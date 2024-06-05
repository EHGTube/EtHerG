using NModbus;
using ScottPlot;
using ETherCheckDataAcq;
using System.ComponentModel;
using ScottPlot.Plottables;
using System.Net.Sockets;
using System.Timers;
using System.IO.Ports;
using InfluxDB;
using System.Collections.Concurrent;
using Newtonsoft.Json.Linq;
using NModbus.Extensions.Enron;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using InfluxDB.Client;
using System.Drawing;
using System;
using System.Management;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Text;


namespace EtHerG
{
    public partial class Form1 : Form
    {
        public ETherRealtimeClass ether = new ETherRealtimeClass(0, 0x70); //Class for the Communication with the EmbedEC


        public ScottPlot.Plottables.DataStreamer StreamX; //StreamX is the Plotted Line in the Line Diagram for the X Values 
        public ScottPlot.Plottables.DataStreamer StreamY; //StreamY is the Plotted Line in the Line Diagram for the Y Values

        public InfluxDBClient influxDBClient;

        private TcpClient modbusClient;
        private IModbusMaster modbusMaster;
        public bool ModbusCon = false; //current connection status
        public int FrequencyModbusVal; //This is the Value which its reading currently
        public int FrequencyModbusLastVal = 0; //This is the Value which it has read last, its used for comparison to see if the Value changed.
        public int GainXModbusVal;
        public int GainXModbusLastVal = 0;
        public int GainYModbusVal;
        public int GainYModbusLastVal = 0;
        public int PhaseModbusVal;
        public int PhaseModbusLastVal = 0;
        public int FilterLPModbusVal;
        public int FilterLPModbusLastVal = 0;
        public int FilterHPModbusVal;
        public int FilterHPModbusLastVal = 0;
        public bool Alarm1SingleWrite = false; //These two bools are used to debounce modbus writing time, it will wait one second since the last alarm before writing it to false. 
        public bool Alarm2SingleWrite = false;

        public List<double> dataX = new List<double>(); //this is the buffer for the Values between reading them from the EmbedEC and writing it into the Graph
        public List<double> dataY = new List<double>();
        public List<double> ScatterX = new List<double>(); //same as datax/y but for the scatter diagram
        public List<double> ScatterY = new List<double>();
        public List<double> lastSpecifiedXValues = new List<double>(); //this will only take the last specified values (specified by the user) and display them
        public List<double> lastSpecifiedYValues = new List<double>();

        public int counter = 0; //this will count how many times the NewRealtimeData Method is called in a second
        public bool firstCon = false; //this will make sure some functions will only be run once 
        public int Xval; //current Values
        public int Yval;
        private System.Timers.Timer resetTimer; //Timer for the P/S Counting Function
        private System.Timers.Timer ModbusTimer; //Cycle Timer to read from Modbus
        private System.Timers.Timer Alarm1Timer; //Alarm Debouncing function
        private System.Timers.Timer Alarm2Timer;
        private System.Timers.Timer AlarmStartupBlock; //Timer which will block alarms upon startup for some time

        public long SumX1; //Sum used to calculate the Average (it will sum the values and then divide them by the Change divider
        public long SumY1;
        public Int32 AverageX1; //The Average Measured Value used to offset the current Value to the middle
        public Int32 AverageY1;
        public int ChangeCounterStepper; //Test this, its supposed to 
        public int ChangeCounterDivider; //Test this
        public long ChangeCounter;
        public int DisplayX1 = 0; //Corrected Measurement value (so its always in the middle) 
        public int DisplayY1 = 0;
        public bool Play = true; //can be controlled via Modbus to start / stop the measurement (machine running/tube in machine)
        bool PlayModbusLastVal = false;

        public bool EtherConnected = false; //To block multiple connection attempts or disconnection attempts
        public bool login = false; //current login status 

        private readonly object dataLockX = new object(); //used to lock access to datax / y / scatter
        private readonly object dataLockY = new object();
        private readonly object dataLockScatter = new object();

        public bool AlarmReady = false; //after a parameter change or on startup this will actually block the alarm coil 

        List<string> PropertiesSetToZeroOrNull = new List<string>(); //this is used to print a list of not set parameters for a function. E.g. User wants to connect to embedec but doesnt have a COM Port specified

        string InternationalizationWrongPassword; //These Strings will be written in the Internationalization Method with different error messages in the corresponding language. 
        string InternationalizationConnectionFailed;
        string InternationalizationMissingProperties;
        string InternationalizationModbusConnectionFailed;
        string InternationalizationFalseColor;

        private DateTime MouseWheelDebounce = DateTime.MinValue; //Debouncer for the MouseWheel Action so it will not send the parameters to modbus/influxdb/embedec on every mousewheel action

        public double VectorLength;
        private bool isClosing = false;
        string lasterror = "";

        public Form1()
        {
            InitializeComponent();
            initvoid();
            ether.RegisterDataCallback(NewRealtimeData);
            DiagWorker.DoWork += DiagWorker_DoWork;
            ModbusWorker.DoWork += ModbusWorker_DoWork;
            this.FormClosing += Form1_FormClosing;
        }

        private void initvoid()
        {
            if (firstCon == false)
            {
                DiagWorker = new BackgroundWorker(); //The DiagWorker will do the Updates to the Charts in the Background
                DiagWorker.WorkerSupportsCancellation = true;

                ModbusWorker = new BackgroundWorker(); //The ModbusWorker will do the Reading Operations for Modbus Communication in the Background
                ModbusWorker.WorkerSupportsCancellation = true;

                EtHerG.Properties.Settings.Default.PropertyChanged += Settings_PropertyChanged; //Registering the Event to pass parameters to the embedEC

                if (EtHerG.Properties.Settings.Default.InfluxDBEnabled == true)
                {
                    //If InfluxDB should be used
                    influxDBClient = new InfluxDBClient(EtHerG.Properties.Settings.Default.InfluxDBServer, EtHerG.Properties.Settings.Default.InfluxDBToken);
                }

                StreamX = formLineDiag.Plot.Add.DataStreamer(EtHerG.Properties.Settings.Default.LineDiagPoints); //Add the Streamers to the LineDiag
                StreamY = formLineDiag.Plot.Add.DataStreamer(EtHerG.Properties.Settings.Default.LineDiagPoints);

                // Initialize and start the timer for resetting dataX and counter every second
                resetTimer = new System.Timers.Timer(1000); // Timer interval in milliseconds (1 second)
                resetTimer.Elapsed += ResetTimer_Elapsed;
                resetTimer.AutoReset = true; // Set AutoReset to true for periodic triggering
                resetTimer.Start();


                ModbusTimer = new System.Timers.Timer(30);
                //30ms is the update time for the EasyE4, other devices might feature a different update timme. 
                ModbusTimer.Elapsed += ModbusTimer_Elapsed;
                ModbusTimer.AutoReset = true;
                ModbusTimer.Start();


                //Every Time Alarm1 or Alarm2 is activated, it will write the specified Modbus Coil to high for one second since the last time it has been activated
                Alarm1Timer = new System.Timers.Timer(1000);
                Alarm1Timer.Elapsed += Alarm1Timer_Elapsed;

                Alarm2Timer = new System.Timers.Timer(1000);
                Alarm2Timer.Elapsed += Alarm2Timer_Elapsed;

                //This will deactivate any alarms for the first 3 seconds since the value offset hasnt been calculated yet
                AlarmStartupBlock = new System.Timers.Timer(3000);
                AlarmStartupBlock.Elapsed += AlarmStartupBlock_Elapsed;
                AlarmStartupBlock.Start();

                firstCon = true; //this is just so it will not go into this method again. 
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            //This whole Method will do the basic Setup for the UI. 
            //It will fill out the Text Fields with the last entered Values so the User knows how the Tool is Set up right now
            //It will run the Internationalization so all labeling and messages are in the user specified language
            //It will format the Graphs like specified
            //If specified, it will connect to Modbus or EmbedEC, automatically log in (if specified before) and disable the user Input possibilities
            base.OnLoad(e);
            Invoke(new Action(() =>
            {
                this.AutoSize = true;
                txtFrequencyLast.Text = EtHerG.Properties.Settings.Default.Frequency.ToString();
                txtGainXLast.Text = EtHerG.Properties.Settings.Default.GainX.ToString();
                txtGainYLast.Text = EtHerG.Properties.Settings.Default.GainY.ToString();
                txtPhaseLast.Text = EtHerG.Properties.Settings.Default.Phase.ToString();
                txtFilterLPLast.Text = EtHerG.Properties.Settings.Default.FilterLP.ToString();
                txtFilterHPLast.Text = EtHerG.Properties.Settings.Default.FilterHP.ToString();
                chkEtherAutoconnect.Checked = EtHerG.Properties.Settings.Default.EtherAutoconnect;
                txtScatterPoints.Text = EtHerG.Properties.Settings.Default.ScatterPoints.ToString();
                txtModbusServerIP.Text = EtHerG.Properties.Settings.Default.ModbusServerIP.ToString();
                txtModbusServerPort.Text = EtHerG.Properties.Settings.Default.ModbusServerPort.ToString();
                txtFilterHPModbusAddress.Text = EtHerG.Properties.Settings.Default.FilterHPModbusAddress.ToString();
                txtFilterLPModbusAddress.Text = EtHerG.Properties.Settings.Default.FilterLPModbusAddress.ToString();
                txtFrequencyModbusAddress.Text = EtHerG.Properties.Settings.Default.FrequencyModbusAddress.ToString();
                txtGainXModbusAddress.Text = EtHerG.Properties.Settings.Default.GainXModbusAddress.ToString();
                txtGainYModbusAddress.Text = EtHerG.Properties.Settings.Default.GainYModbusAddress.ToString();
                txtPhaseModbusAddress.Text = EtHerG.Properties.Settings.Default.PhaseModbusAddress.ToString();
                chkModbusAutoconnect.Checked = EtHerG.Properties.Settings.Default.ModbusAutoconnect;
                txtCOMPort.Text = EtHerG.Properties.Settings.Default.ComPort.ToString();
                txtPlayModbusAddress.Text = EtHerG.Properties.Settings.Default.PlayModbusAddress.ToString();
                txtDiagMaxPointSize.Text = EtHerG.Properties.Settings.Default.DiagMaxPointSize.ToString();
                txtLineDiagPoints.Text = EtHerG.Properties.Settings.Default.LineDiagPoints.ToString();
                chkAutologin.Checked = EtHerG.Properties.Settings.Default.Autologin;
                txtAlarm1Value.Text = EtHerG.Properties.Settings.Default.Alarm1ModbusAddress.ToString();
                txtAlarm2Value.Text = EtHerG.Properties.Settings.Default.Alarm2ModbusAddress.ToString();
                txtLineDiagPosX.Text = EtHerG.Properties.Settings.Default.LineDiagPosX.ToString();
                txtLineDiagPosY.Text = EtHerG.Properties.Settings.Default.LineDiagPosY.ToString();
                txtLineDiagSizeX.Text = EtHerG.Properties.Settings.Default.LineDiagSizeX.ToString();
                txtLineDiagSizeY.Text = EtHerG.Properties.Settings.Default.LineDiagSizeY.ToString();
                txtScatterDiagPosX.Text = EtHerG.Properties.Settings.Default.ScatterDiagPosX.ToString();
                txtScatterDiagPosY.Text = EtHerG.Properties.Settings.Default.ScatterDiagPosY.ToString();
                txtScatterDiagSize.Text = EtHerG.Properties.Settings.Default.ScatterDiagSize.ToString();
                txtAlarm1Value.Text = EtHerG.Properties.Settings.Default.Alarm1Value.ToString();
                txtAlarm2Value.Text = EtHerG.Properties.Settings.Default.Alarm2Value.ToString();
                chkDisableUserInput.Checked = EtHerG.Properties.Settings.Default.DisableUserInput;
                txtAlarm1ModbusAddress.Text = EtHerG.Properties.Settings.Default.Alarm1ModbusAddress.ToString();
                txtAlarm2ModbusAddress.Text = EtHerG.Properties.Settings.Default.Alarm2ModbusAddress.ToString();
                txtFrequencyModbusLastSentAddress.Text = EtHerG.Properties.Settings.Default.FrequencyModbusLastSendAddress.ToString();
                txtGainXModbusLastSentAddress.Text = EtHerG.Properties.Settings.Default.GainXModbusLastSendAddress.ToString();
                txtGainYModbusLastSentAddress.Text = EtHerG.Properties.Settings.Default.GainYModbusLastSendAddress.ToString();
                txtPhaseModbusLastSentAddress.Text = EtHerG.Properties.Settings.Default.PhaseModbusLastSendAddress.ToString();
                txtFilterLPModbusLastSentAddress.Text = EtHerG.Properties.Settings.Default.FilterLPModbusLastSendAddress.ToString();
                txtFilterHPModbusLastSentAddress.Text = EtHerG.Properties.Settings.Default.FilterHPModbusLastSendAddress.ToString();
                chkModbusLastSentAddressEnabled.Checked = EtHerG.Properties.Settings.Default.ModbusLastSentAddressEnabled;
                chkInfluxDBEnabled.Checked = EtHerG.Properties.Settings.Default.InfluxDBEnabled;
                txtInfluxDBServer.Text = EtHerG.Properties.Settings.Default.InfluxDBServer;
                txtInfluxDBToken.Text = EtHerG.Properties.Settings.Default.InfluxDBToken;
                txtInfluxDBOrg.Text = EtHerG.Properties.Settings.Default.InfluxDBOrgID;
                txtInfluxDBBucket.Text = EtHerG.Properties.Settings.Default.InfluxDBBucket;
                txtInfluxDBMachine.Text = EtHerG.Properties.Settings.Default.InfluxDBMachine;
                chkShowX.Checked = EtHerG.Properties.Settings.Default.ShowX;
                chkShowY.Checked = EtHerG.Properties.Settings.Default.ShowY;
                txtAlarm1Color.Text = EtHerG.Properties.Settings.Default.Alarm1Color;
                txtAlarm2Color.Text = EtHerG.Properties.Settings.Default.Alarm2Color;
                txtLineDiagColorX.Text = EtHerG.Properties.Settings.Default.LineDiagColorX;
                txtLineDiagColorY.Text = EtHerG.Properties.Settings.Default.LineDiagColorY;
                txtScatterDiagColor.Text = EtHerG.Properties.Settings.Default.ScatterDiagColor;
                chkScatterDrawPoints.Checked = EtHerG.Properties.Settings.Default.ScatterDiagDrawPoints;
                txtMaxPoints.Text = EtHerG.Properties.Settings.Default.MaxPoints.ToString();
                chkEqualGain.Checked = EtHerG.Properties.Settings.Default.EqualGain;
                txtAmountAveragePoints.Text = EtHerG.Properties.Settings.Default.AmountAveragePoints.ToString();
                chkAutoscale.Checked = EtHerG.Properties.Settings.Default.Autoscale;

                formLineDiag.Location = new Point(EtHerG.Properties.Settings.Default.LineDiagPosX, EtHerG.Properties.Settings.Default.LineDiagPosY);
                formLineDiag.Size = new Size(EtHerG.Properties.Settings.Default.LineDiagSizeX, EtHerG.Properties.Settings.Default.LineDiagSizeY);
                formScatter.Location = new Point(EtHerG.Properties.Settings.Default.ScatterDiagPosX, EtHerG.Properties.Settings.Default.ScatterDiagPosY);
                formScatter.Size = new Size(EtHerG.Properties.Settings.Default.ScatterDiagSize, EtHerG.Properties.Settings.Default.ScatterDiagSize);

                Internationalization();

                FormatLineDiag();

                formLineDiag.Plot.Axes.SetLimits(0, EtHerG.Properties.Settings.Default.LineDiagPoints, -EtHerG.Properties.Settings.Default.DiagMaxPointSize, EtHerG.Properties.Settings.Default.DiagMaxPointSize);

                if (EtHerG.Properties.Settings.Default.EtherAutoconnect == true) { OpenSerialConnection(); }

                if (EtHerG.Properties.Settings.Default.ModbusAutoconnect == true) { OpenModbusConnection(); }

                if (EtHerG.Properties.Settings.Default.Autologin == true)
                {
                    LoggedIn();
                }
                else
                {
                    LoggedOut();
                }

                if (EtHerG.Properties.Settings.Default.DisableUserInput == true) { DisableUserInput(); }
            }));
        }

        private void ResetTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            //Every 1000ms it will update the txtPS how often it has received new Values from the EmbedEC
            if (IsHandleCreated)
            {
                Invoke(new Action(() =>
                {
                    //I Put the If Condition in here to try and catch any write event when the form is closing. 
                    if (!isClosing) { txtPS.Text = counter.ToString(); }
                }));
            }
            counter = 0;


            //I also added the Function in here to check if the Error String from the ether DLL has changed.
            //If its changed it will add the errors to the list.
            //Obviously only if we are actually connected.
            if (EtherConnected)
            {
                string errorString = ether.GetError();

                if (errorString != lasterror)
                {
                    Invoke(new Action(() =>
                    {
                        listEtherError.Items.Add(errorString);
                    }));
                }
                lasterror = errorString;
            }
        }

