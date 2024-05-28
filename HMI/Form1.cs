using IniParser;
using IniParser.Model;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.IO.MemoryMappedFiles;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HMI {
    public partial class Form1 : Form {
        // make axis_data global since its used by a lot of function
        static string axis_ini_path = "..\\..\\..\\..\\settings\\AxisName.ini";
        static FileIniDataParser parser = new FileIniDataParser();
        IniData axis_data = parser.ReadFile(axis_ini_path);

        // define command
        const int COMMAND_SVON = 1;
        const int COMMAND_SVOFF = 2;
        const int COMMAND_MOVE_ABS = 3;
        const int COMMAND_MOVE_REL = 4;
        const int COMMAND_STOP = 5;
        const int COMMAND_SET_OUTPUT = 6;
        const int COMMAND_SET_OUTPUT_CH = 7;
        const int COMMAND_GET_OUTPUT_CH_ARRAY = 8;
        const int COMMAND_ALARM_RESET = 9;
        const int COMMAND_AC_START1 = 10;
        const int COMMAND_AC_START2 = 11;
        const int COMMAND_HOME = 12;
        const int COMMAND_STOP_AUTO_CYCLE = 13;

        // define Auto Cycle status
        const int ACSTAT_READY = 1;
        const int ACSTAT_IDLE = 2;
        const int ACSTAT_START = 3;
        const int ACSTAT_STOP = 4;
        const int ACSTAT_HOMING = 5;

        //// define and register to the memory mapped file
        //static MemoryMappedFile MotorIOMMF = MemoryMappedFile.CreateOrOpen("MotorIOFileMap", 1024, MemoryMappedFileAccess.ReadWriteExecute, MemoryMappedFileOptions.None, System.IO.HandleInheritability.Inheritable);
        //static MemoryMappedViewAccessor MotorIOAccessor = MotorIOMMF.CreateViewAccessor();
        //MotorIOStruct MotorIOData;

        //static MemoryMappedFile CmdMMF = MemoryMappedFile.CreateOrOpen("CmdFileMap", 1024, MemoryMappedFileAccess.ReadWriteExecute, MemoryMappedFileOptions.None, System.IO.HandleInheritability.Inheritable);
        //static MemoryMappedViewAccessor CmdAccessor = CmdMMF.CreateViewAccessor();
        //CmdStruct CmdData;

        // define and register to the memory mapped file
        MMFHandler<MotorIOStruct> MotorIOMMF;
        MMFHandler<CmdStruct> CmdMMF;
        MotorIOStruct MotorIOData;
        CmdStruct CmdData;

        // initialize other param
        int selected_RB = 0;
        int MaxMotorCount = 0;
        const int MaxInChCount = 10;
        const int MaxOutChCount = 10;

        // initialize control collections
        private CheckBox[] cbSetOut_collecttion;

        public Form1() {
            InitializeComponent();

            //Type structType = typeof(MotorIOStruct);
            //FieldInfo[] feilds = structType.GetFields();
            //foreach (FieldInfo field in feilds) {
            //    // Get the field type
            //    Type fieldType = field.FieldType;

            //    // Get the size of the field
            //    int size = Marshal.SizeOf(fieldType);

            //    Debug.WriteLine($"{field.Name}: {size} bytes");
            //}

            ////check shared memory size
            //Debug.WriteLine(Marshal.SizeOf(MotorIOData));
            //Debug.WriteLine(Marshal.SizeOf(typeof(CmdStruct)));

            // titlebar name
            this.Text = "Job Management";

            // initizalize control collections
            cbSetOut_collecttion = new CheckBox[] {
                cbSetOut0, cbSetOut1, cbSetOut2, cbSetOut3,
                cbSetOut4, cbSetOut5, cbSetOut6, cbSetOut7,
                cbSetOut8, cbSetOut9, cbSetOut10, cbSetOut11,
                cbSetOut12, cbSetOut13, cbSetOut14, cbSetOut15 };

            // init MMF
            MotorIOMMF = new MMFHandler<MotorIOStruct>("MotorIOFileMap", "MotorIOMut");
            CmdMMF = new MMFHandler<CmdStruct>("CmdFileMap", "CmdMut");

            // calculate how many axis we have and initialize motor ComboBox tab 2 and 3 from axis.ini
            foreach (var axis_name in axis_data["AxisName"]) {
                cbAxisName.Items.Add(axis_name.KeyName);
                cbMotorStat.Items.Add(axis_name.Value);
                MaxMotorCount++;
            }

            // initilize shared memory
            MotorIOMMF.ReadLock(ref MotorIOData);
            MotorIOData.MotorCount = MaxMotorCount;
            MotorIOData.InChCount = MaxInChCount;
            MotorIOData.OutChCount = MaxOutChCount;
            MotorIOData.InChSelected = 0;
            MotorIOData.OutChSelected = 0;
            //MotorIOAccessor.Write<MotorIOStruct>(0, ref MotorIOData);
            MotorIOMMF.Write(ref MotorIOData);

            CmdMMF.ReadLock(ref CmdData);
            CmdData.is_closed = false;
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);

            // start the C++ MotionControl.exe
            string[] Path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Split("HMI");
            string MotorContolPath = Path[0] + "MotionControl\\x64\\Debug\\MotionControl.exe";

            Process.Start(MotorContolPath);

            Thread.Sleep(500);

            // initialize input and output ComboBox
            for (int i = 0; i < MaxInChCount; i++) {
                cbInput.Items.Add($"Channel {i}");
            }
            for (int i = 0; i < MaxOutChCount; i++) {
                cbOutput.Items.Add($"Channel {i}");
            }

            // set the default value for all ComboBox to 0
            cbInput.SelectedIndex = 0;
            cbOutput.SelectedIndex = 0;
            cbMotorStat.SelectedIndex = 0;
            cbAxisName.SelectedIndex = 0;
            labelAxisName.Text = $"Axis Name: {axis_data["AxisName"][cbAxisName.SelectedItem.ToString()]}";

            // initialize GridDataView
            IODgv_Init();

            // initialize AutoCycle tab
            AutoCycleTab_Init();

            // initialize IO CheckBox
            OutputCB_Init();
        }

        // initialize motor status DataGridView column name
        private void IODgv_Init() {
            for (int i = 0; i < 16; i++) {
                dgvInput.Rows.Add(i.ToString());
                dgvOutput.Rows.Add(i.ToString());
            }

            string[] motor_stat = { "SVON", "Alarm", "Pos", "Vel", "Limit +", "Limit -" };

            foreach (string stat in motor_stat) {
                dgvMotorStat.Rows.Add(stat);
            }
        }

        private void AutoCycleTab_Init() {
            string[] motor_stat = { "SVON", "Alarm", "Pos", "Vel", "Limit +", "Limit -" };
            foreach (string stat in motor_stat) {
                dgvACXStatus.Rows.Add(stat);
                dgvACYStatus.Rows.Add(stat);
                dgvACZStatus.Rows.Add(stat);
            }

            tbACPosX1.Text = "10000";
            tbACPosX2.Text = "15000";
            tbACPosX3.Text = "5000";
            tbACPosY1.Text = "7500";
            tbACPosY2.Text = "15000";
            tbACPosY3.Text = "20000";
            tbACPosZ1.Text = "10";
            tbACPosZ2.Text = "5000";
        }

        private void OutputCB_Init() {
            for (int i = 0; i < 16; i++) cbSetOut_collecttion[i].Checked = (MotorIOData.DOch[cbOutput.SelectedIndex] & (1 << i)) != 0;
        }

        // re-initialize axis name without forgeting the last selected combobox index
        private void GetAxisName() {
            // read axis.ini
            axis_data = parser.ReadFile(axis_ini_path);

            // store the current ComboBox selected index
            var prev_axis = cbAxisName.SelectedIndex;
            var prev_motstat = cbMotorStat.SelectedIndex;

            // reset and set new ComboBox
            cbAxisName.Items.Clear();
            cbMotorStat.Items.Clear();

            foreach (var axis_name in axis_data["AxisName"]) {
                cbAxisName.Items.Add(axis_name.KeyName);
                cbMotorStat.Items.Add(axis_name.Value);
            }
            labelAxisName.Text = $"Axis Name: {axis_data["AxisName"][prev_axis.ToString()]}";

            // set the previous selected ComboBox index
            cbAxisName.SelectedIndex = prev_axis;
            cbMotorStat.SelectedIndex = prev_motstat;
        }

        // show list of .xml files in from tvPathInput
        private void buttonOpen_Click(object sender, EventArgs e) {
            lbLoadJoblist.Items.Clear();
            if (tbPathInput.Text == string.Empty) {
                MessageBox.Show("The path is empty.");
                return;
            }
            if (!Directory.Exists(tbPathInput.Text)) {
                MessageBox.Show("Directory do not exist.");
                return;
            }

            DirectoryInfo dinfo = new DirectoryInfo(tbPathInput.Text);
            FileInfo[] xml_files = dinfo.GetFiles("*.xml");

            if (xml_files.Length == 0) {
                MessageBox.Show("No files detected.");
                return;
            }

            foreach (FileInfo fi in xml_files) {
                lbLoadJoblist.Items.Add(fi.Name);
            }
        }

        // browse a folder and show list of .xml files in that direcroty
        private void buttonBrowse_Click(object sender, EventArgs e) {
            lbLoadJoblist.Items.Clear();
            using (var fbd = new FolderBrowserDialog()) {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {

                    tbPathInput.Text = fbd.SelectedPath;

                    DirectoryInfo dinfo = new DirectoryInfo(fbd.SelectedPath);
                    FileInfo[] xml_files = dinfo.GetFiles("*.xml");

                    if (xml_files.Length == 0) {
                        MessageBox.Show("No files detected");
                    }

                    foreach (FileInfo fi in xml_files) {
                        lbLoadJoblist.Items.Add(fi.Name);
                    }
                }
            }
        }

        // load the job file name and job list in the 3rd tab
        private void buttonLoad_Click(object sender, EventArgs e) {
            if (lbLoadJoblist.SelectedIndex == -1) {
                MessageBox.Show("Select the file you want to load.");
                return;
            }

            dgvJobList.Rows.Clear();

            // load the jobfile data and display in in the title
            var selected_jobfile = lbLoadJoblist.SelectedItem.ToString();
            labelJobName.Text = "Job File Name: " + selected_jobfile.Substring(0, selected_jobfile.Length - 4);

            // load job list in the motor control 3rd tab
            var joblist_xml_path = tbPathInput.Text + "\\" + lbLoadJoblist.SelectedItem.ToString();
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(joblist_xml_path);

                foreach (XmlNode node in doc.DocumentElement) {
                    string job_id = node["id"].InnerText;
                    string job_pos = node["pos"].InnerText;
                    string job_vel = node["vel"].InnerText;

                    dgvJobList.Rows.Add(job_id, job_pos, job_vel);
                }
            }
            catch (NullReferenceException) {
                MessageBox.Show("Error! You select the wrong file. Please try with other file.");
            }

        }

        // update checkbox when cbOutput cbOutput_SelectedIndexChanged
        private void cbOutput_SelectedIndexChanged(object sender, EventArgs e) {
            for (int i = 0; i < 16; i++) cbSetOut_collecttion[i].Checked = (MotorIOData.DOch[cbOutput.SelectedIndex] & (1 << i)) != 0;
        }

        // change axis name when cbAxisName_SelectedIndexChanged (tab 3)
        private void cbAxisName_SelectedIndexChanged(object sender, EventArgs e) {
            labelAxisName.Text = $"Axis Name: {axis_data["AxisName"][cbAxisName.SelectedItem.ToString()]}";
        }

        // set output value when the DataGridView is edited. auto get the index of edited cell.
        /*
        private void dgvOutput_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            string cell_data = dgvOutput.Rows[dgvOutput.CurrentCellAddress.Y].Cells[1].Value.ToString();
            bool isNumeric = int.TryParse(cell_data, out _);

            if (isNumeric) {
                // read the motor axis data
                MotorIOAccessor.Read<MotorIOStruct>(0, out MotorIOData);

                // write new data
                MotorIOData.COMMAND = COMMAND_SET_OUTPUT;
                MotorIOData.OutBit = dgvOutput.CurrentCellAddress.Y;
                MotorIOData.OutValue = Int32.Parse(dgvOutput.Rows[dgvOutput.CurrentCellAddress.Y].Cells[1].Value.ToString());
                MotorIOData.OutCh = cbOutput.SelectedIndex;
                MotorIOAccessor.Write<MotorIOStruct>(0, ref MotorIOData);
            }
            else {
                MessageBox.Show("Please enter 1 or 0");
            }
        }
        */

        private void buttonSave_Click(object sender, EventArgs e) {
            string filePath = tbPathInput.Text + "\\" + lbLoadJoblist.GetItemText(lbLoadJoblist.SelectedItem);
            var format = filePath.Substring(filePath.Length - 4);
            //Debug.WriteLine(tbPathInput.Text);

            if (format != ".ini" && format != ".xml") {
                MessageBox.Show("Please enter file name with .ini or .xml format.");
                return;
            }

            try {
                // Check if file already exists. If yes, delete it.
                if (File.Exists(filePath)) {
                    File.Delete(filePath);
                }

                // Create a new file
                var myFile = File.Create(filePath);
                myFile.Close();
            }
            catch (Exception Ex) {
                Console.WriteLine(Ex.ToString());
            }

            // save to .xml files
            XmlTextWriter textWriter = new XmlTextWriter(filePath, null);

            textWriter.Formatting = Formatting.Indented;
            textWriter.Indentation = 4;
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("joblist");
            for (int rows = 0; rows < dgvJobList.Rows.Count; rows++) {
                //Debug.WriteLine(dgvJobList.Rows[rows].Cells[0].Value.ToString());

                DataGridViewRow currentRow = dgvJobList.Rows[rows];
                string ID = currentRow.Cells["dgvJobID"].Value.ToString();
                string pos = currentRow.Cells["dgvJobPos"].Value.ToString();
                string vel = currentRow.Cells["dgvJobVel"].Value.ToString();

                textWriter.WriteStartElement("job");
                textWriter.WriteElementString("id", ID);
                textWriter.WriteElementString("pos", pos);
                textWriter.WriteElementString("vel", vel);
                textWriter.WriteEndElement();
            }
            textWriter.WriteEndElement();
            textWriter.WriteEndDocument();
            textWriter.Close();
        }

        private void buttonMoveAbs_Click(object sender, EventArgs e) {
            if (dgvJobList.SelectedRows.Count == 0) {
                MessageBox.Show("Select the position and velocity.");
                return;
            }

            int selectedrowindex = dgvJobList.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvJobList.Rows[selectedrowindex];
            double pos = double.Parse(selectedRow.Cells["dgvJobPos"].Value.ToString());
            double vel = double.Parse(selectedRow.Cells["dgvJobVel"].Value.ToString());



            // write new data
            CmdMMF.ReadLock(ref CmdData);
            CmdData.COMMAND = COMMAND_MOVE_ABS;
            CmdData.axis = cbAxisName.SelectedIndex;
            CmdData.ComPos = pos;
            CmdData.ComVel = vel;
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);

            Debug.WriteLine(CmdData.ComPos);
        }

        private void buttonMoveRel_Click(object sender, EventArgs e) {
            if (dgvJobList.SelectedRows.Count == 0) {
                MessageBox.Show("Select the position and velocity.");
                return;
            }

            int selectedrowindex = dgvJobList.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvJobList.Rows[selectedrowindex];
            double pos = double.Parse(selectedRow.Cells["dgvJobPos"].Value.ToString());
            double vel = double.Parse(selectedRow.Cells["dgvJobVel"].Value.ToString());

            // write new data
            CmdMMF.ReadLock(ref CmdData);
            CmdData.COMMAND = COMMAND_MOVE_REL;
            CmdData.axis = cbAxisName.SelectedIndex;
            CmdData.ComPos = pos;
            CmdData.ComVel = vel;
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);
        }

        private void buttonStop_Click(object sender, EventArgs e) {
            // write new data
            CmdMMF.ReadLock(ref CmdData);
            CmdData.COMMAND = COMMAND_STOP;
            CmdData.axis = cbAxisName.SelectedIndex;
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);
        }

        private void buttonSVON_Click(object sender, EventArgs e) {
            // write new data
            CmdMMF.ReadLock(ref CmdData);
            CmdData.COMMAND = COMMAND_SVON;
            CmdData.axis = cbAxisName.SelectedIndex;
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);
        }

        private void buttonSVOFF_Click(object sender, EventArgs e) {
            // write new data
            CmdMMF.ReadLock(ref CmdData);
            CmdData.COMMAND = COMMAND_SVOFF;
            CmdData.axis = cbAxisName.SelectedIndex;
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo)) {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    CmdMMF.ReadLock(ref CmdData);
                    CmdData.is_closed = true;
                    //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
                    CmdMMF.Write(ref CmdData);
                    break;
            }
        }

        // update I/O and motor status using Timer
        private void timer1_Tick(object sender, EventArgs e) {
            // read the motor axis data first to record all the variable first time
            // (otherwise when write the MotorIOData.axis other value will be not initialized)
            //MotorIOAccessor.Read<MotorIOStruct>(0, out MotorIOData);
            //CmdAccessor.Read<CmdStruct>(0, out CmdData);
            //MotorIOMMF.ReadRelease(ref MotorIOData);

            // we only use 1 shared memory the store the status of 4 motors/axises (only store the status of 1 motor/axis at a time)
            // this if condition is to change which motor/axis index to store (because tab 1 and tab 2 may request different motor status information)
            // only the status of this axis will be stored in the shared memory
            //MotorIOMMF.ReadLock(ref MotorIOData);
            //MotorIOData.InChSelected = cbInput.SelectedIndex;
            //MotorIOData.OutChSelected = cbOutput.SelectedIndex; // maybe the output no need to do this because the source is from HMI so no need to update everytime
            //MotorIOAccessor.Write<MotorIOStruct>(0, ref MotorIOData);
            //MotorIOMMF.Write(ref MotorIOData);

            // re-initialize axis name without forgeting the last selected combobox index
            GetAxisName();

            // read motor and IO data
            MotorIOMMF.ReadRelease(ref MotorIOData);

            //----------------------------------------------------------------------------
            // Read the motor/axis data
            //----------------------------------------------------------------------------
            // update motor status tab 2
            dgvMotorStat.Rows[0].Cells[1].Value = MotorIOData.Motor[cbMotorStat.SelectedIndex].SVON;
            dgvMotorStat.Rows[1].Cells[1].Value = MotorIOData.Motor[cbMotorStat.SelectedIndex].alarm;
            dgvMotorStat.Rows[2].Cells[1].Value = MotorIOData.Motor[cbMotorStat.SelectedIndex].pos;
            dgvMotorStat.Rows[3].Cells[1].Value = MotorIOData.Motor[cbMotorStat.SelectedIndex].vel;
            dgvMotorStat.Rows[4].Cells[1].Value = MotorIOData.Motor[cbMotorStat.SelectedIndex].limit_max;
            dgvMotorStat.Rows[5].Cells[1].Value = MotorIOData.Motor[cbMotorStat.SelectedIndex].limit_min;

            // update motor status tab 3
            tbSVON.Text = MotorIOData.Motor[cbAxisName.SelectedIndex].SVON.ToString();
            tbAlarm.Text = MotorIOData.Motor[cbAxisName.SelectedIndex].alarm.ToString();
            tbPos.Text = MotorIOData.Motor[cbAxisName.SelectedIndex].pos.ToString();
            tbVel.Text = MotorIOData.Motor[cbAxisName.SelectedIndex].vel.ToString();
            tbLim1.Text = MotorIOData.Motor[cbAxisName.SelectedIndex].limit_max.ToString();
            tbLim2.Text = MotorIOData.Motor[cbAxisName.SelectedIndex].limit_min.ToString();

            // update motor status tab 4
            dgvACXStatus.Rows[0].Cells[1].Value = MotorIOData.Motor[0].SVON;
            dgvACXStatus.Rows[1].Cells[1].Value = MotorIOData.Motor[0].alarm;
            dgvACXStatus.Rows[2].Cells[1].Value = MotorIOData.Motor[0].pos;
            dgvACXStatus.Rows[3].Cells[1].Value = MotorIOData.Motor[0].vel;
            dgvACXStatus.Rows[4].Cells[1].Value = MotorIOData.Motor[0].limit_max;
            dgvACXStatus.Rows[5].Cells[1].Value = MotorIOData.Motor[0].limit_min;

            dgvACYStatus.Rows[0].Cells[1].Value = MotorIOData.Motor[1].SVON;
            dgvACYStatus.Rows[1].Cells[1].Value = MotorIOData.Motor[1].alarm;
            dgvACYStatus.Rows[2].Cells[1].Value = MotorIOData.Motor[1].pos;
            dgvACYStatus.Rows[3].Cells[1].Value = MotorIOData.Motor[1].vel;
            dgvACYStatus.Rows[4].Cells[1].Value = MotorIOData.Motor[1].limit_max;
            dgvACYStatus.Rows[5].Cells[1].Value = MotorIOData.Motor[1].limit_min;

            dgvACZStatus.Rows[0].Cells[1].Value = MotorIOData.Motor[2].SVON;
            dgvACZStatus.Rows[1].Cells[1].Value = MotorIOData.Motor[2].alarm;
            dgvACZStatus.Rows[2].Cells[1].Value = MotorIOData.Motor[2].pos;
            dgvACZStatus.Rows[3].Cells[1].Value = MotorIOData.Motor[2].vel;
            dgvACZStatus.Rows[4].Cells[1].Value = MotorIOData.Motor[2].limit_max;
            dgvACZStatus.Rows[5].Cells[1].Value = MotorIOData.Motor[2].limit_min;

            //----------------------------------------------------------------------------
            // Read the I/O data
            //----------------------------------------------------------------------------
            // Input
            for (int i = 0; i != 16; i++) dgvInput.Rows[i].Cells[1].Value = ((MotorIOData.DIch[cbInput.SelectedIndex] & (1 << i)) != 0) ? 1 : 0;
            // Output
            for (int i = 0; i != 16; i++) dgvOutput.Rows[i].Cells[1].Value = ((MotorIOData.DOch[cbOutput.SelectedIndex] & (1 << i)) != 0) ? 1 : 0;

            //Debug.WriteLine(CmdData.ACSTAT);

            //----------------------------------------------------------------------------
            // Read the Auto Cycle data
            //----------------------------------------------------------------------------
            CmdMMF.ReadRelease(ref CmdData);
            if (CmdData.ACSTAT == ACSTAT_READY) {
                tbACStatus.Text = "Ready";
            }
            else if (CmdData.ACSTAT == ACSTAT_IDLE) {
                tbACStatus.Text = "Idle";
            }
            else if (CmdData.ACSTAT == ACSTAT_START) {
                tbACStatus.Text = "Start";
            }
            else if (CmdData.ACSTAT == ACSTAT_STOP) {
                tbACStatus.Text = "Stop";
            }
            else if (CmdData.ACSTAT == ACSTAT_HOMING) {
                tbACStatus.Text = "Homing";
            }
        }

        private void cbSetOut_CheckedChanged(object sender, EventArgs e) {

            if (selected_RB != 0) return;

            CheckBox selCB = sender as CheckBox;
            int tagCB = Convert.ToInt32(selCB.Tag);

            if (selCB.Checked == Convert.ToBoolean((MotorIOData.DOch[cbOutput.SelectedIndex] & (1 << tagCB)) != 0)) {
                return;
            }

            // write new data
            CmdMMF.ReadLock(ref CmdData);
            CmdData.COMMAND = COMMAND_SET_OUTPUT;
            CmdData.OutBit = tagCB;
            CmdData.OutValue = Convert.ToInt32(selCB.Checked);
            CmdData.OutCh = cbOutput.SelectedIndex;
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);
        }

        private static byte ConvertBoolArrayToByte(bool[] source) {
            byte result = 0;
            // This assumes the array never contains more than 8 elements!
            int index = 8 - source.Length;

            // Loop through the array
            foreach (bool b in source) {
                // if the element is 'true' set the bit at that position
                if (b)
                    result |= (byte)(1 << (7 - index));

                index++;
            }

            return result;
        }

        private void buttonSetOutCh_Click(object sender, EventArgs e) {
            // write new data
            bool[] cbOut1 = new bool[8];
            bool[] cbOut2 = new bool[8];

            for (int j = 0; j < 8; j++) cbOut1[j] = cbSetOut_collecttion[j].Checked;
            for (int j = 8; j < 16; j++) cbOut2[j - 8] = cbSetOut_collecttion[j].Checked;

            Array.Reverse(cbOut1);
            Array.Reverse(cbOut2);

            byte cbOutByte1 = ConvertBoolArrayToByte(cbOut1);
            byte cbOutByte2 = ConvertBoolArrayToByte(cbOut2);

            ushort bc = BitConverter.ToUInt16(new byte[2] { (byte)cbOutByte1, (byte)cbOutByte2 }, 0);

            CmdMMF.ReadLock(ref CmdData);
            CmdData.COMMAND = COMMAND_SET_OUTPUT_CH;
            CmdData.OutCh = cbOutput.SelectedIndex;
            int i = cbOutput.SelectedIndex;
            CmdData.OutChValue = bc;
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            selected_RB = 0;
            buttonSetOutCh.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            selected_RB = 1;
            buttonSetOutCh.Enabled = true;
        }

        private void buttonGetOutChArr_Click(object sender, EventArgs e) {
            var isStartNumeric = int.TryParse(tbChStart.Text.ToString(), out int start);
            var isSizeNumeric = int.TryParse(tbChSize.Text.ToString(), out int size);
            if (!isStartNumeric && !isSizeNumeric) {
                MessageBox.Show("Please enter a number");
                return;
            }
            if (start > MaxOutChCount) {
                MessageBox.Show("Index out of range. Channel Index is too big.");
                return;
            }
            if (start + size > MaxOutChCount) {
                MessageBox.Show("Index out of range. Channel Size is too big");
                return;
            }

            // write new data
            CmdMMF.ReadLock(ref CmdData);
            CmdData.COMMAND = COMMAND_GET_OUTPUT_CH_ARRAY;
            CmdData.OutChArrStart = Int32.Parse(tbChStart.Text.ToString());
            CmdData.OutChArrSize = Int32.Parse(tbChSize.Text.ToString());
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);
        }

        private void buttonResetAlrm_Click(object sender, EventArgs e) {
            // write new data
            CmdMMF.ReadLock(ref CmdData);
            CmdData.COMMAND = COMMAND_ALARM_RESET;
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);
        }

        private void buttonACStart1_Click(object sender, EventArgs e) {
            if (CmdData.ACSTAT != ACSTAT_READY) {
                MessageBox.Show("Status is not Ready", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            System.Windows.Forms.TextBox[] tbACPos_collection = { tbACPosX1, tbACPosX1, tbACPosX1,
                                             tbACPosY1, tbACPosY1, tbACPosY1,
                                             tbACPosZ1, tbACPosZ2};
            for (int i = 0; i < 8; i++) {
                if (string.IsNullOrEmpty(tbACPos_collection[i].Text)) {
                    MessageBox.Show("Plese fill all the position");
                    return;
                }
                if (!int.TryParse(tbACPos_collection[i].Text.ToString(), out _)) {
                    MessageBox.Show("Please enter a number");
                    return;
                }
            }

            CmdMMF.ReadLock(ref CmdData);
            CmdData.COMMAND = COMMAND_AC_START1;
            CmdData.PosX1 = double.Parse(tbACPosX1.Text.ToString());
            CmdData.PosX2 = double.Parse(tbACPosX2.Text.ToString());
            CmdData.PosX3 = double.Parse(tbACPosX3.Text.ToString());
            CmdData.PosY1 = double.Parse(tbACPosY1.Text.ToString());
            CmdData.PosY2 = double.Parse(tbACPosY2.Text.ToString());
            CmdData.PosY3 = double.Parse(tbACPosY3.Text.ToString());
            CmdData.PosZ1 = double.Parse(tbACPosZ1.Text.ToString());
            CmdData.PosZ2 = double.Parse(tbACPosZ2.Text.ToString());
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);
        }

        private void buttonACStart2_Click(object sender, EventArgs e) {
            if (CmdData.ACSTAT != ACSTAT_READY) {
                MessageBox.Show("Status is not Ready", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            System.Windows.Forms.TextBox[] tbACPos_collection = { tbACPosX1, tbACPosX1, tbACPosX1,
                                             tbACPosY1, tbACPosY1, tbACPosY1,
                                             tbACPosZ1, tbACPosZ2};
            for (int i = 0; i < 8; i++) {
                if (string.IsNullOrEmpty(tbACPos_collection[i].Text)) {
                    MessageBox.Show("Plese fill all the position");
                    return;
                }
                if (!int.TryParse(tbACPos_collection[i].Text.ToString(), out _)) {
                    MessageBox.Show("Please enter a number");
                    return;
                }
            }

            CmdMMF.ReadLock(ref CmdData);
            CmdData.COMMAND = COMMAND_AC_START2;
            CmdData.PosX1 = double.Parse(tbACPosX1.Text.ToString());
            CmdData.PosX2 = double.Parse(tbACPosX2.Text.ToString());
            CmdData.PosX3 = double.Parse(tbACPosX3.Text.ToString());
            CmdData.PosY1 = double.Parse(tbACPosY1.Text.ToString());

            CmdData.PosY2 = double.Parse(tbACPosY2.Text.ToString());
            CmdData.PosY3 = double.Parse(tbACPosY3.Text.ToString());
            CmdData.PosZ1 = double.Parse(tbACPosZ1.Text.ToString());
            CmdData.PosZ2 = double.Parse(tbACPosZ2.Text.ToString());
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);
        }

        private void buttonACStop_Click(object sender, EventArgs e) {
            CmdMMF.ReadLock(ref CmdData);
            CmdData.COMMAND = COMMAND_STOP_AUTO_CYCLE;
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);
        }

        private void buttonACHome_Click(object sender, EventArgs e) {
            if (CmdData.ACSTAT == ACSTAT_START) {
                MessageBox.Show("Stop the motor first", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // write new data
            CmdMMF.ReadLock(ref CmdData);
            CmdData.COMMAND = COMMAND_HOME;
            //CmdAccessor.Write<CmdStruct>(0, ref CmdData);
            CmdMMF.Write(ref CmdData);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
