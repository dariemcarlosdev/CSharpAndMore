using System;
using System.Collections.Generic;
using System.Linq;

namespace ExercisesLearning
{
  public class IntegersNeeded
  {
    private readonly List<int> lst;
    static int counter = 0;

    /*
Write a C# program which will accept a list of integers and checks how many integers are needed to complete the range.
Sample Example [1, 3, 4, 7, 9], between 1-9 -> 2, 5, 6, 8 are not present in the list. So output will be 4.
*/
    public IntegersNeeded(List<int> lst)
    {
      this.lst = lst;
    }

    public void CalcIntegersNeeded()
    {

      lst.ForEach(
          delegate (int value)
          {
            Console.Write(" {0} ", value);
          }
          );

      for (int i = lst.ElementAt(0); i <= lst.ElementAt(lst.Count - 1); i++)
      {
        if (!lst.Contains(i))
        {
          counter ++;
        }
      }
      Console.Write("\n\b{0} integers are missed to complet the given list.",counter);
    }
  }
}