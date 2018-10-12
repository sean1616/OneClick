using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClick_x01
{
    public partial class Script_Form : Form
    {
        string str;

        public Script_Form(string str)
        {
            InitializeComponent();

            this.str = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            script_list.Items.Add(str);
        }
    }
}
