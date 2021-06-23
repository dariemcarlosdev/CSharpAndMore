using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyDI
{
     public class EmployeeDAL : IEmployeeDAL
    {
        public List<Employee> SelectAllEmployees()
        {

                var ListEmplyees = new List<Employee>();
                ListEmplyees.Add(new Employee { ID = 12, Department = "A", Name = "Dariem" });
                ListEmplyees.Add(new Employee { ID = 32, Department = "A", Name = "Jose" });
                ListEmplyees.Add(new Employee { ID = 42, Department = "B", Name = "Lazaro" });

                return ListEmplyees;
           
        }
    }
}
