using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingZeroes
{
    public class Solution
    {

        public static void MoveZeroes(int[] numbs)
        {
            var last = numbs.Length - 1;
            var count = 0;

            for (int i = 0; i <= last; i++)
            {

                if (numbs[i] == 0)
                {
                    count++;

                }

                else

                    numbs[i - count] = numbs[i];
               
            }

            for (int i = numbs.Length - count; i < numbs.Length; i++)
            {
                numbs[i] = 0;
            }

            for (int i = 0; i <= numbs.Length - 1; i++)
            {
                Console.Write("{0} ", numbs[i]);
            }
        }
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution.MoveZeroes(new int[] { 0, 1, 0, 3, 12 });
            //Solution.MoveZeroes(new int[] { 0 });
        }
    }
}
