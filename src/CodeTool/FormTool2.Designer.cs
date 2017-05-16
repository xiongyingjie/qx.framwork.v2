using CodeTool.Helper;

namespace CodeTool
{
    partial class FormTool2:BaseDbForm
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
            this.gp_addReport = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtb_output = new System.Windows.Forms.RichTextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.cb_connString = new System.Windows.Forms.ComboBox();
            this.bt_submit = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.bt_check = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rtb_colum = new System.Windows.Forms.RichTextBox();
            this.rtb_display = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_form_name = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.columToShow = new System.Windows.Forms.Label();
            this.tb_perCount = new System.Windows.Forms.TextBox();
            this.tb_key_info = new System.Windows.Forms.TextBox();
            this.tb_columToShow = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_form_Id = new System.Windows.Forms.TextBox();
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
            this.label11 = new System.Windows.Forms.Label();
            this.rtb_control_type = new System.Windows.Forms.RichTextBox();
            this.rtb_regex = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gp_addReport.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // gp_addReport
            // 
            this.gp_addReport.Controls.Add(this.label3);
            this.gp_addReport.Controls.Add(this.rtb_output);
            this.gp_addReport.Controls.Add(this.groupBox12);
            this.gp_addReport.Controls.Add(this.groupBox5);
            this.gp_addReport.Controls.Add(this.tb_form_Id);
            this.gp_addReport.Location = new System.Drawing.Point(9, 375);
            this.gp_addReport.Name = "gp_addReport";
            this.gp_addReport.Size = new System.Drawing.Size(783, 362);
            this.gp_addReport.TabIndex = 18;
            this.gp_addReport.TabStop = false;
            this.gp_addReport.Text = "4.检查配置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "output preview";
            // 
            // rtb_output
            // 
            this.rtb_output.Location = new System.Drawing.Point(19, 228);
            this.rtb_output.Name = "rtb_output";
            this.rtb_output.Size = new System.Drawing.Size(531, 112);
            this.rtb_output.TabIndex = 2;
            this.rtb_output.Text = "";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.cb_connString);
            this.groupBox12.Controls.Add(this.bt_submit);
            this.groupBox12.Controls.Add(this.label9);
            this.groupBox12.Controls.Add(this.bt_check);
            this.groupBox12.Location = new System.Drawing.Point(579, 211);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(187, 135);
            this.groupBox12.TabIndex = 13;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "5.测试";
            // 
            // cb_connString
            // 
            this.cb_connString.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_connString.FormattingEnabled = true;
            this.cb_connString.Location = new System.Drawing.Point(56, 30);
            this.cb_connString.Name = "cb_connString";
            this.cb_connString.Size = new System.Drawing.Size(113, 20);
            this.cb_connString.TabIndex = 12;
            // 
            // bt_submit
            // 
            this.bt_submit.Location = new System.Drawing.Point(94, 61);
            this.bt_submit.Name = "bt_submit";
            this.bt_submit.Size = new System.Drawing.Size(81, 59);
            this.bt_submit.TabIndex = 9;
            this.bt_submit.Text = "7.提交";
            this.bt_submit.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "数据源";
            // 
            // bt_check
            // 
            this.bt_check.Location = new System.Drawing.Point(10, 61);
            this.bt_check.Name = "bt_check";
            this.bt_check.Size = new System.Drawing.Size(75, 59);
            this.bt_check.TabIndex = 11;
            this.bt_check.Text = "6.检查";
            this.bt_check.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rtb_regex);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.rtb_colum);
            this.groupBox5.Controls.Add(this.rtb_control_type);
            this.groupBox5.Controls.Add(this.rtb_display);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.tb_form_name);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.columToShow);
            this.groupBox5.Controls.Add(this.tb_perCount);
            this.groupBox5.Controls.Add(this.tb_key_info);
            this.groupBox5.Controls.Add(this.tb_columToShow);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(6, 34);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(760, 323);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "基本配置";
            // 
            // rtb_colum
            // 
            this.rtb_colum.Location = new System.Drawing.Point(13, 81);
            this.rtb_colum.Name = "rtb_colum";
            this.rtb_colum.Size = new System.Drawing.Size(167, 81);
            this.rtb_colum.TabIndex = 2;
            this.rtb_colum.Text = "";
            // 
            // rtb_display
            // 
            this.rtb_display.Location = new System.Drawing.Point(197, 81);
            this.rtb_display.Name = "rtb_display";
            this.rtb_display.Size = new System.Drawing.Size(167, 81);
            this.rtb_display.TabIndex = 2;
            this.rtb_display.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "colum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "display";
            // 
            // tb_form_name
            // 
            this.tb_form_name.Location = new System.Drawing.Point(57, 28);
            this.tb_form_name.Name = "tb_form_name";
            this.tb_form_name.Size = new System.Drawing.Size(123, 21);
            this.tb_form_name.TabIndex = 0;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(422, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "key_info";
            // 
            // columToShow
            // 
            this.columToShow.AutoSize = true;
            this.columToShow.Location = new System.Drawing.Point(197, 34);
            this.columToShow.Name = "columToShow";
            this.columToShow.Size = new System.Drawing.Size(71, 12);
            this.columToShow.TabIndex = 1;
            this.columToShow.Text = "columToShow";
            // 
            // tb_perCount
            // 
            this.tb_perCount.Location = new System.Drawing.Point(696, 28);
            this.tb_perCount.Name = "tb_perCount";
            this.tb_perCount.Size = new System.Drawing.Size(52, 21);
            this.tb_perCount.TabIndex = 0;
            this.tb_perCount.Text = "10";
            // 
            // tb_key_info
            // 
            this.tb_key_info.Location = new System.Drawing.Point(481, 27);
            this.tb_key_info.Name = "tb_key_info";
            this.tb_key_info.Size = new System.Drawing.Size(133, 21);
            this.tb_key_info.TabIndex = 0;
            // 
            // tb_columToShow
            // 
            this.tb_columToShow.Location = new System.Drawing.Point(277, 26);
            this.tb_columToShow.Name = "tb_columToShow";
            this.tb_columToShow.Size = new System.Drawing.Size(118, 21);
            this.tb_columToShow.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "name";
            // 
            // tb_form_Id
            // 
            this.tb_form_Id.Location = new System.Drawing.Point(108, 20);
            this.tb_form_Id.Name = "tb_form_Id";
            this.tb_form_Id.ReadOnly = true;
            this.tb_form_Id.Size = new System.Drawing.Size(137, 21);
            this.tb_form_Id.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lv_preview);
            this.groupBox7.Location = new System.Drawing.Point(807, 540);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(464, 196);
            this.groupBox7.TabIndex = 19;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "调试窗口";
            // 
            // lv_preview
            // 
            this.lv_preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_preview.Location = new System.Drawing.Point(3, 17);
            this.lv_preview.Name = "lv_preview";
            this.lv_preview.Size = new System.Drawing.Size(458, 176);
            this.lv_preview.TabIndex = 0;
            this.lv_preview.UseCompatibleStateImageBehavior = false;
            // 
            // p_addReport
            // 
            this.p_addReport.Controls.Add(this.groupBox1);
            this.p_addReport.Controls.Add(this.groupBox2);
            this.p_addReport.Controls.Add(this.groupBox6);
            this.p_addReport.Location = new System.Drawing.Point(7, 7);
            this.p_addReport.Name = "p_addReport";
            this.p_addReport.Size = new System.Drawing.Size(785, 362);
            this.p_addReport.TabIndex = 20;
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
            this.groupBox2.Text = "2.配置字段  (w上移，s下移,a显示，d隐藏,e编辑说明)";
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
            this.lv_colums.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lv_colums_KeyDown);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_State});
            this.statusStrip1.Location = new System.Drawing.Point(0, 742);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1297, 22);
            this.statusStrip1.TabIndex = 22;
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
            this.p_manageReport.Location = new System.Drawing.Point(798, 9);
            this.p_manageReport.Name = "p_manageReport";
            this.p_manageReport.Size = new System.Drawing.Size(492, 521);
            this.p_manageReport.TabIndex = 21;
            // 
            // gp_manageReport
            // 
            this.gp_manageReport.Controls.Add(this.groupBox11);
            this.gp_manageReport.Controls.Add(this.groupBox10);
            this.gp_manageReport.Controls.Add(this.groupBox8);
            this.gp_manageReport.Location = new System.Drawing.Point(9, 11);
            this.gp_manageReport.Name = "gp_manageReport";
            this.gp_manageReport.Size = new System.Drawing.Size(476, 503);
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
            this.groupBox11.Location = new System.Drawing.Point(8, 434);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(455, 62);
            this.groupBox11.TabIndex = 15;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "报表操作";
            // 
            // bt_copy
            // 
            this.bt_copy.Location = new System.Drawing.Point(271, 27);
            this.bt_copy.Name = "bt_copy";
            this.bt_copy.Size = new System.Drawing.Size(75, 23);
            this.bt_copy.TabIndex = 15;
            this.bt_copy.Text = "复制";
            this.bt_copy.UseVisualStyleBackColor = true;
            // 
            // bt_dubeg
            // 
            this.bt_dubeg.Location = new System.Drawing.Point(102, 27);
            this.bt_dubeg.Name = "bt_dubeg";
            this.bt_dubeg.Size = new System.Drawing.Size(75, 23);
            this.bt_dubeg.TabIndex = 15;
            this.bt_dubeg.Text = "调试";
            this.bt_dubeg.UseVisualStyleBackColor = true;
            // 
            // bt_edit
            // 
            this.bt_edit.Location = new System.Drawing.Point(186, 27);
            this.bt_edit.Name = "bt_edit";
            this.bt_edit.Size = new System.Drawing.Size(75, 23);
            this.bt_edit.TabIndex = 15;
            this.bt_edit.Text = "编辑";
            this.bt_edit.UseVisualStyleBackColor = true;
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(16, 27);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 15;
            this.bt_add.Text = "添加";
            this.bt_add.UseVisualStyleBackColor = true;
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(360, 27);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 15;
            this.bt_delete.Text = "删除";
            this.bt_delete.UseVisualStyleBackColor = true;
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
            this.groupBox10.Size = new System.Drawing.Size(455, 88);
            this.groupBox10.TabIndex = 14;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "查询条件";
            // 
            // bt_query
            // 
            this.bt_query.Location = new System.Drawing.Point(357, 20);
            this.bt_query.Name = "bt_query";
            this.bt_query.Size = new System.Drawing.Size(75, 52);
            this.bt_query.TabIndex = 15;
            this.bt_query.Text = "查询";
            this.bt_query.UseVisualStyleBackColor = true;
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
            this.tb_queryReportName.Size = new System.Drawing.Size(270, 21);
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
            this.tb_queryReportId.Size = new System.Drawing.Size(271, 21);
            this.tb_queryReportId.TabIndex = 13;
            this.tb_queryReportId.Text = "%";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lv_reports);
            this.groupBox8.Location = new System.Drawing.Point(6, 114);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(464, 314);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "查询结果";
            // 
            // lv_reports
            // 
            this.lv_reports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_reports.Location = new System.Drawing.Point(3, 17);
            this.lv_reports.Name = "lv_reports";
            this.lv_reports.Size = new System.Drawing.Size(458, 294);
            this.lv_reports.TabIndex = 0;
            this.lv_reports.UseCompatibleStateImageBehavior = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(378, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "control_type";
            // 
            // rtb_control_type
            // 
            this.rtb_control_type.Location = new System.Drawing.Point(380, 81);
            this.rtb_control_type.Name = "rtb_control_type";
            this.rtb_control_type.Size = new System.Drawing.Size(167, 81);
            this.rtb_control_type.TabIndex = 2;
            this.rtb_control_type.Text = "";
            // 
            // rtb_regex
            // 
            this.rtb_regex.Location = new System.Drawing.Point(566, 79);
            this.rtb_regex.Name = "rtb_regex";
            this.rtb_regex.Size = new System.Drawing.Size(167, 81);
            this.rtb_regex.TabIndex = 4;
            this.rtb_regex.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(567, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "regex";
            // 
            // FormTool2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 764);
            this.Controls.Add(this.gp_addReport);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.p_addReport);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.p_manageReport);
            this.Name = "FormTool2";
            this.Text = "FormTool2";
            this.Load += new System.EventHandler(this.FormTool2_Load);
            this.gp_addReport.ResumeLayout(false);
            this.gp_addReport.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_reports;
        private System.Windows.Forms.Button bt_query;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_queryReportName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtb_output;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.ComboBox cb_connString;
        private System.Windows.Forms.Button bt_submit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bt_check;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox rtb_colum;
        private System.Windows.Forms.RichTextBox rtb_display;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_form_name;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label columToShow;
        private System.Windows.Forms.TextBox tb_perCount;
        private System.Windows.Forms.TextBox tb_key_info;
        private System.Windows.Forms.TextBox tb_columToShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gp_addReport;
        private System.Windows.Forms.TextBox tb_form_Id;
        private System.Windows.Forms.TextBox tb_queryReportId;
        private System.Windows.Forms.ListView lv_colums;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListView lv_preview;
        private System.Windows.Forms.Panel p_addReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tv_dataBase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PropertyGrid pg_colum;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_State;
        private System.Windows.Forms.Panel p_manageReport;
        private System.Windows.Forms.GroupBox gp_manageReport;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button bt_copy;
        private System.Windows.Forms.Button bt_dubeg;
        private System.Windows.Forms.Button bt_edit;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RichTextBox rtb_regex;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox rtb_control_type;
        private System.Windows.Forms.Label label11;
    }
}