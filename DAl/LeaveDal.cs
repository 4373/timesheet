using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.SQLite;
using System.Data;

namespace DAl
{
    public class LeaveDal
    {
        /// <summary>
        /// 判断该id这段时间是否已有记录
        /// </summary>
        /// <param name="le">调休记录</param>
        /// <returns>如果存在返回true 否则返回false</returns>
        public bool IsExistSame(Leave le)
        {
            var start = le.DateTimeStart;
            var end = le.DateTimeEnd;
            var id = le.Id;

            string sql = "select * from Leave where not(@start<DateTimeStart and @end <DateTimeStart) and not (@start>DateTimeEnd and @end >DateTimeEnd) and Id <> @id and EmployeeId=@empId";
            SQLiteParameter[] paras = new SQLiteParameter[]{
                new  SQLiteParameter ("@id",id),
                new  SQLiteParameter ("@start",start),
                new SQLiteParameter("@end",end),
                new SQLiteParameter("empId",le.EmployeeId)
            };
            var reader = SQLiteHelper.ExecuteReader(sql, paras);
            if (reader.HasRows)
            {
                return true;
            }
            reader.Close();
            return false;
        }

        /// <summary>
        /// 添加调休信息
        /// </summary>
        /// <param name="le">调休类</param>
        /// <returns>添加成功返回true 否则返回false</returns>
        public bool Add(Leave le)
        {

            string sql = " insert into Leave(EmployeeId,DateTimeStart,DateTimeEnd,Duration,Reason,Status) values (@emp,@start,@end,@duration,@reason,@status)";
            SQLiteParameter[] paras = new SQLiteParameter[]{
               // new SQLiteParameter("@id",le.Id ),
                new SQLiteParameter("@emp",le.EmployeeId),
                new SQLiteParameter("@start",le.DateTimeStart ),
                new SQLiteParameter("@end",le.DateTimeEnd ),
                new SQLiteParameter("@duration",le.Duration),
                new SQLiteParameter("@reason",le.Reason ),
                new SQLiteParameter("@status",le.Status )
            };
            int res = SQLiteHelper.ExecuteNonQuery(sql, paras);
            if (res == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 查询已用调休时间
        /// </summary>
        /// <param name="id">员工id</param>
        /// <returns></returns>
        public float UsedHour(string id)
        {
            string sql = "select sum(Duration) as leavehour from Leave where EmployeeId='" + id + "'";
            var reader = SQLiteHelper.ExecuteReader(sql);
            float usedHour = 0.0F;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var one = reader[0];
                    if (one.ToString() != "")
                    {

                        usedHour = (float)Math.Round(Convert.ToDouble(reader[0]), 1);
                    }
                }
            }
            return usedHour;
        }

        /// <summary>
        /// 根据员工号查询一段时间的调休记录
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="id">员工id</param>
        /// <returns></returns>
        public DataSet QueryByEmpidBetween(string start, string end, string id)
        {
            string sql = "select Id '编号',EmployeeId '员工号',DateTimeStart '开始时间',DateTimeEnd '结束时间',Duration '时长',Status '状态',Reason '原因' from Leave where DateTimeStart between '"
                          + start + "' and '" + end + "' and EmployeeId='" + id + "';";
            return SQLiteHelper.ExecuteDataset(sql);
        }

        /// <summary>
        /// 查询该员工所有的调休记录
        /// </summary>
        /// <param name="id">员工id</param>
        /// <returns></returns>
        public DataSet QueryAllByEmpid(string id)
        {
            string sql = "select Id '编号',EmployeeId '员工号',DateTimeStart '开始时间',DateTimeEnd '结束时间',Duration '时长',Status '状态',Reason '原因' from Leave where EmployeeId='" + id + "'";
            return SQLiteHelper.ExecuteDataset(sql);
        }
        /// <summary>
        /// 根据调休编号删除调休信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(int id)
        {
            string sql = "delete from Leave where Id ='" + id + "'";
            var res = SQLiteHelper.ExecuteNonQuery(sql);
            if (res == 1)
            {
                return true;
            }
            return false;
        }


        public bool Update(Leave le)
        {
            string sql = "update Leave set DateTimeStart=@start,DateTimeEnd=@end,Duration=@duration,Reason=@reason where Id = @id ";
            SQLiteParameter[] paras = {
                new  SQLiteParameter("@start",le.DateTimeStart),
                new SQLiteParameter("@end",le.DateTimeEnd ),
                new SQLiteParameter("@duration",le.Duration),
                new SQLiteParameter("@reason",le.Reason ),
                new SQLiteParameter("@id",le.Id )
            };
            var res = SQLiteHelper.ExecuteNonQuery(sql, paras);
            if (res==1)
            {
                return true;
            }
            return false;
        }
    }
}
