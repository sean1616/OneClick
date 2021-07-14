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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        Thread sample;

        public static bool chechBox_Repeat = false;

        System.Windows.Forms.Timer timer1, timer2;
        System.Threading.Timer timer3;
        TimerCallback callback;

        System.Windows.Forms.Timer timer_timespan;

        Hocy_Hook hook_Main;
        Keys key;
        bool btn1_step_on = false;
        bool Check_Close = false;
        int pause_No;
        double time_spent, t, tt;
        public static SetupIniIP ini = new SetupIniIP();
        string sw_string, X, Y;

        DataTable dt;
        Script_Form form;
        Actions_Collection AC;
        
        public List<string> script_filename = new List<string>();
        public List<string> script_section = new List<string>();
        string csv_path, filename;
        string[] filenameBox;
        internal string selected_csv;        

        public Form1()
        {
            InitializeComponent();

            hook_Main = new Hocy_Hook();

            this.TopMost = true;
            this.MaximizeBox = false;
            //this.MinimizeBox = false;

            AC = new Actions_Collection();

            script_section.Add("script_sec1");
            script_filename.Add("MouseClick_script_1.ini");
                        
            timer1 = new System.Windows.Forms.Timer();
            timer_timespan = new System.Windows.Forms.Timer();

            timer_timespan.Interval = 1000;
            timer_timespan.Tick += Timer_timespan_Tick;

            //this.hook_Main.OnMouseActivity += new MouseEventHandler(hook_MainMouseMove);
            this.hook_Main.OnKeyDown += new KeyEventHandler(hook_MainKeyDown);
            this.hook_Main.OnKeyUp += new KeyEventHandler(hook_MainKeyUp);
            //this.hook_Main.OnKeyPress += new KeyPressEventHandler(hook_MainKeyPress);
            //this.hook_Main.OnKeyUp += new KeyEventHandler(hook_MainKeyUp);

            //hook_Main.InstallHook("1");
                        
            comboBox1.Items.Clear();
            string[] files = System.IO.Directory.GetFiles(Application.StartupPath, "*.csv");
            foreach(string file in files)
            {
                comboBox1.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
            
            //Initial combobox's selected item
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
                selected_csv = comboBox1.SelectedItem.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Update_datatable();

            callback = new TimerCallback(Timer_ProgressBar_Tick);    //Update progress bar
            timer3 = new System.Threading.Timer(callback, null, 0, 100);
        }

        private void LogWrite(KeyEventArgs e)
        {
            //Action 7
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1500);

            //Action 8
            Cursor.Position = new Point(794, 564);
            Mouse.LeftClick();
            Thread.Sleep(500);

            //Action 9
            Cursor.Position = new Point(930,644);
            Mouse.LeftClick();            
        }

        private async void hook_MainKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && btn1_step_on==true)
            {
                LogWrite(e);
                btn1_step_on = false;
            }
            else if (e.KeyCode == Keys.F2)
            {
                btn1_step_on = false;
            }
            else if (e.KeyCode == Keys.Escape)  //ESC終止repeat
            {
                checkBox1.Checked = false;

                if (Check_Close == true) //Crtl + ESC to shutdown app
                    this.Close();
            }
            else if (e.KeyData == Keys.LControlKey)  //Crtl + ESC to shutdown app
            {
                Check_Close = true;
            }
            else if (e.KeyCode == key)
            {
                //Label_Status.Text = "Working";

                foreach (DataRow dr in dt.Rows)
                {
                    if (int.Parse(dr[0].ToString()) <= pause_No)
                    {
                        //Do nothing
                    }                    
                    else
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
                                await AC.Action_Delay(X,Y);
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
                }
                hook_Main.UnInstallHook();
            }
        }

        private void hook_MainKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.LControlKey) { Check_Close = false; }
        }

        private void hook_MainKeyPress(object sender, KeyPressEventArgs e)
        {
            if (btn1_step_on == false) return;

            btn1_step_on = false;
        }

        private void Timer1_Tick(object Sender, EventArgs e)
        {
            do
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sw_string = dr[1].ToString();
                    X = dr[2].ToString();
                    Y = dr[3].ToString();

                    int delay_time;
                    if (sw_string == "Delay")
                        int.TryParse(X, out delay_time);
                    else
                        delay_time = 50;

                    timer1.Interval = delay_time;

                    switch (sw_string)
                    {
                        case "Click":
                            Point p = new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
                            AC.Action_Click(p);
                            break;

                        case "Key":
                            AC.Action_Key(X, Y);
                            break;
                    }
                    ProgressBar_Main.PerformStep();
                }
            }
            while (checkBox1.Checked);            
        }
                
                
        private void Timer_ProgressBar_Tick(object state)
        {                        
            this.BeginInvoke(new UpdateProgressBar(UpdateProgressBarValue));
        }
        delegate void UpdateProgressBar();
        private void UpdateProgressBarValue()
        {
            if (progressMax_TimeSpan > 100)
            {
                ProgressBar_Main.Step = 100 / (progressMax_TimeSpan / 100);
                ProgressBar_Main.PerformStep();
            }                    
        }                
                
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            hook_Main.UnInstallHook();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //hook stop
            this.hook_Main.UnInstallHook();

            if (sample != null)
            {
                if (sample.IsAlive)
                    sample.Abort();
            }
        }              

        int[] UFA_No = new int[2];    

        private void button4_Click(object sender, EventArgs e)
        {
            hook_Main.UnInstallHook();  //卸戴main form的掛鉤

            if (form == null || form.Text == "")
            {
                form = new Script_Form(this, selected_csv); //Creat a script form.
                form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                form.Location = new System.Drawing.Point(this.Right, this.Top);
                form.Show();
            }
            else if (CheckOpened(form.Text))
            {
                form.WindowState = FormWindowState.Normal;
                form.Show();
                form.Focus();
            }            
        }

        private bool CheckOpened(string frm_name)
        {
            FormCollection fc = Application.OpenForms;

            foreach(Form frm in fc)
            {
                if (frm.Text == frm_name) return true;
            }
            return false;
        }

        //創建一個委託來實現非創建控件的線程更新控件
        delegate void AsynUpdateUI(int step);

        Thread thread;
        int progressMax_TimeSpan = 0;
        MainFunction mainFunction;
        DateTime dtn;
        
        private void btn_Go_Click(object sender, EventArgs e)
        {
            if (btn_Go.Text.Equals("Go"))
            {
                btn_Go.Text = "Stop";

                label_timespan.Text = "0";
                dtn = DateTime.Now;

                timer_timespan.Start();

                ProgressBar_Main.Value = 0;

                mainFunction = new MainFunction(dt, checkBox_checked);

                mainFunction.AC.tokenSource = new CancellationTokenSource();

                dt = mainFunction.LoadScripTable(selected_csv);
                progressMax_TimeSpan = (int)mainFunction.TimeSpan_Calculate(dt);

                mainFunction.TaskCallBack += Accomplish;//綁定完成任務要調用的委託

                //mainFunction._MainFunction();

                thread = new Thread(mainFunction._MainFunction);  //執行腳本的執行緒
                thread.IsBackground = true;
                thread.Start();

                //hook_Main.UnInstallHook();

                //timer_timespan.Stop();
                //btn_Go.Text = "Go";
            }
            else
            {
                mainFunction.AC.tokenSource.Cancel();
                thread.Abort();
                btn_Go.Text = "Go";
                timer_timespan.Stop();
            }
        }

        private void Timer_timespan_Tick(object sender, EventArgs e)
        {
            if (label_timespan != null)
                label_timespan.Text = Math.Round((DateTime.Now - dtn).TotalSeconds, 1).ToString();
        }

        //完成任務時需要調用
        private void Accomplish()
        {
            if (InvokeRequired)
            {
                this.Invoke(new AsynUpdateUI(delegate (int s)
                {
                    timer_timespan.Stop();
                    btn_Go.Text = "Go";
                }), 0);
            }                    
        }

        //private async void _MainFunction()
        //{
        //    do
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            sw_string = dr[1].ToString();
        //            X = dr[2].ToString();
        //            Y = dr[3].ToString();

        //            switch (sw_string)
        //            {
        //                case "Click":
        //                    Point p = new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
        //                    AC.Action_Click(p);
        //                    break;

        //                case "Delay":
        //                    await AC.Action_Delay(X,Y);
        //                    break;

        //                case "Key":
        //                    AC.Action_Key(X, Y);
        //                    break;

        //                case "WaitKey":
        //                    key = AC.Action_WaitKey(X, Y);
        //                    pause_No = int.Parse(dr[0].ToString());
        //                    hook_Main.InstallHook("1");
        //                    return;
        //            }
        //        }

        //    }
        //    while (checkBox1.Checked);
        //}

        ListViewItem lv = new ListViewItem();

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            timer2.Enabled = true;  //更新ProgressBar的Timer On
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string[] files = System.IO.Directory.GetFiles(Application.StartupPath, "*.csv");
            foreach (string file in files)
            {
                comboBox1.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
        }                

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            selected_csv = comboBox1.SelectedItem.ToString();

            object obj = new object();
            Update_datatable(obj);

            time_spent = 0;

            foreach(DataRow dr in dt.Rows)
            {
                sw_string = dr[1].ToString();
                X = dr[2].ToString();

                switch (sw_string)
                {
                    case "Click":
                        time_spent += 0.1;
                        break;

                    case "Delay":
                        time_spent += double.Parse(X) / 1000;
                        break;

                    case "Key":
                        time_spent += 0.1;
                        break;                    
                }
            }
        }

        public void Update_datatable(object obj)
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
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("File is opened in another program.");
                return;
            }
        }

        bool checkBox_checked = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox_checked = checkBox1.Checked;
            chechBox_Repeat = checkBox1.Checked;
        }
               
        public string Selected_csv()
        {
            return selected_csv;
        }

        #region shock test condition textBox
        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }
        #endregion
    }    

    static public class Mouse
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern Int32 SendInput(Int32 cInputs, ref INPUT pInputs, Int32 cbSize);

        [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 28)]
        public struct INPUT
        {
            [FieldOffset(0)]
            public INPUTTYPE dwType;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(4)]
            public KEYBOARDINPUT ki;
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MOUSEINPUT
        {
            public Int32 dx;
            public Int32 dy;
            public Int32 mouseData;
            public MOUSEFLAG dwFlags;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct KEYBOARDINPUT
        {
            public Int16 wVk;
            public Int16 wScan;
            public KEYBOARDFLAG dwFlags;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct HARDWAREINPUT
        {
            public Int32 uMsg;
            public Int16 wParamL;
            public Int16 wParamH;
        }

        public enum INPUTTYPE : int
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }

        [Flags()]
        public enum MOUSEFLAG : int
        {
            MOVE = 0x1,
            LEFTDOWN = 0x2,
            LEFTUP = 0x4,
            RIGHTDOWN = 0x8,
            RIGHTUP = 0x10,
            MIDDLEDOWN = 0x20,
            MIDDLEUP = 0x40,
            XDOWN = 0x80,
            XUP = 0x100,
            VIRTUALDESK = 0x400,
            WHEEL = 0x800,
            ABSOLUTE = 0x8000
        }

        [Flags()]
        public enum KEYBOARDFLAG : int
        {
            EXTENDEDKEY = 1,
            KEYUP = 2,
            UNICODE = 4,
            SCANCODE = 8
        }

        static public void RightDown()
        {
            INPUT rightdown = new INPUT();

            rightdown.dwType = 0;
            rightdown.mi = new MOUSEINPUT();
            rightdown.mi.dwExtraInfo = IntPtr.Zero;
            rightdown.mi.dx = 0;
            rightdown.mi.dy = 0;
            rightdown.mi.time = 0;
            rightdown.mi.mouseData = 0;
            rightdown.mi.dwFlags = MOUSEFLAG.RIGHTDOWN;

            SendInput(1, ref rightdown, Marshal.SizeOf(typeof(INPUT)));
        }

        static public void RightUp()
        {
            INPUT rightup = new INPUT();

            rightup.dwType = 0;
            rightup.mi = new MOUSEINPUT();
            rightup.mi.dwExtraInfo = IntPtr.Zero;
            rightup.mi.dx = 0;
            rightup.mi.dy = 0;
            rightup.mi.time = 0;
            rightup.mi.mouseData = 0;
            rightup.mi.dwFlags = MOUSEFLAG.RIGHTUP;

            SendInput(1, ref rightup, Marshal.SizeOf(typeof(INPUT)));
        }

        static public void RightClick()
        {
            RightDown();
            Thread.Sleep(20);
            RightUp();
        }

        static public void LeftDown()
        {
            INPUT leftdown = new INPUT();

            leftdown.dwType = 0;
            leftdown.mi = new MOUSEINPUT();
            leftdown.mi.dwExtraInfo = IntPtr.Zero;
            leftdown.mi.dx = 0;
            leftdown.mi.dy = 0;
            leftdown.mi.time = 0;
            leftdown.mi.mouseData = 0;
            leftdown.mi.dwFlags = MOUSEFLAG.LEFTDOWN;

            SendInput(1, ref leftdown, Marshal.SizeOf(typeof(INPUT)));
        }

        static public void LeftUp()
        {
            INPUT leftup = new INPUT();

            leftup.dwType = 0;
            leftup.mi = new MOUSEINPUT();
            leftup.mi.dwExtraInfo = IntPtr.Zero;
            leftup.mi.dx = 0;
            leftup.mi.dy = 0;
            leftup.mi.time = 0;
            leftup.mi.mouseData = 0;
            leftup.mi.dwFlags = MOUSEFLAG.LEFTUP;

            SendInput(1, ref leftup, Marshal.SizeOf(typeof(INPUT)));
        }

        static public void LeftClick()
        {
            LeftDown();
            Thread.Sleep(20);
            LeftUp();
        }

        static public void LeftDoubleClick()
        {
            LeftClick();
            Thread.Sleep(50);
            LeftClick();
        }

        static public void DragTo(string sor_X, string sor_Y, string des_X, string des_Y)
        {
            MoveTo(sor_X, sor_Y);
            LeftDown();
            Thread.Sleep(200);
            MoveTo(des_X, des_Y);
            LeftUp();
        }

        static public void MoveTo(string tx, string ty)
        {
            int x, y;
            int.TryParse(tx, out x);
            int.TryParse(ty, out y);

            Cursor.Position = new Point(x, y);
        }
    }
}
