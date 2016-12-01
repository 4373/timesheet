using System;
using System.Windows.Forms;

namespace TimeSheet
{
    public partial class FrmMain : Form
    {
        const string MENU_ITEM_EMPLOY_MANAGE = "员工管理";
        const string MENU_ITEM_PROJECT_MANAGE = "项目管理";
        const string MENU_ITEM_RELATION_MANGE = "项目信息";
        const string MENU_ITEM_OVERTIME_MANGE = "加班管理";
        const string MENU_ITEM_LEAVE_MANGE = "调休管理";
        public FrmMain()
        {
            InitializeComponent();
        }
        public FrmMain(string str)
        {
            InitializeComponent();
            this.Text = str;
            //点击事件
            card1.ClickIt += card1_ClickIt;
            card2.ClickIt += card2_ClickIt;
            card3.ClickIt += card3_ClickIt;
            card4.ClickIt += card4_ClickIt;
            card5.ClickIt += card5_ClickIt;
        }
        //调休管理
        void card5_ClickIt()
        {
            FrmLeave leave =new FrmLeave(this.Text);
            leave.ShowDialog();
        }
        //点击加班管理
        void card4_ClickIt()
        {
            FrmOvertime overtime=new FrmOvertime(this.Text);
            overtime.ShowDialog();
        }
        //点击项目信息
        void card3_ClickIt()
        {
            FrmRelation frmRel = new FrmRelation();
            frmRel.ShowDialog();
        }
        //点击项目管理
        void card2_ClickIt()
        {
            FrmProject frmPro = new FrmProject();
            frmPro.ShowDialog();
        }
        //点击员工管理按钮
        void card1_ClickIt()
        {
            FrmEmployee frmEmp = new FrmEmployee();
            frmEmp.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //设置选项名称
            card1.setText(MENU_ITEM_EMPLOY_MANAGE);
            card2.setText(MENU_ITEM_PROJECT_MANAGE);
            card3.setText(MENU_ITEM_RELATION_MANGE);
            card4.setText(MENU_ITEM_OVERTIME_MANGE);
            card5.setText(MENU_ITEM_LEAVE_MANGE);

        }
    }
}
