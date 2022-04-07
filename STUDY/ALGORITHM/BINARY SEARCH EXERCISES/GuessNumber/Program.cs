using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GuessNumber(1792997410));
        }

        public static int GuessNumber(int n)
        {

            int start = 0;
            int end = n;

            if (guess(n) == 0)
            {
                return n;
            }
            end--;
            while (start <= end)
            {
                var mid = end + (start - end) / 2;
                int res = guess(mid);

                if (res < 0)
                {
                    end = mid - 1;
                }

                if (res >= 0)
                {
                    start = mid + 1;
                }

            }

            return end;
        }

        public static int guess(int num) 
        {
            int pick = 1240808008;
            int result=0;
            if (num > pick)
            {
                result = -1;
            }

            else if (num < pick)
            {
                result = 1;
            }

            return result;
        }
    }
}

