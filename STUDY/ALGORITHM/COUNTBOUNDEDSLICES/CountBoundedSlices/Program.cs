using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CountBoundedSlices
{
    class Program
    {
        static void Main(string[] args)

        {
            var res = Math.Max(3, 3) - Math.Min(3, 3);
            Console.WriteLine(res);

            Console.WriteLine(CountBoundedSlices( 2, new int[] {3,5,7,6,3}));
            
       }


        
        static int CountBoundedSlices(int K, int[] A) 
        {
            if (A.Count()==1 && A[0]> K)
            {
                return 1;
            }

            var start_pointer_index = 0;
            var end_pointer_index = A.Length-1;
            var counter = 0;
            
            while (start_pointer_index <= end_pointer_index)
            {
                for (int i = 0; i <= A.Length-1; i++)
                {
                    var res = Math.Max(A[start_pointer_index], A[i]) - Math.Min(A[start_pointer_index], A[i]);
                    
                    if ( A[i] < 2 || (res > 2))
                    {
                        continue;
                        
                    }
                    counter++;
                }
                start_pointer_index++;
            }
            return counter > 1000000000  ? 1000000000 : counter;
            
        }

   
    }
}
