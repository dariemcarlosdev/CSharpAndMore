using System;

namespace PrintRectangleWithNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber;

            Console.Write("Enter input number:");
            inputNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("{0}{0}{0}",inputNumber);
            Console.WriteLine("{0} {0}", inputNumber);
            Console.WriteLine("{0} {0}", inputNumber);
            Console.WriteLine("{0} {0}", inputNumber);
            Console.WriteLine("{0}{0}{0}", inputNumber);
            Console.Read();
        }
    }
}
