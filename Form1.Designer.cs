namespace EtHerG
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panelSettings = new Panel();
            txtFilterHPLast = new TextBox();
            txtFilterLPLast = new TextBox();
            txtPhaseLast = new TextBox();
            txtGainYLast = new TextBox();
            txtGainXLast = new TextBox();
            txtFrequencyLast = new TextBox();
            lblFilterHP = new Label();
            lblFilterLP = new Label();
            lblPhase = new Label();
            lblGainY = new Label();
            lblGainX = new Label();
            txtFilterHPUserInput = new TextBox();
            txtFilterLPUserInput = new TextBox();
            txtPhaseUserInput = new TextBox();
            txtGainYUserInput = new TextBox();
            txtGainXUserInput = new TextBox();
            txtFrequencyUserInput = new TextBox();
            lblFrequency = new Label();
            panelMain = new Panel();
            txtColorY = new TextBox();
            txtColorX = new TextBox();
            txtModbusStatus = new TextBox();
            txtEtherStatus = new TextBox();
            chkModbusAutoconnect = new CheckBox();
            chkEtherAutoconnect = new CheckBox();
            chkShowY = new CheckBox();
            chkShowX = new CheckBox();
            btnLogout = new Button();
            btnEtherConnect = new Button();
            btnLogin = new Button();
            btnModbusDisconnect = new Button();
            txtPassword = new TextBox();
            btnModbusConnect = new Button();
            lblPassword = new Label();
            btnEtherDisconnect = new Button();
            formLineDiag = new ScottPlot.WinForms.FormsPlot();
            formScatter = new ScottPlot.WinForms.FormsPlot();
            tabPage2 = new TabPage();
            panel1 = new Panel();
            lblInstructions = new Label();
            pictureBox1 = new PictureBox();
            pctrInternationalization = new PictureBox();
            chkScatterDrawPoints = new CheckBox();
            txtScatterDiagColor = new TextBox();
            txtLineDiagColorY = new TextBox();
            txtLineDiagColorX = new TextBox();
            txtAlarm2Color = new TextBox();
            txtAlarm1Color = new TextBox();
            lblScatterColor = new Label();
            lblColorY = new Label();
            lblAlarm2Color = new Label();
            lblColorX = new Label();
            lblAlarm1Color = new Label();
            lblInfluxDBMachineName = new Label();
            txtInfluxDBMachine = new TextBox();
            txtInfluxDBOrg = new TextBox();
            txtInfluxDBBucket = new TextBox();
            txtInfluxDBToken = new TextBox();
            txtInfluxDBServer = new TextBox();
            chkInfluxDBEnabled = new CheckBox();
            lblInfluxDBORGID = new Label();
            lblInfluxDBBucket = new Label();
            lblInfluxDBToken = new Label();
            lblInfluxDBServer = new Label();
            chkModbusLastSentAddressEnabled = new CheckBox();
            txtFilterHPModbusLastSentAddress = new TextBox();
            txtFilterLPModbusLastSentAddress = new TextBox();
            txtPhaseModbusLastSentAddress = new TextBox();
            txtGainYModbusLastSentAddress = new TextBox();
            txtGainXModbusLastSentAddress = new TextBox();
            txtFrequencyModbusLastSentAddress = new TextBox();
            lblModbusLastSentValueAdress = new Label();
            txtAlarm2ModbusAddress = new TextBox();
            txtAlarm1ModbusAddress = new TextBox();
            lblAlarm1ModbusSendAddress = new Label();
            lblAlarm2ModbusSendAddress = new Label();
            chkDisableUserInput = new CheckBox();
            lblModbusReadValue = new Label();
            lblModbusReadAdresses = new Label();
            txtSetPassword = new TextBox();
            btnSetPassword = new Button();
            chkAutologin = new CheckBox();
            lblLineDiagSizeY = new Label();
            lblLineDiagSizeX = new Label();
            lblLineDiagPosY = new Label();
            lblLineDiagPosX = new Label();
            txtLineDiagSizeY = new TextBox();
            txtLineDiagSizeX = new TextBox();
            txtLineDiagPosY = new TextBox();
            txtLineDiagPosX = new TextBox();
            lblScatterDiagSize = new Label();
            lblScatterDiagPosY = new Label();
            txtScatterDiagSize = new TextBox();
            txtScatterDiagPosY = new TextBox();
            txtScatterDiagPosX = new TextBox();
            txtFilterHPLastModbusValue = new TextBox();
            lblScatterDiagPosX = new Label();
            txtFilterLPLastModbusValue = new TextBox();
            txtPhaseLastModbusValue = new TextBox();
            lblScatterAmount = new Label();
            txtGainYLastModbusValue = new TextBox();
            txtScatterPoints = new TextBox();
            txtGainXLastModbusValue = new TextBox();
            lblDiagMaxPointSize = new Label();
            txtFrequencyLastModbusValue = new TextBox();
            lblModbusServerIP = new Label();
            txtDiagMaxPointSize = new TextBox();
            lblModbusServerPort = new Label();
            txtPlayLastModbusValue = new TextBox();
            lblLineDiagAmount = new Label();
            txtFilterHPModbusAddress = new TextBox();
            txtModbusServerIP = new TextBox();
            txtFilterLPModbusAddress = new TextBox();
            txtLineDiagPoints = new TextBox();
            txtPhaseModbusAddress = new TextBox();
            txtModbusServerPort = new TextBox();
            txtGainYModbusAddress = new TextBox();
            txtCOMPort = new TextBox();
            txtGainXModbusAddress = new TextBox();
            lblComport = new Label();
            txtFrequencyModbusAddress = new TextBox();
            txtX = new TextBox();
            txtAlarm2Value = new TextBox();
            txtY = new TextBox();
            txtAlarm1Value = new TextBox();
            txtPS = new TextBox();
            txtPlayModbusAddress = new TextBox();
            lblPS = new Label();
            lblAlarm1 = new Label();
            lblYVal = new Label();
            lblPlay = new Label();
            lblXVal = new Label();
            lblAlarm2 = new Label();
            lblFrequency1 = new Label();
            lblFilterHP1 = new Label();
            lblGainX1 = new Label();
            lblFilterLP1 = new Label();
            lblGainY1 = new Label();
            lblPhase1 = new Label();
            DiagWorker = new System.ComponentModel.BackgroundWorker();
            ModbusWorker = new System.ComponentModel.BackgroundWorker();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panelSettings.SuspendLayout();
            panelMain.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctrInternationalization).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1904, 1041);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panelSettings);
            tabPage1.Controls.Add(panelMain);
            tabPage1.Controls.Add(formLineDiag);
            tabPage1.Controls.Add(formScatter);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(0);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1896, 1013);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Main";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelSettings
            // 
            panelSettings.Controls.Add(txtFilterHPLast);
            panelSettings.Controls.Add(txtFilterLPLast);
            panelSettings.Controls.Add(txtPhaseLast);
            panelSettings.Controls.Add(txtGainYLast);
            panelSettings.Controls.Add(txtGainXLast);
            panelSettings.Controls.Add(txtFrequencyLast);
            panelSettings.Controls.Add(lblFilterHP);
            panelSettings.Controls.Add(lblFilterLP);
            panelSettings.Controls.Add(lblPhase);
            panelSettings.Controls.Add(lblGainY);
            panelSettings.Controls.Add(lblGainX);
            panelSettings.Controls.Add(txtFilterHPUserInput);
            panelSettings.Controls.Add(txtFilterLPUserInput);
            panelSettings.Controls.Add(txtPhaseUserInput);
            panelSettings.Controls.Add(txtGainYUserInput);
            panelSettings.Controls.Add(txtGainXUserInput);
            panelSettings.Controls.Add(txtFrequencyUserInput);
            panelSettings.Controls.Add(lblFrequency);
            panelSettings.Location = new Point(6, 80);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(331, 351);
            panelSettings.TabIndex = 5;
            // 
            // txtFilterHPLast
            // 
            txtFilterHPLast.Location = new Point(207, 157);
            txtFilterHPLast.Name = "txtFilterHPLast";
            txtFilterHPLast.ReadOnly = true;
            txtFilterHPLast.Size = new Size(100, 23);
            txtFilterHPLast.TabIndex = 18;
            // 
            // txtFilterLPLast
            // 
            txtFilterLPLast.Location = new Point(207, 128);
            txtFilterLPLast.Name = "txtFilterLPLast";
            txtFilterLPLast.ReadOnly = true;
            txtFilterLPLast.Size = new Size(100, 23);
            txtFilterLPLast.TabIndex = 17;
            // 
            // txtPhaseLast
            // 
            txtPhaseLast.Location = new Point(207, 99);
            txtPhaseLast.Name = "txtPhaseLast";
            txtPhaseLast.ReadOnly = true;
            txtPhaseLast.Size = new Size(100, 23);
            txtPhaseLast.TabIndex = 16;
            // 
            // txtGainYLast
            // 
            txtGainYLast.Location = new Point(207, 70);
            txtGainYLast.Name = "txtGainYLast";
            txtGainYLast.ReadOnly = true;
            txtGainYLast.Size = new Size(100, 23);
            txtGainYLast.TabIndex = 15;
            // 
            // txtGainXLast
            // 
            txtGainXLast.Location = new Point(207, 41);
            txtGainXLast.Name = "txtGainXLast";
            txtGainXLast.ReadOnly = true;
            txtGainXLast.Size = new Size(100, 23);
            txtGainXLast.TabIndex = 14;
            // 
            // txtFrequencyLast
            // 
            txtFrequencyLast.Location = new Point(207, 12);
            txtFrequencyLast.Name = "txtFrequencyLast";
            txtFrequencyLast.ReadOnly = true;
            txtFrequencyLast.Size = new Size(100, 23);
            txtFrequencyLast.TabIndex = 13;
            // 
            // lblFilterHP
            // 
            lblFilterHP.Location = new Point(8, 165);
            lblFilterHP.Name = "lblFilterHP";
            lblFilterHP.Size = new Size(95, 15);
            lblFilterHP.TabIndex = 12;
            lblFilterHP.Text = "Filter HP:";
            lblFilterHP.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFilterLP
            // 
            lblFilterLP.Location = new Point(8, 136);
            lblFilterLP.Name = "lblFilterLP";
            lblFilterLP.Size = new Size(95, 15);
            lblFilterLP.TabIndex = 11;
            lblFilterLP.Text = "Filter LP:";
            lblFilterLP.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPhase
            // 
            lblPhase.Location = new Point(8, 107);
            lblPhase.Name = "lblPhase";
            lblPhase.Size = new Size(95, 15);
            lblPhase.TabIndex = 9;
            lblPhase.Text = "Phase:";
            lblPhase.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGainY
            // 
            lblGainY.Location = new Point(8, 76);
            lblGainY.Name = "lblGainY";
            lblGainY.Size = new Size(95, 15);
            lblGainY.TabIndex = 8;
            lblGainY.Text = "Gain Y:";
            lblGainY.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGainX
            // 
            lblGainX.Location = new Point(8, 47);
            lblGainX.Name = "lblGainX";
            lblGainX.Size = new Size(95, 15);
            lblGainX.TabIndex = 7;
            lblGainX.Text = "Gain X:";
            lblGainX.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtFilterHPUserInput
            // 
            txtFilterHPUserInput.Location = new Point(101, 157);
            txtFilterHPUserInput.Name = "txtFilterHPUserInput";
            txtFilterHPUserInput.Size = new Size(101, 23);
            txtFilterHPUserInput.TabIndex = 6;
            txtFilterHPUserInput.LostFocus += txtFilterHPUserInput_LostFocus;
            txtFilterHPUserInput.MouseWheel += txtFilterHPUserInput_MouseWheel;
            // 
            // txtFilterLPUserInput
            // 
            txtFilterLPUserInput.Location = new Point(101, 128);
            txtFilterLPUserInput.Name = "txtFilterLPUserInput";
            txtFilterLPUserInput.Size = new Size(101, 23);
            txtFilterLPUserInput.TabIndex = 5;
            txtFilterLPUserInput.LostFocus += txtFilterLPUserInput_LostFocus;
            txtFilterLPUserInput.MouseWheel += txtFilterLPUserInput_MouseWheel;
            // 
            // txtPhaseUserInput
            // 
            txtPhaseUserInput.Location = new Point(101, 99);
            txtPhaseUserInput.Name = "txtPhaseUserInput";
            txtPhaseUserInput.Size = new Size(101, 23);
            txtPhaseUserInput.TabIndex = 4;
            txtPhaseUserInput.LostFocus += txtPhaseUserInput_LostFocus;
            txtPhaseUserInput.MouseWheel += txtPhaseUserInput_MouseWheel;
            // 
            // txtGainYUserInput
            // 
            txtGainYUserInput.Location = new Point(101, 70);
            txtGainYUserInput.Name = "txtGainYUserInput";
            txtGainYUserInput.Size = new Size(101, 23);
            txtGainYUserInput.TabIndex = 3;
            txtGainYUserInput.LostFocus += txtGainYUserInput_LostFocus;
            txtGainYUserInput.MouseWheel += txtGainYUserInput_MouseWheel;
            // 
            // txtGainXUserInput
            // 
            txtGainXUserInput.Location = new Point(101, 41);
            txtGainXUserInput.Name = "txtGainXUserInput";
            txtGainXUserInput.Size = new Size(101, 23);
            txtGainXUserInput.TabIndex = 2;
            txtGainXUserInput.LostFocus += txtGainXUserInput_LostFocus;
            txtGainXUserInput.MouseWheel += txtGainXUserInput_MouseWheel;
            // 
            // txtFrequencyUserInput
            // 
            txtFrequencyUserInput.Location = new Point(101, 12);
            txtFrequencyUserInput.Name = "txtFrequencyUserInput";
            txtFrequencyUserInput.Size = new Size(100, 23);
            txtFrequencyUserInput.TabIndex = 1;
            txtFrequencyUserInput.LostFocus += txtFrequencyUserInput_LostFocus;
            txtFrequencyUserInput.MouseWheel += txtFrequencyUserInput_MouseWheel;
            // 
            // lblFrequency
            // 
            lblFrequency.Location = new Point(8, 15);
            lblFrequency.Name = "lblFrequency";
            lblFrequency.Size = new Size(95, 15);
            lblFrequency.TabIndex = 0;
            lblFrequency.Text = "Frequency:";
            lblFrequency.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(txtColorY);
            panelMain.Controls.Add(txtColorX);
            panelMain.Controls.Add(txtModbusStatus);
            panelMain.Controls.Add(txtEtherStatus);
            panelMain.Controls.Add(chkModbusAutoconnect);
            panelMain.Controls.Add(chkEtherAutoconnect);
            panelMain.Controls.Add(chkShowY);
            panelMain.Controls.Add(chkShowX);
            panelMain.Controls.Add(btnLogout);
            panelMain.Controls.Add(btnEtherConnect);
            panelMain.Controls.Add(btnLogin);
            panelMain.Controls.Add(btnModbusDisconnect);
            panelMain.Controls.Add(txtPassword);
            panelMain.Controls.Add(btnModbusConnect);
            panelMain.Controls.Add(lblPassword);
            panelMain.Controls.Add(btnEtherDisconnect);
            panelMain.Dock = DockStyle.Top;
            panelMain.Location = new Point(3, 3);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1890, 71);
            panelMain.TabIndex = 2;
            // 
            // txtColorY
            // 
            txtColorY.Location = new Point(691, 35);
            txtColorY.Name = "txtColorY";
            txtColorY.ReadOnly = true;
            txtColorY.Size = new Size(22, 23);
            txtColorY.TabIndex = 13;
            // 
            // txtColorX
            // 
            txtColorX.Location = new Point(691, 11);
            txtColorX.Name = "txtColorX";
            txtColorX.ReadOnly = true;
            txtColorX.Size = new Size(22, 23);
            txtColorX.TabIndex = 6;
            // 
            // txtModbusStatus
            // 
            txtModbusStatus.BackColor = Color.Red;
            txtModbusStatus.ForeColor = Color.Black;
            txtModbusStatus.Location = new Point(944, 35);
            txtModbusStatus.Name = "txtModbusStatus";
            txtModbusStatus.ReadOnly = true;
            txtModbusStatus.Size = new Size(100, 23);
            txtModbusStatus.TabIndex = 12;
            txtModbusStatus.Text = "MODBUS";
            txtModbusStatus.TextAlign = HorizontalAlignment.Center;
            // 
            // txtEtherStatus
            // 
            txtEtherStatus.BackColor = Color.Red;
            txtEtherStatus.Location = new Point(944, 11);
            txtEtherStatus.Name = "txtEtherStatus";
            txtEtherStatus.ReadOnly = true;
            txtEtherStatus.Size = new Size(100, 23);
            txtEtherStatus.TabIndex = 11;
            txtEtherStatus.Text = "ETHER";
            txtEtherStatus.TextAlign = HorizontalAlignment.Center;
            // 
            // chkModbusAutoconnect
            // 
            chkModbusAutoconnect.AutoSize = true;
            chkModbusAutoconnect.Location = new Point(796, 37);
            chkModbusAutoconnect.Name = "chkModbusAutoconnect";
            chkModbusAutoconnect.Size = new Size(142, 19);
            chkModbusAutoconnect.TabIndex = 10;
            chkModbusAutoconnect.Text = "Modbus Autoconnect";
            chkModbusAutoconnect.UseVisualStyleBackColor = true;
            chkModbusAutoconnect.CheckedChanged += chkModbusAutoconnect_CheckedChanged;
            // 
            // chkEtherAutoconnect
            // 
            chkEtherAutoconnect.AutoSize = true;
            chkEtherAutoconnect.Location = new Point(796, 15);
            chkEtherAutoconnect.Name = "chkEtherAutoconnect";
            chkEtherAutoconnect.Size = new Size(125, 19);
            chkEtherAutoconnect.TabIndex = 9;
            chkEtherAutoconnect.Text = "Ether Autoconnect";
            chkEtherAutoconnect.UseVisualStyleBackColor = true;
            chkEtherAutoconnect.CheckedChanged += chkEtherAutoconnect_CheckedChanged;
            // 
            // chkShowY
            // 
            chkShowY.AutoSize = true;
            chkShowY.Location = new Point(719, 37);
            chkShowY.Name = "chkShowY";
            chkShowY.Size = new Size(71, 19);
            chkShowY.TabIndex = 8;
            chkShowY.Text = "Y-Values";
            chkShowY.UseVisualStyleBackColor = true;
            chkShowY.CheckedChanged += chkShowY_CheckedChanged;
            // 
            // chkShowX
            // 
            chkShowX.AutoSize = true;
            chkShowX.BackColor = Color.Transparent;
            chkShowX.Location = new Point(719, 15);
            chkShowX.Name = "chkShowX";
            chkShowX.Size = new Size(71, 19);
            chkShowX.TabIndex = 7;
            chkShowX.Text = "X-Values";
            chkShowX.UseVisualStyleBackColor = false;
            chkShowX.CheckedChanged += chkShowX_CheckedChanged;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(594, 15);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(79, 41);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnEtherConnect
            // 
            btnEtherConnect.Location = new Point(3, 15);
            btnEtherConnect.Name = "btnEtherConnect";
            btnEtherConnect.Size = new Size(79, 41);
            btnEtherConnect.TabIndex = 0;
            btnEtherConnect.Text = "Ether Connect";
            btnEtherConnect.UseVisualStyleBackColor = true;
            btnEtherConnect.Click += btnEtherConnect_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(509, 15);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(79, 41);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnModbusDisconnect
            // 
            btnModbusDisconnect.Location = new Point(258, 15);
            btnModbusDisconnect.Name = "btnModbusDisconnect";
            btnModbusDisconnect.Size = new Size(79, 41);
            btnModbusDisconnect.TabIndex = 1;
            btnModbusDisconnect.Text = "Modbus Disconnect";
            btnModbusDisconnect.UseVisualStyleBackColor = true;
            btnModbusDisconnect.Click += btnModbusDisconnect_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(403, 23);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnModbusConnect
            // 
            btnModbusConnect.Location = new Point(173, 15);
            btnModbusConnect.Name = "btnModbusConnect";
            btnModbusConnect.Size = new Size(79, 41);
            btnModbusConnect.TabIndex = 2;
            btnModbusConnect.Text = "Modbus Connect";
            btnModbusConnect.UseVisualStyleBackColor = true;
            btnModbusConnect.Click += btnModbusConnect_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(340, 25);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(63, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password: ";
            // 
            // btnEtherDisconnect
            // 
            btnEtherDisconnect.Location = new Point(88, 15);
            btnEtherDisconnect.Name = "btnEtherDisconnect";
            btnEtherDisconnect.Size = new Size(79, 41);
            btnEtherDisconnect.TabIndex = 3;
            btnEtherDisconnect.Text = "Ether Disconnect";
            btnEtherDisconnect.UseVisualStyleBackColor = true;
            btnEtherDisconnect.Click += btnEtherDisconnect_Click;
            // 
            // formLineDiag
            // 
            formLineDiag.AccessibleRole = AccessibleRole.None;
            formLineDiag.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formLineDiag.AutoValidate = AutoValidate.EnableAllowFocusChange;
            formLineDiag.DisplayScale = 1F;
            formLineDiag.Location = new Point(0, 698);
            formLineDiag.Name = "formLineDiag";
            formLineDiag.Size = new Size(1896, 315);
            formLineDiag.TabIndex = 3;
            // 
            // formScatter
            // 
            formScatter.DisplayScale = 1F;
            formScatter.Location = new Point(343, 80);
            formScatter.Name = "formScatter";
            formScatter.Size = new Size(400, 400);
            formScatter.TabIndex = 4;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1896, 1013);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblInstructions);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(pctrInternationalization);
            panel1.Controls.Add(chkScatterDrawPoints);
            panel1.Controls.Add(txtScatterDiagColor);
            panel1.Controls.Add(txtLineDiagColorY);
            panel1.Controls.Add(txtLineDiagColorX);
            panel1.Controls.Add(txtAlarm2Color);
            panel1.Controls.Add(txtAlarm1Color);
            panel1.Controls.Add(lblScatterColor);
            panel1.Controls.Add(lblColorY);
            panel1.Controls.Add(lblAlarm2Color);
            panel1.Controls.Add(lblColorX);
            panel1.Controls.Add(lblAlarm1Color);
            panel1.Controls.Add(lblInfluxDBMachineName);
            panel1.Controls.Add(txtInfluxDBMachine);
            panel1.Controls.Add(txtInfluxDBOrg);
            panel1.Controls.Add(txtInfluxDBBucket);
            panel1.Controls.Add(txtInfluxDBToken);
            panel1.Controls.Add(txtInfluxDBServer);
            panel1.Controls.Add(chkInfluxDBEnabled);
            panel1.Controls.Add(lblInfluxDBORGID);
            panel1.Controls.Add(lblInfluxDBBucket);
            panel1.Controls.Add(lblInfluxDBToken);
            panel1.Controls.Add(lblInfluxDBServer);
            panel1.Controls.Add(chkModbusLastSentAddressEnabled);
            panel1.Controls.Add(txtFilterHPModbusLastSentAddress);
            panel1.Controls.Add(txtFilterLPModbusLastSentAddress);
            panel1.Controls.Add(txtPhaseModbusLastSentAddress);
            panel1.Controls.Add(txtGainYModbusLastSentAddress);
            panel1.Controls.Add(txtGainXModbusLastSentAddress);
            panel1.Controls.Add(txtFrequencyModbusLastSentAddress);
            panel1.Controls.Add(lblModbusLastSentValueAdress);
            panel1.Controls.Add(txtAlarm2ModbusAddress);
            panel1.Controls.Add(txtAlarm1ModbusAddress);
            panel1.Controls.Add(lblAlarm1ModbusSendAddress);
            panel1.Controls.Add(lblAlarm2ModbusSendAddress);
            panel1.Controls.Add(chkDisableUserInput);
            panel1.Controls.Add(lblModbusReadValue);
            panel1.Controls.Add(lblModbusReadAdresses);
            panel1.Controls.Add(txtSetPassword);
            panel1.Controls.Add(btnSetPassword);
            panel1.Controls.Add(chkAutologin);
            panel1.Controls.Add(lblLineDiagSizeY);
            panel1.Controls.Add(lblLineDiagSizeX);
            panel1.Controls.Add(lblLineDiagPosY);
            panel1.Controls.Add(lblLineDiagPosX);
            panel1.Controls.Add(txtLineDiagSizeY);
            panel1.Controls.Add(txtLineDiagSizeX);
            panel1.Controls.Add(txtLineDiagPosY);
            panel1.Controls.Add(txtLineDiagPosX);
            panel1.Controls.Add(lblScatterDiagSize);
            panel1.Controls.Add(lblScatterDiagPosY);
            panel1.Controls.Add(txtScatterDiagSize);
            panel1.Controls.Add(txtScatterDiagPosY);
            panel1.Controls.Add(txtScatterDiagPosX);
            panel1.Controls.Add(txtFilterHPLastModbusValue);
            panel1.Controls.Add(lblScatterDiagPosX);
            panel1.Controls.Add(txtFilterLPLastModbusValue);
            panel1.Controls.Add(txtPhaseLastModbusValue);
            panel1.Controls.Add(lblScatterAmount);
            panel1.Controls.Add(txtGainYLastModbusValue);
            panel1.Controls.Add(txtScatterPoints);
            panel1.Controls.Add(txtGainXLastModbusValue);
            panel1.Controls.Add(lblDiagMaxPointSize);
            panel1.Controls.Add(txtFrequencyLastModbusValue);
            panel1.Controls.Add(lblModbusServerIP);
            panel1.Controls.Add(txtDiagMaxPointSize);
            panel1.Controls.Add(lblModbusServerPort);
            panel1.Controls.Add(txtPlayLastModbusValue);
            panel1.Controls.Add(lblLineDiagAmount);
            panel1.Controls.Add(txtFilterHPModbusAddress);
            panel1.Controls.Add(txtModbusServerIP);
            panel1.Controls.Add(txtFilterLPModbusAddress);
            panel1.Controls.Add(txtLineDiagPoints);
            panel1.Controls.Add(txtPhaseModbusAddress);
            panel1.Controls.Add(txtModbusServerPort);
            panel1.Controls.Add(txtGainYModbusAddress);
            panel1.Controls.Add(txtCOMPort);
            panel1.Controls.Add(txtGainXModbusAddress);
            panel1.Controls.Add(lblComport);
            panel1.Controls.Add(txtFrequencyModbusAddress);
            panel1.Controls.Add(txtX);
            panel1.Controls.Add(txtAlarm2Value);
            panel1.Controls.Add(txtY);
            panel1.Controls.Add(txtAlarm1Value);
            panel1.Controls.Add(txtPS);
            panel1.Controls.Add(txtPlayModbusAddress);
            panel1.Controls.Add(lblPS);
            panel1.Controls.Add(lblAlarm1);
            panel1.Controls.Add(lblYVal);
            panel1.Controls.Add(lblPlay);
            panel1.Controls.Add(lblXVal);
            panel1.Controls.Add(lblAlarm2);
            panel1.Controls.Add(lblFrequency1);
            panel1.Controls.Add(lblFilterHP1);
            panel1.Controls.Add(lblGainX1);
            panel1.Controls.Add(lblFilterLP1);
            panel1.Controls.Add(lblGainY1);
            panel1.Controls.Add(lblPhase1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1890, 1007);
            panel1.TabIndex = 54;
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Location = new Point(363, 653);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(423, 45);
            lblInstructions.TabIndex = 109;
            lblInstructions.Text = "1. Connect Ether and Modbus\r\n2. Set Values for all parameters (perhaps excluding influx and modbus last sent)\r\n3. Set the Play Coil in the PLC to True (atleast for testing)\r\n";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Kartes_;
            pictureBox1.Location = new Point(5, 73);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 108;
            pictureBox1.TabStop = false;
            // 
            // pctrInternationalization
            // 
            pctrInternationalization.Image = Properties.Resources.PL;
            pctrInternationalization.Location = new Point(5, 3);
            pctrInternationalization.Name = "pctrInternationalization";
            pctrInternationalization.Size = new Size(84, 64);
            pctrInternationalization.SizeMode = PictureBoxSizeMode.StretchImage;
            pctrInternationalization.TabIndex = 107;
            pctrInternationalization.TabStop = false;
            pctrInternationalization.Click += pctrInternationalization_Click;
            // 
            // chkScatterDrawPoints
            // 
            chkScatterDrawPoints.AutoSize = true;
            chkScatterDrawPoints.Location = new Point(191, 728);
            chkScatterDrawPoints.Name = "chkScatterDrawPoints";
            chkScatterDrawPoints.Size = new Size(133, 19);
            chkScatterDrawPoints.TabIndex = 106;
            chkScatterDrawPoints.Text = "Scatter Draw Points?";
            chkScatterDrawPoints.UseVisualStyleBackColor = true;
            chkScatterDrawPoints.CheckedChanged += chkScatterDrawPoints_CheckedChanged;
            // 
            // txtScatterDiagColor
            // 
            txtScatterDiagColor.Location = new Point(225, 699);
            txtScatterDiagColor.Name = "txtScatterDiagColor";
            txtScatterDiagColor.Size = new Size(100, 23);
            txtScatterDiagColor.TabIndex = 105;
            txtScatterDiagColor.LostFocus += txtScatterDiagColor_LostFocus;
            // 
            // txtLineDiagColorY
            // 
            txtLineDiagColorY.Location = new Point(225, 670);
            txtLineDiagColorY.Name = "txtLineDiagColorY";
            txtLineDiagColorY.Size = new Size(100, 23);
            txtLineDiagColorY.TabIndex = 104;
            txtLineDiagColorY.LostFocus += txtLineDiagYColor_LostFocus;
            // 
            // txtLineDiagColorX
            // 
            txtLineDiagColorX.Location = new Point(225, 645);
            txtLineDiagColorX.Name = "txtLineDiagColorX";
            txtLineDiagColorX.Size = new Size(100, 23);
            txtLineDiagColorX.TabIndex = 103;
            txtLineDiagColorX.LostFocus += txtLineDiagColorX_LostFocus;
            // 
            // txtAlarm2Color
            // 
            txtAlarm2Color.Location = new Point(224, 613);
            txtAlarm2Color.Name = "txtAlarm2Color";
            txtAlarm2Color.Size = new Size(100, 23);
            txtAlarm2Color.TabIndex = 102;
            txtAlarm2Color.LostFocus += txtAlarm2Color_LostFocus;
            // 
            // txtAlarm1Color
            // 
            txtAlarm1Color.Location = new Point(224, 584);
            txtAlarm1Color.Name = "txtAlarm1Color";
            txtAlarm1Color.Size = new Size(100, 23);
            txtAlarm1Color.TabIndex = 101;
            txtAlarm1Color.LostFocus += txtAlarm1Color_LostFocus;
            // 
            // lblScatterColor
            // 
            lblScatterColor.Location = new Point(23, 702);
            lblScatterColor.Name = "lblScatterColor";
            lblScatterColor.Size = new Size(200, 15);
            lblScatterColor.TabIndex = 100;
            lblScatterColor.Text = "Scatter Color:";
            lblScatterColor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblColorY
            // 
            lblColorY.Location = new Point(19, 673);
            lblColorY.Name = "lblColorY";
            lblColorY.Size = new Size(200, 15);
            lblColorY.TabIndex = 98;
            lblColorY.Text = "Y Color:";
            lblColorY.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAlarm2Color
            // 
            lblAlarm2Color.Location = new Point(19, 616);
            lblAlarm2Color.Name = "lblAlarm2Color";
            lblAlarm2Color.Size = new Size(200, 15);
            lblAlarm2Color.TabIndex = 97;
            lblAlarm2Color.Text = "Alarm 2 Color:";
            lblAlarm2Color.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblColorX
            // 
            lblColorX.Location = new Point(21, 648);
            lblColorX.Name = "lblColorX";
            lblColorX.Size = new Size(200, 15);
            lblColorX.TabIndex = 96;
            lblColorX.Text = "X Color:";
            lblColorX.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAlarm1Color
            // 
            lblAlarm1Color.Location = new Point(19, 587);
            lblAlarm1Color.Name = "lblAlarm1Color";
            lblAlarm1Color.Size = new Size(200, 15);
            lblAlarm1Color.TabIndex = 96;
            lblAlarm1Color.Text = "Alarm 1 Color:";
            lblAlarm1Color.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblInfluxDBMachineName
            // 
            lblInfluxDBMachineName.AutoSize = true;
            lblInfluxDBMachineName.Location = new Point(355, 616);
            lblInfluxDBMachineName.Name = "lblInfluxDBMachineName";
            lblInfluxDBMachineName.Size = new Size(130, 15);
            lblInfluxDBMachineName.TabIndex = 95;
            lblInfluxDBMachineName.Text = "InfluxDBMachineName";
            // 
            // txtInfluxDBMachine
            // 
            txtInfluxDBMachine.Location = new Point(491, 613);
            txtInfluxDBMachine.Name = "txtInfluxDBMachine";
            txtInfluxDBMachine.Size = new Size(100, 23);
            txtInfluxDBMachine.TabIndex = 94;
            txtInfluxDBMachine.LostFocus += txtInfluxDBMachine_LostFocus;
            // 
            // txtInfluxDBOrg
            // 
            txtInfluxDBOrg.Location = new Point(491, 584);
            txtInfluxDBOrg.Name = "txtInfluxDBOrg";
            txtInfluxDBOrg.Size = new Size(100, 23);
            txtInfluxDBOrg.TabIndex = 93;
            txtInfluxDBOrg.LostFocus += txtInfluxDBOrg_LostFocus;
            // 
            // txtInfluxDBBucket
            // 
            txtInfluxDBBucket.Location = new Point(491, 554);
            txtInfluxDBBucket.Name = "txtInfluxDBBucket";
            txtInfluxDBBucket.Size = new Size(100, 23);
            txtInfluxDBBucket.TabIndex = 92;
            txtInfluxDBBucket.LostFocus += txtInfluxDBBucket_LostFocus;
            // 
            // txtInfluxDBToken
            // 
            txtInfluxDBToken.Location = new Point(491, 519);
            txtInfluxDBToken.Name = "txtInfluxDBToken";
            txtInfluxDBToken.Size = new Size(100, 23);
            txtInfluxDBToken.TabIndex = 91;
            txtInfluxDBToken.LostFocus += txtInfluxDBToken_LostFocus;
            // 
            // txtInfluxDBServer
            // 
            txtInfluxDBServer.Location = new Point(491, 491);
            txtInfluxDBServer.Name = "txtInfluxDBServer";
            txtInfluxDBServer.Size = new Size(100, 23);
            txtInfluxDBServer.TabIndex = 90;
            txtInfluxDBServer.LostFocus += txtInfluxDBServer_LostFocus;
            // 
            // chkInfluxDBEnabled
            // 
            chkInfluxDBEnabled.AutoSize = true;
            chkInfluxDBEnabled.Location = new Point(397, 467);
            chkInfluxDBEnabled.Name = "chkInfluxDBEnabled";
            chkInfluxDBEnabled.Size = new Size(116, 19);
            chkInfluxDBEnabled.TabIndex = 89;
            chkInfluxDBEnabled.Text = "InfluxDB Enabled";
            chkInfluxDBEnabled.UseVisualStyleBackColor = true;
            chkInfluxDBEnabled.CheckedChanged += chkInfluxDBEnabled_CheckedChanged;
            // 
            // lblInfluxDBORGID
            // 
            lblInfluxDBORGID.AutoSize = true;
            lblInfluxDBORGID.Location = new Point(392, 584);
            lblInfluxDBORGID.Name = "lblInfluxDBORGID";
            lblInfluxDBORGID.Size = new Size(91, 15);
            lblInfluxDBORGID.TabIndex = 88;
            lblInfluxDBORGID.Text = "InfluxDB Org-ID";
            // 
            // lblInfluxDBBucket
            // 
            lblInfluxDBBucket.AutoSize = true;
            lblInfluxDBBucket.Location = new Point(389, 557);
            lblInfluxDBBucket.Name = "lblInfluxDBBucket";
            lblInfluxDBBucket.Size = new Size(91, 15);
            lblInfluxDBBucket.TabIndex = 87;
            lblInfluxDBBucket.Text = "InfluxDB Bucket";
            // 
            // lblInfluxDBToken
            // 
            lblInfluxDBToken.AutoSize = true;
            lblInfluxDBToken.Location = new Point(401, 527);
            lblInfluxDBToken.Name = "lblInfluxDBToken";
            lblInfluxDBToken.Size = new Size(82, 15);
            lblInfluxDBToken.TabIndex = 86;
            lblInfluxDBToken.Text = "InfluxDBToken";
            // 
            // lblInfluxDBServer
            // 
            lblInfluxDBServer.AutoSize = true;
            lblInfluxDBServer.Location = new Point(401, 499);
            lblInfluxDBServer.Name = "lblInfluxDBServer";
            lblInfluxDBServer.Size = new Size(84, 15);
            lblInfluxDBServer.TabIndex = 85;
            lblInfluxDBServer.Text = "InfluxDBServer";
            // 
            // chkModbusLastSentAddressEnabled
            // 
            chkModbusLastSentAddressEnabled.AutoSize = true;
            chkModbusLastSentAddressEnabled.Location = new Point(661, 198);
            chkModbusLastSentAddressEnabled.Name = "chkModbusLastSentAddressEnabled";
            chkModbusLastSentAddressEnabled.Size = new Size(201, 19);
            chkModbusLastSentAddressEnabled.TabIndex = 84;
            chkModbusLastSentAddressEnabled.Text = "Modbus Last Sent Value Enabled?";
            chkModbusLastSentAddressEnabled.UseVisualStyleBackColor = true;
            chkModbusLastSentAddressEnabled.CheckedChanged += chkModbusLastSentEnabled_CheckedChanged;
            // 
            // txtFilterHPModbusLastSentAddress
            // 
            txtFilterHPModbusLastSentAddress.Location = new Point(661, 373);
            txtFilterHPModbusLastSentAddress.Name = "txtFilterHPModbusLastSentAddress";
            txtFilterHPModbusLastSentAddress.Size = new Size(100, 23);
            txtFilterHPModbusLastSentAddress.TabIndex = 83;
            txtFilterHPModbusLastSentAddress.LostFocus += txtFilterHPModbusLastSentAddress_LostFocus;
            // 
            // txtFilterLPModbusLastSentAddress
            // 
            txtFilterLPModbusLastSentAddress.Location = new Point(661, 344);
            txtFilterLPModbusLastSentAddress.Name = "txtFilterLPModbusLastSentAddress";
            txtFilterLPModbusLastSentAddress.Size = new Size(100, 23);
            txtFilterLPModbusLastSentAddress.TabIndex = 82;
            txtFilterLPModbusLastSentAddress.LostFocus += txtFilterLPModbusLastSentAddress_LostFocus;
            // 
            // txtPhaseModbusLastSentAddress
            // 
            txtPhaseModbusLastSentAddress.Location = new Point(661, 315);
            txtPhaseModbusLastSentAddress.Name = "txtPhaseModbusLastSentAddress";
            txtPhaseModbusLastSentAddress.Size = new Size(100, 23);
            txtPhaseModbusLastSentAddress.TabIndex = 81;
            txtPhaseModbusLastSentAddress.LostFocus += txtPhaseModbusLastSentAddress_LostFocus;
            // 
            // txtGainYModbusLastSentAddress
            // 
            txtGainYModbusLastSentAddress.Location = new Point(661, 289);
            txtGainYModbusLastSentAddress.Name = "txtGainYModbusLastSentAddress";
            txtGainYModbusLastSentAddress.Size = new Size(100, 23);
            txtGainYModbusLastSentAddress.TabIndex = 80;
            txtGainYModbusLastSentAddress.LostFocus += txtGainYModbusLastSentAddress_LostFocus;
            // 
            // txtGainXModbusLastSentAddress
            // 
            txtGainXModbusLastSentAddress.Location = new Point(661, 259);
            txtGainXModbusLastSentAddress.Name = "txtGainXModbusLastSentAddress";
            txtGainXModbusLastSentAddress.Size = new Size(100, 23);
            txtGainXModbusLastSentAddress.TabIndex = 79;
            txtGainXModbusLastSentAddress.LostFocus += txtGainXModbusLastSentAddress_LostFocus;
            // 
            // txtFrequencyModbusLastSentAddress
            // 
            txtFrequencyModbusLastSentAddress.Location = new Point(661, 227);
            txtFrequencyModbusLastSentAddress.Name = "txtFrequencyModbusLastSentAddress";
            txtFrequencyModbusLastSentAddress.Size = new Size(100, 23);
            txtFrequencyModbusLastSentAddress.TabIndex = 78;
            txtFrequencyModbusLastSentAddress.LostFocus += txtFrequencyModbusLastSentAddress_LostFocus;
            // 
            // lblModbusLastSentValueAdress
            // 
            lblModbusLastSentValueAdress.AutoSize = true;
            lblModbusLastSentValueAdress.Location = new Point(661, 176);
            lblModbusLastSentValueAdress.Name = "lblModbusLastSentValueAdress";
            lblModbusLastSentValueAdress.Size = new Size(133, 15);
            lblModbusLastSentValueAdress.TabIndex = 77;
            lblModbusLastSentValueAdress.Text = "Last Sent Value Address:";
            // 
            // txtAlarm2ModbusAddress
            // 
            txtAlarm2ModbusAddress.Location = new Point(431, 438);
            txtAlarm2ModbusAddress.Name = "txtAlarm2ModbusAddress";
            txtAlarm2ModbusAddress.Size = new Size(100, 23);
            txtAlarm2ModbusAddress.TabIndex = 76;
            txtAlarm2ModbusAddress.LostFocus += txtAlarm2ModbusAddress_LostFocus;
            // 
            // txtAlarm1ModbusAddress
            // 
            txtAlarm1ModbusAddress.Location = new Point(430, 404);
            txtAlarm1ModbusAddress.Name = "txtAlarm1ModbusAddress";
            txtAlarm1ModbusAddress.Size = new Size(100, 23);
            txtAlarm1ModbusAddress.TabIndex = 75;
            txtAlarm1ModbusAddress.LostFocus += txtAlarm1ModbusAddress_LostFocus;
            // 
            // lblAlarm1ModbusSendAddress
            // 
            lblAlarm1ModbusSendAddress.AutoSize = true;
            lblAlarm1ModbusSendAddress.Location = new Point(374, 407);
            lblAlarm1ModbusSendAddress.Name = "lblAlarm1ModbusSendAddress";
            lblAlarm1ModbusSendAddress.Size = new Size(51, 15);
            lblAlarm1ModbusSendAddress.TabIndex = 74;
            lblAlarm1ModbusSendAddress.Text = "Alarm 1:";
            // 
            // lblAlarm2ModbusSendAddress
            // 
            lblAlarm2ModbusSendAddress.AutoSize = true;
            lblAlarm2ModbusSendAddress.Location = new Point(374, 438);
            lblAlarm2ModbusSendAddress.Name = "lblAlarm2ModbusSendAddress";
            lblAlarm2ModbusSendAddress.Size = new Size(51, 15);
            lblAlarm2ModbusSendAddress.TabIndex = 73;
            lblAlarm2ModbusSendAddress.Text = "Alarm 2:";
            // 
            // chkDisableUserInput
            // 
            chkDisableUserInput.AutoSize = true;
            chkDisableUserInput.Location = new Point(430, 55);
            chkDisableUserInput.Name = "chkDisableUserInput";
            chkDisableUserInput.Size = new Size(121, 19);
            chkDisableUserInput.TabIndex = 72;
            chkDisableUserInput.Text = "Disable User Input";
            chkDisableUserInput.UseVisualStyleBackColor = true;
            chkDisableUserInput.CheckedChanged += chkDisableUserInput_CheckedChanged;
            // 
            // lblModbusReadValue
            // 
            lblModbusReadValue.AutoSize = true;
            lblModbusReadValue.Location = new Point(550, 176);
            lblModbusReadValue.Name = "lblModbusReadValue";
            lblModbusReadValue.Size = new Size(105, 15);
            lblModbusReadValue.TabIndex = 70;
            lblModbusReadValue.Text = "ModbusReadValue";
            // 
            // lblModbusReadAdresses
            // 
            lblModbusReadAdresses.AutoSize = true;
            lblModbusReadAdresses.Location = new Point(416, 174);
            lblModbusReadAdresses.Name = "lblModbusReadAdresses";
            lblModbusReadAdresses.Size = new Size(129, 15);
            lblModbusReadAdresses.TabIndex = 69;
            lblModbusReadAdresses.Text = "Modbus Read Adresses";
            // 
            // txtSetPassword
            // 
            txtSetPassword.Location = new Point(224, 82);
            txtSetPassword.Name = "txtSetPassword";
            txtSetPassword.Size = new Size(100, 23);
            txtSetPassword.TabIndex = 68;
            // 
            // btnSetPassword
            // 
            btnSetPassword.Location = new Point(144, 57);
            btnSetPassword.Name = "btnSetPassword";
            btnSetPassword.Size = new Size(75, 48);
            btnSetPassword.TabIndex = 67;
            btnSetPassword.Text = "Set Password";
            btnSetPassword.UseVisualStyleBackColor = true;
            btnSetPassword.Click += btnSetPassword_Click;
            // 
            // chkAutologin
            // 
            chkAutologin.AutoSize = true;
            chkAutologin.Location = new Point(234, 59);
            chkAutologin.Name = "chkAutologin";
            chkAutologin.Size = new Size(79, 19);
            chkAutologin.TabIndex = 66;
            chkAutologin.Text = "Autologin";
            chkAutologin.UseVisualStyleBackColor = true;
            // 
            // lblLineDiagSizeY
            // 
            lblLineDiagSizeY.Location = new Point(23, 557);
            lblLineDiagSizeY.Name = "lblLineDiagSizeY";
            lblLineDiagSizeY.Size = new Size(200, 15);
            lblLineDiagSizeY.TabIndex = 65;
            lblLineDiagSizeY.Text = "Line Diag. Size Y:";
            lblLineDiagSizeY.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLineDiagSizeX
            // 
            lblLineDiagSizeX.Location = new Point(23, 528);
            lblLineDiagSizeX.Name = "lblLineDiagSizeX";
            lblLineDiagSizeX.Size = new Size(200, 15);
            lblLineDiagSizeX.TabIndex = 64;
            lblLineDiagSizeX.Text = "Line Diag. Size X:";
            lblLineDiagSizeX.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLineDiagPosY
            // 
            lblLineDiagPosY.Location = new Point(23, 504);
            lblLineDiagPosY.Name = "lblLineDiagPosY";
            lblLineDiagPosY.Size = new Size(200, 15);
            lblLineDiagPosY.TabIndex = 63;
            lblLineDiagPosY.Text = "Line Diag. Pos. Y:";
            lblLineDiagPosY.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLineDiagPosX
            // 
            lblLineDiagPosX.Location = new Point(23, 475);
            lblLineDiagPosX.Name = "lblLineDiagPosX";
            lblLineDiagPosX.Size = new Size(200, 15);
            lblLineDiagPosX.TabIndex = 62;
            lblLineDiagPosX.Text = "Line Diag. Pos. X:";
            lblLineDiagPosX.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtLineDiagSizeY
            // 
            txtLineDiagSizeY.Location = new Point(224, 554);
            txtLineDiagSizeY.Name = "txtLineDiagSizeY";
            txtLineDiagSizeY.Size = new Size(100, 23);
            txtLineDiagSizeY.TabIndex = 61;
            txtLineDiagSizeY.LostFocus += txtLineDiagSizeY_LostFocus;
            // 
            // txtLineDiagSizeX
            // 
            txtLineDiagSizeX.Location = new Point(224, 525);
            txtLineDiagSizeX.Name = "txtLineDiagSizeX";
            txtLineDiagSizeX.Size = new Size(100, 23);
            txtLineDiagSizeX.TabIndex = 60;
            txtLineDiagSizeX.LostFocus += txtLineDiagSizeX_LostFocus;
            // 
            // txtLineDiagPosY
            // 
            txtLineDiagPosY.Location = new Point(224, 496);
            txtLineDiagPosY.Name = "txtLineDiagPosY";
            txtLineDiagPosY.Size = new Size(100, 23);
            txtLineDiagPosY.TabIndex = 59;
            txtLineDiagPosY.LostFocus += txtLineDiagPosY_LostFocus;
            // 
            // txtLineDiagPosX
            // 
            txtLineDiagPosX.Location = new Point(224, 467);
            txtLineDiagPosX.Name = "txtLineDiagPosX";
            txtLineDiagPosX.Size = new Size(100, 23);
            txtLineDiagPosX.TabIndex = 58;
            txtLineDiagPosX.LostFocus += txtLineDiagPosX_LostFocus;
            // 
            // lblScatterDiagSize
            // 
            lblScatterDiagSize.Location = new Point(23, 441);
            lblScatterDiagSize.Name = "lblScatterDiagSize";
            lblScatterDiagSize.Size = new Size(200, 15);
            lblScatterDiagSize.TabIndex = 57;
            lblScatterDiagSize.Text = "Scatter Diag. Size:";
            lblScatterDiagSize.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblScatterDiagPosY
            // 
            lblScatterDiagPosY.Location = new Point(23, 417);
            lblScatterDiagPosY.Name = "lblScatterDiagPosY";
            lblScatterDiagPosY.Size = new Size(200, 15);
            lblScatterDiagPosY.TabIndex = 56;
            lblScatterDiagPosY.Text = "Scatter Diag. Pos. Y:";
            lblScatterDiagPosY.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtScatterDiagSize
            // 
            txtScatterDiagSize.Location = new Point(224, 438);
            txtScatterDiagSize.Name = "txtScatterDiagSize";
            txtScatterDiagSize.Size = new Size(100, 23);
            txtScatterDiagSize.TabIndex = 55;
            txtScatterDiagSize.LostFocus += txtScatterDiagSize_LostFocus;
            // 
            // txtScatterDiagPosY
            // 
            txtScatterDiagPosY.Location = new Point(224, 409);
            txtScatterDiagPosY.Name = "txtScatterDiagPosY";
            txtScatterDiagPosY.Size = new Size(100, 23);
            txtScatterDiagPosY.TabIndex = 54;
            txtScatterDiagPosY.LostFocus += txtScatterDiagPosY_LostFocus;
            // 
            // txtScatterDiagPosX
            // 
            txtScatterDiagPosX.Location = new Point(224, 380);
            txtScatterDiagPosX.Name = "txtScatterDiagPosX";
            txtScatterDiagPosX.Size = new Size(100, 23);
            txtScatterDiagPosX.TabIndex = 52;
            txtScatterDiagPosX.LostFocus += txtScatterDiagPosX_LostFocus;
            // 
            // txtFilterHPLastModbusValue
            // 
            txtFilterHPLastModbusValue.Location = new Point(549, 373);
            txtFilterHPLastModbusValue.Name = "txtFilterHPLastModbusValue";
            txtFilterHPLastModbusValue.ReadOnly = true;
            txtFilterHPLastModbusValue.Size = new Size(100, 23);
            txtFilterHPLastModbusValue.TabIndex = 39;
            // 
            // lblScatterDiagPosX
            // 
            lblScatterDiagPosX.Location = new Point(21, 388);
            lblScatterDiagPosX.Name = "lblScatterDiagPosX";
            lblScatterDiagPosX.Size = new Size(200, 15);
            lblScatterDiagPosX.TabIndex = 53;
            lblScatterDiagPosX.Text = "Scatter Diag. Pos. X:";
            lblScatterDiagPosX.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtFilterLPLastModbusValue
            // 
            txtFilterLPLastModbusValue.Location = new Point(549, 344);
            txtFilterLPLastModbusValue.Name = "txtFilterLPLastModbusValue";
            txtFilterLPLastModbusValue.ReadOnly = true;
            txtFilterLPLastModbusValue.Size = new Size(100, 23);
            txtFilterLPLastModbusValue.TabIndex = 38;
            // 
            // txtPhaseLastModbusValue
            // 
            txtPhaseLastModbusValue.Location = new Point(549, 315);
            txtPhaseLastModbusValue.Name = "txtPhaseLastModbusValue";
            txtPhaseLastModbusValue.ReadOnly = true;
            txtPhaseLastModbusValue.Size = new Size(100, 23);
            txtPhaseLastModbusValue.TabIndex = 37;
            // 
            // lblScatterAmount
            // 
            lblScatterAmount.Location = new Point(21, 263);
            lblScatterAmount.Name = "lblScatterAmount";
            lblScatterAmount.Size = new Size(200, 15);
            lblScatterAmount.TabIndex = 40;
            lblScatterAmount.Text = "Amount of Points in Scatter:";
            lblScatterAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtGainYLastModbusValue
            // 
            txtGainYLastModbusValue.Location = new Point(549, 286);
            txtGainYLastModbusValue.Name = "txtGainYLastModbusValue";
            txtGainYLastModbusValue.ReadOnly = true;
            txtGainYLastModbusValue.Size = new Size(100, 23);
            txtGainYLastModbusValue.TabIndex = 36;
            // 
            // txtScatterPoints
            // 
            txtScatterPoints.Location = new Point(224, 260);
            txtScatterPoints.Name = "txtScatterPoints";
            txtScatterPoints.Size = new Size(100, 23);
            txtScatterPoints.TabIndex = 41;
            txtScatterPoints.LostFocus += txtScatterPoints_LostFocus;
            // 
            // txtGainXLastModbusValue
            // 
            txtGainXLastModbusValue.Location = new Point(549, 260);
            txtGainXLastModbusValue.Name = "txtGainXLastModbusValue";
            txtGainXLastModbusValue.ReadOnly = true;
            txtGainXLastModbusValue.Size = new Size(100, 23);
            txtGainXLastModbusValue.TabIndex = 35;
            // 
            // lblDiagMaxPointSize
            // 
            lblDiagMaxPointSize.Location = new Point(23, 234);
            lblDiagMaxPointSize.Name = "lblDiagMaxPointSize";
            lblDiagMaxPointSize.Size = new Size(200, 15);
            lblDiagMaxPointSize.TabIndex = 51;
            lblDiagMaxPointSize.Text = "Diagram Max. Point Height";
            lblDiagMaxPointSize.TextAlign = ContentAlignment.BottomRight;
            // 
            // txtFrequencyLastModbusValue
            // 
            txtFrequencyLastModbusValue.Location = new Point(550, 231);
            txtFrequencyLastModbusValue.Name = "txtFrequencyLastModbusValue";
            txtFrequencyLastModbusValue.ReadOnly = true;
            txtFrequencyLastModbusValue.Size = new Size(100, 23);
            txtFrequencyLastModbusValue.TabIndex = 34;
            // 
            // lblModbusServerIP
            // 
            lblModbusServerIP.AutoSize = true;
            lblModbusServerIP.Location = new Point(380, 86);
            lblModbusServerIP.Name = "lblModbusServerIP";
            lblModbusServerIP.Size = new Size(105, 15);
            lblModbusServerIP.TabIndex = 42;
            lblModbusServerIP.Text = "Modbus Server IP: ";
            // 
            // txtDiagMaxPointSize
            // 
            txtDiagMaxPointSize.Location = new Point(224, 227);
            txtDiagMaxPointSize.Name = "txtDiagMaxPointSize";
            txtDiagMaxPointSize.Size = new Size(100, 23);
            txtDiagMaxPointSize.TabIndex = 50;
            txtDiagMaxPointSize.LostFocus += txtLineDiagHeight_LostFocus;
            // 
            // lblModbusServerPort
            // 
            lblModbusServerPort.AutoSize = true;
            lblModbusServerPort.Location = new Point(371, 114);
            lblModbusServerPort.Name = "lblModbusServerPort";
            lblModbusServerPort.Size = new Size(114, 15);
            lblModbusServerPort.TabIndex = 43;
            lblModbusServerPort.Text = "Modbus Server Port:";
            // 
            // txtPlayLastModbusValue
            // 
            txtPlayLastModbusValue.Location = new Point(550, 194);
            txtPlayLastModbusValue.Name = "txtPlayLastModbusValue";
            txtPlayLastModbusValue.ReadOnly = true;
            txtPlayLastModbusValue.Size = new Size(100, 23);
            txtPlayLastModbusValue.TabIndex = 31;
            // 
            // lblLineDiagAmount
            // 
            lblLineDiagAmount.Location = new Point(23, 202);
            lblLineDiagAmount.Name = "lblLineDiagAmount";
            lblLineDiagAmount.Size = new Size(200, 15);
            lblLineDiagAmount.TabIndex = 49;
            lblLineDiagAmount.Text = "Amount of Points in LineDiag:";
            lblLineDiagAmount.TextAlign = ContentAlignment.BottomRight;
            // 
            // txtFilterHPModbusAddress
            // 
            txtFilterHPModbusAddress.Location = new Point(430, 373);
            txtFilterHPModbusAddress.Name = "txtFilterHPModbusAddress";
            txtFilterHPModbusAddress.Size = new Size(100, 23);
            txtFilterHPModbusAddress.TabIndex = 30;
            txtFilterHPModbusAddress.LostFocus += txtFilterHPModbusAddress_LostFocus;
            // 
            // txtModbusServerIP
            // 
            txtModbusServerIP.Location = new Point(482, 82);
            txtModbusServerIP.Name = "txtModbusServerIP";
            txtModbusServerIP.Size = new Size(100, 23);
            txtModbusServerIP.TabIndex = 44;
            txtModbusServerIP.LostFocus += txtModbusServerIP_LostFocus;
            // 
            // txtFilterLPModbusAddress
            // 
            txtFilterLPModbusAddress.Location = new Point(430, 344);
            txtFilterLPModbusAddress.Name = "txtFilterLPModbusAddress";
            txtFilterLPModbusAddress.Size = new Size(100, 23);
            txtFilterLPModbusAddress.TabIndex = 29;
            txtFilterLPModbusAddress.LostFocus += txtFilterLPModbusAddress_LostFocus;
            // 
            // txtLineDiagPoints
            // 
            txtLineDiagPoints.Location = new Point(224, 198);
            txtLineDiagPoints.Name = "txtLineDiagPoints";
            txtLineDiagPoints.Size = new Size(100, 23);
            txtLineDiagPoints.TabIndex = 48;
            txtLineDiagPoints.LostFocus += txtLineDiagPoints_LostFocus;
            // 
            // txtPhaseModbusAddress
            // 
            txtPhaseModbusAddress.Location = new Point(430, 315);
            txtPhaseModbusAddress.Name = "txtPhaseModbusAddress";
            txtPhaseModbusAddress.Size = new Size(100, 23);
            txtPhaseModbusAddress.TabIndex = 28;
            txtPhaseModbusAddress.LostFocus += txtPhaseModbusAddress_LostFocus;
            // 
            // txtModbusServerPort
            // 
            txtModbusServerPort.Location = new Point(482, 111);
            txtModbusServerPort.Name = "txtModbusServerPort";
            txtModbusServerPort.Size = new Size(100, 23);
            txtModbusServerPort.TabIndex = 45;
            txtModbusServerPort.LostFocus += txtModbusServerPort_LostFocus;
            // 
            // txtGainYModbusAddress
            // 
            txtGainYModbusAddress.Location = new Point(430, 286);
            txtGainYModbusAddress.Name = "txtGainYModbusAddress";
            txtGainYModbusAddress.Size = new Size(100, 23);
            txtGainYModbusAddress.TabIndex = 27;
            txtGainYModbusAddress.LostFocus += txtGainYModbusAddress_LostFocus;
            // 
            // txtCOMPort
            // 
            txtCOMPort.Location = new Point(225, 351);
            txtCOMPort.Name = "txtCOMPort";
            txtCOMPort.Size = new Size(100, 23);
            txtCOMPort.TabIndex = 47;
            txtCOMPort.LostFocus += txtCOMPort_LostFocus;
            // 
            // txtGainXModbusAddress
            // 
            txtGainXModbusAddress.Location = new Point(430, 260);
            txtGainXModbusAddress.Name = "txtGainXModbusAddress";
            txtGainXModbusAddress.Size = new Size(100, 23);
            txtGainXModbusAddress.TabIndex = 26;
            txtGainXModbusAddress.LostFocus += txtGainXModbusAddress_LostFocus;
            // 
            // lblComport
            // 
            lblComport.Location = new Point(19, 354);
            lblComport.Name = "lblComport";
            lblComport.Size = new Size(200, 15);
            lblComport.TabIndex = 46;
            lblComport.Text = "COM-Port:";
            lblComport.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtFrequencyModbusAddress
            // 
            txtFrequencyModbusAddress.Location = new Point(430, 231);
            txtFrequencyModbusAddress.Name = "txtFrequencyModbusAddress";
            txtFrequencyModbusAddress.Size = new Size(100, 23);
            txtFrequencyModbusAddress.TabIndex = 25;
            txtFrequencyModbusAddress.LostFocus += txtFrequencyModbusAddress_LostFocus;
            // 
            // txtX
            // 
            txtX.Location = new Point(224, 111);
            txtX.Name = "txtX";
            txtX.ReadOnly = true;
            txtX.Size = new Size(100, 23);
            txtX.TabIndex = 0;
            // 
            // txtAlarm2Value
            // 
            txtAlarm2Value.Location = new Point(225, 322);
            txtAlarm2Value.Name = "txtAlarm2Value";
            txtAlarm2Value.Size = new Size(100, 23);
            txtAlarm2Value.TabIndex = 24;
            txtAlarm2Value.LostFocus += txtAlarm2Value_LostFocus;
            // 
            // txtY
            // 
            txtY.Location = new Point(224, 140);
            txtY.Name = "txtY";
            txtY.ReadOnly = true;
            txtY.Size = new Size(100, 23);
            txtY.TabIndex = 1;
            // 
            // txtAlarm1Value
            // 
            txtAlarm1Value.Location = new Point(225, 292);
            txtAlarm1Value.Name = "txtAlarm1Value";
            txtAlarm1Value.Size = new Size(100, 23);
            txtAlarm1Value.TabIndex = 23;
            txtAlarm1Value.LostFocus += txtAlarm1Value_LostFocus;
            // 
            // txtPS
            // 
            txtPS.Location = new Point(224, 169);
            txtPS.Name = "txtPS";
            txtPS.ReadOnly = true;
            txtPS.Size = new Size(100, 23);
            txtPS.TabIndex = 2;
            // 
            // txtPlayModbusAddress
            // 
            txtPlayModbusAddress.Location = new Point(431, 194);
            txtPlayModbusAddress.Name = "txtPlayModbusAddress";
            txtPlayModbusAddress.Size = new Size(100, 23);
            txtPlayModbusAddress.TabIndex = 22;
            txtPlayModbusAddress.LostFocus += txtPlayModbusAddress_LostFocus;
            // 
            // lblPS
            // 
            lblPS.Location = new Point(21, 169);
            lblPS.Name = "lblPS";
            lblPS.Size = new Size(200, 15);
            lblPS.TabIndex = 3;
            lblPS.Text = "P/S";
            lblPS.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAlarm1
            // 
            lblAlarm1.Location = new Point(23, 297);
            lblAlarm1.Name = "lblAlarm1";
            lblAlarm1.Size = new Size(200, 15);
            lblAlarm1.TabIndex = 21;
            lblAlarm1.Text = "Alarm 1:";
            lblAlarm1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblYVal
            // 
            lblYVal.Location = new Point(23, 143);
            lblYVal.Name = "lblYVal";
            lblYVal.Size = new Size(200, 15);
            lblYVal.TabIndex = 4;
            lblYVal.Text = "Y-Values";
            lblYVal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPlay
            // 
            lblPlay.AutoSize = true;
            lblPlay.Location = new Point(393, 202);
            lblPlay.Name = "lblPlay";
            lblPlay.Size = new Size(32, 15);
            lblPlay.TabIndex = 20;
            lblPlay.Text = "Play:";
            // 
            // lblXVal
            // 
            lblXVal.Location = new Point(21, 114);
            lblXVal.Name = "lblXVal";
            lblXVal.Size = new Size(200, 15);
            lblXVal.TabIndex = 5;
            lblXVal.Text = "X-Values";
            lblXVal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAlarm2
            // 
            lblAlarm2.Location = new Point(21, 325);
            lblAlarm2.Name = "lblAlarm2";
            lblAlarm2.Size = new Size(200, 15);
            lblAlarm2.TabIndex = 19;
            lblAlarm2.Text = "Alarm 2:";
            lblAlarm2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFrequency1
            // 
            lblFrequency1.AutoSize = true;
            lblFrequency1.Location = new Point(363, 231);
            lblFrequency1.Name = "lblFrequency1";
            lblFrequency1.Size = new Size(65, 15);
            lblFrequency1.TabIndex = 13;
            lblFrequency1.Text = "Frequency:";
            // 
            // lblFilterHP1
            // 
            lblFilterHP1.AutoSize = true;
            lblFilterHP1.Location = new Point(373, 376);
            lblFilterHP1.Name = "lblFilterHP1";
            lblFilterHP1.Size = new Size(55, 15);
            lblFilterHP1.TabIndex = 18;
            lblFilterHP1.Text = "Filter HP:";
            // 
            // lblGainX1
            // 
            lblGainX1.AutoSize = true;
            lblGainX1.Location = new Point(381, 260);
            lblGainX1.Name = "lblGainX1";
            lblGainX1.Size = new Size(44, 15);
            lblGainX1.TabIndex = 14;
            lblGainX1.Text = "Gain X:";
            // 
            // lblFilterLP1
            // 
            lblFilterLP1.AutoSize = true;
            lblFilterLP1.Location = new Point(373, 347);
            lblFilterLP1.Name = "lblFilterLP1";
            lblFilterLP1.Size = new Size(52, 15);
            lblFilterLP1.TabIndex = 17;
            lblFilterLP1.Text = "Filter LP:";
            // 
            // lblGainY1
            // 
            lblGainY1.AutoSize = true;
            lblGainY1.Location = new Point(381, 289);
            lblGainY1.Name = "lblGainY1";
            lblGainY1.Size = new Size(44, 15);
            lblGainY1.TabIndex = 15;
            lblGainY1.Text = "Gain Y:";
            // 
            // lblPhase1
            // 
            lblPhase1.AutoSize = true;
            lblPhase1.Location = new Point(387, 318);
            lblPhase1.Name = "lblPhase1";
            lblPhase1.Size = new Size(41, 15);
            lblPhase1.TabIndex = 16;
            lblPhase1.Text = "Phase:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "EtHerG";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panelSettings.ResumeLayout(false);
            panelSettings.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctrInternationalization).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnEtherConnect;
        private Button btnEtherDisconnect;
        private Button btnModbusConnect;
        private Button btnModbusDisconnect;
        private Button btnLogout;
        private Button btnLogin;
        private TextBox txtPassword;
        private Label lblPassword;
        private Panel panelMain;
        private ScottPlot.WinForms.FormsPlot formLineDiag;
        private ScottPlot.WinForms.FormsPlot formScatter;
        private CheckBox chkShowY;
        private CheckBox chkShowX;
        private Panel panelSettings;
        private TextBox txtFilterHPUserInput;
        private TextBox txtFilterLPUserInput;
        private TextBox txtPhaseUserInput;
        private TextBox txtGainYUserInput;
        private TextBox txtGainXUserInput;
        private TextBox txtFrequencyUserInput;
        private Label lblFrequency;
        private Label lblFilterHP;
        private Label lblFilterLP;
        private Label lblPhase;
        private Label lblGainY;
        private Label lblGainX;
        private System.ComponentModel.BackgroundWorker DiagWorker;
        private System.ComponentModel.BackgroundWorker ModbusWorker;
        private TextBox txtY;
        private TextBox txtX;
        private Label lblXVal;
        private Label lblYVal;
        private Label lblPS;
        private TextBox txtPS;
        private Label lblAlarm1;
        private Label lblPlay;
        private Label lblAlarm2;
        private Label lblFilterHP1;
        private Label lblFilterLP1;
        private Label lblPhase1;
        private Label lblGainY1;
        private Label lblGainX1;
        private Label lblFrequency1;
        private TextBox txtFilterHPLast;
        private TextBox txtFilterLPLast;
        private TextBox txtPhaseLast;
        private TextBox txtGainYLast;
        private TextBox txtGainXLast;
        private TextBox txtFrequencyLast;
        private TextBox txtFilterLPLastModbusValue;
        private TextBox txtPhaseLastModbusValue;
        private TextBox txtGainYLastModbusValue;
        private TextBox txtGainXLastModbusValue;
        private TextBox txtFrequencyLastModbusValue;
        private TextBox txtPlayLastModbusValue;
        private TextBox txtFilterHPModbusAddress;
        private TextBox txtFilterLPModbusAddress;
        private TextBox txtPhaseModbusAddress;
        private TextBox txtGainYModbusAddress;
        private TextBox txtGainXModbusAddress;
        private TextBox txtFrequencyModbusAddress;
        private TextBox txtAlarm2Value;
        private TextBox txtAlarm1Value;
        private TextBox txtPlayModbusAddress;
        private TextBox txtFilterHPLastModbusValue;
        private CheckBox chkModbusAutoconnect;
        private CheckBox chkEtherAutoconnect;
        private TextBox txtScatterPoints;
        private Label lblScatterAmount;
        private TextBox txtModbusServerPort;
        private TextBox txtModbusServerIP;
        private Label lblModbusServerPort;
        private Label lblModbusServerIP;
        private TextBox txtCOMPort;
        private Label lblComport;
        private Panel panel1;
        private TextBox txtScatterDiagPosX;
        private Label lblScatterDiagPosX;
        private Label lblDiagMaxPointSize;
        private TextBox txtDiagMaxPointSize;
        private Label lblLineDiagAmount;
        private TextBox txtLineDiagPoints;
        private Label lblScatterDiagPosY;
        private TextBox txtScatterDiagSize;
        private TextBox txtScatterDiagPosY;
        private Label lblScatterDiagSize;
        private Label lblLineDiagSizeY;
        private Label lblLineDiagSizeX;
        private Label lblLineDiagPosY;
        private Label lblLineDiagPosX;
        private TextBox txtLineDiagSizeY;
        private TextBox txtLineDiagSizeX;
        private TextBox txtLineDiagPosY;
        private TextBox txtLineDiagPosX;
        private CheckBox chkAutologin;
        private TextBox txtSetPassword;
        private Button btnSetPassword;
        private Label lblModbusReadValue;
        private Label lblModbusReadAdresses;
        private CheckBox chkDisableUserInput;
        private TextBox txtAlarm2ModbusAddress;
        private TextBox txtAlarm1ModbusAddress;
        private Label lblAlarm1ModbusSendAddress;
        private Label lblAlarm2ModbusSendAddress;
        private Label lblModbusLastSentValueAdress;
        private TextBox txtFilterLPModbusLastSentAddress;
        private TextBox txtPhaseModbusLastSentAddress;
        private TextBox txtGainYModbusLastSentAddress;
        private TextBox txtGainXModbusLastSentAddress;
        private TextBox txtFrequencyModbusLastSentAddress;
        private CheckBox chkModbusLastSentAddressEnabled;
        private TextBox txtFilterHPModbusLastSentAddress;
        private Label lblInfluxDBServer;
        private Label lblInfluxDBToken;
        private TextBox txtInfluxDBOrg;
        private TextBox txtInfluxDBBucket;
        private TextBox txtInfluxDBToken;
        private TextBox txtInfluxDBServer;
        private CheckBox chkInfluxDBEnabled;
        private Label lblInfluxDBORGID;
        private Label lblInfluxDBBucket;
        private Label lblInfluxDBMachineName;
        private TextBox txtInfluxDBMachine;
        private TextBox txtModbusStatus;
        private TextBox txtEtherStatus;
        private Label lblColorY;
        private Label lblAlarm2Color;
        private Label lblColorX;
        private Label lblAlarm1Color;
        private TextBox txtScatterDiagColor;
        private TextBox txtLineDiagColorY;
        private TextBox txtLineDiagColorX;
        private TextBox txtAlarm2Color;
        private TextBox txtAlarm1Color;
        private Label lblScatterColor;
        private TextBox txtColorY;
        private TextBox txtColorX;
        private CheckBox chkScatterDrawPoints;
        private PictureBox pctrInternationalization;
        private PictureBox pictureBox1;
        private Label lblInstructions;
    }
}