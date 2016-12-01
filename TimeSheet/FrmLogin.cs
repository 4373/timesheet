using BLL;
using System;
using System.Windows.Forms;

namespace TimeSheet
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (LoginBll.IdExist(TxtId.Text.ToUpper()))
            {
                if (LoginBll.IsLogin(TxtId.Text.ToUpper(),TxtPassword.Text))
                {
                    Text = TxtId.Text;
                    DialogResult=DialogResult.OK;
                    Close();
                }
                else
                {
                    label1.Text = "密码输入有误";
                }
            }
            else
            {
                label1.Text = "用户不存在";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            TxtPassword.Text = "";
        }
    }
}
