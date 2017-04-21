namespace WeiBo
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._ecampus_yxxtDataSet = new WeiBo._ecampus_yxxtDataSet();
            this.ecampusyxxtDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wbuserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wb_userTableAdapter = new WeiBo._ecampus_yxxtDataSetTableAdapters.wb_userTableAdapter();
            this.useridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enterschollyearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spaceurlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nicknameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companynameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schoolidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companycityidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personaltagidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ecampus_yxxtDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecampusyxxtDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wbuserBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.useridDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.mailDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.enterschollyearDataGridViewTextBoxColumn,
            this.spaceurlDataGridViewTextBoxColumn,
            this.nicknameDataGridViewTextBoxColumn,
            this.companynameDataGridViewTextBoxColumn,
            this.schoolidDataGridViewTextBoxColumn,
            this.companycityidDataGridViewTextBoxColumn,
            this.personaltagidDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.wbuserBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(832, 452);
            this.dataGridView1.TabIndex = 0;
            // 
            // _ecampus_yxxtDataSet
            // 
            this._ecampus_yxxtDataSet.DataSetName = "_ecampus_yxxtDataSet";
            this._ecampus_yxxtDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ecampusyxxtDataSetBindingSource
            // 
            this.ecampusyxxtDataSetBindingSource.DataSource = this._ecampus_yxxtDataSet;
            this.ecampusyxxtDataSetBindingSource.Position = 0;
            // 
            // wbuserBindingSource
            // 
            this.wbuserBindingSource.DataMember = "wb_user";
            this.wbuserBindingSource.DataSource = this.ecampusyxxtDataSetBindingSource;
            // 
            // wb_userTableAdapter
            // 
            this.wb_userTableAdapter.ClearBeforeFill = true;
            // 
            // useridDataGridViewTextBoxColumn
            // 
            this.useridDataGridViewTextBoxColumn.DataPropertyName = "user_id";
            this.useridDataGridViewTextBoxColumn.HeaderText = "user_id";
            this.useridDataGridViewTextBoxColumn.Name = "useridDataGridViewTextBoxColumn";
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            // 
            // mailDataGridViewTextBoxColumn
            // 
            this.mailDataGridViewTextBoxColumn.DataPropertyName = "mail";
            this.mailDataGridViewTextBoxColumn.HeaderText = "mail";
            this.mailDataGridViewTextBoxColumn.Name = "mailDataGridViewTextBoxColumn";
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "phone";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            // 
            // enterschollyearDataGridViewTextBoxColumn
            // 
            this.enterschollyearDataGridViewTextBoxColumn.DataPropertyName = "enter_scholl_year";
            this.enterschollyearDataGridViewTextBoxColumn.HeaderText = "enter_scholl_year";
            this.enterschollyearDataGridViewTextBoxColumn.Name = "enterschollyearDataGridViewTextBoxColumn";
            // 
            // spaceurlDataGridViewTextBoxColumn
            // 
            this.spaceurlDataGridViewTextBoxColumn.DataPropertyName = "space_url";
            this.spaceurlDataGridViewTextBoxColumn.HeaderText = "space_url";
            this.spaceurlDataGridViewTextBoxColumn.Name = "spaceurlDataGridViewTextBoxColumn";
            // 
            // nicknameDataGridViewTextBoxColumn
            // 
            this.nicknameDataGridViewTextBoxColumn.DataPropertyName = "nick_name";
            this.nicknameDataGridViewTextBoxColumn.HeaderText = "nick_name";
            this.nicknameDataGridViewTextBoxColumn.Name = "nicknameDataGridViewTextBoxColumn";
            // 
            // companynameDataGridViewTextBoxColumn
            // 
            this.companynameDataGridViewTextBoxColumn.DataPropertyName = "company_name";
            this.companynameDataGridViewTextBoxColumn.HeaderText = "company_name";
            this.companynameDataGridViewTextBoxColumn.Name = "companynameDataGridViewTextBoxColumn";
            // 
            // schoolidDataGridViewTextBoxColumn
            // 
            this.schoolidDataGridViewTextBoxColumn.DataPropertyName = "school_id";
            this.schoolidDataGridViewTextBoxColumn.HeaderText = "school_id";
            this.schoolidDataGridViewTextBoxColumn.Name = "schoolidDataGridViewTextBoxColumn";
            // 
            // companycityidDataGridViewTextBoxColumn
            // 
            this.companycityidDataGridViewTextBoxColumn.DataPropertyName = "company_city_id";
            this.companycityidDataGridViewTextBoxColumn.HeaderText = "company_city_id";
            this.companycityidDataGridViewTextBoxColumn.Name = "companycityidDataGridViewTextBoxColumn";
            // 
            // personaltagidDataGridViewTextBoxColumn
            // 
            this.personaltagidDataGridViewTextBoxColumn.DataPropertyName = "personal_tag_id";
            this.personaltagidDataGridViewTextBoxColumn.HeaderText = "personal_tag_id";
            this.personaltagidDataGridViewTextBoxColumn.Name = "personaltagidDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 452);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ecampus_yxxtDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecampusyxxtDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wbuserBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource ecampusyxxtDataSetBindingSource;
        private _ecampus_yxxtDataSet _ecampus_yxxtDataSet;
        private System.Windows.Forms.BindingSource wbuserBindingSource;
        private _ecampus_yxxtDataSetTableAdapters.wb_userTableAdapter wb_userTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn useridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enterschollyearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spaceurlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nicknameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companynameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn schoolidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companycityidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personaltagidDataGridViewTextBoxColumn;
    }
}

