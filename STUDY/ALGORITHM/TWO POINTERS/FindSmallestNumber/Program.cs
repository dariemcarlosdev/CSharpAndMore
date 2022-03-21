using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSmallestNumber
{
    class Program
    {
        class Solution
        {
            public static int solution(int[] A)
            {
                int number = 0;
                var NewA = A.ToList<int>();

              
                
                //int i = 1;
                // write your code in C# 6.0 with .NET 4.5 (Mono)

                //var temp = new List<int>();

                for (int i = 1; i < 100000; i++)
                {

                    if (!NewA.Contains(i))
                    {

                        number = i;

                        break;
                    }
                    
                }  
                   return number;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution( new int[] { 1, 2, 3 }));
        }
    }
}
