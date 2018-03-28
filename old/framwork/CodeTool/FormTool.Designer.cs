
using xyj.tool.Helper;

namespace xyj.tool
{
    partial class FormTool: BaseDbForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tv_dataBase = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_colums = new System.Windows.Forms.ListView();
            this.gp_addReport = new System.Windows.Forms.GroupBox();
            this.rtb_colums = new System.Windows.Forms.RichTextBox();
            this.rtb_columsNote = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_database = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_tables = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pg_colum = new System.Windows.Forms.PropertyGrid();
            this.p_addReport = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_State = new System.Windows.Forms.ToolStripStatusLabel();
            this.bt_confirm = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gp_addReport.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.p_addReport.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_dataBase);
            this.groupBox1.Location = new System.Drawing.Point(5, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 346);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1.选字段";
            // 
            // tv_dataBase
            // 
            this.tv_dataBase.CheckBoxes = true;
            this.tv_dataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_dataBase.Location = new System.Drawing.Point(3, 17);
            this.tv_dataBase.Name = "tv_dataBase";
            this.tv_dataBase.Size = new System.Drawing.Size(201, 326);
            this.tv_dataBase.TabIndex = 0;
            this.tv_dataBase.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv_dataBase_AfterCheck);
            this.tv_dataBase.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tv_dataBase_AfterExpand);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lv_colums);
            this.groupBox2.Location = new System.Drawing.Point(218, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 343);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2.配置已选字段";
            // 
            // lv_colums
            // 
            this.lv_colums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_colums.HoverSelection = true;
            this.lv_colums.Location = new System.Drawing.Point(3, 17);
            this.lv_colums.Name = "lv_colums";
            this.lv_colums.Size = new System.Drawing.Size(367, 323);
            this.lv_colums.TabIndex = 0;
            this.lv_colums.UseCompatibleStateImageBehavior = false;
            this.lv_colums.SelectedIndexChanged += new System.EventHandler(this.lv_colums_SelectedIndexChanged);
            this.lv_colums.Leave += new System.EventHandler(this.lv_colums_Leave);
            // 
            // gp_addReport
            // 
            this.gp_addReport.Controls.Add(this.bt_confirm);
            this.gp_addReport.Controls.Add(this.rtb_colums);
            this.gp_addReport.Controls.Add(this.rtb_columsNote);
            this.gp_addReport.Controls.Add(this.label10);
            this.gp_addReport.Controls.Add(this.label5);
            this.gp_addReport.Controls.Add(this.tb_database);
            this.gp_addReport.Controls.Add(this.label8);
            this.gp_addReport.Controls.Add(this.tb_tables);
            this.gp_addReport.Controls.Add(this.label2);
            this.gp_addReport.Location = new System.Drawing.Point(14, 380);
            this.gp_addReport.Name = "gp_addReport";
            this.gp_addReport.Size = new System.Drawing.Size(783, 175);
            this.gp_addReport.TabIndex = 4;
            this.gp_addReport.TabStop = false;
            this.gp_addReport.Text = "4.检查参数";
            // 
            // rtb_colums
            // 
            this.rtb_colums.Location = new System.Drawing.Point(16, 76);
            this.rtb_colums.Name = "rtb_colums";
            this.rtb_colums.Size = new System.Drawing.Size(241, 93);
            this.rtb_colums.TabIndex = 26;
            this.rtb_colums.Text = "";
            // 
            // rtb_columsNote
            // 
            this.rtb_columsNote.Location = new System.Drawing.Point(267, 75);
            this.rtb_columsNote.Name = "rtb_columsNote";
            this.rtb_columsNote.Size = new System.Drawing.Size(484, 94);
            this.rtb_columsNote.TabIndex = 27;
            this.rtb_columsNote.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "Colums";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "ColumsNote";
            // 
            // tb_database
            // 
            this.tb_database.Location = new System.Drawing.Point(73, 23);
            this.tb_database.Name = "tb_database";
            this.tb_database.Size = new System.Drawing.Size(99, 21);
            this.tb_database.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "Tables";
            // 
            // tb_tables
            // 
            this.tb_tables.Location = new System.Drawing.Point(247, 23);
            this.tb_tables.Name = "tb_tables";
            this.tb_tables.Size = new System.Drawing.Size(172, 21);
            this.tb_tables.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "DataBase";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pg_colum);
            this.groupBox6.Location = new System.Drawing.Point(602, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(169, 340);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "3.编辑字段属性";
            // 
            // pg_colum
            // 
            this.pg_colum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg_colum.Location = new System.Drawing.Point(3, 17);
            this.pg_colum.Name = "pg_colum";
            this.pg_colum.Size = new System.Drawing.Size(163, 320);
            this.pg_colum.TabIndex = 0;
            this.pg_colum.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pg_colum_PropertyValueChanged);
            // 
            // p_addReport
            // 
            this.p_addReport.Controls.Add(this.groupBox1);
            this.p_addReport.Controls.Add(this.groupBox2);
            this.p_addReport.Controls.Add(this.groupBox6);
            this.p_addReport.Location = new System.Drawing.Point(12, 12);
            this.p_addReport.Name = "p_addReport";
            this.p_addReport.Size = new System.Drawing.Size(785, 362);
            this.p_addReport.TabIndex = 15;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_State});
            this.statusStrip1.Location = new System.Drawing.Point(0, 566);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(809, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_State
            // 
            this.tssl_State.Name = "tssl_State";
            this.tssl_State.Size = new System.Drawing.Size(61, 17);
            this.tssl_State.Text = "tssl_State";
            // 
            // bt_confirm
            // 
            this.bt_confirm.Location = new System.Drawing.Point(662, 21);
            this.bt_confirm.Name = "bt_confirm";
            this.bt_confirm.Size = new System.Drawing.Size(75, 35);
            this.bt_confirm.TabIndex = 29;
            this.bt_confirm.Text = "confirm";
            this.bt_confirm.UseVisualStyleBackColor = true;
            this.bt_confirm.Click += new System.EventHandler(this.bt_confirm_Click);
            // 
            // FormTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 588);
            this.Controls.Add(this.p_addReport);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gp_addReport);
            this.MaximizeBox = false;
            this.Name = "FormTool";
            this.Text = "表单助手1.0";
            this.Load += new System.EventHandler(this.FormTool_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gp_addReport.ResumeLayout(false);
            this.gp_addReport.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.p_addReport.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tv_dataBase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lv_colums;
        private System.Windows.Forms.GroupBox gp_addReport;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PropertyGrid pg_colum;
        private System.Windows.Forms.Panel p_addReport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_State;
        private System.Windows.Forms.RichTextBox rtb_colums;
        private System.Windows.Forms.RichTextBox rtb_columsNote;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_database;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_tables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_confirm;
    }
}

