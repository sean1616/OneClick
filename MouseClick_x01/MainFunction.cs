using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MouseClick_x01
{
    public class MainFunction
    {
        DataTable dt = new DataTable();
        string sw_string, X, Y;
        Actions_Collection AC;
        Keys key;
        int pause_No;
        Hocy_Hook hook_Main;
        bool checkBox_checked;

        public delegate void UpdateUI(int step);//聲明一個更新主線程的委託
        public UpdateUI UpdateUIDelegate;

        public delegate void AccomplishTask();//聲明一個在完成任務時通知主線程的委託
        public AccomplishTask TaskCallBack;

        public MainFunction(DataTable dt, bool checkBox_checked, Actions_Collection AC)
        {
            this.dt = dt;
            //this.hook_Main = hook_Main;
            this.checkBox_checked = checkBox_checked;
            this.AC = AC;
        }

        public void _MainFunction(object lineCount)
        {
            do
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sw_string = dr[1].ToString();
                    X = dr[2].ToString();
                    Y = dr[3].ToString();

                    switch (sw_string)
                    {
                        case "Click":
                            Point p = new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
                            AC.Action_Click(p);
                            break;

                        case "Delay":
                            AC.Action_Delay(X);
                            break;

                        case "Key":
                            AC.Action_Key(X, Y);
                            break;

                        case "WaitKey":
                            key = AC.Action_WaitKey(X, Y);
                            pause_No = int.Parse(dr[0].ToString());
                            //hook_Main.InstallHook("1");
                            //toolStripStatusLabel1.Text = "Waiting";
                            return;
                    }

                    //progressBar1.PerformStep();

                    //寫入一條數據，調用更新主線程ui狀態的委託
                    //UpdateUIDelegate(1);                    
                }

                //任務完成時通知主線程作出相應的處理
                TaskCallBack();
            }
            while (checkBox_checked);
        }

         
    }
}
