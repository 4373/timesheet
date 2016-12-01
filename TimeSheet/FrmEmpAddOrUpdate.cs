using Common;
using System;
using System.Windows.Forms;
using BLL;


namespace TimeSheet
{
    public partial class FrmEmpAddOrUpdate : Form
    {
        const string TITLE_UPDATE_EMPLOYEE_INFO = "更新员工信息";
        const string TITLE_ADD_EMPLOYEE_INFO = "添加员工信息";
        const string SHOW_ID_IS_NULL = "请输入员工号";
        const string SHOW_ID_IS_EXIST = "员工号存在";
        const string SHOW_NAME_IS_NULL = "请输入员工名";
        const string SHOW_EMAIL_IS_NULL = "请输入员工邮箱";
        const string SHOW_UPDATE_SUCESS = "更新成功";
        const string SHOW_UPDATE_DEFEAT = "更新失败";
        const string SHOW_ADD_SUCESS = "添加成功";
        const string SHOW_ADD_DEFEAT = "添加失败";
        const string SHOW_PLEASE_CHECK_MUST_NEED = "请检查必填项";
        const string EMAIL_POSTFIX = "@pactera.com";
        const string SHOW_MOBILE_ILLEGAL = "手机号输入有误";
        const string SHOW_EMAIL_NAME_ILLEGAL = "邮箱名不合法";
        const string SHOW_ID_IS_ILLEGAL = "员工号不合法";

        EmployeeBll empBll = new EmployeeBll();
        public FrmEmpAddOrUpdate(Employee emp)
        {
            InitializeComponent();

            if (emp != null)
            {
                //将标题改为更新
                this.Text = TITLE_UPDATE_EMPLOYEE_INFO;
                txtId.Text = emp.Id;
                txtId.Enabled = false;
                txtName.Text = emp.Name;
                txtEmail.Text = emp.Email.Split('@')[0];
                txtMobile.Text = emp.Mobile;
                txtTelephone.Text = emp.Telephone;
                return;
            }
            //将标题改为增加
            this.Text = TITLE_ADD_EMPLOYEE_INFO;

        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {

            //更新员工
            if (this.Text.Equals(TITLE_UPDATE_EMPLOYEE_INFO))
            {
                if (!Tool.isNull(txtId.Text) && !Tool.isNull(txtName.Text) && !Tool.isNull(txtEmail.Text))
                {
                    Employee emp = new Employee();
                    emp.Id = txtId.Text.ToUpper().Trim();
                    emp.Name = txtName.Text.Trim();
                    emp.Email = txtEmail.Text.Trim() + "@pactera.com";
                    emp.Telephone = txtTelephone.Text.Trim();
                    emp.Mobile = txtMobile.Text.Trim();
                    if (empBll.UpdateEmp(emp))
                    {
                        MessageBox.Show(SHOW_UPDATE_SUCESS);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        MessageBox.Show(SHOW_UPDATE_DEFEAT);
                    }
                }
                else
                {
                    MessageBox.Show(SHOW_PLEASE_CHECK_MUST_NEED);

                    return;
                }
            }
            //增加员工
            else
            {
                if (!Tool.isNull(txtId.Text) && !Tool.isNull(txtName.Text) && !Tool.isNull(txtEmail.Text))
                {
                    Employee emp = new Employee();
                    emp.Id = txtId.Text.ToUpper().Trim();
                    emp.Name = txtName.Text.Trim();
                    emp.Email = txtEmail.Text.Trim() + EMAIL_POSTFIX;
                    emp.Telephone = txtTelephone.Text.Trim();
                    emp.Mobile = txtMobile.Text.Trim();
                    if (empBll.AddEmployee(emp))
                    {
                        MessageBox.Show(SHOW_ADD_SUCESS);
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(SHOW_ADD_DEFEAT);
                    }
                }
                else
                {
                    MessageBox.Show(SHOW_PLEASE_CHECK_MUST_NEED);
                    return;
                }
            }
        }

        //判断员工id
        private void txtId_Leave(object sender, EventArgs e)
        {
            lblIdShow.Text = "";
            lblEmailShow.Text = "";
            lblNameShow.Text = "";
            if (Tool.isNull(txtId.Text))
            {
                lblIdShow.Text = SHOW_ID_IS_NULL;
                //txtId.Focus();
                return;
            }
            if (!empBll.IdIsNumOrChar(txtId.Text))
            {
                lblIdShow.Text = SHOW_ID_IS_ILLEGAL;
                txtId.Text = "";
                // txtId.Focus();
                return;
            }
            if (empBll.IsIdExist(txtId.Text))
            {
                if (this.Text != TITLE_UPDATE_EMPLOYEE_INFO)
                {
                    lblIdShow.Text = SHOW_ID_IS_EXIST;
                    // txtId.Focus();
                    return;
                }
            }
        }
        //判断员工姓名
        private void txtName_Leave(object sender, EventArgs e)
        {
            if (Tool.isNull(txtName.Text))
            {
                lblNameShow.Text = SHOW_NAME_IS_NULL;
                // txtName.Focus();
                return;
            }
        }
        //判断员工邮箱
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (Tool.isNull(txtEmail.Text))
            {
                lblEmailShow.Text = SHOW_EMAIL_IS_NULL;
                //    txtEmail.Focus();
                return;
            } if (!empBll.IsNumOrChar(txtEmail.Text))
            {
                lblEmailShow.Text = SHOW_EMAIL_NAME_ILLEGAL;
                txtEmail.Text = "";
                //  txtEmail.Focus();
            }
            else
            {
                lblEmailShow.Text = "";
            }
        }
        //重置按钮
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (this.Text == TITLE_ADD_EMPLOYEE_INFO)
            {
                txtId.Text = "";
                txtName.Text = "";
                txtEmail.Text = "";
                txtTelephone.Text = "";
                txtMobile.Text = "";
                txtId.Focus();
                lblEmailShow.Text = "";
                lblIdShow.Text = "";
                lblMobileShow.Text = "";
                lblNameShow.Text = "";
                return;

            }
            txtName.Text = "";
            txtEmail.Text = "";
            txtTelephone.Text = "";
            txtMobile.Text = "";
            txtName.Focus();
            lblEmailShow.Text = "";
            lblIdShow.Text = "";
            lblMobileShow.Text = "";
            lblNameShow.Text = "";
        }
        //判断员工手机
        private void txtMobile_Leave(object sender, EventArgs e)
        {
            if (txtMobile.Text.Trim() == "" || txtMobile.Text == null)
            {
                return;
            }
            if (!empBll.IsMobileLegal(txtMobile.Text.Trim()))
            {
                lblMobileShow.Text = SHOW_MOBILE_ILLEGAL;
                txtMobile.Text = "";
                // txtMobile.Focus();
            }
            else
            {
                lblMobileShow.Text = "";
            }

        }
    }
}
