using System;
using System.Collections.Generic;
using System.Text;

namespace DepedencyInjection
{   
    //Dedendency Class Interface based. EmployeeDAL object is the dependency object as this object is going to be used by EmployeeBL Class (Dependent Class), 
    //so we create the interface and then this EmployeeDAL implement that interface.
    public class EmployeeDAL : IEmployeeDAL
    {
        public  List<Employee> SelectAllEmployees()
        {
            var ListEmplyees = new List<Employee>();
            ListEmplyees.Add(new Employee { ID = 12, Department = "A", Name = "Dariem" });
            ListEmplyees.Add(new Employee { ID = 32, Department = "A", Name = "Jose" });
            ListEmplyees.Add(new Employee { ID = 42, Department = "B", Name = "Lazaro" });

            return ListEmplyees;
        }
    }
}
