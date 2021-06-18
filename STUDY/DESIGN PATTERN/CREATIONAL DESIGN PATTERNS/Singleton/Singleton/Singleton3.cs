    using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton.Singleton
{
    public sealed class Singleton3
    {
        /*
        Implementing Thread safety in a multithread environment:

        Handler Thread-safe Singleton Design Pattern implementations use Locks to control the thread race condition in a multithread enviroment.
        
        To remember: Locks are the best option to handle the singleton instance.        

        Lazy Initialization in the Singleton Design Pattern:

        Until and unless we invoke the GetInstance Property of the Singleton class, the Singleton instance is not created. That means when we invoke the GetInstance Property of the Singleton class then only the Singleton object is created. 
        This Delay of Singleton Instance creation is called Lazy Initialization.
        The lazy initialization i.e. the on-demand object creation of the singleton class works fine when we invoke the GetInstance property in a Single-threaded environment.
        But in a multi-threaded environment, it will not work as expected. In a multi-thread environment, the lazy initialization may end up creating multiple instances of the singleton class when multiple threads invoke the GetInstance property parallelly

*/
        private static int counter = 0;
        private static Singleton3 instance = null;
        private static readonly object InstanceLock = new object();
        private Singleton3()
        {
            counter++;
            Console.WriteLine("{0} objects instance have been created", counter.ToString());
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
        public static Singleton3 GetInstance
        {
            get
            {
                /*
                // This code is not Thread-safe because two different threads can evaluate the condition if (instance == null) at the same time
                // and both the threads found it to be true and they both will create the instances, which violates the singleton design pattern. 
                
                if (instance == null)
                {
                    instance = new Singleton3();
                }
                return instance;
                 
                //Using locks we can synchronize the method. So that only one thread can access it at any given point of time.
                // This code Lock the shared resource and checks if the instance whether the instance is created or not. 
               // If the instance is already created then we simply return that instance else we will create the instance and then return that instance.
                
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton3();
                    }
                    return instance;

                }
                */

                //The above code using Lock solve the multithreading issue, but the problem is that only one thread can access the GetInstance property at any given point of time.
                //Using double checked locking approach to overcome the above problem.
                //In the Double-checked locking mechanism, first, we will check whether the instance is created or not. If not then only we will synchronize the method as shown below.

                if (instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (instance==null)
                        {
                            instance = new Singleton3();
                        }
                    }

                }
                return instance;
            }
        }


        }
    }

