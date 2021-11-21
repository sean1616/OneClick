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
            this.metroButton_connect = new MetroFramework.Controls.MetroButton();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_portMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(32, 182);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(88, 34);
            this.metroButton1.TabIndex = 36;
            this.metroButton1.Text = "Setting";
            this.metroButton1.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_Go
            // 
            this.btn_Go.Location = new System.Drawing.Point(138, 182);
            this.btn_Go.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(252, 34);
            this.btn_Go.TabIndex = 37;
            this.btn_Go.Text = "Go";
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 23;
            this.comboBox1.Location = new System.Drawing.Point(138, 135);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(252, 29);
            this.comboBox1.TabIndex = 38;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.checkBox1.Location = new System.Drawing.Point(39, 140);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(67, 19);
            this.checkBox1.TabIndex = 39;
            this.checkBox1.Text = "Repeat";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ProgressBar_Main
            // 
            this.ProgressBar_Main.HideProgressText = false;
            this.ProgressBar_Main.Location = new System.Drawing.Point(-2, 258);
            this.ProgressBar_Main.Margin = new System.Windows.Forms.Padding(4);
            this.ProgressBar_Main.Name = "ProgressBar_Main";
            this.ProgressBar_Main.Size = new System.Drawing.Size(420, 24);
            this.ProgressBar_Main.Step = 2;
            this.ProgressBar_Main.Style = MetroFramework.MetroColorStyle.Orange;
            this.ProgressBar_Main.TabIndex = 40;
            this.ProgressBar_Main.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroToolTip1.SetToolTip(this.ProgressBar_Main, "Scrip Progress");
            // 
            // label_1
            // 
            this.label_1.AutoSize = true;
            this.label_1.Font = new System.Drawing.Font("新細明體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_1.Location = new System.Drawing.Point(34, 231);
            this.label_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(69, 16);
            this.label_1.TabIndex = 41;
            this.label_1.Text = "Timespan";
            // 
            // label_timespan
            // 
            this.label_timespan.AutoSize = true;
            this.label_timespan.Font = new System.Drawing.Font("新細明體", 8F);
            this.label_timespan.Location = new System.Drawing.Point(204, 231);
            this.label_timespan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_timespan.Name = "label_timespan";
            this.label_timespan.Size = new System.Drawing.Size(16, 16);
            this.label_timespan.TabIndex = 42;
            this.label_timespan.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 8F);
            this.label2.Location = new System.Drawing.Point(327, 231);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "Seconds";
            // 
            // metroButton_connect
            // 
            this.metroButton_connect.Location = new System.Drawing.Point(289, 88);
            this.metroButton_connect.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton_connect.Name = "metroButton_connect";
            this.metroButton_connect.Size = new System.Drawing.Size(101, 29);
            this.metroButton_connect.TabIndex = 44;
            this.metroButton_connect.Text = "Connect";
            this.metroButton_connect.Click += new System.EventHandler(this.metroButton_connect_Click);
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(138, 88);
            this.metroComboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(127, 29);
            this.metroComboBox1.TabIndex = 45;
            this.metroComboBox1.DropDown += new System.EventHandler(this.metroComboBox1_DropDown);
            this.metroComboBox1.DropDownClosed += new System.EventHandler(this.metroComboBox1_DropDownClosed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(37, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "Annunciator";
            // 
            // label_portMsg
            // 
            this.label_portMsg.AutoSize = true;
            this.label_portMsg.Font = new System.Drawing.Font("新細明體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_portMsg.Location = new System.Drawing.Point(230, 37);
            this.label_portMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_portMsg.Name = "label_portMsg";
            this.label_portMsg.Size = new System.Drawing.Size(0, 16);
            this.label_portMsg.TabIndex = 47;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(417, 286);
            this.Controls.Add(this.label_portMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.metroButton_connect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_timespan);
            this.Controls.Add(this.label_1);
            this.Controls.Add(this.ProgressBar_Main);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_Go);
            this.Controls.Add(this.metroButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(30, 90, 30, 30);
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.Flat;
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
        private MetroFramework.Controls.MetroButton metroButton_connect;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_portMsg;
    }
}

