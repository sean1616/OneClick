using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Runtime.InteropServices;


namespace OneClick
{
    public partial class Script_Form : MetroFramework.Forms.MetroForm
    {
        SetupIniIP ini;
        Actions_Collection AC;

        System.Windows.Forms.Timer timer_cursor;
        //System.Windows.Forms.Timer timer_timespan;

        DataGridViewRow pause_dg = new DataGridViewRow();
        DataTable dt;
        private Hocy_Hook hook_Main = new Hocy_Hook();
        string csvpath;
        internal string selected_csv;
        bool capture_checkbox_status = false;
        bool record_checkbox_status = false;

        DateTime scriptProcessTime = new DateTime();

        bool continued_check = false;
        Keys key;
        Form1 form_main;

        DateTime dtn;
        System.Threading.Timer timer_TimeSpan;

        int lines_count = 0;

        public Script_Form(Form1 form_main, string selected_csv)
        {
            InitializeComponent();

            this.form_main = form_main;

            AC = new Actions_Collection();

            this.selected_csv = selected_csv;
            
            this.TopMost = true;           

            this.hook_Main.OnKeyDown += new KeyEventHandler(hook_KeyDown);
            this.hook_Main.OnMouseActivity += new MouseEventHandler(hook_MouseEvent);


            //System.timer.timer
            timer_cursor = new System.Windows.Forms.Timer();
            timer_cursor.Interval = 100;
            timer_cursor.Tick += timer_cursor_Tick;

            //timer_timespan = new System.Windows.Forms.Timer();
            //timer_timespan.Interval = 100;
            //timer_timespan.Tick += timer_cursor_Tick;

            scriptProcessTime = DateTime.Now;
        }

        private void hook_MouseEvent(object sender, MouseEventArgs e)
        {
            txt_ms_X.Text = e.X.ToString();
            txt_ms_Y.Text = e.Y.ToString();

            TimeSpan delta_dt = DateTime.Now - scriptProcessTime;
            scriptProcessTime = DateTime.Now;

            if (e.Clicks == 1)
            {
                //wait row
                string[] row_delay = new string[] { (dt.Rows.Count + 1).ToString(), "Delay", delta_dt.TotalMilliseconds.ToString(), "ms" };
                Update_Table(row_delay);

                //click row
                string btn_click = "";
                btn_click = e.Button.ToString() == "Left" ? "Click" : "RClick";

                string[] axis = new string[] { (dt.Rows.Count + 1).ToString(), btn_click, e.X.ToString(), e.Y.ToString() };
                Update_Table(axis);
                
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", (dt.Rows.Count + 1).ToString(), "Click", e.X.ToString(), e.Y.ToString(), e.Button, delta_dt.TotalMilliseconds);
            }
        }

        private async void hook_MainKeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
            if (e.KeyCode == Keys.F1 && capture_checkbox_status == true)
            {
                Write_Click(e);
            }
            else if (e.KeyCode == Keys.F5 && capture_checkbox_status == true)
            {
                Write_RClick(e);
            }
            else if (e.KeyCode == Keys.F2 && capture_checkbox_status == true)
            {
                Write_Delay();
            }
            else if (e.KeyCode == Keys.F3 && capture_checkbox_status == true)
            {
                Write_Key();
            }
            else if (e.KeyCode == Keys.F4 && capture_checkbox_status == true)
            {
                Write_WaitKey();
            }
            else if (e.KeyCode == key)
            {
                foreach (DataGridViewRow dg in dataGridView_script.Rows)
                {
                    if (dg != pause_dg && continued_check != true)
                    {
                        //Do nothing
                    }
                    else if (dg == pause_dg)
                    {
                        continued_check = true;
                    }
                    else
                    {
                        string sw_string = dg.Cells[1].Value.ToString();
                        string X = dg.Cells[2].Value.ToString();
                        string Y = dg.Cells[3].Value.ToString();
                        switch (sw_string)
                        {
                            case "Click":
                                Point p = new Point(Convert.ToInt32(dg.Cells[2].Value), Convert.ToInt32(dg.Cells[3].Value));
                                AC.Action_Click(p);
                                break;

                            case "Delay":
                                await AC.Action_Delay(X, Y);
                                break;

                            case "Key":
                                AC.Action_Key(X, Y);
                                break;

                            case "WaitKey":
                                key = AC.Action_WaitKey(X, Y);
                                pause_dg = dg;
                                return;
                        }
                    }
                }
                hook_Main.UnInstallHook();
            }

