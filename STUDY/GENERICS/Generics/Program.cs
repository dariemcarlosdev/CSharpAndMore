using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    //Creating a Generic Data Type.
    public class GFT<T>
    {
        public T value { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Create an instance of string type.
            GFT<string> Company = new GFT<string>();
            Company.value = "Company C.0";

            //Creating an instance of float type. Here we use var.
            var version = new GFT<float>();
            version.value = 6.0f;



            Console.WriteLine(Company.value + version.value);
        }

        
    }
}
