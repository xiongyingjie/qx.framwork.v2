namespace xyj.tool
{
    partial class AutoCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoCode));
            this.rtb_controllerCode = new System.Windows.Forms.RichTextBox();
            this.rtb_viewCode = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_submit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_reopen = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_action = new System.Windows.Forms.Label();
            this.tb_paramNote = new System.Windows.Forms.TextBox();
            this.tb_addLink = new System.Windows.Forms.TextBox();
            this.tb_action = new System.Windows.Forms.TextBox();
            this.lb_controller = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_controller = new System.Windows.Forms.TextBox();
            this.tb_area = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_reportId = new System.Windows.Forms.Label();
            this.tb_dbKey = new System.Windows.Forms.TextBox();
            this.tb_params = new System.Windows.Forms.TextBox();
            this.tb_perCount = new System.Windows.Forms.TextBox();
            this.tb_reportName = new System.Windows.Forms.TextBox();
            this.tb_pageIndex = new System.Windows.Forms.TextBox();
            this.tb_reportId = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb_controllerCode
            // 
            this.rtb_controllerCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_controllerCode.Location = new System.Drawing.Point(3, 17);
            this.rtb_controllerCode.Name = "rtb_controllerCode";
            this.rtb_controllerCode.Size = new System.Drawing.Size(602, 229);
            this.rtb_controllerCode.TabIndex = 1;
            this.rtb_controllerCode.Text = resources.GetString("rtb_controllerCode.Text");
            // 
            // rtb_viewCode
            // 
            this.rtb_viewCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_viewCode.Location = new System.Drawing.Point(3, 17);
            this.rtb_viewCode.Name = "rtb_viewCode";
            this.rtb_viewCode.Size = new System.Drawing.Size(602, 214);
            this.rtb_viewCode.TabIndex = 1;
            this.rtb_viewCode.Text = resources.GetString("rtb_viewCode.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_controllerCode);
            this.groupBox1.Location = new System.Drawing.Point(6, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 249);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controller Code";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtb_viewCode);
            this.groupBox2.Location = new System.Drawing.Point(658, 292);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(608, 234);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Code";
            // 
            // bt_submit
            // 
            this.bt_submit.Location = new System.Drawing.Point(183, 62);
            this.bt_submit.Name = "bt_submit";
            this.bt_submit.Size = new System.Drawing.Size(75, 23);
            this.bt_submit.TabIndex = 3;
            this.bt_submit.Text = "Submit";
            this.bt_submit.UseVisualStyleBackColor = true;
            this.bt_submit.Click += new System.EventHandler(this.bt_submit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.bt_reopen);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lb_action);
            this.groupBox3.Controls.Add(this.tb_paramNote);
            this.groupBox3.Controls.Add(this.bt_submit);
            this.groupBox3.Controls.Add(this.tb_addLink);
            this.groupBox3.Controls.Add(this.tb_action);
            this.groupBox3.Location = new System.Drawing.Point(12, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(601, 97);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Code Config";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search";
            // 
            // bt_reopen
            // 
            this.bt_reopen.Location = new System.Drawing.Point(289, 62);
            this.bt_reopen.Name = "bt_reopen";
            this.bt_reopen.Size = new System.Drawing.Size(75, 23);
            this.bt_reopen.TabIndex = 3;
            this.bt_reopen.Text = "ReChoose";
            this.bt_reopen.UseVisualStyleBackColor = true;
            this.bt_reopen.Click += new System.EventHandler(this.bt_reopen_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "AddLink";
            // 
            // lb_action
            // 
            this.lb_action.AutoSize = true;
            this.lb_action.Location = new System.Drawing.Point(413, 29);
            this.lb_action.Name = "lb_action";
            this.lb_action.Size = new System.Drawing.Size(41, 12);
            this.lb_action.TabIndex = 1;
            this.lb_action.Text = "Action";
            // 
            // tb_paramNote
            // 
            this.tb_paramNote.Location = new System.Drawing.Point(255, 25);
            this.tb_paramNote.Name = "tb_paramNote";
            this.tb_paramNote.Size = new System.Drawing.Size(141, 21);
            this.tb_paramNote.TabIndex = 0;
            this.tb_paramNote.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_addLink
            // 
            this.tb_addLink.Location = new System.Drawing.Point(74, 25);
            this.tb_addLink.Name = "tb_addLink";
            this.tb_addLink.Size = new System.Drawing.Size(129, 21);
            this.tb_addLink.TabIndex = 0;
            this.tb_addLink.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_action
            // 
            this.tb_action.Location = new System.Drawing.Point(463, 25);
            this.tb_action.Name = "tb_action";
            this.tb_action.Size = new System.Drawing.Size(117, 21);
            this.tb_action.TabIndex = 0;
            this.tb_action.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // lb_controller
            // 
            this.lb_controller.AutoSize = true;
            this.lb_controller.Location = new System.Drawing.Point(849, 75);
            this.lb_controller.Name = "lb_controller";
            this.lb_controller.Size = new System.Drawing.Size(65, 12);
            this.lb_controller.TabIndex = 1;
            this.lb_controller.Text = "Controller";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(849, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Area";
            // 
            // tb_controller
            // 
            this.tb_controller.Location = new System.Drawing.Point(916, 69);
            this.tb_controller.Name = "tb_controller";
            this.tb_controller.Size = new System.Drawing.Size(87, 21);
            this.tb_controller.TabIndex = 0;
            this.tb_controller.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_area
            // 
            this.tb_area.Location = new System.Drawing.Point(916, 32);
            this.tb_area.Name = "tb_area";
            this.tb_area.Size = new System.Drawing.Size(87, 21);
            this.tb_area.TabIndex = 0;
            this.tb_area.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(663, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "dbKey";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(662, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "Params";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(662, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "perCount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(656, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "ReportName";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(662, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "pageIndex";
            // 
            // lb_reportId
            // 
            this.lb_reportId.AutoSize = true;
            this.lb_reportId.Location = new System.Drawing.Point(656, 41);
            this.lb_reportId.Name = "lb_reportId";
            this.lb_reportId.Size = new System.Drawing.Size(53, 12);
            this.lb_reportId.TabIndex = 1;
            this.lb_reportId.Text = "ReportId";
            // 
            // tb_dbKey
            // 
            this.tb_dbKey.Location = new System.Drawing.Point(723, 232);
            this.tb_dbKey.Name = "tb_dbKey";
            this.tb_dbKey.ReadOnly = true;
            this.tb_dbKey.Size = new System.Drawing.Size(49, 21);
            this.tb_dbKey.TabIndex = 0;
            // 
            // tb_params
            // 
            this.tb_params.Location = new System.Drawing.Point(727, 155);
            this.tb_params.Name = "tb_params";
            this.tb_params.ReadOnly = true;
            this.tb_params.Size = new System.Drawing.Size(49, 21);
            this.tb_params.TabIndex = 0;
            // 
            // tb_perCount
            // 
            this.tb_perCount.Location = new System.Drawing.Point(724, 195);
            this.tb_perCount.Name = "tb_perCount";
            this.tb_perCount.ReadOnly = true;
            this.tb_perCount.Size = new System.Drawing.Size(48, 21);
            this.tb_perCount.TabIndex = 0;
            // 
            // tb_reportName
            // 
            this.tb_reportName.Location = new System.Drawing.Point(729, 72);
            this.tb_reportName.Name = "tb_reportName";
            this.tb_reportName.ReadOnly = true;
            this.tb_reportName.Size = new System.Drawing.Size(87, 21);
            this.tb_reportName.TabIndex = 0;
            // 
            // tb_pageIndex
            // 
            this.tb_pageIndex.Location = new System.Drawing.Point(727, 119);
            this.tb_pageIndex.Name = "tb_pageIndex";
            this.tb_pageIndex.ReadOnly = true;
            this.tb_pageIndex.Size = new System.Drawing.Size(49, 21);
            this.tb_pageIndex.TabIndex = 0;
            // 
            // tb_reportId
            // 
            this.tb_reportId.Location = new System.Drawing.Point(729, 35);
            this.tb_reportId.Name = "tb_reportId";
            this.tb_reportId.ReadOnly = true;
            this.tb_reportId.Size = new System.Drawing.Size(87, 21);
            this.tb_reportId.TabIndex = 0;
            // 
            // AutoCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 367);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_controller);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_controller);
            this.Controls.Add(this.tb_reportId);
            this.Controls.Add(this.tb_area);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_pageIndex);
            this.Controls.Add(this.tb_reportName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_perCount);
            this.Controls.Add(this.lb_reportId);
            this.Controls.Add(this.tb_params);
            this.Controls.Add(this.tb_dbKey);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoCode";
            this.Text = "报表助手-生成代码";
            this.Load += new System.EventHandler(this.AutoCode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_controllerCode;
        private System.Windows.Forms.RichTextBox rtb_viewCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_submit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_action;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_controller;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_reportId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_addLink;
        private System.Windows.Forms.TextBox tb_params;
        private System.Windows.Forms.TextBox tb_action;
        private System.Windows.Forms.TextBox tb_perCount;
        private System.Windows.Forms.TextBox tb_reportName;
        private System.Windows.Forms.TextBox tb_pageIndex;
        private System.Windows.Forms.TextBox tb_reportId;
        private System.Windows.Forms.TextBox tb_controller;
        private System.Windows.Forms.TextBox tb_area;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_paramNote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_dbKey;
        private System.Windows.Forms.Button bt_reopen;
    }
}