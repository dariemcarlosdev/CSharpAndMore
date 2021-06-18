using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton.Singleton
{

    /*In Singleton Design Pattern a class has only one instance in the program, that provides a global point of access to it.
    Is a class that allow only a single instance of itself to be created and usually gives simple access to the instance.
    We need to use the Singleton design pattern in C# when we need to ensure that only one instance of a particular class is available at any given point of time for the entire application.

     There is different ways to implement Singleton pattern. The following are the common characteristics:

    -Private and Parameterless single constructor.
    -Sealed Class.
    -Static variable to hold a reference to the single created instance.
    -A public and static way of getting the reference to the created instance.

    Adavantages:

    - Can implement interface.
    - Can be lazy-loaded and has static initialization.
    - It helps to hide dependencies*.
    - It provides a single point of access to a particular instance, so it easy to maintain.

    Disadvantage:

    - Unity test is difficult as it introduces a global state into the application.
    - Reduce the potential for parallelism within a program by locking.

    The following compares Singleton class vs. Static methods:

    - A Static Class cannot be extended whereas a singleton class can be extended.
    - A Static Class cannot be initialized whereas a singleton class can be.
    - A Static class is loaded automatically by the CLR when the program containing the class is loaded.

    Some Real-time scenarios where you can use the Singleton Design Pattern:

    Service Proxies: As we know invoking a Service API is an extensive operation in an application. The process that taking most of the time is creating the Service client in order to invoke the service API. If you create the Service proxy as Singleton then it will improve the performance of your application.

    Facades: You can also create Database connections as Singleton which can improve the performance of the application.

    Logs: In an application, performing the I/O operation on a file is an expensive operation. If you create your Logger as Singleton then it will improve the performance of the I/O operation.

    Data sharing: If you have any constant values or configuration values then you can keep these values in Singleton So that these can be read by other components of the application.

    Caching: As we know fetching the data from a database is a time-consuming process. In your application, you can cache the master and configuration in memory which will avoid the DB calls. 
    In such situations, the Singleton class can be used to handle the caching with thread synchronization in an efficient manner which drastically improves the performance of the application. 
    
    -How to Implement Singleton Pattern in C# code?

    1. not Thread safety in a multithread environment:
    */
    public sealed class Singleton1
    {
        private static int counter = 0;
        /*
        private static variable that hold reference to the single created instance of the class if any.
        Initialized it to null to ensure that one instance of the class is created based on the null condition.
        */
        private static Singleton1 instance = null;
        /*
        public static property/Method which will return the single-created instance (only one instance) of the singleton class by checking the value of the private variable instance. 
        This method or property first check if an instance of the singleton class is available or not. If the singleton instance is available, then it returns that singleton instance otherwise it will create an instance and then return that instance.
        */
        public static Singleton1 GetInstance {

            get {

               return instance ?? new Singleton1();
               
            }

        }


        //Constructor private and parameterless.This is required because it is not allowed the class to be instantiated from outside the class. It only instantiates from within the class.
        private Singleton1(){
            counter++;
            Console.WriteLine("Object instance Counter value: {0}", counter.ToString());
        }
        
        public void PrintMessage(string message) {

            Console.WriteLine(message);
        
        }

    }
}
