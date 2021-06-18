using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton.Singleton
{
    /*
     Lazy loading:

    Is a approach or concept which is commonly used to delay the initialization of an object until it is needed. The objetive of Lazy loading is to load the object on-demand or when it is needed.
    You need to use Lazy loading when the cost of object creation is to high as well as the use of that object is very rare, and improve the app performance. We can use Lazy keyword to make the singleton instance as Lazy loading.

     */
    class Singleton5
    {

        private static int counter = 0;
        public Singleton5()
        {
            counter++;
            Console.WriteLine("{0} instance of the Singleton class have been created.", counter.ToString());
        }

        // IF you to make an object as Lazy initialized (on-demand initialization), need to pass the object type (Singleton) to the Lazy keyword.Lazy<T> objects are by default thread-safe
        //In a multi-threaded environment,when multiple threads are trying to access the same Get Instance property at the same time, the lazy object will take care of thread safety.

        private static readonly Lazy<Singleton5> instance =
            
            //passing a delegate to the constructor which call the singleton constructor.
            new Lazy<Singleton5>( () => new Singleton5());

        public static Singleton5 GetInstance
        {
            get
            {
                return instance.Value;
            }
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }

    }
}
