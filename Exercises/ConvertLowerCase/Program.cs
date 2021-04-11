using System;

namespace ConvertLowerCase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter str to convert: ");
            string str = Console.ReadLine();
            Console.WriteLine(str.ToLower());
            Console.Read();
        }
    }
}
