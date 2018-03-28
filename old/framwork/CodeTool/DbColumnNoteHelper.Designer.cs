using xyj.tool.Helper;

namespace xyj.tool
{
    partial class DbColumnNoteHelper: BaseDbForm
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
            this.tb_note = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtb_output = new System.Windows.Forms.RichTextBox();
            this.tb_error_tip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_regex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lv_regex = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_note
            // 
            this.tb_note.Location = new System.Drawing.Point(85, 24);
            this.tb_note.Name = "tb_note";
            this.tb_note.Size = new System.Drawing.Size(250, 21);
            this.tb_note.TabIndex = 1;
            this.tb_note.TextChanged += new System.EventHandler(this.tb_error_tip_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "列注释";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tb_error_tip);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_regex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_note);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 278);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtb_output);
            this.groupBox2.Location = new System.Drawing.Point(18, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 135);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出（复制粘贴到字段说明中）";
            // 
            // rtb_output
            // 
            this.rtb_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_output.Location = new System.Drawing.Point(3, 17);
            this.rtb_output.Name = "rtb_output";
            this.rtb_output.Size = new System.Drawing.Size(313, 115);
            this.rtb_output.TabIndex = 4;
            this.rtb_output.Text = "";
            // 
            // tb_error_tip
            // 
            this.tb_error_tip.Location = new System.Drawing.Point(84, 98);
            this.tb_error_tip.Name = "tb_error_tip";
            this.tb_error_tip.Size = new System.Drawing.Size(250, 21);
            this.tb_error_tip.TabIndex = 1;
            this.tb_error_tip.TextChanged += new System.EventHandler(this.tb_error_tip_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "错误提示";
            // 
            // tb_regex
            // 
            this.tb_regex.Location = new System.Drawing.Point(84, 62);
            this.tb_regex.Name = "tb_regex";
            this.tb_regex.Size = new System.Drawing.Size(250, 21);
            this.tb_regex.TabIndex = 1;
            this.tb_regex.TextChanged += new System.EventHandler(this.tb_error_tip_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "正则式";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lv_regex);
            this.groupBox3.Location = new System.Drawing.Point(358, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 278);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "常用正则式";
            // 
            // lv_regex
            // 
            this.lv_regex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_regex.Location = new System.Drawing.Point(3, 17);
            this.lv_regex.Name = "lv_regex";
            this.lv_regex.Size = new System.Drawing.Size(337, 258);
            this.lv_regex.TabIndex = 0;
            this.lv_regex.UseCompatibleStateImageBehavior = false;
            this.lv_regex.DoubleClick += new System.EventHandler(this.lv_regex_DoubleClick);
            // 
            // DbColumnNoteHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 299);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "DbColumnNoteHelper";
            this.Text = "数据库说明字段配置助手";
            this.Load += new System.EventHandler(this.DbColumnNoteHelper_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_note;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtb_output;
        private System.Windows.Forms.TextBox tb_error_tip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_regex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lv_regex;
    }
}