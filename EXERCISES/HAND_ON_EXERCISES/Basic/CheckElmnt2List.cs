using System.Collections.Generic;
using System;

namespace ExercisesLearning
{
  /*
  Write a C# program to check if the first element or the last element of the two arrays ( length 1 or more) are equal.
Test Data:
Array1: [1, 2, 2, 3, 3, 4, 5, 6, 5, 7, 7, 7, 8, 8, 1]
Array2: [1, 2, 2, 3, 3, 4, 5, 6, 5, 7, 7, 7, 8, 8, 5]
Check if the first element or the last element of the two arrays ( length 1 or more) are equal.
Sample Output
True
  */
  public class CheckElmnt2List
  {
    static List<int> list1 = new List<int>(){31};
    static List<int> list2 = new List<int>(){3, 2, 2, 3, 3, 4, 5, 6, 5, 7, 7, 7, 8, 8, 5};
public static void CheckElmnt(){
       if (list1.Count >1 && list2.Count >1)
   {
       Console.Write("Result: {0}\n",list1[0] == list2[0] || list1[list1.Count-1] == list2[list2.Count-1]);
   }
else
   Console.Write("Pls, double-check arrray lenght.\n!");
}

  }
}