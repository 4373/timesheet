using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Leave
    {
        public int Id { get; set; }

        public string EmployeeId { get; set; }

        public DateTime DateTimeStart { get; set; }

        public DateTime DateTimeEnd { get; set; }

        public float Duration { get; set; }

        public string  Reason { get; set; }

        public string  Status { get; set; }


    }
}
