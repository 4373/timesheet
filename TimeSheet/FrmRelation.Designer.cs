namespace TimeSheet
{
    partial class FrmRelation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelation));
            this.listBoxPro = new System.Windows.Forms.ListBox();
            this.listBoxEmp = new System.Windows.Forms.ListBox();
            this.listBoxOtherEmp = new System.Windows.Forms.ListBox();
            this.btnOutput = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPM = new System.Windows.Forms.Label();
            this.textBoxPro = new System.Windows.Forms.TextBox();
            this.textBoxEmp = new System.Windows.Forms.TextBox();
            this.textBoxOther = new System.Windows.Forms.TextBox();
            this.lblProName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxPro
            // 
            this.listBoxPro.FormattingEnabled = true;
            this.listBoxPro.ItemHeight = 12;
            this.listBoxPro.Location = new System.Drawing.Point(79, 123);
            this.listBoxPro.Name = "listBoxPro";
            this.listBoxPro.Size = new System.Drawing.Size(141, 280);
            this.listBoxPro.Sorted = true;
            this.listBoxPro.TabIndex = 1;
            this.listBoxPro.SelectedIndexChanged += new System.EventHandler(this.listBoxPro_SelectedIndexChanged);
            // 
            // listBoxEmp
            // 
            this.listBoxEmp.FormattingEnabled = true;
            this.listBoxEmp.ItemHeight = 12;
            this.listBoxEmp.Location = new System.Drawing.Point(301, 147);
            this.listBoxEmp.Name = "listBoxEmp";
            this.listBoxEmp.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxEmp.Size = new System.Drawing.Size(150, 256);
            this.listBoxEmp.TabIndex = 4;
            // 
            // listBoxOtherEmp
            // 
            this.listBoxOtherEmp.FormattingEnabled = true;
            this.listBoxOtherEmp.ItemHeight = 12;
            this.listBoxOtherEmp.Location = new System.Drawing.Point(569, 87);
            this.listBoxOtherEmp.Name = "listBoxOtherEmp";
            this.listBoxOtherEmp.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxOtherEmp.Size = new System.Drawing.Size(148, 316);
            this.listBoxOtherEmp.TabIndex = 7;
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(475, 205);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 5;
            this.btnOutput.Text = "-->";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(475, 274);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(75, 23);
            this.btnInput.TabIndex = 8;
            this.btnInput.Text = "<--";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(642, 436);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "确定修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(77, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(299, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "项目员工";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(567, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "其他员工";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "PL:";
            // 
            // lblPL
            // 
            this.lblPL.AutoSize = true;
            this.lblPL.Location = new System.Drawing.Point(337, 87);
            this.lblPL.Name = "lblPL";
            this.lblPL.Size = new System.Drawing.Size(0, 12);
            this.lblPL.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "PM:";
            // 
            // lblPM
            // 
            this.lblPM.AutoSize = true;
            this.lblPM.Location = new System.Drawing.Point(337, 63);
            this.lblPM.Name = "lblPM";
            this.lblPM.Size = new System.Drawing.Size(0, 12);
            this.lblPM.TabIndex = 12;
            // 
            // textBoxPro
            // 
            this.textBoxPro.ForeColor = System.Drawing.Color.Silver;
            this.textBoxPro.Location = new System.Drawing.Point(79, 87);
            this.textBoxPro.Name = "textBoxPro";
            this.textBoxPro.Size = new System.Drawing.Size(141, 21);
            this.textBoxPro.TabIndex = 2;
            this.textBoxPro.Text = "输入项目名进行查询";
            this.textBoxPro.Click += new System.EventHandler(this.textBoxPro_Click);
            this.textBoxPro.TextChanged += new System.EventHandler(this.textBoxPro_TextChanged);
            this.textBoxPro.Leave += new System.EventHandler(this.textBoxPro_Leave);
            // 
            // textBoxEmp
            // 
            this.textBoxEmp.ForeColor = System.Drawing.Color.Silver;
            this.textBoxEmp.Location = new System.Drawing.Point(301, 120);
            this.textBoxEmp.Name = "textBoxEmp";
            this.textBoxEmp.Size = new System.Drawing.Size(150, 21);
            this.textBoxEmp.TabIndex = 3;
            this.textBoxEmp.Text = "输入员工名或工号查询";
            this.textBoxEmp.Click += new System.EventHandler(this.textBoxEmp_Click);
            this.textBoxEmp.TextChanged += new System.EventHandler(this.textBoxEmp_TextChanged);
            this.textBoxEmp.Leave += new System.EventHandler(this.textBoxEmp_Leave);
            // 
            // textBoxOther
            // 
            this.textBoxOther.ForeColor = System.Drawing.Color.Silver;
            this.textBoxOther.Location = new System.Drawing.Point(569, 63);
            this.textBoxOther.Name = "textBoxOther";
            this.textBoxOther.Size = new System.Drawing.Size(148, 21);
            this.textBoxOther.TabIndex = 6;
            this.textBoxOther.Text = "输入员工名或工号查询";
            this.textBoxOther.Click += new System.EventHandler(this.textBoxOther_Click);
            this.textBoxOther.TextChanged += new System.EventHandler(this.textBoxOther_TextChanged);
            this.textBoxOther.Leave += new System.EventHandler(this.textBoxOther_Leave);
            // 
            // lblProName
            // 
            this.lblProName.AutoSize = true;
            this.lblProName.Location = new System.Drawing.Point(77, 66);
            this.lblProName.Name = "lblProName";
            this.lblProName.Size = new System.Drawing.Size(0, 12);
            this.lblProName.TabIndex = 16;
            // 
            // FrmRelation
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 471);
            this.Controls.Add(this.lblProName);
            this.Controls.Add(this.textBoxOther);
            this.Controls.Add(this.textBoxEmp);
            this.Controls.Add(this.textBoxPro);
            this.Controls.Add(this.lblPM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblPL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.listBoxOtherEmp);
            this.Controls.Add(this.listBoxEmp);
            this.Controls.Add(this.listBoxPro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmRelation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目信息";
            this.Load += new System.EventHandler(this.FrmRelation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPro;
        private System.Windows.Forms.ListBox listBoxEmp;
        private System.Windows.Forms.ListBox listBoxOtherEmp;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPM;
        private System.Windows.Forms.TextBox textBoxPro;
        private System.Windows.Forms.TextBox textBoxEmp;
        private System.Windows.Forms.TextBox textBoxOther;
        private System.Windows.Forms.Label lblProName;
    }
}