            //Set form size
            dataGridView_script.Height = dataGridView_script.RowTemplate.Height * dataGridView_script.Rows.Count + dataGridView_script.ColumnHeadersHeight + 24;
            //this.Height = dataGridView_script.Height + 127;

            this.Size = new Size(Size.Width, dataGridView_script.RowCount * 24 + 205);
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            TimeSpan delta_dt = DateTime.Now - scriptProcessTime;
            scriptProcessTime = DateTime.Now;

            //wait row
            string[] row_delay = new string[] { (dt.Rows.Count + 1).ToString(), "Delay", delta_dt.TotalMilliseconds.ToString(), "ms" };
            Update_Table(row_delay);

            string keyInput = keycode_tranform(e.KeyData.ToString());

            string[] row = new string[] { (dt.Rows.Count + 1).ToString(), "Key", keyInput, "" };
            Update_Table(row);

            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", (dt.Rows.Count + 1).ToString(), "Key", e.KeyCode, "", "", delta_dt.TotalMilliseconds.ToString());
        }

        private string keycode_tranform(string keycode)
        {
            string final_result = "";

            if (keycode.Contains("NumPad"))
                final_result = keycode.Replace("NumPad", "");
            else if (keycode.Contains("ControlKey"))
                final_result = "Ctrl";
            else if (keycode.Contains("Menu"))
                final_result = "Alt";
            else if (keycode.Contains("ShiftKey"))
                final_result = "Shift";
            else
            {
                switch (keycode)
                {
                    case "Return":
                        final_result = "Enter";
                        break;
                    case "Back":
                        final_result = "Backspace";
                        break;
                    case "Escape":
                        final_result = "ESC";
                        break;
                    case "Tab":
                        final_result = "TAB";
                        break;
                    case "Add":
                        final_result = "+";
                        break;
                    case "Multiply":
                        final_result = "*";
                        break;
                    case "Subtract":
                        final_result = "-";
                        break;
                    case "Divide":
                        final_result = "/";
                        break;
                    case "Decimal":
                        final_result = ".";
                        break;
                    default:
                        final_result = keycode;
                        break;
                }
            }

            return final_result;
        }

        private void Script_Form_Load(object sender, EventArgs e)
        {
            txtBox_name.Text = selected_csv;

            csvpath = Application.StartupPath + @"\" + selected_csv + ".csv";

            dt = new DataTable();
            try
            {
                string[] lines = File.ReadAllLines(csvpath);

                lines_count = lines.Count();

                if (lines.Length > 0)
                {
                    //first line to create header
                    string firstLine = lines[0];
                    string[] headerLabels = firstLine.Split(',');

                    foreach (string headerWord in headerLabels)
                    {
                        dt.Columns.Add(new DataColumn(headerWord));
                    }

                    try
                    {
                        //for data
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] datas = lines[i].Split(',');
                            DataRow dr = dt.NewRow();
                            int columIndex = 0;
                            foreach (string headerWord in headerLabels)
                            {
                                dr[headerWord] = datas[columIndex++];
                            }
                            dt.Rows.Add(dr);

                            //dataGridView_script.AutoResizeColumns();
                            dataGridView_script.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("File format is wrong.");
                        return;
                    }
                }

                if (dt.Rows.Count > 0)
                    dataGridView_script.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("File is opened in another program.");
                return;
            }

            //Set form size
            dataGridView_script.Height = dataGridView_script.RowTemplate.Height * dataGridView_script.Rows.Count + dataGridView_script.ColumnHeadersHeight + 24;
            //this.Height = dataGridView_script.Height + 127;

