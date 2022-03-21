using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSumArrayIsSorted
{
    class Program
    {
        public class Solution
        {
            public static int[] TwoSum(int[] numbers, int target)
            {
                var temp = new int[2];



                for (int i = 0; i < numbers.Count(); i++)
                {
                    //return indice of position target value
                    var index = Array.BinarySearch(numbers, target - numbers[i]);

                    //if (pos !=0 & pos >= 0)
                    //{
                    //temp[0] = i > pos ? pos + 1 : i + 1;
                    //temp[1] = i > pos ? i+1 : pos + 1;

                    Console.WriteLine("i:{1} index of {2}: {0}", index, i, target - numbers[i]);
                    if (index >= 0 & i != index)
                    {
                        temp[0] = index > i ? i + 1 : index + 1;
                        temp[1] = index > i ? index + 1 : i + 1;
                    }

                    //Console.WriteLine(pos);
                }
                return temp;
            }
        }

        static void Main(string[] args)
        {
            var array = Solution.TwoSum(new int[] { 2, 3, 4 }, 6);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
    }
}
