using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInversionCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inversion Counter: " + InversionCount(new int[] { -1,6,3,4,7,4 }));
        }

        public static int InversionCount( int[] A)
        {
            var start_pointer = 0;
            var counter = 0;
            while (start_pointer < A.Length - 1)
            {
                if (A.Length == 1)
                {
                    return -1;
                }

                for (int i = start_pointer + 1 ; i < A.Length; i++)
                {
                    if (A[i] >= A[start_pointer])
                    {
                        continue;
                    }

                    else counter++;
                }
                
                start_pointer += 1;
                
            }

            return counter;
        }

       
    }
}
