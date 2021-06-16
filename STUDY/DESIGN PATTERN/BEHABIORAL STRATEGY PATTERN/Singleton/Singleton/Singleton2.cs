using System;
namespace Singleton.Singleton
{
    
    /*why do we need to use the sealed keyword in the singleton class as we already have a private constructor within the class which will restrict the class for further inheritance.
    Sealed prevent the class inheritance. This implementation is not thread-safe. The way we implement the Singleton class allows two different threads at the same time to be evaluated
     the test if (instance == null) and found it to be true and they both create the instances, which violates the singleton design pattern.
    */
    public class Singleton2
    {
        private static int counter = 0;
        private static Singleton2 instance  = null;
        public static Singleton2  GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton2();
                }
                return instance;
            }

        }
        //Private constructor prevent external instantiations of the class.
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