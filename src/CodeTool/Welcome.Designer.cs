using CodeTool.Helper;

namespace CodeTool
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_function = new System.Windows.Forms.ComboBox();
            this.rtb_info = new System.Windows.Forms.RichTextBox();
            this.bt_do = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "选择功能";
            // 
            // cb_function
            // 
            this.cb_function.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_function.FormattingEnabled = true;
            this.cb_function.Items.AddRange(new object[] {
            "报表助手",
            "验证配置助手"});
            this.cb_function.Location = new System.Drawing.Point(72, 80);
            this.cb_function.Name = "cb_function";
            this.cb_function.Size = new System.Drawing.Size(101, 20);
            this.cb_function.TabIndex = 2;
            // 
            // rtb_info
            // 
            this.rtb_info.Location = new System.Drawing.Point(9, 7);
            this.rtb_info.Name = "rtb_info";
            this.rtb_info.Size = new System.Drawing.Size(308, 59);
            this.rtb_info.TabIndex = 1;
            this.rtb_info.Text = "请先选择功能，然后点击启动";
            this.rtb_info.TextChanged += new System.EventHandler(this.rtb_info_TextChanged);
            // 
            // bt_do
            // 
            this.bt_do.Location = new System.Drawing.Point(182, 80);
            this.bt_do.Name = "bt_do";
            this.bt_do.Size = new System.Drawing.Size(58, 21);
            this.bt_do.TabIndex = 0;
            this.bt_do.Text = "启动";
            this.bt_do.UseVisualStyleBackColor = true;
            this.bt_do.Click += new System.EventHandler(this.bt_do_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 21);
            this.button1.TabIndex = 4;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 109);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_function);
            this.Controls.Add(this.rtb_info);
            this.Controls.Add(this.bt_do);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Welcome";
            this.Text = "框架助手启动器";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_do;
        private System.Windows.Forms.RichTextBox rtb_info;
        private System.Windows.Forms.ComboBox cb_function;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}