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
            chkEqualGain = new CheckBox();
            panelPassword = new Panel();
            txtSetPassword = new TextBox();
            chkAutologin = new CheckBox();
            btnSetPassword = new Button();
            panelInfluxDBSettings = new Panel();
            chkInfluxDBEnabled = new CheckBox();
            lblInfluxDBServer = new Label();
            lblInfluxDBToken = new Label();
            lblInfluxDBBucket = new Label();
            lblInstructions = new Label();
            lblInfluxDBORGID = new Label();
            txtInfluxDBServer = new TextBox();
            txtInfluxDBToken = new TextBox();
            txtInfluxDBBucket = new TextBox();
            txtInfluxDBOrg = new TextBox();
            txtInfluxDBMachine = new TextBox();
            lblInfluxDBMachineName = new Label();
            panelModbusSettings = new Panel();
            lblModbusAlarmExpl = new Label();
            txtPlayModbusAddress = new TextBox();
            lblPhase1 = new Label();
            lblGainY1 = new Label();
            lblFilterLP1 = new Label();
            lblGainX1 = new Label();
            lblFilterHP1 = new Label();
            lblFrequency1 = new Label();
            lblPlay = new Label();
            txtFrequencyModbusAddress = new TextBox();
            txtGainXModbusAddress = new TextBox();
            txtGainYModbusAddress = new TextBox();
            txtModbusServerPort = new TextBox();
            txtPhaseModbusAddress = new TextBox();
            txtFilterLPModbusAddress = new TextBox();
            txtModbusServerIP = new TextBox();
            txtFilterHPModbusAddress = new TextBox();
            txtPlayLastModbusValue = new TextBox();
            lblModbusServerPort = new Label();
            lblModbusServerIP = new Label();
            txtFrequencyLastModbusValue = new TextBox();
            txtGainXLastModbusValue = new TextBox();
            txtGainYLastModbusValue = new TextBox();
            txtPhaseLastModbusValue = new TextBox();
            txtFilterLPLastModbusValue = new TextBox();
            txtFilterHPLastModbusValue = new TextBox();
            lblModbusReadAdresses = new Label();
            lblModbusReadValue = new Label();
            chkDisableUserInput = new CheckBox();
            chkModbusLastSentAddressEnabled = new CheckBox();
            lblAlarm2ModbusSendAddress = new Label();
            txtFilterHPModbusLastSentAddress = new TextBox();
            lblAlarm1ModbusSendAddress = new Label();
            txtFilterLPModbusLastSentAddress = new TextBox();
            txtAlarm1ModbusAddress = new TextBox();
            txtPhaseModbusLastSentAddress = new TextBox();
            txtAlarm2ModbusAddress = new TextBox();
            txtGainYModbusLastSentAddress = new TextBox();
            lblModbusLastSentValueAdress = new Label();
            txtGainXModbusLastSentAddress = new TextBox();
            txtFrequencyModbusLastSentAddress = new TextBox();
            txtMaxPoints = new TextBox();
            lblMaxPointsSettable = new Label();
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
            lblScatterDiagPosX = new Label();
            lblScatterAmount = new Label();
            txtScatterPoints = new TextBox();
            lblDiagMaxPointSize = new Label();
            txtDiagMaxPointSize = new TextBox();
            lblLineDiagAmount = new Label();
            txtLineDiagPoints = new TextBox();
            txtCOMPort = new TextBox();
            lblComport = new Label();
            txtX = new TextBox();
            txtAlarm2Value = new TextBox();
            txtY = new TextBox();
            txtAlarm1Value = new TextBox();
            txtPS = new TextBox();
            lblPS = new Label();
            lblAlarm1 = new Label();
            lblYVal = new Label();
            lblXVal = new Label();
            lblAlarm2 = new Label();
            DiagWorker = new System.ComponentModel.BackgroundWorker();
            ModbusWorker = new System.ComponentModel.BackgroundWorker();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panelSettings.SuspendLayout();
            panelMain.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            panelPassword.SuspendLayout();
            panelInfluxDBSettings.SuspendLayout();
            panelModbusSettings.SuspendLayout();
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
            txtFilterHPLast.Location = new Point(215, 175);
            txtFilterHPLast.Name = "txtFilterHPLast";
            txtFilterHPLast.ReadOnly = true;
            txtFilterHPLast.Size = new Size(100, 23);
            txtFilterHPLast.TabIndex = 18;
            txtFilterHPLast.TabStop = false;
            // 
            // txtFilterLPLast
            // 
            txtFilterLPLast.Location = new Point(215, 146);
            txtFilterLPLast.Name = "txtFilterLPLast";
            txtFilterLPLast.ReadOnly = true;
            txtFilterLPLast.Size = new Size(100, 23);
            txtFilterLPLast.TabIndex = 17;
            txtFilterLPLast.TabStop = false;
            // 
            // txtPhaseLast
            // 
            txtPhaseLast.Location = new Point(215, 117);
            txtPhaseLast.Name = "txtPhaseLast";
            txtPhaseLast.ReadOnly = true;
            txtPhaseLast.Size = new Size(100, 23);
            txtPhaseLast.TabIndex = 16;
            txtPhaseLast.TabStop = false;
            // 
            // txtGainYLast
            // 
            txtGainYLast.Location = new Point(215, 88);
            txtGainYLast.Name = "txtGainYLast";
            txtGainYLast.ReadOnly = true;
            txtGainYLast.Size = new Size(100, 23);
            txtGainYLast.TabIndex = 15;
            txtGainYLast.TabStop = false;
            // 
            // txtGainXLast
            // 
            txtGainXLast.Location = new Point(215, 59);
            txtGainXLast.Name = "txtGainXLast";
            txtGainXLast.ReadOnly = true;
            txtGainXLast.Size = new Size(100, 23);
            txtGainXLast.TabIndex = 14;
            txtGainXLast.TabStop = false;
            // 
            // txtFrequencyLast
            // 
            txtFrequencyLast.Location = new Point(215, 30);
            txtFrequencyLast.Name = "txtFrequencyLast";
            txtFrequencyLast.ReadOnly = true;
            txtFrequencyLast.Size = new Size(100, 23);
            txtFrequencyLast.TabIndex = 13;
            txtFrequencyLast.TabStop = false;
            // 
            // lblFilterHP
            // 
            lblFilterHP.Location = new Point(16, 178);
            lblFilterHP.Name = "lblFilterHP";
            lblFilterHP.Size = new Size(95, 15);
            lblFilterHP.TabIndex = 12;
            lblFilterHP.Text = "Filter HP:";
            lblFilterHP.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFilterLP
            // 
            lblFilterLP.Location = new Point(16, 149);
            lblFilterLP.Name = "lblFilterLP";
            lblFilterLP.Size = new Size(95, 15);
            lblFilterLP.TabIndex = 11;
            lblFilterLP.Text = "Filter LP:";
            lblFilterLP.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPhase
            // 
            lblPhase.Location = new Point(16, 120);
            lblPhase.Name = "lblPhase";
            lblPhase.Size = new Size(95, 15);
            lblPhase.TabIndex = 9;
            lblPhase.Text = "Phase:";
            lblPhase.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGainY
            // 
            lblGainY.Location = new Point(16, 91);
            lblGainY.Name = "lblGainY";
            lblGainY.Size = new Size(95, 15);
            lblGainY.TabIndex = 8;
            lblGainY.Text = "Gain Y:";
            lblGainY.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGainX
            // 
            lblGainX.Location = new Point(16, 62);
            lblGainX.Name = "lblGainX";
            lblGainX.Size = new Size(95, 15);
            lblGainX.TabIndex = 7;
            lblGainX.Text = "Gain X:";
            lblGainX.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtFilterHPUserInput
            // 
            txtFilterHPUserInput.Location = new Point(109, 175);
            txtFilterHPUserInput.Name = "txtFilterHPUserInput";
            txtFilterHPUserInput.Size = new Size(101, 23);
            txtFilterHPUserInput.TabIndex = 17;
            txtFilterHPUserInput.LostFocus += txtFilterHPUserInput_LostFocus;
            txtFilterHPUserInput.MouseWheel += txtFilterHPUserInput_MouseWheel;
            // 
            // txtFilterLPUserInput
            // 
            txtFilterLPUserInput.Location = new Point(109, 146);
            txtFilterLPUserInput.Name = "txtFilterLPUserInput";
            txtFilterLPUserInput.Size = new Size(101, 23);
            txtFilterLPUserInput.TabIndex = 16;
            txtFilterLPUserInput.LostFocus += txtFilterLPUserInput_LostFocus;
            txtFilterLPUserInput.MouseWheel += txtFilterLPUserInput_MouseWheel;
            // 
            // txtPhaseUserInput
            // 
            txtPhaseUserInput.Location = new Point(109, 117);
            txtPhaseUserInput.Name = "txtPhaseUserInput";
            txtPhaseUserInput.Size = new Size(101, 23);
            txtPhaseUserInput.TabIndex = 15;
            txtPhaseUserInput.LostFocus += txtPhaseUserInput_LostFocus;
            txtPhaseUserInput.MouseWheel += txtPhaseUserInput_MouseWheel;
            // 
            // txtGainYUserInput
            // 
            txtGainYUserInput.Location = new Point(109, 88);
            txtGainYUserInput.Name = "txtGainYUserInput";
            txtGainYUserInput.Size = new Size(101, 23);
            txtGainYUserInput.TabIndex = 14;
            txtGainYUserInput.LostFocus += txtGainYUserInput_LostFocus;
            txtGainYUserInput.MouseWheel += txtGainYUserInput_MouseWheel;
            // 
            // txtGainXUserInput
            // 
            txtGainXUserInput.Location = new Point(109, 59);
            txtGainXUserInput.Name = "txtGainXUserInput";
            txtGainXUserInput.Size = new Size(101, 23);
            txtGainXUserInput.TabIndex = 13;
            txtGainXUserInput.LostFocus += txtGainXUserInput_LostFocus;
            txtGainXUserInput.MouseWheel += txtGainXUserInput_MouseWheel;
            // 
            // txtFrequencyUserInput
            // 
            txtFrequencyUserInput.Location = new Point(109, 30);
            txtFrequencyUserInput.Name = "txtFrequencyUserInput";
            txtFrequencyUserInput.Size = new Size(100, 23);
            txtFrequencyUserInput.TabIndex = 12;
            txtFrequencyUserInput.LostFocus += txtFrequencyUserInput_LostFocus;
            txtFrequencyUserInput.MouseWheel += txtFrequencyUserInput_MouseWheel;
            // 
            // lblFrequency
            // 
            lblFrequency.Location = new Point(16, 33);
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
            txtModbusStatus.Location = new Point(944, 33);
            txtModbusStatus.Name = "txtModbusStatus";
            txtModbusStatus.ReadOnly = true;
            txtModbusStatus.Size = new Size(100, 23);
            txtModbusStatus.TabIndex = 12;
            txtModbusStatus.TabStop = false;
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
            txtEtherStatus.TabStop = false;
            txtEtherStatus.Text = "ETHER";
            txtEtherStatus.TextAlign = HorizontalAlignment.Center;
            // 
            // chkModbusAutoconnect
            // 
            chkModbusAutoconnect.AutoSize = true;
            chkModbusAutoconnect.Location = new Point(796, 37);
            chkModbusAutoconnect.Name = "chkModbusAutoconnect";
            chkModbusAutoconnect.Size = new Size(142, 19);
            chkModbusAutoconnect.TabIndex = 11;
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
            chkEtherAutoconnect.TabIndex = 10;
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
            chkShowY.TabIndex = 9;
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
            chkShowX.TabIndex = 8;
            chkShowX.Text = "X-Values";
            chkShowX.UseVisualStyleBackColor = false;
            chkShowX.CheckedChanged += chkShowX_CheckedChanged;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(594, 15);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(79, 41);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnEtherConnect
            // 
            btnEtherConnect.Location = new Point(3, 15);
            btnEtherConnect.Name = "btnEtherConnect";
            btnEtherConnect.Size = new Size(79, 41);
            btnEtherConnect.TabIndex = 1;
            btnEtherConnect.Text = "Ether Connect";
            btnEtherConnect.UseVisualStyleBackColor = true;
            btnEtherConnect.Click += btnEtherConnect_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(509, 15);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(79, 41);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnModbusDisconnect
            // 
            btnModbusDisconnect.Location = new Point(258, 15);
            btnModbusDisconnect.Name = "btnModbusDisconnect";
            btnModbusDisconnect.Size = new Size(79, 41);
            btnModbusDisconnect.TabIndex = 4;
            btnModbusDisconnect.Text = "Modbus Disconnect";
            btnModbusDisconnect.UseVisualStyleBackColor = true;
            btnModbusDisconnect.Click += btnModbusDisconnect_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(403, 23);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnModbusConnect
            // 
            btnModbusConnect.Location = new Point(173, 15);
            btnModbusConnect.Name = "btnModbusConnect";
            btnModbusConnect.Size = new Size(79, 41);
            btnModbusConnect.TabIndex = 3;
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
            btnEtherDisconnect.TabIndex = 2;
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
            formLineDiag.TabStop = false;
            // 
            // formScatter
            // 
            formScatter.DisplayScale = 1F;
            formScatter.Location = new Point(343, 80);
            formScatter.Name = "formScatter";
            formScatter.Size = new Size(400, 400);
            formScatter.TabIndex = 4;
            formScatter.TabStop = false;
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
            panel1.Controls.Add(chkEqualGain);
            panel1.Controls.Add(panelPassword);
            panel1.Controls.Add(panelInfluxDBSettings);
            panel1.Controls.Add(panelModbusSettings);
            panel1.Controls.Add(txtMaxPoints);
            panel1.Controls.Add(lblMaxPointsSettable);
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
            panel1.Controls.Add(lblScatterDiagPosX);
            panel1.Controls.Add(lblScatterAmount);
            panel1.Controls.Add(txtScatterPoints);
            panel1.Controls.Add(lblDiagMaxPointSize);
            panel1.Controls.Add(txtDiagMaxPointSize);
            panel1.Controls.Add(lblLineDiagAmount);
            panel1.Controls.Add(txtLineDiagPoints);
            panel1.Controls.Add(txtCOMPort);
            panel1.Controls.Add(lblComport);
            panel1.Controls.Add(txtX);
            panel1.Controls.Add(txtAlarm2Value);
            panel1.Controls.Add(txtY);
            panel1.Controls.Add(txtAlarm1Value);
            panel1.Controls.Add(txtPS);
            panel1.Controls.Add(lblPS);
            panel1.Controls.Add(lblAlarm1);
            panel1.Controls.Add(lblYVal);
            panel1.Controls.Add(lblXVal);
            panel1.Controls.Add(lblAlarm2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1890, 1007);
            panel1.TabIndex = 54;
            // 
            // chkEqualGain
            // 
            chkEqualGain.Location = new Point(106, 720);
            chkEqualGain.Name = "chkEqualGain";
            chkEqualGain.Size = new Size(220, 19);
            chkEqualGain.TabIndex = 25;
            chkEqualGain.Text = "GainX = GainY";
            chkEqualGain.TextAlign = ContentAlignment.MiddleCenter;
            chkEqualGain.UseVisualStyleBackColor = true;
            chkEqualGain.CheckedChanged += chkEqualGain_CheckedChanged;
            // 
            // panelPassword
            // 
            panelPassword.AutoSize = true;
            panelPassword.Controls.Add(txtSetPassword);
            panelPassword.Controls.Add(chkAutologin);
            panelPassword.Controls.Add(btnSetPassword);
            panelPassword.Location = new Point(133, 50);
            panelPassword.Name = "panelPassword";
            panelPassword.Size = new Size(193, 58);
            panelPassword.TabIndex = 113;
            // 
            // txtSetPassword
            // 
            txtSetPassword.Location = new Point(88, 30);
            txtSetPassword.Name = "txtSetPassword";
            txtSetPassword.Size = new Size(100, 23);
            txtSetPassword.TabIndex = 3;
            // 
            // chkAutologin
            // 
            chkAutologin.AutoSize = true;
            chkAutologin.Location = new Point(109, 9);
            chkAutologin.Name = "chkAutologin";
            chkAutologin.Size = new Size(79, 19);
            chkAutologin.TabIndex = 2;
            chkAutologin.Text = "Autologin";
            chkAutologin.UseVisualStyleBackColor = true;
            // 
            // btnSetPassword
            // 
            btnSetPassword.Location = new Point(3, 5);
            btnSetPassword.Name = "btnSetPassword";
            btnSetPassword.Size = new Size(75, 48);
            btnSetPassword.TabIndex = 1;
            btnSetPassword.Text = "Set Password";
            btnSetPassword.UseVisualStyleBackColor = true;
            btnSetPassword.Click += btnSetPassword_Click;
            // 
            // panelInfluxDBSettings
            // 
            panelInfluxDBSettings.BorderStyle = BorderStyle.FixedSingle;
            panelInfluxDBSettings.Controls.Add(chkInfluxDBEnabled);
            panelInfluxDBSettings.Controls.Add(lblInfluxDBServer);
            panelInfluxDBSettings.Controls.Add(lblInfluxDBToken);
            panelInfluxDBSettings.Controls.Add(lblInfluxDBBucket);
            panelInfluxDBSettings.Controls.Add(lblInstructions);
            panelInfluxDBSettings.Controls.Add(lblInfluxDBORGID);
            panelInfluxDBSettings.Controls.Add(txtInfluxDBServer);
            panelInfluxDBSettings.Controls.Add(txtInfluxDBToken);
            panelInfluxDBSettings.Controls.Add(txtInfluxDBBucket);
            panelInfluxDBSettings.Controls.Add(txtInfluxDBOrg);
            panelInfluxDBSettings.Controls.Add(txtInfluxDBMachine);
            panelInfluxDBSettings.Controls.Add(lblInfluxDBMachineName);
            panelInfluxDBSettings.Location = new Point(355, 463);
            panelInfluxDBSettings.Name = "panelInfluxDBSettings";
            panelInfluxDBSettings.Size = new Size(537, 276);
            panelInfluxDBSettings.TabIndex = 112;
            // 
            // chkInfluxDBEnabled
            // 
            chkInfluxDBEnabled.AutoSize = true;
            chkInfluxDBEnabled.Location = new Point(224, 25);
            chkInfluxDBEnabled.Name = "chkInfluxDBEnabled";
            chkInfluxDBEnabled.Size = new Size(116, 19);
            chkInfluxDBEnabled.TabIndex = 100;
            chkInfluxDBEnabled.Text = "InfluxDB Enabled";
            chkInfluxDBEnabled.UseVisualStyleBackColor = true;
            chkInfluxDBEnabled.CheckedChanged += chkInfluxDBEnabled_CheckedChanged;
            // 
            // lblInfluxDBServer
            // 
            lblInfluxDBServer.AutoSize = true;
            lblInfluxDBServer.Location = new Point(133, 54);
            lblInfluxDBServer.Name = "lblInfluxDBServer";
            lblInfluxDBServer.Size = new Size(84, 15);
            lblInfluxDBServer.TabIndex = 85;
            lblInfluxDBServer.Text = "InfluxDBServer";
            // 
            // lblInfluxDBToken
            // 
            lblInfluxDBToken.AutoSize = true;
            lblInfluxDBToken.Location = new Point(135, 83);
            lblInfluxDBToken.Name = "lblInfluxDBToken";
            lblInfluxDBToken.Size = new Size(82, 15);
            lblInfluxDBToken.TabIndex = 86;
            lblInfluxDBToken.Text = "InfluxDBToken";
            // 
            // lblInfluxDBBucket
            // 
            lblInfluxDBBucket.AutoSize = true;
            lblInfluxDBBucket.Location = new Point(126, 112);
            lblInfluxDBBucket.Name = "lblInfluxDBBucket";
            lblInfluxDBBucket.Size = new Size(91, 15);
            lblInfluxDBBucket.TabIndex = 87;
            lblInfluxDBBucket.Text = "InfluxDB Bucket";
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Location = new Point(22, 206);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(427, 60);
            lblInstructions.TabIndex = 109;
            lblInstructions.Text = resources.GetString("lblInstructions.Text");
            // 
            // lblInfluxDBORGID
            // 
            lblInfluxDBORGID.AutoSize = true;
            lblInfluxDBORGID.Location = new Point(126, 141);
            lblInfluxDBORGID.Name = "lblInfluxDBORGID";
            lblInfluxDBORGID.Size = new Size(91, 15);
            lblInfluxDBORGID.TabIndex = 88;
            lblInfluxDBORGID.Text = "InfluxDB Org-ID";
            // 
            // txtInfluxDBServer
            // 
            txtInfluxDBServer.Location = new Point(223, 50);
            txtInfluxDBServer.Name = "txtInfluxDBServer";
            txtInfluxDBServer.Size = new Size(100, 23);
            txtInfluxDBServer.TabIndex = 101;
            txtInfluxDBServer.LostFocus += txtInfluxDBServer_LostFocus;
            // 
            // txtInfluxDBToken
            // 
            txtInfluxDBToken.Location = new Point(223, 79);
            txtInfluxDBToken.Name = "txtInfluxDBToken";
            txtInfluxDBToken.Size = new Size(100, 23);
            txtInfluxDBToken.TabIndex = 102;
            txtInfluxDBToken.LostFocus += txtInfluxDBToken_LostFocus;
            // 
            // txtInfluxDBBucket
            // 
            txtInfluxDBBucket.Location = new Point(223, 108);
            txtInfluxDBBucket.Name = "txtInfluxDBBucket";
            txtInfluxDBBucket.Size = new Size(100, 23);
            txtInfluxDBBucket.TabIndex = 103;
            txtInfluxDBBucket.LostFocus += txtInfluxDBBucket_LostFocus;
            // 
            // txtInfluxDBOrg
            // 
            txtInfluxDBOrg.Location = new Point(223, 137);
            txtInfluxDBOrg.Name = "txtInfluxDBOrg";
            txtInfluxDBOrg.Size = new Size(100, 23);
            txtInfluxDBOrg.TabIndex = 104;
            txtInfluxDBOrg.LostFocus += txtInfluxDBOrg_LostFocus;
            // 
            // txtInfluxDBMachine
            // 
            txtInfluxDBMachine.Location = new Point(223, 166);
            txtInfluxDBMachine.Name = "txtInfluxDBMachine";
            txtInfluxDBMachine.Size = new Size(100, 23);
            txtInfluxDBMachine.TabIndex = 105;
            txtInfluxDBMachine.LostFocus += txtInfluxDBMachine_LostFocus;
            // 
            // lblInfluxDBMachineName
            // 
            lblInfluxDBMachineName.AutoSize = true;
            lblInfluxDBMachineName.Location = new Point(84, 170);
            lblInfluxDBMachineName.Name = "lblInfluxDBMachineName";
            lblInfluxDBMachineName.Size = new Size(133, 15);
            lblInfluxDBMachineName.TabIndex = 95;
            lblInfluxDBMachineName.Text = "InfluxDB MachineName";
            // 
            // panelModbusSettings
            // 
            panelModbusSettings.BorderStyle = BorderStyle.FixedSingle;
            panelModbusSettings.Controls.Add(lblModbusAlarmExpl);
            panelModbusSettings.Controls.Add(txtPlayModbusAddress);
            panelModbusSettings.Controls.Add(lblPhase1);
            panelModbusSettings.Controls.Add(lblGainY1);
            panelModbusSettings.Controls.Add(lblFilterLP1);
            panelModbusSettings.Controls.Add(lblGainX1);
            panelModbusSettings.Controls.Add(lblFilterHP1);
            panelModbusSettings.Controls.Add(lblFrequency1);
            panelModbusSettings.Controls.Add(lblPlay);
            panelModbusSettings.Controls.Add(txtFrequencyModbusAddress);
            panelModbusSettings.Controls.Add(txtGainXModbusAddress);
            panelModbusSettings.Controls.Add(txtGainYModbusAddress);
            panelModbusSettings.Controls.Add(txtModbusServerPort);
            panelModbusSettings.Controls.Add(txtPhaseModbusAddress);
            panelModbusSettings.Controls.Add(txtFilterLPModbusAddress);
            panelModbusSettings.Controls.Add(txtModbusServerIP);
            panelModbusSettings.Controls.Add(txtFilterHPModbusAddress);
            panelModbusSettings.Controls.Add(txtPlayLastModbusValue);
            panelModbusSettings.Controls.Add(lblModbusServerPort);
            panelModbusSettings.Controls.Add(lblModbusServerIP);
            panelModbusSettings.Controls.Add(txtFrequencyLastModbusValue);
            panelModbusSettings.Controls.Add(txtGainXLastModbusValue);
            panelModbusSettings.Controls.Add(txtGainYLastModbusValue);
            panelModbusSettings.Controls.Add(txtPhaseLastModbusValue);
            panelModbusSettings.Controls.Add(txtFilterLPLastModbusValue);
            panelModbusSettings.Controls.Add(txtFilterHPLastModbusValue);
            panelModbusSettings.Controls.Add(lblModbusReadAdresses);
            panelModbusSettings.Controls.Add(lblModbusReadValue);
            panelModbusSettings.Controls.Add(chkDisableUserInput);
            panelModbusSettings.Controls.Add(chkModbusLastSentAddressEnabled);
            panelModbusSettings.Controls.Add(lblAlarm2ModbusSendAddress);
            panelModbusSettings.Controls.Add(txtFilterHPModbusLastSentAddress);
            panelModbusSettings.Controls.Add(lblAlarm1ModbusSendAddress);
            panelModbusSettings.Controls.Add(txtFilterLPModbusLastSentAddress);
            panelModbusSettings.Controls.Add(txtAlarm1ModbusAddress);
            panelModbusSettings.Controls.Add(txtPhaseModbusLastSentAddress);
            panelModbusSettings.Controls.Add(txtAlarm2ModbusAddress);
            panelModbusSettings.Controls.Add(txtGainYModbusLastSentAddress);
            panelModbusSettings.Controls.Add(lblModbusLastSentValueAdress);
            panelModbusSettings.Controls.Add(txtGainXModbusLastSentAddress);
            panelModbusSettings.Controls.Add(txtFrequencyModbusLastSentAddress);
            panelModbusSettings.Location = new Point(355, 41);
            panelModbusSettings.Name = "panelModbusSettings";
            panelModbusSettings.Size = new Size(537, 412);
            panelModbusSettings.TabIndex = 111;
            // 
            // lblModbusAlarmExpl
            // 
            lblModbusAlarmExpl.AutoSize = true;
            lblModbusAlarmExpl.Location = new Point(197, 354);
            lblModbusAlarmExpl.Name = "lblModbusAlarmExpl";
            lblModbusAlarmExpl.Size = new Size(328, 45);
            lblModbusAlarmExpl.TabIndex = 1000;
            lblModbusAlarmExpl.Text = "Play is the Coil Address to Start/Stop the Measurement\r\nAlarm 1 and Alarm 2 Addresses will be the \r\nCoil Addresses which will be written when the Alarm is active";
            // 
            // txtPlayModbusAddress
            // 
            txtPlayModbusAddress.Location = new Point(79, 147);
            txtPlayModbusAddress.Name = "txtPlayModbusAddress";
            txtPlayModbusAddress.Size = new Size(100, 23);
            txtPlayModbusAddress.TabIndex = 53;
            txtPlayModbusAddress.LostFocus += txtPlayModbusAddress_LostFocus;
            // 
            // lblPhase1
            // 
            lblPhase1.AutoSize = true;
            lblPhase1.Location = new Point(35, 268);
            lblPhase1.Name = "lblPhase1";
            lblPhase1.Size = new Size(41, 15);
            lblPhase1.TabIndex = 16;
            lblPhase1.Text = "Phase:";
            // 
            // lblGainY1
            // 
            lblGainY1.AutoSize = true;
            lblGainY1.Location = new Point(29, 239);
            lblGainY1.Name = "lblGainY1";
            lblGainY1.Size = new Size(44, 15);
            lblGainY1.TabIndex = 15;
            lblGainY1.Text = "Gain Y:";
            // 
            // lblFilterLP1
            // 
            lblFilterLP1.AutoSize = true;
            lblFilterLP1.Location = new Point(21, 297);
            lblFilterLP1.Name = "lblFilterLP1";
            lblFilterLP1.Size = new Size(52, 15);
            lblFilterLP1.TabIndex = 17;
            lblFilterLP1.Text = "Filter LP:";
            // 
            // lblGainX1
            // 
            lblGainX1.AutoSize = true;
            lblGainX1.Location = new Point(29, 210);
            lblGainX1.Name = "lblGainX1";
            lblGainX1.Size = new Size(44, 15);
            lblGainX1.TabIndex = 14;
            lblGainX1.Text = "Gain X:";
            // 
            // lblFilterHP1
            // 
            lblFilterHP1.AutoSize = true;
            lblFilterHP1.Location = new Point(21, 326);
            lblFilterHP1.Name = "lblFilterHP1";
            lblFilterHP1.Size = new Size(55, 15);
            lblFilterHP1.TabIndex = 18;
            lblFilterHP1.Text = "Filter HP:";
            // 
            // lblFrequency1
            // 
            lblFrequency1.AutoSize = true;
            lblFrequency1.Location = new Point(11, 181);
            lblFrequency1.Name = "lblFrequency1";
            lblFrequency1.Size = new Size(65, 15);
            lblFrequency1.TabIndex = 13;
            lblFrequency1.Text = "Frequency:";
            // 
            // lblPlay
            // 
            lblPlay.AutoSize = true;
            lblPlay.Location = new Point(41, 152);
            lblPlay.Name = "lblPlay";
            lblPlay.Size = new Size(32, 15);
            lblPlay.TabIndex = 20;
            lblPlay.Text = "Play:";
            // 
            // txtFrequencyModbusAddress
            // 
            txtFrequencyModbusAddress.Location = new Point(79, 176);
            txtFrequencyModbusAddress.Name = "txtFrequencyModbusAddress";
            txtFrequencyModbusAddress.Size = new Size(100, 23);
            txtFrequencyModbusAddress.TabIndex = 54;
            txtFrequencyModbusAddress.LostFocus += txtFrequencyModbusAddress_LostFocus;
            // 
            // txtGainXModbusAddress
            // 
            txtGainXModbusAddress.Location = new Point(78, 205);
            txtGainXModbusAddress.Name = "txtGainXModbusAddress";
            txtGainXModbusAddress.Size = new Size(100, 23);
            txtGainXModbusAddress.TabIndex = 55;
            txtGainXModbusAddress.LostFocus += txtGainXModbusAddress_LostFocus;
            // 
            // txtGainYModbusAddress
            // 
            txtGainYModbusAddress.Location = new Point(78, 234);
            txtGainYModbusAddress.Name = "txtGainYModbusAddress";
            txtGainYModbusAddress.Size = new Size(100, 23);
            txtGainYModbusAddress.TabIndex = 56;
            txtGainYModbusAddress.LostFocus += txtGainYModbusAddress_LostFocus;
            // 
            // txtModbusServerPort
            // 
            txtModbusServerPort.Location = new Point(130, 64);
            txtModbusServerPort.Name = "txtModbusServerPort";
            txtModbusServerPort.Size = new Size(100, 23);
            txtModbusServerPort.TabIndex = 52;
            txtModbusServerPort.LostFocus += txtModbusServerPort_LostFocus;
            // 
            // txtPhaseModbusAddress
            // 
            txtPhaseModbusAddress.Location = new Point(78, 263);
            txtPhaseModbusAddress.Name = "txtPhaseModbusAddress";
            txtPhaseModbusAddress.Size = new Size(100, 23);
            txtPhaseModbusAddress.TabIndex = 57;
            txtPhaseModbusAddress.LostFocus += txtPhaseModbusAddress_LostFocus;
            // 
            // txtFilterLPModbusAddress
            // 
            txtFilterLPModbusAddress.Location = new Point(78, 292);
            txtFilterLPModbusAddress.Name = "txtFilterLPModbusAddress";
            txtFilterLPModbusAddress.Size = new Size(100, 23);
            txtFilterLPModbusAddress.TabIndex = 58;
            txtFilterLPModbusAddress.LostFocus += txtFilterLPModbusAddress_LostFocus;
            // 
            // txtModbusServerIP
            // 
            txtModbusServerIP.Location = new Point(130, 35);
            txtModbusServerIP.Name = "txtModbusServerIP";
            txtModbusServerIP.Size = new Size(100, 23);
            txtModbusServerIP.TabIndex = 51;
            txtModbusServerIP.LostFocus += txtModbusServerIP_LostFocus;
            // 
            // txtFilterHPModbusAddress
            // 
            txtFilterHPModbusAddress.Location = new Point(78, 321);
            txtFilterHPModbusAddress.Name = "txtFilterHPModbusAddress";
            txtFilterHPModbusAddress.Size = new Size(100, 23);
            txtFilterHPModbusAddress.TabIndex = 59;
            txtFilterHPModbusAddress.LostFocus += txtFilterHPModbusAddress_LostFocus;
            // 
            // txtPlayLastModbusValue
            // 
            txtPlayLastModbusValue.Location = new Point(197, 147);
            txtPlayLastModbusValue.Name = "txtPlayLastModbusValue";
            txtPlayLastModbusValue.ReadOnly = true;
            txtPlayLastModbusValue.Size = new Size(100, 23);
            txtPlayLastModbusValue.TabIndex = 1001;
            txtPlayLastModbusValue.TabStop = false;
            // 
            // lblModbusServerPort
            // 
            lblModbusServerPort.Location = new Point(8, 67);
            lblModbusServerPort.Name = "lblModbusServerPort";
            lblModbusServerPort.Size = new Size(120, 15);
            lblModbusServerPort.TabIndex = 43;
            lblModbusServerPort.Text = "Modbus Server Port:";
            lblModbusServerPort.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblModbusServerIP
            // 
            lblModbusServerIP.Location = new Point(8, 38);
            lblModbusServerIP.Name = "lblModbusServerIP";
            lblModbusServerIP.Size = new Size(120, 15);
            lblModbusServerIP.TabIndex = 42;
            lblModbusServerIP.Text = "Modbus Server IP:";
            lblModbusServerIP.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtFrequencyLastModbusValue
            // 
            txtFrequencyLastModbusValue.Location = new Point(197, 176);
            txtFrequencyLastModbusValue.Name = "txtFrequencyLastModbusValue";
            txtFrequencyLastModbusValue.ReadOnly = true;
            txtFrequencyLastModbusValue.Size = new Size(100, 23);
            txtFrequencyLastModbusValue.TabIndex = 1002;
            txtFrequencyLastModbusValue.TabStop = false;
            // 
            // txtGainXLastModbusValue
            // 
            txtGainXLastModbusValue.Location = new Point(197, 205);
            txtGainXLastModbusValue.Name = "txtGainXLastModbusValue";
            txtGainXLastModbusValue.ReadOnly = true;
            txtGainXLastModbusValue.Size = new Size(100, 23);
            txtGainXLastModbusValue.TabIndex = 1003;
            txtGainXLastModbusValue.TabStop = false;
            // 
            // txtGainYLastModbusValue
            // 
            txtGainYLastModbusValue.Location = new Point(197, 234);
            txtGainYLastModbusValue.Name = "txtGainYLastModbusValue";
            txtGainYLastModbusValue.ReadOnly = true;
            txtGainYLastModbusValue.Size = new Size(100, 23);
            txtGainYLastModbusValue.TabIndex = 1004;
            txtGainYLastModbusValue.TabStop = false;
            // 
            // txtPhaseLastModbusValue
            // 
            txtPhaseLastModbusValue.Location = new Point(197, 263);
            txtPhaseLastModbusValue.Name = "txtPhaseLastModbusValue";
            txtPhaseLastModbusValue.ReadOnly = true;
            txtPhaseLastModbusValue.Size = new Size(100, 23);
            txtPhaseLastModbusValue.TabIndex = 1005;
            txtPhaseLastModbusValue.TabStop = false;
            // 
            // txtFilterLPLastModbusValue
            // 
            txtFilterLPLastModbusValue.Location = new Point(197, 292);
            txtFilterLPLastModbusValue.Name = "txtFilterLPLastModbusValue";
            txtFilterLPLastModbusValue.ReadOnly = true;
            txtFilterLPLastModbusValue.Size = new Size(100, 23);
            txtFilterLPLastModbusValue.TabIndex = 1006;
            txtFilterLPLastModbusValue.TabStop = false;
            // 
            // txtFilterHPLastModbusValue
            // 
            txtFilterHPLastModbusValue.Location = new Point(197, 321);
            txtFilterHPLastModbusValue.Name = "txtFilterHPLastModbusValue";
            txtFilterHPLastModbusValue.ReadOnly = true;
            txtFilterHPLastModbusValue.Size = new Size(100, 23);
            txtFilterHPLastModbusValue.TabIndex = 1007;
            txtFilterHPLastModbusValue.TabStop = false;
            // 
            // lblModbusReadAdresses
            // 
            lblModbusReadAdresses.AutoSize = true;
            lblModbusReadAdresses.Location = new Point(64, 127);
            lblModbusReadAdresses.Name = "lblModbusReadAdresses";
            lblModbusReadAdresses.Size = new Size(129, 15);
            lblModbusReadAdresses.TabIndex = 1008;
            lblModbusReadAdresses.Text = "Modbus Read Adresses";
            // 
            // lblModbusReadValue
            // 
            lblModbusReadValue.AutoSize = true;
            lblModbusReadValue.Location = new Point(198, 129);
            lblModbusReadValue.Name = "lblModbusReadValue";
            lblModbusReadValue.Size = new Size(105, 15);
            lblModbusReadValue.TabIndex = 1009;
            lblModbusReadValue.Text = "ModbusReadValue";
            // 
            // chkDisableUserInput
            // 
            chkDisableUserInput.AutoSize = true;
            chkDisableUserInput.Location = new Point(78, 8);
            chkDisableUserInput.Name = "chkDisableUserInput";
            chkDisableUserInput.Size = new Size(121, 19);
            chkDisableUserInput.TabIndex = 50;
            chkDisableUserInput.Text = "Disable User Input";
            chkDisableUserInput.UseVisualStyleBackColor = true;
            chkDisableUserInput.CheckedChanged += chkDisableUserInput_CheckedChanged;
            // 
            // chkModbusLastSentAddressEnabled
            // 
            chkModbusLastSentAddressEnabled.AutoSize = true;
            chkModbusLastSentAddressEnabled.Location = new Point(315, 151);
            chkModbusLastSentAddressEnabled.Name = "chkModbusLastSentAddressEnabled";
            chkModbusLastSentAddressEnabled.Size = new Size(201, 19);
            chkModbusLastSentAddressEnabled.TabIndex = 62;
            chkModbusLastSentAddressEnabled.Text = "Modbus Last Sent Value Enabled?";
            chkModbusLastSentAddressEnabled.UseVisualStyleBackColor = true;
            chkModbusLastSentAddressEnabled.CheckedChanged += chkModbusLastSentEnabled_CheckedChanged;
            // 
            // lblAlarm2ModbusSendAddress
            // 
            lblAlarm2ModbusSendAddress.AutoSize = true;
            lblAlarm2ModbusSendAddress.Location = new Point(22, 384);
            lblAlarm2ModbusSendAddress.Name = "lblAlarm2ModbusSendAddress";
            lblAlarm2ModbusSendAddress.Size = new Size(51, 15);
            lblAlarm2ModbusSendAddress.TabIndex = 73;
            lblAlarm2ModbusSendAddress.Text = "Alarm 2:";
            // 
            // txtFilterHPModbusLastSentAddress
            // 
            txtFilterHPModbusLastSentAddress.Location = new Point(315, 321);
            txtFilterHPModbusLastSentAddress.Name = "txtFilterHPModbusLastSentAddress";
            txtFilterHPModbusLastSentAddress.Size = new Size(100, 23);
            txtFilterHPModbusLastSentAddress.TabIndex = 68;
            txtFilterHPModbusLastSentAddress.LostFocus += txtFilterHPModbusLastSentAddress_LostFocus;
            // 
            // lblAlarm1ModbusSendAddress
            // 
            lblAlarm1ModbusSendAddress.AutoSize = true;
            lblAlarm1ModbusSendAddress.Location = new Point(22, 355);
            lblAlarm1ModbusSendAddress.Name = "lblAlarm1ModbusSendAddress";
            lblAlarm1ModbusSendAddress.Size = new Size(51, 15);
            lblAlarm1ModbusSendAddress.TabIndex = 74;
            lblAlarm1ModbusSendAddress.Text = "Alarm 1:";
            // 
            // txtFilterLPModbusLastSentAddress
            // 
            txtFilterLPModbusLastSentAddress.Location = new Point(315, 292);
            txtFilterLPModbusLastSentAddress.Name = "txtFilterLPModbusLastSentAddress";
            txtFilterLPModbusLastSentAddress.Size = new Size(100, 23);
            txtFilterLPModbusLastSentAddress.TabIndex = 67;
            txtFilterLPModbusLastSentAddress.LostFocus += txtFilterLPModbusLastSentAddress_LostFocus;
            // 
            // txtAlarm1ModbusAddress
            // 
            txtAlarm1ModbusAddress.Location = new Point(78, 350);
            txtAlarm1ModbusAddress.Name = "txtAlarm1ModbusAddress";
            txtAlarm1ModbusAddress.Size = new Size(100, 23);
            txtAlarm1ModbusAddress.TabIndex = 60;
            txtAlarm1ModbusAddress.LostFocus += txtAlarm1ModbusAddress_LostFocus;
            // 
            // txtPhaseModbusLastSentAddress
            // 
            txtPhaseModbusLastSentAddress.Location = new Point(315, 263);
            txtPhaseModbusLastSentAddress.Name = "txtPhaseModbusLastSentAddress";
            txtPhaseModbusLastSentAddress.Size = new Size(100, 23);
            txtPhaseModbusLastSentAddress.TabIndex = 66;
            txtPhaseModbusLastSentAddress.LostFocus += txtPhaseModbusLastSentAddress_LostFocus;
            // 
            // txtAlarm2ModbusAddress
            // 
            txtAlarm2ModbusAddress.Location = new Point(79, 379);
            txtAlarm2ModbusAddress.Name = "txtAlarm2ModbusAddress";
            txtAlarm2ModbusAddress.Size = new Size(100, 23);
            txtAlarm2ModbusAddress.TabIndex = 61;
            txtAlarm2ModbusAddress.LostFocus += txtAlarm2ModbusAddress_LostFocus;
            // 
            // txtGainYModbusLastSentAddress
            // 
            txtGainYModbusLastSentAddress.Location = new Point(315, 234);
            txtGainYModbusLastSentAddress.Name = "txtGainYModbusLastSentAddress";
            txtGainYModbusLastSentAddress.Size = new Size(100, 23);
            txtGainYModbusLastSentAddress.TabIndex = 65;
            txtGainYModbusLastSentAddress.LostFocus += txtGainYModbusLastSentAddress_LostFocus;
            // 
            // lblModbusLastSentValueAdress
            // 
            lblModbusLastSentValueAdress.AutoSize = true;
            lblModbusLastSentValueAdress.Location = new Point(309, 129);
            lblModbusLastSentValueAdress.Name = "lblModbusLastSentValueAdress";
            lblModbusLastSentValueAdress.Size = new Size(133, 15);
            lblModbusLastSentValueAdress.TabIndex = 1010;
            lblModbusLastSentValueAdress.Text = "Last Sent Value Address:";
            // 
            // txtGainXModbusLastSentAddress
            // 
            txtGainXModbusLastSentAddress.Location = new Point(315, 205);
            txtGainXModbusLastSentAddress.Name = "txtGainXModbusLastSentAddress";
            txtGainXModbusLastSentAddress.Size = new Size(100, 23);
            txtGainXModbusLastSentAddress.TabIndex = 64;
            txtGainXModbusLastSentAddress.LostFocus += txtGainXModbusLastSentAddress_LostFocus;
            // 
            // txtFrequencyModbusLastSentAddress
            // 
            txtFrequencyModbusLastSentAddress.Location = new Point(315, 176);
            txtFrequencyModbusLastSentAddress.Name = "txtFrequencyModbusLastSentAddress";
            txtFrequencyModbusLastSentAddress.Size = new Size(100, 23);
            txtFrequencyModbusLastSentAddress.TabIndex = 63;
            txtFrequencyModbusLastSentAddress.LostFocus += txtFrequencyModbusLastSentAddress_LostFocus;
            // 
            // txtMaxPoints
            // 
            txtMaxPoints.Location = new Point(224, 778);
            txtMaxPoints.Name = "txtMaxPoints";
            txtMaxPoints.Size = new Size(100, 23);
            txtMaxPoints.TabIndex = 27;
            txtMaxPoints.LostFocus += txtMaxPoints_LostFocus;
            // 
            // lblMaxPointsSettable
            // 
            lblMaxPointsSettable.Location = new Point(23, 782);
            lblMaxPointsSettable.Name = "lblMaxPointsSettable";
            lblMaxPointsSettable.Size = new Size(200, 15);
            lblMaxPointsSettable.TabIndex = 110;
            lblMaxPointsSettable.Text = "Maximum Amount of Points Allowed:";
            lblMaxPointsSettable.TextAlign = ContentAlignment.MiddleRight;
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
            pctrInternationalization.BorderStyle = BorderStyle.FixedSingle;
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
            chkScatterDrawPoints.Location = new Point(106, 753);
            chkScatterDrawPoints.Name = "chkScatterDrawPoints";
            chkScatterDrawPoints.Size = new Size(220, 19);
            chkScatterDrawPoints.TabIndex = 26;
            chkScatterDrawPoints.Text = "Scatter Draw Points?";
            chkScatterDrawPoints.TextAlign = ContentAlignment.MiddleCenter;
            chkScatterDrawPoints.UseVisualStyleBackColor = true;
            chkScatterDrawPoints.CheckedChanged += chkScatterDrawPoints_CheckedChanged;
            // 
            // txtScatterDiagColor
            // 
            txtScatterDiagColor.Location = new Point(224, 691);
            txtScatterDiagColor.Name = "txtScatterDiagColor";
            txtScatterDiagColor.Size = new Size(100, 23);
            txtScatterDiagColor.TabIndex = 24;
            txtScatterDiagColor.LostFocus += txtScatterDiagColor_LostFocus;
            // 
            // txtLineDiagColorY
            // 
            txtLineDiagColorY.Location = new Point(224, 662);
            txtLineDiagColorY.Name = "txtLineDiagColorY";
            txtLineDiagColorY.Size = new Size(100, 23);
            txtLineDiagColorY.TabIndex = 23;
            txtLineDiagColorY.LostFocus += txtLineDiagYColor_LostFocus;
            // 
            // txtLineDiagColorX
            // 
            txtLineDiagColorX.Location = new Point(224, 633);
            txtLineDiagColorX.Name = "txtLineDiagColorX";
            txtLineDiagColorX.Size = new Size(100, 23);
            txtLineDiagColorX.TabIndex = 22;
            txtLineDiagColorX.LostFocus += txtLineDiagColorX_LostFocus;
            // 
            // txtAlarm2Color
            // 
            txtAlarm2Color.Location = new Point(224, 604);
            txtAlarm2Color.Name = "txtAlarm2Color";
            txtAlarm2Color.Size = new Size(100, 23);
            txtAlarm2Color.TabIndex = 21;
            txtAlarm2Color.LostFocus += txtAlarm2Color_LostFocus;
            // 
            // txtAlarm1Color
            // 
            txtAlarm1Color.Location = new Point(224, 575);
            txtAlarm1Color.Name = "txtAlarm1Color";
            txtAlarm1Color.Size = new Size(100, 23);
            txtAlarm1Color.TabIndex = 20;
            txtAlarm1Color.LostFocus += txtAlarm1Color_LostFocus;
            // 
            // lblScatterColor
            // 
            lblScatterColor.Location = new Point(23, 695);
            lblScatterColor.Name = "lblScatterColor";
            lblScatterColor.Size = new Size(200, 15);
            lblScatterColor.TabIndex = 100;
            lblScatterColor.Text = "Scatter Color:";
            lblScatterColor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblColorY
            // 
            lblColorY.Location = new Point(23, 666);
            lblColorY.Name = "lblColorY";
            lblColorY.Size = new Size(200, 15);
            lblColorY.TabIndex = 98;
            lblColorY.Text = "Y Color:";
            lblColorY.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAlarm2Color
            // 
            lblAlarm2Color.Location = new Point(23, 608);
            lblAlarm2Color.Name = "lblAlarm2Color";
            lblAlarm2Color.Size = new Size(200, 15);
            lblAlarm2Color.TabIndex = 97;
            lblAlarm2Color.Text = "Alarm 2 Color:";
            lblAlarm2Color.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblColorX
            // 
            lblColorX.Location = new Point(23, 637);
            lblColorX.Name = "lblColorX";
            lblColorX.Size = new Size(200, 15);
            lblColorX.TabIndex = 96;
            lblColorX.Text = "X Color:";
            lblColorX.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAlarm1Color
            // 
            lblAlarm1Color.Location = new Point(23, 579);
            lblAlarm1Color.Name = "lblAlarm1Color";
            lblAlarm1Color.Size = new Size(200, 15);
            lblAlarm1Color.TabIndex = 96;
            lblAlarm1Color.Text = "Alarm 1 Color:";
            lblAlarm1Color.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLineDiagSizeY
            // 
            lblLineDiagSizeY.Location = new Point(23, 550);
            lblLineDiagSizeY.Name = "lblLineDiagSizeY";
            lblLineDiagSizeY.Size = new Size(200, 15);
            lblLineDiagSizeY.TabIndex = 65;
            lblLineDiagSizeY.Text = "Line Diag. Size Y:";
            lblLineDiagSizeY.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLineDiagSizeX
            // 
            lblLineDiagSizeX.Location = new Point(23, 521);
            lblLineDiagSizeX.Name = "lblLineDiagSizeX";
            lblLineDiagSizeX.Size = new Size(200, 15);
            lblLineDiagSizeX.TabIndex = 64;
            lblLineDiagSizeX.Text = "Line Diag. Size X:";
            lblLineDiagSizeX.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLineDiagPosY
            // 
            lblLineDiagPosY.Location = new Point(23, 492);
            lblLineDiagPosY.Name = "lblLineDiagPosY";
            lblLineDiagPosY.Size = new Size(200, 15);
            lblLineDiagPosY.TabIndex = 63;
            lblLineDiagPosY.Text = "Line Diag. Pos. Y:";
            lblLineDiagPosY.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLineDiagPosX
            // 
            lblLineDiagPosX.Location = new Point(23, 463);
            lblLineDiagPosX.Name = "lblLineDiagPosX";
            lblLineDiagPosX.Size = new Size(200, 15);
            lblLineDiagPosX.TabIndex = 62;
            lblLineDiagPosX.Text = "Line Diag. Pos. X:";
            lblLineDiagPosX.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtLineDiagSizeY
            // 
            txtLineDiagSizeY.Location = new Point(224, 546);
            txtLineDiagSizeY.Name = "txtLineDiagSizeY";
            txtLineDiagSizeY.Size = new Size(100, 23);
            txtLineDiagSizeY.TabIndex = 19;
            txtLineDiagSizeY.LostFocus += txtLineDiagSizeY_LostFocus;
            // 
            // txtLineDiagSizeX
            // 
            txtLineDiagSizeX.Location = new Point(224, 517);
            txtLineDiagSizeX.Name = "txtLineDiagSizeX";
            txtLineDiagSizeX.Size = new Size(100, 23);
            txtLineDiagSizeX.TabIndex = 18;
            txtLineDiagSizeX.LostFocus += txtLineDiagSizeX_LostFocus;
            // 
            // txtLineDiagPosY
            // 
            txtLineDiagPosY.Location = new Point(224, 488);
            txtLineDiagPosY.Name = "txtLineDiagPosY";
            txtLineDiagPosY.Size = new Size(100, 23);
            txtLineDiagPosY.TabIndex = 17;
            txtLineDiagPosY.LostFocus += txtLineDiagPosY_LostFocus;
            // 
            // txtLineDiagPosX
            // 
            txtLineDiagPosX.Location = new Point(224, 459);
            txtLineDiagPosX.Name = "txtLineDiagPosX";
            txtLineDiagPosX.Size = new Size(100, 23);
            txtLineDiagPosX.TabIndex = 16;
            txtLineDiagPosX.LostFocus += txtLineDiagPosX_LostFocus;
            // 
            // lblScatterDiagSize
            // 
            lblScatterDiagSize.Location = new Point(23, 434);
            lblScatterDiagSize.Name = "lblScatterDiagSize";
            lblScatterDiagSize.Size = new Size(200, 15);
            lblScatterDiagSize.TabIndex = 57;
            lblScatterDiagSize.Text = "Scatter Diag. Size:";
            lblScatterDiagSize.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblScatterDiagPosY
            // 
            lblScatterDiagPosY.Location = new Point(23, 405);
            lblScatterDiagPosY.Name = "lblScatterDiagPosY";
            lblScatterDiagPosY.Size = new Size(200, 15);
            lblScatterDiagPosY.TabIndex = 56;
            lblScatterDiagPosY.Text = "Scatter Diag. Pos. Y:";
            lblScatterDiagPosY.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtScatterDiagSize
            // 
            txtScatterDiagSize.Location = new Point(224, 430);
            txtScatterDiagSize.Name = "txtScatterDiagSize";
            txtScatterDiagSize.Size = new Size(100, 23);
            txtScatterDiagSize.TabIndex = 15;
            txtScatterDiagSize.LostFocus += txtScatterDiagSize_LostFocus;
            // 
            // txtScatterDiagPosY
            // 
            txtScatterDiagPosY.Location = new Point(224, 401);
            txtScatterDiagPosY.Name = "txtScatterDiagPosY";
            txtScatterDiagPosY.Size = new Size(100, 23);
            txtScatterDiagPosY.TabIndex = 14;
            txtScatterDiagPosY.LostFocus += txtScatterDiagPosY_LostFocus;
            // 
            // txtScatterDiagPosX
            // 
            txtScatterDiagPosX.Location = new Point(224, 372);
            txtScatterDiagPosX.Name = "txtScatterDiagPosX";
            txtScatterDiagPosX.Size = new Size(100, 23);
            txtScatterDiagPosX.TabIndex = 13;
            txtScatterDiagPosX.LostFocus += txtScatterDiagPosX_LostFocus;
            // 
            // lblScatterDiagPosX
            // 
            lblScatterDiagPosX.Location = new Point(23, 376);
            lblScatterDiagPosX.Name = "lblScatterDiagPosX";
            lblScatterDiagPosX.Size = new Size(200, 15);
            lblScatterDiagPosX.TabIndex = 53;
            lblScatterDiagPosX.Text = "Scatter Diag. Pos. X:";
            lblScatterDiagPosX.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblScatterAmount
            // 
            lblScatterAmount.Location = new Point(23, 260);
            lblScatterAmount.Name = "lblScatterAmount";
            lblScatterAmount.Size = new Size(200, 15);
            lblScatterAmount.TabIndex = 40;
            lblScatterAmount.Text = "Amount of Points in Scatter:";
            lblScatterAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtScatterPoints
            // 
            txtScatterPoints.Location = new Point(224, 256);
            txtScatterPoints.Name = "txtScatterPoints";
            txtScatterPoints.Size = new Size(100, 23);
            txtScatterPoints.TabIndex = 9;
            txtScatterPoints.LostFocus += txtScatterPoints_LostFocus;
            // 
            // lblDiagMaxPointSize
            // 
            lblDiagMaxPointSize.Location = new Point(23, 231);
            lblDiagMaxPointSize.Name = "lblDiagMaxPointSize";
            lblDiagMaxPointSize.Size = new Size(200, 15);
            lblDiagMaxPointSize.TabIndex = 51;
            lblDiagMaxPointSize.Text = "Diagram Max. Point Height:";
            lblDiagMaxPointSize.TextAlign = ContentAlignment.BottomRight;
            // 
            // txtDiagMaxPointSize
            // 
            txtDiagMaxPointSize.Location = new Point(224, 227);
            txtDiagMaxPointSize.Name = "txtDiagMaxPointSize";
            txtDiagMaxPointSize.Size = new Size(100, 23);
            txtDiagMaxPointSize.TabIndex = 8;
            txtDiagMaxPointSize.LostFocus += txtLineDiagHeight_LostFocus;
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
            // txtLineDiagPoints
            // 
            txtLineDiagPoints.Location = new Point(224, 198);
            txtLineDiagPoints.Name = "txtLineDiagPoints";
            txtLineDiagPoints.Size = new Size(100, 23);
            txtLineDiagPoints.TabIndex = 7;
            txtLineDiagPoints.LostFocus += txtLineDiagPoints_LostFocus;
            // 
            // txtCOMPort
            // 
            txtCOMPort.Location = new Point(224, 343);
            txtCOMPort.Name = "txtCOMPort";
            txtCOMPort.Size = new Size(100, 23);
            txtCOMPort.TabIndex = 12;
            txtCOMPort.LostFocus += txtCOMPort_LostFocus;
            // 
            // lblComport
            // 
            lblComport.Location = new Point(23, 347);
            lblComport.Name = "lblComport";
            lblComport.Size = new Size(200, 15);
            lblComport.TabIndex = 46;
            lblComport.Text = "COM-Port:";
            lblComport.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtX
            // 
            txtX.Location = new Point(224, 111);
            txtX.Name = "txtX";
            txtX.ReadOnly = true;
            txtX.Size = new Size(100, 23);
            txtX.TabIndex = 0;
            txtX.TabStop = false;
            // 
            // txtAlarm2Value
            // 
            txtAlarm2Value.Location = new Point(224, 314);
            txtAlarm2Value.Name = "txtAlarm2Value";
            txtAlarm2Value.Size = new Size(100, 23);
            txtAlarm2Value.TabIndex = 11;
            txtAlarm2Value.LostFocus += txtAlarm2Value_LostFocus;
            // 
            // txtY
            // 
            txtY.Location = new Point(224, 140);
            txtY.Name = "txtY";
            txtY.ReadOnly = true;
            txtY.Size = new Size(100, 23);
            txtY.TabIndex = 1;
            txtY.TabStop = false;
            // 
            // txtAlarm1Value
            // 
            txtAlarm1Value.Location = new Point(224, 285);
            txtAlarm1Value.Name = "txtAlarm1Value";
            txtAlarm1Value.Size = new Size(100, 23);
            txtAlarm1Value.TabIndex = 10;
            txtAlarm1Value.LostFocus += txtAlarm1Value_LostFocus;
            // 
            // txtPS
            // 
            txtPS.Location = new Point(224, 169);
            txtPS.Name = "txtPS";
            txtPS.ReadOnly = true;
            txtPS.Size = new Size(100, 23);
            txtPS.TabIndex = 2;
            txtPS.TabStop = false;
            // 
            // lblPS
            // 
            lblPS.Location = new Point(23, 173);
            lblPS.Name = "lblPS";
            lblPS.Size = new Size(200, 15);
            lblPS.TabIndex = 3;
            lblPS.Text = "P/S";
            lblPS.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAlarm1
            // 
            lblAlarm1.Location = new Point(23, 289);
            lblAlarm1.Name = "lblAlarm1";
            lblAlarm1.Size = new Size(200, 15);
            lblAlarm1.TabIndex = 21;
            lblAlarm1.Text = "Alarm 1:";
            lblAlarm1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblYVal
            // 
            lblYVal.Location = new Point(23, 144);
            lblYVal.Name = "lblYVal";
            lblYVal.Size = new Size(200, 15);
            lblYVal.TabIndex = 4;
            lblYVal.Text = "Y-Values";
            lblYVal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblXVal
            // 
            lblXVal.Location = new Point(23, 115);
            lblXVal.Name = "lblXVal";
            lblXVal.Size = new Size(200, 15);
            lblXVal.TabIndex = 5;
            lblXVal.Text = "X-Values";
            lblXVal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAlarm2
            // 
            lblAlarm2.Location = new Point(23, 318);
            lblAlarm2.Name = "lblAlarm2";
            lblAlarm2.Size = new Size(200, 15);
            lblAlarm2.TabIndex = 19;
            lblAlarm2.Text = "Alarm 2:";
            lblAlarm2.TextAlign = ContentAlignment.MiddleRight;
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
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            panelInfluxDBSettings.ResumeLayout(false);
            panelInfluxDBSettings.PerformLayout();
            panelModbusSettings.ResumeLayout(false);
            panelModbusSettings.PerformLayout();
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
        private TextBox txtMaxPoints;
        private Label lblMaxPointsSettable;
        private Panel panelModbusSettings;
        private Label lblModbusAlarmExpl;
        private Panel panelInfluxDBSettings;
        private Panel panelPassword;
        private CheckBox chkEqualGain;
    }
}