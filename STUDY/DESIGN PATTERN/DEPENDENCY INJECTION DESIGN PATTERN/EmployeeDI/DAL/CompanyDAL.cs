using EmployeeDI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDI.DAL
{
    //DEPENDENCY CLASS as going to be used by EmployeeBL class.
    public class CompanyDAL : ICompanyDAL
    {
        public List<Employee> ListEmployees { get; set; }
        public List<Supervisor> ListSupevisors { get; set; }

        public List<Employee> SelectAllEmployees() {

            ListEmployees = new List<Employee>();
            ListEmployees.Add(new Employee() { EmployeeID = 1, Name = "DADSSA", Department = "Department1" });
            ListEmployees.Add(new Employee() { EmployeeID=2, Name="EDFFD", Department="Department2"});
            ListEmployees.Add(new Employee() { EmployeeID=3, Name="XCVXV",Department="Department3"});

            return ListEmployees;
        }

        public List<Supervisor> SelectAllSupervisors()
        {

            ListSupevisors = new List<Supervisor>();
            ListSupevisors.Add(new Supervisor() { SupervisorID = 1, SupervisorName = "XXXXXX", SupervisorDeparment = "Department1" });
            ListSupevisors.Add(new Supervisor() { SupervisorID = 1, SupervisorName = "YYYYYY", SupervisorDeparment = "Department1" });
            ListSupevisors.Add(new Supervisor() { SupervisorID = 1, SupervisorName = "ZZZZZZ", SupervisorDeparment = "Department1" });
            ;

            return ListSupevisors;
        }
    }
}
