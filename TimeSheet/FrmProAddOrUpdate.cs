using BLL;
using Common;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TimeSheet
{
    public partial class FrmProAddOrUpdate : Form
    {
        const string TITLE_ADD_PRO = "添加项目";
        const string TITLE_UPDATE_PRO = "更新项目";
        const string SHOW_ADD_SUCESS = "添加成功";
        const string SHOW_PLEASE_CHECK = "请检查必须项";
        const string LBLSHOW_NAME_IS_NULL = "请输入项目名称";
        const string LBLSHOW_PL_IS_NULL = "请输入PLId";
        const string LBLSHOW_PM_IS_NULL = "请输入PMId";
        const string LBLSHOW_PRONAME_IS_EXIST = "项目名已存在";
        const string LBLSHOW_EMP_ID_ISNOT_EXIST = "员工号不存在";
        const string SHOW_UPDATE_SUCESS = "更新成功";
        const string SHOW_INPUT_TIPS_MESSAGE = "请选择下拉框中信息填入";


        public FrmProAddOrUpdate(Project pro)
        {

            InitializeComponent();
            if (pro != null)
            {
                //update
                this.Text = TITLE_UPDATE_PRO;
                txtName.Enabled = false;
                txtName.Text = pro.PName;
                //txtPLId.Text = pro.PLId;
                //txtPMId.Text = pro.PMId;
                cmboxStatus.SelectedIndex = pro.Status == "已激活" ? 0 : 1;
                return;
            }
            //add
            this.Text = TITLE_ADD_PRO;
            cmboxStatus.Visible = false;
            lblStastus.Visible = false;
        }

        private void FrmProAddOrUpdate_Load(object sender, EventArgs e)
        {
            cmboxStatus.SelectedIndex = 0;
            lblNameShow.Text = "";
            lblPLShow.Text = "";
            lblPMShow.Text = "";
            lblStatusShow.Text = "";
        }


        //点击确定按钮
        private void btnSure_Click(object sender, EventArgs e)
        {
            //添加项目
            if (this.Text == TITLE_ADD_PRO)
            {
                ProjectBll proBll = new ProjectBll();
                Project pro = new Project();

                if (!Tool.isNull(txtName.Text) && !Tool.isNull(txtPLId.Text) && !Tool.isNull(txtPMId.Text))
                {

                    if (txtPLId.Tag == null )//|| txtPMId.Tag == null)
                    {
                        MessageBox.Show(SHOW_INPUT_TIPS_MESSAGE);
                        txtPLId.Focus();
                        return;
                    }
                    if (txtPMId.Tag==null)
                    {
                        MessageBox.Show(SHOW_INPUT_TIPS_MESSAGE);
                        txtPMId.Focus();
                        return;
                    }
                    pro.PName = txtName.Text.Trim();
                    pro.PLId = txtPLId.Tag.ToString().ToUpper();
                    pro.PMId = txtPMId.Tag.ToString().ToUpper();
                    pro.Status = cmboxStatus.SelectedIndex == 1 ? "未激活" : "已激活";
                    bool a = proBll.IsNameExist(pro.PName);
                    if (a)
                    {
                        lblNameShow.Text = LBLSHOW_PRONAME_IS_EXIST;
                        return;
                    }
                    bool b = proBll.ProAdd(pro);
                    if (b)
                    {
                        MessageBox.Show(SHOW_ADD_SUCESS);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(SHOW_PLEASE_CHECK);
                    if (txtName.Text==string.Empty)
                    {
                        txtName.Focus();
                        return;
                    }
                    if (txtPLId.Text == string.Empty)
                    {
                        txtPLId.Focus();
                        return;
                    }
                    if (txtPMId.Text == string.Empty)
                    {
                        txtPMId.Focus();
                        return;
                    }
                }
            }

            //更新项目
            else
            {
                ProjectBll proBll = new ProjectBll();
                Project pro = new Project();


                if (!Tool.isNull(txtName.Text) && !Tool.isNull(txtPLId.Text) && !Tool.isNull(txtPMId.Text))
                {
                    if (txtPLId.Tag == null)//|| txtPMId.Tag == null)
                    {
                        MessageBox.Show(SHOW_INPUT_TIPS_MESSAGE);
                        txtPLId.Focus();
                        return;
                    }
                    if (txtPMId.Tag == null)
                    {
                        MessageBox.Show(SHOW_INPUT_TIPS_MESSAGE);
                        txtPMId.Focus();
                        return;
                    }
                    pro.PName = txtName.Text.Trim();
                    pro.PLId = txtPLId.Tag.ToString().ToUpper();
                    pro.PMId = txtPMId.Tag.ToString().ToUpper();
                    pro.Status = cmboxStatus.SelectedIndex == 1 ? "未激活" : "已激活";


                    bool b = proBll.UpdatePro(pro);
                    if (b)
                    {
                        MessageBox.Show(SHOW_UPDATE_SUCESS);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(SHOW_PLEASE_CHECK);
                    if (txtName.Text == string.Empty)
                    {
                        txtName.Focus();
                        return;
                    }
                    if (txtPLId.Text == string.Empty)
                    {
                        txtPLId.Focus();
                        return;
                    }
                    if (txtPMId.Text == string.Empty)
                    {
                        txtPMId.Focus();
                        return;
                    }
                }
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            ProjectBll proBll = new ProjectBll();
            if (Tool.isNull(txtName.Text.Trim()))
            {
                lblNameShow.Text = LBLSHOW_NAME_IS_NULL;
                txtName.Text = "";
                //txtName.Focus();
                return;
            }
            bool b = proBll.IsNameExist(txtName.Text.Trim());
            if (b)
            {
                lblNameShow.Text = LBLSHOW_PRONAME_IS_EXIST;
                txtName.Text = "";
               // txtName.Focus();
                return;
            }
            lblNameShow.Text = "";
        }

        private void txtPLId_Leave(object sender, EventArgs e)
        {
            //EmployeeBll empBll = new EmployeeBll();
            if (Tool.isNull(txtPLId.Text.Trim()))
            {
                lblPLShow.Text = LBLSHOW_PL_IS_NULL;
                txtPLId.Text = "";
               // txtPLId.Focus();
                return;
            }
            //bool b = empBll.IsIdExist(txtPLId.Tag.ToString());
            //if (!b)
            //{
            //    lblPLShow.Text = LBLSHOW_EMP_ID_ISNOT_EXIST;
            //    txtPLId.Text = "";
            //    return;
            //}
            lblPLShow.Text = "";
        }

        private void txtPMId_Leave(object sender, EventArgs e)
        {
            //EmployeeBll empBll = new EmployeeBll();
            if (Tool.isNull(txtPMId.Text.Trim()))
            {
                lblPMShow.Text = LBLSHOW_PM_IS_NULL;
                txtPMId.Text = "";
                //txtPMId.Focus();
                return;
            }
            //bool b = empBll.IsIdExist(txtPMId.Tag.ToString());
            //if (!b)
            //{
            //    lblPMShow.Text = LBLSHOW_EMP_ID_ISNOT_EXIST;
            //    txtPMId.Text = "";
            //    return;
            //}
            lblPMShow.Text = "";
        }
        //清除按钮
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (this.Text==TITLE_ADD_PRO)
            {
                txtName.Text = "";
                txtName.Focus();
                txtPLId.Text = "";
                txtPMId.Text = "";
                lblNameShow.Text = "";
                lblPLShow.Text = "";
                lblPMShow.Text = "";
            }
            else
            {
                txtPLId.Text = "";
                txtPMId.Text = "";
                txtPLId.Focus();
                lblNameShow.Text = "";
                lblPLShow.Text = "";
                lblPMShow.Text = "";
            }
        }

        //PLId文本框改变时
        private void txtPLId_TextChanged(object sender, EventArgs e)
       {
            txtPLId.Tag = null;
            listBoxEmpData.Items.Clear();
            if (txtPLId.Text != string.Empty)
            {
                listBoxEmpData.Visible = true;
                this.listBoxEmpData.Location = new Point(txtPLId.Location.X, txtPLId.Location.Y + 22);
                EmployeeBll empBll = new EmployeeBll();
                var data = empBll.QueryLikeThis(txtPLId.Text);
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        listBoxEmpData.Items.Add(item.Id + "_" + item.Name);
                    }  
                }
                else
                {
                    listBoxEmpData.Visible = false;
                }
            }
            else
            {
                listBoxEmpData.Visible = false;
            }
        }

        //pmId文本框改变时
        private void txtPMId_TextChanged(object sender, EventArgs e)
        {
            txtPMId.Tag = null;
            listBoxEmpData.Items.Clear();
            if (txtPMId.Text != string.Empty)
            {
                listBoxEmpData.Visible = true;
                this.listBoxEmpData.Location = new Point(txtPMId.Location.X, txtPMId.Location.Y + 22);
                EmployeeBll empBll = new EmployeeBll();
                var data = empBll.QueryLikeThis(txtPMId.Text);
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        listBoxEmpData.Items.Add(item.Id + "_" + item.Name);
                    }
                }
                else
                {
                    listBoxEmpData.Visible = false;
                }
            }
            else
            {
                listBoxEmpData.Visible = false;
            }
        }




        //按下向下键和向上键时
        private void txtPLId_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBoxEmpData.Visible != true)
            {
                return;
            }

            if (e.KeyValue == Convert.ToChar(Keys.Down) || e.KeyValue == Convert.ToChar(Keys.Up))
            {

                if (listBoxEmpData.Items != null)
                {
                    listBoxEmpData.Focus();
                    listBoxEmpData.SelectedItem = listBoxEmpData.Items[0];
                    this.AcceptButton = null;//////////////////////
                }
            }
        }
        private void txtPMId_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBoxEmpData.Visible != true)
            {
                return;
            }
            if (e.KeyValue == Convert.ToChar(Keys.Down) || e.KeyValue == Convert.ToChar(Keys.Up))
            {

                if (listBoxEmpData.Items != null)
                {
                    listBoxEmpData.Focus();
                    listBoxEmpData.SelectedItem = listBoxEmpData.Items[0];
                    this.AcceptButton = null;//////////////////////
                }
            }
        }

        private void listBoxEmpData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                if (listBoxEmpData.SelectedItem==null)
                {
                    return;
                }
                
                string id = listBoxEmpData.SelectedItem.ToString().Split('_')[0];
                string name = listBoxEmpData.SelectedItem.ToString().Split('_')[1];
                int location = listBoxEmpData.Location.Y - 22;
                string str = "";
                string pl = "PL";
                string pm = "PM";
                if (location == txtPLId.Location.Y)
                {
                    str = pl;
                } if (location == txtPMId.Location.Y)
                {
                    str = pm;
                }
                switch (str)
                {
                    case "PL":
                        txtPLId.Text = name;
                        txtPLId.Tag = id;
                        listBoxEmpData.TabIndex = 3;
                        this.AcceptButton = btnSure;///////////////
                        break;
                    case "PM":
                        txtPMId.Text = name;
                        txtPMId.Tag = id; 
                        listBoxEmpData.TabIndex = 5;
                        this.AcceptButton = btnSure;///////////////
                        break;
                }
                listBoxEmpData.Visible = false;
            }
                    
        }

        private void listBoxEmpData_Click(object sender, EventArgs e)
        {
            if (listBoxEmpData.SelectedItem==null)
            {
                return;
            }
            string id = listBoxEmpData.SelectedItem.ToString().Split('_')[0];
            string name = listBoxEmpData.SelectedItem.ToString().Split('_')[1];
            int location = listBoxEmpData.Location.Y - 22;
            string str = "";
            string pl = "PL";
            string pm = "PM";
            if (location == txtPLId.Location.Y)
            {
                str = pl;
            } if (location == txtPMId.Location.Y)
            {
                str = pm;
            }
            switch (str)
            {
                case "PL":
                    txtPLId.Text = name;
                    txtPLId.Tag = id;
                    listBoxEmpData.TabIndex = 5;
                    break;
                case "PM":
                    txtPMId.Text = name;
                    txtPMId.Tag = id;
                    listBoxEmpData.TabIndex = 3;
                    break;
                default:
                    break;
            }
            listBoxEmpData.Visible = false;
        }
    }
}

