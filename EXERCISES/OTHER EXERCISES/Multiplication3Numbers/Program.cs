using System;

namespace Multiplication3Numbers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int number1, number2, number3, result;

            Console.Write("Enter number1: ");
            number1 = int.Parse(Console.ReadLine());
            Console.Write("Enter number2: ");
            number2 = int.Parse(Console.ReadLine());
            Console.Write("Enter number3: ");
            number3 = int.Parse(Console.ReadLine());
            result = number1 * number2 * number3;
            Console.WriteLine("Result = {0}", result);
            Console.Read();

        }
    }
}