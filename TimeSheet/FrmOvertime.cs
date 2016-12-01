using System;
using System.Windows.Forms;
using BLL;

namespace TimeSheet
{
    public partial class FrmOvertime : Form
    {
        public FrmOvertime(string str)
        {
            InitializeComponent();
            this.Tag = str;//str为上个页面传过来的值;为员工Id
        }

        //点击添加按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmOvertimeAddOrUpdate overtime = new FrmOvertimeAddOrUpdate(this.Tag.ToString(), "添加");
            overtime.ShowDialog();//点击添加按钮,弹出添加页面
            if (overtime.DialogResult == System.Windows.Forms.DialogResult.OK)//如果添加成功,刷新页面
            {
                OvertimeBll ob = new OvertimeBll();
                var datas = ob.QueryByEmpIdUsingDateSet(this.Tag.ToString()).Tables[0];
                if (datas != null)
                {
                    dataGridView1.DataSource = datas;
                }
            }
        }

        //加载该登录员工的加班信息
        private void FrmOvertime_Load(object sender, EventArgs e)
        {
            OvertimeBll ob = new OvertimeBll();

            var datas = ob.QueryByEmpIdUsingDateSet(this.Tag.ToString());
            dataGridView1.DataSource = datas.Tables[0];
        }

        //点击datagridview里的单元格发生
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击删除按钮
            if (e.ColumnIndex == 0 && e.RowIndex > -1)//如果是点击的是内容而不是列名之类的
            {
                int row = e.RowIndex;//点击单元格的行索引
                string id = dataGridView1.Rows[row].Cells["编号"].Value.ToString();
                OvertimeBll ob = new OvertimeBll();
                var result = MessageBox.Show("删除后不可恢复,确定?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    ob.DeleteById(id);
                    dataGridView1.DataSource = ob.QueryByEmpIdUsingDateSet(this.Tag.ToString()).Tables[0];
                    return;
                }
                else
                {
                    return;
                }
            }
            ////////////////////////////////////////////////////////////
            //点击更新按钮
            else if (e.ColumnIndex == 1&&e.RowIndex>-1)
            {
                int row = e.RowIndex;
                string id = dataGridView1.Rows[row].Cells["编号"].Value.ToString();//该员工的员工号
                string tag = this.Tag.ToString();
                string proName = dataGridView1.Rows[row].Cells["项目名"].Value.ToString();//该员工需加班的项目名
                string date = dataGridView1.Rows[row].Cells["开始时间"].Value.ToString();//加班开始时间
                FrmOvertimeAddOrUpdate frmot = new FrmOvertimeAddOrUpdate(tag + " " + id+" "+proName+" "+date);
                frmot.ShowDialog();
                var res = frmot.DialogResult;
                if (res == DialogResult.OK)
                {
                    OvertimeBll ob = new OvertimeBll();
                    dataGridView1.DataSource = ob.QueryByEmpIdUsingDateSet(this.Tag.ToString()).Tables[0];
                    return;
                }
            }
            else if (e.RowIndex>-1)
            {
                //设置点击任意单元格其一行内所有单元格高亮
                int hang = e.RowIndex;
                //dataGridView1.Rows[hang].Cells[0].Selected = true;
                //dataGridView1.Rows[hang].Cells[1].Selected = true;
                dataGridView1.Rows[hang].Cells[2].Selected = true;
                dataGridView1.Rows[hang].Cells[3].Selected = true;
                dataGridView1.Rows[hang].Cells[4].Selected = true;
                dataGridView1.Rows[hang].Cells[5].Selected = true;
                dataGridView1.Rows[hang].Cells[6].Selected = true;
                dataGridView1.Rows[hang].Cells[7].Selected = true;
                dataGridView1.Rows[hang].Cells[8].Selected = true;
                dataGridView1.Rows[hang].Cells[9].Selected = true;
                return;
            }
        }
        //查询按钮
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (!(datePickerStart.Value.CompareTo(datePickerEnd.Value)>0))//如果时间选择合理
            {
                OvertimeBll ob = new OvertimeBll();
                string dateEnd = datePickerEnd.Value.ToString("yyyy-MM-dd 24:00:00");
                string dateStart=datePickerStart.Value.ToString("yyyy-MM-dd 00:00:00");
                var datas=ob.QueryDByIdAndDate(this.Tag.ToString(), dateStart, dateEnd);
                // = ob.QueryDByIdAndDate(date, this.Tag.ToString());
                dataGridView1.DataSource = datas.Tables[0];
            }
        }
    }
}







































































//var result = ob.ReadAll();
//if (result.Count != 0)
//{
//    dataGridView1.DataSource = result;
//}
//string sql = "select o.Id 编号,o.EmployeeId 员工编号,p.PName 项目名称,o.DateTimeStart,o.DateTimeEnd,o.Duration,o.Reason,o.Status from Overtime as o left outer join Project as p on o.ProjectId=p.Id ";
//var ds= SQLiteHelper.ExecuteDataset(sql);
//dataGridView1.DataSource = ds.Tables[0];
//DataSet ds = new DataSet();
//var datas = ob.QueryByEmpIdUsingDateTable(this.Text);
//ds.Tables.Add(datas);
