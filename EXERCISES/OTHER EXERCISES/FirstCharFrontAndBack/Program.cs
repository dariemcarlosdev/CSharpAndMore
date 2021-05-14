using System;

namespace FirstCharFrontAndBack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string to test: ");
            string str = Console.ReadLine();
            Console.WriteLine(FrontBackFirstChar(str));
            Console.Read();
        }

        private static string FrontBackFirstChar(string str)
        {
            return str.Length > 1 ? str.Substring(0, 1) + str + str.Substring(0,1) : str;
        }
    }
}
