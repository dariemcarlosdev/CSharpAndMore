using System;
namespace ExercisesLearning
{
    public class SumPrimes
    {
            //Sum of the first 500 prime numbers:
    public static void SumFirstPrime()
    {
      Console.WriteLine("\nSum of the first 500 prime number");
      var sum = 0;
      var counter = 0;
      var n = 2;
      while (counter < 500) //I user counter to count if n is prime.
      {
        if (IsPrime(n))
        {
          sum += n;
          counter++; 
        }
        n++; //try here counter
      }

      Console.WriteLine(sum);
    }

    private static bool IsPrime(int n)
    {
      var x = Math.Floor(Math.Sqrt(n));
      if (n == 1) return false;
      if (n == 2) return true;
      for (int i = 2; i <= x; i++)
      {

        if (n % i == 0)
        {
          return false;
        }
      }


      return true;
    }
    }
}