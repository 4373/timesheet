namespace TimeSheet
{
    partial class FrmProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProject));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnQueryEmp = new System.Windows.Forms.Button();
            this.txtQueryCondition = new System.Windows.Forms.TextBox();
            this.cmboxIdorName = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(590, 56);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 24);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "刷新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.delete,
            this.update});
            this.dataGridView1.Location = new System.Drawing.Point(26, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(716, 334);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.delete.Frozen = true;
            this.delete.HeaderText = "";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "删除";
            this.delete.UseColumnTextForButtonValue = true;
            this.delete.Width = 60;
            // 
            // update
            // 
            this.update.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.update.Frozen = true;
            this.update.HeaderText = "";
            this.update.Name = "update";
            this.update.ReadOnly = true;
            this.update.Text = "更新";
            this.update.UseColumnTextForButtonValue = true;
            this.update.Width = 60;
            // 
            // btnQueryEmp
            // 
            this.btnQueryEmp.Location = new System.Drawing.Point(497, 56);
            this.btnQueryEmp.Name = "btnQueryEmp";
            this.btnQueryEmp.Size = new System.Drawing.Size(87, 24);
            this.btnQueryEmp.TabIndex = 9;
            this.btnQueryEmp.Text = "查询";
            this.btnQueryEmp.UseVisualStyleBackColor = true;
            // 
            // txtQueryCondition
            // 
            this.txtQueryCondition.Location = new System.Drawing.Point(194, 54);
            this.txtQueryCondition.Multiline = true;
            this.txtQueryCondition.Name = "txtQueryCondition";
            this.txtQueryCondition.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtQueryCondition.Size = new System.Drawing.Size(296, 24);
            this.txtQueryCondition.TabIndex = 8;
            this.txtQueryCondition.TextChanged += new System.EventHandler(this.txtQueryCondition_TextChanged);
            // 
            // cmboxIdorName
            // 
            this.cmboxIdorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxIdorName.FormattingEnabled = true;
            this.cmboxIdorName.Items.AddRange(new object[] {
            " 项目名称查询",
            " PL/M工号查询"});
            this.cmboxIdorName.Location = new System.Drawing.Point(121, 14);
            this.cmboxIdorName.Name = "cmboxIdorName";
            this.cmboxIdorName.Size = new System.Drawing.Size(128, 22);
            this.cmboxIdorName.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(26, 56);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 24);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 514);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnQueryEmp);
            this.Controls.Add(this.txtQueryCondition);
            this.Controls.Add(this.cmboxIdorName);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目管理";
            this.Load += new System.EventHandler(this.FrmProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.DataGridViewButtonColumn update;
        private System.Windows.Forms.Button btnQueryEmp;
        private System.Windows.Forms.TextBox txtQueryCondition;
        private System.Windows.Forms.ComboBox cmboxIdorName;
        private System.Windows.Forms.Button btnAdd;
    }
}