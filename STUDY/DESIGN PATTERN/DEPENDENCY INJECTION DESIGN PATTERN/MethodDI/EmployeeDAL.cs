using System;
using System.Collections.Generic;
using System.Text;

namespace MethodDI
{
    public class EmployeeDAL : IEmployeeDAL
    {
        public List<Employee> SelectAllEmployees()
        {
            var listEmployees = new List<Employee>();
            listEmployees.Add(new Employee { ID = 12, Department = "A", Name = "Dariem" });
            listEmployees.Add(new Employee { ID = 32, Department = "A", Name = "Jose" });
            listEmployees.Add(new Employee { ID = 42, Department = "B", Name = "Lazaro" });

            return listEmployees;
        }
    }
}
