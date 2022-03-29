using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCost
{
    class Program
    {
        class Solution
        {

            public static int solution(String S, int[] C)
            {
                var str = S.ToCharArray();
                int minimumCost = 0;

                if (S.Length == 1)
                {
                    minimumCost = C[0];
                }               

                for (int i = 0; i < str.Count()-1; i++)
                {
                    if (S[i] != S[i + 1] && C[i] != C[i + 1])
                    {
                        continue;
                    }
                    //else if (C[i] == C[i + 1])
                    //{
                    //    continue;
                    //}

                   minimumCost += Math.Min(C[i], C[i + 1]);
                }

                return minimumCost;
            }
        
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution("abccbd", new int[] { 0, 1, 2, 3, 4, 5 }));
            Console.WriteLine(Solution.solution("aabbcc", new int[] { 1, 2, 1, 2, 1, 2 }));
            Console.WriteLine(Solution.solution("aaaa", new int[] { 3, 4, 5, 6 }));
            Console.WriteLine(Solution.solution("aaaa", new int[] { 3, 4, 5, 5}));
            Console.WriteLine(Solution.solution("ababa", new int[] { 10, 5, 10, 5, 10 }));
            Console.WriteLine(Solution.solution("a", new int[] { 10 }));


        }
    }
}
