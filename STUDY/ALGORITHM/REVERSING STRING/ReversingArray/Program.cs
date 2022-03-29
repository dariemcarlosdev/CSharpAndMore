using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversingArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Reverse.ReverseString("sdvfffvf");
            Console.WriteLine(a);
        }
    }

    public static class Reverse
    {

        public static string ReverseString(string S)
        {
            var ListChar = S.ToCharArray();
            Array.Reverse(ListChar);

            return new string(ListChar);
        }
    
    }
}
