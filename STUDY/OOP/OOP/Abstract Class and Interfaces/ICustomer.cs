using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Abstract_Class_and_Interfaces
{
    //Interfaces are a CONTRACT. All properties, methods are pure signature, do not have implementation.
    //All properties, all methods, are publics. 
    // By having a CONTRACT we have better control on implact analysis, change management and breaking changes.
    public interface ICustomer
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string LastName { get; set; }
        public int totalBough();
        public decimal CalculateDiscount();
    }
}
