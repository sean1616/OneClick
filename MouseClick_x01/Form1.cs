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
        System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();

        private Hocy_Hook hook_Main = new Hocy_Hook();

        bool btn1_step_on = false;
        public static SetupIniIP ini = new SetupIniIP();
                
        //string script_ini_filename = "MouseClick_script.ini";

        public List<string> script_filename = new List<string>();
        public List<string> script_section = new List<string>();
        string csv_path;
        Script_Form form;

        public Form1()
        {
            InitializeComponent();

            this.TopMost = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            

            script_section.Add("script_sec1");
            script_filename.Add("MouseClick_script_1.ini");
                        
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

            timer1.Interval = 200;
            timer1.Tick += Timer1_Tick;
            timer1.Enabled = true;

            timer2.Interval = 100;
            timer2.Tick += Timer2_Tick;

            //this.hook_Main.OnMouseActivity += new MouseEventHandler(hook_MainMouseMove);
            this.hook_Main.OnKeyDown += new KeyEventHandler(hook_MainKeyDown);
            //this.hook_Main.OnKeyPress += new KeyPressEventHandler(hook_MainKeyPress);
            //this.hook_Main.OnKeyUp += new KeyEventHandler(hook_MainKeyUp);

            hook_Main.InstallHook("1");

            //Search all csv file and set into combobox
            comboBox1.Items.Clear();
            for (int i = 1; i <= 30; i++)
            {
                csv_path = Application.StartupPath + @"\" + "Script_" + i.ToString() + ".csv";

                if (File.Exists(csv_path))
                {
                    comboBox1.Items.Add("Script_" + i.ToString());
                }
            }
            //Initial combobox's selected item
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
                selected_csv = comboBox1.SelectedItem.ToString();
            }

        }
                
        private void LogWrite(KeyEventArgs e)
        {
            //MessageBox.Show("Get in");
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
            //Thread.Sleep(8300);

            //Action 10
            //Cursor.Position = new Point(885,470);
            //Mouse.LeftClick();
            //Thread.Sleep(500);
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
            curx.Text = Cursor.Position.X.ToString();
            cury.Text = Cursor.Position.Y.ToString();            
        }

        //int time = 0, min, sec;
        private void Timer2_Tick(object Sender, EventArgs e)
        {
            //time += 1;

            //min = time / 60;
            //sec = time % 60;           

            
        }

        string[] filenameBox;
        string filename;

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //hook stop
            this.hook_Main.UnInstallHook();
        }

        private void label3_Click(object sender, EventArgs e)
        {

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
        int UFA_dB = new int();
        private void button2_Click(object sender, EventArgs e)
        {
            check_textbox();

            UFA_dB = Convert.ToInt16(txt5.Text);

            #region  txt1.Length=2

            if (txt1.Text.Length == 2)
            {
                int i = 0;
                foreach (char No in txt1.Text)
                {
                    UFA_No[i] = No - '0';
                    if (UFA_No[i] % 2 == 1) //when UFA_N0 is odd
                    {
                        //upper list pull down
                        Cursor.Position = new Point(122, 182);
                        Mouse.LeftClick();
                        Thread.Sleep(400);
                        //MessageBox.Show(UFA_No[i].ToString());
                        if (UFA_dB == 0)
                        {
                            switch (UFA_No[i])
                            {
                                #region switch case 0 dB
                                case 1:
                                    //No1
                                    Cursor.Position = new Point(122, 214);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 2:
                                    //No2
                                    Cursor.Position = new Point(122, 309);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 3:
                                    //No1
                                    Cursor.Position = new Point(122, 335);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 4:
                                    //No4
                                    Cursor.Position = new Point(122, 360);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 5:
                                    //No5
                                    Cursor.Position = new Point(122, 382);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 6:
                                    //No1
                                    Cursor.Position = new Point(122, 404);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 7:
                                    //No1
                                    Cursor.Position = new Point(122, 431);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 8:
                                    //No1
                                    Cursor.Position = new Point(122, 452);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 9:
                                    //No1
                                    Cursor.Position = new Point(122, 477);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 10:
                                    //No1
                                    Cursor.Position = new Point(122, 238);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 11:
                                    //No1
                                    Cursor.Position = new Point(122, 263);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 12:
                                    //No1
                                    Cursor.Position = new Point(122, 284);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                    #endregion
                            }
                        }
                        else if (UFA_dB == 20)
                        {
                            switch (UFA_No[i])
                            {
                                #region switch case 20dB
                                case 1:
                                    //No1
                                    Cursor.Position = new Point(122, 200);
                                    Mouse.LeftClick();
                                    Thread.Sleep(400);
                                    break;

                                case 2:
                                    //No2
                                    Cursor.Position = new Point(122, 297);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 3:
                                    //No1
                                    Cursor.Position = new Point(122, 320);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 4:
                                    //No4
                                    Cursor.Position = new Point(122, 346);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 5:
                                    //No5
                                    Cursor.Position = new Point(122, 370);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 6:
                                    //No1
                                    Cursor.Position = new Point(122, 394);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 7:
                                    //No1
                                    Cursor.Position = new Point(122, 418);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 8:
                                    //No1
                                    Cursor.Position = new Point(122, 444);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 9:
                                    //No1
                                    Cursor.Position = new Point(122, 467);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 10:
                                    //No1
                                    Cursor.Position = new Point(122, 225);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 11:
                                    //No1
                                    Cursor.Position = new Point(122, 249);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 12:
                                    //No1
                                    Cursor.Position = new Point(122, 277);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;
                                    #endregion
                            }
                        }
                    }
                    else
                    {
                        //lower list pull down
                        Cursor.Position = new Point(122, 212);
                        Mouse.LeftClick();

                        if (UFA_dB == 0)
                        {
                            switch (UFA_No[i])
                            {
                                #region switch case 0dB
                                case 1:
                                    //No1
                                    Cursor.Position = new Point(122, 244);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 2:
                                    //No212_40G_Y+_1530.33_0dB                                   
                                    Cursor.Position = new Point(122, 339);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 3:
                                    //No1
                                    Cursor.Position = new Point(122, 365);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 4:
                                    //No4
                                    Cursor.Position = new Point(122, 390);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 5:
                                    //No5
                                    Cursor.Position = new Point(122, 412);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 6:
                                    //No1
                                    Cursor.Position = new Point(122, 434);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 7:
                                    //No1
                                    Cursor.Position = new Point(122, 461);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 8:
                                    //No1
                                    Cursor.Position = new Point(122, 482);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 9:
                                    //No1
                                    Cursor.Position = new Point(122, 507);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 10:
                                    //No1
                                    Cursor.Position = new Point(122, 268);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 11:
                                    //No1
                                    Cursor.Position = new Point(122, 293);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 12:
                                    //No1
                                    Cursor.Position = new Point(122, 314);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                    #endregion
                            }
                        }
                        else if (UFA_dB == 20)
                        {
                            switch (UFA_No[i])
                            {
                                #region switch case 20dB
                                case 1:
                                    //No1
                                    Cursor.Position = new Point(122, 230);
                                    Mouse.LeftClick();
                                    Thread.Sleep(400);
                                    break;

                                case 2:
                                    //No2
                                    Cursor.Position = new Point(122, 327);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 3:
                                    //No1
                                    Cursor.Position = new Point(122, 350);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 4:
                                    //No4
                                    Cursor.Position = new Point(122, 376);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 5:
                                    //No5
                                    Cursor.Position = new Point(122, 400);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 6:
                                    //No1
                                    Cursor.Position = new Point(122, 424);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 7:
                                    //No1
                                    Cursor.Position = new Point(122, 448);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 8:
                                    //No1
                                    Cursor.Position = new Point(122, 474);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 9:
                                    //No1
                                    Cursor.Position = new Point(122, 497);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 10:
                                    //No1
                                    Cursor.Position = new Point(122, 255);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 11:
                                    //No1
                                    Cursor.Position = new Point(122, 279);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;

                                case 12:
                                    //No1
                                    Cursor.Position = new Point(122, 309);
                                    Mouse.LeftClick();
                                    Thread.Sleep(800);
                                    break;
                                    #endregion
                            }
                        }
                    }
                    
                    i++;
                }
            }

            #endregion

            #region txt1.text=910
            if (txt1.Text=="910" && txt5.Text=="0")
            {
                Cursor.Position = new Point(138, 186);
                Mouse.LeftClick();
                Thread.Sleep(800);

                Cursor.Position = new Point(138, 478);
                Mouse.LeftClick();
                Thread.Sleep(800);

                Cursor.Position = new Point(138, 210);
                Mouse.LeftClick();
                Thread.Sleep(800);

                Cursor.Position = new Point(138, 264);
                Mouse.LeftClick();
                Thread.Sleep(800);
            }
            else if (txt1.Text=="910" && txt5.Text == "20")
            {
                Cursor.Position = new Point(138, 186);
                Mouse.LeftClick();
                Thread.Sleep(800);

                Cursor.Position = new Point(138, 468);
                Mouse.LeftClick();
                Thread.Sleep(800);

                Cursor.Position = new Point(138, 210);
                Mouse.LeftClick();
                Thread.Sleep(800);

                Cursor.Position = new Point(138, 254);
                Mouse.LeftClick();
                Thread.Sleep(800);
            }
            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            check_textbox();

            Cursor.Position = new Point(182, 114);
            Mouse.LeftClick();
            Thread.Sleep(800);

            Cursor.Position = new Point(300, 114);
            Mouse.LeftClick();
            Thread.Sleep(800);

            switch (txt4.Text)
            {
                case "1530.33":
                    Cursor.Position = new Point(300, 131);
                    Mouse.LeftClick();
                    Thread.Sleep(800);
                    break;

                case "1550.12":
                    Cursor.Position = new Point(300, 165);
                    Mouse.LeftClick();
                    Thread.Sleep(800);
                    break;

                case "1569.36":
                    Cursor.Position = new Point(300, 192);
                    Mouse.LeftClick();
                    Thread.Sleep(800);
                    break;                
            }

            Cursor.Position = new Point(362, 159);
            Mouse.LeftClick();
            Thread.Sleep(800);

            switch (txt4.Text)
            {
                case "1530.33":
                    Cursor.Position = new Point(350, 178);
                    Mouse.LeftClick();
                    Thread.Sleep(800);
                    break;

                case "1550.12":
                    Cursor.Position = new Point(350, 210);
                    Mouse.LeftClick();
                    Thread.Sleep(800);
                    break;

                case "1569.36":
                    Cursor.Position = new Point(350, 235);
                    Mouse.LeftClick();
                    Thread.Sleep(800);
                    break;
            }
        }
        public string str = "asdf";
        private void button4_Click(object sender, EventArgs e)
        {
            hook_Main.UnInstallHook();  //卸戴main form的掛鉤
            
            form = new Script_Form(selected_csv); //Creat a script form.
            
            form.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if(checkBox1.Checked && txt1x.Text != "" && txt1y.Text != "")
            //{
            //    Cursor.Position = new Point(Convert.ToInt32(txt1x.Text), Convert.ToInt16(txt1y.Text));
            //    Mouse.LeftClick();
            //}                  
            
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        ListViewItem lv = new ListViewItem();
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            for (int i = 1; i <= 30; i++)
            {
                csv_path = Application.StartupPath + @"\" + "Script_" + i.ToString() + ".csv";

                if (File.Exists(csv_path))
                {                   
                    comboBox1.Items.Add("Script_" + i.ToString());
                }                
            }
                
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        internal string selected_csv;
        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            selected_csv = comboBox1.SelectedItem.ToString();
            //MessageBox.Show(selected_csv);
        }

        public string Selected_csv()
        {
            return selected_csv;
        }
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
