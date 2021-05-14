namespace ExercisesLearning
{
  using System;
  /*
Write a C# program to check if a string starts with a specified word. Go to the editor
Note: Suppose the sentence starts with "Hello"
Sample Data: string1 = "Hello how are you?"
Result: Hello.
Sample Output:
Input a string : Hello how are you?
True
  */
  public class StringStartWith
  {
    public static void StartWith()
    {
      Console.Write("\nEnter string to check: ");
      string str = Console.ReadLine();
      Console.Write("\nEnter word to check: ");
      string wordToCheck = Console.ReadLine();

      Console.WriteLine("The result is \n{0}",str.Substring(0, wordToCheck.Length) == wordToCheck);
    }
  }
}