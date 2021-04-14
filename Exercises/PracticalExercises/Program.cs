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

          /*  95.
      BasicAlgorithms.NumericalMethodsRepository.newArrayFromDictionary(new Dictionary<int, List<int>>(){
        {3,new List<int>{2,3,5,3,4}},
        {1,new List<int> {2,4,3}}
        }
        ); */
         
       Console.Write(numericalMethods.ArrayContainElmnt(new List<int>{12, 20}, 12, 15));
    }


























  
  }

}


