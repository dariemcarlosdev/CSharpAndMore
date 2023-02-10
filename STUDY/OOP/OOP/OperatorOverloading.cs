using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class OperatorOverloading
    {

        public int somevalue { get; set; }

        public OperatorOverloading(int value)
        {
            somevalue = value;
        }

        public static OperatorOverloading operator +(OperatorOverloading arg1, OperatorOverloading arg2) {

            //operation you want to do.
            return new OperatorOverloading(arg1.somevalue - arg2.somevalue);
        
        }
    }
}
