using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using Common;

namespace TimeSheet
{
    public partial class FrmEmployee : Form
    {

        public FrmEmployee()
        {
            InitializeComponent();
        }
        FrmEmpAddOrUpdate frmAdd;
        EmployeeBll empBll = new EmployeeBll();
        const string THERE_AER＿NO_MESSAGE = "无该员工信息";
        const string NO_MESSAGE = "无信息";
        const string DELETED_AND_NO_RECOVERY = "删除后不可恢复!确定删除?";

        //添加学生按钮
        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            frmAdd = new FrmEmpAddOrUpdate(null);
            var dialogResult = frmAdd.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = empBll.QueryAll();
            }
        }

        //窗体加载时
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            cmboxIdorName.SelectedIndex = 0;
            cmboxIdorName.DropDownStyle = ComboBoxStyle.DropDownList;
            if (empBll.QueryAll() != null)
            {
                dataGridView1.DataSource = empBll.QueryAll();
            }
        }

        //查询
        private void btnQueryEmp_Click(object sender, EventArgs e)
        {
            //按姓名查询
            if (cmboxIdorName.SelectedIndex == 0)
            {
                dataGridView1.DataSource = null;
                var list = empBll.QueryByName(txtQueryCondition.Text.Trim());
                if (list == null)
                {
                    MessageBox.Show(NO_MESSAGE);
                    return;
                }
                dataGridView1.DataSource = list;
            }

            //按工号查询
            if (cmboxIdorName.SelectedIndex == 1)
            {
                Employee emp = empBll.QueryById(txtQueryCondition.Text.Trim().ToUpper());
                if (emp == null)
                {
                    MessageBox.Show(NO_MESSAGE);
                    return;
                }
                List<Employee> list = new List<Employee>();
                list.Add(emp);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = list;

            }
        }


        //单击删除和更新
        private void dataGridView1_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                //点击删除
                if (e.ColumnIndex == 0)
                {
                    if (MessageBox.Show(DELETED_AND_NO_RECOVERY, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int row = e.RowIndex;
                        string id = dataGridView1.Rows[row].Cells["Id"].Value.ToString();
                        empBll.DeleteEmp(id);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = empBll.QueryAll();

                    }
                }
                //点击更新
                if (e.ColumnIndex == 1)
                {
                    Employee emp = new Employee();
                    int row = e.RowIndex;
                    emp.Id = dataGridView1.Rows[row].Cells["Id"].Value.ToString();
                    emp.Name = dataGridView1.Rows[row].Cells["Name"].Value.ToString();
                    emp.Email = dataGridView1.Rows[row].Cells["Email"].Value.ToString();
                    emp.Mobile = dataGridView1.Rows[row].Cells["Mobile"].Value.ToString();
                    emp.Telephone = dataGridView1.Rows[row].Cells["Telephone"].Value.ToString();
                    FrmEmpAddOrUpdate frmUpdate = new FrmEmpAddOrUpdate(emp);
                    frmUpdate.ShowDialog();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = empBll.QueryAll();
                    return;
                }
            }
        }

        //刷新按钮
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = empBll.QueryAll();
        }

        private void txtQueryCondition_TextChanged(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = null;
            var a = empBll.QueryLikeThis(txtQueryCondition.Text);
            dataGridView1.DataSource = a;
        }
    }
}
