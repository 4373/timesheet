namespace TimeSheet
{
    partial class FrmOvertimeAddOrUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOvertimeAddOrUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.TimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.btnSure = new System.Windows.Forms.Button();
            this.listBoxShow = new System.Windows.Forms.ListBox();
            this.cBoxNextDay = new System.Windows.Forms.CheckBox();
            this.myTxtReason = new TimeSheet.UsrUI.MyTextBox();
            this.myTxtProPLName = new TimeSheet.UsrUI.MyTextBox();
            this.myTxtProName = new TimeSheet.UsrUI.MyTextBox();
            this.myTxtEmpName = new TimeSheet.UsrUI.MyTextBox();
            this.myTxtEmpId = new TimeSheet.UsrUI.MyTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "工号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "所属项目名:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "直属PL名:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "加班时间:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "到";
            // 
            // TimePickerFrom
            // 
            this.TimePickerFrom.CustomFormat = "HH\':\'mm";
            this.TimePickerFrom.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.TimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimePickerFrom.Location = new System.Drawing.Point(108, 183);
            this.TimePickerFrom.Name = "TimePickerFrom";
            this.TimePickerFrom.ShowUpDown = true;
            this.TimePickerFrom.Size = new System.Drawing.Size(52, 21);
            this.TimePickerFrom.TabIndex = 4;
            // 
            // TimePickerTo
            // 
            this.TimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimePickerTo.Location = new System.Drawing.Point(263, 183);
            this.TimePickerTo.Name = "TimePickerTo";
            this.TimePickerTo.ShowUpDown = true;
            this.TimePickerTo.Size = new System.Drawing.Size(51, 21);
            this.TimePickerTo.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "加班原因:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(273, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 21);
            this.label8.TabIndex = 16;
            this.label8.Text = "加 班 申 请 单";
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(550, 49);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(132, 21);
            this.dateTime.TabIndex = 0;
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(607, 231);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(62, 23);
            this.btnSure.TabIndex = 7;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // listBoxShow
            // 
            this.listBoxShow.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxShow.FormattingEnabled = true;
            this.listBoxShow.ItemHeight = 12;
            this.listBoxShow.Location = new System.Drawing.Point(403, 81);
            this.listBoxShow.Name = "listBoxShow";
            this.listBoxShow.Size = new System.Drawing.Size(117, 40);
            this.listBoxShow.TabIndex = 3;
            this.listBoxShow.Visible = false;
            this.listBoxShow.Click += new System.EventHandler(this.listBoxShow_Click);
            // 
            // cBoxNextDay
            // 
            this.cBoxNextDay.AutoSize = true;
            this.cBoxNextDay.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.cBoxNextDay.Location = new System.Drawing.Point(195, 185);
            this.cBoxNextDay.Name = "cBoxNextDay";
            this.cBoxNextDay.Size = new System.Drawing.Size(60, 16);
            this.cBoxNextDay.TabIndex = 17;
            this.cBoxNextDay.Text = "第二日";
            this.cBoxNextDay.UseVisualStyleBackColor = true;
            this.cBoxNextDay.CheckedChanged += new System.EventHandler(this.cBoxNextDay_CheckedChanged);
            // 
            // myTxtReason
            // 
            this.myTxtReason.Location = new System.Drawing.Point(403, 181);
            this.myTxtReason.Name = "myTxtReason";
            this.myTxtReason.Size = new System.Drawing.Size(278, 23);
            this.myTxtReason.TabIndex = 6;
            // 
            // myTxtProPLName
            // 
            this.myTxtProPLName.Enabled = false;
            this.myTxtProPLName.Location = new System.Drawing.Point(599, 101);
            this.myTxtProPLName.Name = "myTxtProPLName";
            this.myTxtProPLName.Size = new System.Drawing.Size(82, 23);
            this.myTxtProPLName.TabIndex = 3;
            // 
            // myTxtProName
            // 
            this.myTxtProName.Location = new System.Drawing.Point(403, 101);
            this.myTxtProName.Name = "myTxtProName";
            this.myTxtProName.Size = new System.Drawing.Size(117, 23);
            this.myTxtProName.TabIndex = 6;
            this.myTxtProName.Enter += new System.EventHandler(this.myTxtProName_Enter);
            // 
            // myTxtEmpName
            // 
            this.myTxtEmpName.Enabled = false;
            this.myTxtEmpName.Location = new System.Drawing.Point(232, 101);
            this.myTxtEmpName.Name = "myTxtEmpName";
            this.myTxtEmpName.Size = new System.Drawing.Size(82, 23);
            this.myTxtEmpName.TabIndex = 2;
            // 
            // myTxtEmpId
            // 
            this.myTxtEmpId.Enabled = false;
            this.myTxtEmpId.Location = new System.Drawing.Point(84, 101);
            this.myTxtEmpId.Name = "myTxtEmpId";
            this.myTxtEmpId.Size = new System.Drawing.Size(90, 23);
            this.myTxtEmpId.TabIndex = 1;
            // 
            // FrmOvertimeAddOrUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 280);
            this.Controls.Add(this.cBoxNextDay);
            this.Controls.Add(this.listBoxShow);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.myTxtReason);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TimePickerTo);
            this.Controls.Add(this.TimePickerFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.myTxtProPLName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.myTxtProName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.myTxtEmpName);
            this.Controls.Add(this.myTxtEmpId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmOvertimeAddOrUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOvertimeAddOrUpdate";
            this.Load += new System.EventHandler(this.FrmOvertimeAddOrUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private UsrUI.MyTextBox myTxtEmpId;
        private UsrUI.MyTextBox myTxtEmpName;
        private System.Windows.Forms.Label label3;
        private UsrUI.MyTextBox myTxtProName;
        private System.Windows.Forms.Label label4;
        private UsrUI.MyTextBox myTxtProPLName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker TimePickerFrom;
        private System.Windows.Forms.DateTimePicker TimePickerTo;
        private System.Windows.Forms.Label label7;
        private UsrUI.MyTextBox myTxtReason;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.ListBox listBoxShow;
        private System.Windows.Forms.CheckBox cBoxNextDay;
    }
}