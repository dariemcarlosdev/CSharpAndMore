using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareElementsArray
{
    /*
     Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.

Example 1:

Input: nums = [-4,-1,0,3,10]
Output: [0,1,9,16,100]
Explanation: After squaring, the array becomes [16,1,0,9,100].
After sorting, it becomes [0,1,9,16,100].
Example 2:

Input: nums = [-7,-3,2,3,11]
Output: [4,9,9,49,121]
     
     */
    public class Solution 
    {

        public static int[] SortedSquared(int[] nums)
        {

            var pointer_begin = 0;
            var pointer_end = nums.Length - 1;
            var temp_array = new int[nums.Length];

            for (int i = nums.Length -1 ; i >= 0; i--)
            {
                if (Math.Abs(nums[pointer_begin]) >= Math.Abs(nums[pointer_end]))
                {
                    temp_array[i] = nums[pointer_begin] * nums[pointer_begin];
                    pointer_begin += 1;
                }

                else
                {
                    temp_array[i] = nums[pointer_end] * nums[pointer_end];
                    pointer_end -= 1;
                }
            }

            return temp_array;

        } 
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            var array = Solution.SortedSquared(new int[] { -7, -3, 2, 3, 11 });
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ",array[i]);
            }

        }
    }
}
