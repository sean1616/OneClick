namespace OneClick
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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btn_Go = new MetroFramework.Controls.MetroButton();
            this.comboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.checkBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.ProgressBar_Main = new MetroFramework.Controls.MetroProgressBar();
            this.label_1 = new System.Windows.Forms.Label();
            this.label_timespan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(21, 105);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(59, 23);
            this.metroButton1.TabIndex = 36;
            this.metroButton1.Text = "Setting";
            this.metroButton1.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_Go
            // 
            this.btn_Go.Location = new System.Drawing.Point(92, 105);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(168, 23);
            this.btn_Go.TabIndex = 37;
            this.btn_Go.Text = "Go";
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 23;
            this.comboBox1.Location = new System.Drawing.Point(92, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(168, 29);
            this.comboBox1.TabIndex = 38;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(23, 71);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 15);
            this.checkBox1.TabIndex = 39;
            this.checkBox1.Text = "Repeat";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ProgressBar_Main
            // 
            this.ProgressBar_Main.HideProgressText = false;
            this.ProgressBar_Main.Location = new System.Drawing.Point(-1, 172);
            this.ProgressBar_Main.Name = "ProgressBar_Main";
            this.ProgressBar_Main.Size = new System.Drawing.Size(280, 23);
            this.ProgressBar_Main.Step = 2;
            this.ProgressBar_Main.Style = MetroFramework.MetroColorStyle.Orange;
            this.ProgressBar_Main.TabIndex = 40;
            this.ProgressBar_Main.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroToolTip1.SetToolTip(this.ProgressBar_Main, "Scrip Progress");
            // 
            // label_1
            // 
            this.label_1.AutoSize = true;
            this.label_1.Location = new System.Drawing.Point(23, 145);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(50, 12);
            this.label_1.TabIndex = 41;
            this.label_1.Text = "Timespan";
            // 
            // label_timespan
            // 
            this.label_timespan.AutoSize = true;
            this.label_timespan.Location = new System.Drawing.Point(136, 145);
            this.label_timespan.Name = "label_timespan";
            this.label_timespan.Size = new System.Drawing.Size(11, 12);
            this.label_timespan.TabIndex = 42;
            this.label_timespan.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 12);
            this.label2.TabIndex = 43;
            this.label2.Text = "Seconds";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 198);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_timespan);
            this.Controls.Add(this.label_1);
            this.Controls.Add(this.ProgressBar_Main);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_Go);
            this.Controls.Add(this.metroButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "OneClick";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton btn_Go;
        private MetroFramework.Controls.MetroComboBox comboBox1;
        private MetroFramework.Controls.MetroCheckBox checkBox1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroProgressBar ProgressBar_Main;
        private System.Windows.Forms.Label label_1;
        private System.Windows.Forms.Label label_timespan;
        private System.Windows.Forms.Label label2;
    }
}

