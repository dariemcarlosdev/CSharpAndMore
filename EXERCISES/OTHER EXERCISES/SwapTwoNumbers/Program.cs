using System;

namespace SwapTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1, number2, temp;
            Console.Write("Enter number1: ");
            number1 = int.Parse(Console.ReadLine());

            Console.Write("Enter number2: ");
            number2 = int.Parse(Console.ReadLine());

            temp = number1;
            number1 = number2;
            number2 = temp;

            Console.WriteLine("Number1 {0} and Number2 {1}", number1, number2) ;
            Console.Read();
        }
    }
}
