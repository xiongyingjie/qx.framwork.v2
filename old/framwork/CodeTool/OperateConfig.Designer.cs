using xyj.tool.Helper;

namespace xyj.tool
{
    partial class OperateConfig: BaseDbForm
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
            this.tb_output = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nud_param_3 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.p_param_2 = new System.Windows.Forms.Panel();
            this.nud_param_2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.p_param_1 = new System.Windows.Forms.Panel();
            this.nud_param_1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_op2 = new System.Windows.Forms.TextBox();
            this.cb_table = new System.Windows.Forms.ComboBox();
            this.cb_db = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_url = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_operate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.p_condition_1 = new System.Windows.Forms.Panel();
            this.cb_condition_oprator = new System.Windows.Forms.ComboBox();
            this.nud_conditon_1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_conditon_value_1 = new System.Windows.Forms.TextBox();
            this.bt_submit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nud_param = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_can_click = new System.Windows.Forms.ComboBox();
            this.nud_condition = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_param_3)).BeginInit();
            this.p_param_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_param_2)).BeginInit();
            this.p_param_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_param_1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.p_condition_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_conditon_1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_param)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_condition)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_output
            // 
            this.tb_output.Location = new System.Drawing.Point(15, 275);
            this.tb_output.Name = "tb_output";
            this.tb_output.ReadOnly = true;
            this.tb_output.Size = new System.Drawing.Size(287, 21);
            this.tb_output.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.p_param_2);
            this.groupBox3.Controls.Add(this.p_param_1);
            this.groupBox3.Location = new System.Drawing.Point(9, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 77);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "参数分别是:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nud_param_3);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(236, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(110, 40);
            this.panel2.TabIndex = 2;
            // 
            // nud_param_3
            // 
            this.nud_param_3.Location = new System.Drawing.Point(70, 11);
            this.nud_param_3.Name = "nud_param_3";
            this.nud_param_3.Size = new System.Drawing.Size(34, 21);
            this.nud_param_3.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "参数3索引";
            // 
            // p_param_2
            // 
            this.p_param_2.Controls.Add(this.nud_param_2);
            this.p_param_2.Controls.Add(this.label5);
            this.p_param_2.Location = new System.Drawing.Point(124, 20);
            this.p_param_2.Name = "p_param_2";
            this.p_param_2.Size = new System.Drawing.Size(109, 40);
            this.p_param_2.TabIndex = 2;
            // 
            // nud_param_2
            // 
            this.nud_param_2.Location = new System.Drawing.Point(65, 11);
            this.nud_param_2.Name = "nud_param_2";
            this.nud_param_2.Size = new System.Drawing.Size(34, 21);
            this.nud_param_2.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "参数2索引";
            // 
            // p_param_1
            // 
            this.p_param_1.Controls.Add(this.nud_param_1);
            this.p_param_1.Controls.Add(this.label6);
            this.p_param_1.Location = new System.Drawing.Point(9, 20);
            this.p_param_1.Name = "p_param_1";
            this.p_param_1.Size = new System.Drawing.Size(111, 40);
            this.p_param_1.TabIndex = 2;
            // 
            // nud_param_1
            // 
            this.nud_param_1.Location = new System.Drawing.Point(69, 11);
            this.nud_param_1.Name = "nud_param_1";
            this.nud_param_1.Size = new System.Drawing.Size(34, 21);
            this.nud_param_1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "参数1索引";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.p_condition_1);
            this.groupBox2.Location = new System.Drawing.Point(9, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 116);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "条件是：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.tb_op2);
            this.panel3.Controls.Add(this.cb_table);
            this.panel3.Controls.Add(this.cb_db);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(7, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 35);
            this.panel3.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "对";
            // 
            // tb_op2
            // 
            this.tb_op2.Location = new System.Drawing.Point(256, 6);
            this.tb_op2.Name = "tb_op2";
            this.tb_op2.Size = new System.Drawing.Size(74, 21);
            this.tb_op2.TabIndex = 2;
            this.tb_op2.Text = "删除";
            this.tb_op2.TextChanged += new System.EventHandler(this.tb_op2_TextChanged);
            // 
            // cb_table
            // 
            this.cb_table.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_table.FormattingEnabled = true;
            this.cb_table.Items.AddRange(new object[] {
            "是表单",
            "是报表",
            "是删除",
            "可被点击",
            "不可点击"});
            this.cb_table.Location = new System.Drawing.Point(125, 7);
            this.cb_table.Name = "cb_table";
            this.cb_table.Size = new System.Drawing.Size(90, 20);
            this.cb_table.TabIndex = 0;
            // 
            // cb_db
            // 
            this.cb_db.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_db.FormattingEnabled = true;
            this.cb_db.Items.AddRange(new object[] {
            "是表单",
            "是报表",
            "是删除",
            "可被点击",
            "不可点击"});
            this.cb_db.Location = new System.Drawing.Point(29, 7);
            this.cb_db.Name = "cb_db";
            this.cb_db.Size = new System.Drawing.Size(90, 20);
            this.cb_db.TabIndex = 0;
            this.cb_db.SelectedIndexChanged += new System.EventHandler(this.cb_db_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(222, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "进行";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_url);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tb_operate);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(6, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 35);
            this.panel1.TabIndex = 4;
            // 
            // tb_url
            // 
            this.tb_url.Location = new System.Drawing.Point(53, 7);
            this.tb_url.Name = "tb_url";
            this.tb_url.Size = new System.Drawing.Size(115, 21);
            this.tb_url.TabIndex = 2;
            this.tb_url.Text = "/Home/Index";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "跳转到";
            // 
            // tb_operate
            // 
            this.tb_operate.Location = new System.Drawing.Point(207, 7);
            this.tb_operate.Name = "tb_operate";
            this.tb_operate.Size = new System.Drawing.Size(97, 21);
            this.tb_operate.TabIndex = 2;
            this.tb_operate.Text = "编辑";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(308, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "操作";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "进行";
            // 
            // p_condition_1
            // 
            this.p_condition_1.Controls.Add(this.cb_condition_oprator);
            this.p_condition_1.Controls.Add(this.nud_conditon_1);
            this.p_condition_1.Controls.Add(this.label4);
            this.p_condition_1.Controls.Add(this.label11);
            this.p_condition_1.Controls.Add(this.label3);
            this.p_condition_1.Controls.Add(this.tb_conditon_value_1);
            this.p_condition_1.Location = new System.Drawing.Point(6, 20);
            this.p_condition_1.Name = "p_condition_1";
            this.p_condition_1.Size = new System.Drawing.Size(340, 42);
            this.p_condition_1.TabIndex = 2;
            // 
            // cb_condition_oprator
            // 
            this.cb_condition_oprator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_condition_oprator.FormattingEnabled = true;
            this.cb_condition_oprator.Items.AddRange(new object[] {
            "=",
            "!=",
            ">",
            "<",
            ">=",
            "<="});
            this.cb_condition_oprator.Location = new System.Drawing.Point(131, 11);
            this.cb_condition_oprator.Name = "cb_condition_oprator";
            this.cb_condition_oprator.Size = new System.Drawing.Size(37, 20);
            this.cb_condition_oprator.TabIndex = 0;
            // 
            // nud_conditon_1
            // 
            this.nud_conditon_1.Location = new System.Drawing.Point(46, 10);
            this.nud_conditon_1.Name = "nud_conditon_1";
            this.nud_conditon_1.Size = new System.Drawing.Size(34, 21);
            this.nud_conditon_1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "列的值";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(250, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "时";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "当第";
            // 
            // tb_conditon_value_1
            // 
            this.tb_conditon_value_1.Location = new System.Drawing.Point(176, 10);
            this.tb_conditon_value_1.Name = "tb_conditon_value_1";
            this.tb_conditon_value_1.Size = new System.Drawing.Size(68, 21);
            this.tb_conditon_value_1.TabIndex = 2;
            this.tb_conditon_value_1.Text = "1";
            // 
            // bt_submit
            // 
            this.bt_submit.Location = new System.Drawing.Point(316, 273);
            this.bt_submit.Name = "bt_submit";
            this.bt_submit.Size = new System.Drawing.Size(39, 23);
            this.bt_submit.TabIndex = 3;
            this.bt_submit.Text = "ok";
            this.bt_submit.UseVisualStyleBackColor = true;
            this.bt_submit.Click += new System.EventHandler(this.bt_submit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nud_param);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cb_can_click);
            this.groupBox1.Controls.Add(this.nud_condition);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 59);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "这个操作:";
            // 
            // nud_param
            // 
            this.nud_param.Location = new System.Drawing.Point(259, 22);
            this.nud_param.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_param.Name = "nud_param";
            this.nud_param.Size = new System.Drawing.Size(34, 21);
            this.nud_param.TabIndex = 0;
            this.nud_param.ValueChanged += new System.EventHandler(this.UpdateOutPut);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(106, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "且包含";
            // 
            // cb_can_click
            // 
            this.cb_can_click.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_can_click.FormattingEnabled = true;
            this.cb_can_click.Items.AddRange(new object[] {
            "是表单",
            "是报表",
            "是删除",
            "可被点击",
            "不可点击"});
            this.cb_can_click.Location = new System.Drawing.Point(9, 25);
            this.cb_can_click.Name = "cb_can_click";
            this.cb_can_click.Size = new System.Drawing.Size(90, 20);
            this.cb_can_click.TabIndex = 0;
            this.cb_can_click.SelectedIndexChanged += new System.EventHandler(this.cb_can_click_SelectedIndexChanged);
            // 
            // nud_condition
            // 
            this.nud_condition.Location = new System.Drawing.Point(158, 23);
            this.nud_condition.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_condition.Name = "nud_condition";
            this.nud_condition.Size = new System.Drawing.Size(34, 21);
            this.nud_condition.TabIndex = 0;
            this.nud_condition.ValueChanged += new System.EventHandler(this.UpdateOutPut);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "个条件和";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "个参数";
            // 
            // OperateConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 303);
            this.Controls.Add(this.tb_output);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bt_submit);
            this.Controls.Add(this.groupBox1);
            this.Name = "OperateConfig";
            this.Text = "操作列配置";
            this.Load += new System.EventHandler(this.OperateConfig_Load);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_param_3)).EndInit();
            this.p_param_2.ResumeLayout(false);
            this.p_param_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_param_2)).EndInit();
            this.p_param_1.ResumeLayout(false);
            this.p_param_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_param_1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.p_condition_1.ResumeLayout(false);
            this.p_condition_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_conditon_1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_param)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_condition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_submit;
        private System.Windows.Forms.TextBox tb_operate;
        private System.Windows.Forms.Panel p_condition_1;
        private System.Windows.Forms.NumericUpDown nud_conditon_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel p_param_2;
        private System.Windows.Forms.NumericUpDown nud_param_2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel p_param_1;
        private System.Windows.Forms.NumericUpDown nud_param_1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_condition_oprator;
        private System.Windows.Forms.ComboBox cb_can_click;
        private System.Windows.Forms.TextBox tb_url;
        private System.Windows.Forms.NumericUpDown nud_param;
        private System.Windows.Forms.NumericUpDown nud_condition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_conditon_value_1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown nud_param_3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_op2;
        private System.Windows.Forms.ComboBox cb_table;
        private System.Windows.Forms.ComboBox cb_db;
        private System.Windows.Forms.Label label14;
    }
}