using System;
using System.Collections.Generic;
using System.Linq;
/*
 Write a C# program to sort the integers in ascending order without moving the number -5.
 */
namespace ExercisesLearning{
  public class SortingAscKeepPosition
  {

    static int count = 0;
    private readonly List<int> _list;


    public SortingAscKeepPosition(List<int> list)
    {
      _list = list;
    }

    public void OrderAscending()
    {
      //Create new list with elements of initial List != -5
      List<int> NewListFiltered = _list.Where(x => x >=0).OrderBy(x => x).ToList();
      //Here I use Delegate type to pass a method as argument to another method.
      _list.ForEach(delegate (int value)
      {
        //Print each element of initial list.
        Console.Write(" {0} ", value);
      });
      Console.WriteLine();
      _list.ForEach(delegate (int value)
      {
        //print each value of initial list, ternary condition to evaluate each element if >=0
        //if it's so, asign NewListFiltered[count] and then increment counter, otherwise keep same value.
        Console.Write(" {0} ", value >= 0 ? value = NewListFiltered[count++] : value);
      }
      );

    }
  }
}