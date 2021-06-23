using System;

namespace PropertyDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeBL = new EmployeeBL();

            //We are using the public property EmployeeDAL in order to access the instance of ImployeeDAL and setting the dependency object throught the public porperty setter method.(Setter Dependency Injection)
            employeeBL.EmployeeDAL = new EmployeeDAL();


            var listEmployees = employeeBL.GetEmployees();

            foreach (var employee in listEmployees)
            {
                Console.WriteLine($"{employee.ID}, {employee.Name}, {employee.Department}");
            }
        }
    }
}
