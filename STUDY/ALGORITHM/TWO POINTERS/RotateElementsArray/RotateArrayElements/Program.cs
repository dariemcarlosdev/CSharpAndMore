using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateArrayElements
{
    public interface IRotate 
    
    {
        void Rotate(int[] numbs, int K);
    
    }
    public class SolutionRotateRight : IRotate
    {

        /*
         Given an array, rotate the array to the right by k steps, where k is non-negative.
 
Example 1:

Input: nums = [1,2,3,4,5,6,7], k = 3
Output: [5,6,7,1,2,3,4]
Explanation:
rotate 1 steps to the right: [7,1,2,3,4,5,6]
rotate 2 steps to the right: [6,7,1,2,3,4,5]
rotate 3 steps to the right: [5,6,7,1,2,3,4]
         */

        public void Rotate(int[] nums, int k)
        {

            // calculate reminder (%) between (k, nums.length)
            k %= nums.Length;
            //create temp array
            var res = nums.ToArray();
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = res[ i- k < 0 ? res.Length - k + i : i - k ];
                Console.Write("{0} ", nums[i]);
            }

          
            Console.WriteLine();
        }
    
    }

    //Rotate array left Solution using two pointers.
    public class SolutionRotateRotateLeft : IRotate
    {
        public void Rotate(int[] numbs, int k)
        {
            k %= numbs.Length;
            var array_output = numbs.ToArray();
            
            for (int i = numbs.Length - 1 ; i >= 0; i-- )
            {
                numbs[i] = array_output[i - k > 0 ? i + k - numbs.Length : i + k ];
            }

            for (int i = 0; i < numbs.Length; i++)
            {
                Console.Write("{0} ", numbs[i]);
            }

            Console.WriteLine();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var solution1 = new SolutionRotateRight();
            var solution2 = new SolutionRotateRotateLeft();

            Console.WriteLine("Array [-1, -100, 3, 99] rotated to right:");
            solution1.Rotate(new int[] { -1, -100, 3, 99 }, 2);
            Console.WriteLine("Array [1,2,3,4,5,6,7] rotate to left:");
            solution2.Rotate(new int[] {1,2,3,4,5,6,7},3);
            
        }
    }
}
