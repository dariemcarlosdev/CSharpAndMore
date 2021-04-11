using System;

namespace StrFcharAndLcharChange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(First_Last("w3recource"));
            Console.WriteLine(First_Last("x"));
        }

        private static string First_Last(string str)
        {
           return str.Length > 1 ? str.Substring(str.Length - 1) + str.Substring(1, str.Length-1) + str.Substring(0,1)  : str;
        }
    }
}
