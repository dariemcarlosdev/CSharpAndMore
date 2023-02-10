using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    // Struct and Class both are user defined,
    // by Struct inherit from System.Value, hence it's a value type.
    // - Struct cannot be Abstract.
    // - there's no need to create an object with the new keyword.
    // - no have permission to create default constructor.
    // - it's used when there's small amount of data.

    // Class inherit from System.object hence it's a reference type.
    // there's used when there's a large amount of data.
    // when you need to use inheritance. 
    // Class can be Abstract.

    struct MyStruct
    {
        public int MyProperty { get; set; }
        public int MyProperty1{get; set;}

    }


    class MyClass
    {
        public readonly int MyProperty;

        public MyClass(int myProperty)
        {
            this.MyProperty = myProperty;
        }
    }

}
