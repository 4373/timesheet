using Common;
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


namespace TimeSheet
{
    public partial class FrmLeaveAddOrUpdate : Form
    {

        float duration = 0.0F;//调休时长
        string thisEmpId; //员工id
        int thisId;//调休表id
        int time = 0;
        public FrmLeaveAddOrUpdate(string id)//添加信息初始化
        {
            InitializeComponent();
            thisEmpId = id;
            this.Text = "添加信息";
        }
        public FrmLeaveAddOrUpdate(Leave le)//更新信息初始化
        {
            InitializeComponent();
            thisEmpId = le.EmployeeId;
            this.Text = "更新信息";
            thisId = le.Id;
            txtReason.Text = le.Reason;
            dateStart.Value = DateTime.Parse(le.DateTimeStart.ToString("yyyy-MM-dd"));
            dateEnd.Value = DateTime.Parse(le.DateTimeEnd.ToString("yyyy-MM-dd"));
            time = 1;
            cmbTimeStart.SelectedItem = le.DateTimeStart.ToString("HH:mm");
            cmbTimeEnd.SelectedItem = le.DateTimeEnd.ToString("HH:mm");
            txtDuration.Text = le.Duration.ToString();
        }



        //添加或更新  确定按钮
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (txtDuration.Text=="0"||txtDuration.Text==string.Empty)
            {
                MessageBox.Show("未添加,请检查时间输入");
                return;
            }
            if (txtReason.Text==string.Empty)
            {
                MessageBox.Show("请你填写原因");
                return;
            }
            if (Convert.ToDouble(txtDuration.Text)>Convert.ToDouble(txtRemainHours.Text))//可用时长不够时;
            {
                var result=MessageBox.Show("你的时长不够,继续?","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (result==DialogResult.Cancel)
                {
                    return;
                }
            }

            DateTime startD = DateTime.Parse(dateStart.Value.ToShortDateString());//开始日期
            DateTime endD = DateTime.Parse(dateEnd.Value.ToShortDateString());//结束日期
            DateTime startT = DateTime.Parse(cmbTimeStart.SelectedItem.ToString());//开始时间
            DateTime endT = DateTime.Parse(cmbTimeEnd.SelectedItem.ToString());//结束时间
            Leave leave = new Leave();
            LeaveBll lb = new LeaveBll();
            leave.EmployeeId = txtEmpId.Text;
            leave.DateTimeStart = DateTime.Parse(string.Format("{0} {1}", startD.ToShortDateString(), startT.ToShortTimeString()));
            leave.DateTimeEnd = DateTime.Parse(string.Format("{0} {1}", endD.ToShortDateString(), endT.ToShortTimeString()));
            leave.Duration = (float)Convert.ToDouble(txtDuration.Text);
            leave.Reason = txtReason.Text;
            leave.Status = "YES";
  
            bool b = false;
            if (this.Text=="添加信息")//添加信息
            {
                b =lb.Add(leave);
            }
            else//更新信息
            {
                leave.Id = thisId;
                b = lb.Update(leave);
            }

            if (b)
            {
                MessageBox.Show("成功");
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                MessageBox.Show("这段时间已经存在记录");
                return;
            }

        }

       
        //加载时自动填充
        private void FrmLeaveAddOrUpdate_Load(object sender, EventArgs e)
        {
           
            txtEmpId.Text = thisEmpId;//员工号
            txtEmpName.Text = new EmployeeBll().QueryById(txtEmpId.Text).Name;//姓名
            float[] hours = new LeaveBll().Hour(txtEmpId.Text);

            txtAllHours.Text = hours[0].ToString();// 总时长
            txtUsedHours.Text = hours[1].ToString();//已用时长
            txtRemainHours.Text = hours[2].ToString();//剩余时长

            if (this.Text=="添加信息")
            {
                txtReason.Text = "世界这么大,想去溜溜";//默认原因
                time = 1;
                cmbTimeStart.SelectedItem = cmbTimeStart.Items[0];//默认选择早上九点到晚上六点
                cmbTimeEnd.SelectedItem = cmbTimeEnd.Items[18];
                txtDuration.Text = "8.0";
            }
            else 
            {
                
            }


        }


        //cmb和时间选择控件改变时
        private void cmbTimeStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (time == 1 || time == 2)
            {
                time += 1;
                return;
            }
            DateTime startD = DateTime.Parse(dateStart.Value.ToShortDateString());//开始日期
            DateTime endD = DateTime.Parse(dateEnd.Value.ToShortDateString());//结束日期
            if (cmbTimeStart.SelectedItem==null||cmbTimeEnd.SelectedItem==null)
            {
                return;
            }
            DateTime startT = DateTime.Parse(cmbTimeStart.SelectedItem.ToString());//开始时间
            DateTime endT = DateTime.Parse(cmbTimeEnd.SelectedItem.ToString());//结束时间
            if (startD.CompareTo(endD) > 0)//日期不合法
            {
                MessageBox.Show("你输入的时间不合法");
                //dateEnd.Value = DateTime.Now;
                //dateStart.Value = DateTime.Now;
                txtDuration.Text = "0";
                return;
            }
            else
            {
                if (startT.CompareTo(endT) > 0)//时间不合法
                {
                    MessageBox.Show("你输入的时间不合法");
                    cmbTimeStart.SelectedIndex = 0;
                    cmbTimeEnd.SelectedIndex = 18;
                    txtDuration.Text = "0";
                    return;
                }
            }

            var day = endD.DayOfYear - startD.DayOfYear;//调休日期中相隔的天数;
            int realEndHour = endT.Hour;
            int realStartHour = startT.Hour;
            var hour = 0.0F;
            if ((startT.Hour < 13 || startT.Hour == 13) && (endT.Hour > 13 || endT.Hour == 13))//如果调休时间大于13点,要减去无用的一个小时
            {
                realEndHour = endT.Hour - 1;//中午一小时休息不算,需要-1
            }
            if (endT.Hour == 12)//十二点和十二半是一个意思
            {
                hour = (realEndHour - realStartHour);
            }
            else//主要情况
            {
                hour = (float)((realEndHour - realStartHour) + ((endT.Minute - startT.Minute) < 30 ? 0.0 : 0.5));//相隔的小时数
            }

            if (hour > 8.0F)
            {
                hour = 8.0F;//如果大于8,就等于8,,一天工作时间最多为8
            }

            duration = day * 8 + (float)hour;//调休时长
            txtDuration.Text = duration.ToString();//显示


        }
    }
}
