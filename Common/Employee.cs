using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Employee : IEqualityComparer<Employee> 
    {
        
        public string Id
        {
            get;
            set;
        }
        public string Name
        {
            set;
            get;

        }

        public string Email
        {
            set;
            get;
        }

        public string Telephone
        {
            set;
            get;
        }
        public string Mobile
        {
            set;
            get;
        }
        public string CreateDate
        {
            set;
            get;
        }

        public bool Equals(Employee x, Employee y)
        {
            if (x.Id.Equals(y.Id))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Id.GetHashCode();
        }

        
    }
}
