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
    public partial class FrmOvertimeAddOrUpdate : Form
    {
        int thisId = 0;//加班表的编号
        string thisProName;//员工的项目名
        string thisDate;//员工的加班日期----以上是为了更新员工加班详情时默认显示的变量

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public FrmOvertimeAddOrUpdate(string str)
        {
            InitializeComponent();
            this.Tag = str.Split(' ')[0];//获取员工号
            thisId=Convert.ToInt32(str.Split(' ')[1]);//获取加班表编号
            thisProName = str.Split(' ')[2];//获取项目名
            thisDate = str.Split(' ')[3];//获取加班开始时间
            this.Text = "更新信息";

            // myTxtEmpId.OnMyTextChange += myTextBox1_OnMyTextChange;
        }
        //添加信息
        public FrmOvertimeAddOrUpdate(string tag, string info)
        {

                    InitializeComponent();
                    this.Tag = tag;
                    this.Text = "添加信息";
        }
        //点击确定按扭
        private void btnSure_Click(object sender, EventArgs e)
        {

            if (listBoxShow.Items.Count == 0&&myTxtProName.GetText()==string.Empty)//如果员工没有项目
            {
                MessageBox.Show("您没有项目");
                return;
            }
            if (listBoxShow.Visible == true)//如果可见,表示未点击选择
            {
                MessageBox.Show("请选择项目!");
                return;
            }

            var timeFrom = TimePickerFrom.Value.ToShortTimeString();//开始时间  时分表示
            var timeTo = TimePickerTo.Value.ToShortTimeString(); //结束时间  时分表示
            int hourFrom = Convert.ToInt16(timeFrom.Split(':')[0]);     //开始时间:小时
            int minteFrom = Convert.ToInt16(timeFrom.Split(':')[1]);   //开始时间 : 分钟
            int hourTo = Convert.ToInt16(timeTo.Split(':')[0]); //结束时间  小时
            int minteTo = Convert.ToInt16(timeTo.Split(':')[1]);//结束时间 分钟

            bool b = (hourTo * 60 + minteTo) > (hourFrom * 60 + minteFrom);
            if (!b && !cBoxNextDay.Checked)//开始时间不能晚于结束时间
            {
                MessageBox.Show("您输入的时间不合法");
                return;
            }
            if (myTxtReason.GetText() == string.Empty)
            {
                MessageBox.Show("请填写原因");
                return;
            }

            #region  用来计算 时长
            float duration;
            if (cBoxNextDay.Checked)//如果选择了,结束时间要加上24小时
            {
                int to = (hourTo * 60 + minteTo + 1440);
                int from = (hourFrom * 60 + minteFrom);
                duration = (float)Math.Round(((to - from) / 60.0), 1);
                
            }//没有不用加
            else
            {
                int to = (hourTo * 60 + minteTo);
                int from = (hourFrom * 60 + minteFrom);
                duration = (float)Math.Round(((to - from) / 60.0), 1);
            }
            #endregion

            #region 获取要添加或更新的类的内容
            Overtime ot = new Overtime();
            var proBll = new ProjectBll();
            ot.EmployeeId = myTxtEmpId.GetText();
            ot.ProjectId = proBll.QueryByName(myTxtProName.GetText())[0].Id;//虽然项目名不可能相同,但是QueryByName()返回值我还是写成了集合,集合里只有一个元素,取索引0即可


            ot.DateTimeStart = DateTime.Parse(string.Format("{0} {1}",dateTime.Value.ToShortDateString(),timeFrom));
            if (cBoxNextDay.Checked)
            {
                ot.DateTimeEnd = DateTime.Parse(string.Format("{0} {1}",dateTime.Value.AddDays(1).ToShortDateString(),timeTo));
            }
            else
            {
                ot.DateTimeEnd = DateTime.Parse(string.Format("{0} {1}", dateTime.Value.ToShortDateString(), timeTo));
            }
            ot.Duration = duration;
            ot.Reason = myTxtReason.GetText();
            ot.Status = "已批";
            #endregion

            bool a=false;

            if (this.Text=="添加信息")//添加执行的代码
            {
                OvertimeBll oBll = new OvertimeBll();
                 a = oBll.Add(ot);
            }
            else //更新执行的代码
            {
                OvertimeBll ob = new OvertimeBll();
                ot.Id = thisId;
                a =ob.Update(ot);              
            }

            if (a)
            {
                MessageBox.Show("成功");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("您这段时间已有加班记录");
                return;
            }
        }


        //点击用户控件文本框时发生,文本框显示项目名
        private void myTxtProName_Enter(object sender, EventArgs e)
        {

            myTxtProPLName.Clear();

            #region  加载该员工项目.显示到listbox中
            string empId = myTxtEmpId.GetText().ToUpper().Trim();
            if (empId == string.Empty)
            {
                return;
            }
            listBoxShow.Items.Clear();

            ProjectBll pBll = new ProjectBll();
            EPRelationBll eBll = new EPRelationBll();
            List<string> need = new List<string>();
            List<string> have = new List<string>();
            need.Clear();

            //一个员工id,他可能的项目 包括他负责的项目和他从属的项目

            //从项目表中查询.负责的项目.因为关系表中每个项目没有包涵PM pl
            var pros = pBll.QueryWhenEmpIdLike(empId);
            if (pros != null)
            {
                foreach (var item in pros)
                {
                    need.Add(item);
                }
            }

            //从关系表中查询.从属的项目
            var epr = eBll.QueryLikeThis(empId);
            if (epr != null)
            {
                foreach (var item in epr)
                {
                    have.Add(item);
                }
            }
            need = need.Union(have).ToList();
            if (need != null)
            {
                if (need.Count == 1)//如果只有一个项目
                {

                    myTxtProName.SetText(need[0]);
                    myTxtProName.Enabled = false;
                    EmployeeBll emBll = new EmployeeBll();
                    ProjectBll prBll = new ProjectBll();
                    string pl = prBll.QueryByName(myTxtProName.GetText())[0].PLId;
                    string plName = emBll.QueryById(pl).Name;
                    myTxtProPLName.SetText(plName);//加载项目Pl

                    return;
                }
                listBoxShow.Visible = true;
                foreach (var item in need)
                {
                    listBoxShow.Items.Add(item);
                }

            }
            else
            {
                MessageBox.Show("您未参与任何项目");
                return;
            }
            #endregion


        }


        //listboxshow  单击选择
        private void listBoxShow_Click(object sender, EventArgs e)
        {

            if (listBoxShow.SelectedItem != null)
            {


                var item = listBoxShow.SelectedItem.ToString();
                myTxtProName.SetText(item);


                EmployeeBll empBll = new EmployeeBll();
                ProjectBll proBll = new ProjectBll();
                string choose = myTxtProName.GetText();//现在textbox中的字符串
                string pl = proBll.QueryByName(choose)[0].PLId;//项目PL的id
                string plName = empBll.QueryById(pl).Name;//项目的PL的名字
                myTxtProPLName.Clear();
                myTxtProPLName.SetText(plName);//加载项目Pl
                listBoxShow.Visible = false;//选择后隐藏
            }
        }

        private void FrmOvertimeAddOrUpdate_Load(object sender, EventArgs e)
        {
            EmployeeBll empBll = new EmployeeBll();
            ProjectBll proBll = new ProjectBll();
            myTxtEmpId.SetText(this.Tag.ToString());//加载员工Id
            string name = empBll.QueryById(this.Tag.ToString()).Name;
            myTxtEmpName.SetText(name);//加载员工姓名
            myTxtReason.SetText("工作需要");//默认原因
            TimePickerFrom.Value = DateTime.Parse("19:00");//默认开始时间
            TimePickerTo.Value = DateTime.Parse("21:00");//默认结束时间

            if (this.Text=="添加信息")
            {
                #region  加载该员工项目.显示到listbox中
                string empId = myTxtEmpId.GetText().ToUpper().Trim();
                if (empId == string.Empty)
                {
                    return;
                }
                listBoxShow.Items.Clear();

                ProjectBll pBll = new ProjectBll();
                EPRelationBll eBll = new EPRelationBll();
                List<string> need = new List<string>();
                List<string> have = new List<string>();
                need.Clear();

                //一个员工id,他可能的项目 包括他负责的项目和他从属的项目

                //从项目表中查询.负责的项目.因为关系表中每个项目没有包涵PM pl
                var pros = pBll.QueryWhenEmpIdLike(empId);
                if (pros.Count != 0)
                {
                    foreach (var item in pros)
                    {
                        need.Add(item);
                    }
                }

                //从关系表中查询.从属的项目
                var epr = eBll.QueryLikeThis(empId);
                if (epr.Count != 0)
                {
                    foreach (var item in epr)
                    {
                        have.Add(item);
                    }
                }
                need = need.Union(have).ToList();
                if (need.Count != 0)
                {
                    if (need.Count == 1)
                    {

                        myTxtProName.SetText(need[0]);
                        myTxtProName.Enabled = false;
                        EmployeeBll emBll = new EmployeeBll();
                        ProjectBll prBll = new ProjectBll();
                        string pl = prBll.QueryByName(myTxtProName.GetText())[0].PLId;
                        string plName = emBll.QueryById(pl).Name;
                        myTxtProPLName.SetText(plName);//加载项目Pl

                        return;
                    }
                    listBoxShow.Visible = true;
                    foreach (var item in need)
                    {
                        listBoxShow.Items.Add(item);
                    }

                }

                #endregion
            }
            else if (this.Text=="更新信息")
            {
                myTxtProName.SetText(thisProName);
                ProjectBll pb = new ProjectBll();
                EmployeeBll eb = new EmployeeBll();
                string plid=pb.QueryByName(thisProName)[0].PLId;
                string plname = eb.QueryById(plid).Name;
                myTxtProPLName.SetText(plname);
                dateTime.Value = DateTime.Parse(thisDate);
            }

            //使时间选择器值显示时间不显示日期
            TimePickerFrom.Format = DateTimePickerFormat.Custom;
            TimePickerFrom.CustomFormat = "HH':'mm";


            TimePickerTo.Format = DateTimePickerFormat.Custom;
            TimePickerTo.CustomFormat = "HH':'mm";
        }

        //单选框 第二日 
        private void cBoxNextDay_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxNextDay.Checked)
            {
                cBoxNextDay.ForeColor = Color.Black;//选上效果
            }
            else
            {
                cBoxNextDay.ForeColor = Color.Gray;//没选上效果
            }
        }


    }
}
