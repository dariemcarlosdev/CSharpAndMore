using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Difference between array and arrayList

            //When we want to store item of the same type we use array.

            string[] strArray = new string[] {"a", "b", "c" };

            //When we need to store item with diferent datatypes, we use ArrayList.
            ArrayList arrayList = new ArrayList();
            arrayList.Add(3);
            arrayList.Add("Dariem");
            arrayList.Add(false);
        }
    }
}
