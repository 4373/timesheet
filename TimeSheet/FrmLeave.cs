using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Common;

namespace TimeSheet
{
    public partial class FrmLeave : Form
    {
        public FrmLeave(string id)
        {
            InitializeComponent();
            this.Tag = id;
        }

        //点击添加按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmLeaveAddOrUpdate leave = new FrmLeaveAddOrUpdate(this.Tag.ToString());
            leave.ShowDialog();
            if (leave.DialogResult==DialogResult.OK)
            {
                //添加完刷新
                QueryAll(this.Tag.ToString());
            }
        }

        private void FrmLeave_Load(object sender, EventArgs e)
        {
            //加载所有
            QueryAll(this.Tag.ToString());
        }

        //按日期查询
        private void btnQuery_Click(object sender, EventArgs e)
        {

           var start = datePickerStart.Value.ToString("yyyy-MM-dd 00:00:00");
           var end = datePickerEnd.Value.ToString("yyyy-MM-dd 24:00:00");
           if (start.CompareTo(end)>0)
           {
               MessageBox.Show("请输入合适的时间");
               return;
           }
            var data = new LeaveBll().QueryByEmpidBetween(start, end, this.Tag.ToString()).Tables[0];
            if (data!=null)
            {
                dataGridView1.DataSource = data;
            }
        }

        //刷新
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            QueryAll(this.Tag.ToString());
        }

        //抽出的查询所有方法
        private void QueryAll(string id)
        {
            dataGridView1.DataSource = new LeaveBll().QueryAllByEmpid(id).Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            
            if (e.ColumnIndex==0&&e.RowIndex>-1)//删除按钮操作
            {
                int leaveId = Convert.ToInt32(dataGridView1.Rows[row].Cells["编号"].Value.ToString());
                var result =MessageBox.Show("删除后不可恢复,继续?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result==DialogResult.OK)
                {
                    bool b = new LeaveBll().DeleteById(leaveId);
                    if (b)
                    {
                        MessageBox.Show("删除成功!");
                        QueryAll(this.Tag.ToString());
                        return;
                    }
                    return;
                }
            }
            if (e.ColumnIndex==1&&e.RowIndex>-1)//更新按钮操作
            {
                Leave le = new Leave();
                le.Id  = Convert.ToInt32(dataGridView1.Rows[row].Cells["编号"].Value.ToString()); ;
                le.EmployeeId = dataGridView1.Rows[row].Cells["员工号"].Value.ToString();
                le.DateTimeStart = Convert.ToDateTime(dataGridView1.Rows[row].Cells["开始时间"].Value.ToString());
                le.DateTimeEnd = Convert.ToDateTime(dataGridView1.Rows[row].Cells["结束时间"].Value.ToString());
                le.Duration = (float)Convert.ToDouble(dataGridView1.Rows[row].Cells["时长"].Value.ToString());
                le.Status = dataGridView1.Rows[row].Cells["状态"].Value.ToString();
                le.Reason = dataGridView1.Rows[row].Cells["原因"].Value.ToString();
                FrmLeaveAddOrUpdate leave = new FrmLeaveAddOrUpdate(le);
                leave.ShowDialog();
                if (leave.DialogResult==DialogResult.OK)
                {
                    QueryAll(this.Tag.ToString());
                }
            }
        }
    }
}
