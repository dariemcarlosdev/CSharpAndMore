using System;
using System.Collections.Generic;
using System.Linq;
namespace ExercisesLearning
{

  /*
  Write a C# program to check if a number appears as either the first or last element of an array of integers 
  and the length is 1 or more.
Input an integer: 25
Sample Output
False
*/
  public class CheckAppearsFL
  {
    public static List<int> list = new List<int>();

    public static void CheckValuePositionArray()
    {
      Console.Write("\n How many alements will the have have?: ");
      int length = int.Parse(Console.ReadLine());
      if (length > 1)
      {
        for (int i = 1; i <= length; i++)
        {
          Console.Write("Enter element in position {0}: ", i);
          int value = int.Parse(Console.ReadLine());
          list.Add(value);
        }

        Console.Write("New List is:");
        list.ForEach(delegate (int value)
        {
          Console.Write(" {0}", value);
        });
        Console.Write("\nEnter value to check: ");
        int valueToCheck = int.Parse(Console.ReadLine());
        Console.WriteLine("Result: {0}",list[0] == valueToCheck && list[length - 1] == valueToCheck);
        Console.Read();
      }
      else
      {
        Console.Write("!Ups Sorry!, the list lenght must be greather than 1.");
      }
    }
  }
}