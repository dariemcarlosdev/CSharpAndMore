using System;
using System.Collections.Generic;
using System.Text;

namespace DepedencyInjection
{   
    //Service Class: Provide Services to Client Class.

    /*
    First we create one interface i.e IEmployeeDAL with the one method. Then that interface is implemented by the EmployeeDAL class.
    when we are going to use the dependency injection design pattern in c#, then the dependency object should be interface based.
    */
    public interface IEmployeeDAL
    {
         List<Employee> SelectAllEmployees();

    }
}
