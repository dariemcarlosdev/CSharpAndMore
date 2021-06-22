#region
using System;
using System.Collections.Generic;
using System.Text;

namespace DepedencyInjection
{

    //Client Class: Depend on the Service Class.
 public  class EmployeeBL

    /*
     we created one constructor which accepts one parameter of the dependency object type. The point that you need to keep focus is, the parameter of the constructor is of the type interface,
    not the concrete class. Now, this parameter can accept any concrete class object which implements this interface.

    So here in the EmployeeBL class, we are not creating the object of the EmployeeDAL class. Instead, we are passing it as a parameter to the constructor of the EmployeeBL class.
    As we are injecting the dependency object through the constructor, it is called as constructor dependency injection in C#.
     */
    {
        private readonly IEmployeeDAL employeeDAL;

        public EmployeeBL(IEmployeeDAL employeeDAL)
        {
            this.employeeDAL = employeeDAL;
        }

        public List<Employee> GetEmployees()
        {
            return employeeDAL.SelectAllEmployees();
        }
 }
}
#endregion
