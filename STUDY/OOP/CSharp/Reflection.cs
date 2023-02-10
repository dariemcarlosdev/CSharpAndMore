using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Reflection
    {
        //Provide objects of type Type that describe assamblies, modules, and types. It's when managed code can read it own metadata.
        /*
         Reflection is useful in the following situations:
           - When you have to access attributes in your program's metadata.
           - For examining and instantiating types in an assembly.
           - For building new types at run time. Use classes in System.Reflection.Emit.
           - For performing late binding, accessing methods on types created at run time. See the topic Dynamically Loading and Using Types.
         */
        static int i = 42;
       public Type type = i.GetType();
        
    }
}
