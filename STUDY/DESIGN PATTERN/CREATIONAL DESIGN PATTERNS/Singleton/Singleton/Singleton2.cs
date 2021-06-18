using System;
namespace Singleton.Singleton
{

    /*
     why do we need to use the sealed keyword in the singleton class as we already have a private constructor within the class which will restrict the class for further inheritance.
     Sealed prevent the class inheritance. This implementation is not thread-safe. The way we implement the Singleton class allows two different threads at the same time to be evaluated
     the test if (instance == null) and found it to be true and they both create the instances, which violates the singleton design pattern.

    By removing the sealed keyword we can inherit the singleton class, and also possible to create multiple objects of the singleton class. 
    This violates singleton design principles. This Singleton implementation is not thread-safe.

    No Thread safety in a multithread environment:
    */


    // The Singleton class defines the `GetInstance` method that serves as an
    // alternative to constructor and lets clients access the same instance of
    // this class over and over.
    public class Singleton2
    {
        private static int counter = 0;

        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static Singleton2 _instance  = null;




        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field
        public static Singleton2  GetInstance
        {
            get
            {
                
                 return   _instance ??= new Singleton2();
                
            }

        }
        //Private constructor prevent external instantiations of the class.
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private Singleton2()
        {
            counter++;
            Console.WriteLine("{0} object instance has been created", counter.ToString());
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

    //Nested Class: Whenever we defined a class within another class in C# then the inner class is called a nested class or child class.
     public class DerivedSingleton : Singleton2
    {

    }

    }

 

}