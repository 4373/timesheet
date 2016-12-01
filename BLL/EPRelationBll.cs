using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAl;
using Common;

namespace BLL
{
    public class EPRelationBll
    {
        /// <summary>
        /// 先删除与该项目有关的所有员工 再新添加员工
        /// </summary>
        /// <param name="epRel">新添加员工</param>
        /// <returns>如果添加成功返回 true 否则返回false</returns>
        public bool AddAfterDeleteInfo(List<EPRelation> epRel)
        {
            EPRelationDal erpDal = new EPRelationDal ();
            if (epRel==null)
            {
                return false;
            }
            return erpDal.AddAfterDeleteInfo(epRel);
            
        }

        /// <summary>
        /// 根据项目名称查员工集合
        /// </summary>
        /// <param name="name">项目名</param>
        /// <returns>项目员工集合</returns>
        public List<Employee> QueryProEmp(string name)
        {
            List<Employee> empList = new List<Employee>();
            empList.Clear();
            EPRelationDal eperDal = new EPRelationDal();
            EmployeeBll empBll = new EmployeeBll ();
            var epRel =eperDal.QueryByProName(name);//取得项目名为name的关系表集合
            if (epRel.Count==0)
            {
                return empList;
            }
            foreach (var item in epRel)//将关系表中项目名为name的员工id加入到员工id集合Emplist
            {
                //Employee emp = new Employee();
                var emp = empBll.QueryById(item.EmployeeId);
                empList.Add(emp);
            }
            return empList;
        }

        /// <summary>
        /// 查询不是该项目的员工
        /// </summary>
        /// <param name="proName">该项目名改</param>
        /// <returns>非该项目员工集合</returns>
        public List<Employee> QueryOtherEmp(string proName)
        {
            EmployeeBll empBll = new EmployeeBll();
            List<Employee> otherEmp = new List<Employee> ();
            var pro = QueryProByName(proName);
            string pl = pro.PLId;
            string pm = pro.PMId;

            var allEmps = QueryAllExceptPLPM(pl, pm);//除该项目Pl,pm之外的所有员工
            var proEmps = QueryProEmp(proName);//项目员工
            if (proEmps.Count==0)
            {
                return allEmps;
            }

            otherEmp = allEmps.Except(proEmps,new Employee()).ToList();//将allemps里id与proemps不相同的员工添加到otherEmp
            
            //foreach (var item in allEmps)
            //{
            //    foreach (var proitem in proEmps)
            //    {
            //        if (item!=proitem)
            //        {
            //            otherEmp.Add(item);
            //        }
            //    }

            //}
            return otherEmp;
        }
        /// <summary>
        /// 查询项目信息 
        /// </summary>
        /// <param name="proName">项目名称</param>
        /// <returns>项目对象</returns>
        public Project QueryProByName(string proName)
        {
            ProjectBll proBll = new ProjectBll();
            return proBll.QueryByName(proName)[0];
        }

        /// <summary>
        /// 查询除PLPM之外的所有员工
        /// </summary>
        /// <param name="PL">pl的id</param>
        /// <param name="PM">pm的id</param>
        /// <returns>除PLPM之外的所有员工集合</returns>
        public List<Employee> QueryAllExceptPLPM(string PL, string PM)
        {
            EmployeeBll empBll = new EmployeeBll ();
            List<Employee> all = new List<Employee>();
            all.Clear();
            all = empBll.QueryAll();
            List<Employee> need = new List<Employee>();
            need.Clear();
            foreach (var item in all)
            {
                if (item.Id!=PL&&item.Id!=PM)
                {
                    need.Add(item);
                }
            }
            //if (need.Count!=0)
            //{
            //    return need;
            //}
            return need;
        }

        /// <summary>
        /// 根据员工号查询他所属项目,返回项目名集合
        /// </summary>
        /// <param name="id">员工号</param>
        /// <returns>项目名称的集合</returns>
        public List<string> QueryLikeThis(string id)
        {
            EPRelationDal eDal = new EPRelationDal();
            List<string> list = new List<string>();
            list.Clear();
            var datas = eDal.QueryLikeThis(id);
            if (datas.Count== null )
            {
                return null;
            }
            foreach (var item in datas)
            {
                list.Add(item.ProjectName);
            }
            return list;
        }
    }
}