        private void ModbusTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            //If the Modbusworker isnt busy right now (which would be fine) it will run the Background Worker every 30ms to check all the Modbus Values.
            //If the Delay is too big it would be bad because it has to be somewhat realtime because out of line tube inspection speed is at 60m/s and at 30ms we already have a ~1.8mm Delay between light barrier and measurement. 
            //Obviously the first few millimeters of a tube and the last cannot be measured but its better to measure and block out than to not measure at all. 
            if (!ModbusWorker.IsBusy)
            {
                ModbusWorker.RunWorkerAsync();
            }
        }

        private void Alarm1Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            //This will reset the specified Alarm1 Modbus Address Coil 
            Alarm1Timer.Stop();
            Alarm1SingleWrite = false;

            if (ModbusCon) { modbusMaster.WriteSingleCoil(1, EtHerG.Properties.Settings.Default.Alarm1ModbusAddress, false); }

            if (EtHerG.Properties.Settings.Default.InfluxDBEnabled)
            {
                var alarmData = PointData.Measurement("Alarms")
                    .Tag("device", EtHerG.Properties.Settings.Default.InfluxDBMachine)
                    .Field("Alarm1", false)
                    .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

                influxDBClient.GetWriteApi().WritePoint(alarmData, EtHerG.Properties.Settings.Default.InfluxDBBucket, EtHerG.Properties.Settings.Default.InfluxDBOrgID);
            }
        }

        private void Alarm2Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            //This will reset the specified Alarm2 Modbus Address Coil 
            Alarm2Timer.Stop();
            Alarm2SingleWrite = false;

            if (ModbusCon) { modbusMaster.WriteSingleCoil(1, EtHerG.Properties.Settings.Default.Alarm2ModbusAddress, false); }

            if (EtHerG.Properties.Settings.Default.InfluxDBEnabled)
            {
                var alarmData = PointData.Measurement("Alarms")
                    .Tag("device", EtHerG.Properties.Settings.Default.InfluxDBMachine)
                    .Field("Alarm2", false)
                    .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

                influxDBClient.GetWriteApi().WritePoint(alarmData, EtHerG.Properties.Settings.Default.InfluxDBBucket, EtHerG.Properties.Settings.Default.InfluxDBOrgID);
            }
        }

        private void AlarmStartupBlock_Elapsed(object? sender, ElapsedEventArgs e)
        {
            AlarmReady = true;
        }

        private void FormatLineDiag()
        {
            Invoke(new Action(() =>
            {
                //The order of these commands is very important
                //Keep in mind nearly all of this is for the LineDiagram. 
                //The Scatter Diagram formatting has to be done by the DiagWorker Background Worker, look there for more information
                formLineDiag.Reset(); //This will basically clean everything from the formLineDiag
                StreamX.Clear(); //This will clear everything from StreamX
                StreamY.Clear();
                StreamX = formLineDiag.Plot.Add.DataStreamer(EtHerG.Properties.Settings.Default.LineDiagPoints); //This will Set Up StreamX again
                StreamY = formLineDiag.Plot.Add.DataStreamer(EtHerG.Properties.Settings.Default.LineDiagPoints);
                StreamX.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.LineDiagColorX); //This will format the Color for the new StreamX
                StreamY.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.LineDiagColorY);
                StreamY.ViewScrollLeft(); //This will Set up the Scroll Direction for StreamX
                StreamX.ViewScrollLeft();


                //Yes the following Alarm naming scheme is confusing because im mixing the Alarm declarations for the Line Diagrams and the Alarm Naming which the User can specify. 
                //Basically, the User can Specify Alarm1 (this will be Alarm 1 and Alarm 2 in the Diagram) and Alarm2 (which will be Alarm 3 and 4). 
                //This only matters when you read this here, this will not be mentioned anymore again so just dont be confused here and youre good. 

                HorizontalLine Alarm1 = formLineDiag.Plot.Add.HorizontalLine(EtHerG.Properties.Settings.Default.Alarm1Value); //Alarm 1 and Alarm 2 are basically the two Lines for Alarm 1
                HorizontalLine Alarm2 = formLineDiag.Plot.Add.HorizontalLine(-EtHerG.Properties.Settings.Default.Alarm1Value); //Both are the same Value one is positive and one is negative
                Alarm1.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.Alarm1Color);
                Alarm2.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.Alarm1Color);

                HorizontalLine Alarm3 = formLineDiag.Plot.Add.HorizontalLine(EtHerG.Properties.Settings.Default.Alarm2Value); //Alarm 3 and 4 are like Alarm 1 and 2 but for "User Alarm2" 
                HorizontalLine Alarm4 = formLineDiag.Plot.Add.HorizontalLine(-EtHerG.Properties.Settings.Default.Alarm2Value);
                Alarm3.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.Alarm2Color);
                Alarm4.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.Alarm2Color);

                //these two Textboxes (txtColorX and txtColorY) are ment to show the User in the Top of the Form what Color he has currently specified for X and for Y. 
                //I didnt want to use a Legend as it would be harder to Set up I guess. 
                txtColorX.BackColor = System.Drawing.ColorTranslator.FromHtml(EtHerG.Properties.Settings.Default.LineDiagColorX);
                txtColorY.BackColor = System.Drawing.ColorTranslator.FromHtml(EtHerG.Properties.Settings.Default.LineDiagColorY);
                txtColorY.Enabled = false;
                txtColorX.Enabled = false;



                //Here we just decide on wether the Diagram will autoscale to size (probaply useful for in line applications?) 
                if (EtHerG.Properties.Settings.Default.Autoscale)
                {
                    formLineDiag.Plot.Axes.ContinuouslyAutoscale = true;
                }
                else //And wether it should force a certain size and stay in this window. This will probaply be the more used application
                {
                    StreamX.ManageAxisLimits = false; //This will force that the LineDiagram will not auto size its diagram
                    StreamY.ManageAxisLimits = false;
                    //This will again force the Diagram into the User Specified Size, disable any interaction (so the User cannot scroll around in it maybe messing it up and Refresh the whole UI so it will load the Changes
                    formLineDiag.Plot.Axes.SetLimits(0, EtHerG.Properties.Settings.Default.LineDiagPoints, -EtHerG.Properties.Settings.Default.DiagMaxPointSize, EtHerG.Properties.Settings.Default.DiagMaxPointSize);
                }
                formLineDiag.Interaction.Disable();
                formLineDiag.Refresh();
            }));
        }

        public void FormatScatterDiag()
        {
            Invoke(new Action(() =>
            {
                //Then we clear the whole ScatterPlot and add all formatting again, starting with the Alarm Rectangles 
                formScatter.Plot.Clear();
                //var Alarm5 = formScatter.Plot.Add.Rectangle(-EtHerG.Properties.Settings.Default.Alarm1Value, EtHerG.Properties.Settings.Default.Alarm1Value, -EtHerG.Properties.Settings.Default.Alarm1Value, EtHerG.Properties.Settings.Default.Alarm1Value);
                //var Alarm6 = formScatter.Plot.Add.Rectangle(-EtHerG.Properties.Settings.Default.Alarm2Value, EtHerG.Properties.Settings.Default.Alarm2Value, -EtHerG.Properties.Settings.Default.Alarm2Value, EtHerG.Properties.Settings.Default.Alarm2Value);

                var Alarm5 = formScatter.Plot.Add.Circle(0, 0, EtHerG.Properties.Settings.Default.Alarm1Value);
                var Alarm6 = formScatter.Plot.Add.Circle(0, 0, EtHerG.Properties.Settings.Default.Alarm2Value);
                Alarm5.FillStyle.Color = ScottPlot.Color.FromHex("#D22B2B").WithAlpha(0);
                Alarm6.FillStyle.Color = ScottPlot.Color.FromHex("#388e3c").WithAlpha(0);
                Alarm5.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.Alarm1Color); // Alarm 1
                Alarm6.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.Alarm2Color); // Alarm 2
                Alarm5.LineStyle.Width = 3;
                Alarm6.LineStyle.Width = 3;

                //We will set the Size of the Diagram, Disable Interaction (so it cannot be scrolled around etc. and refresh the Diagram. 

                if (EtHerG.Properties.Settings.Default.Autoscale)
                {
                    formScatter.Plot.Axes.ContinuouslyAutoscale = true;
                }
                else
                {
                    formScatter.Plot.Axes.SetLimits(-EtHerG.Properties.Settings.Default.DiagMaxPointSize, EtHerG.Properties.Settings.Default.DiagMaxPointSize, -EtHerG.Properties.Settings.Default.DiagMaxPointSize, EtHerG.Properties.Settings.Default.DiagMaxPointSize);
                }
                formScatter.Interaction.Disable();

            }));
        }

        public void NewRealtimeData(Int32 X1, Int32 Y1, Int32 X2, Int32 Y2, Int32 Xmix_or_percent, Int32 Ymix_or_percent, Int32 Theta_or_status_X, Int32 Radius_or_status_Y)
        {
            //NewRealtimeData is the whole Method for Reading/Using Values from the EmbedEC. 
            counter++; //Adding a +1 to the Counter is the first Operation as no matter the Value of X1/Y1, it has run this method

            if (X1 > -50000 && X1 < 50000 && Y1 > -50000 && Y1 < 50000 && Play)
            {
                //Sometimes the EmbedEC returns a crazy high/low Value so I just filter this out from the start. 
                //Also I will only continue if Play is true. This had to be changed up to here because the Offset Calculation shouldnt continue when theres no measurement active.
                //No Measurement active might mean no tube in machine which would result in a different average position due to different magnetic properties of tube present vs tube not present
                //Maybe this has to be further tweaked. 


                //All of the following is to create an average X and Y Value to offset the current measurement to 0. 
                //Other Devices will require this manually but for this application its easier to 

                ChangeCounter++; //This is to count how many points we have added in the two following Sum Variables
                SumX1 += Convert.ToInt64(X1);
                SumY1 += Convert.ToInt64(Y1);

                if (ChangeCounter >= EtHerG.Properties.Settings.Default.AmountAveragePoints) //If the Counter exceeds 10000 we will create the Average Value, this can be changed. Perhaps you want a more accurate average or you want a faster reacting average. 
                {
                    AverageX1 = (int)(SumX1 / ChangeCounter); //Im dividing with the ChangeCounter and not 10.000 Values because I might have run over the 10.000 Values 
                    AverageY1 = (int)(SumY1 / ChangeCounter);

                    SumX1 = 0; //and in the End reset the Sum and Counter
                    SumY1 = 0;
                    ChangeCounter = 0;
                }

                DisplayX1 = X1 - AverageX1; //Now Apply my Offset to the measured Values to create the functional Value it should Display. 
                DisplayY1 = Y1 - AverageY1;


                VectorLength = Math.Sqrt(Math.Pow(DisplayX1, 2) + Math.Pow(DisplayY1, 2));


                //I have these Locked Down to limit access to the lists between my background worker and this method.
                //Without the Lock there will be conflicts between reading and clearing the list 
                //Here it will add the Offset X/Y Values to the lists for the Line and Scatter Diagrams 
                lock (dataLockX)
                {
                    dataX.Add(DisplayX1);
                }
                lock (dataLockY)
                {
                    dataY.Add(DisplayY1);
                }
                lock (dataLockScatter)
                {
                    ScatterX.Add(DisplayX1);
                    ScatterY.Add(DisplayY1);
                }


                HandleAlarm(EtHerG.Properties.Settings.Default.Alarm1Value, EtHerG.Properties.Settings.Default.Alarm1ModbusAddress, ref Alarm1SingleWrite, ref Alarm1Timer);
                HandleAlarm(EtHerG.Properties.Settings.Default.Alarm2Value, EtHerG.Properties.Settings.Default.Alarm2ModbusAddress, ref Alarm2SingleWrite, ref Alarm2Timer);


                //If dataX list is full, it will run the background worker 
                //The 800 here is actually an important number. The higher the value is the lower should be the Diagram FPS but also lower System Usage.
                //Lower number will increase FPS but also system load. 
                //800 seems to be a good spot 
                if (dataX.Count >= 800 && !DiagWorker.IsBusy && IsHandleCreated)
                {
                    DiagWorker.RunWorkerAsync();
                }
            }
            else
            {
                return;
            }
        }

        void HandleAlarm(int alarmValue, ushort alarmModbusAddress, ref bool singleWriteFlag, ref System.Timers.Timer alarmTimer)
        {
            if (VectorLength > alarmValue && AlarmReady)
            {
                //If im outside of either Alarmvalue Bounds it will start the Timer (or restart) and then either or write the Alarm to the specified Modbus Coil and to the InfluxDB 
                alarmTimer.Stop();
                alarmTimer.Start();
                if (!singleWriteFlag)
                {
                    singleWriteFlag = true;
                    if (ModbusCon) { modbusMaster.WriteSingleCoil(1, alarmModbusAddress, true); }

                    if (EtHerG.Properties.Settings.Default.InfluxDBEnabled)
                    {
                        var alarmData = PointData.Measurement("Alarms")
                            .Tag("device", EtHerG.Properties.Settings.Default.InfluxDBMachine)
                            .Field($"Alarm{(alarmModbusAddress == EtHerG.Properties.Settings.Default.Alarm1ModbusAddress ? 1 : 2)}", true)
                            .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

                        influxDBClient.GetWriteApi().WritePoint(alarmData, EtHerG.Properties.Settings.Default.InfluxDBBucket, EtHerG.Properties.Settings.Default.InfluxDBOrgID);
                    }
                }
            }
        }

        private void DiagWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            Invoke(new Action(() =>
            {
                //if the Background worker is called it will update the two diagrams and then also set the X/Y Value Text Field in the Settings.
                UpdateScatterDiag();
                UpdateLineDiag();

                txtX.Text = DisplayX1.ToString(); // Update textBox1 with X1 value
                txtY.Text = DisplayY1.ToString();
            }));
        }

        private void UpdateLineDiag()
        {
            if (EtHerG.Properties.Settings.Default.ShowX)
            {//ShowX is controlled by the user to control wether it will only show the X/Y Lines or both
                lock (dataLockX) // Lock access to dataX and dataY
                {
                    StreamX.AddRange(dataX); //This will actually then add the recently added points from dataX to the StreamX 
                }
            }

            if (EtHerG.Properties.Settings.Default.ShowY)
            {
                lock (dataLockY) // Lock access to dataX and dataY
                {
                    StreamY.AddRange(dataY);
                }
            }
            //Might not be neccesary (perhaps check and remove later) 
            formLineDiag.Refresh();

            //In the End it will clear the Lists
            dataX.Clear();
            dataY.Clear();
        }

        private void UpdateScatterDiag()
        {
            // The Scatter Diagram has all the Formatting inside the function itself.
            // Why? 
            // Because due to its nature of only showing the last specified Values, it has to clear the graph and draw everything again.
            // The Line Graph will format once and then add points to this formatted form. 

            lock (dataLockScatter)
            {
                //First we enter the dataLock for the Scatter Points and then retrieves the last specified number of X values from the ScatterX list and stores them in lastSpecifiedXValues,
                //taking into account the specified number of points and ensuring that it doesn't attempt to access elements before the beginning of the list
                lastSpecifiedXValues = ScatterX.Skip(Math.Max(0, ScatterX.Count - EtHerG.Properties.Settings.Default.ScatterPoints)).ToList(); // Get last Specified X values
                lastSpecifiedYValues = ScatterY.Skip(Math.Max(0, ScatterY.Count - EtHerG.Properties.Settings.Default.ScatterPoints)).ToList(); // Get last Specified Y values
            }

            FormatScatterDiag();

            //And then if checked we will add the EmbedEC Data via Points 
            if (EtHerG.Properties.Settings.Default.ScatterDiagDrawPoints)
            {
                var ScatterPoints = formScatter.Plot.Add.ScatterPoints(lastSpecifiedXValues, lastSpecifiedYValues);
                ScatterPoints.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.ScatterDiagColor);
                ScatterPoints.MarkerSize = 1;
            }
            else //Or as Lines: 
            {
                var ScatterLine = formScatter.Plot.Add.ScatterLine(lastSpecifiedXValues, lastSpecifiedYValues);
                ScatterLine.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.ScatterDiagColor);
            }
            formScatter.Refresh();

            //Lastly we remove the Range beyond the Values which are outside of the user specified amount anyways. 
            if (lastSpecifiedXValues.Count > EtHerG.Properties.Settings.Default.ScatterPoints)
            {
                lastSpecifiedXValues.RemoveRange(0, (lastSpecifiedXValues.Count - EtHerG.Properties.Settings.Default.ScatterPoints));
                lastSpecifiedYValues.RemoveRange(0, (lastSpecifiedYValues.Count - EtHerG.Properties.Settings.Default.ScatterPoints));
            }

        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If already closing, do nothing
            if (isClosing)
            {
                return;
            }

            // Set flag to indicate closing process is underway
            isClosing = true;

            // Prevent the form from closing immediately
            e.Cancel = true;
            this.Enabled = false;

            // Stop all timers
            resetTimer.Stop();
            ModbusTimer.Stop();
            resetTimer.Dispose();
            resetTimer.Elapsed -= ResetTimer_Elapsed;


            // Cancel the background workers and wait for them to complete
            await CancelBackgroundWorkerAsync(DiagWorker);
            await CancelBackgroundWorkerAsync(ModbusWorker);

            // Close connections if they are open
            if (EtherConnected)
            {
                ether.CloseSerialConnection();
                EtherConnected = false;
            }

            if (ModbusCon)
            {
                CloseModbusConnection();
                ModbusCon = false;
            }

            ether.ResetUSB();

            // Allow the form to close
            this.Close();
        }

        private Task CancelBackgroundWorkerAsync(BackgroundWorker worker)
        {
            var tcs = new TaskCompletionSource<object>();

            if (worker != null && worker.IsBusy)
            {
                worker.RunWorkerCompleted += (s, e) => tcs.SetResult(null);
                worker.CancelAsync();
            }
            else
            {
                tcs.SetResult(null);
            }

            return tcs.Task;
        }

        private void ModbusWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            if (EtHerG.Properties.Settings.Default.PlayModbusAddress != 0 && ModbusCon)
            {
                Play = modbusMaster.ReadCoils(1, EtHerG.Properties.Settings.Default.PlayModbusAddress, 1)[0];
                if (Play == true && PlayModbusLastVal == false)
                {
                    lastSpecifiedXValues.Clear();
                    lastSpecifiedYValues.Clear();
                    ScatterX.Clear();
                    ScatterY.Clear();
                    FormatScatterDiag();
                    FormatLineDiag();

                    SumX1 = 0;
                    SumY1 = 0;
                    ChangeCounter = 0;
                }
                Invoke(new Action(() =>
                {
                    txtPlayLastModbusValue.Text = Play.ToString();
                }));

                PlayModbusLastVal = Play;
            }

            //Test this and Delete Later
            //Read Frequency
            if (EtHerG.Properties.Settings.Default.FrequencyModbusAddress != 0 && ModbusCon)
            {
                FrequencyModbusVal = modbusMaster.ReadHoldingRegisters(1, EtHerG.Properties.Settings.Default.FrequencyModbusAddress, 1)[0];

                if (FrequencyModbusLastVal == 0)
                {
                    FrequencyModbusLastVal = FrequencyModbusVal;
                }

                if (FrequencyModbusLastVal != FrequencyModbusVal)
                {
                    EtHerG.Properties.Settings.Default.Frequency = FrequencyModbusVal;
                    EtHerG.Properties.Settings.Default.Save();
                }
                FrequencyModbusLastVal = FrequencyModbusVal;
            }



            //Read GainX
            if (EtHerG.Properties.Settings.Default.GainXModbusAddress != 0 && ModbusCon)
            {
                GainXModbusVal = modbusMaster.ReadHoldingRegisters(1, EtHerG.Properties.Settings.Default.GainXModbusAddress, 1)[0];

                if (GainXModbusLastVal == 0)
                {
                    GainXModbusLastVal = GainXModbusVal;
                }

                if (GainXModbusLastVal != GainXModbusVal)
                {
                    EtHerG.Properties.Settings.Default.GainX = GainXModbusVal;
                    EtHerG.Properties.Settings.Default.Save();
                }
                GainXModbusLastVal = GainXModbusVal;
            }

            //Read GainY
            if (EtHerG.Properties.Settings.Default.GainYModbusAddress != 0 && ModbusCon)
            {
                GainYModbusVal = modbusMaster.ReadHoldingRegisters(1, EtHerG.Properties.Settings.Default.GainYModbusAddress, 1)[0];

                if (GainYModbusLastVal == 0)
                {
                    GainYModbusLastVal = GainYModbusVal;
                }

                if (GainYModbusLastVal != GainYModbusVal)
                {
                    EtHerG.Properties.Settings.Default.GainY = GainYModbusVal;
                    EtHerG.Properties.Settings.Default.Save();
                }
                GainYModbusLastVal = GainYModbusVal;
            }

            //Read Phase
            if (EtHerG.Properties.Settings.Default.PhaseModbusAddress != 0 && ModbusCon)
            {
                PhaseModbusVal = modbusMaster.ReadHoldingRegisters(1, EtHerG.Properties.Settings.Default.PhaseModbusAddress, 1)[0];

                if (PhaseModbusLastVal == 0)
                {
                    PhaseModbusLastVal = PhaseModbusVal;
                }

                if (PhaseModbusLastVal != PhaseModbusVal)
                {
                    EtHerG.Properties.Settings.Default.Phase = PhaseModbusVal;
                    EtHerG.Properties.Settings.Default.Save();
                }
                PhaseModbusLastVal = PhaseModbusVal;
            }


            //Read FilterLP
            if (EtHerG.Properties.Settings.Default.FilterLPModbusAddress != 0 && ModbusCon)
            {
                FilterLPModbusVal = modbusMaster.ReadHoldingRegisters(1, EtHerG.Properties.Settings.Default.FilterLPModbusAddress, 1)[0];

                if (FilterLPModbusLastVal == 0)
                {
                    FilterLPModbusLastVal = FilterLPModbusVal;
                }

                if (FilterLPModbusLastVal != FilterLPModbusVal)
                {
                    EtHerG.Properties.Settings.Default.FilterLP = FilterLPModbusVal;
                    EtHerG.Properties.Settings.Default.Save();
                }
                FilterLPModbusLastVal = FilterLPModbusVal;
            }


            //Read FilterHP
            if (EtHerG.Properties.Settings.Default.FilterHPModbusAddress != 0 && ModbusCon)
            {
                FilterHPModbusVal = modbusMaster.ReadHoldingRegisters(1, EtHerG.Properties.Settings.Default.FilterHPModbusAddress, 1)[0];

                if (FilterHPModbusLastVal == 0)
                {
                    FilterHPModbusLastVal = FilterHPModbusVal;
                }

                if (FilterHPModbusLastVal != FilterHPModbusVal)
                {
                    EtHerG.Properties.Settings.Default.FilterHP = FilterHPModbusVal;
                    EtHerG.Properties.Settings.Default.Save();
                }
                FilterHPModbusLastVal = FilterHPModbusVal;
            }
        }

        private void CloseModbusConnection()
        {
            if (ModbusCon)
            { //if its connected to Modbus ("ModbusCon") it will close the Connection and set the Connection State to false
                modbusClient.Close();
                ModbusCon = false;
                txtModbusStatus.BackColor = System.Drawing.Color.Red;
            }
        }

        private void OpenModbusConnection()
        {
            //The following is just a function to check if Modbus ServerIP, Port and all Addresses for the Device Parameters have been set. 
            //if not it will not open connection and Display a List with all Parameters not set yet 
            PropertiesSetToZeroOrNull.Clear();
            // Check if ModbusServerIP is set to 0 or null
            if (string.IsNullOrEmpty(EtHerG.Properties.Settings.Default.ModbusServerIP))
            {
                PropertiesSetToZeroOrNull.Add("Modbus Server IP");
            }

            // Check if ModbusServerPort is set to 0 or null
            if (EtHerG.Properties.Settings.Default.ModbusServerPort == 0 || EtHerG.Properties.Settings.Default.ModbusServerPort == null)
            {
                PropertiesSetToZeroOrNull.Add("Modbus Server Port");
            }

            // Check if PlayModbusAddress is set to 0 or null
            if (EtHerG.Properties.Settings.Default.PlayModbusAddress == 0 || EtHerG.Properties.Settings.Default.PlayModbusAddress == null)
            {
                PropertiesSetToZeroOrNull.Add("Play Modbus Address");
            }

            // Check if FrequencyModbusAddress is set to 0 or null
            if (EtHerG.Properties.Settings.Default.FrequencyModbusAddress == 0 || EtHerG.Properties.Settings.Default.FrequencyModbusAddress == null)
            {
                PropertiesSetToZeroOrNull.Add("Frequency Modbus Address");
            }

            if (EtHerG.Properties.Settings.Default.GainXModbusAddress == 0 || EtHerG.Properties.Settings.Default.GainXModbusAddress == null)
            {
                PropertiesSetToZeroOrNull.Add("Gain X Modbus Address");
            }

            if (EtHerG.Properties.Settings.Default.GainYModbusAddress == 0 || EtHerG.Properties.Settings.Default.GainYModbusAddress == null)
            {
                PropertiesSetToZeroOrNull.Add("Gain Y Modbus Address");
            }

            if (EtHerG.Properties.Settings.Default.PhaseModbusAddress == 0 || EtHerG.Properties.Settings.Default.PhaseModbusAddress == null)
            {
                PropertiesSetToZeroOrNull.Add("Phase Modbus Address");
            }

            if (EtHerG.Properties.Settings.Default.FilterLPModbusAddress == 0 || EtHerG.Properties.Settings.Default.FilterLPModbusAddress == null)
            {
                PropertiesSetToZeroOrNull.Add("Filter LP Modbus Address");
            }

            if (EtHerG.Properties.Settings.Default.FilterHPModbusAddress == 0 || EtHerG.Properties.Settings.Default.FilterHPModbusAddress == null)
            {
                PropertiesSetToZeroOrNull.Add("Filter HP Modbus Address");
            }

            // If any Modbus property is set to 0 or null, display a single MessageBox with the list of properties
            if (PropertiesSetToZeroOrNull.Any())
            {

                string message = InternationalizationMissingProperties;

                // Add each Modbus property to the message with a new line
                foreach (string property in PropertiesSetToZeroOrNull)
                {
                    message += $"{property}\n";
                }

                MessageBox.Show(message);
            }
            else
            {
                try
                {
                    //it should try setting up the Connection and then Setting ModbusCon to True and Coloring the "ModbusStatus" Box to Green so the User knows its connected. 
                    modbusClient = new TcpClient(EtHerG.Properties.Settings.Default.ModbusServerIP, EtHerG.Properties.Settings.Default.ModbusServerPort);
                    var factory = new ModbusFactory();
                    modbusMaster = factory.CreateMaster(modbusClient);
                    ModbusCon = true;
                    txtModbusStatus.BackColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    // Log or display a warning that the connection failed
                    MessageBox.Show($"{InternationalizationModbusConnectionFailed}: {ex.Message}");
                    // Stop trying to connect
                    txtModbusStatus.BackColor = System.Drawing.Color.Red;
                    return;
                }
            }
        }

        private void OpenSerialConnection()
        {
            PropertiesSetToZeroOrNull.Clear();

            // Check if Frequency is set to 0 or null
            if (EtHerG.Properties.Settings.Default.Frequency == 0 || EtHerG.Properties.Settings.Default.Frequency == null)
            {
                PropertiesSetToZeroOrNull.Add("Frequency");
            }

            // Check if GainX is set to 0 or null
            if (EtHerG.Properties.Settings.Default.GainX == 0 || EtHerG.Properties.Settings.Default.GainX == null)
            {
                PropertiesSetToZeroOrNull.Add("GainX");
            }

            // Check if GainY is set to 0 or null
            if (EtHerG.Properties.Settings.Default.GainY == 0 || EtHerG.Properties.Settings.Default.GainY == null)
            {
                PropertiesSetToZeroOrNull.Add("GainY");
            }

            // Check if Phase is set to 0 or null
            if (EtHerG.Properties.Settings.Default.Phase == 0 || EtHerG.Properties.Settings.Default.Phase == null)
            {
                PropertiesSetToZeroOrNull.Add("Phase");
            }

            // Check if FilterLP is set to 0 or null
            if (EtHerG.Properties.Settings.Default.FilterLP == 0 || EtHerG.Properties.Settings.Default.FilterLP == null)
            {
                PropertiesSetToZeroOrNull.Add("FilterLP");
            }

            // Check if FilterHP is set to 0 or null
            if (EtHerG.Properties.Settings.Default.FilterHP == 0 || EtHerG.Properties.Settings.Default.FilterHP == null)
            {
                PropertiesSetToZeroOrNull.Add("FilterHP");
            }

            // Check if ComPort is set to 0 or null
            if (EtHerG.Properties.Settings.Default.ComPort == null)
            {
                PropertiesSetToZeroOrNull.Add("ComPort");
            }

            // Check if LineDiagPoints is set to 0 or null
            if (EtHerG.Properties.Settings.Default.LineDiagPoints == 0 || EtHerG.Properties.Settings.Default.LineDiagPoints == null)
            {
                PropertiesSetToZeroOrNull.Add("LineDiagPoints");
            }

            // Check if ScatterPoints is set to 0 or null
            if (EtHerG.Properties.Settings.Default.ScatterPoints == 0 || EtHerG.Properties.Settings.Default.ScatterPoints == null)
            {
                PropertiesSetToZeroOrNull.Add("ScatterPoints");
            }

            // If any property is set to 0, display a single MessageBox with the list of properties
            if (PropertiesSetToZeroOrNull.Any())
            {
                string message = InternationalizationMissingProperties;

                // Add each property to the message with a new line
                foreach (string property in PropertiesSetToZeroOrNull)
                {
                    message += $"{property}\n";
                }

                MessageBox.Show(message);
            }
            else
            {
                if (!EtherConnected)
                {
                    bool result = ether.OpenSerialConnection(EtHerG.Properties.Settings.Default.ComPort);
                    if (result)
                    {
                        EtherConnected = true;
                        txtEtherStatus.BackColor = System.Drawing.Color.Green;

                        txtEtherVersion.Text = ether.GetVersion();

                    }
                    else
                    {
                        MessageBox.Show(InternationalizationConnectionFailed);
                        txtEtherStatus.BackColor = System.Drawing.Color.Red;
                    }
                    System.Threading.Thread.Sleep(100);
                    ether.WriteToInstrument(1, 0, "<USB_OUTPUT>0</USB_OUTPUT>");
                    System.Threading.Thread.Sleep(100);
                    ether.WriteToInstrument(1, 0, "<USB_OUTPUT>7</USB_OUTPUT>");

                    ether.WriteToInstrument(1, 0, "<FREQUENCY>" + EtHerG.Properties.Settings.Default.Frequency * 1000 + "</FREQUENCY>");
                    ether.WriteToInstrument(1, 0, "<GAIN_X>" + EtHerG.Properties.Settings.Default.GainX * 10 + "</GAIN_X>");
                    ether.WriteToInstrument(1, 0, "<GAIN_Y>" + EtHerG.Properties.Settings.Default.GainY * 10 + "</GAIN_Y>");
                    ether.WriteToInstrument(1, 0, "<PHASE>" + EtHerG.Properties.Settings.Default.Phase * 1000 + "</PHASE>");
                    ether.WriteToInstrument(1, 0, "<FILTER_LP>" + EtHerG.Properties.Settings.Default.FilterLP * 100 + "</FILTER_LP>");
                    ether.WriteToInstrument(1, 0, "<FILTER_HP>" + EtHerG.Properties.Settings.Default.FilterHP * 100 + "</FILTER_HP>");
                }
            }
        }

        private void btnEtherConnect_Click(object sender, EventArgs e)
        {
            OpenSerialConnection();
        }

        private void btnEtherDisconnect_Click(object sender, EventArgs e)
        {
            if (EtherConnected == true) { ether.CloseSerialConnection(); EtherConnected = false; }
            ether.ResetUSB(); //TEST THIS
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == EtHerG.Properties.Settings.Default.Password) { LoggedIn(); }
            else { MessageBox.Show(InternationalizationWrongPassword); }
        }

        private void LoggedIn()
        {
            panelPassword.Visible = true;
            panelModbusSettings.Visible = true;
            panelInfluxDBSettings.Visible = true;
            panelLoggedInSettings.Visible = true;
            btnLogin.Visible = false;
            btnLogout.Visible = true;
            panelEtherInformation.Visible = true;
        }

        private void LoggedOut()
        {
            panelPassword.Visible = false;
            panelModbusSettings.Visible = false;
            panelInfluxDBSettings.Visible = false;
            panelLoggedInSettings.Visible = false;
            btnLogin.Visible = true;
            btnLogout.Visible = false;
            panelEtherInformation.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoggedOut();
        }

        private void txtFrequencyUserInput_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFrequencyUserInput.Text) && float.TryParse(txtFrequencyUserInput.Text, out float Value))
            {
                EtHerG.Properties.Settings.Default.Frequency = Value;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtGainXUserInput_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGainXUserInput.Text) && float.TryParse(txtGainXUserInput.Text, out float Value))
            {
                EtHerG.Properties.Settings.Default.GainX = Value;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtGainYUserInput_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGainYUserInput.Text) && float.TryParse(txtGainYUserInput.Text, out float Value))
            {
                EtHerG.Properties.Settings.Default.GainY = Value;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtPhaseUserInput_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPhaseUserInput.Text) && float.TryParse(txtPhaseUserInput.Text, out float Value) && Value >= 1 && Value <= 360)
            {
                EtHerG.Properties.Settings.Default.Phase = Value;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtFilterLPUserInput_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFilterLPUserInput.Text) && float.TryParse(txtFilterLPUserInput.Text, out float Value))
            {
                EtHerG.Properties.Settings.Default.FilterLP = Value;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtFilterHPUserInput_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFilterHPUserInput.Text) && float.TryParse(txtFilterHPUserInput.Text, out float Value))
            {
                EtHerG.Properties.Settings.Default.FilterHP = Value;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void btnModbusConnect_Click(object sender, EventArgs e)
        {
            OpenModbusConnection();
        }

        private void btnModbusDisconnect_Click(object sender, EventArgs e)
        {
            CloseModbusConnection();
        }

        private void chkShowX_CheckedChanged(object sender, EventArgs e)
        {
            StreamX.Clear();
            EtHerG.Properties.Settings.Default.ShowX = chkShowX.Checked;
            EtHerG.Properties.Settings.Default.Save();
        }

        private void chkShowY_CheckedChanged(object sender, EventArgs e)
        {
            StreamY.Clear();
            EtHerG.Properties.Settings.Default.ShowY = chkShowY.Checked;
            EtHerG.Properties.Settings.Default.Save();
        }

        private void chkEtherAutoconnect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEtherAutoconnect.Checked)
            {
                EtHerG.Properties.Settings.Default.EtherAutoconnect = true;
            }
            else
            {
                EtHerG.Properties.Settings.Default.EtherAutoconnect = false;
            }
            EtHerG.Properties.Settings.Default.Save();
        }

        private void chkModbusAutoconnect_CheckedChanged(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.ModbusAutoconnect = chkModbusAutoconnect.Checked;
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtPlayModbusAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPlayModbusAddress.Text) && ushort.TryParse(txtPlayModbusAddress.Text, out ushort PlayModbusAddress))
            {
                EtHerG.Properties.Settings.Default.PlayModbusAddress = PlayModbusAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtAlarm1Value_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAlarm1Value.Text) && int.TryParse(txtAlarm1Value.Text, out int alarm1Value))
            {
                EtHerG.Properties.Settings.Default.Alarm1Value = alarm1Value;
                EtHerG.Properties.Settings.Default.Save();
                FormatLineDiag();
            }
        }

        private void txtAlarm2Value_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAlarm2Value.Text) && int.TryParse(txtAlarm2Value.Text, out int alarm2Value))
            {
                EtHerG.Properties.Settings.Default.Alarm2Value = alarm2Value;
                EtHerG.Properties.Settings.Default.Save();
                FormatLineDiag();
            }
        }

        private void txtFrequencyModbusAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFrequencyModbusAddress.Text) && ushort.TryParse(txtFrequencyModbusAddress.Text, out ushort FrequencyModbusAddress))
            {
                EtHerG.Properties.Settings.Default.FrequencyModbusAddress = FrequencyModbusAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtGainXModbusAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGainXModbusAddress.Text) && ushort.TryParse(txtGainXModbusAddress.Text, out ushort GainXModbusAddress))
            {
                EtHerG.Properties.Settings.Default.GainXModbusAddress = GainXModbusAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtGainYModbusAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGainYModbusAddress.Text) && ushort.TryParse(txtGainYModbusAddress.Text, out ushort GainYModbusAddress))
            {
                EtHerG.Properties.Settings.Default.GainYModbusAddress = GainYModbusAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtPhaseModbusAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPhaseModbusAddress.Text) && ushort.TryParse(txtPhaseModbusAddress.Text, out ushort PhaseModbusAddress))
            {
                EtHerG.Properties.Settings.Default.PhaseModbusAddress = PhaseModbusAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtFilterLPModbusAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFilterLPModbusAddress.Text) && ushort.TryParse(txtFilterLPModbusAddress.Text, out ushort FilterLPModbusAddress))
            {
                EtHerG.Properties.Settings.Default.FilterLPModbusAddress = FilterLPModbusAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtFilterHPModbusAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFilterHPModbusAddress.Text) && ushort.TryParse(txtFilterHPModbusAddress.Text, out ushort FilterHPModbusAddress))
            {
                EtHerG.Properties.Settings.Default.FilterHPModbusAddress = FilterHPModbusAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtScatterPoints_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtScatterPoints.Text) && int.TryParse(txtScatterPoints.Text, out int ScatterPoints))
            {
                EtHerG.Properties.Settings.Default.ScatterPoints = ScatterPoints;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtModbusServerIP_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.ModbusServerIP = txtModbusServerIP.Text;
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtModbusServerPort_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtModbusServerPort.Text) && int.TryParse(txtModbusServerPort.Text, out int ModbusServerPort))
            {
                EtHerG.Properties.Settings.Default.ModbusServerPort = ModbusServerPort;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtCOMPort_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCOMPort.Text) && int.TryParse(txtCOMPort.Text, out int ComPort))
            {
                EtHerG.Properties.Settings.Default.ComPort = ComPort;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtLineDiagPoints_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLineDiagPoints.Text) && Int32.TryParse(txtLineDiagPoints.Text, out int LineDiagPoints) && LineDiagPoints < EtHerG.Properties.Settings.Default.MaxPoints)
            {
                EtHerG.Properties.Settings.Default.LineDiagPoints = LineDiagPoints;
                EtHerG.Properties.Settings.Default.Save();
                FormatLineDiag();
            }
        }

        private void txtLineDiagHeight_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDiagMaxPointSize.Text) && Int32.TryParse(txtDiagMaxPointSize.Text, out int LineDiagHeight))
            {
                EtHerG.Properties.Settings.Default.DiagMaxPointSize = LineDiagHeight;
                EtHerG.Properties.Settings.Default.Save();
                FormatLineDiag();
            }
        }

        private void txtScatterDiagPosX_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtScatterDiagPosX.Text) && Int32.TryParse(txtScatterDiagPosX.Text, out int ScatterDiagPosX))
            {
                EtHerG.Properties.Settings.Default.ScatterDiagPosX = ScatterDiagPosX;
                EtHerG.Properties.Settings.Default.Save();
                formScatter.Location = new Point(EtHerG.Properties.Settings.Default.ScatterDiagPosX, EtHerG.Properties.Settings.Default.ScatterDiagPosY);
            }
        }

        private void txtScatterDiagPosY_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtScatterDiagPosY.Text) && Int32.TryParse(txtScatterDiagPosY.Text, out int ScatterDiagPosY))
            {
                EtHerG.Properties.Settings.Default.ScatterDiagPosY = ScatterDiagPosY;
                EtHerG.Properties.Settings.Default.Save();
                formScatter.Location = new Point(EtHerG.Properties.Settings.Default.ScatterDiagPosX, EtHerG.Properties.Settings.Default.ScatterDiagPosY);
            }
        }

        private void txtScatterDiagSize_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtScatterDiagSize.Text) && Int32.TryParse(txtScatterDiagSize.Text, out int ScatterDiagSize))
            {
                EtHerG.Properties.Settings.Default.ScatterDiagSize = ScatterDiagSize;
                EtHerG.Properties.Settings.Default.Save();
                formScatter.Size = new Size(EtHerG.Properties.Settings.Default.ScatterDiagSize, EtHerG.Properties.Settings.Default.ScatterDiagSize);
            }
        }

        private void txtLineDiagPosX_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLineDiagPosX.Text) && Int32.TryParse(txtLineDiagPosX.Text, out int LineDiagPosX))
            {
                EtHerG.Properties.Settings.Default.LineDiagPosX = LineDiagPosX;
                EtHerG.Properties.Settings.Default.Save();
                formLineDiag.Location = new Point(EtHerG.Properties.Settings.Default.LineDiagPosX, EtHerG.Properties.Settings.Default.LineDiagPosY);
            }
        }

        private void txtLineDiagPosY_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLineDiagPosY.Text) && Int32.TryParse(txtLineDiagPosY.Text, out int LineDiagPosY))
            {
                EtHerG.Properties.Settings.Default.LineDiagPosY = LineDiagPosY;
                EtHerG.Properties.Settings.Default.Save();
                formLineDiag.Location = new Point(EtHerG.Properties.Settings.Default.LineDiagPosX, EtHerG.Properties.Settings.Default.LineDiagPosY);
            }
        }

        private void txtLineDiagSizeX_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLineDiagSizeX.Text) && Int32.TryParse(txtLineDiagSizeX.Text, out int LineDiagSizeX))
            {
                EtHerG.Properties.Settings.Default.LineDiagSizeX = LineDiagSizeX;
                EtHerG.Properties.Settings.Default.Save();
                formLineDiag.Size = new Size(EtHerG.Properties.Settings.Default.LineDiagSizeX, EtHerG.Properties.Settings.Default.LineDiagSizeY);
            }
        }

        private void txtLineDiagSizeY_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLineDiagSizeY.Text) && Int32.TryParse(txtLineDiagSizeY.Text, out int LineDiagSizeY))
            {
                EtHerG.Properties.Settings.Default.LineDiagSizeY = LineDiagSizeY;
                EtHerG.Properties.Settings.Default.Save();
                formLineDiag.Size = new Size(EtHerG.Properties.Settings.Default.LineDiagSizeX, EtHerG.Properties.Settings.Default.LineDiagSizeY);
            }
        }

        private void txtMaxPoints_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMaxPoints.Text) && Int32.TryParse(txtMaxPoints.Text, out int MaxPoints))
            {
                EtHerG.Properties.Settings.Default.MaxPoints = MaxPoints;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void chkDisableUserInput_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDisableUserInput.Checked == true) { EtHerG.Properties.Settings.Default.DisableUserInput = true; DisableUserInput(); }
            if (chkDisableUserInput.Checked == false)
            {
                EtHerG.Properties.Settings.Default.DisableUserInput = false;
                txtFrequencyUserInput.Visible = true;
                txtGainXUserInput.Visible = true;
                txtGainYUserInput.Visible = true;
                txtPhaseUserInput.Visible = true;
                txtFilterLPUserInput.Visible = true;
                txtFilterHPUserInput.Visible = true;
            }
            EtHerG.Properties.Settings.Default.Save();
        }

        private void DisableUserInput()
        {
            txtFrequencyUserInput.Visible = false;
            txtGainXUserInput.Visible = false;
            txtGainYUserInput.Visible = false;
            txtPhaseUserInput.Visible = false;
            txtFilterLPUserInput.Visible = false;
            txtFilterHPUserInput.Visible = false;
        }

        private void txtAlarm1ModbusAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAlarm1ModbusAddress.Text) && ushort.TryParse(txtAlarm1ModbusAddress.Text, out ushort Alarm1ModbusAddress))
            {
                EtHerG.Properties.Settings.Default.Alarm1ModbusAddress = Alarm1ModbusAddress;
                EtHerG.Properties.Settings.Default.Save();
            }

        }

        private void txtAlarm2ModbusAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAlarm2ModbusAddress.Text) && ushort.TryParse(txtAlarm2ModbusAddress.Text, out ushort Alarm2ModbusAddress))
            {
                EtHerG.Properties.Settings.Default.Alarm2ModbusAddress = Alarm2ModbusAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtFrequencyModbusLastSentAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFrequencyModbusLastSentAddress.Text) && ushort.TryParse(txtFrequencyModbusLastSentAddress.Text, out ushort FrequencyModbusLastSendAddress))
            {
                EtHerG.Properties.Settings.Default.FrequencyModbusLastSendAddress = FrequencyModbusLastSendAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtGainXModbusLastSentAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGainXModbusLastSentAddress.Text) && ushort.TryParse(txtGainXModbusLastSentAddress.Text, out ushort GainXModbusLastSendAddress))
            {
                EtHerG.Properties.Settings.Default.GainXModbusLastSendAddress = GainXModbusLastSendAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtGainYModbusLastSentAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGainYModbusLastSentAddress.Text) && ushort.TryParse(txtGainYModbusLastSentAddress.Text, out ushort GainYModbusLastSendAddress))
            {
                EtHerG.Properties.Settings.Default.GainYModbusLastSendAddress = GainYModbusLastSendAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtPhaseModbusLastSentAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPhaseModbusLastSentAddress.Text) && ushort.TryParse(txtPhaseModbusLastSentAddress.Text, out ushort PhaseModbusLastSendAddress))
            {
                EtHerG.Properties.Settings.Default.PhaseModbusLastSendAddress = PhaseModbusLastSendAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtFilterLPModbusLastSentAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFilterLPModbusLastSentAddress.Text) && ushort.TryParse(txtFilterLPModbusLastSentAddress.Text, out ushort FilterLPModbusLastSendAddress))
            {
                EtHerG.Properties.Settings.Default.FilterLPModbusLastSendAddress = FilterLPModbusLastSendAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtFilterHPModbusLastSentAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFilterHPModbusLastSentAddress.Text) && ushort.TryParse(txtFilterHPModbusLastSentAddress.Text, out ushort FilterHPModbusLastSendAddress))
            {
                EtHerG.Properties.Settings.Default.FilterHPModbusLastSendAddress = FilterHPModbusLastSendAddress;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void chkModbusLastSentEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModbusLastSentAddressEnabled.Checked)
            {
                var zeroOrNullProperties = new List<string>();

                var propertiesToCheck = new Dictionary<string, string>()
        {
            {"FrequencyModbusLastSendAddress", txtFrequencyModbusLastSentAddress.Text},
            {"GainXModbusLastSendAddress", txtGainXModbusLastSentAddress.Text},
            {"GainYModbusLastSendAddress", txtGainYModbusLastSentAddress.Text},
            {"PhaseModbusLastSendAddress", txtPhaseModbusLastSentAddress.Text},
            {"FilterHPModbusLastSendAddress", txtFilterHPModbusLastSentAddress.Text},
            {"FilterLPModbusLastSendAddress", txtFilterLPModbusLastSentAddress.Text}
        };

                foreach (var entry in propertiesToCheck)
                {
                    if (string.IsNullOrWhiteSpace(entry.Value) || ushort.Parse(entry.Value) == 0)
                        zeroOrNullProperties.Add(entry.Key);
                }

                if (zeroOrNullProperties.Any())
                {
                    string message = InternationalizationMissingProperties;
                    message += string.Join("\n", zeroOrNullProperties) + "\n";
                    MessageBox.Show(message);
                }
                else
                {
                    EtHerG.Properties.Settings.Default.ModbusLastSentAddressEnabled = true;
                    EtHerG.Properties.Settings.Default.Save();
                }
            }
            else
            {
                EtHerG.Properties.Settings.Default.ModbusLastSentAddressEnabled = false;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Frequency":
                    ether.WriteToInstrument(1, 0, "<FREQUENCY>" + EtHerG.Properties.Settings.Default.Frequency * 1000 + "</FREQUENCY>");
                    Invoke(new Action(() =>
                    {
                        txtFrequencyLast.Text = EtHerG.Properties.Settings.Default.Frequency.ToString();
                        if (ModbusCon)
                        {
                            txtFrequencyLastModbusValue.Text = FrequencyModbusVal.ToString();
                            if (EtHerG.Properties.Settings.Default.ModbusLastSentAddressEnabled)
                            {
                                modbusMaster.WriteSingleRegister(1, EtHerG.Properties.Settings.Default.FrequencyModbusLastSendAddress, Convert.ToUInt16(EtHerG.Properties.Settings.Default.Frequency));
                            }
                        }
                    }));
                    break;

                case "GainX":
                    if (EtHerG.Properties.Settings.Default.EqualGain)
                    {
                        float EqualGain = EtHerG.Properties.Settings.Default.GainX;
                        EtHerG.Properties.Settings.Default.GainY = EtHerG.Properties.Settings.Default.GainX;
                        EtHerG.Properties.Settings.Default.Save();
                        ether.WriteToInstrument(1, 0, "<GAIN_X>" + EqualGain * 10 + "</GAIN_X>");
                        ether.WriteToInstrument(1, 0, "<GAIN_Y>" + EqualGain * 10 + "</GAIN_Y>");
                        Invoke(new Action(() =>
                        {
                            txtGainXLast.Text = EqualGain.ToString();
                            txtGainYLast.Text = EqualGain.ToString();
                            if (ModbusCon)
                            {
                                txtGainXLastModbusValue.Text = EqualGain.ToString();
                                txtGainYLastModbusValue.Text = EqualGain.ToString();
                                if (EtHerG.Properties.Settings.Default.ModbusLastSentAddressEnabled)
                                {
                                    modbusMaster.WriteSingleRegister(1, EtHerG.Properties.Settings.Default.GainXModbusLastSendAddress, Convert.ToUInt16(EqualGain));
                                    modbusMaster.WriteSingleRegister(1, EtHerG.Properties.Settings.Default.GainYModbusLastSendAddress, Convert.ToUInt16(EqualGain));
                                }
                            }
                        }));
                    }
                    else
                    {
                        ether.WriteToInstrument(1, 0, "<GAIN_X>" + EtHerG.Properties.Settings.Default.GainX * 10 + "</GAIN_X>");
                        Invoke(new Action(() =>
                        {
                            txtGainXLast.Text = EtHerG.Properties.Settings.Default.GainX.ToString();
                            if (ModbusCon)
                            {
                                txtGainXLastModbusValue.Text = GainXModbusVal.ToString();
                                if (EtHerG.Properties.Settings.Default.ModbusLastSentAddressEnabled)
                                {
                                    modbusMaster.WriteSingleRegister(1, EtHerG.Properties.Settings.Default.GainXModbusLastSendAddress, Convert.ToUInt16(EtHerG.Properties.Settings.Default.GainX));
                                }
                            }
                        }));
                    }
                    break;

                case "GainY":
                    if (EtHerG.Properties.Settings.Default.EqualGain)
                    {
                        float EqualGain = EtHerG.Properties.Settings.Default.GainY;
                        ether.WriteToInstrument(1, 0, "<GAIN_X>" + EqualGain * 10 + "</GAIN_X>");
                        ether.WriteToInstrument(1, 0, "<GAIN_Y>" + EqualGain * 10 + "</GAIN_Y>");
                        Invoke(new Action(() =>
                        {
                            txtGainXLast.Text = EqualGain.ToString();
                            txtGainYLast.Text = EqualGain.ToString();
                            txtGainXUserInput.Text = EqualGain.ToString();
                            if (ModbusCon)
                            {
                                txtGainXLastModbusValue.Text = EqualGain.ToString();
                                txtGainYLastModbusValue.Text = EqualGain.ToString();
                                if (EtHerG.Properties.Settings.Default.ModbusLastSentAddressEnabled)
                                {
                                    modbusMaster.WriteSingleRegister(1, EtHerG.Properties.Settings.Default.GainXModbusLastSendAddress, Convert.ToUInt16(EqualGain));
                                    modbusMaster.WriteSingleRegister(1, EtHerG.Properties.Settings.Default.GainYModbusLastSendAddress, Convert.ToUInt16(EqualGain));
                                }
                            }
                        }));
                    }
                    else
                    {
                        ether.WriteToInstrument(1, 0, "<GAIN_Y>" + EtHerG.Properties.Settings.Default.GainY * 10 + "</GAIN_Y>");
                        Invoke(new Action(() =>
                        {
                            txtGainYLast.Text = EtHerG.Properties.Settings.Default.GainY.ToString();
                            if (ModbusCon)
                            {
                                txtGainYLastModbusValue.Text = GainYModbusVal.ToString();
                                if (EtHerG.Properties.Settings.Default.ModbusLastSentAddressEnabled)
                                {
                                    modbusMaster.WriteSingleRegister(1, EtHerG.Properties.Settings.Default.GainYModbusLastSendAddress, Convert.ToUInt16(EtHerG.Properties.Settings.Default.GainY));
                                }
                            }
                        }));
                    }
                    break;

                case "Phase":
                    ether.WriteToInstrument(1, 0, "<PHASE>" + EtHerG.Properties.Settings.Default.Phase * 1000 + "</PHASE>");
                    Invoke(new Action(() =>
                    {
                        txtPhaseLast.Text = EtHerG.Properties.Settings.Default.Phase.ToString();
                        if (ModbusCon)
                        {
                            txtPhaseLastModbusValue.Text = PhaseModbusVal.ToString();
                            if (EtHerG.Properties.Settings.Default.ModbusLastSentAddressEnabled)
                            {
                                modbusMaster.WriteSingleRegister(1, EtHerG.Properties.Settings.Default.PhaseModbusLastSendAddress, Convert.ToUInt16(EtHerG.Properties.Settings.Default.Phase));
                            }
                        }
                    }));

                    break;

                case "FilterLP":
                    ether.WriteToInstrument(1, 0, "<FILTER_LP>" + EtHerG.Properties.Settings.Default.FilterLP * 100 + "</FILTER_LP>");
                    Invoke(new Action(() =>
                    {
                        txtFilterLPLast.Text = EtHerG.Properties.Settings.Default.FilterLP.ToString();
                        if (ModbusCon)
                        {
                            txtFilterLPLastModbusValue.Text = FilterLPModbusVal.ToString();
                            if (EtHerG.Properties.Settings.Default.ModbusLastSentAddressEnabled)
                            {
                                modbusMaster.WriteSingleRegister(1, EtHerG.Properties.Settings.Default.FilterLPModbusLastSendAddress, Convert.ToUInt16(EtHerG.Properties.Settings.Default.FilterLP));
                            }
                        }

                    }));

                    MessageBox.Show("<FILTER_LP>" + EtHerG.Properties.Settings.Default.FilterLP * 100 + "</FILTER_LP>");
                    break;

                case "FilterHP":
                    ether.WriteToInstrument(1, 0, "<FILTER_HP>" + EtHerG.Properties.Settings.Default.FilterHP * 100 + "</FILTER_HP>");
                    Invoke(new Action(() =>
                    {
                        txtFilterHPLast.Text = EtHerG.Properties.Settings.Default.FilterHP.ToString();
                        if (ModbusCon)
                        {
                            txtFilterHPLastModbusValue.Text = FilterHPModbusVal.ToString();
                            if (EtHerG.Properties.Settings.Default.ModbusLastSentAddressEnabled)
                            {
                                modbusMaster.WriteSingleRegister(1, EtHerG.Properties.Settings.Default.FilterHPModbusLastSendAddress, Convert.ToUInt16(EtHerG.Properties.Settings.Default.FilterHP));
                            }
                        }
                    }));
                    break;
            }

            if (EtHerG.Properties.Settings.Default.InfluxDBEnabled)
            {
                // Create a point with the desired fields and tags
                var point = PointData.Measurement("parameters")
                    .Tag("device", EtHerG.Properties.Settings.Default.InfluxDBMachine)
                    .Field("GainX", EtHerG.Properties.Settings.Default.GainX)
                    .Field("GainY", EtHerG.Properties.Settings.Default.GainY)
                    .Field("Frequency", EtHerG.Properties.Settings.Default.Frequency)
                    .Field("Phase", EtHerG.Properties.Settings.Default.Phase)
                    .Field("FilterLP", EtHerG.Properties.Settings.Default.FilterLP)
                    .Field("FilterHP", EtHerG.Properties.Settings.Default.FilterHP)
                    .Field("Alarm1Value", EtHerG.Properties.Settings.Default.Alarm1Value)
                    .Field("Alarm2Value", EtHerG.Properties.Settings.Default.Alarm2Value)
                    .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

                if (influxDBClient == null)
                {
                    influxDBClient = new InfluxDBClient(EtHerG.Properties.Settings.Default.InfluxDBServer, EtHerG.Properties.Settings.Default.InfluxDBToken);
                }

                influxDBClient.GetWriteApi().WritePoint(point, EtHerG.Properties.Settings.Default.InfluxDBBucket, EtHerG.Properties.Settings.Default.InfluxDBOrgID);
            }

            AlarmStartupBlock.Start();
            AlarmReady = false;
        }

        private void chkInfluxDBEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInfluxDBEnabled.Checked)
            {
                PropertiesSetToZeroOrNull.Clear();
                // Check if InfluxDBServer is null or empty
                if (string.IsNullOrEmpty(EtHerG.Properties.Settings.Default.InfluxDBServer))
                {
                    PropertiesSetToZeroOrNull.Add("InfluxDBServer");
                }

                // Check if InfluxDBToken is null or empty
                if (string.IsNullOrEmpty(EtHerG.Properties.Settings.Default.InfluxDBToken))
                {
                    PropertiesSetToZeroOrNull.Add("InfluxDBToken");
                }

                // Check if InfluxDBBucket is null or empty
                if (string.IsNullOrEmpty(EtHerG.Properties.Settings.Default.InfluxDBBucket))
                {
                    PropertiesSetToZeroOrNull.Add("InfluxDBBucket");
                }

                // Check if InfluxDBMachine is null or empty
                if (string.IsNullOrEmpty(EtHerG.Properties.Settings.Default.InfluxDBMachine))
                {
                    PropertiesSetToZeroOrNull.Add("InfluxDBMachine");
                }

                // Check if InfluxDBOrgID is null or empty
                if (string.IsNullOrEmpty(EtHerG.Properties.Settings.Default.InfluxDBOrgID))
                {
                    PropertiesSetToZeroOrNull.Add("InfluxDBOrgID");
                }

                // If any InfluxDB property is null or empty, display a single MessageBox with the list of properties
                if (PropertiesSetToZeroOrNull.Any())
                {
                    chkInfluxDBEnabled.Checked = false;

                    string message = InternationalizationMissingProperties;

                    // Add each InfluxDB property to the message with a new line
                    foreach (string property in PropertiesSetToZeroOrNull)
                    {
                        message += $"{property}\n";
                    }

                    MessageBox.Show(message);

                }
                else
                {
                    EtHerG.Properties.Settings.Default.InfluxDBEnabled = chkInfluxDBEnabled.Checked;
                    EtHerG.Properties.Settings.Default.Save();

                    influxDBClient = new InfluxDBClient(EtHerG.Properties.Settings.Default.InfluxDBServer, EtHerG.Properties.Settings.Default.InfluxDBToken);
                }
            }
            else
            {
                EtHerG.Properties.Settings.Default.InfluxDBEnabled = chkInfluxDBEnabled.Checked;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtInfluxDBServer_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.InfluxDBServer = txtInfluxDBServer.Text;
            EtHerG.Properties.Settings.Default.Save();

        }

        private void txtInfluxDBToken_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.InfluxDBToken = txtInfluxDBToken.Text;
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtInfluxDBBucket_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.InfluxDBBucket = txtInfluxDBBucket.Text;
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtInfluxDBOrg_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.InfluxDBOrgID = txtInfluxDBOrg.Text;
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtInfluxDBMachine_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.InfluxDBMachine = txtInfluxDBMachine.Text;
            EtHerG.Properties.Settings.Default.Save();
        }

        private void btnSetPassword_Click(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.Password = txtSetPassword.Text;
            EtHerG.Properties.Settings.Default.Save();
        }

        private bool IsValidHexColor(string input)
        {
            // Define the regular expression pattern for a hexadecimal color code
            string hexColorPattern = @"^#(?:[0-9a-fA-F]{3}){1,2}$";

            // Check if the input string matches the pattern
            return Regex.IsMatch(input, hexColorPattern);
        }

        private void ValidateAndSaveColor(TextBox textBox, string settingName)
        {
            if (IsValidHexColor(textBox.Text))
            {
                // Save the valid color to settings
                EtHerG.Properties.Settings.Default[settingName] = textBox.Text;
                EtHerG.Properties.Settings.Default.Save();
                FormatLineDiag();
            }
            else
            {
                // Show error message and revert to previous color
                MessageBox.Show(InternationalizationFalseColor);
                textBox.Text = EtHerG.Properties.Settings.Default[settingName].ToString();
            }
        }

        private void txtAlarm1Color_LostFocus(object sender, EventArgs e)
        {
            ValidateAndSaveColor(txtAlarm1Color, "Alarm1Color");
        }

        private void txtAlarm2Color_LostFocus(object sender, EventArgs e)
        {
            ValidateAndSaveColor(txtAlarm2Color, "Alarm2Color");
        }

        private void txtLineDiagColorX_LostFocus(object sender, EventArgs e)
        {
            ValidateAndSaveColor(txtLineDiagColorX, "LineDiagColorX");
        }

        private void txtLineDiagYColor_LostFocus(object sender, EventArgs e)
        {
            ValidateAndSaveColor(txtLineDiagColorY, "LineDiagColorY");
        }

        private void txtScatterDiagColor_LostFocus(object sender, EventArgs e)
        {
            ValidateAndSaveColor(txtScatterDiagColor, "ScatterDiagColor");
        }

        private void chkScatterDrawPoints_CheckedChanged(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.ScatterDiagDrawPoints = chkScatterDrawPoints.Checked;
            EtHerG.Properties.Settings.Default.Save();
        }

        private void pctrInternationalization_Click(object sender, EventArgs e)
        {
            if (EtHerG.Properties.Settings.Default.Language == 3)
            {
                EtHerG.Properties.Settings.Default.Language = 1;
            }
            else
            {
                EtHerG.Properties.Settings.Default.Language = EtHerG.Properties.Settings.Default.Language + 1;
            }

            EtHerG.Properties.Settings.Default.Save();
            Internationalization();
        }

        private void Internationalization()
        {
            switch (EtHerG.Properties.Settings.Default.Language)
            {
                case 1:
                    //UK
                    pctrInternationalization.Image = EtHerG.Properties.Resources.UK1;
                    btnEtherConnect.Text = "Ether Connect";
                    btnEtherDisconnect.Text = "Ether Disconnect";
                    btnModbusConnect.Text = "Modbus Connect";
                    btnModbusDisconnect.Text = "Modbus Disconnect";
                    chkShowX.Text = "X-Values";
                    chkShowY.Text = "Y-Values";
                    chkEtherAutoconnect.Text = "Ether Autoconnect";
                    chkModbusAutoconnect.Text = "Modbus Autoconnect";
                    lblFrequency.Text = "Frequency:";
                    lblGainX.Text = "Gain X:";
                    lblGainY.Text = "Gain Y:";
                    lblPhase.Text = "Phase:";
                    lblFilterLP.Text = "Filter LP. :";
                    lblFilterHP.Text = "Filter HP. :";
                    tabPage1.Text = "Main";
                    tabPage2.Text = "Settings";
                    lblXVal.Text = "X-Values:";
                    lblYVal.Text = "Y-Values:";
                    lblLineDiagAmount.Text = "Amount of Points in Line Diag.:";
                    lblDiagMaxPointSize.Text = "Max. Pointheight:";
                    lblScatterAmount.Text = "Amount of Points in Scatter:";
                    lblAlarm1.Text = "Alarm 1:";
                    lblAlarm2.Text = "Alarm 2:";
                    lblScatterDiagPosX.Text = "Scatter Pos. X:";
                    lblScatterDiagPosY.Text = "Scatter Pos. Y:";
                    lblScatterDiagSize.Text = "Scatter Size:";
                    lblLineDiagPosX.Text = "Line Diagram Pos. X:";
                    lblLineDiagPosY.Text = "Line Diagram Pos. Y:";
                    lblLineDiagSizeX.Text = "Line Diagram Größe X:";
                    lblLineDiagSizeY.Text = "Line Diagram Größe Y:";
                    lblAlarm1Color.Text = "Alarm 1 Color:";
                    lblAlarm2Color.Text = "Alarm 2 Color:";
                    lblColorX.Text = "Color X:";
                    lblColorY.Text = "Color Y:";
                    lblScatterColor.Text = "Color Scatter:";
                    chkScatterDrawPoints.Text = "Scatter Diagram Draw Points?";
                    InternationalizationWrongPassword = "Wrong Password!";
                    InternationalizationConnectionFailed = "Connection Failed!";
                    InternationalizationMissingProperties = "The following properties are still set to 0 or null:\n";
                    InternationalizationModbusConnectionFailed = "Modbus Connection Failed";
                    InternationalizationFalseColor = "Please use a valid Hex Color Code";
                    chkEqualGain.Text = "Gain X = Gain Y";
                    txtEtherStatus.Location = new Point(944, 11);
                    txtModbusStatus.Location = new Point(944, 33);
                    break;
                case 2:
                    //DE
                    pctrInternationalization.Image = EtHerG.Properties.Resources.DE1;
                    btnEtherConnect.Text = "Ether Verbinden";
                    btnEtherDisconnect.Text = "Ether Trennen";
                    btnModbusConnect.Text = "Modbus Verbinden";
                    btnModbusDisconnect.Text = "Modbus Trennen";
                    chkShowX.Text = "X-Werte";
                    chkShowY.Text = "Y-Werte";
                    chkEtherAutoconnect.Text = "Ether Autom. Verbinden";
                    chkModbusAutoconnect.Text = "Modbus Autom. Verbinden";
                    lblFrequency.Text = "Frequenz:";
                    lblGainX.Text = "Empf. X:";
                    lblGainY.Text = "Empf. Y:";
                    lblPhase.Text = "Phase:";
                    lblFilterLP.Text = "Filter TP. :";
                    lblFilterHP.Text = "Filter HP. :";
                    tabPage1.Text = "Haupt";
                    tabPage2.Text = "Einstellungen";
                    lblXVal.Text = "X-Werte:";
                    lblYVal.Text = "Y-Werte:";
                    lblLineDiagAmount.Text = "Punktanzahl in Liniendiagram:";
                    lblDiagMaxPointSize.Text = "Max. Punkthöhe:";
                    lblScatterAmount.Text = "Punktanzahl in Punktwolke:";
                    lblAlarm1.Text = "Alarm 1:";
                    lblAlarm2.Text = "Alarm 2:";
                    lblScatterDiagPosX.Text = "Punktwolke Pos. X:";
                    lblScatterDiagPosY.Text = "Punktwolke Pos. Y:";
                    lblScatterDiagSize.Text = "Punktwolke Größe:";
                    lblLineDiagPosX.Text = "Liniendiagram Pos. X:";
                    lblLineDiagPosY.Text = "Liniendiagram Pos. Y:";
                    lblLineDiagSizeX.Text = "Liniendiagram Größe X:";
                    lblLineDiagSizeY.Text = "Liniendiagram Größe Y:";
                    lblAlarm1Color.Text = "Alarm 1 Farbe:";
                    lblAlarm2Color.Text = "Alarm 2 Farbe:";
                    lblColorX.Text = "Farbe X:";
                    lblColorY.Text = "Farbe Y:";
                    lblScatterColor.Text = "Farbe Punktwolke:";
                    chkScatterDrawPoints.Text = "Punktwolke Punkte Malen?";
                    InternationalizationWrongPassword = "Falsches Passwort!";
                    InternationalizationConnectionFailed = "Verbindung fehlgeschlagen!";
                    InternationalizationMissingProperties = "Die folgenden Eigenschaften sind immer noch auf 0 oder null gesetzt:\n";
                    InternationalizationModbusConnectionFailed = "Modbus Verbindung fehlgeschlagen!";
                    InternationalizationFalseColor = "Bitte verwenden Sie einen gültigen Hex-Farb-Code!";
                    chkEqualGain.Text = "Empf. X = Empf. Y";
                    txtEtherStatus.Location = new Point(960, 11);
                    txtModbusStatus.Location = new Point(960, 33);
                    break;
                case 3:
                    //PL
                    pctrInternationalization.Image = EtHerG.Properties.Resources.PL;
                    btnEtherConnect.Text = "Połącz z Ethernetem";
                    btnEtherDisconnect.Text = "Rozłącz Ethernetem";
                    btnModbusConnect.Text = "Połącz z Modbus";
                    btnModbusDisconnect.Text = "Rozłącz Modbus";
                    chkShowX.Text = "Wartości X";
                    chkShowY.Text = "Wartości Y";
                    chkEtherAutoconnect.Text = "Automatyczne połączenie z Ethernetem";
                    chkModbusAutoconnect.Text = "Automatyczne połączenie z Modbus";
                    lblFrequency.Text = "Częstotliwość:";
                    lblGainX.Text = "Wzmocnienie X:";
                    lblGainY.Text = "Wzmocnienie Y:";
                    lblPhase.Text = "Faza:";
                    lblFilterLP.Text = "Filtr DP. :";
                    lblFilterHP.Text = "Filtr GP. :";
                    tabPage1.Text = "Główna";
                    tabPage2.Text = "Ustawienia";
                    lblXVal.Text = "Wartości X:";
                    lblYVal.Text = "Wartości Y:";
                    lblLineDiagAmount.Text = "Skalowanie wykresu liniowego:";
                    lblDiagMaxPointSize.Text = "Skalowanie wykresu punktowego";
                    lblScatterAmount.Text = "Liczba pomiarów w wykresie punktowym:";
                    lblAlarm1.Text = "Alarm 1:";
                    lblAlarm2.Text = "Alarm 2:";
                    lblScatterDiagPosX.Text = "Płożenie wykresu punktowego - pozycja X:";
                    lblScatterDiagPosY.Text = "Płożenie wykresu punktowego - pozycja Y:";
                    lblScatterDiagSize.Text = "Rozmiar wykresu punktowego:";
                    lblLineDiagPosX.Text = "Płożenie wykresu liniowego  - pozycja X:";
                    lblLineDiagPosY.Text = "Płożenie wykresu liniowego  - pozycja Y:";
                    lblLineDiagSizeX.Text = "Rozmiar X wykresu liniowego:";
                    lblLineDiagSizeY.Text = "Rozmiar Y wykresu liniowego:";
                    lblAlarm1Color.Text = "Kolor Alarmu 1:";
                    lblAlarm2Color.Text = "Kolor Alarmu 2:";
                    lblColorX.Text = "Kolor X:";
                    lblColorY.Text = "Kolor Y:";
                    lblScatterColor.Text = "Kolor wykresu punktowego";
                    chkScatterDrawPoints.Text = "Czy rysować wykres punktowy?";
                    InternationalizationWrongPassword = "Błędne hasło!";
                    InternationalizationConnectionFailed = "Połączenie nie powiodło się";
                    InternationalizationMissingProperties = "Następujące właściwości są nadal ustawione na 0 lub null:\n";
                    InternationalizationFalseColor = "Proszę użyć prawidłowego kodu koloru w formacie szesnastkowym.";
                    chkEqualGain.Text = "Wzmocnienie X = Wzmocnienie Y";
                    txtEtherStatus.Location = new Point(1030, 11);
                    txtModbusStatus.Location = new Point(1030, 33);
                    break;
            }

        }

        private void txtFrequencyUserInput_MouseWheel(object sender, MouseEventArgs e)
        {
            // Check if the TextBox has focus
            if (txtFrequencyUserInput.Focused)
            {
                // If the mouse wheel is scrolled up, increment the value
                if (e.Delta > 0)
                {
                    EtHerG.Properties.Settings.Default.Frequency++;
                }
                // If the mouse wheel is scrolled down, decrement the value
                else if (e.Delta < 0)
                {
                    EtHerG.Properties.Settings.Default.Frequency--;
                }

                // Update the TextBox text with the new value
                txtFrequencyUserInput.Text = EtHerG.Properties.Settings.Default.Frequency.ToString();

                // Debounce the Save() method call
                DateTime now = DateTime.Now;
                if (now - MouseWheelDebounce >= TimeSpan.FromMilliseconds(1000))
                {
                    EtHerG.Properties.Settings.Default.Save();
                    MouseWheelDebounce = now;
                }
            }
        }

        private void txtGainXUserInput_MouseWheel(object sender, MouseEventArgs e)
        {
            // Check if the TextBox has focus
            if (txtGainXUserInput.Focused)
            {
                // If the mouse wheel is scrolled up, increment the value
                if (e.Delta > 0)
                {
                    EtHerG.Properties.Settings.Default.GainX++;
                }
                // If the mouse wheel is scrolled down, decrement the value
                else if (e.Delta < 0)
                {
                    EtHerG.Properties.Settings.Default.GainX--;
                }
                txtGainXUserInput.Text = EtHerG.Properties.Settings.Default.GainX.ToString();

                // Debounce the Save() method call
                DateTime now = DateTime.Now;
                if (now - MouseWheelDebounce >= TimeSpan.FromMilliseconds(1000))
                {
                    EtHerG.Properties.Settings.Default.Save();
                    MouseWheelDebounce = now;
                }
            }
        }

        private void txtGainYUserInput_MouseWheel(object sender, MouseEventArgs e)
        {
            // Check if the TextBox has focus
            if (txtGainYUserInput.Focused)
            {
                // If the mouse wheel is scrolled up, increment the value
                if (e.Delta > 0)
                {
                    EtHerG.Properties.Settings.Default.GainY++;
                }
                // If the mouse wheel is scrolled down, decrement the value
                else if (e.Delta < 0)
                {
                    EtHerG.Properties.Settings.Default.GainY--;
                }
                // Update the TextBox text with the new value
                txtGainYUserInput.Text = EtHerG.Properties.Settings.Default.GainY.ToString();

                // Debounce the Save() method call
                DateTime now = DateTime.Now;
                if (now - MouseWheelDebounce >= TimeSpan.FromMilliseconds(1000))
                {
                    EtHerG.Properties.Settings.Default.Save();
                    MouseWheelDebounce = now;
                }
            }
        }

        private void txtPhaseUserInput_MouseWheel(object sender, MouseEventArgs e)
        {
            // Check if the TextBox has focus
            if (txtPhaseUserInput.Focused)
            {
                // If the mouse wheel is scrolled up, increment the value
                if (e.Delta > 0)
                {
                    EtHerG.Properties.Settings.Default.Phase++;
                }
                // If the mouse wheel is scrolled down, decrement the value
                else if (e.Delta < 0)
                {
                    EtHerG.Properties.Settings.Default.Phase--;
                }

                txtPhaseUserInput.Text = EtHerG.Properties.Settings.Default.Phase.ToString();

                // Debounce the Save() method call
                DateTime now = DateTime.Now;
                if (now - MouseWheelDebounce >= TimeSpan.FromMilliseconds(1000))
                {
                    EtHerG.Properties.Settings.Default.Save();
                    MouseWheelDebounce = now;
                }
            }
        }

        private void txtFilterLPUserInput_MouseWheel(object sender, MouseEventArgs e)
        {
            // Check if the TextBox has focus
            if (txtFilterLPUserInput.Focused)
            {
                // If the mouse wheel is scrolled up, increment the value
                if (e.Delta > 0)
                {
                    EtHerG.Properties.Settings.Default.FilterLP++;
                }
                // If the mouse wheel is scrolled down, decrement the value
                else if (e.Delta < 0)
                {
                    EtHerG.Properties.Settings.Default.FilterLP--;
                }

                txtFilterLPUserInput.Text = EtHerG.Properties.Settings.Default.FilterLP.ToString();
                // Debounce the Save() method call
                DateTime now = DateTime.Now;
                if (now - MouseWheelDebounce >= TimeSpan.FromMilliseconds(1000))
                {
                    EtHerG.Properties.Settings.Default.Save();
                    MouseWheelDebounce = now;
                }
            }
        }

        private void txtFilterHPUserInput_MouseWheel(object sender, MouseEventArgs e)
        {
            // Check if the TextBox has focus
            if (txtFilterHPUserInput.Focused)
            {
                // If the mouse wheel is scrolled up, increment the value
                if (e.Delta > 0)
                {
                    EtHerG.Properties.Settings.Default.FilterHP++;
                }
                // If the mouse wheel is scrolled down, decrement the value
                else if (e.Delta < 0)
                {
                    EtHerG.Properties.Settings.Default.FilterHP--;
                }
                // Update the TextBox text with the new value
                txtFilterHPUserInput.Text = EtHerG.Properties.Settings.Default.FilterHP.ToString();

                // Debounce the Save() method call
                DateTime now = DateTime.Now;
                if (now - MouseWheelDebounce >= TimeSpan.FromMilliseconds(1000))
                {
                    EtHerG.Properties.Settings.Default.Save();
                    MouseWheelDebounce = now;
                }
            }
        }

        private void chkEqualGain_CheckedChanged(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.EqualGain = chkEqualGain.Checked;
            EtHerG.Properties.Settings.Default.Save();
            txtGainYUserInput.Visible = !EtHerG.Properties.Settings.Default.EqualGain;
        }

        private void txtAmountAveragePoints_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAmountAveragePoints.Text) && long.TryParse(txtAmountAveragePoints.Text, out long Value))
            {
                EtHerG.Properties.Settings.Default.AmountAveragePoints = Value;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void chkAutoscale_CheckedChanged(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.Autoscale = chkAutoscale.Checked;
            EtHerG.Properties.Settings.Default.Save();
            FormatLineDiag();
        }

        private void chkAutologin_CheckedChanged(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.Autologin = chkAutologin.Checked;
            EtHerG.Properties.Settings.Default.Save();
        }
    }
}

