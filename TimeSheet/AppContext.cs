using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    public  class AppContext
    {
        private AppContext() { }

        //保存当前登录者的信息
        static Employee loginEmployee = null;

        /// <summary>
        /// 获得当前登录者的信息
        /// </summary>
        /// <returns></returns>
        public static Employee GetLoginEmployee()
        {
            return loginEmployee;
        }

        /// <summary>
        /// 设置当前登录者的信息
        /// </summary>
        /// <param name="employee"></param>
        public static void Login(Employee employee)
        {
            loginEmployee = employee;
        }
    }
}
