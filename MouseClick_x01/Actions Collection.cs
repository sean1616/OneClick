using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace MouseClick_x01
{
    public class Actions_Collection
    {
        #region Actions Collection
        public void Action_Click(Point p)
        {
            Point point = Cursor.Position;

            Cursor.Position = new Point(p.X, p.Y);
            Mouse.LeftClick();

            Cursor.Position = point; //Back to origin position

            Thread.Sleep(100);
        }

        public void Action_Delay(string t)
        {
            int delay_time;
            if (int.TryParse(t, out delay_time))
            {
                Thread.Sleep(delay_time);
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

            try
            {
                SendKeys.SendWait(key.ToString());
            }
            catch
            {
                MessageBox.Show("Somethin wrong when send the key");
            }
        }
        #endregion
    }
}
