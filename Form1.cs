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

namespace EtHerG
{
    public partial class Form1 : Form
    {
        public ETherRealtimeClass ether = new ETherRealtimeClass(0, 0x70);


        public ScottPlot.Plottables.DataStreamer StreamX;
        public ScottPlot.Plottables.DataStreamer StreamY;
        public HorizontalLine Alarm1;
        public HorizontalLine Alarm2;
        public ScottPlot.Plottables.Rectangle Alarm5;

        private TcpClient modbusClient;
        private IModbusMaster modbusMaster;
        public bool ModbusCon = false;
        public int FrequencyModbusVal;
        public int FrequencyModbusLastVal = 0;
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
        public bool Alarm1SingleWrite = false;
        public bool Alarm2SingleWrite = false;

        public List<double> dataX = new List<double>();
        public List<double> dataY = new List<double>();
        public List<double> ScatterX = new List<double>();
        public List<double> ScatterY = new List<double>();
        public List<double> lastSpecifiedXValues = new List<double>();
        public List<double> lastSpecifiedYValues = new List<double>();
        public List<double> Alarm1dataX = new List<double>();
        public List<double> Alarm2dataY = new List<double>();

        public int counter = 0;
        public bool firstCon = false;
        public int Xval;
        public int Yval;
        private System.Timers.Timer resetTimer;
        private System.Timers.Timer ModbusTimer;
        private System.Timers.Timer Alarm1Timer;
        private System.Timers.Timer Alarm2Timer;
        private System.Timers.Timer initTimer;
        private System.Timers.Timer AlarmStartupBlock;

        public long SumX1;
        public long SumY1;
        public Int32 AverageX1;
        public Int32 AverageY1;
        public int ChangeCounter;
        public int ChangeDivider = 10000;
        public int DisplayX1 = 0;
        public int DisplayY1 = 0;
        public double[] last100X;
        public double[] last100Y;
        public bool play = true;
        public bool playX;
        public bool playY;

        public bool EtherConnected = false;
        public int LineDiagPosY = 0;
        public bool login = false;
        public InfluxDBClient influxDBClient;
        private readonly object dataLockX = new object();
        private readonly object dataLockY = new object();
        private readonly object dataLockScatter = new object();

        public bool AlarmReady = false;
        List<string> EtherPropertiesSetToZeroOrNull = new List<string>();
        List<string> ModbusPropertiesSetToZeroOrNull = new List<string>();
        List<string> modbusLastSendAddressesSetToZeroOrNull = new List<string>();
        List<string> influxDBPropertiesSetToNullOrEmpty = new List<string>();

        public Form1()
        {
            InitializeComponent();

            if (firstCon == false)
            {
                initvoid();
            }

            ether.RegisterDataCallback(NewRealtimeData);
            DiagWorker.DoWork += DiagWorker_DoWork;
            ModbusWorker.DoWork += ModbusWorker_DoWork;
            this.FormClosing += Form1_FormClosing;
        }

        private void initvoid()
        {
            DiagWorker = new BackgroundWorker();
            DiagWorker.WorkerSupportsCancellation = true;

            ModbusWorker = new BackgroundWorker();
            ModbusWorker.WorkerSupportsCancellation = true;

            EtHerG.Properties.Settings.Default.PropertyChanged += Settings_PropertyChanged;

            if (EtHerG.Properties.Settings.Default.InfluxDBEnabled == true)
            {
                influxDBClient = new InfluxDBClient(EtHerG.Properties.Settings.Default.InfluxDBServer, EtHerG.Properties.Settings.Default.InfluxDBToken);
            }

            StreamX = formLineDiag.Plot.Add.DataStreamer(EtHerG.Properties.Settings.Default.LineDiagPoints);
            StreamY = formLineDiag.Plot.Add.DataStreamer(EtHerG.Properties.Settings.Default.LineDiagPoints);

            // Initialize and start the timer for resetting dataX and counter every second
            resetTimer = new System.Timers.Timer(1000); // Timer interval in milliseconds (1 second)
            resetTimer.Elapsed += ResetTimer_Elapsed;
            resetTimer.AutoReset = true; // Set AutoReset to true for periodic triggering
            resetTimer.Start();

            initTimer = new System.Timers.Timer(1000); // Timer interval in milliseconds (1 second)
            initTimer.Elapsed += initTimer_Elapsed;
            initTimer.AutoReset = false;
            initTimer.Start();

            ModbusTimer = new System.Timers.Timer(25);
            ModbusTimer.Elapsed += ModbusTimer_Elapsed;
            ModbusTimer.AutoReset = true;
            ModbusTimer.Start();

            Alarm1Timer = new System.Timers.Timer(1000);
            Alarm1Timer.Elapsed += Alarm1Timer_Elapsed;

            Alarm2Timer = new System.Timers.Timer(1000);
            Alarm2Timer.Elapsed += Alarm2Timer_Elapsed;

            AlarmStartupBlock = new System.Timers.Timer(3000);
            AlarmStartupBlock.Elapsed += AlarmStartupBlock_Elapsed;
            AlarmStartupBlock.Start();

            firstCon = true;
        }

