using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton.Singleton
{

    /*In sigleton Design Pattern a class has only one instance in the program, that provides a global point of access to it.
    Is a class that allow only a single instance of itself to be created and ussually gives simple access to the instance.

     There is different ways to implement Singleton pattern. The following are the common characteristics:

    -Private and Parameterless single construcctor.
    -Sealed Class.
    -Static variable to hold a reference to the single created instance.
    -A public and static way of getting the reference to the created instance.

    Adavantages:

    - Can implement interface.
    - Can be lazy-loaded and has static initialization.
    - It helps to hide dependencies*.
    - It provides a single point of access to a particular instance, so it easy to maintain.

    Disavantege:

    - Unity test is dificult as it intruduces a global state into the application.
    - Reduce the potencial for parallelism within a program by locking.

    The following compares Singleton class vs. Static methods:

    - A Static Class cannot be extended whereas a singleton class can be extended.
    - A Static Class cannot be initialized whereas a singleton class can be.
    - A Static class is loaded automatically by the CLR when the program containing the class is loaded.
    
    -How to Implement Singleton Pattern in C# code?

    1. No Thread Safe Singleton implementation.
    */
    public sealed class Singleton1
    {
        private static int counter = 0;

        //Constructor private and parameterless.This is required because it is not allowed the class to be instantiated from outside the class. It only instantiates from within the class.
        private Singleton1(){
            counter++;
            Console.WriteLine("Object instance Counter value: {0}", counter.ToString());
        }
        
        //private static variable that hold reference to the single created instance of the class if any.
        //Initialized it to null to ensure that one instance of the class is created based on the null condition.
        private static Singleton1 instance = null;

        //public static property/Method which will return the single-created instance (only one instance) of the singleton class by checking the value of the private variable instance. 
        //This method or property first check if an instance of the singleton class is available or not. If the singleton instance is available, then it returns that singleton instance otherwise it will create an instance and then return that instance.
        public static Singleton1 GetInstance {

            get {

                if (instance == null) {
                    instance = new Singleton1();
                }
                return instance;
            }

        }

        public void PrintMessage(string message) {

            Console.WriteLine(message);
        
        }

    }
}
