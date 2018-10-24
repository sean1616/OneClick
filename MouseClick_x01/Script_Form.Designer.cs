namespace MouseClick_x01
{
    partial class Script_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.script_name_statusbar = new System.Windows.Forms.ToolStripStatusLabel();
            this.Click_Check = new System.Windows.Forms.CheckBox();
            this.dataGridView_script = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_script)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 18);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Modify";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(191, 18);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 34);
            this.button3.TabIndex = 3;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(276, 18);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(79, 34);
            this.button4.TabIndex = 4;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.script_name_statusbar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 770);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(406, 28);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(66, 23);
            this.toolStripStatusLabel1.Text = "script: ";
            // 
            // script_name_statusbar
            // 
            this.script_name_statusbar.Name = "script_name_statusbar";
            this.script_name_statusbar.Size = new System.Drawing.Size(0, 23);
            // 
            // Click_Check
            // 
            this.Click_Check.AutoSize = true;
            this.Click_Check.Location = new System.Drawing.Point(18, 62);
            this.Click_Check.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Click_Check.Name = "Click_Check";
            this.Click_Check.Size = new System.Drawing.Size(88, 22);
            this.Click_Check.TabIndex = 7;
            this.Click_Check.Text = "Capture";
            this.Click_Check.UseVisualStyleBackColor = true;
            this.Click_Check.CheckedChanged += new System.EventHandler(this.Click_Check_CheckedChanged);
            // 
            // dataGridView_script
            // 
            this.dataGridView_script.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_script.Location = new System.Drawing.Point(18, 94);
            this.dataGridView_script.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_script.Name = "dataGridView_script";
            this.dataGridView_script.RowTemplate.Height = 24;
            this.dataGridView_script.Size = new System.Drawing.Size(375, 666);
            this.dataGridView_script.TabIndex = 8;
            this.dataGridView_script.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_script_CellContentClick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(363, 18);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 34);
            this.button5.TabIndex = 9;
            this.button5.Text = "Go";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Script_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 798);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridView_script);
            this.Controls.Add(this.Click_Check);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Script_Form";
            this.Text = "Script_Form";
            this.Load += new System.EventHandler(this.Script_Form_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_script)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel script_name_statusbar;
        private System.Windows.Forms.CheckBox Click_Check;
        private System.Windows.Forms.DataGridView dataGridView_script;
        private System.Windows.Forms.Button button5;
    }
}