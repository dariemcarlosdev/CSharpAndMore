using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWordsInString
{
    public class Solution
    {
        public static string ReverseWords(string s)
        {
            var a = s.ToArray();           
            var start = 0;
            var last_index = a.Length-1;

            for (int i = 0; i < a.Length; i++)
                {
                if (a[i] == ' ' || i==last_index)
                {
                  var end = i == last_index ?  i : i-1;
                    while (start < end)
                    {
                        var temp = a[end];
                        a[end] = a[start];
                        a[start] = temp;
                        start++;
                        end--;
                    }

                    start = i + 1;
                }
            }
            return new string(a);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(Solution.ReverseWords("ets ake"));
        }
    }
}
