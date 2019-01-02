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
    public partial class Form1 : Form
    {
        Thread sample;

        System.Windows.Forms.Timer timer1, timer2;
        System.Threading.Timer timer3;
        TimerCallback callback;

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
            this.MinimizeBox = false;

            AC = new Actions_Collection();

            script_section.Add("script_sec1");
            script_filename.Add("MouseClick_script_1.ini");
                        
            timer1 = new System.Windows.Forms.Timer();
            timer2 = new System.Windows.Forms.Timer();
                                                           
            //timer1.Interval = 200;
            //timer1.Tick += Timer1_Tick;
            //timer1.Enabled = true;

            timer2.Interval = 200;
            timer2.Tick += Timer2_Tick;

            //this.hook_Main.OnMouseActivity += new MouseEventHandler(hook_MainMouseMove);
            this.hook_Main.OnKeyDown += new KeyEventHandler(hook_MainKeyDown);
            this.hook_Main.OnKeyUp += new KeyEventHandler(hook_MainKeyUp);
            //this.hook_Main.OnKeyPress += new KeyPressEventHandler(hook_MainKeyPress);
            //this.hook_Main.OnKeyUp += new KeyEventHandler(hook_MainKeyUp);

            hook_Main.InstallHook("1");
                        
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
            Update_datatable();
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

        private void hook_MainKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && btn1_step_on==true)
            {
                LogWrite(e);
                btn1_step_on = false;
            }
            else if (e.KeyCode == Keys.F2)
            {
                btn1_step_on = false;
                MessageBox.Show("1234");
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
                //MessageBox.Show("Keyin");
                toolStripStatusLabel1.Text = "Working";

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
                                AC.Action_Delay(X);
                                break;

                            case "Key":
                                AC.Action_Key(X, Y);
                                break;

                            case "WaitKey":
                                key = AC.Action_WaitKey(X, Y);
                                pause_No = int.Parse(dr[0].ToString());
                                toolStripStatusLabel1.Text = "Waiting";
                                return;
                        }

                    }
                }
                hook_Main.UnInstallHook();

                toolStripStatusLabel1.Text = "Complete";
            }


        }

        private void hook_MainKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.LControlKey)
            {
                Check_Close = false;
            }
        }

        private void hook_MainKeyPress(object sender, KeyPressEventArgs e)
        {
            if (btn1_step_on == false)
                return;
            //LogWrite(e);
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

                    progressBar1.PerformStep();
                }
            }
            while (checkBox1.Checked);

            
        }

        private void Timer2_Tick(object Sender, EventArgs e)
        {
            double tt = double.Parse(toolStripStatusLabel2.Text) + 0.2;
            //toolStripStatusLabel2.Text = (tt).ToString();

            if (tt >= time_spent)
                timer2.Enabled = false;  //關閉ProgressBar的更新timer
        }
                
        private void Timer3_Tick(object state)
        {            
            tt = double.Parse(toolStripStatusLabel2.Text) + 0.2;

            this.BeginInvoke(new setLable2(setLabel2));

            if (tt >= time_spent)
            {
                //timer3.Change(Timeout.Infinite, Timeout.Infinite); //關閉ProgressBar的更新timer
                timer3.Dispose();
                
            }
                
        }
        delegate void setLable2();
        private void setLabel2()
        {
            progressBar1.PerformStep();
            if (tt > time_spent)
            {
                toolStripStatusLabel2.Text = time_spent.ToString();
                progressBar1.Value = progressBar1.Maximum;
            }                          
            else
                toolStripStatusLabel2.Text = (tt).ToString();
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

        private void check_textbox()
        {
            filenameBox = new string[] { txt1.Text, txt2.Text, txt3.Text, txt4.Text, txt5.Text };

            foreach (string txt in filenameBox)
            {
                if (string.IsNullOrEmpty(txt))
                {
                    MessageBox.Show("Textbox empty");
                    return;
                }
            }
        }

        int[] UFA_No = new int[2];                    

        private void button1_Click(object sender, EventArgs e)
        {                             
            if (btn1_step_on == true)
            {
                MessageBox.Show("Press F1(F2) to continue(cancel).");
                return;
            }    

            filenameBox = new string[] { txt1.Text, txt2.Text, txt3.Text, txt4.Text, txt5.Text };

            foreach (string txt in filenameBox)
            {
                if (string.IsNullOrEmpty(txt))
                {
                    MessageBox.Show("Textbox empty");
                    return;
                }
                   
            }

            //hook start
            hook_Main.InstallHook("1");

            //Action 0
            Cursor.Position = new Point(705, 52);
            Mouse.LeftClick();
            Thread.Sleep(5000);

            //Action 1
            Cursor.Position = new Point(1508, 50);
            Mouse.LeftClick();
            Thread.Sleep(500);

            //Action 2
            Cursor.Position = new Point(1404, 220);
            Mouse.LeftClick();
            Thread.Sleep(500);

            //Action 3
            Cursor.Position = new Point(1000, 240);
            Mouse.LeftClick();
            Thread.Sleep(500);

            //Action 4
            Cursor.Position = new Point(746, 518);
            Mouse.LeftClick();
            Thread.Sleep(500);

            //Action 5
            Cursor.Position = new Point(660, 560);
            Mouse.LeftClick();
            Thread.Sleep(500);

            //Action 6
            filename = txt1.Text + "_" + txt2.Text + "G_" + txt3.Text + "_" + txt4.Text + "_" + txt5.Text + "dB";
            Clipboard.SetText(filename);
            SendKeys.Send("^{V}");
                            
            btn1_step_on = true;

            //timer2.Enabled = true;           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hook_Main.UnInstallHook();  //卸戴main form的掛鉤

            form = new Script_Form(selected_csv); //Creat a script form.
            form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            form.Location = new System.Drawing.Point(this.Right, this.Top);
            form.Show();

        }

        //創建一個委託來實現非創建控件的線程更新控件
        delegate void AsynUpdateUI(int step);

        private void button5_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = 0.ToString();

            MainFunction mainFunction = new MainFunction(dt, checkBox_checked, AC);
            mainFunction.TaskCallBack += Accomplish;//綁定完成任務要調用的委託

            Thread thread = new Thread(new ParameterizedThreadStart(mainFunction._MainFunction));
            thread.IsBackground = true;
            thread.Start();

            //sample = new Thread(_MainFunction);
            //sample.Start();
;
            callback = new TimerCallback(Timer3_Tick);    //Update progress bar
            timer3 = new System.Threading.Timer(callback, null, 0, 200);
            
            //timer3.Change(0, 200);

            //Update_datatable();

            //hook_Main.InstallHook("1"); //開啟掛鉤

            //progressBar1.Value = 0;
            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = dt.Rows.Count;
            //progressBar1.Step = 1;            

            hook_Main.UnInstallHook();
        }

        //完成任務時需要調用
        private void Accomplish()
        {
            if (InvokeRequired)
            {
                this.Invoke(new AsynUpdateUI(delegate (int s)
                {
                    this.progressBar1.Value = 0;
                    //this.progressBar1.Text = this.progressBar1.Value.ToString() + "/" + this.progressBar1.Maximum.ToString();
                    toolStripStatusLabel2.Text = 0.ToString();
                }), 0);
                
            }
            else
            {
                
            }
            
        }

        private void _MainFunction()
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
                            hook_Main.InstallHook("1");
                            //toolStripStatusLabel1.Text = "Waiting";
                            return;
                    }
                    
                    //progressBar1.PerformStep();
                }

            }
            while (checkBox1.Checked);
        }

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

            Update_datatable();

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
            toolStripStatusLabel1.Text = time_spent.ToString();
            progressBar1.Maximum = Convert.ToInt32(time_spent * 5);
        }

        private void Update_datatable()
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
            checkBox_checked = checkBox1.Checked;
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
