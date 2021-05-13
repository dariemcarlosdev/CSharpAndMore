using System;
using System.Collections.Generic;


namespace ExercisesLearning
{
  public class Multiply
  {
    static int[] array1 = new int[] { 2, 4, -3, 4 };
    static int[] array2 = new int[] { 3, -1, 4, 0 };

    public static void MultiplyElmntsArrray()
    {
      
        Console.WriteLine("array 1: {0}", string.Join(", ", array1));
        Console.WriteLine("array 1: {0}", string.Join(", ", array2));

      //Write a C# program to multiply corresponding elements of two arrays of integers.
      for (int i = 0; i < array1.Length; i++)
      {
        var multiply = array1[i] * array2[i];
        Console.Write("Result is: {0} ", multiply);


      }

    }
  }
}