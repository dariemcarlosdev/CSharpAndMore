using System;

/*
Write a C# program to check if a given positive number is a multiple of 3 or a multiple of 7.
Sample Output:
Input first integer:
15
True
*/

namespace ExercisesLearning
{
    public class VerifyMultiplicityBy
    {
        public static void IsMultipleOf(int number, int multipleof){

         if (number > 0)
         {
            Console.WriteLine("\nResult: {0} ",number % multipleof==0);
         }
      
    }
    }
}