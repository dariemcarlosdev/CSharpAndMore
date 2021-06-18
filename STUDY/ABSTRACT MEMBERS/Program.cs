using System;

namespace ABSTRACT_MEMBERS
{
    class Program
    {
        static void Main(string[] args)
        {   
            //Output Example Static and Non Static variables.
            Console.WriteLine($"Output Example Static and Non Static variables");
            Console.WriteLine($"static member: {StaticMembersExamples.y}");

            var obj1 = new StaticMembersExamples(30);

            var obj2 = new StaticMembersExamples(40);

            Console.WriteLine($"obj1 x: {obj1.x} obj2 x: {obj2.x}");
            Console.ReadKey();

            //Output Example Static and Non Static method.
            Console.WriteLine($"Output Example Static and Non Static method");
            StaticNonStaticMethods.Add();
            var obj3 = new StaticNonStaticMethods();
            obj3.Mul();
            Console.ReadKey();

            //Output Example Static and Non Static constructor.
             Console.WriteLine($"Output Example Static and Non Static constructor.");
             var obj5 = new StaticNonStaticConstructor();
             var obj6 = new StaticNonStaticConstructor();
             var obj7 = new StaticNonStaticConstructor();
              Console.ReadKey();

             // //Output Example Static Class.

             Console.WriteLine("Select convertion type.");
             Console.WriteLine("1. Celsius to Fahrenheit");
             Console.WriteLine("2. Fahrenheit to Celsius");
             Console.WriteLine(":");

             var selection = Console.ReadLine();
             double F,C = 0;

             switch (selection)
             {
                 case "1":
                    Console.WriteLine("Enter Celsius Temp. ");
                    C = StaticClass.CelciusToFahrenheit(Console.ReadLine());
                    Console.WriteLine("Temp in Fahrenheit is: {0:f2}", C);
                    break;
                 case "2":
                    Console.WriteLine("Enter Fahrenheit Temp. ");
                    F = StaticClass.FahrenheitToCelcius(Console.ReadLine());
                    Console.WriteLine("Temp im Celsious is {0:f2}",F);
                    break;
                 default:
                 Console.WriteLine("Select Convertion method.");
                 break;
             }   

        }
    }
}
