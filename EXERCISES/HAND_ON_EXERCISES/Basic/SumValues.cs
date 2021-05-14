using System;

namespace ExercisesLearning
{
    public class SumValues
    {

 public void InputData(){
       /*Write a C# program to check the sum of the two given integers and return true if one of the integer is 20 or if their sum is 20.*/
        Console.WriteLine("Enter number 1: ");
        int number1 = int.Parse(Console.ReadLine()) ;
        Console.WriteLine("Enter number 2: ");
        int number2 = int.Parse(Console.ReadLine());        
        var result = CheckSum(number1, number2);
        Console.WriteLine(result);
 }

     public bool CheckSum(int v1, int v2)
    {
 

        var sum = v1 + v2;
      if ((v1==20 || v2==20) || sum == 20)
      {
          return true;
      }
      return false;
    }
    }
}