using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Common;

namespace DAl
{
    public class ProjectDal
    {
        public bool AddProject(Project pro)
        {

            string sql = "insert into Project(PName,PLId,PMId,CreateTime,Status) values (@PName,@PLId,@PMId,@CreateTime,@Status)";
            SQLiteParameter[] paras = new SQLiteParameter[]
                {
                 
                    new SQLiteParameter("@PName",pro.PName),
                    new SQLiteParameter("@PLId",pro.PLId),
                    new SQLiteParameter("@PMId",pro.PMId),
                    new SQLiteParameter("@CreateTime",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SQLiteParameter("@Status",pro.Status),
                };
            int res = SQLiteHelper.ExecuteNonQuery(sql, paras);
            if (res == 1)
            {
                return true;
            }
            return false;
        }

        public bool IsNameExist(string name)
        {
            string sql = "select * from Project where PName = @name ";
            SQLiteParameter paras = new SQLiteParameter("@name", name);
            return SQLiteHelper.IsExist(sql, paras);
        }

        public List<Project> QueryAll()
        {
            List<Project> list = new List<Project>();
            list.Clear();
            string sql = "select * from Project";
            var reader = SQLiteHelper.ExecuteReader(sql);
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Project pro = new Project();
                    pro.Id = Convert.ToInt32(reader[0]);
                    pro.PName = reader[1].ToString();
                    pro.PLId = reader[2].ToString();
                    pro.PMId = reader[3].ToString();
                    pro.Status = reader[4].ToString();
                    pro.CreateDate = reader[5].ToString();
                    list.Add(pro);

                }
                return list;
            }
            reader.Close();
            return null;
        }

        public int UpdatePro(Project pro)
        {
            string sql = "update Project set PLId=@pl,PMId=@pm,Status=@status where PName= @name";
            SQLiteParameter[] paras = new SQLiteParameter[]{
                new SQLiteParameter("@name",pro.PName),
               // new SQLiteParameter("@Name",pro.PName),
                new SQLiteParameter("@pl",pro.PLId),
                new SQLiteParameter("@pm",pro.PMId),
                new SQLiteParameter("@status",pro.Status),
              
            };
            return SQLiteHelper.ExecuteNonQuery(sql, paras);
        }


        public List<Project> QueryByName(string name)
        {
            List<Project> list = new List<Project>();

            string sql = "select * from Project where PName = @Name";
            SQLiteParameter paras = new SQLiteParameter("@Name", name);
            var reader = SQLiteHelper.ExecuteReader(sql, paras);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Project pro = new Project();
                    pro.Id = Convert.ToInt32(reader[0]);
                    pro.PName = reader[1].ToString();
                    pro.PLId = reader[2].ToString();
                    pro.PMId = reader[3].ToString();
                    pro.Status = reader[4].ToString();
                    pro.CreateDate = reader[5].ToString();
                    list.Add(pro);

                }
                return list;
            }
            reader.Close();
            return null;
        }

        public List<Project> QueryByPLOrPMId(string id)
        {
            List<Project> list = new List<Project>();

            string sql = "select * from Project where PLId='"+id+ "'or PMId='"+id+"'";
            //SQLiteParameter[] paras = new SQLiteParameter[]{
            //  new SQLiteParameter  ("@PLId", id),
            //  new SQLiteParameter  ("@PMId", id)};
            var reader = SQLiteHelper.ExecuteReader(sql);//, paras);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Project pro = new Project();
                    pro.Id = Convert.ToInt32(reader[0]);
                    pro.PName = reader[1].ToString();
                    pro.PLId = reader[2].ToString();
                    pro.PMId = reader[3].ToString();
                    pro.Status = reader[4].ToString();
                    pro.CreateDate = reader[5].ToString();
                    list.Add(pro);

                }
                return list;
            }
            reader.Close();
            return null;
        }


        public int DeletePro(string id)
        {
            string sql = string.Format("delete from Project where Id = '{0}' ", id);

            return SQLiteHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据项目名或 PL或 PM 查询项目
        /// </summary>
        /// <param name="str">关键字</param>
        /// <returns>项目集合</returns>
        public List<Project> QureyLikeThis(string str)
        {
            List<Project> proList = new List<Project>();
            string sql = "select * from Project where PName like\"" + "%" + str + "%" + "\" or PLId like \"" + "%" + str + "%" + "\" or PMId like \"" + "%" + str + "%\"";
            // SQLiteParameter paras = new SQLiteParameter("@str", str);
            var reader = SQLiteHelper.ExecuteReader(sql);
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Project pro = new Project();
                    pro.Id = Convert.ToInt32(reader[0]);
                    pro.PName = reader[1].ToString();
                    pro.PLId = reader[2].ToString();
                    pro.PMId = reader[3].ToString();
                    pro.Status = reader[4].ToString();
                    pro.CreateDate = reader[5].ToString();
                    proList.Add(pro);

                }
                return proList;
            }
            reader.Close();
            return null;
        }

        /// <summary>
        /// 根据PLＰＭ模糊查询项目
        /// </summary>
        /// <param name="str"> pl 或 pm id</param>
        /// <returns>项目集合</returns>
        //public List<Project> QureyByPLOrPMLikeThis(string str)
        //{
        //    List<Project> proList = new List<Project>();
        //    string sql = "select * from Project where  PLId like \"" + "%" + str + "%" + "\" or PMId like \"" + "%" + str + "%\"";
        //    // SQLiteParameter paras = new SQLiteParameter("@str", str);
        //    var reader = SQLiteHelper.ExecuteReader(sql);
        //    if (reader.HasRows)
        //    {

        //        while (reader.Read())
        //        {
        //            Project pro = new Project();
        //            pro.Id = Convert.ToInt32(reader[0]);
        //            pro.PName = reader[1].ToString();
        //            pro.PLId = reader[2].ToString();
        //            pro.PMId = reader[3].ToString();
        //            pro.Status = reader[4].ToString();
        //            pro.CreateDate = reader[5].ToString();
        //            proList.Add(pro);

        //        }
        //        return proList;
        //    }
        //    return null;
        //}
    }
}
