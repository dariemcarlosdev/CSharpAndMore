using System;

namespace ExercisesLearning
{
  public class StringOdd
  {
    public static string str;
    /*
  Write a C# program to create a new string of every other character (odd position) 
  from the first position of a given string.
  Test Data:
  Input a string : w3resource
  Sample Output
  wrsuc
    */
    public static void NewStringOdd()
    {
      Console.Write("\nEnter string from which create a new odd string: ");
      str = Console.ReadLine();
      Console.WriteLine(str);
      for (int i = 0; i < str.Length; i++)
      {
        if (!IsOdd(i))
        {
          Console.Write(str[i]);
        }
      }
    }

    public static bool IsOdd(int value)
    {
      if (value % 2 != 0)
      {
        return true;
      }
      return false;
    }
  }
}