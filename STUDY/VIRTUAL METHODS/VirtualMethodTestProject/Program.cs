using System;
using VirtualMethodTestProject.Shapes;

namespace VirtualMethodTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter the distance");
            //var distance = Double.Parse(Console.ReadLine());
            //Console.WriteLine("Enter the Hour");
            //var hour = Double.Parse(Console.ReadLine());
            //Console.WriteLine("Enter the Fuel");
            //var fuel = Double.Parse(Console.ReadLine());

            ///*
            // When we call virtual and non-virtual methods by both class's instance then according to the run type the instance virtual method implementation is invoked;
            //in other words both class's instances invoke the subclass override method and the non-virtual method invoked is determined based on the instance of the class.
            // */

            //var car = new Car(distance, hour, fuel);
            //var vehicle = car;

            //car.Average();
            //vehicle.Average();
            //car.Speed();
            //vehicle.Speed();


            //Invoked Virtual Method that override and not override in derived classes


            /*
              When the virtual methods are overriden in a derived class and that derived class uses an instance then invokes a derived class overriden method.
            When a virtual method is not overriden in a derived class and uses that derived class instance then invokes base class virtual method.
             */

            Console.WriteLine("Enter the length:");
            var length = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the with:");
            var with = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the radius:");
            var radius = Double.Parse(Console.ReadLine());

            var rectangle = new Rectangle(length, with);
            var circle = new Circle(radius);

            rectangle.Area();
            circle.Area();


        }
    }
}
