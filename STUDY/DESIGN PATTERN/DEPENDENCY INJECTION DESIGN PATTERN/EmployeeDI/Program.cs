using EmployeeDI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDI
{   
    //CLIENT CLASS
    class Program
    {
        static void Main(string[] args)
        {
            //This line commented for making able DI
            //var employeeBL = new EmployeeBL();

            Console.WriteLine("What List do you want to show up? 1. Employees 2.Supervisors");
            var selectedOption = Console.ReadLine();

            if (selectedOption.Equals("1",StringComparison.InvariantCultureIgnoreCase))
            {
                //passing EmployeeDAL instance to the constructor of the EmployeeBL class.
                var companyBL = new CompanyBL(new CompanyDAL());

                var listEmployee = companyBL.GetAllEmployees();
                foreach (var employee in listEmployee)
                {
                    Console.WriteLine("Employee ID: {0} EmployeeName:{1} EmployeeDepartment:{2}", employee.EmployeeID, employee.Name, employee.Department);
                    Console.ReadKey();
                }
            }

            if (selectedOption.Equals("2",StringComparison.InvariantCultureIgnoreCase))
            {
                var companyBL = new CompanyBL(new CompanyDAL());
                var listSupervisors = companyBL.GetAllSupervisors();
                foreach (var supervisor in listSupervisors)
                {
                    Console.WriteLine("SupervisorID: {0} SupervisorName:{1} SupervisorDepartment:{2}", supervisor.SupervisorID, supervisor.SupervisorName, supervisor.SupervisorDeparment);
                    Console.ReadKey();
                }
            }
           
        }
    }
}
