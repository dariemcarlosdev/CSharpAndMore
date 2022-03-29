using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Calculate
    {

        int? number = null;
        public Calculate(int? value)
        {
            this.number = value;
        }

        public void DoCalculation()
        {
            if (!number.HasValue)
            {
                
                Console.WriteLine("Value no assigned");
                
            }
            else
            Console.WriteLine("Value assigned");
            

        }
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculate(5);
            calc.DoCalculation();
        }
    }
}
