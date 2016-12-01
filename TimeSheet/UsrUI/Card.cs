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
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
            label1.BackColor = Color.White;
        }

        public void setText(string a)
        {
            label1.Text = a;
        }

        public event Action ClickIt;
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.DeepSkyBlue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (ClickIt != null) ClickIt();
        }
    }
}
