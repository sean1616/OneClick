using System;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace OneClick
{
    public class Actions_Collection
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        bool timer_check = false;

        public CancellationTokenSource tokenSource;

        public Actions_Collection()
        {
            tokenSource = new CancellationTokenSource();
        }

        private bool Set_Timer(int interval)
        {
            timer.Interval = interval;

            return timer_check = false;
        }

        #region Actions Collection
        public void Action_Click(Point p)
        {
            Point point = Cursor.Position;

            Cursor.Position = new Point(p.X, p.Y);
            Mouse.LeftClick();

            Cursor.Position = point; //Back to origin position

            Thread.Sleep(50);
        }

        public void Action_RightClick(Point p)
        {
            Point point = Cursor.Position;

            Cursor.Position = new Point(p.X, p.Y);
            Mouse.RightClick();

            Cursor.Position = point; //Back to origin position

            Thread.Sleep(50);
        }
        
        public async Task<bool> Action_Delay(string t, string unit)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0);
            int delay_time;

            if (int.TryParse(t, out delay_time))
            {
                switch (unit)
                {
                    case "ms":
                        ts = new TimeSpan(0, 0, 0, delay_time / 1000, delay_time % 1000);
                        break;

                    case "s":
                        ts = new TimeSpan(0, 0, delay_time);
                        break;

                    case "m":
                        ts = new TimeSpan(0, delay_time, 0);
                        break;

                    case "hr":
                        ts = new TimeSpan(delay_time, 0, 0);
                        break;
                }
                await Task.Delay(ts, tokenSource.Token);

                return true;
            }
            else return false;
        }

        public void Action_KeyString(string keystring)
        {
            try
            {
                SendKeys.SendWait(keystring);
            }
            catch
            {
                MessageBox.Show("Somethin wrong when send the key");
            }
        }
                
        public void Action_Key(string key_X, string key_Y)
        {
            StringBuilder key = new StringBuilder();

            switch (key_X)
            {
                case "Ctrl":
                    key_X = "^";
                    break;
                case "Shift":
                    key_X = "+";
                    break;
                case "Alt":
                    key_X = "%";
                    break;
                case "Backspace":
                    key_X = "{BS}";
                    break;
                case "Delete":
                    key_X = "{DEL}";
                    break;
                case "DEL":
                    key_X = "{DEL}";
                    break;
                case "Enter":
                    key_X = "{ENTER}";
                    break;                
                case "ESC":
                    key_X = "{ESC}";
                    break;
                case "Home":
                    key_X = "{HOME}";
                    break;
                case "Left":
                    key_X = "{LEFT}";
                    break;
                case "Right":
                    key_X = "RIGHT";
                    break;
                case "Up":
                    key_X = "{UP}";
                    break;
                case "Down":
                    key_X = "{DOWN}";
                    break;
                case "TAB":
                    key_X = "{TAB}";
                    break;
            }

            key.Append(key_X);
            key.Append(key_Y);
            string keyString = key.ToString();

            if (keyString.Contains("+") || keyString.Contains("-"))
            {
                char[] list_char = keyString.ToCharArray();

                keyString = "";
                foreach (char c in list_char)
                {
                    if (c == '+' || c == '-')
                    {
                        keyString += "{";
                        keyString += c;
                        keyString += "}";
                    }
                    else
                    {
                        keyString += c;
                    }
                }
            }
            try
            {
                SendKeys.SendWait(keyString);
            }
            catch
            {
                MessageBox.Show("Somethin wrong when send the key");
            }

        }

        public Keys Action_WaitKey(string key_X, string key_Y)
        {
            key_X = key_X.ToUpper();
            Keys k;
            if (Enum.TryParse<Keys>(key_X, out k))
            {

            }
            return k;
        }
        #endregion
    }
}
