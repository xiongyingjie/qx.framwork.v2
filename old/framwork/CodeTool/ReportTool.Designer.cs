
using xyj.tool.Helper;

namespace xyj.tool
{
    partial class ReportTool: BaseDbForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportTool));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lv_preview = new System.Windows.Forms.ListView();
            this.p_addReport = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tv_dataBase = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_colums = new System.Windows.Forms.ListView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pg_colum = new System.Windows.Forms.PropertyGrid();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_State = new System.Windows.Forms.ToolStripStatusLabel();
            this.p_manageReport = new System.Windows.Forms.Panel();
            this.gp_manageReport = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.bt_copy = new System.Windows.Forms.Button();
            this.bt_dubeg = new System.Windows.Forms.Button();
            this.bt_edit = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.bt_query = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_queryReportName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_queryReportId = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lv_reports = new System.Windows.Forms.ListView();
            this.gp_addReport = new System.Windows.Forms.GroupBox();
            this.rtb_sql = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ck_deletes = new System.Windows.Forms.CheckBox();
            this.ck_detail = new System.Windows.Forms.CheckBox();
            this.ck_delete = new System.Windows.Forms.CheckBox();
            this.ck_update = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtb_headears = new System.Windows.Forms.RichTextBox();
            this.tb_deafultParam = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rtb_oprate = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_help = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_reportName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_perCount = new System.Windows.Forms.TextBox();
            this.tb_columToShow = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_reportId = new System.Windows.Forms.TextBox();
            this.tb_menu_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.pl_auto_menu = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_target_role = new System.Windows.Forms.ComboBox();
            this.cb_controller = new System.Windows.Forms.ComboBox();
            this.cb_area = new System.Windows.Forms.ComboBox();
            this.cb_root_menu = new System.Windows.Forms.ComboBox();
            this.Lable111 = new System.Windows.Forms.Label();
            this.tb_action = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ck_auto_menu = new System.Windows.Forms.CheckBox();
            this.ck_autocode = new System.Windows.Forms.CheckBox();
            this.cb_connString = new System.Windows.Forms.ComboBox();
            this.bt_submit = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_check = new System.Windows.Forms.Button();
            this.groupBox7.SuspendLayout();
            this.p_addReport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.p_manageReport.SuspendLayout();
            this.gp_manageReport.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.gp_addReport.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.pl_auto_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lv_preview);
            this.groupBox7.Location = new System.Drawing.Point(798, 367);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(363, 152);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "调试窗口";
            // 
            // lv_preview
            // 
            this.lv_preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_preview.Location = new System.Drawing.Point(3, 17);
            this.lv_preview.Name = "lv_preview";
            this.lv_preview.Size = new System.Drawing.Size(357, 132);
            this.lv_preview.TabIndex = 0;
            this.lv_preview.UseCompatibleStateImageBehavior = false;
            // 
            // p_addReport
            // 
            this.p_addReport.Controls.Add(this.groupBox1);
            this.p_addReport.Controls.Add(this.groupBox2);
            this.p_addReport.Controls.Add(this.groupBox6);
            this.p_addReport.Location = new System.Drawing.Point(2, -4);
            this.p_addReport.Name = "p_addReport";
            this.p_addReport.Size = new System.Drawing.Size(785, 362);
            this.p_addReport.TabIndex = 15;
            this.p_addReport.Click += new System.EventHandler(this.p_addReport_Click);
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
            this.groupBox2.Size = new System.Drawing.Size(389, 343);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2.配置字段  (w上移，s下移,a隐藏，d显示,e编辑说明,q查询条件)";
            // 
            // lv_colums
            // 
            this.lv_colums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_colums.HoverSelection = true;
            this.lv_colums.Location = new System.Drawing.Point(3, 17);
            this.lv_colums.Name = "lv_colums";
            this.lv_colums.Size = new System.Drawing.Size(383, 323);
            this.lv_colums.TabIndex = 0;
            this.lv_colums.UseCompatibleStateImageBehavior = false;
            this.lv_colums.SelectedIndexChanged += new System.EventHandler(this.lv_colums_SelectedIndexChanged);
            this.lv_colums.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lv_colums_KeyDown);
            this.lv_colums.Leave += new System.EventHandler(this.lv_colums_Leave);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pg_colum);
            this.groupBox6.Location = new System.Drawing.Point(613, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(169, 340);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "3.编辑字段属性";
            // 
            // pg_colum
            // 
            this.pg_colum.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pg_colum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg_colum.LineColor = System.Drawing.SystemColors.ControlDark;
            this.pg_colum.Location = new System.Drawing.Point(3, 17);
            this.pg_colum.Name = "pg_colum";
            this.pg_colum.Size = new System.Drawing.Size(163, 320);
            this.pg_colum.TabIndex = 0;
            this.pg_colum.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pg_colum_PropertyValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_State});
            this.statusStrip1.Location = new System.Drawing.Point(0, 687);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1167, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_State
            // 
            this.tssl_State.Name = "tssl_State";
            this.tssl_State.Size = new System.Drawing.Size(61, 17);
            this.tssl_State.Text = "tssl_State";
            // 
            // p_manageReport
            // 
            this.p_manageReport.Controls.Add(this.gp_manageReport);
            this.p_manageReport.Location = new System.Drawing.Point(791, -8);
            this.p_manageReport.Name = "p_manageReport";
            this.p_manageReport.Size = new System.Drawing.Size(363, 366);
            this.p_manageReport.TabIndex = 16;
            this.p_manageReport.Click += new System.EventHandler(this.p_manageReport_Click);
            // 
            // gp_manageReport
            // 
            this.gp_manageReport.Controls.Add(this.groupBox11);
            this.gp_manageReport.Controls.Add(this.groupBox10);
            this.gp_manageReport.Controls.Add(this.groupBox8);
            this.gp_manageReport.Location = new System.Drawing.Point(9, 11);
            this.gp_manageReport.Name = "gp_manageReport";
            this.gp_manageReport.Size = new System.Drawing.Size(346, 347);
            this.gp_manageReport.TabIndex = 14;
            this.gp_manageReport.TabStop = false;
            this.gp_manageReport.Text = "报表管理";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.bt_copy);
            this.groupBox11.Controls.Add(this.bt_dubeg);
            this.groupBox11.Controls.Add(this.bt_edit);
            this.groupBox11.Controls.Add(this.bt_add);
            this.groupBox11.Controls.Add(this.bt_delete);
            this.groupBox11.Location = new System.Drawing.Point(9, 263);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(326, 76);
            this.groupBox11.TabIndex = 15;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "报表操作";
            // 
            // bt_copy
            // 
            this.bt_copy.Location = new System.Drawing.Point(221, 47);
            this.bt_copy.Name = "bt_copy";
            this.bt_copy.Size = new System.Drawing.Size(75, 23);
            this.bt_copy.TabIndex = 15;
            this.bt_copy.Text = "复制";
            this.bt_copy.UseVisualStyleBackColor = true;
            this.bt_copy.Click += new System.EventHandler(this.bt_copy_Click);
            // 
            // bt_dubeg
            // 
            this.bt_dubeg.Location = new System.Drawing.Point(121, 18);
            this.bt_dubeg.Name = "bt_dubeg";
            this.bt_dubeg.Size = new System.Drawing.Size(75, 23);
            this.bt_dubeg.TabIndex = 15;
            this.bt_dubeg.Text = "调试";
            this.bt_dubeg.UseVisualStyleBackColor = true;
            this.bt_dubeg.Click += new System.EventHandler(this.bt_dubeg_Click);
            // 
            // bt_edit
            // 
            this.bt_edit.Location = new System.Drawing.Point(121, 47);
            this.bt_edit.Name = "bt_edit";
            this.bt_edit.Size = new System.Drawing.Size(75, 23);
            this.bt_edit.TabIndex = 15;
            this.bt_edit.Text = "编辑";
            this.bt_edit.UseVisualStyleBackColor = true;
            this.bt_edit.Click += new System.EventHandler(this.bt_edit_Click);
            // 
            // bt_add
            // 
            this.bt_add.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.bt_add.Location = new System.Drawing.Point(16, 18);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 52);
            this.bt_add.TabIndex = 15;
            this.bt_add.Text = "添加";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(221, 19);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 15;
            this.bt_delete.Text = "删除";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.bt_query);
            this.groupBox10.Controls.Add(this.label7);
            this.groupBox10.Controls.Add(this.tb_queryReportName);
            this.groupBox10.Controls.Add(this.label6);
            this.groupBox10.Controls.Add(this.tb_queryReportId);
            this.groupBox10.Location = new System.Drawing.Point(8, 20);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(330, 88);
            this.groupBox10.TabIndex = 14;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "查询条件";
            // 
            // bt_query
            // 
            this.bt_query.Location = new System.Drawing.Point(240, 20);
            this.bt_query.Name = "bt_query";
            this.bt_query.Size = new System.Drawing.Size(75, 52);
            this.bt_query.TabIndex = 15;
            this.bt_query.Text = "查询";
            this.bt_query.UseVisualStyleBackColor = true;
            this.bt_query.Click += new System.EventHandler(this.bt_query_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "报表名称";
            // 
            // tb_queryReportName
            // 
            this.tb_queryReportName.Location = new System.Drawing.Point(62, 51);
            this.tb_queryReportName.Name = "tb_queryReportName";
            this.tb_queryReportName.Size = new System.Drawing.Size(150, 21);
            this.tb_queryReportName.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "报表id";
            // 
            // tb_queryReportId
            // 
            this.tb_queryReportId.Location = new System.Drawing.Point(61, 20);
            this.tb_queryReportId.Name = "tb_queryReportId";
            this.tb_queryReportId.Size = new System.Drawing.Size(151, 21);
            this.tb_queryReportId.TabIndex = 13;
            this.tb_queryReportId.Text = "%";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lv_reports);
            this.groupBox8.Location = new System.Drawing.Point(6, 114);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(332, 143);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "查询结果";
            // 
            // lv_reports
            // 
            this.lv_reports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_reports.Location = new System.Drawing.Point(3, 17);
            this.lv_reports.Name = "lv_reports";
            this.lv_reports.Size = new System.Drawing.Size(326, 123);
            this.lv_reports.TabIndex = 0;
            this.lv_reports.UseCompatibleStateImageBehavior = false;
            // 
            // gp_addReport
            // 
            this.gp_addReport.Controls.Add(this.rtb_sql);
            this.gp_addReport.Controls.Add(this.groupBox5);
            this.gp_addReport.Controls.Add(this.tb_reportId);
            this.gp_addReport.Location = new System.Drawing.Point(5, 360);
            this.gp_addReport.Name = "gp_addReport";
            this.gp_addReport.Size = new System.Drawing.Size(783, 324);
            this.gp_addReport.TabIndex = 4;
            this.gp_addReport.TabStop = false;
            // 
            // rtb_sql
            // 
            this.rtb_sql.Location = new System.Drawing.Point(63, 198);
            this.rtb_sql.Name = "rtb_sql";
            this.rtb_sql.Size = new System.Drawing.Size(708, 114);
            this.rtb_sql.TabIndex = 2;
            this.rtb_sql.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ck_deletes);
            this.groupBox5.Controls.Add(this.ck_detail);
            this.groupBox5.Controls.Add(this.ck_delete);
            this.groupBox5.Controls.Add(this.ck_update);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.rtb_headears);
            this.groupBox5.Controls.Add(this.tb_deafultParam);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.rtb_oprate);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.lb_help);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.tb_reportName);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.tb_perCount);
            this.groupBox5.Controls.Add(this.tb_columToShow);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(6, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(771, 302);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "4.检查报表配置";
            // 
            // ck_deletes
            // 
            this.ck_deletes.AutoSize = true;
            this.ck_deletes.Location = new System.Drawing.Point(694, 59);
            this.ck_deletes.Name = "ck_deletes";
            this.ck_deletes.Size = new System.Drawing.Size(72, 16);
            this.ck_deletes.TabIndex = 13;
            this.ck_deletes.Text = "批量删除";
            this.ck_deletes.UseVisualStyleBackColor = true;
            // 
            // ck_detail
            // 
            this.ck_detail.AutoSize = true;
            this.ck_detail.Location = new System.Drawing.Point(545, 59);
            this.ck_detail.Name = "ck_detail";
            this.ck_detail.Size = new System.Drawing.Size(48, 16);
            this.ck_detail.TabIndex = 13;
            this.ck_detail.Text = "详情";
            this.ck_detail.UseVisualStyleBackColor = true;
            this.ck_detail.CheckedChanged += new System.EventHandler(this.ck_detail_CheckedChanged);
            // 
            // ck_delete
            // 
            this.ck_delete.AutoSize = true;
            this.ck_delete.Location = new System.Drawing.Point(644, 59);
            this.ck_delete.Name = "ck_delete";
            this.ck_delete.Size = new System.Drawing.Size(48, 16);
            this.ck_delete.TabIndex = 13;
            this.ck_delete.Text = "删除";
            this.ck_delete.UseVisualStyleBackColor = true;
            this.ck_delete.CheckedChanged += new System.EventHandler(this.ck_delete_CheckedChanged);
            // 
            // ck_update
            // 
            this.ck_update.AutoSize = true;
            this.ck_update.Location = new System.Drawing.Point(596, 59);
            this.ck_update.Name = "ck_update";
            this.ck_update.Size = new System.Drawing.Size(48, 16);
            this.ck_update.TabIndex = 13;
            this.ck_update.Text = "编辑";
            this.ck_update.UseVisualStyleBackColor = true;
            this.ck_update.CheckedChanged += new System.EventHandler(this.ck_update_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Sql预览";
            // 
            // rtb_headears
            // 
            this.rtb_headears.Location = new System.Drawing.Point(58, 59);
            this.rtb_headears.Name = "rtb_headears";
            this.rtb_headears.Size = new System.Drawing.Size(350, 117);
            this.rtb_headears.TabIndex = 2;
            this.rtb_headears.Text = "";
            // 
            // tb_deafultParam
            // 
            this.tb_deafultParam.Location = new System.Drawing.Point(491, 26);
            this.tb_deafultParam.Name = "tb_deafultParam";
            this.tb_deafultParam.Size = new System.Drawing.Size(111, 21);
            this.tb_deafultParam.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(432, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "查询条件";
            // 
            // rtb_oprate
            // 
            this.rtb_oprate.Location = new System.Drawing.Point(424, 80);
            this.rtb_oprate.Name = "rtb_oprate";
            this.rtb_oprate.Size = new System.Drawing.Size(341, 96);
            this.rtb_oprate.TabIndex = 2;
            this.rtb_oprate.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "标题集合";
            // 
            // lb_help
            // 
            this.lb_help.AutoSize = true;
            this.lb_help.ForeColor = System.Drawing.Color.OrangeRed;
            this.lb_help.Location = new System.Drawing.Point(479, 61);
            this.lb_help.Name = "lb_help";
            this.lb_help.Size = new System.Drawing.Size(47, 12);
            this.lb_help.TabIndex = 1;
            this.lb_help.Text = "(help?)";
            this.lb_help.Click += new System.EventHandler(this.lb_help_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(423, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "操作配置";
            // 
            // tb_reportName
            // 
            this.tb_reportName.Location = new System.Drawing.Point(59, 28);
            this.tb_reportName.Name = "tb_reportName";
            this.tb_reportName.Size = new System.Drawing.Size(123, 21);
            this.tb_reportName.TabIndex = 0;
            this.tb_reportName.TextChanged += new System.EventHandler(this.tb_reportName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(629, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "每页条数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "要显示的索引集";
            // 
            // tb_perCount
            // 
            this.tb_perCount.Location = new System.Drawing.Point(696, 28);
            this.tb_perCount.Name = "tb_perCount";
            this.tb_perCount.Size = new System.Drawing.Size(69, 21);
            this.tb_perCount.TabIndex = 0;
            this.tb_perCount.Text = "10";
            // 
            // tb_columToShow
            // 
            this.tb_columToShow.Location = new System.Drawing.Point(289, 26);
            this.tb_columToShow.Name = "tb_columToShow";
            this.tb_columToShow.Size = new System.Drawing.Size(118, 21);
            this.tb_columToShow.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "名称";
            // 
            // tb_reportId
            // 
            this.tb_reportId.Location = new System.Drawing.Point(108, 20);
            this.tb_reportId.Name = "tb_reportId";
            this.tb_reportId.ReadOnly = true;
            this.tb_reportId.Size = new System.Drawing.Size(137, 21);
            this.tb_reportId.TabIndex = 0;
            // 
            // tb_menu_name
            // 
            this.tb_menu_name.Location = new System.Drawing.Point(1271, 466);
            this.tb_menu_name.Name = "tb_menu_name";
            this.tb_menu_name.Size = new System.Drawing.Size(111, 21);
            this.tb_menu_name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1216, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "菜单名称";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.pl_auto_menu);
            this.groupBox12.Controls.Add(this.ck_auto_menu);
            this.groupBox12.Controls.Add(this.ck_autocode);
            this.groupBox12.Controls.Add(this.cb_connString);
            this.groupBox12.Controls.Add(this.bt_submit);
            this.groupBox12.Controls.Add(this.label9);
            this.groupBox12.Controls.Add(this.bt_exit);
            this.groupBox12.Controls.Add(this.bt_check);
            this.groupBox12.Location = new System.Drawing.Point(799, 526);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(362, 155);
            this.groupBox12.TabIndex = 13;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "5.测试";
            // 
            // pl_auto_menu
            // 
            this.pl_auto_menu.Controls.Add(this.label11);
            this.pl_auto_menu.Controls.Add(this.cb_target_role);
            this.pl_auto_menu.Controls.Add(this.cb_controller);
            this.pl_auto_menu.Controls.Add(this.cb_area);
            this.pl_auto_menu.Controls.Add(this.cb_root_menu);
            this.pl_auto_menu.Controls.Add(this.Lable111);
            this.pl_auto_menu.Controls.Add(this.tb_action);
            this.pl_auto_menu.Controls.Add(this.label12);
            this.pl_auto_menu.Enabled = false;
            this.pl_auto_menu.Location = new System.Drawing.Point(4, 69);
            this.pl_auto_menu.Name = "pl_auto_menu";
            this.pl_auto_menu.Size = new System.Drawing.Size(352, 82);
            this.pl_auto_menu.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "上级菜单";
            // 
            // cb_target_role
            // 
            this.cb_target_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_target_role.FormattingEnabled = true;
            this.cb_target_role.Location = new System.Drawing.Point(58, 59);
            this.cb_target_role.Name = "cb_target_role";
            this.cb_target_role.Size = new System.Drawing.Size(284, 20);
            this.cb_target_role.TabIndex = 12;
            // 
            // cb_controller
            // 
            this.cb_controller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_controller.FormattingEnabled = true;
            this.cb_controller.Location = new System.Drawing.Point(169, 35);
            this.cb_controller.Name = "cb_controller";
            this.cb_controller.Size = new System.Drawing.Size(86, 20);
            this.cb_controller.TabIndex = 12;
            // 
            // cb_area
            // 
            this.cb_area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_area.FormattingEnabled = true;
            this.cb_area.Location = new System.Drawing.Point(59, 35);
            this.cb_area.Name = "cb_area";
            this.cb_area.Size = new System.Drawing.Size(106, 20);
            this.cb_area.TabIndex = 12;
            this.cb_area.SelectedIndexChanged += new System.EventHandler(this.cb_area_SelectedIndexChanged);
            // 
            // cb_root_menu
            // 
            this.cb_root_menu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_root_menu.FormattingEnabled = true;
            this.cb_root_menu.Location = new System.Drawing.Point(58, 6);
            this.cb_root_menu.Name = "cb_root_menu";
            this.cb_root_menu.Size = new System.Drawing.Size(285, 20);
            this.cb_root_menu.TabIndex = 12;
            // 
            // Lable111
            // 
            this.Lable111.AutoSize = true;
            this.Lable111.Location = new System.Drawing.Point(3, 65);
            this.Lable111.Name = "Lable111";
            this.Lable111.Size = new System.Drawing.Size(53, 12);
            this.Lable111.TabIndex = 1;
            this.Lable111.Text = "目标角色";
            // 
            // tb_action
            // 
            this.tb_action.Location = new System.Drawing.Point(259, 34);
            this.tb_action.Name = "tb_action";
            this.tb_action.Size = new System.Drawing.Size(83, 21);
            this.tb_action.TabIndex = 0;
            this.tb_action.TextChanged += new System.EventHandler(this.tb_action_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "跳转目标";
            // 
            // ck_auto_menu
            // 
            this.ck_auto_menu.AutoSize = true;
            this.ck_auto_menu.Location = new System.Drawing.Point(97, 46);
            this.ck_auto_menu.Name = "ck_auto_menu";
            this.ck_auto_menu.Size = new System.Drawing.Size(72, 16);
            this.ck_auto_menu.TabIndex = 13;
            this.ck_auto_menu.Text = "生成菜单";
            this.ck_auto_menu.UseVisualStyleBackColor = true;
            this.ck_auto_menu.CheckedChanged += new System.EventHandler(this.ck_auto_menu_CheckedChanged);
            // 
            // ck_autocode
            // 
            this.ck_autocode.AutoSize = true;
            this.ck_autocode.Location = new System.Drawing.Point(9, 46);
            this.ck_autocode.Name = "ck_autocode";
            this.ck_autocode.Size = new System.Drawing.Size(72, 16);
            this.ck_autocode.TabIndex = 13;
            this.ck_autocode.Text = "生成代码";
            this.ck_autocode.UseVisualStyleBackColor = true;
            this.ck_autocode.CheckedChanged += new System.EventHandler(this.ck_autocode_CheckedChanged);
            // 
            // cb_connString
            // 
            this.cb_connString.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_connString.FormattingEnabled = true;
            this.cb_connString.Location = new System.Drawing.Point(55, 14);
            this.cb_connString.Name = "cb_connString";
            this.cb_connString.Size = new System.Drawing.Size(118, 20);
            this.cb_connString.TabIndex = 12;
            // 
            // bt_submit
            // 
            this.bt_submit.Location = new System.Drawing.Point(246, 14);
            this.bt_submit.Name = "bt_submit";
            this.bt_submit.Size = new System.Drawing.Size(50, 48);
            this.bt_submit.TabIndex = 9;
            this.bt_submit.Text = "7.提交";
            this.bt_submit.UseVisualStyleBackColor = true;
            this.bt_submit.Click += new System.EventHandler(this.button3_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "数据源";
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(303, 14);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(49, 48);
            this.bt_exit.TabIndex = 11;
            this.bt_exit.Text = "关闭";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_check
            // 
            this.bt_check.Location = new System.Drawing.Point(189, 14);
            this.bt_check.Name = "bt_check";
            this.bt_check.Size = new System.Drawing.Size(49, 48);
            this.bt_check.TabIndex = 11;
            this.bt_check.Text = "6.检查";
            this.bt_check.UseVisualStyleBackColor = true;
            this.bt_check.Click += new System.EventHandler(this.bt_check_Click);
            // 
            // ReportTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 709);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.p_addReport);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.p_manageReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gp_addReport);
            this.Controls.Add(this.tb_menu_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReportTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报表生成器2.0.0.0";
            this.Load += new System.EventHandler(this.ReportTool_Load);
            this.groupBox7.ResumeLayout(false);
            this.p_addReport.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.p_manageReport.ResumeLayout(false);
            this.gp_manageReport.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.gp_addReport.ResumeLayout(false);
            this.gp_addReport.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.pl_auto_menu.ResumeLayout(false);
            this.pl_auto_menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tv_dataBase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lv_colums;
        private System.Windows.Forms.GroupBox gp_addReport;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_reportName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_reportId;
        private System.Windows.Forms.TextBox tb_columToShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PropertyGrid pg_colum;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListView lv_preview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_submit;
        private System.Windows.Forms.Button bt_check;
        private System.Windows.Forms.RichTextBox rtb_oprate;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox gp_manageReport;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button bt_copy;
        private System.Windows.Forms.Button bt_dubeg;
        private System.Windows.Forms.Button bt_edit;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button bt_query;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_queryReportName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_queryReportId;
        private System.Windows.Forms.RichTextBox rtb_headears;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_perCount;
        private System.Windows.Forms.RichTextBox rtb_sql;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.ComboBox cb_connString;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView lv_reports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_deafultParam;
        private System.Windows.Forms.Panel p_addReport;
        private System.Windows.Forms.Panel p_manageReport;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_State;
        private System.Windows.Forms.Label lb_help;
        private System.Windows.Forms.CheckBox ck_detail;
        private System.Windows.Forms.CheckBox ck_delete;
        private System.Windows.Forms.CheckBox ck_update;
        private System.Windows.Forms.CheckBox ck_deletes;
        private System.Windows.Forms.CheckBox ck_autocode;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.CheckBox ck_auto_menu;
        private System.Windows.Forms.Panel pl_auto_menu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cb_root_menu;
        private System.Windows.Forms.Label Lable111;
        private System.Windows.Forms.ComboBox cb_target_role;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_menu_name;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cb_controller;
        private System.Windows.Forms.ComboBox cb_area;
        private System.Windows.Forms.TextBox tb_action;
    }
}

