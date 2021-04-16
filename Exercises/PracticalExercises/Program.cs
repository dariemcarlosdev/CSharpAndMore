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
        ); 
          
        var newDictionary= new Dictionary<int, List<int>>();
        newDictionary.Add(1, new List<int> {10,20,34});
        newDictionary.Add(2, new List<int>{10,20,30});
        var arraylargestSum = BasicAlgorithms.NumericalMethodsRepository.ComputeSumList(newDictionary);

        foreach (var item in arraylargestSum)
	{
        Console.Write(item + " ");

            Testing new update.
	}          
           */
         
    Console.WriteLine(BasicAlgorithms.NumericalMethodsRepository.FindLargestValueFirstLastMiddle(new List<int>{1}));        
    Console.WriteLine(BasicAlgorithms.NumericalMethodsRepository.FindLargestValueFirstLastMiddle(new List<int>{1,2,9})); 
    Console.WriteLine(BasicAlgorithms.NumericalMethodsRepository.FindLargestValueFirstLastMiddle(new List<int>{1,2,9,3,3})); 
    Console.WriteLine(BasicAlgorithms.NumericalMethodsRepository.FindLargestValueFirstLastMiddle(new List<int>{1,2,3,4,5,6,7}));        
    Console.WriteLine(BasicAlgorithms.NumericalMethodsRepository.FindLargestValueFirstLastMiddle(new List<int>{1,2,2,3,7,8,9,10,6,5,4}));        



    }
  
  }

}


