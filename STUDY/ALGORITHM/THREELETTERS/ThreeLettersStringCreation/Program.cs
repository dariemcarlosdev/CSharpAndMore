using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeLettersStringCreation
{
    /*
     Generate a string consisting of characters ‘a’ and ‘b’ that satisfy the conditions as follow:

       1-str must only contain the characters ‘a’ and ‘b’.
       2-str has length A + B and the occurrence of character ‘a’ is equal to A and the occurrence of character ‘b’ is equal to B
       3-The sub-strings “aaa” or “bbb” must not occur in str.
       
    Note that for the given values of A and B, a valid string can always be generated.
    Examples: 
    Input: A = 1, B = 2 
    Output: abb 
    “abb”, “bab” and “bba” are all valid strings.
    Input: A = 4, B = 1 
    Output: aabaa 
     
     */
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Solution(10, 5));
        }
        static string Solution(int A, int B)
        {


            string result = "";

            while (A > 0 || B > 0) 
            {
                //Three escenarios are pesents. b > a, a > b, a = b

                if (B > A)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (B > 0)
                        {
                            result += 'b';
                            B--;
                        }
                    }

                    if (A > 0)
                    {
                        result += 'a';
                        A--;
                    }
               
                }

                if (A > B)
                {

                    for (int i = 0; i < 2; i++)
                    {
                        if (A > 0)
                        {
                            result += 'a';
                            A--;
                        }
                    }
                    if (B > 0)
                    {
                        result += 'b';
                        B--;
                    }
                
                }


                if (A == B)
                {
                    if (B > 0)
                    {
                        result += 'b';
                    }
                    if (A > 0)
                    {
                        result += 'a';
                    }
                }
            }

            return result;
        }
    }

}
