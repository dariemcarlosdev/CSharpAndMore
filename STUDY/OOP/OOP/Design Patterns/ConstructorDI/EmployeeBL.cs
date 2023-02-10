using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Design_Patterns.DI
{
    class EmployeeBL
    {
        public IEmployeeDAL employees;
        /*
          The point that you need to keep focus is, the parameter of the constructor is of the type interface, not the concrete class.
          Now, this parameter can accept any concrete class object that implements the IEmployeeDAL interface.

        So here in the EmployeeBL class, we are not creating the object of the EmployeeDAL class. Instead, we are passing it as a parameter to the constructor of the EmployeeBL class. 
        As we are injecting the dependency object through the constructor, it is called constructor dependency injection in C#.
         */
        public EmployeeBL(IEmployeeDAL employees)
        {
            this.employees = employees;
        }

        public List<Employee> GetEmployees() {

            return employees.SelectEmployee();
        
        }
    }
}
