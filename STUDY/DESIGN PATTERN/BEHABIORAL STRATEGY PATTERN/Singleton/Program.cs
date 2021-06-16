using Singleton.Singleton;
using System;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
            For example Singleton1 and Singleton2

            var fromTeacher = Singleton2.GetInstance;
            var fromStudent = Singleton2.GetInstance;

            fromTeacher.PrintMessage("From Teacher");
            fromStudent.PrintMessage("From Student");

            
            //Instantiating Singleton class from derived class.
            //This violates singleton pattern principle.
            

            Singleton2.DerivedSingleton derivedObject = new Singleton2.DerivedSingleton();
            derivedObject.PrintMessage("From derived");
            */

            Parallel.EventHandler temp = MyEvent;
            if (temp != null)
            {
                temp();
            }

            Console.ReadKey();
        }
    }
}
