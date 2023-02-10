using OOP.Abstract_Class_and_Interfaces;
using OOP.Design_Patterns.DI;
using OOP.MultipleInheritance;
using System;
using OOP.Design_Patterns.PropertyDI;
using OOP.Design_Patterns.Behavioral_DP.Strategy;

namespace OOP
{
    class Program
    {

        static int i = 0;
        static void Main(string[] args)
        {
            // Polymorphism: Ability of an object to act differently under different conditions.
            // Static Polymorphism (link a method to an object during compile time- method overloading): it's implemented by method overloading.
            // Dynamic Polymorphism (link a method to an object during run-time time- method overriding): it's implemented by method overriding.
            User d1 = new Doctor(); // right here object d1 is acting like a Doctor.
            d1.Validate();
            d1 = new Patient(); // and here same object d1 dinamically is acting(become) like a Patient.
            d1.Validate();

            User p2 = new Patient();

            d1.name = "da";
            p2.name = "ca";
            // abstraction happens during the design phase.
            // we decide what has to be shown as public.
            // during the execution phase we uses encapsulation through out access modifier public, private, protected
            // to implement abstraction. Encapsulation hide complexity. Any high complex functionality wont be shown out side the class.
            Console.WriteLine(d1.name, p2.name);

            //Static polymorphism - operator overloading tecnique.

            var o1 = new OperatorOverloading(10);
            var o2 = new OperatorOverloading(20);
            var o3 = o1 + o2;
            Console.WriteLine(o3.somevalue);

            //Abstract Class and Interfaces.

            var cg = new CustomerGold();
            cg.productamount = 30;

            Console.WriteLine(cg.CalculateDiscount());
            var cs = new CustomerSilver();
            cs.productamount = 40;
            Console.WriteLine(cs.CalculateDiscount());

            //--------Interfaces---------------
            //The Client will go through the CONTRACT (interface) only.

            ICustomer x = new CustomerGold();
            x.name = "sas";
            x.LastName = "dasd";
            x.totalBough();

            ICustomer x1 = new CustomerSilver();
            x1.totalBough();

            ICustomerWithInterest x2 = new CustomerGold();
            x2.CalculateDiscount();
            x2.totalBough();
            x2.CustomerInterest();

            // INTERFACE SEGGREGATION means you are not to force the client to use
            // unnecessary methods which it's not suppose to use.
            // for example ICustomer does not has the method called as CustomerInterest(), just the clients who have interest applied
            // will use this method through ICustomerWithInterest Interface.
            //YOU WILL CREATE DIFFERENT INTERFACES and don't force the client to use unnecesary method which he is not interested to use.

            //-----------CONSTRUCTOR DEPENDENCY INJECTION---------------------------------------
            Console.WriteLine("\n CONSTRUCTOR DEPENDENCY INJECTION");
            var employeesBL = new Design_Patterns.DI.EmployeeBL(new ManagerDAL());
            var listEmployee = employeesBL.GetEmployees();
            Console.ReadLine();
            foreach (var item in listEmployee)
            {
                Console.WriteLine("Employee Name:{0}-----> Employee Address: {1}", item.Name, item.Address);
            }
            //-----------PROPERTY DEPENDENCY INJECTION---------------------------------------
            Console.WriteLine("\n PROPERTY DEPENDENCY INJECTION");
            var employeesBLP = new Design_Patterns.PropertyDI.EmployeeBL();
            employeesBLP.employeeDataObject = new EmployeeDAL();
            var employeesList = employeesBLP.GetAllEmployees();
            Console.ReadLine();
            foreach (var item in employeesList)
            {
                i++;
                Console.WriteLine("Employee {2} Name:{0}-----> Employee {2} Address: {1}", item.Name, item.Address, i);


            }


            //----------METHOD DEPENDENCY INJECTION------------------------------------------------
            Console.WriteLine("\n PROPERTY DEPENDENCY INJECTION");
            var employeeBLM = new Design_Patterns.MethodDI.EmployeeBL();
            var listEmployees = employeeBLM.GetAllEmployee(new ManagerDAL());
            Console.ReadLine();
            foreach (var item in listEmployees)
            {
                i++;
                Console.WriteLine("Employee {2} Name:{0}-----> Employee {2} Address: {1}", item.Name, item.Address, i);
            }


            //------------------STRATEGY DESIGN PATTERN----------------------------------------------

            /*--Entities involved in STRATEGY
            1- Strategy(Interface): declare interface that's gonna be implemented by all concrete Strategies.
            2- Concrete Strategy: classes that implemente the Strategy.
            3- Context: Class that holds a reference to the strategy object, and use this reference to call the algorithm defined by a concrete Strategy.

            When do we need to use the Strategy Design Pattern in real-time applications?
            
            1- when we have diferents solution for the same tasks and selection criterial of the solution will be defined at run-time.
            2- when you want different variants for one lagorithm.
            3- when releted class differs in their behavior only.


             */

            Console.WriteLine("\n STRATEGY DESIGN PATTERN");
            Console.Read();
            var strategyctx = new Design_Patterns.Behavioral_DP.Strategy.ContextCompression(new ZipCompression());
            strategyctx.CreateFiles("fileName1");
            strategyctx.SetStrategy(new RarCompression());
            strategyctx.CreateFiles("fileName2");
        }
    }
}
