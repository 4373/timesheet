using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAl;
using System.Data;

namespace BLL
{
    public class LeaveBll
    {
        /// <summary>
        /// 添加调休详情
        /// </summary>
        /// <param name="le">调休类</param>
        /// <returns>成功返回 true 否则返回false</returns>
        public bool Add(Leave le)
        {
            LeaveDal ld = new LeaveDal();
            if (ld.IsExistSame(le))
            {
                return false;
            }
            return ld.Add(le);
        }

        /// <summary>
        /// 查询总加班时间,已调休时间,剩余时间
        /// </summary>
        /// <param name="le">该员工id</param>
        /// <returns>结果返回成数组</returns>
        public float[] Hour(string id)
        {
            OvertimeDal ot = new OvertimeDal();
            LeaveDal ld = new LeaveDal();
            float all = ot.AllHour(id);
            float used = ld.UsedHour(id);
            float remain = all - used;
            float[] hours = { all, used, remain };
            return hours;

        }

        /// <summary>
        /// 查询员工一段时间的调休记录
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="id">员工id</param>
        /// <returns></returns>
        public DataSet QueryByEmpidBetween(string start, string end, string id)
        {
            return new LeaveDal().QueryByEmpidBetween(start, end, id);
        }

        /// <summary>
        /// 查询员工的所有调休记录
        /// </summary>
        /// <param name="id">员工id</param>
        /// <returns></returns>
        public DataSet QueryAllByEmpid(string id)
        {
            return new LeaveDal().QueryAllByEmpid(id);
        }

        /// <summary>
        /// 根据调休编号删除
        /// </summary>
        /// <param name="id">调休编号</param>
        /// <returns></returns>
        public bool DeleteById(int id)
        {
            return new LeaveDal().DeleteById(id);
        }

        /// <summary>
        /// 更新调休表
        /// </summary>
        /// <param name="le">新的调休信息</param>
        /// <returns></returns>
        public bool Update(Leave le)
        {
            LeaveDal ld = new LeaveDal ();
            var b =ld.IsExistSame(le);
            if (b)
            {
                return false;
            }
            return new LeaveDal().Update(le);
        }

    }
}
