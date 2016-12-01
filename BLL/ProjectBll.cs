using Common;
using DAl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProjectBll
    {
        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="pro">项目对象</param>
        /// <returns>添加成功返回true  否则返回false</returns>
        public bool ProAdd(Project pro )
        {
            ProjectDal  proDal = new ProjectDal ();
            bool flag = true;
            if (!proDal.AddProject(pro))
            {
                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// 判断项目名是否存在
        /// </summary>
        /// <param name="name">项目名</param>
        /// <returns>存在返回true</returns>
        public bool IsNameExist(string name )
        {
            ProjectDal proDal = new ProjectDal ();
            return proDal.IsNameExist(name);
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<Project> QueryAll()
        {
            ProjectDal proDal = new ProjectDal ();
            return proDal.QueryAll();
        }

        /// <summary>
        /// 更新员工
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public bool UpdatePro(Project pro)
        {
            ProjectDal proDal = new ProjectDal ();
            int a = proDal.UpdatePro(pro);
            if (a==1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 按项目名查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Project> QueryByName(string name)
        {
            ProjectDal proDal = new ProjectDal();
            return proDal.QueryByName(name);
        }

        /// <summary>
        /// 按员工编号查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns>项目名称</returns>
        public List<Project> QueryByPMOrPLId(string id)
        {
            ProjectDal proDal = new ProjectDal();
            return proDal.QueryByPLOrPMId(id);
        }

        /// <summary>
        /// 查询员工的项目
        /// </summary>
        /// <param name="id">员工编号</param>
        /// <returns>返回项目集合</returns>
        public List<string> QueryWhenEmpIdLike(string id)
        {
            ProjectDal proDal = new ProjectDal();
            List<string> list = new List<string>();
            list.Clear();
            var datas = proDal.QueryByPLOrPMId(id);
            if (datas !=null )
            {
                foreach (var item in datas)
                {
                    list.Add(item.PName);
                }
               
            }
            return list;
        }

        /// <summary>
        /// 更新员工
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public bool UpdateEmp(Project pro)
        {
            ProjectDal proDal = new ProjectDal();
            int a =proDal.UpdatePro(pro);
            if (a==1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletePro(string id)
        {
            ProjectDal proDal = new ProjectDal();
            int a = proDal.DeletePro(id);
            if (a==1)
            {
                return true;
            }
            return false;
        }

        public List<Project> QueryLikeThis(string str)
        {
            ProjectDal proDal = new ProjectDal();

            return proDal.QureyLikeThis(str);
        }
    }
}
