using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubstringLength
{
    public class Solution
    {
        public static int LengthOfLongestSubstring(string s)
        {
            //convert string to char array
            var s_ToCharArray = s.ToCharArray();
            //creating temp char char array.
            var tempCharList  = new List<char>();
            int longestSubStringCount = 0;

            //if temp does not contain in element of s_to_chararray add it to it. 
            foreach (var item in s_ToCharArray)
            {
                if (!tempCharList.Contains(item))
                {
                    tempCharList.Add(item);
                }
             //if tem contains element of s_to_chararray.
                else
                {
                    //get index of item in tempCharList.
                    int indexFoundChar = tempCharList.IndexOf(item);
                    //skip number of elements in temp array. number of elements to skips are indexFound + 1.
                    tempCharList = tempCharList.Skip(indexFoundChar + 1).ToList();
                    //add item to temp array.
                    tempCharList.Add(item);
                }

                if (longestSubStringCount < tempCharList.Count)
                {
                    longestSubStringCount = tempCharList.Count();
                }
               // longestSubStringValue = longestSubStringValue < tem.Count() ? tem.Count() : longestSubStringValue++;
            }          
            
            
            return longestSubStringCount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.LengthOfLongestSubstring("bbbbb"));
        }
    }
}
