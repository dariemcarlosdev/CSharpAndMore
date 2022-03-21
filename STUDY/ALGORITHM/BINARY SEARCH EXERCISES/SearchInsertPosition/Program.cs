using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInsertPosition
{
    /*
     Given a sorted array of distinct integers and a target value, return the index if the target is found. 
     If not, return the index where it would be if it were inserted in order.
     You must write an algorithm with O(log n) runtime complexity.

Example 1:

Input: nums = [1,3,5,6], target = 5
Output: 2
Example 2:

Input: nums = [1,3,5,6], target = 2
Output: 1
Example 3:

Input: nums = [1,3,5,6], target = 7
Output: 4
     */

    public class Solution 
    {
        public static int SearchInsert(int[] nums, int target)
        {

            var left = 0;
            var right = nums.Count() - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                else if (target > nums[mid])
                {
                    left = mid + 1;
                }

                else
                {
                    right = mid - 1;
                }
            }

            return right + 1;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(Solution.SearchInsert(new int[] { 1, 3, 5, 6},2));
        }
    }
}
