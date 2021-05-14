using System;

namespace CheckNegPos
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1, number2;

            Console.WriteLine("Enter number1: ");
            number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number1: ");
            number2 = int.Parse(Console.ReadLine());

            Console.WriteLine(CheckNegativeAndPositive(number1, number2));
            Console.Read();
        }

        private static bool CheckNegativeAndPositive(int number1, int number2)
        {
            return (number1 > 0 && number2 < 0) || (number1 < 0 && number2 > 0);
        }
    }
}
