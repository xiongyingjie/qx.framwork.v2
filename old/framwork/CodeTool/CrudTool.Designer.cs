using xyj.tool.Helper;

namespace xyj.tool
{
    partial class CrudTool: BaseDbForm
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
            this.rtb_output = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_colums = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.gp_addReport = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.cb_connString = new System.Windows.Forms.ComboBox();
            this.bt_submit = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rtb_regex = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.rtb_colum = new System.Windows.Forms.RichTextBox();
            this.rtb_control_type = new System.Windows.Forms.RichTextBox();
            this.rtb_display = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_State = new System.Windows.Forms.ToolStripStatusLabel();
            this.p_addReport = new System.Windows.Forms.Panel();
            this.rtb_jsQuery = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tv_dataBase = new System.Windows.Forms.TreeView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pg_colum = new System.Windows.Forms.PropertyGrid();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_check = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.gp_addReport.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.p_manageReport.SuspendLayout();
            this.gp_manageReport.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.p_addReport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb_output
            // 
            this.rtb_output.Location = new System.Drawing.Point(990, 268);
            this.rtb_output.Name = "rtb_output";
            this.rtb_output.Size = new System.Drawing.Size(670, 112);
            this.rtb_output.TabIndex = 24;
            this.rtb_output.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lv_colums);
            this.groupBox2.Location = new System.Drawing.Point(9, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(931, 282);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2.配置字段  (a隐藏,d显示,w上移，s下移,t控件类型,e编辑标签,r设置正则式,q查询类型,f下拉选项)";
            // 
            // lv_colums
            // 
            this.lv_colums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_colums.HoverSelection = true;
            this.lv_colums.Location = new System.Drawing.Point(3, 17);
            this.lv_colums.Name = "lv_colums";
            this.lv_colums.Size = new System.Drawing.Size(925, 262);
            this.lv_colums.TabIndex = 0;
            this.lv_colums.UseCompatibleStateImageBehavior = false;
            this.lv_colums.SelectedIndexChanged += new System.EventHandler(this.lv_colums_SelectedIndexChanged);
            this.lv_colums.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lv_colums_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1032, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "output preview";
            // 
            // gp_addReport
            // 
            this.gp_addReport.Controls.Add(this.groupBox12);
            this.gp_addReport.Controls.Add(this.groupBox5);
            this.gp_addReport.Controls.Add(this.tb_form_Id);
            this.gp_addReport.Location = new System.Drawing.Point(1014, 458);
            this.gp_addReport.Name = "gp_addReport";
            this.gp_addReport.Size = new System.Drawing.Size(783, 354);
            this.gp_addReport.TabIndex = 27;
            this.gp_addReport.TabStop = false;
            this.gp_addReport.Text = "4.检查配置";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.cb_connString);
            this.groupBox12.Controls.Add(this.bt_submit);
            this.groupBox12.Controls.Add(this.label9);
            this.groupBox12.Location = new System.Drawing.Point(579, 209);
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
            this.cb_connString.Location = new System.Drawing.Point(56, 28);
            this.cb_connString.Name = "cb_connString";
            this.cb_connString.Size = new System.Drawing.Size(113, 20);
            this.cb_connString.TabIndex = 12;
            // 
            // bt_submit
            // 
            this.bt_submit.Location = new System.Drawing.Point(94, 59);
            this.bt_submit.Name = "bt_submit";
            this.bt_submit.Size = new System.Drawing.Size(81, 59);
            this.bt_submit.TabIndex = 9;
            this.bt_submit.Text = "7.提交";
            this.bt_submit.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "数据源";
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
            this.groupBox5.Location = new System.Drawing.Point(6, 38);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(760, 323);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "基本配置";
            // 
            // rtb_regex
            // 
            this.rtb_regex.Location = new System.Drawing.Point(566, 77);
            this.rtb_regex.Name = "rtb_regex";
            this.rtb_regex.Size = new System.Drawing.Size(167, 81);
            this.rtb_regex.TabIndex = 4;
            this.rtb_regex.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(567, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "regex";
            // 
            // rtb_colum
            // 
            this.rtb_colum.Location = new System.Drawing.Point(13, 79);
            this.rtb_colum.Name = "rtb_colum";
            this.rtb_colum.Size = new System.Drawing.Size(167, 81);
            this.rtb_colum.TabIndex = 2;
            this.rtb_colum.Text = "";
            // 
            // rtb_control_type
            // 
            this.rtb_control_type.Location = new System.Drawing.Point(380, 79);
            this.rtb_control_type.Name = "rtb_control_type";
            this.rtb_control_type.Size = new System.Drawing.Size(167, 81);
            this.rtb_control_type.TabIndex = 2;
            this.rtb_control_type.Text = "";
            // 
            // rtb_display
            // 
            this.rtb_display.Location = new System.Drawing.Point(197, 79);
            this.rtb_display.Name = "rtb_display";
            this.rtb_display.Size = new System.Drawing.Size(167, 81);
            this.rtb_display.TabIndex = 2;
            this.rtb_display.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(378, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "control_type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "colum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "display";
            // 
            // tb_form_name
            // 
            this.tb_form_name.Location = new System.Drawing.Point(57, 26);
            this.tb_form_name.Name = "tb_form_name";
            this.tb_form_name.Size = new System.Drawing.Size(123, 21);
            this.tb_form_name.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(629, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "每页条数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(422, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "key_info";
            // 
            // columToShow
            // 
            this.columToShow.AutoSize = true;
            this.columToShow.Location = new System.Drawing.Point(197, 32);
            this.columToShow.Name = "columToShow";
            this.columToShow.Size = new System.Drawing.Size(71, 12);
            this.columToShow.TabIndex = 1;
            this.columToShow.Text = "columToShow";
            // 
            // tb_perCount
            // 
            this.tb_perCount.Location = new System.Drawing.Point(696, 26);
            this.tb_perCount.Name = "tb_perCount";
            this.tb_perCount.Size = new System.Drawing.Size(52, 21);
            this.tb_perCount.TabIndex = 0;
            this.tb_perCount.Text = "10";
            // 
            // tb_key_info
            // 
            this.tb_key_info.Location = new System.Drawing.Point(481, 25);
            this.tb_key_info.Name = "tb_key_info";
            this.tb_key_info.Size = new System.Drawing.Size(133, 21);
            this.tb_key_info.TabIndex = 0;
            // 
            // tb_columToShow
            // 
            this.tb_columToShow.Location = new System.Drawing.Point(277, 24);
            this.tb_columToShow.Name = "tb_columToShow";
            this.tb_columToShow.Size = new System.Drawing.Size(118, 21);
            this.tb_columToShow.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "name";
            // 
            // tb_form_Id
            // 
            this.tb_form_Id.Location = new System.Drawing.Point(108, 18);
            this.tb_form_Id.Name = "tb_form_Id";
            this.tb_form_Id.ReadOnly = true;
            this.tb_form_Id.Size = new System.Drawing.Size(137, 21);
            this.tb_form_Id.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lv_preview);
            this.groupBox7.Location = new System.Drawing.Point(1168, 533);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(464, 196);
            this.groupBox7.TabIndex = 28;
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
            // p_manageReport
            // 
            this.p_manageReport.Controls.Add(this.gp_manageReport);
            this.p_manageReport.Location = new System.Drawing.Point(1159, 2);
            this.p_manageReport.Name = "p_manageReport";
            this.p_manageReport.Size = new System.Drawing.Size(492, 521);
            this.p_manageReport.TabIndex = 30;
            // 
            // gp_manageReport
            // 
            this.gp_manageReport.Controls.Add(this.groupBox11);
            this.gp_manageReport.Controls.Add(this.groupBox10);
            this.gp_manageReport.Controls.Add(this.groupBox8);
            this.gp_manageReport.Location = new System.Drawing.Point(9, 4);
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
            this.groupBox11.Location = new System.Drawing.Point(8, 432);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(455, 62);
            this.groupBox11.TabIndex = 15;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "报表操作";
            // 
            // bt_copy
            // 
            this.bt_copy.Location = new System.Drawing.Point(271, 25);
            this.bt_copy.Name = "bt_copy";
            this.bt_copy.Size = new System.Drawing.Size(75, 23);
            this.bt_copy.TabIndex = 15;
            this.bt_copy.Text = "复制";
            this.bt_copy.UseVisualStyleBackColor = true;
            // 
            // bt_dubeg
            // 
            this.bt_dubeg.Location = new System.Drawing.Point(102, 25);
            this.bt_dubeg.Name = "bt_dubeg";
            this.bt_dubeg.Size = new System.Drawing.Size(75, 23);
            this.bt_dubeg.TabIndex = 15;
            this.bt_dubeg.Text = "调试";
            this.bt_dubeg.UseVisualStyleBackColor = true;
            // 
            // bt_edit
            // 
            this.bt_edit.Location = new System.Drawing.Point(186, 25);
            this.bt_edit.Name = "bt_edit";
            this.bt_edit.Size = new System.Drawing.Size(75, 23);
            this.bt_edit.TabIndex = 15;
            this.bt_edit.Text = "编辑";
            this.bt_edit.UseVisualStyleBackColor = true;
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(16, 25);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 15;
            this.bt_add.Text = "添加";
            this.bt_add.UseVisualStyleBackColor = true;
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(360, 25);
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
            this.groupBox10.Location = new System.Drawing.Point(8, 18);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(455, 88);
            this.groupBox10.TabIndex = 14;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "查询条件";
            // 
            // bt_query
            // 
            this.bt_query.Location = new System.Drawing.Point(357, 18);
            this.bt_query.Name = "bt_query";
            this.bt_query.Size = new System.Drawing.Size(75, 52);
            this.bt_query.TabIndex = 15;
            this.bt_query.Text = "查询";
            this.bt_query.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "报表名称";
            // 
            // tb_queryReportName
            // 
            this.tb_queryReportName.Location = new System.Drawing.Point(62, 49);
            this.tb_queryReportName.Name = "tb_queryReportName";
            this.tb_queryReportName.Size = new System.Drawing.Size(270, 21);
            this.tb_queryReportName.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "报表id";
            // 
            // tb_queryReportId
            // 
            this.tb_queryReportId.Location = new System.Drawing.Point(61, 18);
            this.tb_queryReportId.Name = "tb_queryReportId";
            this.tb_queryReportId.Size = new System.Drawing.Size(271, 21);
            this.tb_queryReportId.TabIndex = 13;
            this.tb_queryReportId.Text = "%";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lv_reports);
            this.groupBox8.Location = new System.Drawing.Point(6, 112);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_State});
            this.statusStrip1.Location = new System.Drawing.Point(0, 653);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(945, 22);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_State
            // 
            this.tssl_State.Name = "tssl_State";
            this.tssl_State.Size = new System.Drawing.Size(61, 17);
            this.tssl_State.Text = "tssl_State";
            // 
            // p_addReport
            // 
            this.p_addReport.Controls.Add(this.rtb_jsQuery);
            this.p_addReport.Controls.Add(this.groupBox1);
            this.p_addReport.Controls.Add(this.groupBox6);
            this.p_addReport.Controls.Add(this.bt_exit);
            this.p_addReport.Controls.Add(this.bt_check);
            this.p_addReport.Location = new System.Drawing.Point(1, -4);
            this.p_addReport.Name = "p_addReport";
            this.p_addReport.Size = new System.Drawing.Size(936, 362);
            this.p_addReport.TabIndex = 29;
            // 
            // rtb_jsQuery
            // 
            this.rtb_jsQuery.Location = new System.Drawing.Point(656, 20);
            this.rtb_jsQuery.Name = "rtb_jsQuery";
            this.rtb_jsQuery.Size = new System.Drawing.Size(267, 279);
            this.rtb_jsQuery.TabIndex = 24;
            this.rtb_jsQuery.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_dataBase);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 346);
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
            this.tv_dataBase.Size = new System.Drawing.Size(392, 326);
            this.tv_dataBase.TabIndex = 0;
            this.tv_dataBase.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv_dataBase_AfterCheck);
            this.tv_dataBase.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tv_dataBase_AfterExpand);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pg_colum);
            this.groupBox6.Location = new System.Drawing.Point(418, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(204, 340);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "3.编辑字段属性";
            // 
            // pg_colum
            // 
            this.pg_colum.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pg_colum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg_colum.Location = new System.Drawing.Point(3, 17);
            this.pg_colum.Name = "pg_colum";
            this.pg_colum.Size = new System.Drawing.Size(198, 320);
            this.pg_colum.TabIndex = 0;
            this.pg_colum.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pg_colum_PropertyValueChanged);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(816, 305);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 44);
            this.bt_exit.TabIndex = 25;
            this.bt_exit.Text = "退出";
            this.bt_exit.UseVisualStyleBackColor = true;
            // 
            // bt_check
            // 
            this.bt_check.Location = new System.Drawing.Point(692, 305);
            this.bt_check.Name = "bt_check";
            this.bt_check.Size = new System.Drawing.Size(75, 44);
            this.bt_check.TabIndex = 26;
            this.bt_check.Text = "4.提交";
            this.bt_check.UseVisualStyleBackColor = true;
            this.bt_check.Click += new System.EventHandler(this.bt_check_Click);
            // 
            // CrudTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 675);
            this.Controls.Add(this.rtb_output);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gp_addReport);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.p_manageReport);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.p_addReport);
            this.Name = "CrudTool";
            this.Text = "js查询生成器 V1.0";
            this.Load += new System.EventHandler(this.CrudTool_Load);
            this.groupBox2.ResumeLayout(false);
            this.gp_addReport.ResumeLayout(false);
            this.gp_addReport.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.p_manageReport.ResumeLayout(false);
            this.gp_manageReport.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.p_addReport.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_output;
        private System.Windows.Forms.ListView lv_preview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tv_dataBase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lv_colums;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PropertyGrid pg_colum;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_check;
        private System.Windows.Forms.ToolStripStatusLabel tssl_State;
        private System.Windows.Forms.GroupBox gp_manageReport;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button bt_copy;
        private System.Windows.Forms.Button bt_dubeg;
        private System.Windows.Forms.Button bt_edit;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button bt_query;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_queryReportName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_queryReportId;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ListView lv_reports;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gp_addReport;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.ComboBox cb_connString;
        private System.Windows.Forms.Button bt_submit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox rtb_regex;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox rtb_colum;
        private System.Windows.Forms.RichTextBox rtb_control_type;
        private System.Windows.Forms.RichTextBox rtb_display;
        private System.Windows.Forms.Label label11;
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
        private System.Windows.Forms.TextBox tb_form_Id;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Panel p_manageReport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel p_addReport;
        private System.Windows.Forms.RichTextBox rtb_jsQuery;
    }
}