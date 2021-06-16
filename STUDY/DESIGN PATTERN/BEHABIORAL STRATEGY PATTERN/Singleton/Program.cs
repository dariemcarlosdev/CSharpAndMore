using Singleton.Singleton;
using System;

namespace Singleton
{
    class Program
    {

        static void Main(string[] args)
        {

            var fromTeacher = Singleton1.GetInstance;
            var fromStudent = Singleton1.GetInstance;

            fromTeacher.PrintMessage("From Teacher");
            fromStudent.PrintMessage("From Student");

            Console.ReadKey();
        }
    }
}
