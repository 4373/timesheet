namespace TimeSheet
{
    partial class FrmMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.card5 = new TimeSheet.UsrUI.Card();
            this.card4 = new TimeSheet.UsrUI.Card();
            this.card3 = new TimeSheet.UsrUI.Card();
            this.card2 = new TimeSheet.UsrUI.Card();
            this.card1 = new TimeSheet.UsrUI.Card();
            this.SuspendLayout();
            // 
            // card5
            // 
            this.card5.Location = new System.Drawing.Point(480, 414);
            this.card5.Name = "card5";
            this.card5.Size = new System.Drawing.Size(112, 42);
            this.card5.TabIndex = 4;
            // 
            // card4
            // 
            this.card4.Location = new System.Drawing.Point(362, 414);
            this.card4.Name = "card4";
            this.card4.Size = new System.Drawing.Size(112, 42);
            this.card4.TabIndex = 3;
            // 
            // card3
            // 
            this.card3.Location = new System.Drawing.Point(244, 414);
            this.card3.Name = "card3";
            this.card3.Size = new System.Drawing.Size(112, 42);
            this.card3.TabIndex = 2;
            // 
            // card2
            // 
            this.card2.Location = new System.Drawing.Point(126, 414);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(112, 42);
            this.card2.TabIndex = 1;
            // 
            // card1
            // 
            this.card1.Location = new System.Drawing.Point(8, 414);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(112, 42);
            this.card1.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::TimeSheet.Properties.Resources.ts;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(599, 502);
            this.Controls.Add(this.card5);
            this.Controls.Add(this.card4);
            this.Controls.Add(this.card3);
            this.Controls.Add(this.card2);
            this.Controls.Add(this.card1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主界面";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UsrUI.Card card1;
        private UsrUI.Card card2;
        private UsrUI.Card card3;
        private UsrUI.Card card4;
        private UsrUI.Card card5;


    }
}

