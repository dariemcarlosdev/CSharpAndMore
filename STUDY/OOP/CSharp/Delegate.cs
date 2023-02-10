using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Delegate
    {
        // Delegates are function pointers. It's a refererence data type that hold a reference to a method.
        public delegate void Print<TypeOfValue>(TypeOfValue value); //here we are using Generic Method.

        public static void PrintNumber(int num) {

            Console.WriteLine("Number {0,-12:N0}", num);

        }

        public static void PrintMoney(int monkey) {

            Console.WriteLine("Monkey {0:C}", monkey);
        }

        public static void PrintProduct(string name) {

            Console.WriteLine("Product name: {0}", name);
        }
    }
}
