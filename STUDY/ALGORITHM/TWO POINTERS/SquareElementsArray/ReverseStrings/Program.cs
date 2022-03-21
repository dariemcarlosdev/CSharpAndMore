using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStrings
{
    class Program
    {
        public class Solution
            {

            public static void ReverseString(char[] s)
            {
                var start = 0;
                var end = s.Length - 1;
                while (start < end)
                {
                    var tem = s[end];
                    s[end] = s[start];
                    s[start] = tem;

                    start++;
                    end--;
                }

                for (int i = 0; i < s.Length; i++)
                {
                    Console.Write("{0} ",s[i]);
                }
                Console.Read();
            }

        }
        static void Main(string[] args)
        {
            Solution.ReverseString(new char[] { 'h', 'e', 'l', 'l', 'o' });
            Solution.ReverseString(new char[] { 'H', 'a', 'n', 'n', 'a', 'h' });
        }
    }
}
