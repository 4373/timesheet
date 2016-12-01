using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.SQLite;

namespace DAl
{
    public class EPRelationDal
    {
        public bool AddAfterDeleteInfo(List<EPRelation> epr)
        {
            try
            {
                string sql = string.Format("delete from EPRelation where ProjectName ='{0}';",epr[0].ProjectName);

                foreach (var item in epr)
                {
                    string emp = item.EmployeeId;
                    string pro = item.ProjectName;
                    sql += string.Format("insert into EPRelation(EmployeeId,ProjectName,CreateDate) values('{0}','{1}','{2}') ;", emp, pro,item.CreateDate);
                }
                SQLiteHelper.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

            
        }
        /// <summary>
        /// 根据项目名查询关系表
        /// </summary>
        /// <param name="name">项目名</param>
        /// <returns>项目相同的,工号不同的关系类集合</returns>
        public List<EPRelation> QueryByProName(string name)
        {
            string sql = "select * from EPRelation where ProjectName=@name";
            SQLiteParameter paras = new SQLiteParameter("@name", name);
            List<EPRelation> eprList = new List<EPRelation>();
            eprList.Clear();
            var reader = SQLiteHelper.ExecuteReader(sql, paras);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    EPRelation epr = new EPRelation();
                    epr.EmployeeId = reader[2].ToString();
                    epr.ProjectName = reader[1].ToString();
                    eprList.Add(epr);
                }
            }
            reader.Close();
            return eprList;
        }

        //根据员工编号查询关系表
        public List<EPRelation> QueryLikeThis(string num)
        {
            List<EPRelation> list = new List<EPRelation>();
            list.Clear();
            string sql = " select * from EPRelation where EmployeeId like '%" + num + "%'";
            var reader =SQLiteHelper.ExecuteReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    EPRelation epr = new EPRelation();
                    epr.Id = Convert.ToInt32(reader[0]);
                    epr.ProjectName = reader[1].ToString();
                    epr.EmployeeId = reader[2].ToString();
                    epr.CreateDate = reader[3].ToString();
                    list.Add(epr);
                }
            }
            return list;
            reader.Close();
        }
    }
}
