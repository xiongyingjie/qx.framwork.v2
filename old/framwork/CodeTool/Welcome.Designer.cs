using xyj.tool.Helper;

namespace xyj.tool
{
    partial class Welcome : BaseDbForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtb_info = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_uid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_psw = new System.Windows.Forms.TextBox();
            this.bt_exit = new System.Windows.Forms.Button();
            this.cb_function = new System.Windows.Forms.ComboBox();
            this.bt_do = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtb_info);
            this.groupBox2.Location = new System.Drawing.Point(215, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 109);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "更新日志";
            // 
            // rtb_info
            // 
            this.rtb_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_info.Location = new System.Drawing.Point(3, 17);
            this.rtb_info.Name = "rtb_info";
            this.rtb_info.Size = new System.Drawing.Size(443, 89);
            this.rtb_info.TabIndex = 1;
            this.rtb_info.Text = resources.GetString("rtb_info.Text");
            this.rtb_info.TextChanged += new System.EventHandler(this.rtb_info_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_uid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_psw);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 83);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "身份认证";
            // 
            // tb_uid
            // 
            this.tb_uid.Location = new System.Drawing.Point(55, 17);
            this.tb_uid.Name = "tb_uid";
            this.tb_uid.Size = new System.Drawing.Size(120, 21);
            this.tb_uid.TabIndex = 5;
            this.tb_uid.Text = "1325112032";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "账号";
            // 
            // tb_psw
            // 
            this.tb_psw.Location = new System.Drawing.Point(55, 46);
            this.tb_psw.Name = "tb_psw";
            this.tb_psw.PasswordChar = '*';
            this.tb_psw.Size = new System.Drawing.Size(120, 21);
            this.tb_psw.TabIndex = 6;
            this.tb_psw.Text = "1325112032";
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(14, 100);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(47, 21);
            this.bt_exit.TabIndex = 4;
            this.bt_exit.Text = "关闭";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_function
            // 
            this.cb_function.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_function.FormattingEnabled = true;
            this.cb_function.Items.AddRange(new object[] {
            "报表生成器",
            "表单生成器",
            "查询生成器"});
            this.cb_function.Location = new System.Drawing.Point(67, 101);
            this.cb_function.Name = "cb_function";
            this.cb_function.Size = new System.Drawing.Size(90, 20);
            this.cb_function.TabIndex = 2;
            // 
            // bt_do
            // 
            this.bt_do.Location = new System.Drawing.Point(163, 100);
            this.bt_do.Name = "bt_do";
            this.bt_do.Size = new System.Drawing.Size(42, 21);
            this.bt_do.TabIndex = 0;
            this.bt_do.Text = "启动";
            this.bt_do.UseVisualStyleBackColor = true;
            this.bt_do.Click += new System.EventHandler(this.bt_do_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 129);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.cb_function);
            this.Controls.Add(this.bt_do);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "框架助手启动器V2.0";
            this.Load += new System.EventHandler(this.Test_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_do;
        private System.Windows.Forms.ComboBox cb_function;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.RichTextBox rtb_info;
        private System.Windows.Forms.TextBox tb_uid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_psw;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}