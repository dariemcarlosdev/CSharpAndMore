using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousType
{
    public static class Anonymous
    {
        //Anonymoust allow us to create new types without having to define them.
        public static void Print() {
           //Here we define read-only properties in this single object without especifying the data type, so we use Anonymous type.
           //the compiler (CRL) has the responsability to generate the data type.
            var anonymousData = new
            {
                //here we got 2 read-only properties without specifiying theirs value types.
                Name = "Dariem",
                LastName = "Macias"
            };

            Console.WriteLine(anonymousData.Name + anonymousData.LastName);
        
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Anonymous.Print();
        }
    }
}
