using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAl;

namespace BLL
{
    public static class LoginBll
    {
        public static bool IsLogin(string name, string psw)
        {
            EmployeeDal empdDal=new EmployeeDal();
            return empdDal.QureyById(name) .Email.Split('@')[0]==psw;
        }

        public static bool IdExist(string id)
        {
            EmployeeDal empdDal = new EmployeeDal();
            return empdDal.IsIdExist(id);
        }
    }
}
