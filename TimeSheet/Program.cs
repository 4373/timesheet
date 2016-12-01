using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSheet
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin login = new FrmLogin();
            
            if (login.ShowDialog()==DialogResult.OK)
            {
                Application.Run(new FrmMain(login.Text));
            }
            //Application.Run(new FrmLogin());
        }
    }
}
