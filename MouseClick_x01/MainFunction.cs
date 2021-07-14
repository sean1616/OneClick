using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OneClick
{
    public class MainFunction
    {
        DataTable dt = new DataTable();
        string sw_string, X, Y;
        public Actions_Collection AC = new Actions_Collection();
        Keys key;
        int pause_No;
        Hocy_Hook hook_Main;
        bool checkBox_checked;

        public delegate void UpdateUI(int step);//聲明一個更新主線程的委託
        public UpdateUI UpdateUIDelegate;

        public delegate void AccomplishTask();//聲明一個在完成任務時通知主線程的委託
        public AccomplishTask TaskCallBack;

        public MainFunction(DataTable dt, bool checkBox_checked)
        {
            this.dt = dt;
            //this.hook_Main = hook_Main;
            this.checkBox_checked = checkBox_checked;
            //this.AC = AC;

            hook_Main = new Hocy_Hook();
            this.hook_Main.OnKeyDown += new KeyEventHandler(hook_MainKeyDown);
        }

        public async void _MainFunction()
        {
            try
            {
                do
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        sw_string = dr[1].ToString();
                        X = dr[2].ToString();
                        Y = dr[3].ToString();
                        Point p;

                        switch (sw_string)
                        {
                            case "Click":
                                p = new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
                                AC.Action_Click(p);
                                break;

                            case "RClick":
                                p = new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
                                AC.Action_RightClick(p);
                                break;

                            case "Delay":
                                AC.tokenSource = new System.Threading.CancellationTokenSource();
                                await AC.Action_Delay(X, Y);
                                break;

                            case "Key":
                                AC.Action_Key(X, Y);
                                break;

                            case "WaitKey":
                                key = AC.Action_WaitKey(X, Y);
                                pause_No = int.Parse(dr[0].ToString());

                                return;
                        }
                    }

                    //任務完成時通知主線程作出相應的處理
                    TaskCallBack();
                }
                while (Form1.chechBox_Repeat);
            }
            catch
            {

            }
        }

        public double TimeSpan_Calculate(DataTable dt)
        {
            int dataLines = dt.Rows.Count;
            double timeSpan = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sw_string = dr[1].ToString();
                X = dr[2].ToString();
                Y = dr[3].ToString();

                switch (sw_string)
                {
                    case "Click":
                        timeSpan += 10;  //ms
                        break;

                    case "RClick":
                        timeSpan += 10;  //ms
                        break;

                    case "Delay":
                        timeSpan += double.Parse(X);  //ms
                        break;

                    case "Key":
                        timeSpan += 10;  //ms
                        break;

                    case "WaitKey":
                        
                        break;
                }
            }

            return timeSpan;
        }

        string csv_path = "";
        public DataTable LoadScripTable(string selected_csv)
        {
            csv_path = Application.StartupPath + @"\" + selected_csv + ".csv";

            dt = new DataTable();
            try
            {
                string[] lines = File.ReadAllLines(csv_path);

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
                        }
                    }
                    catch
                    {
                        MessageBox.Show("File format is wrong.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("File is opened in another program.");
            }

            return dt;
        }

        DataGridViewRow pause_dg = new DataGridViewRow();
        private void hook_MainKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && checkBox_checked)
            {
                checkBox_checked = false;
            }
        }
    }
}
