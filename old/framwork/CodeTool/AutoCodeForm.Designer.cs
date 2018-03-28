using System.Windows.Forms;

namespace xyj.tool
{
    partial class AutoCodeForm:Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoCodeForm));
            this.rtb_interface = new System.Windows.Forms.RichTextBox();
            this.rtb_controller = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_generate = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_controller = new System.Windows.Forms.TextBox();
            this.tb_area = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_action = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_controller = new System.Windows.Forms.Label();
            this.lb_reportId = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_actionNote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_columsTip = new System.Windows.Forms.TextBox();
            this.tb_nameSpace = new System.Windows.Forms.TextBox();
            this.tb_projectName = new System.Windows.Forms.TextBox();
            this.tb_viewModel = new System.Windows.Forms.TextBox();
            this.tb_tableName = new System.Windows.Forms.TextBox();
            this.tb_action = new System.Windows.Forms.TextBox();
            this.tb_colums = new System.Windows.Forms.TextBox();
            this.tb_apiReturnModelNote = new System.Windows.Forms.TextBox();
            this.tb_apiReturnModel = new System.Windows.Forms.TextBox();
            this.tb_apiInModelNote = new System.Windows.Forms.TextBox();
            this.tb_apiModel = new System.Windows.Forms.TextBox();
            this.tb_apiNote = new System.Windows.Forms.TextBox();
            this.tb_apiName = new System.Windows.Forms.TextBox();
            this.tb_service = new System.Windows.Forms.TextBox();
            this.tb_interface = new System.Windows.Forms.TextBox();
            this.tb_columsNote = new System.Windows.Forms.TextBox();
            this.tb_database = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtb_service = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rtb_view = new System.Windows.Forms.RichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rtb_serviceModel = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rtb_viewModel = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb_interface
            // 
            this.rtb_interface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_interface.Location = new System.Drawing.Point(3, 17);
            this.rtb_interface.Name = "rtb_interface";
            this.rtb_interface.Size = new System.Drawing.Size(330, 213);
            this.rtb_interface.TabIndex = 1;
            this.rtb_interface.Text = resources.GetString("rtb_interface.Text");
            // 
            // rtb_controller
            // 
            this.rtb_controller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_controller.Location = new System.Drawing.Point(3, 17);
            this.rtb_controller.Name = "rtb_controller";
            this.rtb_controller.Size = new System.Drawing.Size(330, 195);
            this.rtb_controller.TabIndex = 1;
            this.rtb_controller.Text = resources.GetString("rtb_controller.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_interface);
            this.groupBox1.Location = new System.Drawing.Point(6, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 233);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interface Code";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtb_controller);
            this.groupBox2.Location = new System.Drawing.Point(6, 490);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 215);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controller Code";
            // 
            // bt_generate
            // 
            this.bt_generate.Location = new System.Drawing.Point(348, 202);
            this.bt_generate.Name = "bt_generate";
            this.bt_generate.Size = new System.Drawing.Size(75, 23);
            this.bt_generate.TabIndex = 3;
            this.bt_generate.Text = "Generate";
            this.bt_generate.UseVisualStyleBackColor = true;
            this.bt_generate.Click += new System.EventHandler(this.bt_generate_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(644, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tb_controller);
            this.groupBox3.Controls.Add(this.tb_area);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lb_action);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lb_controller);
            this.groupBox3.Controls.Add(this.lb_reportId);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tb_actionNote);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tb_columsTip);
            this.groupBox3.Controls.Add(this.tb_nameSpace);
            this.groupBox3.Controls.Add(this.tb_projectName);
            this.groupBox3.Controls.Add(this.tb_viewModel);
            this.groupBox3.Controls.Add(this.tb_tableName);
            this.groupBox3.Controls.Add(this.tb_action);
            this.groupBox3.Controls.Add(this.tb_colums);
            this.groupBox3.Controls.Add(this.tb_apiReturnModelNote);
            this.groupBox3.Controls.Add(this.tb_apiReturnModel);
            this.groupBox3.Controls.Add(this.tb_apiInModelNote);
            this.groupBox3.Controls.Add(this.tb_apiModel);
            this.groupBox3.Controls.Add(this.tb_apiNote);
            this.groupBox3.Controls.Add(this.tb_apiName);
            this.groupBox3.Controls.Add(this.tb_service);
            this.groupBox3.Controls.Add(this.tb_interface);
            this.groupBox3.Controls.Add(this.tb_columsNote);
            this.groupBox3.Controls.Add(this.tb_database);
            this.groupBox3.Location = new System.Drawing.Point(12, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1031, 168);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Code Config";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(865, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Controller";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(865, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Area";
            // 
            // tb_controller
            // 
            this.tb_controller.Location = new System.Drawing.Point(932, 58);
            this.tb_controller.Name = "tb_controller";
            this.tb_controller.Size = new System.Drawing.Size(87, 21);
            this.tb_controller.TabIndex = 2;
            this.tb_controller.Text = "CRUD2";
            this.tb_controller.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_area
            // 
            this.tb_area.Location = new System.Drawing.Point(932, 21);
            this.tb_area.Name = "tb_area";
            this.tb_area.Size = new System.Drawing.Size(87, 21);
            this.tb_area.TabIndex = 3;
            this.tb_area.Text = "Permision2";
            this.tb_area.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(854, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "ActionNote";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(673, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 1;
            this.label15.Text = "ColumsTip";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(673, 135);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 1;
            this.label17.Text = "NameSpace";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(673, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "ProjectName";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(673, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "ViewModel";
            // 
            // lb_action
            // 
            this.lb_action.AutoSize = true;
            this.lb_action.Location = new System.Drawing.Point(468, 61);
            this.lb_action.Name = "lb_action";
            this.lb_action.Size = new System.Drawing.Size(59, 12);
            this.lb_action.TabIndex = 1;
            this.lb_action.Text = "TableName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(870, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Action";
            // 
            // lb_controller
            // 
            this.lb_controller.AutoSize = true;
            this.lb_controller.Location = new System.Drawing.Point(468, 136);
            this.lb_controller.Name = "lb_controller";
            this.lb_controller.Size = new System.Drawing.Size(65, 12);
            this.lb_controller.TabIndex = 1;
            this.lb_controller.Text = "ColumsNote";
            // 
            // lb_reportId
            // 
            this.lb_reportId.AutoSize = true;
            this.lb_reportId.Location = new System.Drawing.Point(469, 99);
            this.lb_reportId.Name = "lb_reportId";
            this.lb_reportId.Size = new System.Drawing.Size(41, 12);
            this.lb_reportId.TabIndex = 1;
            this.lb_reportId.Text = "Colums";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(207, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "ApiReturnModel";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "ApiReturnModelNote";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(207, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "ApiInModelNote";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(207, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "ApiModel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "ApiNote";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "ApiName";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "Service";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Interface";
            // 
            // tb_actionNote
            // 
            this.tb_actionNote.Location = new System.Drawing.Point(931, 130);
            this.tb_actionNote.Name = "tb_actionNote";
            this.tb_actionNote.Size = new System.Drawing.Size(87, 21);
            this.tb_actionNote.TabIndex = 0;
            this.tb_actionNote.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(468, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Database";
            // 
            // tb_columsTip
            // 
            this.tb_columsTip.Location = new System.Drawing.Point(752, 12);
            this.tb_columsTip.Name = "tb_columsTip";
            this.tb_columsTip.Size = new System.Drawing.Size(87, 21);
            this.tb_columsTip.TabIndex = 0;
            this.tb_columsTip.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_nameSpace
            // 
            this.tb_nameSpace.Location = new System.Drawing.Point(752, 127);
            this.tb_nameSpace.Name = "tb_nameSpace";
            this.tb_nameSpace.Size = new System.Drawing.Size(87, 21);
            this.tb_nameSpace.TabIndex = 0;
            this.tb_nameSpace.TextChanged += new System.EventHandler(this.tb_viewModel_TextChanged);
            // 
            // tb_projectName
            // 
            this.tb_projectName.Location = new System.Drawing.Point(752, 92);
            this.tb_projectName.Name = "tb_projectName";
            this.tb_projectName.Size = new System.Drawing.Size(87, 21);
            this.tb_projectName.TabIndex = 0;
            this.tb_projectName.TextChanged += new System.EventHandler(this.tb_viewModel_TextChanged);
            // 
            // tb_viewModel
            // 
            this.tb_viewModel.Location = new System.Drawing.Point(752, 55);
            this.tb_viewModel.Name = "tb_viewModel";
            this.tb_viewModel.Size = new System.Drawing.Size(87, 21);
            this.tb_viewModel.TabIndex = 0;
            this.tb_viewModel.TextChanged += new System.EventHandler(this.tb_viewModel_TextChanged);
            // 
            // tb_tableName
            // 
            this.tb_tableName.Location = new System.Drawing.Point(549, 54);
            this.tb_tableName.Name = "tb_tableName";
            this.tb_tableName.ReadOnly = true;
            this.tb_tableName.Size = new System.Drawing.Size(102, 21);
            this.tb_tableName.TabIndex = 0;
            this.tb_tableName.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_action
            // 
            this.tb_action.Location = new System.Drawing.Point(932, 94);
            this.tb_action.Name = "tb_action";
            this.tb_action.Size = new System.Drawing.Size(87, 21);
            this.tb_action.TabIndex = 0;
            this.tb_action.TextChanged += new System.EventHandler(this.tb_action_TextChanged);
            // 
            // tb_colums
            // 
            this.tb_colums.Location = new System.Drawing.Point(549, 93);
            this.tb_colums.Name = "tb_colums";
            this.tb_colums.ReadOnly = true;
            this.tb_colums.Size = new System.Drawing.Size(102, 21);
            this.tb_colums.TabIndex = 0;
            this.tb_colums.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_apiReturnModelNote
            // 
            this.tb_apiReturnModelNote.Location = new System.Drawing.Point(324, 57);
            this.tb_apiReturnModelNote.Name = "tb_apiReturnModelNote";
            this.tb_apiReturnModelNote.Size = new System.Drawing.Size(109, 21);
            this.tb_apiReturnModelNote.TabIndex = 0;
            this.tb_apiReturnModelNote.Text = "true or false";
            this.tb_apiReturnModelNote.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_apiReturnModel
            // 
            this.tb_apiReturnModel.Location = new System.Drawing.Point(324, 136);
            this.tb_apiReturnModel.Name = "tb_apiReturnModel";
            this.tb_apiReturnModel.Size = new System.Drawing.Size(109, 21);
            this.tb_apiReturnModel.TabIndex = 0;
            this.tb_apiReturnModel.Text = "bool";
            this.tb_apiReturnModel.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_apiInModelNote
            // 
            this.tb_apiInModelNote.Location = new System.Drawing.Point(324, 17);
            this.tb_apiInModelNote.Name = "tb_apiInModelNote";
            this.tb_apiInModelNote.Size = new System.Drawing.Size(109, 21);
            this.tb_apiInModelNote.TabIndex = 0;
            this.tb_apiInModelNote.Text = "Model";
            this.tb_apiInModelNote.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_apiModel
            // 
            this.tb_apiModel.Location = new System.Drawing.Point(324, 96);
            this.tb_apiModel.Name = "tb_apiModel";
            this.tb_apiModel.Size = new System.Drawing.Size(109, 21);
            this.tb_apiModel.TabIndex = 0;
            this.tb_apiModel.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_apiNote
            // 
            this.tb_apiNote.Location = new System.Drawing.Point(103, 139);
            this.tb_apiNote.Name = "tb_apiNote";
            this.tb_apiNote.Size = new System.Drawing.Size(87, 21);
            this.tb_apiNote.TabIndex = 0;
            this.tb_apiNote.Text = "接口说明";
            this.tb_apiNote.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_apiName
            // 
            this.tb_apiName.Location = new System.Drawing.Point(103, 96);
            this.tb_apiName.Name = "tb_apiName";
            this.tb_apiName.Size = new System.Drawing.Size(87, 21);
            this.tb_apiName.TabIndex = 0;
            this.tb_apiName.Text = "接口名称";
            this.tb_apiName.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_service
            // 
            this.tb_service.Location = new System.Drawing.Point(103, 60);
            this.tb_service.Name = "tb_service";
            this.tb_service.Size = new System.Drawing.Size(87, 21);
            this.tb_service.TabIndex = 0;
            this.tb_service.Text = "PermissionServices";
            this.tb_service.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_interface
            // 
            this.tb_interface.Location = new System.Drawing.Point(103, 20);
            this.tb_interface.Name = "tb_interface";
            this.tb_interface.Size = new System.Drawing.Size(87, 21);
            this.tb_interface.TabIndex = 0;
            this.tb_interface.Text = "IPermmisionService";
            this.tb_interface.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_columsNote
            // 
            this.tb_columsNote.Location = new System.Drawing.Point(549, 130);
            this.tb_columsNote.Name = "tb_columsNote";
            this.tb_columsNote.ReadOnly = true;
            this.tb_columsNote.Size = new System.Drawing.Size(102, 21);
            this.tb_columsNote.TabIndex = 0;
            this.tb_columsNote.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // tb_database
            // 
            this.tb_database.Location = new System.Drawing.Point(549, 16);
            this.tb_database.Name = "tb_database";
            this.tb_database.ReadOnly = true;
            this.tb_database.Size = new System.Drawing.Size(102, 21);
            this.tb_database.TabIndex = 0;
            this.tb_database.TextChanged += new System.EventHandler(this.bt_generate_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtb_service);
            this.groupBox4.Location = new System.Drawing.Point(357, 231);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(336, 233);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Service Code";
            // 
            // rtb_service
            // 
            this.rtb_service.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_service.Location = new System.Drawing.Point(3, 17);
            this.rtb_service.Name = "rtb_service";
            this.rtb_service.Size = new System.Drawing.Size(330, 213);
            this.rtb_service.TabIndex = 1;
            this.rtb_service.Text = resources.GetString("rtb_service.Text");
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rtb_view);
            this.groupBox5.Location = new System.Drawing.Point(357, 489);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(336, 215);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "View Code";
            // 
            // rtb_view
            // 
            this.rtb_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_view.Location = new System.Drawing.Point(3, 17);
            this.rtb_view.Name = "rtb_view";
            this.rtb_view.Size = new System.Drawing.Size(330, 195);
            this.rtb_view.TabIndex = 1;
            this.rtb_view.Text = resources.GetString("rtb_view.Text");
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rtb_serviceModel);
            this.groupBox6.Location = new System.Drawing.Point(707, 231);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(336, 233);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Service Model Code";
            // 
            // rtb_serviceModel
            // 
            this.rtb_serviceModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_serviceModel.Location = new System.Drawing.Point(3, 17);
            this.rtb_serviceModel.Name = "rtb_serviceModel";
            this.rtb_serviceModel.Size = new System.Drawing.Size(330, 213);
            this.rtb_serviceModel.TabIndex = 1;
            this.rtb_serviceModel.Text = " public class StuInfo: NStudent_Msg\n    {\n    }";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rtb_viewModel);
            this.groupBox7.Location = new System.Drawing.Point(715, 489);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(336, 215);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "ViewModel Code";
            // 
            // rtb_viewModel
            // 
            this.rtb_viewModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_viewModel.Location = new System.Drawing.Point(3, 17);
            this.rtb_viewModel.Name = "rtb_viewModel";
            this.rtb_viewModel.Size = new System.Drawing.Size(330, 195);
            this.rtb_viewModel.TabIndex = 1;
            this.rtb_viewModel.Text = resources.GetString("rtb_viewModel.Text");
            // 
            // AutoCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 754);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bt_generate);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "AutoCodeForm";
            this.Text = "AutoCodeForm";
            this.Load += new System.EventHandler(this.AutoCodeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_interface;
        private System.Windows.Forms.RichTextBox rtb_controller;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_generate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_action;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_controller;
        private System.Windows.Forms.Label lb_reportId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_viewModel;
        private System.Windows.Forms.TextBox tb_tableName;
        private System.Windows.Forms.TextBox tb_action;
        private System.Windows.Forms.TextBox tb_colums;
        private System.Windows.Forms.TextBox tb_columsNote;
        private System.Windows.Forms.TextBox tb_database;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtb_service;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox rtb_view;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_apiReturnModel;
        private System.Windows.Forms.TextBox tb_apiModel;
        private System.Windows.Forms.TextBox tb_apiName;
        private System.Windows.Forms.TextBox tb_service;
        private System.Windows.Forms.TextBox tb_interface;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox rtb_serviceModel;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox rtb_viewModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_controller;
        private System.Windows.Forms.TextBox tb_area;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_apiNote;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_apiInModelNote;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_apiReturnModelNote;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_actionNote;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tb_columsTip;
        private Label label17;
        private Label label16;
        private TextBox tb_nameSpace;
        private TextBox tb_projectName;
    }
}