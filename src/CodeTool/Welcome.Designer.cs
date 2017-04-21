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
            this.rtb_info = new System.Windows.Forms.RichTextBox();
            this.bt_do = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtb_info
            // 
            this.rtb_info.Location = new System.Drawing.Point(9, 7);
            this.rtb_info.Name = "rtb_info";
            this.rtb_info.Size = new System.Drawing.Size(308, 59);
            this.rtb_info.TabIndex = 1;
            this.rtb_info.Text = "Please Click Button [Test Environment] To Continue";
            this.rtb_info.TextChanged += new System.EventHandler(this.rtb_info_TextChanged);
            // 
            // bt_do
            // 
            this.bt_do.Location = new System.Drawing.Point(80, 72);
            this.bt_do.Name = "bt_do";
            this.bt_do.Size = new System.Drawing.Size(162, 37);
            this.bt_do.TabIndex = 0;
            this.bt_do.Text = "Test Environment";
            this.bt_do.UseVisualStyleBackColor = true;
            this.bt_do.Click += new System.EventHandler(this.bt_do_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 117);
            this.ControlBox = false;
            this.Controls.Add(this.rtb_info);
            this.Controls.Add(this.bt_do);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Welcome";
            this.Text = "Welcome To QxFramwork Tool";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_do;
        private System.Windows.Forms.RichTextBox rtb_info;
    }
}