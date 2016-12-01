using Common;
using DAl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeBll
    {
        List<Employee> empList = new List<Employee>();
        EmployeeDal empDal = new EmployeeDal();
        

        /// <summary>
        /// 添加学生,返回字符串
        /// </summary>
        /// <param name="employee">员工对象</param>
        /// <returns>成功 true  失败 false </returns>
        public bool AddEmployee(Employee employee)
        {

            if (empDal.AddEmployee(employee))
            {
                return true;
            }
         
                return false;
           
        }

        /// <summary>
        /// 判断工号是否存在
        /// </summary>
        /// <param name="id">员工编号</param>
        /// <returns>存在返回true   否则返回false</returns>
        public bool IsIdExist(string id)
        {
            if (empDal.IsIdExist(id))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 按姓名查询员工
        /// </summary>
        /// <param name="name">员工名</param>
        /// <returns>员工信息</returns>
        public List<Employee> QueryByName(string name)
        {
            return empDal.QueryByName(name);
        }

        /// <summary>
        /// 按工号查询
        /// </summary>
        /// <param name="id">工号</param>
        /// <returns>员工对象</returns>
        public Employee QueryById(string id)
        {
            return empDal.QureyById(id);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="emp">员工对象</param>
        /// <returns>成功 为true  </returns>
        public bool UpdateEmp(Employee emp)
        {
            int  b = empDal.UpdateEmp(emp);
            if (b==1)
            {
                return true;
            }
            return false;
            
        }

        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="id">员工id</param>
        /// <returns>删除成功返回true</returns>
        public bool DeleteEmp(string id)
        {
            int a = empDal.DeleteEmp(id);
            if (a==1)
            {
                return true;
            }
            return false;
        }
        
        public List<Employee> QueryAll()
        {
            return empDal.QueryAll();
        }

        //判断手机号码是否合法
        public bool IsMobileLegal(string mobile)
        {
            bool flag = true;
            //是否是11位手机号
            if (mobile.Length!=11)
            {
                return false;
            }
            if (mobile.Trim() != "")
            {
                for (int i = 0; i < mobile.Length; i++)
                {
                    if (!Char.IsNumber(mobile, i))
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;

            //bool b = Regex.IsMatch(mobile, "^[0-9]{11}$");//正则表达式
        }

        //判断字符串是否为数字,字母或"_"或".";
        public bool IsNumOrChar(string str)
        {
            bool flag = true;
            for (int i = 0; i < str.Length; i++)
            {
                if (!((int)str[i] > 64 && (int)str[i] < 91) && !((int)str[i] > 96 && (int)str[i] < 123) && !str[i].Equals('.') && !str[i].Equals('_') && !Char.IsDigit(str, i) )
                {

                    flag= false;
                }
            }
            if (str.StartsWith("_")||str.StartsWith(".")||str.EndsWith("_")||str.EndsWith("."))
            {
                flag = false;
            }
            return flag;
        }


        //判断员工号是够合法
        public bool IdIsNumOrChar(string str)
        {
            bool flag = true;
            if (str.Length!=8)
            {
                flag = false;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if ( !((int)str[i]>64&&(int)str[i]<91) && !((int)str[i]>96&&(int)str[i]<123)   && !Char.IsDigit(str,i))
                {
                    flag = false;
                }
            }
            return flag;
        }

        public List<Employee> QueryLikeThis(string  str) 
        {
            return empDal.QueryLikeThis(str);
        }
    }
}
