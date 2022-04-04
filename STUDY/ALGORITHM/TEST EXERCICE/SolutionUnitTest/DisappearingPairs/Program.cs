using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisappearingPairs
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine( DisppearingPairs("ABCBBCBA"));
        }

        static string DisppearingPairs(string S) 
        {
            int j = 0;
            if (S.ToCharArray() == S.ToCharArray().Reverse())
            {
                return S;
            }
            while (j < S.Length-1)
            {

                for (int i = 1; i < S.Length; i++)
                {
                    if (S[j] != S[i])
                    {
                        j++;
                    }
                    else
                    {
                        return DisppearingPairs(S.Remove(j, 2));
                    }
                }
                
            }

            return S;
        }
    }
}
