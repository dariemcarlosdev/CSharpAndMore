using System;
using System.Collections.Generic;
using System.Linq;
namespace ExercisesLearning
{
  /*
  Write a C# program to rotate an array (length 3) of integers in left direction. Go to the editor
Test Data:
Array1: [1, 2, 8]
After rotating array becomes: [2, 8, 1]
*/
  public class RotateListLeft
  {
    public static List<int> lst = new List<int>() { 2, 8, 1, 5 };
    public static void RotateElmntsListLeft()
    {
      for (int i = 0; i < lst.Count - 1; i++)
      {
        int temp = lst[i];
        lst[i] = lst[i + 1];
        lst[i + 1] = temp;
      }

      lst.ForEach(delegate (int value)
 {
   Console.Write("{0} ", value);
 });
    }
  }
}