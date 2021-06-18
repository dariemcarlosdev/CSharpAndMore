using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton.Singleton
{

    /*
     Lazy Loading and Eager Loading in Singleton Design Pattern.

    Non-Lazy or Eager Loading:

    A process in which wee need to initialize the singleton object at the time of application startup rather than on-demand (invoke property that has reference to the Constructor)
    and keep it ready in memory to be used in the future. Advantage of using Eager loading is the CLR will take case of the object initialization and thread-safety, We don´t need to write
    any code explicitly to handling the thread-safety in a multithreaded-enviroment.
     */


    //This class is thread-safety without using Lock variable, because the CLR take care of the variable initialization as well as thread safety in eager loading.
    class Singleton4
    {

        private static int counter = 0;
        public Singleton4()
        {
            counter++;
            Console.WriteLine("{0} instance of the Singleton class have been created.", counter.ToString());
        }

        // to creates the Singleton instance at the time of application startup
        private static readonly Singleton4 singleInstance = new Singleton4();

        public static Singleton4 GetInstance
        {
            get
            {

                return singleInstance;
            }
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }

    }
}
