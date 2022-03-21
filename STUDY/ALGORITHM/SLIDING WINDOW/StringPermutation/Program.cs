using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPermutation
{
    /*
     Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.

In other words, return true if one of s1's permutations is the substring of s2. 

Example 1:

Input: s1 = "ab", s2 = "eidbaooo"
Output: true
Explanation: s2 contains one permutation of s1 ("ba").

Example 2:

Input: s1 = "ab", s2 = "eidboaoo"
Output: false
     */
    // [Time Limit Exceeded]
    public class Solution
    {
        public static void PrintElementsWithRecursion(string s1, string s2, int start = 0)
        {
            var s1_to_CharArray = s1.ToCharArray();
            var end = s1_to_CharArray.Length;
            if (start == end)
            {
                return;
            }
            //recusivity
            Console.Write("{0} ", s1_to_CharArray[start]);
            PrintElementsWithRecursion(s1, s2, start + 1);


        }

        public static int Sum(int[] array, int start = 0)
        {
            if (start == array.Length)
            {
                return 0;
            }

            return array[start] + Sum(array, start + 1);

        }
        class Program
        {
            static void Main(string[] args)
            {

                string s = "dc";
                string s1 = "eadc";
                //var bt = new Backtracking_Recursive();
                //var bt2 = new Backtracking_Recursive_Method2();
                var bt3 = new SlideWindow_Method3();
                // var list = a.Permutation(s);
                //Console.Write("Permutation of {0}: ",s);
                //foreach (var item in list)
                //{
                //    Console.Write("{0} ",item);
                //}

                //Console.WriteLine("\n{0} is contained in {1}? : {2}", s, s1, bt2.CheckInclusion(s, s1));
               Console.WriteLine("Result: {0} ",bt3.CheckInclusion(s, s1));


            }
        }

    }

    //This solution works but have slow performance for large strings since the  time Complexity is defined as a function O(n!) for permutations.[Time Limit Exceeded]
    public class Backtracking_Recursive
    {
        public List<string> list { get; set; } = new List<string>();

        public static string SwapElements(string s, int i, int j)
        {
            var charArray = s.ToCharArray();

            var temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;

            return new string(charArray);
        }

        public List<string> Permutation(string s, int ix = 0)
        {
            if (ix == s.Length - 1)
            {
                //Console.WriteLine(s);
                list.Add(s);
                //return list;

            }

            else
            {
                for (int i = ix; i <= s.Length - 1; i++)
                {
                    s = SwapElements(s, i, ix);
                    Permutation(s, ix + 1);
                }
            }

            return list;

        }

        public bool IsContained(string s1, string s2)
        {
            var list = Permutation(s1);
            bool result = false;

            for (int i = 0; i < list.Count(); i++)
            {
                if (s2.Contains(list[i]))
                {

                    return true;

                }

            }

            return result;
        }
    }

    //This solution works but have slow performance for large strings since the  time Complexity is defined as a function O(n!) for permutations.[Time Limit Exceeded]
    public class Backtracking_Recursive_Method2
    {


        bool flag = false;
        // public List<string> list { get; set; } = new List<string>();

        public bool CheckInclusion(string s1, string s2)
        {

            PermutationByFlag(s1, s2);
            return flag;
        }

        public static string SwapElements(string s, int i, int j)
        {
            var charArray = s.ToCharArray();

            var temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;

            return new string(charArray);
        }




        public void PermutationByFlag(string s1, string s2, int ix = 0)
        {
            if (ix == s1.Length - 1)
            {

                if (s2.IndexOf(s1) >= 0)
                {
                    flag = true;
                }

            }

            else

            {
                for (int i = ix; i <= s1.Length - 1; i++)
                {
                    s1 = SwapElements(s1, i, ix);
                    PermutationByFlag(s1, s2, ix + 1);
                }
            }
        }
    }

    public class SlideWindow_Method3
    {

        public bool CheckInclusion(string _s1, string _s2)
        {
            
            if (_s1.Length > _s2.Length)
            {
                return false;
            }

            var s1_MapToInt = new int[26];
            var s2_MapToInt = new int[26];

            var timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < _s1.Length; i++)
            {   //a[i]++ increments the element at index i, it doesn't increment i. And a[i++] increments i, not the element at index i.
                var range = _s1[i] - 'a';
                var range2 = _s2[i] - 'a';
                s1_MapToInt[range]++;
                s2_MapToInt[range2]++;                
            }
            
            timer.Stop();            
            TimeSpan timeTaken = timer.Elapsed;
            timer.Restart();
            
            Console.WriteLine("TTime taken first for Loop for hashMapping: {0} ms", timeTaken.TotalMilliseconds.ToString());


          
            for (int i = 0; i < _s2.Length -_s1.Length; i++)
            {
                if (Match(s1_MapToInt,s2_MapToInt))
                {
                    return true;
                }
                
                var range3 = _s2[i + _s1.Length] - 'a';
                s2_MapToInt[range3]++;
                var range4 = _s2[i] - 'a';
                s2_MapToInt[range4]--;
            }
            
            timer.Stop();
            TimeSpan timeTaken2 = timer.Elapsed;
            Console.WriteLine("Time taken second for Loop: {0} ", timeTaken2.TotalMilliseconds.ToString());
            
            return Match(s1_MapToInt, s2_MapToInt);
        }
        bool Match(int[] s1_MapToInt, int[] s2_MapToInt)
            {

                for (int i = 0; i < 26; i++)
                {
                    if (s1_MapToInt[i] != s2_MapToInt[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        

    }

}
