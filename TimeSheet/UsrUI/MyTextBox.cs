using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSheet.UsrUI
{
    public partial class MyTextBox : UserControl
    {
        //[Description("通过设置字体大小来调节行高")]
        //[DefaultValue(12)]
        //public int FontSize { get; set{ this.textBox1.Font= new Font (}
            
        //    ; }
        public MyTextBox()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            this.textBox1.Text = text;
        }

        public void Clear()
        {
            this.textBox1.Text=string.Empty;
        }

       public event Action<string> OnMyTextChange;
        public string GetText()
        {
            return this.textBox1.Text;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            
            this.Height = 23;
            this.textBox1.Width = this.Width;
            this.textBox1.Height = this.Height-5;
            //GDI+绘图
            e.Graphics.DrawLine(new Pen(Brushes.Black,2), new Point(0, this.Height), new Point(this.Width, this.Height));
            this.textBox1.BackColor = this.BackColor;
            
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (OnMyTextChange!=null)
            {
                OnMyTextChange(this.textBox1.Text);
            }
        }
    }
    
}
