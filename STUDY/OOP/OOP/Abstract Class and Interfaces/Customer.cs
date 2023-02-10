using OOP.MultipleInheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Abstract_Class_and_Interfaces
{
    // Abstract class is a HIGH DEFINED Parent Class, PARTIALLY DEFINED parent class. Contain partial implementation of an Iterface.
    // It can only contain abstracts or virtuals methods. (https://www.tutorialspoint.com/csharp/pdf/csharp_polymorphism.pdf)
    // We cannot create an instance of this class.
    abstract class Customer : ICustomer, ICustomerWithInterest //when implement interface all properties, methods signatures need to be follow religiosly. 
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string LastName { get; set; }

        public decimal productamount { get; set; }

        // This method is gonna be rewritten by child classes.
        // Abstract method in abstract class are by default Virtual.
        public abstract decimal CalculateDiscount();

        public decimal CustomerInterest()
        {
            return 0;
        }

        public void Total() {

             throw new NotImplementedException("No result");
        
        }

        public int totalBough()
        {
            //your implementation here
            return 100;
        }
    }
}
