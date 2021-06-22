using System;

namespace DepedencyInjection
{
    class Program
    {   
        //Injector Class: create an object of the Service Class, and inject that object to the Client Class.
        static void Main(string[] args)
        {

            //Constructor Injection: When the Injector injects the dependency object (i.e. service) through the client class constructor, then it is called as Constructor Injection.
            
            var employeeBL = new EmployeeBL(new EmployeeDAL());
            var listEmployee = employeeBL.GetEmployees();

            foreach (var employee in listEmployee)
            {
                Console.WriteLine($"{employee.ID}, {employee.Name}, {employee.Department}");
            }
        }
    }
}
