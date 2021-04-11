using System;

/*Write a C# program to check if a given string starts with "w" and immediately followed by two "ww".*/

namespace StartWithWFallowWW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input String :");
            string str = Console.ReadLine();
            Console.WriteLine(TestStr(str));
        }

        private static bool TestStr(string str)
        {
            int ctr = 0;
            for (int i = 0; i< str.Length - 1; i++)
            {
                if (str[i].Equals('w'))
                    ctr++;
                if (str.Substring(i, 2).Equals("ww") && ctr > 2)
                return true;
                break;
            }
            
            return false;
        }
    }
}
