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
using TimeSheet;

namespace TimeSheet
{
    public delegate void SetResult( string  txtId,string txtName,string txtBoxName);
    public partial class EmpDataShow : UserControl
    {
        private string txtBoxName;
        public EmpDataShow()
        {
            InitializeComponent();
        }
        public event SetResult EmployeeSelected;
        public event MyDelegate KeyDownOrUp;
      
        public void Query(string str,string txtName)
        {
            listBox1.Items.Clear();
            this.txtBoxName = txtName;
            var data = new EmployeeBll().QueryLikeThis(str);
            if (data!=null)
            {
                foreach (var item in data)
                {
                    listBox1.Items.Add(item.Id + "_" + item.Name);
                }
            } 
        }

        public void SelectIndex()
        {
            int all = listBox1.Items.Count;
            int select = listBox1.SelectedIndex;
            listBox1.SelectedItem=listBox1.Items[0];

        }

        //当选中的项改变的时候,得到选中的项的文本,把他显示到另一个控件textbox中
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string needName =listBox1.SelectedItem.ToString().Split('_')[1];//姓名 
            string needId = listBox1.SelectedItem.ToString().Split('_')[0];//工号
            EmployeeSelected(needId,needName,this.txtBoxName);
            
            //this.Hide();
        }




        //按下箭头上箭头键实现listbox项滚动
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyValue==Convert.ToChar(Keys.Down))
            {
                listBox1.SelectedItem =3;
            }

            if (e.KeyValue==Convert.ToChar(Keys.Enter))
            {
                string needName = listBox1.SelectedItem.ToString().Split('_')[1];//姓名 
                string needId = listBox1.SelectedItem.ToString().Split('_')[0];//工号
                EmployeeSelected(needId, needName, this.txtBoxName);
                this.Hide();
            }
        }

        
    }
    public delegate void MyDelegate(object sender, MyEventArgs e);

    public class MyEventArgs
    {
   
        public int All { get; set; }
     
        public int Select { get; set; }
        public int  key { set; get; }

    }
}


//if (e.KeyValue == Convert.ToChar(Keys.Down))
//{
//    if (selected == (all - 1))
//    {
//        selected = 0;
//    }
//    else
//    {
//        selected += 1;
//    }
//}
//if (e.KeyValue == Convert.ToChar(Keys.Up))
//{
//    if (selected == 0)
//    {
//        selected = all - 1;
//    }
//    else
//    {
//        selected -= 1;
//    }
//}