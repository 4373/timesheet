namespace TimeSheet
{
    partial class FrmEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmployee));
            this.btnAddEmp = new System.Windows.Forms.Button();
            this.cmboxIdorName = new System.Windows.Forms.ComboBox();
            this.txtQueryCondition = new System.Windows.Forms.TextBox();
            this.btnQueryEmp = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddEmp
            // 
            this.btnAddEmp.Location = new System.Drawing.Point(27, 57);
            this.btnAddEmp.Name = "btnAddEmp";
            this.btnAddEmp.Size = new System.Drawing.Size(87, 23);
            this.btnAddEmp.TabIndex = 0;
            this.btnAddEmp.Text = "添加";
            this.btnAddEmp.UseVisualStyleBackColor = true;
            this.btnAddEmp.Click += new System.EventHandler(this.btnAddEmp_Click);
            // 
            // cmboxIdorName
            // 
            this.cmboxIdorName.FormattingEnabled = true;
            this.cmboxIdorName.Items.AddRange(new object[] {
            "按姓名查询",
            "按工号查询"});
            this.cmboxIdorName.Location = new System.Drawing.Point(129, 57);
            this.cmboxIdorName.Name = "cmboxIdorName";
            this.cmboxIdorName.Size = new System.Drawing.Size(118, 22);
            this.cmboxIdorName.TabIndex = 1;
            // 
            // txtQueryCondition
            // 
            this.txtQueryCondition.Location = new System.Drawing.Point(255, 56);
            this.txtQueryCondition.Name = "txtQueryCondition";
            this.txtQueryCondition.Size = new System.Drawing.Size(296, 22);
            this.txtQueryCondition.TabIndex = 2;
            this.txtQueryCondition.TextChanged += new System.EventHandler(this.txtQueryCondition_TextChanged);
            // 
            // btnQueryEmp
            // 
            this.btnQueryEmp.Location = new System.Drawing.Point(559, 57);
            this.btnQueryEmp.Name = "btnQueryEmp";
            this.btnQueryEmp.Size = new System.Drawing.Size(87, 23);
            this.btnQueryEmp.TabIndex = 3;
            this.btnQueryEmp.Text = "查询";
            this.btnQueryEmp.UseVisualStyleBackColor = true;
            this.btnQueryEmp.Click += new System.EventHandler(this.btnQueryEmp_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.delete,
            this.update});
            this.dataGridView1.Location = new System.Drawing.Point(27, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(798, 334);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellClick);
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
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(696, 57);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "刷新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // FrmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(848, 514);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnQueryEmp);
            this.Controls.Add(this.txtQueryCondition);
            this.Controls.Add(this.cmboxIdorName);
            this.Controls.Add(this.btnAddEmp);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmEmployee";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工管理";
            this.Load += new System.EventHandler(this.FrmEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddEmp;
        private System.Windows.Forms.ComboBox cmboxIdorName;
        private System.Windows.Forms.TextBox txtQueryCondition;
        private System.Windows.Forms.Button btnQueryEmp;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.DataGridViewButtonColumn update;
    }
}