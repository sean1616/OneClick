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

        int index_list;
        private Hocy_Hook hook_Main = new Hocy_Hook();
        string ini_path;

        bool capture_checkbox_status = false;

        public Script_Form(SetupIniIP setupIni, List<string> script_filename, List<string> script_section)
        {
            InitializeComponent();
            
            this.TopMost = true;
            this.ini = setupIni;
            //this.script_filename = script_filename;
            this.script_section = script_section;

            this.hook_Main.OnKeyDown += new KeyEventHandler(hook_MainKeyDown);
        }
        DateTime dt = new DateTime();
        private void button1_Click(object sender, EventArgs e)
        {
            script_filename = new List<string>();
            for (int i = 1; i <= 30; i++)
            {
                script_filename.Add("MouseClick_script_" + i.ToString() + ".ini"); //將新增的ini檔名寫入list
                ini_path = Application.StartupPath + @"\" + script_filename[i-1];
                if (!File.Exists(ini_path))
                {
                    ini.IniWriteValue(script_section[0], "Built up time ", DateTime.Now.ToString(), script_filename[i-1]); //創建ini file並寫入基本設定
                    script_name_statusbar.Text = script_filename[i-1];
                    index_list = i - 1;
                    return;
                }                    
            }          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            script_list.Items.Add("HIHI");
        }

        private void script_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Script_Form_Load(object sender, EventArgs e)
        {
            script_list.GridLines = true;//表格是否顯示網格
            script_list.FullRowSelect = false;//是否選中整行
                        
            script_list.View = View.Details;//設置顯示方式
            script_list.Scrollable = true;//是否自動顯示滾動條
            script_list.MultiSelect = false;//是否可以選擇多行

            //添加表頭（列）
            script_list.Columns.Add("No.", "No.");
            script_list.Columns.Add("Event", "Event");
            script_list.Columns.Add("X", 60, HorizontalAlignment.Center);
            script_list.Columns.Add("Y", 60, HorizontalAlignment.Center);

            //-1為根據內容設置寬度，-2為根據標題設置寬度
            script_list.Columns["No."].Width = -2;
            script_list.Columns["Event"].Width = -2;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (capture_checkbox_status == false)
            //    return;

            ////添加表格内容
            //for (int i = 1; i <= 3; i++)
            //{
            //    ListViewItem item = new ListViewItem();
            //    item.SubItems.Clear();

            //    item.SubItems[0].Text= i.ToString();
            //    item.SubItems.Add("Click");
            //    item.SubItems.Add((i + 7).ToString());
            //    item.SubItems.Add((i * i).ToString());
            //    script_list.Items.Add(item);
            //}
            
                
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
            else if (e.KeyCode == Keys.F2)
            {
                
            }
        }

        private void Write_Click(KeyEventArgs e)
        {
            Point point = Cursor.Position;

            //添加表格内容
            int i = 1;

            ListViewItem item = new ListViewItem();
            item.SubItems.Clear();

            item.SubItems[0].Text = i.ToString();
            item.SubItems.Add("Click");
            item.SubItems.Add((point.X).ToString());
            item.SubItems.Add((point.Y).ToString());
            script_list.Items.Add(item);
        }
        int i_count = 0;
        private void button3_Click(object sender, EventArgs e)
        {         
            if (File.Exists(ini_path))
            {
                foreach (ListViewItem item in script_list.Items)
                {
                    i_count++;
                    var objA = item.SubItems[1].Text;  //Action
                    var objX = item.SubItems[2].Text;  //X
                    var objY = item.SubItems[3].Text;  //Y

                    ini.IniWriteValue(objA + "_" + i_count.ToString(), "X", objX, script_filename[index_list]); //寫入腳本
                    ini.IniWriteValue(objA + "_" + i_count.ToString(), "Y", objY, script_filename[index_list]); //寫入腳本
                }        
            }
            else
                MessageBox.Show("File doesn't exist");
        }
    }

    
}
