using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Design_Patterns.DI
{
    class EmployeeDAL : IEmployeeDAL
    {

        private List<Employee> ListEmployee { get; set; }

        public void SetEmployee()
        {
            ListEmployee = new List<Employee>();
            ListEmployee.Add(new Employee() { Name="Dariem",Address="dasdad" });
            ListEmployee.Add(new Employee() { Name="Carlos",Address="ccccccc" });
            
        }

        public List<Employee> SelectEmployee()
        {
            SetEmployee();
            return ListEmployee;
        }
    }
}
