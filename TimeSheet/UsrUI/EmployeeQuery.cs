using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Common;
namespace TimeSheet.UsrUI
{
    public delegate void SetResult(Employee pro ,string  str);
   
    public partial class EmployeeQuery : UserControl
    {
        /// <summary>
        /// 表格中的行高
        /// </summary>
        private const int ROW_HEIGHT = 28;
        private const int ROW_COLUMNS = 37;
        /// <summary>
        /// 当用户选择列表中的某一个员工时触发
        /// </summary>
        public event SSetResult EmployeeSelected;

        private string txtBoxName;
        public EmployeeQuery()
        {
            InitializeComponent();
           // dataGridViewUI.RowHeadersVisible = false;
        }
        /// <summary>
        /// 输入姓名或者员工编号来模糊查询员工信息,并填充到Dataset上
        /// </summary>
        /// <param name="keyWord">关键字</param>
        public void Query(string keyWord,string txtBoxName)
        {
            //从数据库中查找
            dataGridViewUI.DataSource = new EmployeeBll().QueryByName(keyWord);
            this.txtBoxName = txtBoxName;
            for (int i = 0; i < dataGridViewUI.Columns.Count; i++)
            {
                if (i>1)
                {
                    dataGridViewUI.Columns[i].Visible = false;
                }
            }
            dataGridViewUI.Height = dataGridViewUI.Rows.Count *ROW_HEIGHT+28;
           // dataGridViewUI.Width=dataGridViewUI.Columns.Count*ROW_COLUMNS;
            this.Height = dataGridViewUI.Rows.Count*ROW_HEIGHT+28;
           // this.Width = dataGridViewUI.Width;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (EmployeeSelected!=null)
            {
                var emp = new Employee() { Name="梅欢",Id="23123" };
                EmployeeSelected(emp,this.txtBoxName);
            }
            this.Hide();
        }
    }
}
