using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
  public  class Tool
    {
      public static  bool isNull(string str)
      {
          if (null==str||str.Trim().Equals(""))
          {
              return true;
          }
          return false;
      }


    }
}
