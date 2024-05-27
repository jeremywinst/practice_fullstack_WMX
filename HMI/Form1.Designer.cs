namespace HMI
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
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tpJobList = new TabPage();
            buttonBrowse = new Button();
            label1 = new Label();
            buttonLoad = new Button();
            tbPathInput = new TextBox();
            buttonOpen = new Button();
            lbLoadJoblist = new ListBox();
            label2 = new Label();
            tpHWStatus = new TabPage();
            groupBox2 = new GroupBox();
            label3 = new Label();
            buttonGetOutChArr = new Button();
            label6 = new Label();
            tbChStart = new TextBox();
            tbChSize = new TextBox();
            groupBox1 = new GroupBox();
            radioButton1 = new RadioButton();
            buttonSetOutCh = new Button();
            radioButton2 = new RadioButton();
            labelSetBitCh = new Label();
            cbSetOut15 = new CheckBox();
            cbSetOut14 = new CheckBox();
            cbSetOut13 = new CheckBox();
            cbSetOut12 = new CheckBox();
            cbSetOut11 = new CheckBox();
            cbSetOut10 = new CheckBox();
            cbSetOut9 = new CheckBox();
            cbSetOut8 = new CheckBox();
            cbSetOut7 = new CheckBox();
            cbSetOut6 = new CheckBox();
            cbSetOut5 = new CheckBox();
            cbSetOut4 = new CheckBox();
            cbSetOut3 = new CheckBox();
            cbSetOut2 = new CheckBox();
            cbSetOut1 = new CheckBox();
            cbSetOut0 = new CheckBox();
            dgvMotorStat = new DataGridView();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dgvOutput = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dgvInput = new DataGridView();
            Bit = new DataGridViewTextBoxColumn();
            dgvInValue = new DataGridViewTextBoxColumn();
            cbOutput = new ComboBox();
            label9 = new Label();
            cbMotorStat = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            cbInput = new ComboBox();
            tpMotorCmd = new TabPage();
            buttonResetAlrm = new Button();
            buttonMoveRel = new Button();
            buttonSVOFF = new Button();
            buttonSVON = new Button();
            tbLim2 = new TextBox();
            tbLim1 = new TextBox();
            tbAlarm = new TextBox();
            tbVel = new TextBox();
            tbPos = new TextBox();
            tbSVON = new TextBox();
            label12 = new Label();
            label13 = new Label();
            label10 = new Label();
            dgvJobList = new DataGridView();
            dgvJobID = new DataGridViewTextBoxColumn();
            dgvJobPos = new DataGridViewTextBoxColumn();
            dgvJobVel = new DataGridViewTextBoxColumn();
            buttonSave = new Button();
            buttonStop = new Button();
            buttonMoveAbs = new Button();
            labelAlarm = new Label();
            label5 = new Label();
            label4 = new Label();
            cbAxisName = new ComboBox();
            labelAxisName = new Label();
            tpAutoCycle = new TabPage();
            buttonACHome = new Button();
            label23 = new Label();
            label22 = new Label();
            label21 = new Label();
            tbACPosZ2 = new TextBox();
            tbACPosZ1 = new TextBox();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            tbACPosY3 = new TextBox();
            tbACPosX3 = new TextBox();
            tbACPosY2 = new TextBox();
            tbACPosY1 = new TextBox();
            tbACPosX2 = new TextBox();
            tbACPosX1 = new TextBox();
            groupBox5 = new GroupBox();
            label15 = new Label();
            dgvACZStatus = new DataGridView();
            dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
            label14 = new Label();
            dgvACYStatus = new DataGridView();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            label11 = new Label();
            dgvACXStatus = new DataGridView();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            tbACStatus = new TextBox();
            label26 = new Label();
            buttonACStop = new Button();
            buttonACStart2 = new Button();
            buttonACStart1 = new Button();
            labelJobName = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            timer1 = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            tpJobList.SuspendLayout();
            tpHWStatus.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMotorStat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOutput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInput).BeginInit();
            tpMotorCmd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJobList).BeginInit();
            tpAutoCycle.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvACZStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvACYStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvACXStatus).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpJobList);
            tabControl1.Controls.Add(tpHWStatus);
            tabControl1.Controls.Add(tpMotorCmd);
            tabControl1.Controls.Add(tpAutoCycle);
            tabControl1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.ItemSize = new Size(90, 40);
            tabControl1.Location = new Point(1, 75);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(12, 3);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(850, 691);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tpJobList
            // 
            tpJobList.Controls.Add(buttonBrowse);
            tpJobList.Controls.Add(label1);
            tpJobList.Controls.Add(buttonLoad);
            tpJobList.Controls.Add(tbPathInput);
            tpJobList.Controls.Add(buttonOpen);
            tpJobList.Controls.Add(lbLoadJoblist);
            tpJobList.Controls.Add(label2);
            tpJobList.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tpJobList.Location = new Point(4, 44);
            tpJobList.Name = "tpJobList";
            tpJobList.Padding = new Padding(3);
            tpJobList.Size = new Size(842, 643);
            tpJobList.TabIndex = 0;
            tpJobList.Text = "Job List";
            tpJobList.UseVisualStyleBackColor = true;
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(644, 111);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(75, 27);
            buttonBrowse.TabIndex = 0;
            buttonBrowse.Text = "Browse";
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(291, 59);
            label1.Name = "label1";
            label1.Size = new Size(197, 25);
            label1.TabIndex = 2;
            label1.Text = "Load Your Job List File";
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(562, 152);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 37);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // tbPathInput
            // 
            tbPathInput.Font = new Font("Segoe UI", 11F);
            tbPathInput.Location = new Point(129, 112);
            tbPathInput.Name = "tbPathInput";
            tbPathInput.Size = new Size(422, 27);
            tbPathInput.TabIndex = 3;
            // 
            // buttonOpen
            // 
            buttonOpen.Location = new Point(562, 111);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new Size(75, 27);
            buttonOpen.TabIndex = 2;
            buttonOpen.Text = "Open";
            buttonOpen.UseVisualStyleBackColor = true;
            buttonOpen.Click += buttonOpen_Click;
            // 
            // lbLoadJoblist
            // 
            lbLoadJoblist.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbLoadJoblist.FormattingEnabled = true;
            lbLoadJoblist.ItemHeight = 21;
            lbLoadJoblist.Location = new Point(88, 152);
            lbLoadJoblist.Name = "lbLoadJoblist";
            lbLoadJoblist.Size = new Size(463, 193);
            lbLoadJoblist.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(84, 114);
            label2.Name = "label2";
            label2.Size = new Size(40, 21);
            label2.TabIndex = 0;
            label2.Text = "Path";
            // 
            // tpHWStatus
            // 
            tpHWStatus.Controls.Add(groupBox2);
            tpHWStatus.Controls.Add(groupBox1);
            tpHWStatus.Controls.Add(labelSetBitCh);
            tpHWStatus.Controls.Add(cbSetOut15);
            tpHWStatus.Controls.Add(cbSetOut14);
            tpHWStatus.Controls.Add(cbSetOut13);
            tpHWStatus.Controls.Add(cbSetOut12);
            tpHWStatus.Controls.Add(cbSetOut11);
            tpHWStatus.Controls.Add(cbSetOut10);
            tpHWStatus.Controls.Add(cbSetOut9);
            tpHWStatus.Controls.Add(cbSetOut8);
            tpHWStatus.Controls.Add(cbSetOut7);
            tpHWStatus.Controls.Add(cbSetOut6);
            tpHWStatus.Controls.Add(cbSetOut5);
            tpHWStatus.Controls.Add(cbSetOut4);
            tpHWStatus.Controls.Add(cbSetOut3);
            tpHWStatus.Controls.Add(cbSetOut2);
            tpHWStatus.Controls.Add(cbSetOut1);
            tpHWStatus.Controls.Add(cbSetOut0);
            tpHWStatus.Controls.Add(dgvMotorStat);
            tpHWStatus.Controls.Add(dgvOutput);
            tpHWStatus.Controls.Add(dgvInput);
            tpHWStatus.Controls.Add(cbOutput);
            tpHWStatus.Controls.Add(label9);
            tpHWStatus.Controls.Add(cbMotorStat);
            tpHWStatus.Controls.Add(label8);
            tpHWStatus.Controls.Add(label7);
            tpHWStatus.Controls.Add(cbInput);
            tpHWStatus.Location = new Point(4, 44);
            tpHWStatus.Name = "tpHWStatus";
            tpHWStatus.Padding = new Padding(3);
            tpHWStatus.Size = new Size(842, 643);
            tpHWStatus.TabIndex = 1;
            tpHWStatus.Text = "Hardware Status";
            tpHWStatus.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(buttonGetOutChArr);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(tbChStart);
            groupBox2.Controls.Add(tbChSize);
            groupBox2.Location = new Point(523, 449);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(276, 164);
            groupBox2.TabIndex = 35;
            groupBox2.TabStop = false;
            groupBox2.Text = "Get Out Channel Array Simulation";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 38);
            label3.Name = "label3";
            label3.Size = new Size(103, 21);
            label3.TabIndex = 35;
            label3.Text = "Start Channel";
            // 
            // buttonGetOutChArr
            // 
            buttonGetOutChArr.Font = new Font("Segoe UI", 10F);
            buttonGetOutChArr.Location = new Point(98, 111);
            buttonGetOutChArr.Name = "buttonGetOutChArr";
            buttonGetOutChArr.Size = new Size(91, 34);
            buttonGetOutChArr.TabIndex = 32;
            buttonGetOutChArr.Text = "Get Output";
            buttonGetOutChArr.UseVisualStyleBackColor = true;
            buttonGetOutChArr.Click += buttonGetOutChArr_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 72);
            label6.Name = "label6";
            label6.Size = new Size(99, 21);
            label6.TabIndex = 36;
            label6.Text = "Channel Size";
            // 
            // tbChStart
            // 
            tbChStart.Location = new Point(140, 36);
            tbChStart.Name = "tbChStart";
            tbChStart.Size = new Size(100, 29);
            tbChStart.TabIndex = 33;
            // 
            // tbChSize
            // 
            tbChSize.Location = new Point(140, 68);
            tbChSize.Name = "tbChSize";
            tbChSize.Size = new Size(100, 29);
            tbChSize.TabIndex = 34;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(buttonSetOutCh);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Location = new Point(295, 531);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(187, 82);
            groupBox1.TabIndex = 35;
            groupBox1.TabStop = false;
            groupBox1.Text = "Set Output By";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(17, 23);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(46, 25);
            radioButton1.TabIndex = 33;
            radioButton1.TabStop = true;
            radioButton1.Text = "Bit";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // buttonSetOutCh
            // 
            buttonSetOutCh.Enabled = false;
            buttonSetOutCh.Font = new Font("Segoe UI", 9F);
            buttonSetOutCh.Location = new Point(105, 46);
            buttonSetOutCh.Name = "buttonSetOutCh";
            buttonSetOutCh.Size = new Size(68, 25);
            buttonSetOutCh.TabIndex = 32;
            buttonSetOutCh.Text = "Set";
            buttonSetOutCh.UseVisualStyleBackColor = true;
            buttonSetOutCh.Click += buttonSetOutCh_Click;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(17, 46);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(85, 25);
            radioButton2.TabIndex = 34;
            radioButton2.TabStop = true;
            radioButton2.Text = "Channel";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // labelSetBitCh
            // 
            labelSetBitCh.AutoSize = true;
            labelSetBitCh.Location = new Point(460, 86);
            labelSetBitCh.Name = "labelSetBitCh";
            labelSetBitCh.Size = new Size(32, 21);
            labelSetBitCh.TabIndex = 31;
            labelSetBitCh.Text = "Set";
            // 
            // cbSetOut15
            // 
            cbSetOut15.AutoSize = true;
            cbSetOut15.Location = new Point(468, 493);
            cbSetOut15.Name = "cbSetOut15";
            cbSetOut15.Size = new Size(15, 14);
            cbSetOut15.TabIndex = 30;
            cbSetOut15.Tag = "15";
            cbSetOut15.UseVisualStyleBackColor = true;
            cbSetOut15.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut14
            // 
            cbSetOut14.AutoSize = true;
            cbSetOut14.Location = new Point(468, 468);
            cbSetOut14.Name = "cbSetOut14";
            cbSetOut14.Size = new Size(15, 14);
            cbSetOut14.TabIndex = 29;
            cbSetOut14.Tag = "14";
            cbSetOut14.UseVisualStyleBackColor = true;
            cbSetOut14.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut13
            // 
            cbSetOut13.AutoSize = true;
            cbSetOut13.Location = new Point(468, 443);
            cbSetOut13.Name = "cbSetOut13";
            cbSetOut13.Size = new Size(15, 14);
            cbSetOut13.TabIndex = 28;
            cbSetOut13.Tag = "13";
            cbSetOut13.UseVisualStyleBackColor = true;
            cbSetOut13.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut12
            // 
            cbSetOut12.AutoSize = true;
            cbSetOut12.Location = new Point(468, 418);
            cbSetOut12.Name = "cbSetOut12";
            cbSetOut12.Size = new Size(15, 14);
            cbSetOut12.TabIndex = 27;
            cbSetOut12.Tag = "12";
            cbSetOut12.UseVisualStyleBackColor = true;
            cbSetOut12.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut11
            // 
            cbSetOut11.AutoSize = true;
            cbSetOut11.Location = new Point(468, 393);
            cbSetOut11.Name = "cbSetOut11";
            cbSetOut11.Size = new Size(15, 14);
            cbSetOut11.TabIndex = 26;
            cbSetOut11.Tag = "11";
            cbSetOut11.UseVisualStyleBackColor = true;
            cbSetOut11.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut10
            // 
            cbSetOut10.AutoSize = true;
            cbSetOut10.Location = new Point(468, 368);
            cbSetOut10.Name = "cbSetOut10";
            cbSetOut10.Size = new Size(15, 14);
            cbSetOut10.TabIndex = 25;
            cbSetOut10.Tag = "10";
            cbSetOut10.UseVisualStyleBackColor = true;
            cbSetOut10.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut9
            // 
            cbSetOut9.AutoSize = true;
            cbSetOut9.Location = new Point(468, 343);
            cbSetOut9.Name = "cbSetOut9";
            cbSetOut9.Size = new Size(15, 14);
            cbSetOut9.TabIndex = 24;
            cbSetOut9.Tag = "9";
            cbSetOut9.UseVisualStyleBackColor = true;
            cbSetOut9.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut8
            // 
            cbSetOut8.AutoSize = true;
            cbSetOut8.Location = new Point(468, 318);
            cbSetOut8.Name = "cbSetOut8";
            cbSetOut8.Size = new Size(15, 14);
            cbSetOut8.TabIndex = 23;
            cbSetOut8.Tag = "8";
            cbSetOut8.UseVisualStyleBackColor = true;
            cbSetOut8.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut7
            // 
            cbSetOut7.AutoSize = true;
            cbSetOut7.Location = new Point(468, 293);
            cbSetOut7.Name = "cbSetOut7";
            cbSetOut7.Size = new Size(15, 14);
            cbSetOut7.TabIndex = 22;
            cbSetOut7.Tag = "7";
            cbSetOut7.UseVisualStyleBackColor = true;
            cbSetOut7.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut6
            // 
            cbSetOut6.AutoSize = true;
            cbSetOut6.Location = new Point(468, 268);
            cbSetOut6.Name = "cbSetOut6";
            cbSetOut6.Size = new Size(15, 14);
            cbSetOut6.TabIndex = 21;
            cbSetOut6.Tag = "6";
            cbSetOut6.UseVisualStyleBackColor = true;
            cbSetOut6.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut5
            // 
            cbSetOut5.AutoSize = true;
            cbSetOut5.Location = new Point(468, 243);
            cbSetOut5.Name = "cbSetOut5";
            cbSetOut5.Size = new Size(15, 14);
            cbSetOut5.TabIndex = 20;
            cbSetOut5.Tag = "5";
            cbSetOut5.UseVisualStyleBackColor = true;
            cbSetOut5.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut4
            // 
            cbSetOut4.AutoSize = true;
            cbSetOut4.Location = new Point(468, 218);
            cbSetOut4.Name = "cbSetOut4";
            cbSetOut4.Size = new Size(15, 14);
            cbSetOut4.TabIndex = 19;
            cbSetOut4.Tag = "4";
            cbSetOut4.UseVisualStyleBackColor = true;
            cbSetOut4.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut3
            // 
            cbSetOut3.AutoSize = true;
            cbSetOut3.Location = new Point(468, 193);
            cbSetOut3.Name = "cbSetOut3";
            cbSetOut3.Size = new Size(15, 14);
            cbSetOut3.TabIndex = 18;
            cbSetOut3.Tag = "3";
            cbSetOut3.UseVisualStyleBackColor = true;
            cbSetOut3.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut2
            // 
            cbSetOut2.AutoSize = true;
            cbSetOut2.Location = new Point(468, 168);
            cbSetOut2.Name = "cbSetOut2";
            cbSetOut2.Size = new Size(15, 14);
            cbSetOut2.TabIndex = 17;
            cbSetOut2.Tag = "2";
            cbSetOut2.UseVisualStyleBackColor = true;
            cbSetOut2.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut1
            // 
            cbSetOut1.AutoSize = true;
            cbSetOut1.Location = new Point(468, 143);
            cbSetOut1.Name = "cbSetOut1";
            cbSetOut1.Size = new Size(15, 14);
            cbSetOut1.TabIndex = 16;
            cbSetOut1.Tag = "1";
            cbSetOut1.UseVisualStyleBackColor = true;
            cbSetOut1.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // cbSetOut0
            // 
            cbSetOut0.AutoSize = true;
            cbSetOut0.Location = new Point(468, 118);
            cbSetOut0.Name = "cbSetOut0";
            cbSetOut0.Size = new Size(15, 14);
            cbSetOut0.TabIndex = 15;
            cbSetOut0.Tag = "0";
            cbSetOut0.UseVisualStyleBackColor = true;
            cbSetOut0.CheckedChanged += cbSetOut_CheckedChanged;
            // 
            // dgvMotorStat
            // 
            dgvMotorStat.AllowUserToAddRows = false;
            dgvMotorStat.AllowUserToDeleteRows = false;
            dgvMotorStat.AllowUserToResizeColumns = false;
            dgvMotorStat.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMotorStat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMotorStat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMotorStat.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMotorStat.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMotorStat.Location = new Point(563, 82);
            dgvMotorStat.Name = "dgvMotorStat";
            dgvMotorStat.ReadOnly = true;
            dgvMotorStat.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMotorStat.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvMotorStat.Size = new Size(143, 182);
            dgvMotorStat.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Name";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Value";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dgvOutput
            // 
            dgvOutput.AllowUserToAddRows = false;
            dgvOutput.AllowUserToDeleteRows = false;
            dgvOutput.AllowUserToResizeColumns = false;
            dgvOutput.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvOutput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvOutput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOutput.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dgvOutput.Location = new Point(307, 82);
            dgvOutput.Name = "dgvOutput";
            dgvOutput.RowHeadersVisible = false;
            dgvOutput.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvOutput.Size = new Size(143, 432);
            dgvOutput.TabIndex = 13;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Bit";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Value";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dgvInput
            // 
            dgvInput.AllowUserToAddRows = false;
            dgvInput.AllowUserToDeleteRows = false;
            dgvInput.AllowUserToResizeColumns = false;
            dgvInput.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvInput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvInput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInput.Columns.AddRange(new DataGridViewColumn[] { Bit, dgvInValue });
            dgvInput.Location = new Point(86, 82);
            dgvInput.Name = "dgvInput";
            dgvInput.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvInput.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvInput.RowHeadersVisible = false;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInput.RowsDefaultCellStyle = dataGridViewCellStyle7;
            dgvInput.Size = new Size(143, 432);
            dgvInput.TabIndex = 12;
            // 
            // Bit
            // 
            Bit.HeaderText = "Bit";
            Bit.Name = "Bit";
            Bit.ReadOnly = true;
            Bit.SortMode = DataGridViewColumnSortMode.NotSortable;
            Bit.Width = 70;
            // 
            // dgvInValue
            // 
            dgvInValue.HeaderText = "Value";
            dgvInValue.Name = "dgvInValue";
            dgvInValue.ReadOnly = true;
            dgvInValue.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvInValue.Width = 70;
            // 
            // cbOutput
            // 
            cbOutput.FormattingEnabled = true;
            cbOutput.Location = new Point(366, 31);
            cbOutput.Name = "cbOutput";
            cbOutput.Size = new Size(116, 29);
            cbOutput.TabIndex = 11;
            cbOutput.SelectedIndexChanged += cbOutput_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(538, 35);
            label9.Name = "label9";
            label9.Size = new Size(99, 21);
            label9.TabIndex = 10;
            label9.Text = "Motor Status";
            // 
            // cbMotorStat
            // 
            cbMotorStat.FormattingEnabled = true;
            cbMotorStat.Location = new Point(638, 31);
            cbMotorStat.Name = "cbMotorStat";
            cbMotorStat.Size = new Size(92, 29);
            cbMotorStat.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(306, 35);
            label8.Name = "label8";
            label8.Size = new Size(59, 21);
            label8.TabIndex = 8;
            label8.Text = "Output";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(73, 35);
            label7.Name = "label7";
            label7.Size = new Size(46, 21);
            label7.TabIndex = 6;
            label7.Text = "Input";
            // 
            // cbInput
            // 
            cbInput.FormattingEnabled = true;
            cbInput.Location = new Point(120, 31);
            cbInput.Name = "cbInput";
            cbInput.Size = new Size(116, 29);
            cbInput.TabIndex = 0;
            // 
            // tpMotorCmd
            // 
            tpMotorCmd.Controls.Add(buttonResetAlrm);
            tpMotorCmd.Controls.Add(buttonMoveRel);
            tpMotorCmd.Controls.Add(buttonSVOFF);
            tpMotorCmd.Controls.Add(buttonSVON);
            tpMotorCmd.Controls.Add(tbLim2);
            tpMotorCmd.Controls.Add(tbLim1);
            tpMotorCmd.Controls.Add(tbAlarm);
            tpMotorCmd.Controls.Add(tbVel);
            tpMotorCmd.Controls.Add(tbPos);
            tpMotorCmd.Controls.Add(tbSVON);
            tpMotorCmd.Controls.Add(label12);
            tpMotorCmd.Controls.Add(label13);
            tpMotorCmd.Controls.Add(label10);
            tpMotorCmd.Controls.Add(dgvJobList);
            tpMotorCmd.Controls.Add(buttonSave);
            tpMotorCmd.Controls.Add(buttonStop);
            tpMotorCmd.Controls.Add(buttonMoveAbs);
            tpMotorCmd.Controls.Add(labelAlarm);
            tpMotorCmd.Controls.Add(label5);
            tpMotorCmd.Controls.Add(label4);
            tpMotorCmd.Controls.Add(cbAxisName);
            tpMotorCmd.Controls.Add(labelAxisName);
            tpMotorCmd.Location = new Point(4, 44);
            tpMotorCmd.Name = "tpMotorCmd";
            tpMotorCmd.Padding = new Padding(3);
            tpMotorCmd.Size = new Size(842, 643);
            tpMotorCmd.TabIndex = 2;
            tpMotorCmd.Text = "Motor Command";
            tpMotorCmd.UseVisualStyleBackColor = true;
            // 
            // buttonResetAlrm
            // 
            buttonResetAlrm.Font = new Font("Segoe UI", 12F);
            buttonResetAlrm.Location = new Point(555, 167);
            buttonResetAlrm.Name = "buttonResetAlrm";
            buttonResetAlrm.Size = new Size(111, 40);
            buttonResetAlrm.TabIndex = 29;
            buttonResetAlrm.Text = "Alarm Reset";
            buttonResetAlrm.UseVisualStyleBackColor = true;
            buttonResetAlrm.Click += buttonResetAlrm_Click;
            // 
            // buttonMoveRel
            // 
            buttonMoveRel.Font = new Font("Segoe UI", 12F);
            buttonMoveRel.Location = new Point(575, 298);
            buttonMoveRel.Name = "buttonMoveRel";
            buttonMoveRel.Size = new Size(91, 40);
            buttonMoveRel.TabIndex = 28;
            buttonMoveRel.Text = "Move Rel";
            buttonMoveRel.UseVisualStyleBackColor = true;
            buttonMoveRel.Click += buttonMoveRel_Click;
            // 
            // buttonSVOFF
            // 
            buttonSVOFF.Font = new Font("Segoe UI", 12F);
            buttonSVOFF.Location = new Point(555, 117);
            buttonSVOFF.Name = "buttonSVOFF";
            buttonSVOFF.Size = new Size(111, 40);
            buttonSVOFF.TabIndex = 27;
            buttonSVOFF.Text = "Servo OFF";
            buttonSVOFF.UseVisualStyleBackColor = true;
            buttonSVOFF.Click += buttonSVOFF_Click;
            // 
            // buttonSVON
            // 
            buttonSVON.Font = new Font("Segoe UI", 12F);
            buttonSVON.Location = new Point(555, 65);
            buttonSVON.Name = "buttonSVON";
            buttonSVON.Size = new Size(111, 40);
            buttonSVON.TabIndex = 26;
            buttonSVON.Text = "Servo ON";
            buttonSVON.UseVisualStyleBackColor = true;
            buttonSVON.Click += buttonSVON_Click;
            // 
            // tbLim2
            // 
            tbLim2.Location = new Point(204, 181);
            tbLim2.Name = "tbLim2";
            tbLim2.ReadOnly = true;
            tbLim2.Size = new Size(63, 29);
            tbLim2.TabIndex = 25;
            // 
            // tbLim1
            // 
            tbLim1.Location = new Point(204, 149);
            tbLim1.Name = "tbLim1";
            tbLim1.ReadOnly = true;
            tbLim1.Size = new Size(63, 29);
            tbLim1.TabIndex = 24;
            // 
            // tbAlarm
            // 
            tbAlarm.Location = new Point(204, 117);
            tbAlarm.Name = "tbAlarm";
            tbAlarm.ReadOnly = true;
            tbAlarm.Size = new Size(63, 29);
            tbAlarm.TabIndex = 22;
            // 
            // tbVel
            // 
            tbVel.Location = new Point(357, 112);
            tbVel.Name = "tbVel";
            tbVel.ReadOnly = true;
            tbVel.Size = new Size(143, 29);
            tbVel.TabIndex = 21;
            // 
            // tbPos
            // 
            tbPos.Location = new Point(357, 80);
            tbPos.Name = "tbPos";
            tbPos.ReadOnly = true;
            tbPos.Size = new Size(143, 29);
            tbPos.TabIndex = 20;
            // 
            // tbSVON
            // 
            tbSVON.Location = new Point(204, 84);
            tbSVON.Name = "tbSVON";
            tbSVON.ReadOnly = true;
            tbSVON.Size = new Size(63, 29);
            tbSVON.TabIndex = 19;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(134, 153);
            label12.Name = "label12";
            label12.Size = new Size(60, 21);
            label12.TabIndex = 17;
            label12.Text = "Limit +";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(134, 185);
            label13.Name = "label13";
            label13.Size = new Size(55, 21);
            label13.TabIndex = 16;
            label13.Text = "Limit -";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(133, 87);
            label10.Name = "label10";
            label10.Size = new Size(53, 21);
            label10.TabIndex = 15;
            label10.Text = "SVON";
            // 
            // dgvJobList
            // 
            dgvJobList.AllowUserToAddRows = false;
            dgvJobList.AllowUserToDeleteRows = false;
            dgvJobList.AllowUserToResizeColumns = false;
            dgvJobList.AllowUserToResizeRows = false;
            dgvJobList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJobList.Columns.AddRange(new DataGridViewColumn[] { dgvJobID, dgvJobPos, dgvJobVel });
            dgvJobList.Location = new Point(117, 248);
            dgvJobList.Name = "dgvJobList";
            dgvJobList.RowHeadersVisible = false;
            dgvJobList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJobList.Size = new Size(438, 157);
            dgvJobList.TabIndex = 12;
            // 
            // dgvJobID
            // 
            dgvJobID.HeaderText = "ID";
            dgvJobID.Name = "dgvJobID";
            dgvJobID.Width = 35;
            // 
            // dgvJobPos
            // 
            dgvJobPos.HeaderText = "Position";
            dgvJobPos.Name = "dgvJobPos";
            dgvJobPos.Width = 200;
            // 
            // dgvJobVel
            // 
            dgvJobVel.HeaderText = "Velocity";
            dgvJobVel.Name = "dgvJobVel";
            dgvJobVel.Width = 200;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 9F);
            buttonSave.Location = new Point(303, 422);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 25);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonStop
            // 
            buttonStop.Font = new Font("Segoe UI", 12F);
            buttonStop.Location = new Point(575, 365);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 40);
            buttonStop.TabIndex = 7;
            buttonStop.Text = "STOP";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // buttonMoveAbs
            // 
            buttonMoveAbs.Font = new Font("Segoe UI", 12F);
            buttonMoveAbs.Location = new Point(575, 248);
            buttonMoveAbs.Name = "buttonMoveAbs";
            buttonMoveAbs.Size = new Size(91, 40);
            buttonMoveAbs.TabIndex = 6;
            buttonMoveAbs.Text = "Move Abs";
            buttonMoveAbs.UseVisualStyleBackColor = true;
            buttonMoveAbs.Click += buttonMoveAbs_Click;
            // 
            // labelAlarm
            // 
            labelAlarm.AutoSize = true;
            labelAlarm.Location = new Point(133, 121);
            labelAlarm.Name = "labelAlarm";
            labelAlarm.Size = new Size(52, 21);
            labelAlarm.TabIndex = 4;
            labelAlarm.Text = "Alarm";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(286, 116);
            label5.Name = "label5";
            label5.Size = new Size(64, 21);
            label5.TabIndex = 3;
            label5.Text = "Velocity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(286, 84);
            label4.Name = "label4";
            label4.Size = new Size(65, 21);
            label4.TabIndex = 2;
            label4.Text = "Position";
            // 
            // cbAxisName
            // 
            cbAxisName.FormattingEnabled = true;
            cbAxisName.Location = new Point(312, 40);
            cbAxisName.Name = "cbAxisName";
            cbAxisName.Size = new Size(66, 29);
            cbAxisName.TabIndex = 1;
            cbAxisName.Text = "Select Index";
            cbAxisName.SelectedIndexChanged += cbAxisName_SelectedIndexChanged;
            // 
            // labelAxisName
            // 
            labelAxisName.AutoSize = true;
            labelAxisName.Location = new Point(133, 43);
            labelAxisName.Name = "labelAxisName";
            labelAxisName.Size = new Size(132, 21);
            labelAxisName.TabIndex = 0;
            labelAxisName.Text = "Axis Name: Axis ...";
            // 
            // tpAutoCycle
            // 
            tpAutoCycle.Controls.Add(buttonACHome);
            tpAutoCycle.Controls.Add(label23);
            tpAutoCycle.Controls.Add(label22);
            tpAutoCycle.Controls.Add(label21);
            tpAutoCycle.Controls.Add(tbACPosZ2);
            tpAutoCycle.Controls.Add(tbACPosZ1);
            tpAutoCycle.Controls.Add(label20);
            tpAutoCycle.Controls.Add(label19);
            tpAutoCycle.Controls.Add(label18);
            tpAutoCycle.Controls.Add(label17);
            tpAutoCycle.Controls.Add(label16);
            tpAutoCycle.Controls.Add(tbACPosY3);
            tpAutoCycle.Controls.Add(tbACPosX3);
            tpAutoCycle.Controls.Add(tbACPosY2);
            tpAutoCycle.Controls.Add(tbACPosY1);
            tpAutoCycle.Controls.Add(tbACPosX2);
            tpAutoCycle.Controls.Add(tbACPosX1);
            tpAutoCycle.Controls.Add(groupBox5);
            tpAutoCycle.Controls.Add(tbACStatus);
            tpAutoCycle.Controls.Add(label26);
            tpAutoCycle.Controls.Add(buttonACStop);
            tpAutoCycle.Controls.Add(buttonACStart2);
            tpAutoCycle.Controls.Add(buttonACStart1);
            tpAutoCycle.Location = new Point(4, 44);
            tpAutoCycle.Name = "tpAutoCycle";
            tpAutoCycle.Size = new Size(842, 643);
            tpAutoCycle.TabIndex = 3;
            tpAutoCycle.Text = "Auto Cycle";
            tpAutoCycle.UseVisualStyleBackColor = true;
            // 
            // buttonACHome
            // 
            buttonACHome.Location = new Point(541, 237);
            buttonACHome.Name = "buttonACHome";
            buttonACHome.Size = new Size(75, 49);
            buttonACHome.TabIndex = 96;
            buttonACHome.Text = "HOME";
            buttonACHome.UseVisualStyleBackColor = true;
            buttonACHome.Click += buttonACHome_Click;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(366, 237);
            label23.Name = "label23";
            label23.Size = new Size(30, 21);
            label23.TabIndex = 95;
            label23.Text = "Up";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(290, 237);
            label22.Name = "label22";
            label22.Size = new Size(51, 21);
            label22.TabIndex = 94;
            label22.Text = "Down";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(229, 265);
            label21.Name = "label21";
            label21.Size = new Size(51, 21);
            label21.TabIndex = 93;
            label21.Text = "Z Axis";
            // 
            // tbACPosZ2
            // 
            tbACPosZ2.Location = new Point(349, 261);
            tbACPosZ2.Name = "tbACPosZ2";
            tbACPosZ2.Size = new Size(63, 29);
            tbACPosZ2.TabIndex = 92;
            // 
            // tbACPosZ1
            // 
            tbACPosZ1.Location = new Point(283, 261);
            tbACPosZ1.Name = "tbACPosZ1";
            tbACPosZ1.Size = new Size(63, 29);
            tbACPosZ1.TabIndex = 91;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(355, 97);
            label20.Name = "label20";
            label20.Size = new Size(51, 21);
            label20.TabIndex = 90;
            label20.Text = "Y Axis";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(290, 97);
            label19.Name = "label19";
            label19.Size = new Size(51, 21);
            label19.TabIndex = 89;
            label19.Text = "X Axis";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(230, 193);
            label18.Name = "label18";
            label18.Size = new Size(47, 21);
            label18.TabIndex = 88;
            label18.Text = "Pos 3";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(230, 159);
            label17.Name = "label17";
            label17.Size = new Size(47, 21);
            label17.TabIndex = 87;
            label17.Text = "Pos 2";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(230, 126);
            label16.Name = "label16";
            label16.Size = new Size(47, 21);
            label16.TabIndex = 86;
            label16.Text = "Pos 1";
            // 
            // tbACPosY3
            // 
            tbACPosY3.Location = new Point(349, 190);
            tbACPosY3.Name = "tbACPosY3";
            tbACPosY3.Size = new Size(63, 29);
            tbACPosY3.TabIndex = 85;
            // 
            // tbACPosX3
            // 
            tbACPosX3.Location = new Point(283, 190);
            tbACPosX3.Name = "tbACPosX3";
            tbACPosX3.Size = new Size(63, 29);
            tbACPosX3.TabIndex = 84;
            // 
            // tbACPosY2
            // 
            tbACPosY2.Location = new Point(349, 156);
            tbACPosY2.Name = "tbACPosY2";
            tbACPosY2.Size = new Size(63, 29);
            tbACPosY2.TabIndex = 83;
            // 
            // tbACPosY1
            // 
            tbACPosY1.Location = new Point(349, 123);
            tbACPosY1.Name = "tbACPosY1";
            tbACPosY1.Size = new Size(63, 29);
            tbACPosY1.TabIndex = 82;
            // 
            // tbACPosX2
            // 
            tbACPosX2.Location = new Point(283, 156);
            tbACPosX2.Name = "tbACPosX2";
            tbACPosX2.Size = new Size(63, 29);
            tbACPosX2.TabIndex = 81;
            // 
            // tbACPosX1
            // 
            tbACPosX1.Location = new Point(283, 123);
            tbACPosX1.Name = "tbACPosX1";
            tbACPosX1.Size = new Size(63, 29);
            tbACPosX1.TabIndex = 80;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label15);
            groupBox5.Controls.Add(dgvACZStatus);
            groupBox5.Controls.Add(label14);
            groupBox5.Controls.Add(dgvACYStatus);
            groupBox5.Controls.Add(label11);
            groupBox5.Controls.Add(dgvACXStatus);
            groupBox5.Font = new Font("Segoe UI", 13F);
            groupBox5.Location = new Point(78, 320);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(680, 283);
            groupBox5.TabIndex = 38;
            groupBox5.TabStop = false;
            groupBox5.Text = "Motor Status";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F);
            label15.Location = new Point(516, 40);
            label15.Name = "label15";
            label15.Size = new Size(51, 21);
            label15.TabIndex = 83;
            label15.Text = "Z Axis";
            // 
            // dgvACZStatus
            // 
            dgvACZStatus.AllowUserToAddRows = false;
            dgvACZStatus.AllowUserToDeleteRows = false;
            dgvACZStatus.AllowUserToResizeColumns = false;
            dgvACZStatus.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvACZStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvACZStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvACZStatus.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn15, dataGridViewTextBoxColumn16 });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = SystemColors.Window;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvACZStatus.DefaultCellStyle = dataGridViewCellStyle9;
            dgvACZStatus.Location = new Point(473, 71);
            dgvACZStatus.Name = "dgvACZStatus";
            dgvACZStatus.ReadOnly = true;
            dgvACZStatus.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvACZStatus.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvACZStatus.Size = new Size(143, 182);
            dgvACZStatus.TabIndex = 84;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewTextBoxColumn15.HeaderText = "Name";
            dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            dataGridViewTextBoxColumn15.ReadOnly = true;
            dataGridViewTextBoxColumn15.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn15.Width = 70;
            // 
            // dataGridViewTextBoxColumn16
            // 
            dataGridViewTextBoxColumn16.HeaderText = "Value";
            dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            dataGridViewTextBoxColumn16.ReadOnly = true;
            dataGridViewTextBoxColumn16.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn16.Width = 70;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F);
            label14.Location = new Point(313, 40);
            label14.Name = "label14";
            label14.Size = new Size(51, 21);
            label14.TabIndex = 81;
            label14.Text = "Y Axis";
            // 
            // dgvACYStatus
            // 
            dgvACYStatus.AllowUserToAddRows = false;
            dgvACYStatus.AllowUserToDeleteRows = false;
            dgvACYStatus.AllowUserToResizeColumns = false;
            dgvACYStatus.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = SystemColors.Control;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle11.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dgvACYStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgvACYStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvACYStatus.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn13, dataGridViewTextBoxColumn14 });
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = SystemColors.Window;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle12.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            dgvACYStatus.DefaultCellStyle = dataGridViewCellStyle12;
            dgvACYStatus.Location = new Point(270, 71);
            dgvACYStatus.Name = "dgvACYStatus";
            dgvACYStatus.ReadOnly = true;
            dgvACYStatus.RowHeadersVisible = false;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvACYStatus.RowsDefaultCellStyle = dataGridViewCellStyle13;
            dgvACYStatus.Size = new Size(143, 182);
            dgvACYStatus.TabIndex = 82;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.HeaderText = "Name";
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.ReadOnly = true;
            dataGridViewTextBoxColumn13.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn13.Width = 70;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.HeaderText = "Value";
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.ReadOnly = true;
            dataGridViewTextBoxColumn14.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn14.Width = 70;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(104, 40);
            label11.Name = "label11";
            label11.Size = new Size(51, 21);
            label11.TabIndex = 80;
            label11.Text = "X Axis";
            // 
            // dgvACXStatus
            // 
            dgvACXStatus.AllowUserToAddRows = false;
            dgvACXStatus.AllowUserToDeleteRows = false;
            dgvACXStatus.AllowUserToResizeColumns = false;
            dgvACXStatus.AllowUserToResizeRows = false;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = SystemColors.Control;
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle14.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dgvACXStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dgvACXStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvACXStatus.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12 });
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = SystemColors.Window;
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle15.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.False;
            dgvACXStatus.DefaultCellStyle = dataGridViewCellStyle15;
            dgvACXStatus.Location = new Point(57, 71);
            dgvACXStatus.Name = "dgvACXStatus";
            dgvACXStatus.ReadOnly = true;
            dgvACXStatus.RowHeadersVisible = false;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvACXStatus.RowsDefaultCellStyle = dataGridViewCellStyle16;
            dgvACXStatus.Size = new Size(143, 182);
            dgvACXStatus.TabIndex = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.HeaderText = "Name";
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.ReadOnly = true;
            dataGridViewTextBoxColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn11.Width = 70;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.HeaderText = "Value";
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.ReadOnly = true;
            dataGridViewTextBoxColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn12.Width = 70;
            // 
            // tbACStatus
            // 
            tbACStatus.Location = new Point(452, 47);
            tbACStatus.Name = "tbACStatus";
            tbACStatus.ReadOnly = true;
            tbACStatus.Size = new Size(106, 29);
            tbACStatus.TabIndex = 38;
            tbACStatus.TextAlign = HorizontalAlignment.Center;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 13F);
            label26.Location = new Point(289, 46);
            label26.Name = "label26";
            label26.Size = new Size(164, 25);
            label26.TabIndex = 79;
            label26.Text = "Auto Cycle Status : ";
            // 
            // buttonACStop
            // 
            buttonACStop.Location = new Point(452, 237);
            buttonACStop.Name = "buttonACStop";
            buttonACStop.Size = new Size(75, 49);
            buttonACStop.TabIndex = 77;
            buttonACStop.Text = "STOP";
            buttonACStop.UseVisualStyleBackColor = true;
            buttonACStop.Click += buttonACStop_Click;
            // 
            // buttonACStart2
            // 
            buttonACStart2.Location = new Point(452, 169);
            buttonACStart2.Name = "buttonACStart2";
            buttonACStart2.Size = new Size(75, 34);
            buttonACStart2.TabIndex = 76;
            buttonACStart2.Text = "Start 2";
            buttonACStart2.UseVisualStyleBackColor = true;
            buttonACStart2.Click += buttonACStart2_Click;
            // 
            // buttonACStart1
            // 
            buttonACStart1.Location = new Point(452, 129);
            buttonACStart1.Name = "buttonACStart1";
            buttonACStart1.Size = new Size(75, 34);
            buttonACStart1.TabIndex = 75;
            buttonACStart1.Text = "Start 1";
            buttonACStart1.UseVisualStyleBackColor = true;
            buttonACStart1.Click += buttonACStart1_Click;
            // 
            // labelJobName
            // 
            labelJobName.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelJobName.Location = new Point(74, 24);
            labelJobName.Name = "labelJobName";
            labelJobName.Size = new Size(661, 30);
            labelJobName.TabIndex = 1;
            labelJobName.Text = "Job File Name: ...";
            labelJobName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(849, 763);
            Controls.Add(labelJobName);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tpJobList.ResumeLayout(false);
            tpJobList.PerformLayout();
            tpHWStatus.ResumeLayout(false);
            tpHWStatus.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMotorStat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOutput).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInput).EndInit();
            tpMotorCmd.ResumeLayout(false);
            tpMotorCmd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJobList).EndInit();
            tpAutoCycle.ResumeLayout(false);
            tpAutoCycle.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvACZStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvACYStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvACXStatus).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpJobList;
        private TabPage tpHWStatus;
        private TabPage tpMotorCmd;
        private Label label2;
        private ListBox lbLoadJoblist;
        private Button buttonLoad;
        private TextBox tbPathInput;
        private Button buttonOpen;
        private ComboBox cbInput;
        private Label labelJobName;
        private Label label1;
        private Label labelAlarm;
        private Label label5;
        private Label label4;
        private ComboBox cbAxisName;
        private Label labelAxisName;
        private Label label7;
        private Label label9;
        private Label label8;
        private ComboBox cbOutput;
        private ComboBox cbMotorStat;
        private Button buttonSave;
        private Button buttonStop;
        private Button buttonMoveAbs;
        private DataGridView dgvJobList;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label10;
        private Label label12;
        private Label label13;
        private TextBox tbVel;
        private TextBox tbPos;
        private TextBox tbSVON;
        private TextBox tbLim2;
        private TextBox tbLim1;
        private TextBox tbAlarm;
        private Button buttonBrowse;
        private Button buttonSVOFF;
        private Button buttonSVON;
        private DataGridView dgvInput;
        private DataGridView dgvMotorStat;
        private DataGridView dgvOutput;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Bit;
        private DataGridViewTextBoxColumn dgvInValue;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private CheckBox cbSetOut1;
        private CheckBox cbSetOut0;
        private CheckBox cbSetOut3;
        private CheckBox cbSetOut2;
        private CheckBox cbSetOut15;
        private CheckBox cbSetOut14;
        private CheckBox cbSetOut13;
        private CheckBox cbSetOut12;
        private CheckBox cbSetOut11;
        private CheckBox cbSetOut10;
        private CheckBox cbSetOut9;
        private CheckBox cbSetOut8;
        private CheckBox cbSetOut7;
        private CheckBox cbSetOut6;
        private CheckBox cbSetOut5;
        private CheckBox cbSetOut4;
        private Label labelSetBitCh;
        private System.Windows.Forms.Timer timer1;
        private DataGridViewTextBoxColumn dgvJobID;
        private DataGridViewTextBoxColumn dgvJobPos;
        private DataGridViewTextBoxColumn dgvJobVel;
        private Button buttonMoveRel;
        private Button buttonSetOutCh;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox1;
        private Button buttonResetAlrm;
        private Button buttonGetOutChArr;
        private Label label3;
        private TextBox tbChSize;
        private TextBox tbChStart;
        private Label label6;
        private GroupBox groupBox2;
        private TabPage tpAutoCycle;
        private Button buttonACStop;
        private Button buttonACStart2;
        private Button buttonACStart1;
        private Label label26;
        private TextBox tbACStatus;
        private GroupBox groupBox5;
        private Label label15;
        private Label label14;
        private Label label11;
        private DataGridView dgvACZStatus;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridView dgvACYStatus;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridView dgvACXStatus;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private TextBox tbACPosY3;
        private TextBox tbACPosX3;
        private TextBox tbACPosY2;
        private TextBox tbACPosY1;
        private TextBox tbACPosX2;
        private TextBox tbACPosX1;
        private Label label23;
        private Label label22;
        private Label label21;
        private TextBox tbACPosZ2;
        private TextBox tbACPosZ1;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label16;
        private Button buttonACHome;
    }
}
