using System;

namespace MethodDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeBL = new EmployeeBL();
            var listEmployees = employeeBL.GetEmployees(new EmployeeDAL());

            foreach (var employee in listEmployees)
            {
                Console.WriteLine($"{employee.ID}, {employee.Name}, {employee.Department}");
            }
        }
    }
}
