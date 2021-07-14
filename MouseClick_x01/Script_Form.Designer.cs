﻿namespace OneClick
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
            this.Click_Check = new System.Windows.Forms.CheckBox();
            this.dataGridView_script = new System.Windows.Forms.DataGridView();
            this.txtBox_name = new System.Windows.Forms.TextBox();
            this.txt_ms_X = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ms_Y = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.btn_go = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label_timespan = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_script)).BeginInit();
            this.SuspendLayout();
            // 
            // Click_Check
            // 
            this.Click_Check.AutoSize = true;
            this.Click_Check.Location = new System.Drawing.Point(13, 91);
            this.Click_Check.Name = "Click_Check";
            this.Click_Check.Size = new System.Drawing.Size(61, 16);
            this.Click_Check.TabIndex = 7;
            this.Click_Check.Text = "Capture";
            this.Click_Check.UseVisualStyleBackColor = true;
            this.Click_Check.CheckedChanged += new System.EventHandler(this.Click_Check_CheckedChanged);
            // 
            // dataGridView_script
            // 
            this.dataGridView_script.AllowUserToAddRows = false;
            this.dataGridView_script.AllowUserToResizeColumns = false;
            this.dataGridView_script.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_script.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_script.Location = new System.Drawing.Point(12, 173);
            this.dataGridView_script.MinimumSize = new System.Drawing.Size(237, 0);
            this.dataGridView_script.Name = "dataGridView_script";
            this.dataGridView_script.RowTemplate.Height = 24;
            this.dataGridView_script.Size = new System.Drawing.Size(237, 331);
            this.dataGridView_script.TabIndex = 8;
            this.dataGridView_script.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_script_CellContentClick);
            this.dataGridView_script.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_script_ColumnWidthChanged);
            this.dataGridView_script.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_script_RowsAdded);
            this.dataGridView_script.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_script_UserDeletedRow);
            // 
            // txtBox_name
            // 
            this.txtBox_name.Location = new System.Drawing.Point(76, 88);
            this.txtBox_name.Name = "txtBox_name";
            this.txtBox_name.Size = new System.Drawing.Size(173, 22);
            this.txtBox_name.TabIndex = 10;
            this.txtBox_name.TextChanged += new System.EventHandler(this.txtBox_name_TextChanged);
            // 
            // txt_ms_X
            // 
            this.txt_ms_X.AutoSize = true;
            this.txt_ms_X.Location = new System.Drawing.Point(80, 117);
            this.txt_ms_X.Name = "txt_ms_X";
            this.txt_ms_X.Size = new System.Drawing.Size(11, 12);
            this.txt_ms_X.TabIndex = 11;
            this.txt_ms_X.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = " ，";
            // 
            // txt_ms_Y
            // 
            this.txt_ms_Y.AutoSize = true;
            this.txt_ms_Y.Location = new System.Drawing.Point(148, 117);
            this.txt_ms_Y.Name = "txt_ms_Y";
            this.txt_ms_Y.Size = new System.Drawing.Size(11, 12);
            this.txt_ms_Y.TabIndex = 13;
            this.txt_ms_Y.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Cursor";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(12, 61);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(55, 23);
            this.metroButton1.TabIndex = 17;
            this.metroButton1.Text = "New";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(70, 61);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(55, 23);
            this.metroButton2.TabIndex = 18;
            this.metroButton2.Text = "Insert";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(131, 61);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(55, 23);
            this.metroButton3.TabIndex = 19;
            this.metroButton3.Text = "Save";
            this.metroButton3.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(192, 61);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(55, 23);
            this.btn_go.TabIndex = 20;
            this.btn_go.Text = "Go";
            this.btn_go.Click += new System.EventHandler(this.btn_GO_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Location = new System.Drawing.Point(194, 114);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(55, 23);
            this.metroButton5.TabIndex = 21;
            this.metroButton5.Text = "Help";
            this.metroButton5.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "Timespan";
            // 
            // label_timespan
            // 
            this.label_timespan.AutoSize = true;
            this.label_timespan.Location = new System.Drawing.Point(80, 145);
            this.label_timespan.Name = "label_timespan";
            this.label_timespan.Size = new System.Drawing.Size(11, 12);
            this.label_timespan.TabIndex = 23;
            this.label_timespan.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "Seconds";
            // 
            // Script_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 535);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_timespan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ms_Y);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ms_X);
            this.Controls.Add(this.txtBox_name);
            this.Controls.Add(this.dataGridView_script);
            this.Controls.Add(this.Click_Check);
            this.Name = "Script_Form";
            this.Text = "Script_Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Script_Form_FormClosed);
            this.Load += new System.EventHandler(this.Script_Form_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Script_Form_MouseMove);
            this.Resize += new System.EventHandler(this.Script_Form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_script)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox Click_Check;
        private System.Windows.Forms.DataGridView dataGridView_script;
        private System.Windows.Forms.TextBox txtBox_name;
        private System.Windows.Forms.Label txt_ms_X;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt_ms_Y;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton btn_go;
        private MetroFramework.Controls.MetroButton metroButton5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_timespan;
        private System.Windows.Forms.Label label4;
    }
}