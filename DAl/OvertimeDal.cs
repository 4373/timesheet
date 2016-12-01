using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Common;
using System.Data;

namespace DAl
{
    public class OvertimeDal
    {
        /// <summary>
        /// 添加加班详情
        /// </summary>
        /// <param name="overtime">加班详情类</param>
        /// <returns>添加成功返回true 否则返回false</returns>
        public bool Add(Overtime overtime)
        {
            string sql = " insert into Overtime(EmployeeId,ProjectId,DateTimeStart,DateTimeEnd,Duration,Reason,Status) values (@emp,@pro,@start,@end,@duration,@reason,@status) ";
            SQLiteParameter[] paras = new SQLiteParameter[]{
                new SQLiteParameter("@emp",overtime.EmployeeId),
                new SQLiteParameter("@pro",overtime.ProjectId),
                new SQLiteParameter("@start",overtime.DateTimeStart),
                new SQLiteParameter("@end",overtime.DateTimeEnd),
                new SQLiteParameter("@duration",overtime.Duration),
                new SQLiteParameter("@reason",overtime.Reason),
                new SQLiteParameter("@status",overtime.Status),
            };
            int res = SQLiteHelper.ExecuteNonQuery(sql, paras);
            if (res==1)
            {
                return true;   
            }
            return false;
        }

        /// <summary>
        /// 更新加班表
        /// </summary>
        /// <param name="ot">修改后的加班详情</param>
        /// <returns>修该成功返回true 其他返回false</returns>
        public bool Update(Overtime ot)
        {
            string sql = "update overtime set ProjectId=@Pro,DatetimeStart=@start,DatetimeEnd =@end,Duration=@duration,Status=@status,Reason=@reason where id =@id";
            SQLiteParameter[] paras = new SQLiteParameter[]{
                new SQLiteParameter ("@Pro",ot.ProjectId),
                new SQLiteParameter("@start",ot.DateTimeStart),
                new SQLiteParameter("@end",ot.DateTimeEnd),
                new SQLiteParameter("@id",ot.Id),
                new SQLiteParameter("@reason",ot.Reason),
                new SQLiteParameter("@duration",ot.Duration),
                new SQLiteParameter("@status",ot.Status)
            };
            int res = SQLiteHelper.ExecuteNonQuery(sql,paras);
            if (res==1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 查询加班表中的所有信息
        /// </summary>
        /// <returns> 一个加班类组成的list集合</returns>
        public List<Overtime> ReadAll()
        {
            string sql = "select * from Overtime ";
            var otList = new List<Overtime>();
            otList.Clear();
            var reader = SQLiteHelper.ExecuteReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var ot = new Overtime();
                    ot.Id =Convert.ToInt32( reader[0]);
                    ot.EmployeeId = reader[1].ToString();
                    ot.ProjectId = Convert.ToInt32(reader[2]);
                    ot.DateTimeStart = (DateTime)reader[3];
                    ot.DateTimeEnd = (DateTime)reader[4];
                    ot.Duration = (float)Math.Round(Convert.ToDouble(reader[5]),1);
                    ot.Reason = reader[6].ToString();
                    ot.Status = reader[7].ToString();
                    otList.Add(ot);
                }
            }
            reader.Close();
            return otList;
        }

        /// <summary>
        /// 根据员工号查询加班信息
        /// </summary>
        /// <param name="id">员工号</param>
        /// <returns>加班信息类的list集合</returns>
        public List<Overtime> QueryByEmpId(string id)
        {
            string sql = "select * from Overtime where EmployeeId ='" + id + "';";
            var reader =SQLiteHelper.ExecuteReader(sql);
            List<Overtime> otList = new List<Overtime>();
            otList.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Overtime ot = new Overtime();
                    ot.Id = Convert.ToInt32(reader[0]);
                    ot.DateTimeStart =(DateTime) reader[3];
                    ot.DateTimeEnd=(DateTime)reader[4];
                    otList.Add(ot);
                }
            }
            reader.Close();
            return otList;
        }
        /// <summary>
        /// 查询该员工的加班详情
        /// </summary>
        /// <param name="empid">员工id</param>
        /// <returns>员工的加班记录</returns>
        public DataSet QueryByEmpIdUsingDateSet(string empid)
        {
            string sql = "select o.Id 编号,o.EmployeeId 员工号,p.PName 项目名,o.DateTimeStart 开始时间,o.DateTimeEnd 结束时间,o.Duration 时长,o.Reason 加班原因,o.Status 状态 from Overtime as o left outer join Project as p on o.ProjectId=p.Id where o.EmployeeId='"+empid+"'";
            return SQLiteHelper.ExecuteDataset(sql);
        }


        public bool DeleteById(string id)
        {
            string sql = "delete from Overtime where id = '" + id + "'";
            int res =SQLiteHelper.ExecuteNonQuery(sql);
            if (res==1)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 模糊查询加班信息
        /// </summary>
        /// <param name="str">员工号,或员工名,或加班审批状态,或加班开始时间,或加班结束时间</param>
        /// <returns></returns>
        public DataSet QueryLikeThis(string str)
        {
            string sql = "select o.Id 编号,o.EmployeeId 员工号,p.PName 项目名,o.DateTimeStart 开始时间,o.DateTimeEnd 结束时间,o.Duration 时长,o.Reason 加班原因,o.Status 状态 from Overtime as o left outer join Project as p on o.ProjectId=p.Id where EmployeeId like '%"
                         + str + "%' or p.PName like '%"
                         +str+"%' or o.Status like '%"
                         +str+"%' or DateTimeStart like'%"
                         +str+"%' or DateTimeEnd like '%"+str+"%';";
            return SQLiteHelper.ExecuteDataset(sql);
        }
        /// <summary>
        /// 查询登录员工指定日期区间的加班详情 使用中文列名
        /// </summary>
        /// <param name="empid">员工编号</param>
        /// <param name="dateStart">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns>加班详情</returns>
        public DataSet QueryById( string empid,string dateStart, string dateEnd)
        {
            string sql = "select o.Id 编号,o.EmployeeId 员工号,p.PName 项目名,o.DateTimeStart 开始时间,o.DateTimeEnd 结束时间,o.Duration 时长,o.Reason 加班原因,o.Status 状态 from Overtime as o left outer join Project as p on o.ProjectId=p.Id where EmployeeId ='" + empid + "' and (DateTimeStart between '" + dateStart + "' and '" + dateEnd + "');";//,DateTimeEnd between '"+dateStart+"' and '"+dateEnd+"';";
            return SQLiteHelper.ExecuteDataset(sql);
        }



        public float AllHour(string id)
        {
            string sql = "select sum(Duration) as allhour from Overtime where EmployeeId='" + id + "'";
            var reader = SQLiteHelper.ExecuteReader(sql);
            float allHour = 0.0F;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader[0].ToString()!="")
                    {
                        allHour = (float)Math.Round(Convert.ToDouble(reader[0]), 1);
                    }
                }
            }
            return allHour;
        }
    }
}
