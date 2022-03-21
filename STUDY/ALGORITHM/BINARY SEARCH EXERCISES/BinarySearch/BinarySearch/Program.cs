using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    /*
     Example 1:

Input: nums = [-1,0,3,5,9,12], target = 9
Output: 4
Explanation: 9 exists in nums and its index is 4
Example 2:

Input: nums = [-1,0,3,5,9,12], target = 2
Output: -1
Explanation: 2 does not exist in nums so return -1
     
     */
    public class Solution
    {

        //Binary Search Method .

        public static int BinarySearch(int[] nums, int target)
        {

            //represent index of first and last element in search space.
            int left = 0;
            int right = nums.Count() - 1;

            while (left <= right)
            {
                var middle = (right + left) / 2;

                if (target == nums[middle])
                {
                    return middle;
                }

                else if (target < nums[middle])
                {
                    right = middle - 1;
                }

                else
                {
                    left = middle + 1;
                }
            }

            return -1;

        }


        /*Exercise 2:*/
          
         
        //Binary Search Method Recursive.

        public static int BinarySearchRecursive(int[] nums, int target, int left, int right)
        {

            while (left <= right)
            {
                var middle = (right + left) / 2;

                if (target == nums[middle])
                {
                    return middle;
                }

                else if (target > nums[middle])
                {
                    return BinarySearchRecursive(nums, target, middle + 1, right);
                }

                else
                {
                    return BinarySearchRecursive(nums, target, left, right - 1);
                }

            }

            return -1;

        }


    }


    class Program
        {
            static void Main(string[] args)
            {
            Console.WriteLine(Solution.BinarySearch(new int[] { -1, 0, 3, 5, 9, 12 }, 9));
            Console.WriteLine(Solution.BinarySearchRecursive(new int[] { -1, 0, 3, 5, 9, 12 }, 2, 0, 8));
            }
        }
    }

