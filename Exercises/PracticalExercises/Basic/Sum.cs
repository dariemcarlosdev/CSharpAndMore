using System;
namespace ExercisesLearning
{
    public class Sum
    {
        public void SumValues(){
   
      Console.WriteLine("Enter digit: ");
      var digit = int.Parse(Console.ReadLine());
      int sum = 0;

      while (digit != 0)
      {
        sum += digit % 10;
        digit /= 10;
      }

      Console.WriteLine(sum);

        }
        
    }
}