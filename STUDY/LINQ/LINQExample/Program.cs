using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var mobile = new List<Mobile>();
            mobile.Add(new Mobile { Brand = "Iphone", Model = "S8", Year = 2018 });
            mobile.Add(new Mobile { Brand = "Samsung", Model ="Z12", Year = 2017} );

            var result = from item in mobile where item.Brand.Contains("Iphone") select item;
            foreach (var item in result)
            {
                Console.WriteLine("{0} {1} {2}",item.Brand ,item.Model ,item.Year);
            }
        }
    }

    public class Mobile
    {
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Model{ get; set; }
    }
}
