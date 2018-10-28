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


namespace MouseClick_x01
{
    public partial class Script_Form : Form
    {
        SetupIniIP ini;
        Actions_Collection AC;
        
        int index_list;
        DataTable dt;
        private Hocy_Hook hook_Main = new Hocy_Hook();
        string csvpath;
        internal string selected_csv;
        bool capture_checkbox_status = false;

        public Script_Form(string selected_csv)
        {
            InitializeComponent();

            AC = new Actions_Collection();

            this.selected_csv = selected_csv;
            
            this.TopMost = true;           

            this.hook_Main.OnKeyDown += new KeyEventHandler(hook_MainKeyDown);
        }

        private void Script_Form_Load(object sender, EventArgs e)
        {
            csvpath = Application.StartupPath + @"\" + selected_csv + ".csv";

            dt = new DataTable();
            try
            {
                string[] lines = File.ReadAllLines(csvpath);
                
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
            this.Height = dataGridView_script.Height + 127;
        }

        //New button
        private void button1_Click(object sender, EventArgs e)
        {
            int scriptIndex = 1;

            StringBuilder csvcontent = new StringBuilder();  //動態字串

            //Add grid header
            csvcontent.Append("No.,");
            csvcontent.Append("Event,");
            csvcontent.Append("X,");
            csvcontent.Append("Y");

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
        }

        //GO button
        private void button5_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dg in dataGridView_script.Rows)
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
                        AC.Action_Delay(X);
                        break;

                    case "Key":
                        AC.Action_Key(X, Y);
                        break;
                }               
            }            
        }

        private void script_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Click_Check_CheckedChanged(object sender, EventArgs e)
        {
            capture_checkbox_status = !capture_checkbox_status;

            if (capture_checkbox_status==true)
                hook_Main.InstallHook("1"); //開啟掛鉤
        }

        private void hook_MainKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && capture_checkbox_status == true)
            {
                Write_Click(e);                
            }
            else if (e.KeyCode == Keys.F2 && capture_checkbox_status == true)
            {
                Write_Delay();
            }
            else if (e.KeyCode == Keys.F3 && capture_checkbox_status == true)
            {
                Write_Key();
            }

            //Set form size
            dataGridView_script.Height = dataGridView_script.RowTemplate.Height * dataGridView_script.Rows.Count + dataGridView_script.ColumnHeadersHeight + 24;
            this.Height = dataGridView_script.Height + 127;
        }

        #region Functions Collection
        private void Write_Click(KeyEventArgs e)
        {
            Point point = Cursor.Position;
            
            string[] axis = new string[] { (dt.Rows.Count+1).ToString(), "Click", point.X.ToString(), point.Y.ToString() };

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

            dataGridView_script.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
            dataGridView_script.Width = dataGridView_script.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 45;
            this.Width = dataGridView_script.Columns.GetColumnsWidth(DataGridViewElementStates.Visible)  + 80;

        }
    }


}
