using System;
using System.Linq;

/*Write a C# program to check if a given string contains 'w' character between 1 and 3 times.*/

namespace Count3FirstChart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string: ");
            string str = Console.ReadLine();
            var counter = str.Count(s => s == 'w' || s=='W');
            Console.WriteLine(counter>=1 && counter<=3);

        }
    }
}
