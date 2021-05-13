using System;

/*Write a C# program to create a new string where the first 4 characters will be in lower case. 
If the string is less than 4 characters then make the whole string in upper case.
Test Data:
Input a string: w3r
Sample Output
W3R*/

namespace ExercisesLearning
{
  public class StringLowerUpper
  {
    public static string str1;
    public static int num;

    public static void CreateNewString()
    {
      Console.Write("\nEnter string to convert: ");
      str1 = Console.ReadLine();      
      Console.Write("\nEnter characters to convert: ");
      num = int.Parse(Console.ReadLine());
      Console.Write(str1.Length > num ? str1.Substring(0, num).ToLower() : str1.ToUpper());

    }
  }
}