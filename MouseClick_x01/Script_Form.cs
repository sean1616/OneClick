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
        List<string> script_filename;
        List<string> script_section;

        public Script_Form(SetupIniIP setupIni, List<string> script_filename, List<string> script_section)
        {
            InitializeComponent();

            this.TopMost = true;
            this.ini = setupIni;
            //this.script_filename = script_filename;
            this.script_section = script_section;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            script_filename = new List<string>();
            for (int i = 1; i <= 30; i++)
            {
                script_filename.Add("MouseClick_script_" + i.ToString() + ".ini");
                string ini_path = Application.StartupPath + @"\" + script_filename[i-1];
                if (!File.Exists(ini_path))
                {
                    ini.IniWriteValue(script_section[0], "btn_opa", "0", script_filename[i-1]); //創建ini file並寫入基本設定
                    return;
                }                    
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            script_list.Items.Add("HIHI");
        }
    }

    
}
