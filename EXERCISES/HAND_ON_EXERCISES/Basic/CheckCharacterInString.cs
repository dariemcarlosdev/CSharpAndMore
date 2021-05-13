using System;
using System.Linq;
/*
Write a C# program to check if a given string contains ‘w’ character between 1 and 3 times.
Test Data:
Input a string (conatins at least one 'w' char) : w3resource
Test the string contains 'w' character between 1 and 3 times:
Sample Output
True
*/
namespace ExercisesLearning
{
  public class CheckCharacterInString
  {
    
    public static void ContainCharacter()
    {
      Console.Write("\nEnter string to check:");
      var str = Console.ReadLine();
      Console.Write("\nEnter character to check if it's present among 1 and 3 times in the string: ");
      var Letter = char.Parse( Console.ReadLine());
    // Using Linq
    //   var count = str.Count(s => s == Letter);
    //   Console.WriteLine("\nResult: {0}",count >=1 && count<=3);
    var count = 0;
    for (int i = 0; i < str.Length; i++)
    {
        if (str[i] == Letter)
        {
            count+=1;
        }
    }
    Console.WriteLine("\nResult:{0}.Character {1} is present {2} times.",count >=1 && count<=3, Letter, count);
    }
  }
}