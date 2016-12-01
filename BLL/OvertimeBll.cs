using System.Collections.Generic;
using DAl;
using Common;
using System.Data;

namespace BLL
{
    public class OvertimeBll
    {
        /// <summary>
        /// 添加加班记录
        /// </summary>
        /// <param name="ot">加班记录类</param>
        /// <returns>添加成功返回 true 否则返回false</returns>
        public bool Add(Overtime ot)
        {
            OvertimeDal od = new OvertimeDal();
            var otList = od.QueryByEmpId(ot.EmployeeId);
            if (otList.Count == 0)
            {
                return od.Add(ot);
            }

            foreach (var item in otList)
            {
                var start = item.DateTimeStart;//某个加班详情的开始时间
                var end = item.DateTimeEnd;//结束时间

                //是否要添加的加班表的开始时间早于该item的开始时间   && 要添加的加班表结束时间早于该 item的开始时间
                bool early = ot.DateTimeStart.CompareTo(start) < 0 && ot.DateTimeEnd.CompareTo(start) < 0 ? true : false;

                //是否要添加的加班表的开始时间迟于该item的开始时间   && 要添加的加班表结束时间迟于该 item的开始时间
                bool late = ot.DateTimeStart.CompareTo(end) > 0 && ot.DateTimeEnd.CompareTo(end) > 0 ? true : false;
                if (!early && !late)
                {
                    return false;//如果不早于也不迟于  表示这段时间有加班.就不能添加此例
                }
            }
            return od.Add(ot);
            //select * from overtime where  starttime<xxx  and overtime>XXX and empid=XXX and id<>XXX
        }

        /// <summary>
        /// 返回所有员工的加班记录 管理员使用
        /// </summary>
        /// <returns>所有加班表的list集合</returns>

        public List<Overtime> ReadAll()
        {
            OvertimeDal od = new OvertimeDal();
            return od.ReadAll();
        }

        /// <summary>
        /// 更新加班表 
        /// </summary>
        /// <param name="ot">需要修改的加班表</param>
        /// <returns>修该成功返回true 否则返回false</returns>
        public bool Update(Overtime ot)
        {
            OvertimeDal od = new OvertimeDal();
            var otList = od.QueryByEmpId(ot.EmployeeId);
            if (otList.Count == 0)
            {
                return od.Add(ot);
            }

            foreach (var item in otList)
            {
                var start = item.DateTimeStart;
                var end = item.DateTimeEnd;

                //是否要添加的加班表的开始时间早于该item的开始时间   && 要添加的加班表结束时间早于该 item的开始时间
                bool early = ot.DateTimeStart.CompareTo(start) < 0 && ot.DateTimeEnd.CompareTo(start) < 0 ? true : false;

                //是否要添加的加班表的开始时间迟于该item的开始时间   && 要添加的加班表结束时间迟于该 item的开始时间
                bool late = ot.DateTimeStart.CompareTo(end) > 0 && ot.DateTimeEnd.CompareTo(end) > 0 ? true : false;
                if (item.Id!=ot.Id)//修改,,不与自己本身做比较
                {
                    if (!early && !late)
                    {
                        return false;//如果这段时间有加班.就不能更新此例
                    }
                }
 
            }
            return od.Update(ot);
        }

        /// <summary>
        /// 根据员工号查询加班信息
        /// </summary>
        /// <param name="empId">该员工工号</param>
        /// <returns>该员工的所有加班表</returns>
        public DataSet QueryByEmpIdUsingDateSet(string empId)
        {
            OvertimeDal od  = new OvertimeDal   ();
            var datas = od.QueryByEmpIdUsingDateSet(empId);
            return datas;
        }

        public DataSet QueryLikeThis(string str)
        {
            OvertimeDal od = new OvertimeDal();
            var datas = od.QueryLikeThis(str);
            return datas;
        }
        /// <summary>
        /// 根据员工号删除信息
        /// </summary>
        /// <param name="id">员工id</param>
        /// <returns>删除成功返回true 否则返回false</returns>
        public bool DeleteById(string id)
        {
            return new OvertimeDal().DeleteById(id);
        }

         /// <summary>
        /// 查询登录员工指定日期区间的加班详情 使用中文列名
         /// </summary>
         /// <param name="empid">员工编号</param>
         /// <param name="dateStart">开始时间</param>
         /// <param name="dateEnd">结束时间</param>
         /// <returns>加班详情</returns>

        public DataSet QueryDByIdAndDate(string empid, string dateStart, string dateEnd)
        {
            OvertimeDal ot = new OvertimeDal();
            return ot.QueryById(empid, dateStart, dateEnd);
        }
    }
}
