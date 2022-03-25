using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayCopyToAndClone
{
    class Program
    {
        static void Main(string[] args)
        {
            var array1 = new int[] {3,4,5,5,6,7};
            var array2 = new int[6];

            //Copy the element form an existing array to another existing array.
            array1.CopyTo(array2, 0);

            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write(array2[i] + " ");
            }

            Console.WriteLine();

            //create a new array object containing all elements of an existing array.
            //Unboxing.
            var arrayClone = (int[])array2.Clone();

            for (int i = 0; i < arrayClone.Length; i++)
            {
                Console.Write(arrayClone[i] + " ");
            }
        }
    }
}
