using System;

namespace RemoveChar
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine(RmvChar("w3resource",1));
            Console.WriteLine(RmvChar("w3resource",9));
            Console.WriteLine(RmvChar("w3resource", 0));
        }

        public static string RmvChar(string v1, int v2)
        {
            return v1.Remove(v2, 1);
        }
    }
}
