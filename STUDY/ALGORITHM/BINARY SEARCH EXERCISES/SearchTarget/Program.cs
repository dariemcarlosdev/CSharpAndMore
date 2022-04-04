using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            var index = new int[] { -1, 0, 3, 5, 9, 12 };

            Console.WriteLine(Search(index, 2));
            var s = "Let's take Dariem";
            var str = new string[] { "sas"};
            var zzz = new string[6];
            var sfdsf = (string[])str.Clone();
            str.CopyTo(zzz,4);

            Console.WriteLine(sfdsf[0]);
            Console.WriteLine(zzz[4]);
            ReverseString(s);
            
        }

        public static int Search(int[] n, int target) {

            int index;

            if (n.Contains(target))
            {
               return index = Array.IndexOf(n, target);
            }

            else return -1;

        }

        public static void ReverseString(string str)
        {
            var Stack = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {

                    Stack.Push(str[i]);
                }

                else
                {
                    while (Stack.Count > 0)
                        Console.Write(Stack.Pop());
                        Console.Write(" ");
                }

            }

            while (Stack.Count > 0) 
            {
                Console.Write(Stack.Pop());
            }
            
        }
    }
}
