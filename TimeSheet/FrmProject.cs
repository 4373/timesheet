using BLL;
using Common;
using System;
using System.Windows.Forms;

namespace TimeSheet
{
    public partial class FrmProject : Form
    {
        public FrmProject()
        {
            InitializeComponent();
        }
        const string DELETED_AND_NO_RECOVERY = "删除后不可恢复,确定删除?";
        private void FrmProject_Load(object sender, EventArgs e)
        {
            cmboxIdorName.SelectedIndex = 0;
            ProjectBll proBll = new ProjectBll();
            var all =proBll.QueryAll();
            if (all!=null)
            {
                dataGridView1.DataSource = all;
            }
            cmboxIdorName.Visible = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmProAddOrUpdate frmAddPro = new FrmProAddOrUpdate(null);
            
            frmAddPro.ShowDialog();

            //dataGridView1.DataSource = null;
            //dataGridView1.DataSource = new ProjectBll().QueryAll();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                ProjectBll proBll = new ProjectBll();
                //点击删除
                if (e.ColumnIndex == 0)
                {
                    if (MessageBox.Show(DELETED_AND_NO_RECOVERY, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int row = e.RowIndex;
                        string id = dataGridView1.Rows[row].Cells["Id"].Value.ToString();
                        proBll.DeletePro(id);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = proBll.QueryAll();
                    }
                }
                //点击更新
                if (e.ColumnIndex == 1)
                {
                    Project pro =new Project ();
                    int row = e.RowIndex;
                    pro.Id =(int) dataGridView1.Rows[row].Cells["Id"].Value;
                    pro.PName = dataGridView1.Rows[row].Cells["PName"].Value.ToString();
                    pro.PLId = dataGridView1.Rows[row].Cells["PLId"].Value.ToString();
                    pro.PMId = dataGridView1.Rows[row].Cells["PMId"].Value.ToString();
                    pro.Status = dataGridView1.Rows[row].Cells["Status"].Value.ToString();
                    FrmProAddOrUpdate frmUpdate = new FrmProAddOrUpdate(pro);
                    frmUpdate.ShowDialog();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = proBll.QueryAll();
                    return;
                }
            }
        }
        private void txtQueryCondition_TextChanged(object sender, EventArgs e)
        {
            var a = new ProjectBll().QueryLikeThis(txtQueryCondition.Text);
            dataGridView1.DataSource = a;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProjectBll proBll = new ProjectBll();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = proBll.QueryAll();
        }
    }
}
