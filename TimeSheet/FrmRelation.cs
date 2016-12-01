using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using Common;
using System.Text.RegularExpressions;

namespace TimeSheet
{
    public partial class FrmRelation : Form
    {
        public FrmRelation()
        {
            InitializeComponent();
        }

        private void FrmRelation_Load(object sender, EventArgs e)
        {
            ProjectBll proBll = new ProjectBll();
            var proData = proBll.QueryAll();
            foreach (var item in proData)
            {
                listBoxPro.Items.Add(item.PName);
            }

        }

        private void listBoxPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            EPRelationBll eprBll = new EPRelationBll();
            EmployeeBll empBll = new EmployeeBll();
            lblProName.Text = listBoxPro.SelectedItem.ToString();
            listBoxEmp.Items.Clear();
            listBoxOtherEmp.Items.Clear();

            //显示PL,PM
            var pro = eprBll.QueryProByName(listBoxPro.SelectedItem.ToString());
            lblPL.Text = pro.PLId + "   " + empBll.QueryById(pro.PLId).Name;
            lblPM.Text = pro.PMId + "   " + empBll.QueryById(pro.PMId).Name;

            var proEmp = eprBll.QueryProEmp(listBoxPro.SelectedItem.ToString());
            var otherEmp = eprBll.QueryOtherEmp(listBoxPro.SelectedItem.ToString());


            if (proEmp.Count != 0)
            {

                foreach (var item in proEmp)
                {
                    listBoxEmp.Items.Add(item.Id + "   " + item.Name);//项目员工
                }
            }

