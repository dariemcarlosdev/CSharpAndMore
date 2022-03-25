using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateClass
{   /*
     Delegates are reference types. It's like a pointer to a function. Holds a reference to a methods. We use delegate to write generic type-safe functions.

        The Following are the characteristics of delegates:

        Delegates derive from the System. Delegate class.
        Delegates have a signature as well as return type. A function assigned to delegates must be fit with this signature.
        Delegates can point to instance methods or static.
        Delegate objects, once created, can dynamically invoke the methods it points to at runtime.
        Delegates can call methods synchronously and asynchronously.            
     */
    class Program
    {   
        //declaring delegate. 
        public delegate void PrintDistance (int a, int b);
        static void Main(string[] args)
        {   //print delagate point to static ReturnDistance() method.

            //Single Delegate: Invoke a single method.
            PrintDistance printDistanceAB = ReturnDistanceAB;
            Console.WriteLine("Single Delegate:");
            printDistanceAB(4, 7);
            PrintDistance printDistanceBC = ReturnDistanceBC;
            printDistanceBC(8, 9);

            //Milti-Cast Delegate: Invoke multiples methods. We can add a method in the delegate instance using + operator,
            //and we can remove a method using – operator. All the methods are invoked in sequence as they are assigned.

            PrintDistance multicast = printDistanceAB + printDistanceBC;
            Console.WriteLine("\nMultiCast Delegate:");
            multicast(16, 57);
            

        }

        public static void ReturnDistanceAB (int a, int b)
        {
            var distance = b - a;
            Console.WriteLine(distance);
        }

        public static void ReturnDistanceBC(int b, int c)
        {
            var distance = c - b;
            Console.WriteLine(distance);
        }
    }
}
