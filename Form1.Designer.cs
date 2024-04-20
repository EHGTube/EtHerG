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
            lblInflux = new Label();
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
            tabPage1.Text = "tabPage1";
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
            txtFilterHPLast.Location = new Point(188, 157);
            txtFilterHPLast.Name = "txtFilterHPLast";
            txtFilterHPLast.ReadOnly = true;
            txtFilterHPLast.Size = new Size(100, 23);
            txtFilterHPLast.TabIndex = 18;
            // 
            // txtFilterLPLast
            // 
            txtFilterLPLast.Location = new Point(188, 128);
            txtFilterLPLast.Name = "txtFilterLPLast";
            txtFilterLPLast.ReadOnly = true;
            txtFilterLPLast.Size = new Size(100, 23);
            txtFilterLPLast.TabIndex = 17;
            // 
            // txtPhaseLast
            // 
            txtPhaseLast.Location = new Point(188, 99);
            txtPhaseLast.Name = "txtPhaseLast";
            txtPhaseLast.ReadOnly = true;
            txtPhaseLast.Size = new Size(100, 23);
            txtPhaseLast.TabIndex = 16;
            // 
            // txtGainYLast
            // 
            txtGainYLast.Location = new Point(188, 70);
            txtGainYLast.Name = "txtGainYLast";
            txtGainYLast.ReadOnly = true;
            txtGainYLast.Size = new Size(100, 23);
            txtGainYLast.TabIndex = 15;
            // 
            // txtGainXLast
            // 
            txtGainXLast.Location = new Point(188, 41);
            txtGainXLast.Name = "txtGainXLast";
            txtGainXLast.ReadOnly = true;
            txtGainXLast.Size = new Size(100, 23);
            txtGainXLast.TabIndex = 14;
            // 
            // txtFrequencyLast
            // 
            txtFrequencyLast.Location = new Point(188, 12);
            txtFrequencyLast.Name = "txtFrequencyLast";
            txtFrequencyLast.ReadOnly = true;
            txtFrequencyLast.Size = new Size(100, 23);
            txtFrequencyLast.TabIndex = 13;
            // 
            // lblFilterHP
            // 
            lblFilterHP.AutoSize = true;
            lblFilterHP.Location = new Point(24, 160);
            lblFilterHP.Name = "lblFilterHP";
            lblFilterHP.Size = new Size(55, 15);
            lblFilterHP.TabIndex = 12;
            lblFilterHP.Text = "Filter HP:";
            // 
            // lblFilterLP
            // 
            lblFilterLP.AutoSize = true;
            lblFilterLP.Location = new Point(24, 131);
            lblFilterLP.Name = "lblFilterLP";
            lblFilterLP.Size = new Size(52, 15);
            lblFilterLP.TabIndex = 11;
            lblFilterLP.Text = "Filter LP:";
            // 
            // lblPhase
            // 
            lblPhase.AutoSize = true;
            lblPhase.Location = new Point(38, 102);
            lblPhase.Name = "lblPhase";
            lblPhase.Size = new Size(41, 15);
            lblPhase.TabIndex = 9;
            lblPhase.Text = "Phase:";
            // 
            // lblGainY
            // 
            lblGainY.AutoSize = true;
            lblGainY.Location = new Point(32, 73);
            lblGainY.Name = "lblGainY";
            lblGainY.Size = new Size(44, 15);
            lblGainY.TabIndex = 8;
            lblGainY.Text = "Gain Y:";
            // 
            // lblGainX
            // 
            lblGainX.AutoSize = true;
            lblGainX.Location = new Point(32, 44);
            lblGainX.Name = "lblGainX";
            lblGainX.Size = new Size(44, 15);
            lblGainX.TabIndex = 7;
            lblGainX.Text = "Gain X:";
            // 
            // txtFilterHPUserInput
            // 
            txtFilterHPUserInput.Location = new Point(82, 157);
            txtFilterHPUserInput.Name = "txtFilterHPUserInput";
            txtFilterHPUserInput.Size = new Size(100, 23);
            txtFilterHPUserInput.TabIndex = 6;
            txtFilterHPUserInput.LostFocus += txtFilterHPUserInput_LostFocus;
            // 
            // txtFilterLPUserInput
            // 
            txtFilterLPUserInput.Location = new Point(82, 128);
            txtFilterLPUserInput.Name = "txtFilterLPUserInput";
            txtFilterLPUserInput.Size = new Size(100, 23);
            txtFilterLPUserInput.TabIndex = 5;
            txtFilterLPUserInput.LostFocus += txtFilterLPUserInput_LostFocus;
            // 
            // txtPhaseUserInput
            // 
            txtPhaseUserInput.Location = new Point(82, 99);
            txtPhaseUserInput.Name = "txtPhaseUserInput";
            txtPhaseUserInput.Size = new Size(100, 23);
            txtPhaseUserInput.TabIndex = 4;
            txtPhaseUserInput.LostFocus += txtPhaseUserInput_LostFocus;
            // 
            // txtGainYUserInput
            // 
            txtGainYUserInput.Location = new Point(82, 70);
            txtGainYUserInput.Name = "txtGainYUserInput";
            txtGainYUserInput.Size = new Size(100, 23);
            txtGainYUserInput.TabIndex = 3;
            txtGainYUserInput.LostFocus += txtGainYUserInput_LostFocus;
            // 
            // txtGainXUserInput
            // 
            txtGainXUserInput.Location = new Point(82, 41);
            txtGainXUserInput.Name = "txtGainXUserInput";
            txtGainXUserInput.Size = new Size(100, 23);
            txtGainXUserInput.TabIndex = 2;
            txtGainXUserInput.LostFocus += txtGainXUserInput_LostFocus;
            // 
            // txtFrequencyUserInput
            // 
            txtFrequencyUserInput.Location = new Point(82, 12);
            txtFrequencyUserInput.Name = "txtFrequencyUserInput";
            txtFrequencyUserInput.Size = new Size(100, 23);
            txtFrequencyUserInput.TabIndex = 1;
            txtFrequencyUserInput.LostFocus += txtFrequencyUserInput_LostFocus;
            // 
            // lblFrequency
            // 
            lblFrequency.AutoSize = true;
            lblFrequency.Location = new Point(14, 15);
            lblFrequency.Name = "lblFrequency";
            lblFrequency.Size = new Size(65, 15);
            lblFrequency.TabIndex = 0;
            lblFrequency.Text = "Frequency:";
            // 
            // panelMain
            // 
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
            // chkModbusAutoconnect
            // 
            chkModbusAutoconnect.AutoSize = true;
            chkModbusAutoconnect.Location = new Point(756, 37);
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
            chkEtherAutoconnect.Location = new Point(756, 15);
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
            chkShowY.Location = new Point(679, 37);
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
            chkShowX.Location = new Point(679, 15);
            chkShowX.Name = "chkShowX";
            chkShowX.Size = new Size(71, 19);
            chkShowX.TabIndex = 7;
            chkShowX.Text = "X-Values";
            chkShowX.UseVisualStyleBackColor = true;
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
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblInflux);
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
            // lblInflux
            // 
            lblInflux.AutoSize = true;
            lblInflux.Location = new Point(423, 467);
            lblInflux.Name = "lblInflux";
            lblInflux.Size = new Size(38, 15);
            lblInflux.TabIndex = 73;
            lblInflux.Text = "label1";
            // 
            // chkDisableUserInput
            // 
            chkDisableUserInput.AutoSize = true;
            chkDisableUserInput.Location = new Point(423, 84);
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
            lblModbusReadValue.Location = new Point(543, 205);
            lblModbusReadValue.Name = "lblModbusReadValue";
            lblModbusReadValue.Size = new Size(105, 15);
            lblModbusReadValue.TabIndex = 70;
            lblModbusReadValue.Text = "ModbusReadValue";
            // 
            // lblModbusReadAdresses
            // 
            lblModbusReadAdresses.AutoSize = true;
            lblModbusReadAdresses.Location = new Point(409, 203);
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
            lblLineDiagSizeY.AutoSize = true;
            lblLineDiagSizeY.Location = new Point(126, 558);
            lblLineDiagSizeY.Name = "lblLineDiagSizeY";
            lblLineDiagSizeY.Size = new Size(95, 15);
            lblLineDiagSizeY.TabIndex = 65;
            lblLineDiagSizeY.Text = "Line Diag. Size Y:";
            // 
            // lblLineDiagSizeX
            // 
            lblLineDiagSizeX.AutoSize = true;
            lblLineDiagSizeX.Location = new Point(126, 529);
            lblLineDiagSizeX.Name = "lblLineDiagSizeX";
            lblLineDiagSizeX.Size = new Size(95, 15);
            lblLineDiagSizeX.TabIndex = 64;
            lblLineDiagSizeX.Text = "Line Diag. Size X:";
            // 
            // lblLineDiagPosY
            // 
            lblLineDiagPosY.AutoSize = true;
            lblLineDiagPosY.Location = new Point(124, 500);
            lblLineDiagPosY.Name = "lblLineDiagPosY";
            lblLineDiagPosY.Size = new Size(97, 15);
            lblLineDiagPosY.TabIndex = 63;
            lblLineDiagPosY.Text = "Line Diag. Pos. Y:";
            // 
            // lblLineDiagPosX
            // 
            lblLineDiagPosX.AutoSize = true;
            lblLineDiagPosX.Location = new Point(124, 471);
            lblLineDiagPosX.Name = "lblLineDiagPosX";
            lblLineDiagPosX.Size = new Size(97, 15);
            lblLineDiagPosX.TabIndex = 62;
            lblLineDiagPosX.Text = "Line Diag. Pos. X:";
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
            lblScatterDiagSize.AutoSize = true;
            lblScatterDiagSize.Location = new Point(122, 442);
            lblScatterDiagSize.Name = "lblScatterDiagSize";
            lblScatterDiagSize.Size = new Size(99, 15);
            lblScatterDiagSize.TabIndex = 57;
            lblScatterDiagSize.Text = "Scatter Diag. Size:";
            // 
            // lblScatterDiagPosY
            // 
            lblScatterDiagPosY.AutoSize = true;
            lblScatterDiagPosY.Location = new Point(110, 413);
            lblScatterDiagPosY.Name = "lblScatterDiagPosY";
            lblScatterDiagPosY.Size = new Size(111, 15);
            lblScatterDiagPosY.TabIndex = 56;
            lblScatterDiagPosY.Text = "Scatter Diag. Pos. Y:";
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
            txtFilterHPLastModbusValue.Location = new Point(542, 402);
            txtFilterHPLastModbusValue.Name = "txtFilterHPLastModbusValue";
            txtFilterHPLastModbusValue.ReadOnly = true;
            txtFilterHPLastModbusValue.Size = new Size(100, 23);
            txtFilterHPLastModbusValue.TabIndex = 39;
            // 
            // lblScatterDiagPosX
            // 
            lblScatterDiagPosX.AutoSize = true;
            lblScatterDiagPosX.Location = new Point(110, 384);
            lblScatterDiagPosX.Name = "lblScatterDiagPosX";
            lblScatterDiagPosX.Size = new Size(111, 15);
            lblScatterDiagPosX.TabIndex = 53;
            lblScatterDiagPosX.Text = "Scatter Diag. Pos. X:";
            // 
            // txtFilterLPLastModbusValue
            // 
            txtFilterLPLastModbusValue.Location = new Point(542, 373);
            txtFilterLPLastModbusValue.Name = "txtFilterLPLastModbusValue";
            txtFilterLPLastModbusValue.ReadOnly = true;
            txtFilterLPLastModbusValue.Size = new Size(100, 23);
            txtFilterLPLastModbusValue.TabIndex = 38;
            // 
            // txtPhaseLastModbusValue
            // 
            txtPhaseLastModbusValue.Location = new Point(542, 344);
            txtPhaseLastModbusValue.Name = "txtPhaseLastModbusValue";
            txtPhaseLastModbusValue.ReadOnly = true;
            txtPhaseLastModbusValue.Size = new Size(100, 23);
            txtPhaseLastModbusValue.TabIndex = 37;
            // 
            // lblScatterAmount
            // 
            lblScatterAmount.AutoSize = true;
            lblScatterAmount.Location = new Point(65, 264);
            lblScatterAmount.Name = "lblScatterAmount";
            lblScatterAmount.Size = new Size(156, 15);
            lblScatterAmount.TabIndex = 40;
            lblScatterAmount.Text = "Amount of Points in Scatter:";
            // 
            // txtGainYLastModbusValue
            // 
            txtGainYLastModbusValue.Location = new Point(542, 315);
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
            txtGainXLastModbusValue.Location = new Point(542, 289);
            txtGainXLastModbusValue.Name = "txtGainXLastModbusValue";
            txtGainXLastModbusValue.ReadOnly = true;
            txtGainXLastModbusValue.Size = new Size(100, 23);
            txtGainXLastModbusValue.TabIndex = 35;
            // 
            // lblDiagMaxPointSize
            // 
            lblDiagMaxPointSize.AutoSize = true;
            lblDiagMaxPointSize.Location = new Point(62, 231);
            lblDiagMaxPointSize.Name = "lblDiagMaxPointSize";
            lblDiagMaxPointSize.Size = new Size(151, 15);
            lblDiagMaxPointSize.TabIndex = 51;
            lblDiagMaxPointSize.Text = "Diagram Max. Point Height";
            // 
            // txtFrequencyLastModbusValue
            // 
            txtFrequencyLastModbusValue.Location = new Point(543, 260);
            txtFrequencyLastModbusValue.Name = "txtFrequencyLastModbusValue";
            txtFrequencyLastModbusValue.ReadOnly = true;
            txtFrequencyLastModbusValue.Size = new Size(100, 23);
            txtFrequencyLastModbusValue.TabIndex = 34;
            // 
            // lblModbusServerIP
            // 
            lblModbusServerIP.AutoSize = true;
            lblModbusServerIP.Location = new Point(373, 115);
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
            lblModbusServerPort.Location = new Point(364, 143);
            lblModbusServerPort.Name = "lblModbusServerPort";
            lblModbusServerPort.Size = new Size(114, 15);
            lblModbusServerPort.TabIndex = 43;
            lblModbusServerPort.Text = "Modbus Server Port:";
            // 
            // txtPlayLastModbusValue
            // 
            txtPlayLastModbusValue.Location = new Point(543, 223);
            txtPlayLastModbusValue.Name = "txtPlayLastModbusValue";
            txtPlayLastModbusValue.ReadOnly = true;
            txtPlayLastModbusValue.Size = new Size(100, 23);
            txtPlayLastModbusValue.TabIndex = 31;
            // 
            // lblLineDiagAmount
            // 
            lblLineDiagAmount.AutoSize = true;
            lblLineDiagAmount.Location = new Point(55, 202);
            lblLineDiagAmount.Name = "lblLineDiagAmount";
            lblLineDiagAmount.Size = new Size(166, 15);
            lblLineDiagAmount.TabIndex = 49;
            lblLineDiagAmount.Text = "Amount of Points in LineDiag:";
            // 
            // txtFilterHPModbusAddress
            // 
            txtFilterHPModbusAddress.Location = new Point(423, 402);
            txtFilterHPModbusAddress.Name = "txtFilterHPModbusAddress";
            txtFilterHPModbusAddress.Size = new Size(100, 23);
            txtFilterHPModbusAddress.TabIndex = 30;
            txtFilterHPModbusAddress.LostFocus += txtFilterHPModbusAddress_LostFocus;
            // 
            // txtModbusServerIP
            // 
            txtModbusServerIP.Location = new Point(475, 111);
            txtModbusServerIP.Name = "txtModbusServerIP";
            txtModbusServerIP.Size = new Size(100, 23);
            txtModbusServerIP.TabIndex = 44;
            txtModbusServerIP.LostFocus += txtModbusServerIP_LostFocus;
            // 
            // txtFilterLPModbusAddress
            // 
            txtFilterLPModbusAddress.Location = new Point(423, 373);
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
            txtPhaseModbusAddress.Location = new Point(423, 344);
            txtPhaseModbusAddress.Name = "txtPhaseModbusAddress";
            txtPhaseModbusAddress.Size = new Size(100, 23);
            txtPhaseModbusAddress.TabIndex = 28;
            txtPhaseModbusAddress.LostFocus += txtPhaseModbusAddress_LostFocus;
            // 
            // txtModbusServerPort
            // 
            txtModbusServerPort.Location = new Point(475, 140);
            txtModbusServerPort.Name = "txtModbusServerPort";
            txtModbusServerPort.Size = new Size(100, 23);
            txtModbusServerPort.TabIndex = 45;
            txtModbusServerPort.LostFocus += txtModbusServerPort_LostFocus;
            // 
            // txtGainYModbusAddress
            // 
            txtGainYModbusAddress.Location = new Point(423, 315);
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
            txtGainXModbusAddress.Location = new Point(423, 289);
            txtGainXModbusAddress.Name = "txtGainXModbusAddress";
            txtGainXModbusAddress.Size = new Size(100, 23);
            txtGainXModbusAddress.TabIndex = 26;
            txtGainXModbusAddress.LostFocus += txtGainXModbusAddress_LostFocus;
            // 
            // lblComport
            // 
            lblComport.AutoSize = true;
            lblComport.Location = new Point(158, 355);
            lblComport.Name = "lblComport";
            lblComport.Size = new Size(65, 15);
            lblComport.TabIndex = 46;
            lblComport.Text = "COM-Port:";
            // 
            // txtFrequencyModbusAddress
            // 
            txtFrequencyModbusAddress.Location = new Point(423, 260);
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
            txtPlayModbusAddress.Location = new Point(424, 223);
            txtPlayModbusAddress.Name = "txtPlayModbusAddress";
            txtPlayModbusAddress.Size = new Size(100, 23);
            txtPlayModbusAddress.TabIndex = 22;
            txtPlayModbusAddress.LostFocus += txtPlayModbusAddress_LostFocus;
            // 
            // lblPS
            // 
            lblPS.AutoSize = true;
            lblPS.Location = new Point(196, 173);
            lblPS.Name = "lblPS";
            lblPS.Size = new Size(25, 15);
            lblPS.TabIndex = 3;
            lblPS.Text = "P/S";
            // 
            // lblAlarm1
            // 
            lblAlarm1.AutoSize = true;
            lblAlarm1.Location = new Point(171, 296);
            lblAlarm1.Name = "lblAlarm1";
            lblAlarm1.Size = new Size(51, 15);
            lblAlarm1.TabIndex = 21;
            lblAlarm1.Text = "Alarm 1:";
            // 
            // lblYVal
            // 
            lblYVal.AutoSize = true;
            lblYVal.Location = new Point(169, 144);
            lblYVal.Name = "lblYVal";
            lblYVal.Size = new Size(52, 15);
            lblYVal.TabIndex = 4;
            lblYVal.Text = "Y-Values";
            // 
            // lblPlay
            // 
            lblPlay.AutoSize = true;
            lblPlay.Location = new Point(386, 231);
            lblPlay.Name = "lblPlay";
            lblPlay.Size = new Size(32, 15);
            lblPlay.TabIndex = 20;
            lblPlay.Text = "Play:";
            // 
            // lblXVal
            // 
            lblXVal.AutoSize = true;
            lblXVal.Location = new Point(169, 115);
            lblXVal.Name = "lblXVal";
            lblXVal.Size = new Size(52, 15);
            lblXVal.TabIndex = 5;
            lblXVal.Text = "X-Values";
            // 
            // lblAlarm2
            // 
            lblAlarm2.AutoSize = true;
            lblAlarm2.Location = new Point(171, 327);
            lblAlarm2.Name = "lblAlarm2";
            lblAlarm2.Size = new Size(51, 15);
            lblAlarm2.TabIndex = 19;
            lblAlarm2.Text = "Alarm 2:";
            // 
            // lblFrequency1
            // 
            lblFrequency1.AutoSize = true;
            lblFrequency1.Location = new Point(356, 260);
            lblFrequency1.Name = "lblFrequency1";
            lblFrequency1.Size = new Size(65, 15);
            lblFrequency1.TabIndex = 13;
            lblFrequency1.Text = "Frequency:";
            // 
            // lblFilterHP1
            // 
            lblFilterHP1.AutoSize = true;
            lblFilterHP1.Location = new Point(366, 405);
            lblFilterHP1.Name = "lblFilterHP1";
            lblFilterHP1.Size = new Size(55, 15);
            lblFilterHP1.TabIndex = 18;
            lblFilterHP1.Text = "Filter HP:";
            // 
            // lblGainX1
            // 
            lblGainX1.AutoSize = true;
            lblGainX1.Location = new Point(374, 289);
            lblGainX1.Name = "lblGainX1";
            lblGainX1.Size = new Size(44, 15);
            lblGainX1.TabIndex = 14;
            lblGainX1.Text = "Gain X:";
            // 
            // lblFilterLP1
            // 
            lblFilterLP1.AutoSize = true;
            lblFilterLP1.Location = new Point(366, 376);
            lblFilterLP1.Name = "lblFilterLP1";
            lblFilterLP1.Size = new Size(52, 15);
            lblFilterLP1.TabIndex = 17;
            lblFilterLP1.Text = "Filter LP:";
            // 
            // lblGainY1
            // 
            lblGainY1.AutoSize = true;
            lblGainY1.Location = new Point(374, 318);
            lblGainY1.Name = "lblGainY1";
            lblGainY1.Size = new Size(44, 15);
            lblGainY1.TabIndex = 15;
            lblGainY1.Text = "Gain Y:";
            // 
            // lblPhase1
            // 
            lblPhase1.AutoSize = true;
            lblPhase1.Location = new Point(380, 347);
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
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panelSettings.ResumeLayout(false);
            panelSettings.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Label lblInflux;
    }
}