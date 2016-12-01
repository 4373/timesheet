using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Project
    {
        /// <summary>
        /// 项目ID,数据库主键自动增长
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string PName { get; set; }
        /// <summary>
        /// 项目领导id
        /// </summary>
        public string PLId { get; set; }
        /// <summary>
        /// 项目经理id
        /// </summary>
        public string PMId { get; set; }

        //项目状态
        public string  Status { get; set; }

        public string  CreateDate { get; set; }

        

    }
}
