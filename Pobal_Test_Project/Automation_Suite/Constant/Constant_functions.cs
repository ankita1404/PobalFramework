using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Suite.Constant
{
    static class Constant_functions
    {
        public static string SetDateTimeValue()
        {

           DateTime dt = new DateTime();

            return dt.ToString("dddd, dd MMMM yyyy HH: mm:ss");



        }


    }

}

