using System;

/*
Write a C# program to create a new string of four copies, taking last four characters from a given string. 
If the length of the given string is less than 4 return the original one.
Sample Output:
Input a string : The quick brown fox jumps over the lazy dog.
dog.dog.dog.dog.
*/

namespace ExercisesLearning
{
  public class StringCopies
  {
    static string str;
    static int numCopies;

    public static void PrintStringCopy()
    {

      Console.Write("Enter string to print 4 copies: ");
      str = Console.ReadLine();
      Console.Write("Enter num. copies you wanna print: ");
      numCopies = int.Parse(Console.ReadLine());

      if (str.Length >= 4)
      {
        for (int i = 1; i <= numCopies; i++)
        {
          Console.Write("{0} ", str.Substring(str.Length - 4));
        }
      }
      Console.Write(str);
    }
  }
}