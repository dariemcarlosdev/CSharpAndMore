using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzyncPrograming
{
    class Program
    {
        /*Task is a class that allow us to work with azynchronic tasks that gonna run at the same time. Give a flexible use talking about the status of the task.*/
        
        //let say we have this task main. Main is the principal thread, and Task would be another dimension, another line of time separated of Main.
        static async Task Main(string[] args)
        {
            //let's create an Azync task and pass to it a lambda function
            var task = new Task(()=> {

                Thread.Sleep(3000); //this thread delay the process 1 second and then print the internal message.
                Console.WriteLine("Internal Task1 Completed");
                
            });
            //Initializing Task to be executed under the hood.
            task.Start();

            var task2 = new Task(()=> {
                Thread.Sleep(3000);
                Console.WriteLine("Internal Task2 Completed");
            
            });
            task2.Start();

            Console.WriteLine("doing something else.");//some code here that belong to the Main thread is gonna be running.
            
            await task; //verified if task is done, is it's done, pass to next point, if not, it stay there completing the process, but the azync Task2 is already working Azynchronous. 
            await task2;

            var resultRamdom = await  MultAsync(5,4); //to call async method we hace use await keyword in front method.
            Console.WriteLine(resultRamdom);

            Console.WriteLine("I am done with the Main task");

            //we add a Readline() here to stop the main process, allowing that the message of the Task can be printed out. if we dont add this stop here,
            //the Task message does not gonna be consoled out, due the Task is delayed quite much time, and the process continue runing on the Main Task,
            //get the WriteLine() method and end.
            Console.ReadLine();
        }

        public static async Task<int> MultAsync(int num1, int num2) {

            var task = new Task<int>(()=> num1 * num2);
            task.Start();

            int result = await task;
            return result;
            
        }
    }
}
