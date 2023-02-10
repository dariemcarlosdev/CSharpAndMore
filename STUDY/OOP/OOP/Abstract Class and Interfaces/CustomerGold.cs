using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Abstract_Class_and_Interfaces
{
    class CustomerGold : Customer
    {
        public override decimal CalculateDiscount()
        {
            return productamount - 10;
        }

    }
}
