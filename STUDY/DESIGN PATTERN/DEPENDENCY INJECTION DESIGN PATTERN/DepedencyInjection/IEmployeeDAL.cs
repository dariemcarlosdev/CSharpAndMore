using System;
using System.Collections.Generic;
using System.Text;

namespace DepedencyInjection
{   
    //Service Class: Provide Services to Client Class.
    public interface IEmployeeDAL
    {
         List<Employee> SelectAllEmployees();

    }
}
