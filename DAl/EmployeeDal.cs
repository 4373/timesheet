using Common;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAl
{
    public class EmployeeDal
    {

       
        /// <summary>
        /// 向数据库里增加雇员信息
        /// </summary>
        /// <param name="employee">员工对象</param>
        /// <returns>成功返回true</returns>
        public  bool AddEmployee(Employee employee)
        {
            string sql = "insert into Employee (Id,Name,Email,Telephone,Mobile,CreateDate) values(@Id,@Name,@Email,@Telephone,@Mobile,@CreateDate)";
            SQLiteParameter[] paras = new SQLiteParameter[]
                {
                    new SQLiteParameter("@Id",employee.Id),
                    new SQLiteParameter("@Name",employee.Name),
                    new SQLiteParameter("@Email",employee.Email),
                    new SQLiteParameter("@Telephone",employee.Telephone),
                    new SQLiteParameter("@Mobile",employee.Mobile),
                    new SQLiteParameter("@CreateDate",DateTime.Now.ToString("yyyy-MM-dd HH:mm"))
                };
            int res = SQLiteHelper.ExecuteNonQuery(sql, paras);
            if (res == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断员工是否存在
        /// </summary>
        /// <param name="employeeId">员工id</param>
        /// <returns>存在返回true</returns>
        public bool IsIdExist(string employeeId)
        {

            string sql = "select * from Employee where Id=@employeeId";
            SQLiteParameter paras = new SQLiteParameter("@employeeId", employeeId);
            return SQLiteHelper.IsExist(sql, paras);
        }

        /// <summary>
        /// 按姓名查询员工
        /// </summary>
        /// <param name="name">员工姓名</param>
        /// <returns>员工集合</returns>

        public List<Employee> QueryByName(string name)
        {
            List<Employee> empList = new List<Employee>();
            string sql = "select * from Employee where Name = @Name";
            SQLiteParameter paras = new SQLiteParameter("@Name", name.Trim());
            var reader = SQLiteHelper.ExecuteReader(sql, paras);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = reader[0].ToString();
                    emp.Name = reader[1].ToString();
                    emp.Email = reader[2].ToString();
                    emp.Telephone = reader[3].ToString();
                    emp.Mobile = reader[4].ToString();
                    emp.CreateDate = reader[5].ToString();
                    empList.Add(emp);

                }
                return empList;
                reader.Close();
            }
            return null;
        }

        /// <summary>
        /// 按工号查询
        /// </summary>
        /// <param name="id">员工Id</param>
        /// <returns>员工对象</returns>
        public Employee QureyById(string id)
        {
            string sql = "select * from Employee where Id = @id";
            SQLiteParameter paras = new SQLiteParameter("@id", id.ToUpper().Trim());
            var reader = SQLiteHelper.ExecuteReader(sql, paras);
            if (reader.HasRows)
            {
                Employee emp = new Employee();
                while (reader.Read())
                {
                    
                    emp.Id = reader[0].ToString();
                    emp.Name = reader[1].ToString();
                    emp.Email = reader[2].ToString();
                    emp.Telephone = reader[3].ToString();
                    emp.Mobile = reader[4].ToString();
                    emp.CreateDate = reader[5].ToString();
                }
                return emp;
            }
            return null;
            reader.Close();
        }
        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="emp">员工对象</param>
        /// <returns>成功返回1  </returns>
        public int  UpdateEmp(Employee emp)
        {
            string sql = "update Employee set Id =@Id ,Name = @Name ,Email = @Email,Telephone = @Telephone,Mobile = @Mobile where Id= @Id1";
            SQLiteParameter[] paras = new SQLiteParameter[]{
                new SQLiteParameter("@Id",emp.Id),
                new SQLiteParameter("@Name",emp.Name),
                new SQLiteParameter("@Email",emp.Email),
                new SQLiteParameter("@Telephone",emp.Telephone),
                new SQLiteParameter("@Mobile",emp.Mobile),
                new SQLiteParameter("@Id1",emp.Id)
            };
            return SQLiteHelper.ExecuteNonQuery(sql, paras);
        }
        /// <summary>
        /// 按员工编号删除
        /// </summary>
        /// <param name="id">员工id</param>
        /// <returns>成功返回1</returns>
        public int DeleteEmp(string id)
        {
            string sql = string.Format("delete from Employee where Id = '{0}' ",id);
            
            return SQLiteHelper.ExecuteNonQuery(sql);
        }


        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns>返回所有员工集合</returns>
        public List<Employee> QueryAll()
        {
            List<Employee> empList = new List<Employee>();

            //string sqa = "select Id as 员工编号,Name as 员工姓名,Email as 员工邮箱,Telephone as 员工固话,Mobile as 员工手机,CreateDate as 创建时间 from Employee;";
            string sql = "select * from Employee";
            var reader =SQLiteHelper.ExecuteReader(sql);
            if (reader.HasRows)
            {
                
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = reader[0].ToString();
                    emp.Name = reader[1].ToString();
                    emp.Email = reader[2].ToString();
                    emp.Telephone = reader[3].ToString();
                    emp.Mobile = reader[4].ToString();
                    emp.CreateDate = reader[5].ToString();
                    empList.Add(emp);

                }
                return empList;
            }
            reader.Close();
            return null;
        }


        public List<Employee> QueryLikeThis(string str)
        {
            
            List<Employee> empList = new List<Employee>();
            string sql = "select * from Employee where Name like\"" + "%" + str + "%" + "\" or Id like \"" + "%" + str + "%\"";
            SQLiteParameter paras = new SQLiteParameter("@str", str);
            var reader = SQLiteHelper.ExecuteReader(sql,paras);
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = reader[0].ToString();
                    emp.Name = reader[1].ToString();
                    emp.Email = reader[2].ToString();
                    emp.Telephone = reader[3].ToString();
                    emp.Mobile = reader[4].ToString();
                    emp.CreateDate = reader[5].ToString();
                    empList.Add(emp);

                }
                reader.Close();
                return empList;
            }
            return null;
        }
    }
}
