using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    //Generics mean a general form, no specific. In c# generics means no specific data type,
    //generic allow us to write a class or method that can work with any data type.
    //c# allow us to define Generics class, methods, properties, Interfaces, Delegates, Events without the a specific datatype.
    //A generic type is declare by specifying type of parameter in <> after the type name. e.g TypeName<T> where T is type of parameter.

    //We use <> to specify the Parameter Type. T is called type parameter, which can be used as type of field, property,
    //method parameters, return type, and delegates in a Generic Class.

    /*
     Generic Class Characteristics
        A generic class increases the reusability. The more type parameters mean more reusable it becomes.
        However, too much generalization makes code difficult to understand and maintain.
        A generic class can be a base class to other generic or non-generic classes or abstract classes.
        A generic class can be derived from other generic or non-generic interfaces, classes, or abstract classes.
     */
    /*
     Advantage of Generics:

    1-Increase reusability of code. You do not have to write a new code to handle different data types.
    2-Generics are type-safety. You get compile-error if you try to use different data type than the one specified in definition.
    3- Improve performance cuz it removes posibilities of boxing and unboxing.
    4-It is preferred to use System.Collections.Generic namespace instead of classes such as ArrayList in the System.Collections namespace to create a generic collection.
     https://www.tutorialsteacher.com/csharp/csharp-collection
     */
    class MyGenericClass<T>
    {
        //Private member.
        public T prop { get; set; }
    }

    //you can also define multiple type parameters.

    class KeyValuePair<TKey, TValue> {

        public TKey Key { get; set; }
        public TValue Value { get; set; }

    }


    //Generic Class can include generic field, but they cannot be initialized.
    class DataSet<T> {

        public T[] _array; // generic array declare.

        public DataSet(int size) {

            this._array = new T[size];
        }

        //Bellow, the AddorUpdate() and the GetElements() methods are generic methods.
        //The actual data type of the item parameter will be specified at the time of instantiating
        //the DataStore<T> class.

        public void AddOrUpdate(int index, T item) {

            if (index >=0 && index < _array.Length)
            {
                _array[index] = item;
            }
        
        }

        public T GetElements(int index) {

            if (index >= 0 && index < _array.Length)
            {
                return _array[index];
            }

            else return default(T);
        
        }
    }

    //A non-generic class can include generic methods by specifying the parameter type <T> with the method name

    class NGC {
        public void PrintData<T>(T data) {
            Console.WriteLine(data);
        }
    }

    class CG<T>    {

        public List<T> MyProperty { get; set; }

    }
}