            if (otherEmp.Count != 0)
            {

                foreach (var item in otherEmp)
                {
                    listBoxOtherEmp.Items.Add(item.Id + "   " + item.Name);//其他员工
                }
            }

        }
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBoxOtherEmp.SelectedIndex > -1)
            {
                listBoxEmp.Show();
                var output = listBoxOtherEmp.SelectedItems;
                string[] str = new string[output.Count];
                for (int i = 0; i < output.Count; i++)
                {
                    str[i] = output[i].ToString();
                }
                listBoxEmp.Items.AddRange(str);
                for (int i = 0; i < str.Length; i++)
                {
                    listBoxOtherEmp.Items.Remove(str[i]);
                }

            }
            btnUpdate.Focus();
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutput_Click(object sender, EventArgs e)
        {
            if (listBoxEmp.SelectedIndex > -1)
            {
                listBoxEmp.Show();
                var output = listBoxEmp.SelectedItems;
                string[] str = new string[output.Count];
                for (int i = 0; i < output.Count; i++)
                {
                    str[i] = output[i].ToString();
                }
                listBoxOtherEmp.Items.AddRange(str);
                for (int i = 0; i < str.Length; i++)
                {
                    listBoxEmp.Items.Remove(str[i]);
                }

            }
            btnUpdate.Focus();
        }
        /// <summary>
        /// 更新关系表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            EPRelationBll eprBll = new EPRelationBll();
            List<EPRelation> eprList = new List<EPRelation>();
            eprList.Clear();
            int count = listBoxEmp.Items.Count;
            if (count != 0)
            {
                for (int i = 0; i < count; i++)
                {
                    EPRelation epr = new EPRelation();
                    epr.ProjectName = listBoxPro.SelectedItem.ToString();
                    epr.EmployeeId = listBoxEmp.Items[i].ToString().Split(' ')[0];
                    epr.CreateDate = DateTime.Now.ToString();
                    eprList.Add(epr);
                }
                bool b = eprBll.AddAfterDeleteInfo(eprList);
                if (b)
                {
                    MessageBox.Show("成功");
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
        }

        //查询项目
        private void textBoxPro_TextChanged(object sender, EventArgs e)
        {


            textBoxPro.ForeColor = Color.Black;
            if (textBoxPro.Text == string.Empty)
            {
                listBoxOtherEmp.ClearSelected();
                
                return;
            }
            if (listBoxPro.Items != null)
            {
                //List<string> all = new List<string>();
                List<string> need = new List<string>();
                foreach (var item in listBoxPro.Items)
                {

                    bool b = Regex.IsMatch(item.ToString(), string.Format("\\w*{0}\\w*", textBoxPro.Text));
                    if (b)
                    {
                        need.Add(item.ToString());
                    }
                }

                foreach (var item in need)
                {

                    listBoxPro.SelectedItem = item;
                }
            }
        }
        //查询项目员工
        private void textBoxEmp_TextChanged(object sender, EventArgs e)
        {
            textBoxEmp.ForeColor = Color.Black;
            if (listBoxEmp.Items != null)
            {
                if (textBoxEmp.Text == string.Empty)
                {
                    listBoxEmp.SelectedItems.Clear();
                    return;
                }

                List<string> all = new List<string>();
                List<string> need = new List<string>();
                foreach (var item in listBoxEmp.Items)
                {
                    bool b = Regex.IsMatch(item.ToString(), string.Format("\\w*{0}\\w*", textBoxEmp.Text));
                    if (b)
                    {
                        need.Add(item.ToString());
                    }
                    all.Add(item.ToString());
                }

                if (need.Count==0)
                {
                    return;
                }
                listBoxEmp.Items.Clear();
                for (int i = 0; i < need.Count; i++)
                {
                    listBoxEmp.SelectionMode = SelectionMode.One;
                    listBoxEmp.Items.Add(need[i]);
                    listBoxEmp.SelectedItem = need[i];
                    listBoxEmp.SelectedIndex = i;
                }

                var other = all.Except(need).ToList();
                for (int i = 0; i < other.Count; i++)
                {
                    listBoxEmp.Items.Add(other[i]);
                }

                for (int i = 0; i < need.Count; i++)
                {
                    listBoxEmp.SelectionMode = SelectionMode.MultiExtended;

                    listBoxEmp.SelectedItem = need[i];

                }

            }
        }

        //查询非项目员工
        private void textBoxOther_TextChanged(object sender, EventArgs e)
        {
            
            textBoxOther.ForeColor = Color.Black;
            if (listBoxOtherEmp.Items != null)
            {
                if (textBoxOther.Text == string.Empty)
                {
                    listBoxOtherEmp.SelectedItems.Clear();
                    return;
                }

                //List<string> all = new List<string>();
                List<string> need = new List<string>();
                List<string> all = new List<string>();
                foreach (var item in listBoxOtherEmp.Items)
                {

                    bool b = Regex.IsMatch(item.ToString(), string.Format("\\w*{0}\\w*", textBoxOther.Text));
                    if (b)
                    {
                        need.Add(item.ToString());
                    }
                    all.Add(item.ToString());
                }
                if (need.Count==0)
                {
                    return;
                }
                listBoxOtherEmp.Items.Clear();
                for (int i = 0; i < need.Count; i++)
                {
                    listBoxOtherEmp.SelectionMode = SelectionMode.One;
                    listBoxOtherEmp.Items.Add(need[i]);
                    listBoxOtherEmp.SelectedItem = need[i];
                    listBoxOtherEmp.SelectedIndex = i;
                }

                var other = all.Except(need).ToList();
                for (int i = 0; i < other.Count; i++)
                {
                    listBoxOtherEmp.Items.Add(other[i]);
                }

                for (int i = 0; i < need.Count; i++)
                {
                    listBoxOtherEmp.SelectionMode = SelectionMode.MultiExtended;
                    
                    listBoxOtherEmp.SelectedItem = need[i];
                    
                }
            }
        }




        #region 文本框灰白特效
        private void textBoxPro_Click(object sender, EventArgs e)
        {

            textBoxPro.Text = "";
            textBoxPro.ForeColor = Color.Black;
        }

        private void textBoxPro_Leave(object sender, EventArgs e)
        {
            if (textBoxPro.Text!="")
            {
                return;
            }
            textBoxPro.Text = "输入项目名进行查询";
            textBoxPro.ForeColor = Color.Silver;
        }

        private void textBoxEmp_Click(object sender, EventArgs e)
        {
 
            textBoxEmp.Text = "";
            textBoxEmp.ForeColor = Color.Black;
        }

        private void textBoxEmp_Leave(object sender, EventArgs e)
        {
            if (textBoxEmp.Text != "")
            {
                return;
            }
            textBoxEmp.Text = "输入员工名或工号查询";
            textBoxEmp.ForeColor = Color.Silver;
        }

        private void textBoxOther_Leave(object sender, EventArgs e)
        {
            if (textBoxOther.Text != "")
            {
                return;
            }
            textBoxOther.Text = "输入员工名或工号查询";
            textBoxOther.ForeColor = Color.Silver;
        }

        private void textBoxOther_Click(object sender, EventArgs e)
        {
            textBoxOther.Text = "";
            textBoxOther.ForeColor = Color.Black;
        }
        #endregion




    }
}
