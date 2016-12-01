namespace TimeSheet
{
    partial class FrmProAddOrUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProAddOrUpdate));
            this.lblName = new System.Windows.Forms.Label();
            this.lblPLid = new System.Windows.Forms.Label();
            this.lblPMId = new System.Windows.Forms.Label();
            this.lblStastus = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPLId = new System.Windows.Forms.TextBox();
            this.txtPMId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxEmpData = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatusShow = new System.Windows.Forms.Label();
            this.lblPMShow = new System.Windows.Forms.Label();
            this.lblPLShow = new System.Windows.Forms.Label();
            this.lblNameShow = new System.Windows.Forms.Label();
            this.cmboxStatus = new System.Windows.Forms.ComboBox();
            this.btnSure = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(27, 56);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "项目名称";
            // 
            // lblPLid
            // 
            this.lblPLid.AutoSize = true;
            this.lblPLid.Location = new System.Drawing.Point(27, 107);
            this.lblPLid.Name = "lblPLid";
            this.lblPLid.Size = new System.Drawing.Size(17, 12);
            this.lblPLid.TabIndex = 1;
            this.lblPLid.Text = "PL";
            // 
            // lblPMId
            // 
            this.lblPMId.AutoSize = true;
            this.lblPMId.Location = new System.Drawing.Point(27, 162);
            this.lblPMId.Name = "lblPMId";
            this.lblPMId.Size = new System.Drawing.Size(17, 12);
            this.lblPMId.TabIndex = 2;
            this.lblPMId.Text = "PM";
            // 
            // lblStastus
            // 
            this.lblStastus.AutoSize = true;
            this.lblStastus.Location = new System.Drawing.Point(27, 209);
            this.lblStastus.Name = "lblStastus";
            this.lblStastus.Size = new System.Drawing.Size(53, 12);
            this.lblStastus.TabIndex = 3;
            this.lblStastus.Text = "是否启动";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(86, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 1;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // txtPLId
            // 
            this.txtPLId.Location = new System.Drawing.Point(86, 103);
            this.txtPLId.Name = "txtPLId";
            this.txtPLId.Size = new System.Drawing.Size(100, 21);
            this.txtPLId.TabIndex = 2;
            this.txtPLId.TextChanged += new System.EventHandler(this.txtPLId_TextChanged);
            this.txtPLId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPLId_KeyDown);
            this.txtPLId.Leave += new System.EventHandler(this.txtPLId_Leave);
            // 
            // txtPMId
            // 
            this.txtPMId.Location = new System.Drawing.Point(86, 153);
            this.txtPMId.Name = "txtPMId";
            this.txtPMId.Size = new System.Drawing.Size(100, 21);
            this.txtPMId.TabIndex = 4;
            this.txtPMId.TextChanged += new System.EventHandler(this.txtPMId_TextChanged);
            this.txtPMId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPMId_KeyDown);
            this.txtPMId.Leave += new System.EventHandler(this.txtPMId_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxEmpData);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblStatusShow);
            this.groupBox1.Controls.Add(this.lblPMShow);
            this.groupBox1.Controls.Add(this.lblPLShow);
            this.groupBox1.Controls.Add(this.lblNameShow);
            this.groupBox1.Controls.Add(this.cmboxStatus);
            this.groupBox1.Controls.Add(this.txtPLId);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtPMId);
            this.groupBox1.Controls.Add(this.lblPLid);
            this.groupBox1.Controls.Add(this.lblPMId);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblStastus);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 285);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // listBoxEmpData
            // 
            this.listBoxEmpData.FormattingEnabled = true;
            this.listBoxEmpData.ItemHeight = 12;
            this.listBoxEmpData.Location = new System.Drawing.Point(243, 107);
            this.listBoxEmpData.Name = "listBoxEmpData";
            this.listBoxEmpData.Size = new System.Drawing.Size(120, 88);
            this.listBoxEmpData.TabIndex = 3;
            this.listBoxEmpData.Visible = false;
            this.listBoxEmpData.Click += new System.EventHandler(this.listBoxEmpData_Click);
            this.listBoxEmpData.DoubleClick += new System.EventHandler(this.btnClear_Click);
            this.listBoxEmpData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxEmpData_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "带 * 为必填项";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(10, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(10, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(10, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "*";
            // 
            // lblStatusShow
            // 
            this.lblStatusShow.AutoSize = true;
            this.lblStatusShow.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStatusShow.ForeColor = System.Drawing.Color.Red;
            this.lblStatusShow.Location = new System.Drawing.Point(192, 204);
            this.lblStatusShow.Name = "lblStatusShow";
            this.lblStatusShow.Size = new System.Drawing.Size(35, 10);
            this.lblStatusShow.TabIndex = 8;
            this.lblStatusShow.Text = "label4";
            // 
            // lblPMShow
            // 
            this.lblPMShow.AutoSize = true;
            this.lblPMShow.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPMShow.ForeColor = System.Drawing.Color.Red;
            this.lblPMShow.Location = new System.Drawing.Point(192, 162);
            this.lblPMShow.Name = "lblPMShow";
            this.lblPMShow.Size = new System.Drawing.Size(35, 10);
            this.lblPMShow.TabIndex = 7;
            this.lblPMShow.Text = "label3";
            // 
            // lblPLShow
            // 
            this.lblPLShow.AutoSize = true;
            this.lblPLShow.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPLShow.ForeColor = System.Drawing.Color.Red;
            this.lblPLShow.Location = new System.Drawing.Point(192, 107);
            this.lblPLShow.Name = "lblPLShow";
            this.lblPLShow.Size = new System.Drawing.Size(35, 10);
            this.lblPLShow.TabIndex = 6;
            this.lblPLShow.Text = "label2";
            // 
            // lblNameShow
            // 
            this.lblNameShow.AutoSize = true;
            this.lblNameShow.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNameShow.ForeColor = System.Drawing.Color.Red;
            this.lblNameShow.Location = new System.Drawing.Point(192, 56);
            this.lblNameShow.Name = "lblNameShow";
            this.lblNameShow.Size = new System.Drawing.Size(35, 10);
            this.lblNameShow.TabIndex = 5;
            this.lblNameShow.Text = "label1";
            // 
            // cmboxStatus
            // 
            this.cmboxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxStatus.FormattingEnabled = true;
            this.cmboxStatus.Items.AddRange(new object[] {
            "已激活",
            "未激活"});
            this.cmboxStatus.Location = new System.Drawing.Point(86, 201);
            this.cmboxStatus.Name = "cmboxStatus";
            this.cmboxStatus.Size = new System.Drawing.Size(100, 20);
            this.cmboxStatus.TabIndex = 6;
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(194, 303);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(64, 25);
            this.btnSure.TabIndex = 6;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(40, 303);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(64, 25);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FrmProAddOrUpdate
            // 
            this.AcceptButton = this.btnSure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 364);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProAddOrUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmProAddOrUpdate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPLid;
        private System.Windows.Forms.Label lblPMId;
        private System.Windows.Forms.Label lblStastus;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPLId;
        private System.Windows.Forms.TextBox txtPMId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Label lblPMShow;
        private System.Windows.Forms.Label lblPLShow;
        private System.Windows.Forms.Label lblNameShow;
        private System.Windows.Forms.ComboBox cmboxStatus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatusShow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxEmpData;
      
    }
}