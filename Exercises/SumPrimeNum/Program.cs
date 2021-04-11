using System;

namespace SumPrimeNum
{
    class Program
    {
        private static int number;

        static void Main(string[] args)
        {
            Console.WriteLine("\nSum of first 500 prime numbers: ");
            number = 2;
            int Sum = 0;
            int counter = 0;

            while ( counter < 500) //500 ain´t prime number.
            {
                if (IsPrime(number))
                {
                    Sum += number;
                    counter++;
                }
                number++;
            }

            Console.WriteLine(Sum.ToString());
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            int x = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3 ; i <=x; i++)
            {
                if (number%i== 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
