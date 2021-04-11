using System;

namespace ExercisesLearning
{
    public class Odds
    {


     public void CheckOdd(){

            for (int i = 0; i <= 99; i++)
     {
         if (i%2==0)
         {
             Console.WriteLine("Number {0} is even ",i);
         }
         else Console.WriteLine("Number {0} is odd",i);
     }
    }
}
}