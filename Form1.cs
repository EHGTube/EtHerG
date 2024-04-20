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
        public List<double> last100XValues = new List<double>();
        public List<double> last100YValues = new List<double>();

        public int counter = 0;
        public bool firstCon = false;
        public int Xval;
        public int Yval;
        private System.Timers.Timer resetTimer;
        private System.Timers.Timer ModbusTimer;
        private System.Timers.Timer Alarm1Timer;
        private System.Timers.Timer Alarm2Timer;
        private System.Timers.Timer initTimer;

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

        private readonly object dataLockX = new object();
        private readonly object dataLockY = new object();
        private readonly object dataLockScatter = new object();

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

            if (EtHerG.Properties.Settings.Default.InfluxDBEnabled == true)
            {
                //using (var influxDBClient = InfluxDBClientFactory.Create("http://localhost:8086", "my-token".ToCharArray())) ;
                //var influxDBClient = new InfluxDB.Client.InfluxDBClient.Create()
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

                formLineDiag.Location = new Point(EtHerG.Properties.Settings.Default.LineDiagPosX, EtHerG.Properties.Settings.Default.LineDiagPosY);
                formLineDiag.Size = new Size(EtHerG.Properties.Settings.Default.LineDiagSizeX, EtHerG.Properties.Settings.Default.LineDiagSizeY);
                formScatter.Location = new Point(EtHerG.Properties.Settings.Default.ScatterDiagPosX, EtHerG.Properties.Settings.Default.ScatterDiagPosY);
                formScatter.Size = new Size(EtHerG.Properties.Settings.Default.ScatterDiagSize, EtHerG.Properties.Settings.Default.ScatterDiagSize);



                chkShowX.Checked = true;
                chkShowY.Checked = true;
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

                if (chkAutologin.Checked == true)
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

        private void FormatDiags()
        {
            Invoke(new Action(() =>
            {
                formLineDiag.Reset();
                StreamX.Clear();
                StreamY.Clear();
                StreamX = formLineDiag.Plot.Add.DataStreamer(EtHerG.Properties.Settings.Default.LineDiagPoints);
                StreamY = formLineDiag.Plot.Add.DataStreamer(EtHerG.Properties.Settings.Default.LineDiagPoints);
                StreamX.LineStyle.Color = ScottPlot.Color.FromHex("#0000FF");
                StreamY.LineStyle.Color = ScottPlot.Color.FromHex("#00CED1");
                StreamY.ViewScrollLeft();
                StreamX.ViewScrollLeft();
                StreamX.ManageAxisLimits = false;
                StreamY.ManageAxisLimits = false;

                HorizontalLine Alarm1 = formLineDiag.Plot.Add.HorizontalLine(EtHerG.Properties.Settings.Default.Alarm1Value);
                HorizontalLine Alarm2 = formLineDiag.Plot.Add.HorizontalLine(-EtHerG.Properties.Settings.Default.Alarm1Value);
                Alarm1.LineStyle.Color = ScottPlot.Color.FromHex("#D22B2B");
                Alarm2.LineStyle.Color = ScottPlot.Color.FromHex("#D22B2B");

                HorizontalLine Alarm3 = formLineDiag.Plot.Add.HorizontalLine(EtHerG.Properties.Settings.Default.Alarm2Value);
                HorizontalLine Alarm4 = formLineDiag.Plot.Add.HorizontalLine(-EtHerG.Properties.Settings.Default.Alarm2Value);
                Alarm3.LineStyle.Color = ScottPlot.Color.FromHex("#388e3c");
                Alarm4.LineStyle.Color = ScottPlot.Color.FromHex("#388e3c");

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

            if (ModbusCon)
            {
                if (DisplayX1 > EtHerG.Properties.Settings.Default.Alarm1Value || DisplayX1 < -EtHerG.Properties.Settings.Default.Alarm1Value || DisplayY1 > EtHerG.Properties.Settings.Default.Alarm1Value || DisplayY1 < -EtHerG.Properties.Settings.Default.Alarm1Value)
                {
                    Alarm1Timer.Stop();
                    Alarm1Timer.Start();
                    if (Alarm1SingleWrite == false)
                    {
                        Alarm1SingleWrite = true;
                        modbusMaster.WriteSingleCoil(1, EtHerG.Properties.Settings.Default.Alarm1ModbusAddress, true);
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
            lock (dataLockScatter)
            {
                last100XValues = ScatterX.Skip(Math.Max(0, ScatterX.Count - EtHerG.Properties.Settings.Default.ScatterPoints)).ToList(); // Get last 100 X values
                last100YValues = ScatterY.Skip(Math.Max(0, ScatterY.Count - EtHerG.Properties.Settings.Default.ScatterPoints)).ToList(); // Get last 100 Y values
            }

            formScatter.Plot.Clear();
            var Alarm5 = formScatter.Plot.Add.Rectangle(-EtHerG.Properties.Settings.Default.Alarm1Value, EtHerG.Properties.Settings.Default.Alarm1Value, -EtHerG.Properties.Settings.Default.Alarm1Value, EtHerG.Properties.Settings.Default.Alarm1Value);
            var Alarm6 = formScatter.Plot.Add.Rectangle(-EtHerG.Properties.Settings.Default.Alarm2Value, EtHerG.Properties.Settings.Default.Alarm2Value, -EtHerG.Properties.Settings.Default.Alarm2Value, EtHerG.Properties.Settings.Default.Alarm2Value);
            Alarm5.FillStyle.Color = ScottPlot.Color.FromHex("#D22B2B").WithAlpha(0);
            Alarm6.FillStyle.Color = ScottPlot.Color.FromHex("#388e3c").WithAlpha(0);
            Alarm5.LineStyle.Color = ScottPlot.Color.FromHex("#D22B2B");
            Alarm6.LineStyle.Color = ScottPlot.Color.FromHex("#388e3c");
            Alarm5.LineStyle.Width = 3;
            Alarm6.LineStyle.Width = 3;
            var ScatterLine = formScatter.Plot.Add.ScatterLine(last100XValues, last100YValues);
            ScatterLine.Color = ScottPlot.Color.FromHex("#0067E8");
            formScatter.Plot.Axes.SetLimits(-EtHerG.Properties.Settings.Default.DiagMaxPointSize, EtHerG.Properties.Settings.Default.DiagMaxPointSize, -EtHerG.Properties.Settings.Default.DiagMaxPointSize, EtHerG.Properties.Settings.Default.DiagMaxPointSize);
            formScatter.Interaction.Disable();
            formScatter.Refresh();

            if (last100XValues.Count > EtHerG.Properties.Settings.Default.ScatterPoints)
            {
                last100XValues.RemoveRange(0, (last100XValues.Count - EtHerG.Properties.Settings.Default.ScatterPoints));
                last100YValues.RemoveRange(0, (last100YValues.Count - EtHerG.Properties.Settings.Default.ScatterPoints));
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
                        Invoke(new Action(() =>
                        {
                            txtFrequencyLastModbusValue.Text = FrequencyModbusVal.ToString();
                            txtFrequencyLast.Text = FrequencyModbusVal.ToString();
                        }));
                        ether.WriteToInstrument(1, 0, "<FREQUENCY>" + FrequencyModbusVal * 1000 + "</FREQUENCY>");
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
                        Invoke(new Action(() =>
                        {
                            txtGainXLastModbusValue.Text = GainXModbusVal.ToString();
                            txtGainXLast.Text = GainXModbusVal.ToString();
                        }));
                        ether.WriteToInstrument(1, 0, "<GAIN_X>" + GainXModbusVal * 10 + "</GAIN_X>");
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
                        Invoke(new Action(() =>
                        {
                            txtGainYLastModbusValue.Text = GainYModbusVal.ToString();
                            txtGainYLast.Text = GainYModbusVal.ToString();
                        }));
                        ether.WriteToInstrument(1, 0, "<GAIN_Y>" + GainYModbusVal * 10 + "</GAIN_Y>");
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
                        Invoke(new Action(() =>
                        {
                            txtPhaseLastModbusValue.Text = PhaseModbusVal.ToString();
                            txtPhaseLast.Text = PhaseModbusVal.ToString();
                        }));
                        ether.WriteToInstrument(1, 0, "<PHASE>" + PhaseModbusVal * 100 + "</PHASE>");
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
                        Invoke(new Action(() =>
                        {
                            txtFilterLPLastModbusValue.Text = FilterLPModbusVal.ToString();
                            txtFilterLPLast.Text = FilterLPModbusVal.ToString();
                        }));
                        ether.WriteToInstrument(1, 0, "<FILTER_LP>" + FilterLPModbusVal * 100 + "</FILTER_LP>");
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
                        Invoke(new Action(() =>
                        {
                            txtFilterHPLastModbusValue.Text = FilterHPModbusVal.ToString();
                            txtFilterHPLast.Text = FilterHPModbusVal.ToString();
                        }));
                        ether.WriteToInstrument(1, 0, "<FILTER_HP>" + FilterHPModbusVal * 1000 + "</FILTER_HP>");
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
            try
            {
                modbusClient = new TcpClient(EtHerG.Properties.Settings.Default.ModbusServerIP, EtHerG.Properties.Settings.Default.ModbusServerPort);
                var factory = new ModbusFactory();
                modbusMaster = factory.CreateMaster(modbusClient);
                ModbusCon = true;
            }
            catch (Exception ex)
            {
                // Log or display a warning that the connection failed
                MessageBox.Show($"Failed to connect to Modbus server: {ex.Message}");
                // Stop trying to connect
                return;
            }
        }

        private void OpenSerialConnection()
        {
            //MessageBox.Show("Text here" + Environment.NewLine + "some other text");
            bool result = ether.OpenSerialConnection(EtHerG.Properties.Settings.Default.ComPort);
            if (result)
            {
                EtherConnected = true;
            }
            else
            {
                MessageBox.Show("Verbindungsaufbau nicht möglich");
            }
            ether.WriteToInstrument(1, 0, "<USB_OUTPUT>0</USB_OUTPUT>");
            System.Threading.Thread.Sleep(100);
            ether.WriteToInstrument(1, 0, "<USB_OUTPUT>7</USB_OUTPUT>");
        }

        private void btnEtherConnect_Click(object sender, EventArgs e)
        {
            OpenSerialConnection();
        }

        private void btnEtherDisconnect_Click(object sender, EventArgs e)
        {
            if (EtherConnected == true) { ether.CloseSerialConnection(); }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == EtHerG.Properties.Settings.Default.Password) { LoggedIn(); }
        }

        private void LoggedIn()
        {

        }

        private void LoggedOut()
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoggedOut();
        }

        private void txtFrequencyUserInput_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFrequencyUserInput.Text) && float.TryParse(txtFrequencyUserInput.Text, out float Value))
            {
                ether.WriteToInstrument(1, 0, "<FREQUENCY>" + Value * 1000 + "</FREQUENCY>");
                txtFrequencyLast.Text = Value.ToString();
                EtHerG.Properties.Settings.Default.Frequency = Value;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtGainXUserInput_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGainXUserInput.Text) && float.TryParse(txtGainXUserInput.Text, out float Value))
            {
                ether.WriteToInstrument(1, 0, "<GAIN_X>" + Value * 10 + "</GAIN_X>");
                txtGainXLast.Text = Value.ToString();
                EtHerG.Properties.Settings.Default.GainX = Value;
                EtHerG.Properties.Settings.Default.Save();
                InfluxDBParameterSave();
            }
        }

        private void txtGainYUserInput_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGainYUserInput.Text) && float.TryParse(txtGainYUserInput.Text, out float Value))
            {
                ether.WriteToInstrument(1, 0, "<GAIN_Y>" + Value * 10 + "</GAIN_Y>");
                txtGainYLast.Text = Value.ToString();
                EtHerG.Properties.Settings.Default.GainY = Value;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtPhaseUserInput_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPhaseUserInput.Text) && float.TryParse(txtPhaseUserInput.Text, out float Value) && Value >= 1 && Value <= 360)
            {
                ether.WriteToInstrument(1, 0, "<PHASE>" + Value * 1000 + "</PHASE>");
                txtPhaseLast.Text = Value.ToString();
                EtHerG.Properties.Settings.Default.Phase = Value;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtFilterLPUserInput_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFilterLPUserInput.Text) && float.TryParse(txtFilterLPUserInput.Text, out float Value))
            {
                ether.WriteToInstrument(1, 0, "<FILTER_LP>" + Value * 100 + "</FILTER_LP>");
                txtFilterLPLast.Text = Value.ToString();
                EtHerG.Properties.Settings.Default.FilterLP = Value;
                EtHerG.Properties.Settings.Default.Save();
            }
        }

        private void txtFilterHPUserInput_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFilterHPUserInput.Text) && float.TryParse(txtFilterHPUserInput.Text, out float Value))
            {
                ether.WriteToInstrument(1, 0, "<FILTER_HP>" + Value * 100 + "</FILTER_HP>");
                txtFilterHPLast.Text = Value.ToString();
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
            if (chkDisableUserInput.Checked == false) { EtHerG.Properties.Settings.Default.DisableUserInput = false; }
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

        private void InfluxDBParameterSave()
        {
            //EtHerG.Properties.Settings.Default.GainX;
            //EtHerG.Properties.Settings.Default.GainY;
            //EtHerG.Properties.Settings.Default.Frequency;
            //EtHerG.Properties.Settings.Default.Phase;
            //EtHerG.Properties.Settings.Default.FilterLP;
            //EtHerG.Properties.Settings.Default.FilterHP;
            //EtHerG.Properties.Settings.Default.Alarm1Value;
            //EtHerG.Properties.Settings.Default.Alarm2Value;
        }
    }
}

//btnEtherConnect.Text = "Ether Verbinden";
//btnEtherDisconnect.Text = "Ether Trennen";
//btnModbusConnect.Text = "Modbus Verbinden";
//btnModbusDisconnect.Text = "Modbus Trennen";