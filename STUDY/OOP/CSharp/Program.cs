using System;
using System.Collections;
using static CSharp.Delegate;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // delegate reference type: here Print point to PrintNumber, Print Delegate hold a reference to the method Print Number.
            // We use Delegate to write genetic type save functions.
           
            
            //Single Delegate
            Print<int> printdel = PrintNumber;
            printdel(10);
            printdel(2000);
            /*
             Output: 
                Number 10
                Number 2,000
             */

            // Print delegate point to PrintMoney.
            printdel = PrintMoney;
            printdel(100);
            printdel(20);
            /*
             Output: 
                Monkey $100.00
                 Monkey $20.00
             */

            //Print delegate pint to PrintProduct.

            Print<string> printProd = PrintProduct;
            printProd("prduct name");

            //Multicast Delegates. It can call multiple methods at the same time. + to add methods, and - to remove methods.
            Print<int> printNumDel = PrintNumber;
            Print<int> printMonDel = PrintMoney;

            Print<int> multipleDel = printMonDel + printNumDel;
            Console.ReadLine();
            Console.WriteLine("Multicast delegate");
            multipleDel(200);

            //------------------------------------------------------------

            //arrays

            //copy arrays
            int[] sourcearray = new int[] { 2,3,4,5};
            int[] targetarray = new int[5];
            // from targetarray index 1, I will copy source array.
            //The first being the array you want to copy to,
            //and the second parameter tells it what index of the destination array it should start copying into
            sourcearray.CopyTo(targetarray, 1);
            foreach (var item in targetarray)
            {
                if (item == 0)
                {
                    continue;
                }

                Console.Write(item);
            }
            Console.Write("\n");
           
            
            //Clone arrays.
            //Clone the complete array.
            int[] clonearray = (int[])sourcearray.Clone();
            foreach (var item in clonearray)
            {
                if (item == 0)
                {
                    continue;
                }

                Console.Write(item);
            }

            // arrays store values of the same data type.

            string[] array = new string[3];
            array[0] = "dariem";
            array[1] = "macias";
            array[2] = "mora";

            // arraylist store values of different data types.

            ArrayList arrayList = new ArrayList();
            arrayList.Add("Dariem");
            arrayList.Add(23);
            arrayList.Add(false);

            //jagged array
            // each element of a jagged arrays is an array itself,
            //and each item can be of different dimensions and sizes.

            int[][] jaggedarray = new int[2][];
            jaggedarray[0] = new int[2] { 1,5};
            jaggedarray[1] = new int[3] {  1, 6, 4 };


            //----------------------Genetics------------------------------------------------sss

            //Generic Class Instance
            MyGenericClass<int> total = new MyGenericClass<int>(); //instantiating Generic Class
            total.prop = 10;
            //You can specify diferent data types for different objects.
            MyGenericClass<String> prductName = new MyGenericClass<string>();
            prductName.prop = "Test";
            Console.ReadLine();
            Console.WriteLine("total: {0}-----> Name: {1}",total.prop, prductName.prop);


            DataSet<string> dataSet = new DataSet<string>(3);
            dataSet.AddOrUpdate(0, "dariem");
            dataSet.AddOrUpdate(1, "macias");
            dataSet.AddOrUpdate(2, "carlos");

            for (int i = 0; i < dataSet._array.Length; i++)
            {
                Console.Write("{0} ",dataSet.GetElements(i));
            }

            //Non-Generic class instance

            NGC noGenericClass = new NGC();
            noGenericClass.PrintData<string>("dariem");
            noGenericClass.PrintData<int>(3);


            //Using system collection Generics instead system collection. This has better performance.
            CG<string> collection = new CG<string>();
            collection.MyProperty = new System.Collections.Generic.List<string>();
            collection.MyProperty.Add("arer");
            foreach (var item in collection.MyProperty)
            {
                Console.Write(item);
            }

            //--------------------------------------Reflection----------------------------------------

            var reflection = new Reflection();
            Console.Write(reflection.type);
        }
    }
}