            this.Size = new Size(Size.Width , lines_count * 24 + 205);   //Resize form by the number of data rows, 1 line = 24 heigh
        }

        private void timer_cursor_Tick(object Sender, EventArgs e)
        {
            Point point = Cursor.Position;

            txt_ms_X.Text = point.X.ToString();
            txt_ms_Y.Text = point.Y.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        //Delete button
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView_script.SelectedRows.Count > 0 && !dataGridView_script.SelectedRows[0].IsNewRow)
                dataGridView_script.Rows.Remove(dataGridView_script.SelectedRows[0]);
        }

        //Save button
        private void button4_Click(object sender, EventArgs e)
        {
            //Clear file content and lock the file
            FileStream fileStream = File.Open(csvpath, FileMode.Open);
            fileStream.SetLength(0);
            fileStream.Close();

            //Save datagridview_script to a string builder
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < dataGridView_script.Columns.Count; i++)
            {
                if (dataGridView_script.Columns[i].HeaderCell == null)
                    return;

                stringBuilder.Append(dataGridView_script.Columns[i].HeaderText);
                if(i<dataGridView_script.Columns.Count-1)
                    stringBuilder.Append(",");
            }

            stringBuilder.AppendLine();

            foreach(DataGridViewRow dg in dataGridView_script.Rows)
            {                
                //for data
                for (int i = 0; i < dataGridView_script.ColumnCount; i++)
                {
                    if (dg.Cells[i].Value != null)
                    {
                        stringBuilder.Append(dg.Cells[i].Value);
                        stringBuilder.Append(",");                        
                    }
                    else
                    {
                        stringBuilder.Append(" ,");
                    }                    
                }
                stringBuilder.AppendLine();
            }
                        
            File.AppendAllText(csvpath, stringBuilder.ToString());  //Save string builder to csv

            string csvpath_rename = Application.StartupPath + @"\" + txtBox_name.Text + ".csv"; 
            File.Move(csvpath, csvpath_rename);
        }

        private void _do(object state)
        {
            this.BeginInvoke(new setLable2(setLable));            
        }

        delegate void setLable2();
        private void setLable()
        {
            if (label_timespan != null)
                label_timespan.Text = Math.Round((DateTime.Now - dtn).TotalSeconds, 1).ToString();
        }

        //GO button
        private async void btn_GO_Click(object sender, EventArgs e)
        {
            if (btn_go.Text.Equals("Go"))
            {
                btn_go.Text = "Stop";

                dtn = DateTime.Now;

                //System.threading.timer            
                TimerCallback callback = new TimerCallback(_do);  //宣告timer要做什麼事.要做什麼事呢?要做_do的事
                timer_TimeSpan = new System.Threading.Timer(callback, null, 0, 1000);  //Timer start

                try
                {
                    foreach (DataGridViewRow dg in dataGridView_script.Rows)
                    {
                        string sw_string = dg.Cells[1].Value.ToString();
                        string X = dg.Cells[2].Value.ToString();
                        string Y = dg.Cells[3].Value.ToString();
                        switch (sw_string)
                        {
                            case "Click":
                                Point p = new Point(Convert.ToInt32(dg.Cells[2].Value), Convert.ToInt32(dg.Cells[3].Value));
                                AC.Action_Click(p);
                                break;

                            case "RClick":
                                p = new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
                                AC.Action_RightClick(p);
                                break;

                            case "Delay":
                                AC.tokenSource = new CancellationTokenSource();
                                await AC.Action_Delay(X, Y);
                                break;

                            case "Key":
                                AC.Action_Key(X, Y);
                                break;

                            case "String":
                                AC.Action_KeyString(X);
                                break;

                            case "WaitKey":
                                key = AC.Action_WaitKey(X, Y);
                                pause_dg = dg;
                                hook_Main.InstallHook("1");
                                return;
                        }
                    }
                }
                catch 
                {
                    //MessageBox.Show(ex.StackTrace.ToString());
                }

                timer_TimeSpan.Dispose();  //Timer stop    

                btn_go.Text = "Go";
            }
            else
            {
                AC.tokenSource.Cancel();
            }
        }

        private void datascript_rowcount_changed()
        {
            int i = 1;
            foreach (DataRow dataRow in dt.Rows)
            {
                
                dataRow[0] = i++;
            }
        }

        private void script_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Click_Check_CheckedChanged(object sender, EventArgs e)
        {
            record_checkbox_status = false;
            ckBox_Record.Checked = false;

            capture_checkbox_status = !capture_checkbox_status;

            if (capture_checkbox_status == true)
            {
                hook_Main.InstallHook("1"); //開啟掛鉤
                timer_cursor.Start();
            }
            else
                timer_cursor.Stop();   
        }

        private void ckBox_Record_CheckedChanged(object sender, EventArgs e)
        {
            capture_checkbox_status = false;
            Click_Check.Checked = false;

            record_checkbox_status = !record_checkbox_status;

            if (record_checkbox_status)
            {
                hook_Main.InstallHook("1"); //開啟掛鉤

                scriptProcessTime = DateTime.Now;
            }
            else
            {
                hook_Main.UnInstallHook();
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.RemoveAt(dt.Rows.Count - 1);
                    dt.Rows.RemoveAt(dt.Rows.Count - 1);

                    //Set form size
                    dataGridView_script.Height = dataGridView_script.RowTemplate.Height * dataGridView_script.Rows.Count + dataGridView_script.ColumnHeadersHeight + 24;
                    this.Size = new Size(Size.Width, dataGridView_script.RowCount * 24 + 205);
                }
            }
        }

        #region Functions Collection
        private void Write_Click(KeyEventArgs e)
        {
            Point point = Cursor.Position;
            
            string[] axis = new string[] { (dt.Rows.Count+1).ToString(), "Click", point.X.ToString(), point.Y.ToString() };

            Update_Table(axis);
        }

        private void Write_RClick(KeyEventArgs e)
        {
            Point point = Cursor.Position;

            string[] axis = new string[] { (dt.Rows.Count + 1).ToString(), "RClick", point.X.ToString(), point.Y.ToString() };

            Update_Table(axis);
        }

        private void Write_Delay()
        {
            string[] row = new string[] { (dt.Rows.Count + 1).ToString(), "Delay", "100", "ms" };

            Update_Table(row);
        }

        private void Write_Key()
        {
            string[] row = new string[] { (dt.Rows.Count + 1).ToString(), "Key", "", "" };

            Update_Table(row);
        }

        private void Write_WaitKey()
        {
            string[] row = new string[] { (dt.Rows.Count + 1).ToString(), "WaitKey", "", "" };

            Update_Table(row);
        }

        private void Update_Table(string[] row)
        {
            //添加表格内容   
            string[] lines = File.ReadAllLines(csvpath);
            string[] headers = lines[0].Split(',');

            DataRow dr = dt.NewRow();
            int columIndex = 0;
            foreach (string header in headers)
            {
                dr[header] = row[columIndex++];
            }
            dt.Rows.Add(dr);

            dataGridView_script.DataSource = dt;

            //Set form size
            dataGridView_script.Height = dataGridView_script.RowTemplate.Height * dataGridView_script.Rows.Count + dataGridView_script.ColumnHeadersHeight + 24;

            this.Size = new Size(Size.Width, dataGridView_script.RowCount * 24 + 205);

            //dataGridView_script.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //this.Size = new Size(this.Size.Width, this.Size.Height + 20);
        }
        #endregion

        DataGridViewRow dr;
        private void dataGridView_script_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {          
            if(dataGridView_script.SelectedRows.Count > 0)
                dr = dataGridView_script.SelectedRows[0];            
        }

        private void dataGridView_script_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridView_script.Width = dataGridView_script.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 65;
            this.Width = dataGridView_script.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 88;
        }

        private void dataGridView_script_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            datascript_rowcount_changed();
        }
                
        private void dataGridView_script_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            datascript_rowcount_changed();
        }

        private void txtBox_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Script_Form_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("F1=Click, \nF2=Delay(ms, s, m, hr), \nF3=Key, \nF4=WaitKey, \nF5=RClick \nString function is for continue string");
        }

        private void Script_Form_Resize(object sender, EventArgs e)
        {
            //MessageBox.Show(this.Size.Height.ToString());
        }

        Thread thread;
        private void Script_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            record_checkbox_status = !record_checkbox_status;

            if (!record_checkbox_status)
                hook_Main.UnInstallHook(); //關閉掛鉤

            AC.tokenSource.Cancel();
            thread = new Thread(new ParameterizedThreadStart(form_main.Update_datatable));  //執行腳本的執行緒
            thread.IsBackground = true;
            thread.Start();
        }

        //New Button
        private void metroButton1_Click(object sender, EventArgs e)
        {
            int scriptIndex = 1;

            StringBuilder csvcontent = new StringBuilder();  //動態字串

            //Add grid header
            csvcontent.Append("No.,");
            csvcontent.Append("Event,");
            csvcontent.Append("X,");
            csvcontent.Append("Y");
            csvcontent.Append("Note");

            csvpath = Application.StartupPath + @"\" + "Script_" + scriptIndex.ToString() + ".csv";

            for (int i = 1; i <= 30; i++)
            {
                if (!File.Exists(csvpath))
                {
                    File.AppendAllText(csvpath, csvcontent.ToString());
                    return;
                }
                else
                    scriptIndex++;
                csvpath = Application.StartupPath + @"\" + "Script_" + scriptIndex.ToString() + ".csv";
            }
        }

        //Insert Button
        private void metroButton2_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();
            if (dataGridView_script.CurrentCell != null)
                dt.Rows.InsertAt(dr, dataGridView_script.CurrentCell.RowIndex + 1);

            int i = 1;
            foreach (DataRow dataRow in dt.Rows)
            {
                dataRow[0] = i++;
            }
        }

        
    }


}
