using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct
{
    class Program
    {
        static void Main(string[] args)
        {
            var myStruct = new MyStruct(2,3);
            Console.WriteLine("Struct prop1={0}, and prop2={1}", myStruct.MyProperty1,myStruct.MyProperty2);
        }
    }

    //Difference beetween Struct and Class. They both are user-define but have significant differences each other.

    /*
     Struct inherit from System.ValueType class hence it's a value Type. It's not a reference Type such as a Class whose inherit from System.Object
     It's prefered to use Struct where there are small amount of data.
     Struct not support Inheritance, it's implicitly Sealed no Abstract, so that function members in Struct cannot be Abstract or Virtual, And override is allowed only for methods inherited from System.ValueType.
     Struct not support Create default constructor.(parameterless constructor)

    when is recommender use Classes:

    When we have a huge amount of data. 
    When we want to use Inheritance.
    When we want to define a Class as Abstract.
     */

    struct MyStruct
    {
        //public MyStruct() //error
        //{

        //}

        //ok

        public MyStruct(int prop1, int prop2)
        {
            this.MyProperty1 = prop1;
            this.MyProperty2 = prop2;
        }
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
    }
}
