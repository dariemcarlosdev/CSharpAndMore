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


            /*
             * Example 3 using multi-thread programming:
             * 
             * To invoke method to access the GetInstance property parallely, means at the same time multiple thread are accessing the GetInstance property.
            Multithread enviroment*/
            /*
             Parallel.Invoke(
                () => PrintTeacherDetails(),
                () => PrintStudentDetails()
                );

            Console.ReadKey();
        }


        private static void PrintTeacherDetails()
        {
            //Invoke get instance property on Singleton Class.
            var fromTeacher = Singleton3.GetInstance;
            fromTeacher.PrintMessage("From Teacher");
        }

        private static void PrintStudentDetails()
        { 
            //Invoke get instance property on Singleton Class.
            var fromStudent = Singleton3.GetInstance;
            fromStudent.PrintMessage("From Student");

        }
            */

            //Example 4 Eager Loading in Singleton Design Pattern:
            Console.WriteLine("Example 4 Eager Loading");
            Parallel.Invoke(
               () => PrintTeacherDetails(),
               () => PrintStudentDetails()
               );

            Console.ReadKey();


            /*

            Example 5 Lazy Loading in Singleton Design Pattern using Lazy keyword.

             */

            Console.WriteLine("Example 5 Lazy loading");
            Parallel.Invoke(
                () => DisplayTeacherDetails(),
                () => DisplayStudentDetails()
                );
        }

        private static void DisplayStudentDetails()
        {
            var fromStudents = Singleton5.GetInstance;
            fromStudents.PrintDetails("Students");
                
         }

        private static void  DisplayTeacherDetails()
        {
            var fromTeachers = Singleton5.GetInstance;
            fromTeachers.PrintDetails("Teachers");
        }

        private static void PrintTeacherDetails()
        {
            //Invoke get instance property on Singleton Class.
            var fromTeacher = Singleton4.GetInstance;
            fromTeacher.PrintDetails("From Teacher");
        }

        private static void PrintStudentDetails()
        {
            //Invoke get instance property on Singleton Class.
            var fromStudent = Singleton4.GetInstance;
            fromStudent.PrintDetails("From Student");


        }



    }
}
