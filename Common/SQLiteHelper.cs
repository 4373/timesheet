using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
  public  class SQLiteHelper
    {
        private static SQLiteConnection conn = null;
        private static SQLiteCommand cmd = null;
        private static SQLiteDataReader sdr = null;
        static string ConnectionString = ConfigurationManager.AppSettings["connectionString"];


        ///
        /// 获取连接结果，未连接打开连接
        ///
        /// 连接结果
        private static SQLiteConnection GetConn()
        {
            conn = new SQLiteConnection(ConnectionString);
            conn.SetPassword("timesheet");
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
        /// <summary>
        /// 判断是否查询目标存在
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns>存在返回true ,否则返回false</returns>
        public static bool IsExist(string sql, params  SQLiteParameter[] paras)
        {
            try
            {
                GetConn();
                using (cmd = new SQLiteCommand(sql, conn))
                {
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
                    }

                    return cmd.ExecuteScalar() != null;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }





        ///
        /// 该方法执行传入的增删改SQL语句
        ///
        /// 要执行的增删改SQL语句
        /// 返回更新的记录数
        public static int ExecuteNonQuery(string sql)
        {
            int res;
            try
            {
                cmd = new SQLiteCommand(sql, GetConn());
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //res = -1;
                throw ex;
            }
            finally
            {
                CloseConn();
            }
            return res;
        }

        public static SQLiteDataReader ExecuteReader(string sql)
        {
            GetConn();
            cmd = new SQLiteCommand(sql, conn);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);

        }

        public static DataSet ExecuteDataset(string sql)
        {
            GetConn();
            var adapter = new SQLiteDataAdapter(sql, conn);
            var dataset = new DataSet();
            adapter.Fill(dataset);
            CloseConn();
            return dataset;
        }

        public static SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] paras)
        {
            GetConn();
            cmd = new SQLiteCommand(sql, conn);
            if (paras != null)
            {
                cmd.Parameters.AddRange(paras);
            }

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);

        }
        ///
        /// 执行带参数的SQL增删改语句
        ///
        /// SQL增删改语句
        /// 参数集合
        /// 返回更新的记录数
        public static int ExecuteNonQuery(string sql, SQLiteParameter[] paras)
        {
            int res;
            try
            {
                using (cmd = new SQLiteCommand(sql, GetConn()))
                {
                    cmd.Parameters.AddRange(paras);
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                CloseConn();
            }

            return res;
        }
        ///
        /// 该方法执行传入的SQL查询语句
        ///
        /// SQL查询语句
        /// 返回数据集合
        public static DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            cmd = new SQLiteCommand(sql, GetConn());
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }
        ///
        /// 执行带参数的SQL查询语句
        ///
        /// SQL查询语句
        /// 参数集合
        /// 返回数据集合
        public static DataTable ExecuteQuery(string sql, SQLiteParameter[] paras)
        {
            DataTable dt = new DataTable();
            cmd = new SQLiteCommand(sql, GetConn());
            cmd.Parameters.AddRange(paras);
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }
        ///
        /// 执行带参数的SQL查询判断语句
        ///
        /// SQL查询语句
        /// 参数集合
        /// 返回是否为空
        public static bool BoolExecuteQuery(string sql, SQLiteParameter[] paras)
        {
            try
            {
                cmd = new SQLiteCommand(sql, GetConn());
                cmd.Parameters.AddRange(paras);
                return cmd.ExecuteScalar() != null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConn();
            }

        }
        ///
        /// 该方法执行传入的SQL查询判断语句
        ///
        /// SQL查询语句
        /// 返回是否为空
        public static bool BoolExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            cmd = new SQLiteCommand(sql, GetConn());
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            DataRow[] rows = dt.Select();
            bool temp = false;
            if (rows.Length > 0)
            {
                temp = true;
            }
            return temp;
        }
        static void CloseConn()
        {
            if (conn != null)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

        }

        /// <summary>
        /// 执行插入多条记录的操作
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static bool ExecuteTra(Dictionary<StringBuilder, SQLiteParameter[]> dic)
        {
            SQLiteTransaction tra = null;
            try
            {
                cmd = new SQLiteCommand() { Connection = GetConn() };

                tra = conn.BeginTransaction();
                cmd.Transaction = tra;
                foreach (var item in dic.Keys)
                {
                    cmd.CommandText = item.ToString();
                    cmd.Parameters.AddRange(dic[item]);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                tra.Commit();
                return true;
            }
            catch (Exception)
            {
                tra.Rollback();
                return false;
            }
            finally
            {
                CloseConn();
            }

        }

        public static bool InitDB()
        {
            GetConn();

            //set passwd
//            conn.ChangePassword("111");

//            //create USER_INFO table
//            string sql = @"CREATE TABLE 员工信息表(
//                                员工编号 varchar(10) PRIMARY KEY UNIQUE NOT NULL,
//                                员工姓名 varchar(10)  NOT NULL,
//                                手机 int(11) ,
//                                固话 int(11), 
//                                邮箱 varchar(50),
//                                项目组 varchar(50),
//                                create_at datetime NOT NULL default (datetime('now','localtime')),
//                                update_at datetime NOT NULL default (datetime('now','localtime'))
//                                )";
//            int res = ExecuteNonQuery(sql);
//            if (res == -1)
//            {
//                return false;
//            }

//            //create PAT_INFO table
//            sql = @"CREATE TABLE 加班时间统计表( 
//                        员工编号 varchar(10) PRIMARY KEY UNIQUE NOT NULL,
//                        加班时间 varchar(20) NOT NULL,
//                        已调休时间 varchar(20) NOT NULL,
//                        未调休时间 varchar(20) NOT NULL
//                        create_at datetime NOT NULL default (datetime('now','localtime')),
//                        update_at datetime NOT NULL default (datetime('now','localtime'))
//                        )";
//            res = ExecuteNonQuery(sql);
//            if (res == -1)
//            {
//                return false;
//            }

//            //create BP_INFO table
//            sql = @"CREATE TABLE 加班详情表( 
//                        员工编号 varchar(10) PRIMARY KEY UNIQUE NOT NULL,
//                        加班日期 varchar(100) ,
//                        加班时间 varchar(100), 
//                        create_at datetime NOT NULL default (datetime('now','localtime')), 
//                        update_at datetime NOT NULL default (datetime('now','localtime')), 
//                        )";
//            res = ExecuteNonQuery(sql);
//            if (res == -1)
//            {
//                return false;
//            }

//            //create 调休 table
//            sql = @"CREATE TABLE 调休详情表( 
//                        员工编号 varchar(10) PRIMARY KEY UNIQUE NOT NULL,
//                        调休日期 varchar(100) ,
//                        调休时间 varchar(100), 
//                        create_at datetime NOT NULL default (datetime('now','localtime')), 
//                        update_at datetime NOT NULL default (datetime('now','localtime')), 
//                        )";
//            res = ExecuteNonQuery(sql);
//            if (res == -1)
//            {
//                return false;
//            }


//            //登录信息表
//            sql = @"CREATE TABLE 登录信息表( 
//                                          user_name, 
//                                          password
//                                         ) 
//                                   VALUES(
//                                          'admin', 
//                                          'admin'
//                                         )";
//            res = ExecuteNonQuery(sql);
//            if (res == -1)
//            {
//                return false;
//            }


//            //            init USER_INFO table
//            //            sql = @"INSERT INTO USER_INFO(
//            //                                          user_name, 
//            //                                          password
//            //                                         ) 
//            //                                   VALUES(
//            //                                          'admin', 
//            //                                          'admin'
//            //                                         )";


//            sql = @"INSERT INTO 登录信息表(
//                                          user_name, 
//                                          password
//                                         ) 
//                                   VALUES(
//                                          'staff', 
//                                          'staff'
//                                         )";
//            res = ExecuteNonQuery(sql);
//            if (res == -1)
//            {
//                return false;
//            }

            return true;
        }
    }
}
