using System;
using System.Linq;

namespace CreateStringLowUpper
{
    class Program
    {/*Write a C# program to create a new string where the first 4 characters will be in lower case. 
      * If the string is less than 4 characters then make the whole string in upper case*/
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();
            if (str.Length < 4)
            {
                str.ToLower();
            }
            Console.WriteLine(str.Substring(0,4).ToLower() + str.Substring(4));
        }
    }
}
