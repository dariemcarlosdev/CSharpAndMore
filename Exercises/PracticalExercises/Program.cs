using System.Collections.Generic;
using System;

namespace ExercisesLearning
{
  class Program
  {

    public static void Main(string[] args)
    {

      var numericalMethods = new BasicAlgorithms.NumericalMethodsRepository();
      var stringMethods = new BasicAlgorithms.StringsMethodsRepository();

      
      Console.WriteLine(numericalMethods.ValueAppearsinArrays(new int[]{10, 20, 40, 50 }, new int[]{10, 20, 40, 50}));
      Console.WriteLine(numericalMethods.ValueAppearsinArrays(new int[]{10, 20, 40, 50 }, new int[]{10, 20, 40, 5}));
      Console.WriteLine(numericalMethods.ValueAppearsinArrays(new int[]{10, 20, 40, 50}, new int[]{1, 20, 40, 5 }));
 
    }


























  
  }

}