        protected override void OnLoad(EventArgs e)
        {
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


                formLineDiag.Location = new Point(EtHerG.Properties.Settings.Default.LineDiagPosX, EtHerG.Properties.Settings.Default.LineDiagPosY);
                formLineDiag.Size = new Size(EtHerG.Properties.Settings.Default.LineDiagSizeX, EtHerG.Properties.Settings.Default.LineDiagSizeY);
                formScatter.Location = new Point(EtHerG.Properties.Settings.Default.ScatterDiagPosX, EtHerG.Properties.Settings.Default.ScatterDiagPosY);
                formScatter.Size = new Size(EtHerG.Properties.Settings.Default.ScatterDiagSize, EtHerG.Properties.Settings.Default.ScatterDiagSize);

                FormatDiags();

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

                //if (EtHerG.Properties.Settings.Default.UKLanguage == true)
                //{
                //    UKLanguage();
                //    pctrLanguage.Image = EtHerG.Properties.Resources.germany_flag_icon;
                //}
                //else
                //{
                //    DELanguage();
                //    pctrLanguage.Image = EtHerG.Properties.Resources.united_kingdom_flag_icon;
                //}
            }));
        }

        private void ResetTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke(new Action(() =>
                {
                    txtPS.Text = counter.ToString();
                }));
            }
            counter = 0;
        }

        private void initTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            FormatDiags();
        }

        private void ModbusTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (!ModbusWorker.IsBusy)
            {
                ModbusWorker.RunWorkerAsync();
            }
        }

        private void Alarm1Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            Alarm1Timer.Stop();
            modbusMaster.WriteSingleCoil(1, EtHerG.Properties.Settings.Default.Alarm1ModbusAddress, false);
            Alarm1SingleWrite = false;
        }

        private void Alarm2Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            Alarm2Timer.Stop();
            modbusMaster.WriteSingleCoil(1, EtHerG.Properties.Settings.Default.Alarm2ModbusAddress, false);
            Alarm2SingleWrite = false;
        }

        private void AlarmStartupBlock_Elapsed(object? sender, ElapsedEventArgs e)
        {
            AlarmReady = true;
        }

        private void FormatDiags()
        {
            Invoke(new Action(() =>
            {
                formLineDiag.Reset();
                StreamX.Clear();
                StreamY.Clear();
                StreamX = formLineDiag.Plot.Add.DataStreamer(EtHerG.Properties.Settings.Default.LineDiagPoints);
                StreamY = formLineDiag.Plot.Add.DataStreamer(EtHerG.Properties.Settings.Default.LineDiagPoints);
                StreamX.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.LineDiagColorX);
                StreamY.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.LineDiagColorY);
                StreamY.ViewScrollLeft();
                StreamX.ViewScrollLeft();
                StreamX.ManageAxisLimits = false;
                StreamY.ManageAxisLimits = false;

                HorizontalLine Alarm1 = formLineDiag.Plot.Add.HorizontalLine(EtHerG.Properties.Settings.Default.Alarm1Value);
                HorizontalLine Alarm2 = formLineDiag.Plot.Add.HorizontalLine(-EtHerG.Properties.Settings.Default.Alarm1Value);
                Alarm1.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.Alarm1Color);
                Alarm2.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.Alarm1Color);

                HorizontalLine Alarm3 = formLineDiag.Plot.Add.HorizontalLine(EtHerG.Properties.Settings.Default.Alarm2Value);
                HorizontalLine Alarm4 = formLineDiag.Plot.Add.HorizontalLine(-EtHerG.Properties.Settings.Default.Alarm2Value);
                Alarm3.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.Alarm2Color);
                Alarm4.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.Alarm2Color);

                txtColorX.BackColor = System.Drawing.ColorTranslator.FromHtml(EtHerG.Properties.Settings.Default.LineDiagColorX);
                txtColorY.BackColor = System.Drawing.ColorTranslator.FromHtml(EtHerG.Properties.Settings.Default.LineDiagColorY);
                txtColorY.Enabled = false;
                txtColorX.Enabled = false;


                formLineDiag.Plot.Axes.SetLimits(0, EtHerG.Properties.Settings.Default.LineDiagPoints, -EtHerG.Properties.Settings.Default.DiagMaxPointSize, EtHerG.Properties.Settings.Default.DiagMaxPointSize);
                formLineDiag.Interaction.Disable();
                formLineDiag.Refresh();
            }));
        }

        public void NewRealtimeData(Int32 X1, Int32 Y1, Int32 X2, Int32 Y2, Int32 Xmix_or_percent, Int32 Ymix_or_percent, Int32 Theta_or_status_X, Int32 Radius_or_status_Y)
        {

            counter++;
            if (X1 < -50000 || X1 > 50000 || Y1 < -50000 || Y1 > 50000)
            {
                return;
            }

            ChangeCounter++;
            SumX1 += Convert.ToInt64(X1);
            SumY1 += Convert.ToInt64(Y1);


            if (ChangeCounter >= ChangeDivider)
            {
                AverageX1 = (int)(SumX1 / (long)ChangeDivider);
                AverageY1 = (int)(SumY1 / (long)ChangeDivider);

                SumX1 = 0;
                SumY1 = 0;
                ChangeCounter = 0; // Reset counter
            }

            DisplayX1 = X1 - AverageX1;
            DisplayY1 = Y1 - AverageY1;

            // Add X1 value to dataX list
            if (play)
            {
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
            }

            if (ModbusCon && AlarmReady)
            {
                if (DisplayX1 > EtHerG.Properties.Settings.Default.Alarm1Value || DisplayX1 < -EtHerG.Properties.Settings.Default.Alarm1Value || DisplayY1 > EtHerG.Properties.Settings.Default.Alarm1Value || DisplayY1 < -EtHerG.Properties.Settings.Default.Alarm1Value)
                {
                    Alarm1Timer.Stop();
                    Alarm1Timer.Start();
                    if (Alarm1SingleWrite == false)
                    {
                        Alarm1SingleWrite = true;
                        modbusMaster.WriteSingleCoil(1, EtHerG.Properties.Settings.Default.Alarm1ModbusAddress, true);

                        if (EtHerG.Properties.Settings.Default.InfluxDBEnabled)
                        {
                            var Alarm1 = PointData.Measurement("Alarms")
                                .Tag("device", EtHerG.Properties.Settings.Default.InfluxDBMachine)
                                .Field("Alarm1", true)
                                .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

                            influxDBClient.GetWriteApi().WritePoint(Alarm1, EtHerG.Properties.Settings.Default.InfluxDBBucket, EtHerG.Properties.Settings.Default.InfluxDBOrgID);
                        }
                    }
                }

                if (DisplayX1 > EtHerG.Properties.Settings.Default.Alarm2Value || DisplayX1 < -EtHerG.Properties.Settings.Default.Alarm2Value || DisplayY1 > EtHerG.Properties.Settings.Default.Alarm2Value || DisplayY1 < -EtHerG.Properties.Settings.Default.Alarm2Value)
                {
                    Alarm2Timer.Stop();
                    Alarm2Timer.Start();
                    if (Alarm2SingleWrite == false)
                    {
                        Alarm2SingleWrite = true;
                        modbusMaster.WriteSingleCoil(1, EtHerG.Properties.Settings.Default.Alarm2ModbusAddress, true);

                        if (EtHerG.Properties.Settings.Default.InfluxDBEnabled)
                        {
                            var Alarm2 = PointData.Measurement("Alarms")
                                .Tag("device", EtHerG.Properties.Settings.Default.InfluxDBMachine)
                                .Field("Alarm2", true)
                                .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

                            influxDBClient.GetWriteApi().WritePoint(Alarm2, EtHerG.Properties.Settings.Default.InfluxDBBucket, EtHerG.Properties.Settings.Default.InfluxDBOrgID);
                        }
                    }
                }
            }

            //If dataX list is full, add it to the Streamer
            if (dataX.Count >= 800 && !DiagWorker.IsBusy && IsHandleCreated) // Adjust the threshold as needed
            {
                DiagWorker.RunWorkerAsync();
            }
        }

        private void DiagWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            Invoke(new Action(() =>
            {

                UpdateScatterDiag();
                UpdateLineDiag();

                txtX.Text = DisplayX1.ToString(); // Update textBox1 with X1 value
                txtY.Text = DisplayY1.ToString();
            }));
        }

        private void UpdateLineDiag()
        {
            if (playX == true)
            {
                lock (dataLockX) // Lock access to dataX and dataY
                {
                    StreamX.AddRange(dataX);
                }
            }

            if (playY == true)
            {
                lock (dataLockY) // Lock access to dataX and dataY
                {
                    StreamY.AddRange(dataY);
                }
            }

            formLineDiag.Refresh();

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
                lastSpecifiedXValues = ScatterX.Skip(Math.Max(0, ScatterX.Count - EtHerG.Properties.Settings.Default.ScatterPoints)).ToList(); // Get last 100 X values
                lastSpecifiedYValues = ScatterY.Skip(Math.Max(0, ScatterY.Count - EtHerG.Properties.Settings.Default.ScatterPoints)).ToList(); // Get last 100 Y values
            }

            formScatter.Plot.Clear();
            var Alarm5 = formScatter.Plot.Add.Rectangle(-EtHerG.Properties.Settings.Default.Alarm1Value, EtHerG.Properties.Settings.Default.Alarm1Value, -EtHerG.Properties.Settings.Default.Alarm1Value, EtHerG.Properties.Settings.Default.Alarm1Value);
            var Alarm6 = formScatter.Plot.Add.Rectangle(-EtHerG.Properties.Settings.Default.Alarm2Value, EtHerG.Properties.Settings.Default.Alarm2Value, -EtHerG.Properties.Settings.Default.Alarm2Value, EtHerG.Properties.Settings.Default.Alarm2Value);
            Alarm5.FillStyle.Color = ScottPlot.Color.FromHex("#D22B2B").WithAlpha(0);
            Alarm6.FillStyle.Color = ScottPlot.Color.FromHex("#388e3c").WithAlpha(0);
            Alarm5.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.Alarm1Color); // Alarm 1
            Alarm6.LineStyle.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.Alarm2Color); // Alarm 2
            Alarm5.LineStyle.Width = 3;
            Alarm6.LineStyle.Width = 3;
            if (EtHerG.Properties.Settings.Default.ScatterDiagDrawPoints)
            {
                var ScatterPoints = formScatter.Plot.Add.ScatterPoints(lastSpecifiedXValues, lastSpecifiedYValues);
                ScatterPoints.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.ScatterDiagColor);
                ScatterPoints.MarkerSize = 1;
            }
            else
            {
                var ScatterLine = formScatter.Plot.Add.ScatterLine(lastSpecifiedXValues, lastSpecifiedYValues);
                ScatterLine.Color = ScottPlot.Color.FromHex(EtHerG.Properties.Settings.Default.ScatterDiagColor);
            }
            
            formScatter.Plot.Axes.SetLimits(-EtHerG.Properties.Settings.Default.DiagMaxPointSize, EtHerG.Properties.Settings.Default.DiagMaxPointSize, -EtHerG.Properties.Settings.Default.DiagMaxPointSize, EtHerG.Properties.Settings.Default.DiagMaxPointSize);
            formScatter.Interaction.Disable();
            formScatter.Refresh();

            if (lastSpecifiedXValues.Count > EtHerG.Properties.Settings.Default.ScatterPoints)
            {
                lastSpecifiedXValues.RemoveRange(0, (lastSpecifiedXValues.Count - EtHerG.Properties.Settings.Default.ScatterPoints));
                lastSpecifiedYValues.RemoveRange(0, (lastSpecifiedYValues.Count - EtHerG.Properties.Settings.Default.ScatterPoints));
            }
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            resetTimer.Stop();
            if (EtherConnected == true) { ether.CloseSerialConnection(); }
            ModbusTimer.Stop();

            // Cancel the background worker's operation
            DiagWorker.CancelAsync();

            // Wait for the background worker to complete
            while (DiagWorker.IsBusy)
            {
                Application.DoEvents(); // Allow the application to process events
                System.Threading.Thread.Sleep(100); // Pause for a short duration
            }

            ModbusWorker.CancelAsync();
            while (ModbusWorker.IsBusy)
            {
                Application.DoEvents(); // Allow the application to process events
                System.Threading.Thread.Sleep(1000); // Pause for a short duration
            }
            CloseModbusConnection();
        }

        private void ModbusWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            if (ModbusCon)
            {
                if (EtHerG.Properties.Settings.Default.PlayModbusAddress != 0)
                {
                    play = modbusMaster.ReadCoils(1, EtHerG.Properties.Settings.Default.PlayModbusAddress, 1)[0];
                    Invoke(new Action(() =>
                    {
                        txtPlayLastModbusValue.Text = play.ToString();
                    }));
                }


                //Read Frequency
                if (EtHerG.Properties.Settings.Default.FrequencyModbusAddress != 0)
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
                if (EtHerG.Properties.Settings.Default.GainXModbusAddress != 0)
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
                if (EtHerG.Properties.Settings.Default.GainYModbusAddress != 0)
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
                if (EtHerG.Properties.Settings.Default.PhaseModbusAddress != 0)
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
                if (EtHerG.Properties.Settings.Default.FilterLPModbusAddress != 0)
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
                if (EtHerG.Properties.Settings.Default.FilterHPModbusAddress != 0)
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
        }

        private void CloseModbusConnection()
        {
            if (ModbusCon)
            {
                modbusClient.Close();
                ModbusCon = false;
            }
        }

        private void OpenModbusConnection()
        {
            // Check if ModbusServerIP is set to 0 or null
            if (string.IsNullOrEmpty(EtHerG.Properties.Settings.Default.ModbusServerIP))
            {
                ModbusPropertiesSetToZeroOrNull.Add("ModbusServerIP");
            }

            // Check if ModbusServerPort is set to 0 or null
            if (EtHerG.Properties.Settings.Default.ModbusServerPort == 0)
            {
                ModbusPropertiesSetToZeroOrNull.Add("ModbusServerPort");
            }

            // Check if PlayModbusAddress is set to 0 or null
            if (EtHerG.Properties.Settings.Default.PlayModbusAddress == 0)
            {
                ModbusPropertiesSetToZeroOrNull.Add("PlayModbusAddress");
            }

            // Check if FrequencyModbusAddress is set to 0 or null
            if (EtHerG.Properties.Settings.Default.FrequencyModbusAddress == 0)
            {
                ModbusPropertiesSetToZeroOrNull.Add("FrequencyModbusAddress");
            }

            // Check other Modbus address properties similarly...

            // If any Modbus property is set to 0 or null, display a single MessageBox with the list of properties
            if (ModbusPropertiesSetToZeroOrNull.Any())
            {
                string message = "The following Modbus properties are still set to 0 or null:\n";

                // Add each Modbus property to the message with a new line
                foreach (string property in ModbusPropertiesSetToZeroOrNull)
                {
                    message += $"{property}\n";
                }

                MessageBox.Show(message);
            }
            else
            {
                try
                {
                    modbusClient = new TcpClient(EtHerG.Properties.Settings.Default.ModbusServerIP, EtHerG.Properties.Settings.Default.ModbusServerPort);
                    var factory = new ModbusFactory();
                    modbusMaster = factory.CreateMaster(modbusClient);
                    ModbusCon = true;
                    txtModbusStatus.BackColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    // Log or display a warning that the connection failed
                    MessageBox.Show($"Failed to connect to Modbus server: {ex.Message}");
                    // Stop trying to connect
                    txtModbusStatus.BackColor = System.Drawing.Color.Red;
                    return;
                }
            }
        }

        private void OpenSerialConnection()
        {
            // Check if Frequency is set to 0 or null
            if (EtHerG.Properties.Settings.Default.Frequency == 0 || EtHerG.Properties.Settings.Default.Frequency == null)
            {
                EtherPropertiesSetToZeroOrNull.Add("Frequency");
            }

            // Check if GainX is set to 0 or null
            if (EtHerG.Properties.Settings.Default.GainX == 0 || EtHerG.Properties.Settings.Default.GainX == null)
            {
                EtherPropertiesSetToZeroOrNull.Add("GainX");
            }

            // Check if GainY is set to 0 or null
            if (EtHerG.Properties.Settings.Default.GainY == 0 || EtHerG.Properties.Settings.Default.GainY == null)
            {
                EtherPropertiesSetToZeroOrNull.Add("GainY");
            }

            // Check if Phase is set to 0 or null
            if (EtHerG.Properties.Settings.Default.Phase == 0 || EtHerG.Properties.Settings.Default.Phase == null)
            {
                EtherPropertiesSetToZeroOrNull.Add("Phase");
            }

            // Check if FilterLP is set to 0 or null
            if (EtHerG.Properties.Settings.Default.FilterLP == 0 || EtHerG.Properties.Settings.Default.FilterLP == null)
            {
                EtherPropertiesSetToZeroOrNull.Add("FilterLP");
            }

            // Check if FilterHP is set to 0 or null
            if (EtHerG.Properties.Settings.Default.FilterHP == 0 || EtHerG.Properties.Settings.Default.FilterHP == null)
            {
                EtherPropertiesSetToZeroOrNull.Add("FilterHP");
            }

            // Check if ComPort is set to 0 or null
            if (EtHerG.Properties.Settings.Default.ComPort == 0 || EtHerG.Properties.Settings.Default.ComPort == null)
            {
                EtherPropertiesSetToZeroOrNull.Add("ComPort");
            }

            // Check if LineDiagPoints is set to 0 or null
            if (EtHerG.Properties.Settings.Default.LineDiagPoints == 0 || EtHerG.Properties.Settings.Default.LineDiagPoints == null)
            {
                EtherPropertiesSetToZeroOrNull.Add("LineDiagPoints");
            }

            // Check if ScatterPoints is set to 0 or null
            if (EtHerG.Properties.Settings.Default.ScatterPoints == 0 || EtHerG.Properties.Settings.Default.ScatterPoints == null)
            {
                EtherPropertiesSetToZeroOrNull.Add("ScatterPoints");
            }

            // If any property is set to 0, display a single MessageBox with the list of properties
            if (EtherPropertiesSetToZeroOrNull.Any())
            {
                string message = "The following properties are not set up:\n";

                // Add each property to the message with a new line
                foreach (string property in EtherPropertiesSetToZeroOrNull)
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
                    }
                    else
                    {
                        MessageBox.Show("Verbindungsaufbau nicht möglich");
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
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == EtHerG.Properties.Settings.Default.Password) { LoggedIn(); }
        }

        private void LoggedIn()
        {
            btnSetPassword.Visible = true;
            chkAutologin.Visible = true;
            txtSetPassword.Visible = true;
            chkDisableUserInput.Visible = true;
            txtModbusServerIP.Visible = true;
            txtModbusServerPort.Visible = true;
            lblModbusServerIP.Visible = true;
            lblModbusServerPort.Visible = true;
            lblModbusReadAdresses.Visible = true;
            lblModbusReadValue.Visible = true;
            lblModbusLastSentValueAdress.Visible = true;
            chkModbusLastSentAddressEnabled.Visible = true;
            lblPlay.Visible = true;
            lblFrequency1.Visible = true;
            lblGainX1.Visible = true;
            lblGainY1.Visible = true;
            lblPhase1.Visible = true;
            lblFilterHP1.Visible = true;
            lblFilterLP1.Visible = true;
            lblAlarm1ModbusSendAddress.Visible = true;
            lblAlarm2ModbusSendAddress.Visible = true;
            chkInfluxDBEnabled.Visible = true;
            lblInfluxDBBucket.Visible = true;
            lblInfluxDBMachineName.Visible = true;
            lblInfluxDBORGID.Visible = true;
            lblInfluxDBServer.Visible = true;
            lblInfluxDBToken.Visible = true;
            txtPlayLastModbusValue.Visible = true;
            txtPlayModbusAddress.Visible = true;
            txtFrequencyModbusAddress.Visible = true;
            txtFrequencyLastModbusValue.Visible = true;
            txtFrequencyModbusLastSentAddress.Visible = true;
            txtGainXLastModbusValue.Visible = true;
            txtGainXModbusAddress.Visible = true;
            txtGainXModbusLastSentAddress.Visible = true;
            txtGainYLastModbusValue.Visible = true;
            txtGainYModbusAddress.Visible = true;
            txtGainYModbusLastSentAddress.Visible = true;
            txtPhaseLastModbusValue.Visible = true;
            txtPhaseModbusAddress.Visible = true;
            txtPhaseModbusLastSentAddress.Visible = true;
            txtFilterLPLastModbusValue.Visible = true;
            txtFilterLPModbusAddress.Visible = true;
            txtFilterLPModbusLastSentAddress.Visible = true;
            txtFilterHPLastModbusValue.Visible = true;
            txtFilterHPModbusAddress.Visible = true;
            txtFilterHPModbusLastSentAddress.Visible = true;
            txtAlarm1ModbusAddress.Visible = true;
            txtAlarm2ModbusAddress.Visible = true;
            txtInfluxDBBucket.Visible = true;
            txtInfluxDBMachine.Visible = true;
            txtInfluxDBOrg.Visible = true;
            txtInfluxDBServer.Visible = true;
            txtInfluxDBToken.Visible = true;
        }

        private void LoggedOut()
        {
            btnSetPassword.Visible = false;
            chkAutologin.Visible = false;
            txtSetPassword.Visible = false;
            chkDisableUserInput.Visible = false;
            txtModbusServerIP.Visible = false;
            txtModbusServerPort.Visible = false;
            lblModbusServerIP.Visible = false;
            lblModbusServerPort.Visible = false;
            lblModbusReadAdresses.Visible = false;
            lblModbusReadValue.Visible = false;
            lblModbusLastSentValueAdress.Visible = false;
            chkModbusLastSentAddressEnabled.Visible = false;
            lblPlay.Visible = false;
            lblFrequency1.Visible = false;
            lblGainX1.Visible = false;
            lblGainY1.Visible = false;
            lblPhase1.Visible = false;
            lblFilterHP1.Visible = false;
            lblFilterLP1.Visible = false;
            lblAlarm1ModbusSendAddress.Visible = false;
            lblAlarm2ModbusSendAddress.Visible = false;
            chkInfluxDBEnabled.Visible = false;
            lblInfluxDBBucket.Visible = false;
            lblInfluxDBMachineName.Visible = false;
            lblInfluxDBORGID.Visible = false;
            lblInfluxDBServer.Visible = false;
            lblInfluxDBToken.Visible = false;
            txtPlayLastModbusValue.Visible = false;
            txtPlayModbusAddress.Visible = false;
            txtFrequencyModbusAddress.Visible = false;
            txtFrequencyLastModbusValue.Visible = false;
            txtFrequencyModbusLastSentAddress.Visible = false;
            txtGainXLastModbusValue.Visible = false;
            txtGainXModbusAddress.Visible = false;
            txtGainXModbusLastSentAddress.Visible = false;
            txtGainYLastModbusValue.Visible = false;
            txtGainYModbusAddress.Visible = false;
            txtGainYModbusLastSentAddress.Visible = false;
            txtPhaseLastModbusValue.Visible = false;
            txtPhaseModbusAddress.Visible = false;
            txtPhaseModbusLastSentAddress.Visible = false;
            txtFilterLPLastModbusValue.Visible = false;
            txtFilterLPModbusAddress.Visible = false;
            txtFilterLPModbusLastSentAddress.Visible = false;
            txtFilterHPLastModbusValue.Visible = false;
            txtFilterHPModbusAddress.Visible = false;
            txtFilterHPModbusLastSentAddress.Visible = false;
            txtAlarm1ModbusAddress.Visible = false;
            txtAlarm2ModbusAddress.Visible = false;
            txtInfluxDBBucket.Visible = false;
            txtInfluxDBMachine.Visible = false;
            txtInfluxDBOrg.Visible = false;
            txtInfluxDBServer.Visible = false;
            txtInfluxDBToken.Visible = false;
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
            if (chkShowX.Checked)
            {
                playX = true;
            }
            else
            {
                playX = false;
                StreamX.Clear();
            }
            EtHerG.Properties.Settings.Default.ShowX = chkShowX.Checked;
            EtHerG.Properties.Settings.Default.Save();
        }

        private void chkShowY_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowY.Checked)
            {
                playY = true;
            }
            else
            {
                playY = false;
                StreamY.Clear();
            }
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
            EtHerG.Properties.Settings.Default.PlayModbusAddress = ushort.Parse(txtPlayModbusAddress.Text);
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtAlarm1Value_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAlarm1Value.Text))
            {
                EtHerG.Properties.Settings.Default.Alarm1Value = int.Parse(txtAlarm1Value.Text);
                EtHerG.Properties.Settings.Default.Save();
                FormatDiags();
            }
        }

        private void txtAlarm2Value_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAlarm2Value.Text))
            {
                EtHerG.Properties.Settings.Default.Alarm2Value = int.Parse(txtAlarm2Value.Text);
                EtHerG.Properties.Settings.Default.Save();
                FormatDiags();
            }
        }

        private void txtFrequencyModbusAddress_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.FrequencyModbusAddress = ushort.Parse(txtFrequencyModbusAddress.Text);
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtGainXModbusAddress_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.GainXModbusAddress = ushort.Parse(txtGainXModbusAddress.Text);
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtGainYModbusAddress_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.GainYModbusAddress = ushort.Parse(txtGainYModbusAddress.Text);
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtPhaseModbusAddress_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.PhaseModbusAddress = ushort.Parse(txtPhaseModbusAddress.Text);
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtFilterLPModbusAddress_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.FilterLPModbusAddress = ushort.Parse(txtFilterLPModbusAddress.Text);
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtFilterHPModbusAddress_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.FilterHPModbusAddress = ushort.Parse(txtFilterHPModbusAddress.Text);
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtScatterPoints_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.ScatterPoints = Int32.Parse(txtScatterPoints.Text);
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtModbusServerIP_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.ModbusServerIP = txtModbusServerIP.Text;
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtModbusServerPort_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.ModbusServerPort = int.Parse(txtModbusServerPort.Text);
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtCOMPort_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.ComPort = int.Parse(txtCOMPort.Text);
            EtHerG.Properties.Settings.Default.Save();
        }

        private void txtLineDiagPoints_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLineDiagPoints.Text) && Int32.TryParse(txtLineDiagPoints.Text, out int LineDiagPoints) && LineDiagPoints < 1000001)
            {
                EtHerG.Properties.Settings.Default.LineDiagPoints = LineDiagPoints;
                EtHerG.Properties.Settings.Default.Save();
                FormatDiags();
            }
        }

        private void txtLineDiagHeight_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDiagMaxPointSize.Text) && Int32.TryParse(txtDiagMaxPointSize.Text, out int LineDiagHeight))
            {
                EtHerG.Properties.Settings.Default.DiagMaxPointSize = LineDiagHeight;
                EtHerG.Properties.Settings.Default.Save();
                FormatDiags();
            }
        }

        private void txtScatterDiagPosX_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.ScatterDiagPosX = int.Parse(txtScatterDiagPosX.Text);
            EtHerG.Properties.Settings.Default.Save();
            formScatter.Location = new Point(EtHerG.Properties.Settings.Default.ScatterDiagPosX, EtHerG.Properties.Settings.Default.ScatterDiagPosY);
        }

        private void txtScatterDiagPosY_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.ScatterDiagPosY = int.Parse(txtScatterDiagPosY.Text);
            EtHerG.Properties.Settings.Default.Save();
            formScatter.Location = new Point(EtHerG.Properties.Settings.Default.ScatterDiagPosX, EtHerG.Properties.Settings.Default.ScatterDiagPosY);
        }

        private void txtScatterDiagSize_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.ScatterDiagSize = int.Parse(txtScatterDiagSize.Text);
            EtHerG.Properties.Settings.Default.Save();
            formScatter.Size = new Size(EtHerG.Properties.Settings.Default.ScatterDiagSize, EtHerG.Properties.Settings.Default.ScatterDiagSize);
        }

        private void txtLineDiagPosX_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.LineDiagPosX = int.Parse(txtLineDiagPosX.Text);
            EtHerG.Properties.Settings.Default.Save();
            formLineDiag.Location = new Point(EtHerG.Properties.Settings.Default.LineDiagPosX, EtHerG.Properties.Settings.Default.LineDiagPosY);
        }

        private void txtLineDiagPosY_LostFocus(object sender, EventArgs e)
        {
            if (int.Parse(txtLineDiagPosY.Text) < 400)
            {
                LineDiagPosY = 400;
            }
            else
            {
                LineDiagPosY = int.Parse(txtLineDiagPosY.Text);
            }
            EtHerG.Properties.Settings.Default.LineDiagPosY = LineDiagPosY;
            EtHerG.Properties.Settings.Default.Save();
            formLineDiag.Location = new Point(EtHerG.Properties.Settings.Default.LineDiagPosX, EtHerG.Properties.Settings.Default.LineDiagPosY);
        }

        private void txtLineDiagSizeX_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.LineDiagSizeX = int.Parse(txtLineDiagSizeX.Text);
            EtHerG.Properties.Settings.Default.Save();
            formLineDiag.Size = new Size(EtHerG.Properties.Settings.Default.LineDiagSizeX, EtHerG.Properties.Settings.Default.LineDiagSizeY);
        }

        private void txtLineDiagSizeY_LostFocus(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.LineDiagSizeY = int.Parse(txtLineDiagSizeY.Text);
            EtHerG.Properties.Settings.Default.Save();
            formLineDiag.Size = new Size(EtHerG.Properties.Settings.Default.LineDiagSizeX, EtHerG.Properties.Settings.Default.LineDiagSizeY);
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
            if (!string.IsNullOrWhiteSpace(txtAlarm1ModbusAddress.Text))
            {
                EtHerG.Properties.Settings.Default.Alarm1ModbusAddress = ushort.Parse(txtAlarm1ModbusAddress.Text);
                EtHerG.Properties.Settings.Default.Save();
            }

        }

        private void txtAlarm2ModbusAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAlarm2ModbusAddress.Text))
            {
                EtHerG.Properties.Settings.Default.Alarm2ModbusAddress = ushort.Parse(txtAlarm2ModbusAddress.Text);
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void chkModbusLastSentEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModbusLastSentAddressEnabled.Checked)
            {
                // Check if FrequencyModbusLastSendAddress is set to 0 or null
                if (EtHerG.Properties.Settings.Default.FrequencyModbusLastSendAddress == 0)
                {
                    modbusLastSendAddressesSetToZeroOrNull.Add("FrequencyModbusLastSendAddress");
                }

                // Check if GainYModbusLastSendAddress is set to 0 or null
                if (EtHerG.Properties.Settings.Default.GainYModbusLastSendAddress == 0)
                {
                    modbusLastSendAddressesSetToZeroOrNull.Add("GainYModbusLastSendAddress");
                }

                // Check if GainXModbusLastSendAddress is set to 0 or null
                if (EtHerG.Properties.Settings.Default.GainXModbusLastSendAddress == 0)
                {
                    modbusLastSendAddressesSetToZeroOrNull.Add("GainXModbusLastSendAddress");
                }

                // Check if PhaseModbusLastSendAddress is set to 0 or null
                if (EtHerG.Properties.Settings.Default.PhaseModbusLastSendAddress == 0)
                {
                    modbusLastSendAddressesSetToZeroOrNull.Add("PhaseModbusLastSendAddress");
                }

                // Check if FilterHPModbusLastSendAddress is set to 0 or null
                if (EtHerG.Properties.Settings.Default.FilterHPModbusLastSendAddress == 0)
                {
                    modbusLastSendAddressesSetToZeroOrNull.Add("FilterHPModbusLastSendAddress");
                }

                // Check if FilterLPModbusLastSendAddress is set to 0 or null
                if (EtHerG.Properties.Settings.Default.FilterLPModbusLastSendAddress == 0)
                {
                    modbusLastSendAddressesSetToZeroOrNull.Add("FilterLPModbusLastSendAddress");
                }

                // If any Modbus last send address property is set to 0 or null, display a single MessageBox with the list of properties
                if (modbusLastSendAddressesSetToZeroOrNull.Any())
                {
                    string message = "The following Modbus last send address properties are still set to 0 or null:\n";

                    // Add each Modbus last send address property to the message with a new line
                    foreach (string property in modbusLastSendAddressesSetToZeroOrNull)
                    {
                        message += $"{property}\n";
                    }

                    MessageBox.Show(message);
                }
                else
                {
                    EtHerG.Properties.Settings.Default.ModbusLastSentAddressEnabled = chkModbusLastSentAddressEnabled.Checked;
                    EtHerG.Properties.Settings.Default.Save();
                }
            }
            else
            {
                EtHerG.Properties.Settings.Default.ModbusLastSentAddressEnabled = chkModbusLastSentAddressEnabled.Checked;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtFrequencyModbusLastSentAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFrequencyModbusLastSentAddress.Text))
            {
                EtHerG.Properties.Settings.Default.FrequencyModbusLastSendAddress = Convert.ToUInt16(txtFrequencyModbusLastSentAddress.Text);
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtGainXModbusLastSentAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGainXModbusLastSentAddress.Text))
            {

                EtHerG.Properties.Settings.Default.GainXModbusLastSendAddress = Convert.ToUInt16(txtGainXModbusLastSentAddress.Text);
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtGainYModbusLastSentAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGainYModbusLastSentAddress.Text))
            {

                EtHerG.Properties.Settings.Default.GainYModbusLastSendAddress = Convert.ToUInt16(txtGainYModbusLastSentAddress.Text);
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtPhaseModbusLastSentAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPhaseModbusLastSentAddress.Text))
            {
                EtHerG.Properties.Settings.Default.PhaseModbusLastSendAddress = Convert.ToUInt16(txtPhaseModbusLastSentAddress.Text);
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtFilterLPModbusLastSentAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFilterLPModbusLastSentAddress.Text))
            {
                EtHerG.Properties.Settings.Default.FilterLPModbusLastSendAddress = Convert.ToUInt16(txtFilterLPModbusLastSentAddress.Text);
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtFilterHPModbusLastSentAddress_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFilterHPModbusLastSentAddress.Text))
            {
                EtHerG.Properties.Settings.Default.FilterHPModbusLastSendAddress = Convert.ToUInt16(txtFilterHPModbusLastSentAddress.Text);
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
                    break;

                case "GainY":
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
                // Check if InfluxDBServer is null or empty
                if (string.IsNullOrEmpty(EtHerG.Properties.Settings.Default.InfluxDBServer))
                {
                    influxDBPropertiesSetToNullOrEmpty.Add("InfluxDBServer");
                }

                // Check if InfluxDBToken is null or empty
                if (string.IsNullOrEmpty(EtHerG.Properties.Settings.Default.InfluxDBToken))
                {
                    influxDBPropertiesSetToNullOrEmpty.Add("InfluxDBToken");
                }

                // Check if InfluxDBBucket is null or empty
                if (string.IsNullOrEmpty(EtHerG.Properties.Settings.Default.InfluxDBBucket))
                {
                    influxDBPropertiesSetToNullOrEmpty.Add("InfluxDBBucket");
                }

                // Check if InfluxDBMachine is null or empty
                if (string.IsNullOrEmpty(EtHerG.Properties.Settings.Default.InfluxDBMachine))
                {
                    influxDBPropertiesSetToNullOrEmpty.Add("InfluxDBMachine");
                }

                // Check if InfluxDBOrgID is null or empty
                if (string.IsNullOrEmpty(EtHerG.Properties.Settings.Default.InfluxDBOrgID))
                {
                    influxDBPropertiesSetToNullOrEmpty.Add("InfluxDBOrgID");
                }

                // If any InfluxDB property is null or empty, display a single MessageBox with the list of properties
                if (influxDBPropertiesSetToNullOrEmpty.Any())
                {
                    string message = "The following InfluxDB properties are still null or empty:\n";

                    // Add each InfluxDB property to the message with a new line
                    foreach (string property in influxDBPropertiesSetToNullOrEmpty)
                    {
                        message += $"{property}\n";
                    }

                    MessageBox.Show(message);
                }
                else
                {
                    EtHerG.Properties.Settings.Default.InfluxDBEnabled = chkInfluxDBEnabled.Checked;
                    EtHerG.Properties.Settings.Default.Save();
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

        private void txtAlarm1Color_LostFocus(object sender, EventArgs e)
        {
            if (IsValidHexColor(txtAlarm1Color.Text))
            {
                EtHerG.Properties.Settings.Default.Alarm1Color = txtAlarm1Color.Text;
                EtHerG.Properties.Settings.Default.Save();
                FormatDiags();
            }
            else
            {
                MessageBox.Show("Please enter Valid Color!");
            }
        }

        private void txtAlarm2Color_LostFocus(object sender, EventArgs e)
        {
            if (IsValidHexColor(txtAlarm2Color.Text))
            {
                EtHerG.Properties.Settings.Default.Alarm2Color = txtAlarm2Color.Text;
                EtHerG.Properties.Settings.Default.Save();
                FormatDiags();
            }
            else
            {
                MessageBox.Show("Please enter Valid Color!");
            }
        }

        private void txtLineDiagColorX_LostFocus(object sender, EventArgs e)
        {
            if (IsValidHexColor(txtLineDiagColorX.Text))
            {
                EtHerG.Properties.Settings.Default.LineDiagColorX = txtLineDiagColorX.Text;
                EtHerG.Properties.Settings.Default.Save();
                FormatDiags();
            }
            else
            {
                MessageBox.Show("Please enter Valid Color!");
            }
        }

        private void txtLineDiagYColor_LostFocus(object sender, EventArgs e)
        {
            if (IsValidHexColor(txtLineDiagColorY.Text))
            {
                EtHerG.Properties.Settings.Default.LineDiagColorY = txtLineDiagColorY.Text;
                EtHerG.Properties.Settings.Default.Save();
                FormatDiags();
            }
            else
            {
                MessageBox.Show("Please enter Valid Color!");
            }
        }

        private void txtScatterDiagColor_LostFocus(object sender, EventArgs e)
        {
            if (IsValidHexColor(txtScatterDiagColor.Text))
            {
                EtHerG.Properties.Settings.Default.ScatterDiagColor = txtScatterDiagColor.Text;
                EtHerG.Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Please enter Valid Color!");
            }
        }

        private void chkScatterDrawPoints_CheckedChanged(object sender, EventArgs e)
        {
            EtHerG.Properties.Settings.Default.ScatterDiagDrawPoints = chkScatterDrawPoints.Checked;
            EtHerG.Properties.Settings.Default.Save();
        }
    }
}

//btnEtherConnect.Text = "Ether Verbinden";
//btnEtherDisconnect.Text = "Ether Trennen";
//btnModbusConnect.Text = "Modbus Verbinden";
//btnModbusDisconnect.Text = "Modbus Trennen";