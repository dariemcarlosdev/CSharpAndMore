using OOP.Abstract_Class_and_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.MultipleInheritance
{
    // Multiple Inheritance (Multiple Interfaces). This allow to handle changes in an interfaces as adding new method to an existing interface,
    //but creating new Interfaces that contains new method definitions that need to be added. 
    // In this case that you are modifying an interface, you'll definitely do not do in the current interface (ICustomer)
    // you actually have to create a new one. 
    // Multiple Inheritance help to add new methods with out affecting the old interface. 
    public interface ICustomerWithInterest : ICustomer // this interface have all things of ICustomer and will have extra method.
    {
        public decimal CustomerInterest();
    }
}
