using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Anonymous
    {
        //Anonymous types allow us to create new types without defining them.
        //When there is a need to define read-only properties in a single object without defining each type.
        //In that case, we use anonymous types.
        public void print()
            {
                var anonymousData = new
                {
                    FirstName = "John",
                    SurName = "lastname"
                };
                Console.WriteLine("First Name : " + anonymousData.FirstName);
            }
       
    }
}
