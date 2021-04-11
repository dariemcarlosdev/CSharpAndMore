using System;

namespace PrintOddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int n= 1;  n <=99; n++)
            {
                if (n%2!=0)
                {
                    Console.WriteLine(n.ToString());
                }
            }
        }
    }
}
