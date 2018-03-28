using xyj.tool.Helper;

namespace xyj.tool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTool2));
            this.rtb_output_add = new System.Windows.Forms.RichTextBox();
            this.p_addReport = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tb_namespace = new System.Windows.Forms.TextBox();
            this.ck_test = new System.Windows.Forms.CheckBox();
            this.ck_pre = new System.Windows.Forms.CheckBox();
            this.ck_clean = new System.Windows.Forms.CheckBox();
            this.ck_rechoose = new System.Windows.Forms.CheckBox();
            this.ck_detail = new System.Windows.Forms.CheckBox();
            this.ck_update = new System.Windows.Forms.CheckBox();
            this.ck_entity = new System.Windows.Forms.CheckBox();
            this.ck_add = new System.Windows.Forms.CheckBox();
            this.bt_check = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tv_dataBase = new System.Windows.Forms.TreeView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pg_colum = new System.Windows.Forms.PropertyGrid();
            this.ck_list = new System.Windows.Forms.CheckBox();
            this.ck_items = new System.Windows.Forms.CheckBox();
            this.ck_delete = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtb_output_update = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_colums = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_State = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rtb_output_detail = new System.Windows.Forms.RichTextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rtb_output_delete = new System.Windows.Forms.RichTextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.rtb_output_items = new System.Windows.Forms.RichTextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.rtb_output_list = new System.Windows.Forms.RichTextBox();
            this.p_addReport.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb_output_add
            // 
            this.rtb_output_add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_output_add.Location = new System.Drawing.Point(3, 17);
            this.rtb_output_add.Name = "rtb_output_add";
            this.rtb_output_add.Size = new System.Drawing.Size(350, 94);
            this.rtb_output_add.TabIndex = 2;
            this.rtb_output_add.Text = "";
            // 
            // p_addReport
            // 
            this.p_addReport.Controls.Add(this.groupBox8);
            this.p_addReport.Controls.Add(this.groupBox5);
            this.p_addReport.Controls.Add(this.groupBox1);
            this.p_addReport.Controls.Add(this.groupBox6);
            this.p_addReport.Location = new System.Drawing.Point(7, 7);
            this.p_addReport.Name = "p_addReport";
            this.p_addReport.Size = new System.Drawing.Size(826, 350);
            this.p_addReport.TabIndex = 20;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.richTextBox1);
            this.groupBox8.Location = new System.Drawing.Point(517, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(301, 238);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "小贴士";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(295, 218);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tb_namespace);
            this.groupBox5.Controls.Add(this.ck_test);
            this.groupBox5.Controls.Add(this.ck_pre);
            this.groupBox5.Controls.Add(this.ck_clean);
            this.groupBox5.Controls.Add(this.ck_rechoose);
            this.groupBox5.Controls.Add(this.ck_detail);
            this.groupBox5.Controls.Add(this.ck_update);
            this.groupBox5.Controls.Add(this.ck_entity);
            this.groupBox5.Controls.Add(this.ck_add);
            this.groupBox5.Controls.Add(this.bt_check);
            this.groupBox5.Controls.Add(this.bt_exit);
            this.groupBox5.Location = new System.Drawing.Point(517, 252);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(301, 89);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "4.生成代码";
            // 
            // tb_namespace
            // 
            this.tb_namespace.Location = new System.Drawing.Point(190, 15);
            this.tb_namespace.Name = "tb_namespace";
            this.tb_namespace.Size = new System.Drawing.Size(100, 21);
            this.tb_namespace.TabIndex = 14;
            this.tb_namespace.Visible = false;
            // 
            // ck_test
            // 
            this.ck_test.AutoSize = true;
            this.ck_test.Location = new System.Drawing.Point(12, 71);
            this.ck_test.Name = "ck_test";
            this.ck_test.Size = new System.Drawing.Size(72, 16);
            this.ck_test.TabIndex = 13;
            this.ck_test.Text = "调试模式";
            this.ck_test.UseVisualStyleBackColor = true;
            this.ck_test.CheckedChanged += new System.EventHandler(this.ck_test_CheckedChanged);
            // 
            // ck_pre
            // 
            this.ck_pre.AutoSize = true;
            this.ck_pre.Checked = true;
            this.ck_pre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_pre.Location = new System.Drawing.Point(87, 35);
            this.ck_pre.Name = "ck_pre";
            this.ck_pre.Size = new System.Drawing.Size(72, 16);
            this.ck_pre.TabIndex = 13;
            this.ck_pre.Text = "字段前缀";
            this.ck_pre.UseVisualStyleBackColor = true;
            this.ck_pre.CheckedChanged += new System.EventHandler(this.ck_pre_CheckedChanged);
            // 
            // ck_clean
            // 
            this.ck_clean.AutoSize = true;
            this.ck_clean.Location = new System.Drawing.Point(87, 71);
            this.ck_clean.Name = "ck_clean";
            this.ck_clean.Size = new System.Drawing.Size(72, 16);
            this.ck_clean.TabIndex = 13;
            this.ck_clean.Text = "清理目录";
            this.ck_clean.UseVisualStyleBackColor = true;
            this.ck_clean.CheckedChanged += new System.EventHandler(this.ck_clean_CheckedChanged);
            // 
            // ck_rechoose
            // 
            this.ck_rechoose.AutoSize = true;
            this.ck_rechoose.Checked = true;
            this.ck_rechoose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_rechoose.Enabled = false;
            this.ck_rechoose.Location = new System.Drawing.Point(87, 53);
            this.ck_rechoose.Name = "ck_rechoose";
            this.ck_rechoose.Size = new System.Drawing.Size(72, 16);
            this.ck_rechoose.TabIndex = 13;
            this.ck_rechoose.Text = "重选目录";
            this.ck_rechoose.UseVisualStyleBackColor = true;
            // 
            // ck_detail
            // 
            this.ck_detail.AutoSize = true;
            this.ck_detail.Checked = true;
            this.ck_detail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_detail.Location = new System.Drawing.Point(12, 53);
            this.ck_detail.Name = "ck_detail";
            this.ck_detail.Size = new System.Drawing.Size(72, 16);
            this.ck_detail.TabIndex = 13;
            this.ck_detail.Text = "详细界面";
            this.ck_detail.UseVisualStyleBackColor = true;
            // 
            // ck_update
            // 
            this.ck_update.AutoSize = true;
            this.ck_update.Checked = true;
            this.ck_update.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_update.Location = new System.Drawing.Point(12, 35);
            this.ck_update.Name = "ck_update";
            this.ck_update.Size = new System.Drawing.Size(72, 16);
            this.ck_update.TabIndex = 13;
            this.ck_update.Text = "编辑界面";
            this.ck_update.UseVisualStyleBackColor = true;
            // 
            // ck_entity
            // 
            this.ck_entity.AutoSize = true;
            this.ck_entity.Location = new System.Drawing.Point(87, 15);
            this.ck_entity.Name = "ck_entity";
            this.ck_entity.Size = new System.Drawing.Size(72, 16);
            this.ck_entity.TabIndex = 13;
            this.ck_entity.Text = "生成实体";
            this.ck_entity.UseVisualStyleBackColor = true;
            this.ck_entity.CheckedChanged += new System.EventHandler(this.ck_entity_CheckedChanged);
            // 
            // ck_add
            // 
            this.ck_add.AutoSize = true;
            this.ck_add.Checked = true;
            this.ck_add.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_add.Location = new System.Drawing.Point(12, 16);
            this.ck_add.Name = "ck_add";
            this.ck_add.Size = new System.Drawing.Size(72, 16);
            this.ck_add.TabIndex = 13;
            this.ck_add.Text = "添加界面";
            this.ck_add.UseVisualStyleBackColor = true;
            // 
            // bt_check
            // 
            this.bt_check.Location = new System.Drawing.Point(193, 46);
            this.bt_check.Name = "bt_check";
            this.bt_check.Size = new System.Drawing.Size(39, 37);
            this.bt_check.TabIndex = 11;
            this.bt_check.Text = "生成";
            this.bt_check.UseVisualStyleBackColor = true;
            this.bt_check.Click += new System.EventHandler(this.bt_check_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(254, 46);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(37, 38);
            this.bt_exit.TabIndex = 11;
            this.bt_exit.Text = "退出";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_dataBase);
            this.groupBox1.Location = new System.Drawing.Point(-1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 346);
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
            this.tv_dataBase.Size = new System.Drawing.Size(291, 326);
            this.tv_dataBase.TabIndex = 0;
            this.tv_dataBase.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv_dataBase_AfterCheck);
            this.tv_dataBase.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tv_dataBase_AfterExpand);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pg_colum);
            this.groupBox6.Location = new System.Drawing.Point(299, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(214, 340);
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
            this.pg_colum.Size = new System.Drawing.Size(208, 320);
            this.pg_colum.TabIndex = 0;
            this.pg_colum.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pg_colum_PropertyValueChanged);
            // 
            // ck_list
            // 
            this.ck_list.AutoSize = true;
            this.ck_list.Checked = true;
            this.ck_list.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_list.Location = new System.Drawing.Point(1242, 314);
            this.ck_list.Name = "ck_list";
            this.ck_list.Size = new System.Drawing.Size(66, 16);
            this.ck_list.TabIndex = 13;
            this.ck_list.Text = "列表api";
            this.ck_list.UseVisualStyleBackColor = true;
            this.ck_list.CheckedChanged += new System.EventHandler(this.ck_clean_CheckedChanged);
            // 
            // ck_items
            // 
            this.ck_items.AutoSize = true;
            this.ck_items.Checked = true;
            this.ck_items.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_items.Location = new System.Drawing.Point(1242, 294);
            this.ck_items.Name = "ck_items";
            this.ck_items.Size = new System.Drawing.Size(66, 16);
            this.ck_items.TabIndex = 13;
            this.ck_items.Text = "下拉api";
            this.ck_items.UseVisualStyleBackColor = true;
            this.ck_items.CheckedChanged += new System.EventHandler(this.ck_clean_CheckedChanged);
            // 
            // ck_delete
            // 
            this.ck_delete.AutoSize = true;
            this.ck_delete.Checked = true;
            this.ck_delete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_delete.Location = new System.Drawing.Point(1242, 274);
            this.ck_delete.Name = "ck_delete";
            this.ck_delete.Size = new System.Drawing.Size(66, 16);
            this.ck_delete.TabIndex = 13;
            this.ck_delete.Text = "删除api";
            this.ck_delete.UseVisualStyleBackColor = true;
            this.ck_delete.CheckedChanged += new System.EventHandler(this.ck_clean_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtb_output_add);
            this.groupBox4.Location = new System.Drawing.Point(866, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(356, 114);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "预览添加";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtb_output_update);
            this.groupBox3.Location = new System.Drawing.Point(866, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(353, 122);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "预览编辑";
            // 
            // rtb_output_update
            // 
            this.rtb_output_update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_output_update.Location = new System.Drawing.Point(3, 17);
            this.rtb_output_update.Name = "rtb_output_update";
            this.rtb_output_update.Size = new System.Drawing.Size(347, 102);
            this.rtb_output_update.TabIndex = 2;
            this.rtb_output_update.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lv_colums);
            this.groupBox2.Location = new System.Drawing.Point(4, 362);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(829, 239);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2.配置字段  (a隐藏,d显示,w上移，s下移,t类型,c详情类型,e编辑标签,r设置正则式)";
            // 
            // lv_colums
            // 
            this.lv_colums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_colums.HoverSelection = true;
            this.lv_colums.Location = new System.Drawing.Point(3, 17);
            this.lv_colums.Name = "lv_colums";
            this.lv_colums.Size = new System.Drawing.Size(823, 219);
            this.lv_colums.TabIndex = 0;
            this.lv_colums.UseCompatibleStateImageBehavior = false;
            this.lv_colums.SelectedIndexChanged += new System.EventHandler(this.lv_colums_SelectedIndexChanged);
            this.lv_colums.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lv_colums_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_State});
            this.statusStrip1.Location = new System.Drawing.Point(0, 603);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(842, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_State
            // 
            this.tssl_State.Name = "tssl_State";
            this.tssl_State.Size = new System.Drawing.Size(61, 17);
            this.tssl_State.Text = "tssl_State";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rtb_output_detail);
            this.groupBox7.Location = new System.Drawing.Point(869, 253);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(353, 122);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "预览详情";
            // 
            // rtb_output_detail
            // 
            this.rtb_output_detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_output_detail.Location = new System.Drawing.Point(3, 17);
            this.rtb_output_detail.Name = "rtb_output_detail";
            this.rtb_output_detail.Size = new System.Drawing.Size(347, 102);
            this.rtb_output_detail.TabIndex = 2;
            this.rtb_output_detail.Text = "";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rtb_output_delete);
            this.groupBox9.Location = new System.Drawing.Point(872, 381);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(353, 63);
            this.groupBox9.TabIndex = 9;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "删除Api";
            // 
            // rtb_output_delete
            // 
            this.rtb_output_delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_output_delete.Location = new System.Drawing.Point(3, 17);
            this.rtb_output_delete.Name = "rtb_output_delete";
            this.rtb_output_delete.Size = new System.Drawing.Size(347, 43);
            this.rtb_output_delete.TabIndex = 2;
            this.rtb_output_delete.Text = "";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.rtb_output_items);
            this.groupBox10.Location = new System.Drawing.Point(872, 453);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(353, 63);
            this.groupBox10.TabIndex = 9;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "下拉Api";
            // 
            // rtb_output_items
            // 
            this.rtb_output_items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_output_items.Location = new System.Drawing.Point(3, 17);
            this.rtb_output_items.Name = "rtb_output_items";
            this.rtb_output_items.Size = new System.Drawing.Size(347, 43);
            this.rtb_output_items.TabIndex = 2;
            this.rtb_output_items.Text = "";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.rtb_output_list);
            this.groupBox11.Location = new System.Drawing.Point(875, 522);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(353, 63);
            this.groupBox11.TabIndex = 9;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "列表Api";
            // 
            // rtb_output_list
            // 
            this.rtb_output_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_output_list.Location = new System.Drawing.Point(3, 17);
            this.rtb_output_list.Name = "rtb_output_list";
            this.rtb_output_list.Size = new System.Drawing.Size(347, 43);
            this.rtb_output_list.TabIndex = 2;
            this.rtb_output_list.Text = "";
            // 
            // FormTool2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 625);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ck_list);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.ck_items);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.ck_delete);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.p_addReport);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTool2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "表单生成器 V2.0.0.0";
            this.Load += new System.EventHandler(this.FormTool2_Load);
            this.p_addReport.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtb_output_add;
        private System.Windows.Forms.Button bt_check;
        private System.Windows.Forms.ListView lv_colums;
        private System.Windows.Forms.Panel p_addReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tv_dataBase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PropertyGrid pg_colum;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_State;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.RichTextBox rtb_output_update;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ck_detail;
        private System.Windows.Forms.CheckBox ck_update;
        private System.Windows.Forms.CheckBox ck_add;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox rtb_output_detail;
        private System.Windows.Forms.CheckBox ck_test;
        private System.Windows.Forms.CheckBox ck_clean;
        private System.Windows.Forms.CheckBox ck_list;
        private System.Windows.Forms.CheckBox ck_items;
        private System.Windows.Forms.CheckBox ck_delete;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RichTextBox rtb_output_delete;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RichTextBox rtb_output_items;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.RichTextBox rtb_output_list;
        private System.Windows.Forms.CheckBox ck_pre;
        private System.Windows.Forms.CheckBox ck_rechoose;
        private System.Windows.Forms.CheckBox ck_entity;
        private System.Windows.Forms.TextBox tb_namespace;
    }
}