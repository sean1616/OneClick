namespace MouseClick_x01
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.curx = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cury = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.txt5 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 90);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "GO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(12, 66);
            this.txt1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(36, 22);
            this.txt1.TabIndex = 2;
            this.txt1.Text = "12";
            this.txt1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt1_KeyPress);
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(55, 66);
            this.txt2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(24, 22);
            this.txt2.TabIndex = 5;
            this.txt2.Text = "40";
            this.txt2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt2_KeyPress);
            // 
            // curx
            // 
            this.curx.AutoSize = true;
            this.curx.Location = new System.Drawing.Point(106, 42);
            this.curx.Name = "curx";
            this.curx.Size = new System.Drawing.Size(9, 12);
            this.curx.TabIndex = 8;
            this.curx.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = ",";
            // 
            // cury
            // 
            this.cury.AutoSize = true;
            this.cury.Location = new System.Drawing.Point(178, 42);
            this.cury.Name = "cury";
            this.cury.Size = new System.Drawing.Size(9, 12);
            this.cury.TabIndex = 10;
            this.cury.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "Mouse Position";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(86, 66);
            this.txt3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(26, 22);
            this.txt3.TabIndex = 21;
            this.txt3.Text = "Y+";
            this.txt3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt3_KeyPress);
            // 
            // txt4
            // 
            this.txt4.Location = new System.Drawing.Point(119, 66);
            this.txt4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(44, 22);
            this.txt4.TabIndex = 22;
            this.txt4.Text = "1530.33";
            this.txt4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt4_KeyPress);
            // 
            // txt5
            // 
            this.txt5.Location = new System.Drawing.Point(172, 66);
            this.txt5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt5.Name = "txt5";
            this.txt5.Size = new System.Drawing.Size(24, 22);
            this.txt5.TabIndex = 23;
            this.txt5.Text = "0";
            this.txt5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt5_KeyPress);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 10);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 30);
            this.button2.TabIndex = 24;
            this.button2.Text = "Set";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(110, 10);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 30);
            this.button3.TabIndex = 25;
            this.button3.Text = "Set";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(215, 10);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 30);
            this.button4.TabIndex = 26;
            this.button4.Text = "Set script";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(215, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(66, 20);
            this.comboBox1.TabIndex = 28;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(150, 90);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 40);
            this.button5.TabIndex = 29;
            this.button5.Text = "Script";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 139);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt5);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cury);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.curx);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Mouse Click";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Label curx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cury;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.TextBox txt5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button5;
    }
}

