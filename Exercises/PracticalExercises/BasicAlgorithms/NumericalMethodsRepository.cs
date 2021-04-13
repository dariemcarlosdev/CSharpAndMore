using System;
using System.Collections.Generic;
using System.Linq;
using ExercisesLearning.ExtensionMethods;
using PracticalExercises.Services;

namespace ExercisesLearning.BasicAlgorithms
{
  public class NumericalMethodsRepository : INumerical
  {
    /*
Write a C# Sharp program to check a given integer and return true if it is within 10 of 100 or 200.
*/
    public void CheckInteger(int x)
    {
      Console
          .WriteLine(Math.Abs(x - 100) <= 10 || Math.Abs(x - 200) <= 10);
    }

    /*
Write a C# Sharp program to compute the sum of the two given integer values. 
If the two values are the same, then return triple their sum.
*/
    public void ComputeSumValues(int v1, int v2)
    {
      Console.WriteLine(v1 != v2 ? v1 + v2 : 3 * (v1 + v2));
    }

    /* Check values and Sum */
    public void CheckValueSumIntegers(int val1, int val2)
    {
      //Creating new List with two values:
      /*List<int> lst = new List<int>{val1,val2};
  lst.ForEach(delegate(int v){
      Console.Write(v);
  });    
Console.WriteLine(lst.Contains(30) || val1 + val2 == 30);*/
      //Using extension methods:
      Console
          .WriteLine(30.IsContainedIn(val1, val2) || val1 + val2 == 30);
    }

    /*
Write a C# Sharp program to get the absolute difference between n and 51. 
If n is greater than 51 return triple the absolute difference
*/
    public void CalAbsoluteDifference(int n)
    {
      Console.WriteLine(n <= 51 ? Math.Abs(n - 51) : 3 * ((n) - 51));
    }

    /*
13. Write a C# Sharp program to check if one given temperatures is less than 0 and the other is greater than 100. 
Go to the editor

Sample Input:
120, -1
-1, 120
2, 120
Expected Output:
True
True
False
*/
    //temps.Exists(t => t < 0 )
    public void CheckingTemp(List<int> temps)
    {
      Console
          .WriteLine((temps.First() < 0 && temps.Last() > 100) ||
          (temps.First() > 100 && temps.Last() < 0));
    }

    /*
16. Write a C# Sharp program to check whether two given integer values are in the range 20..50 inclusive.
    Return true if 1 or other is in the said range otherwise false.
    Sample Input:
20, 84
14, 50
11, 45
25, 40
Expected Output:
True
True
True
False
*/
    public void CheckInRange(List<int> values)
    {
      int count = 0;

      foreach (var item in values)
      {
        if (item >= 20 && item <= 50)
        {
          count++;
        }
      }

      Console
          .WriteLine("{0} - count={1}", count <= 1 ? true : false, count);
    }

    public void CheckNearestTo(List<int> values, int point)
    {
      //int nearest=0;
      List<int> OrderList = values.OrderBy(v => v).ToList();
      int rest = 0;
      int max = 0;
      OrderList
          .ForEach(delegate (int value)
          {
            if (value <= point)
            {
              max = value;
            }
            Console.Write(value + " ");
            rest = Math.Abs(rest - value);
          });

      Console.WriteLine("Nearest to 100 is: {0}", rest > 0 ? max : 0);
    }

    /*23. Write a C# Sharp program to check if two given non-negative integers have the same last digit. Go to the editor

Sample Input:
123, 456
12, 512
7, 87
12, 45
Expected Output:
False
True
True
False*/
    public void CheckingLastDigit(int val1, int val2)
    {
      if ((new List<int> { val1, val2 }.Exists(val => val < 0)))
      {
        Console
            .Write("values:[{0}, {1}] --> Values must be non-negative",
            val1,
            val2);
      }
      else
      {
        Console
            .WriteLine("values:[{0}, {1}] Last digits are equal? --> {2}",
            val1,
            val2,
            val1 % 10 == val2 % 10);
      }
      // else
      // {
      //   var str1 = val1.ToString();
      //   var str2 = val2.ToString();
      //   Console.WriteLine(str1.Last() == str2.Last());
      // }
    }

    /*38. Write a C# Sharp program to count the number of two 5's are next to each other in an array of integers. Also count the situation where the second 5 is actually a 6. Go to the editor

Sample Input:
{ 5, 5, 2 }
{ 5, 5, 2, 5, 5 }
{ 5, 6, 2, 9}
Expected Output:
1
2
1*/
    public void Count2NumberEachOther(int[] integerArr)
    {
      int count = 0;
      for (int i = 0; i < integerArr.Length - 1; i++)
      {
        if (integerArr[i].Equals(5) && (integerArr[i + 1].Equals(5) || integerArr[i + 1].Equals(6)))
        {
          count++;
        }
      }

      Console.WriteLine(count);
    }

    /* 39. Write a C# Sharp program to check if a triple is presents in an array of integers or not. If a value appears three times in a row in an array it is called a triple. Go to the editor

Sample Input:
{ 1, 1, 2, 2, 1 }
{ 1, 1, 2, 1, 2, 3 }
{ 1, 1, 1, 2, 2, 2, 1 }
Expected Output:
False
False
True */

    public void CheckTripleNumbIsPresent(int[] integerArr)
    {
      int count = 0;
      for (int i = 0; i < integerArr.Length - 2; i++)
      {
        if (integerArr[i].Equals(integerArr[i + 1]) && integerArr[i + 1].Equals(integerArr[i + 2]))
        {
          count++;
        }
      }
      Console.WriteLine("{0}, {1} tripes are presents in {2}", count > 0, count, string.Join(",", integerArr));
    }

    /* 47. Write a C# Sharp program to check if it is possible to add two integers to get the third integer from three given integers. 

    Sample Input:
    1, 2, 3
    4, 5, 6
    -1, 1, 0
    Expected Output:
    True
    False
    True */

    public bool CheckAddEqualThird(int[] intArr)
    {
      int add = intArr[0] + intArr[1];
      switch (add)
      {
        case int e when e == intArr[2]:
          return true;
        default: return false;
      }
    }

    /*
    49. Write a C# Sharp program to check if three given numbers are in strict increasing order, such as 4 7 15, or 45, 56, 67,
     but not 4 ,5, 8 or 6, 6, 8.However,if a fourth parameter is true, equality is allowed, such as 6, 6, 8 or 7, 7, 7. 

    Sample Input:
    1, 2, 3, false
    1, 2, 3, true
    10, 2, 30, false
    10, 10, 30, true

    Expected Output:
    True
    True
    False
    True
    */

    public bool CheckStrictIncreasingOrder(int[] intArray, bool flag)
    {

      return flag ? intArray[0] <= intArray[1] && intArray[1] <= intArray[2] : intArray[0] < intArray[1] && intArray[1] < intArray[2];
    }

    /*
    50. Write a C# Sharp program to check if two or more non-negative given integers have the same rightmost digit. Go to the editor

    Sample Input:
    11, 21, 31
    11, 22, 31
    11, 22, 33
    Expected Output:
    True
    True
    False
    */

    public string CheckSameRightmostDigit(int[] integerArr)
    {
      int result = 0;
      while (integerArr.All(i => i > 0))
      {
        for (int i = 0; i < integerArr.Length - 1; i++)
        {
          for (int j = 1; j < integerArr.Length; j++)
          {
            result = Math.Abs(integerArr[i] % 10) == Math.Abs(integerArr[j] % 10) ? result += 1 : result;

          }
        }
        break;
      }

      return string.Join(",", integerArr) + " -> " + (result >= 1 ?
       "It's TRUE, two/more non-negative given integers have the same rightmost digit." :
       "it's FALSE, two/more given integers do not have the same rightmost digit or have any negative integer.");
    }

    /*
51. Write a C# Sharp program to check three given integers and return true if one of them is 20 or more less than one of the others.

Sample Input:
11, 21, 31
11, 22, 31
10, 20, 15
Expected Output:
True
True
False
    */
    public void CheckNumber(int[] integerArr)
    {

      var result = false;

      foreach (var item in integerArr)
      {
        if (item > 20)
        {
          for (int i = 0; i <= integerArr.Length - 1; i++)
          {
            result = item <= integerArr[i];
          }

          break;
        }
      }
      Console.WriteLine(result);
    }

    /*
    53. Write a C# Sharp program to check two given integers, each in the range 10..99. 
    Return true if a digit appears in both numbers, such as the 3 in 13 and 33. 

    Sample Input:
    11, 21
    11, 20
    10, 10
    Expected Output:
    True
    False
    True
    */

    public void CheckInRangeAndDigit(int val1, int val2)
    {
      var stringvalue = string.Empty;
      if (val1 >= 10 && val1 <= 99 && val2 >= 10 && val2 <= 99)
      {

        Console.WriteLine(val1 / 10 == val2 / 10 || val1 / 10 == val2 % 10 || val1 % 10 == val2 / 10 || val1 % 10 == val2 % 10);


        /* Another way to solve it: 
         Console.WriteLine(val1.ToString().Contains(val2.ToString().First()) || val1.ToString().Contains(val2.ToString().Last()));
         */
      }
      else
      {
        Console.WriteLine("Two numbers must be in the range 10..99, pls enter two new intergers.");
      }
    }

    /*54. Write a C# Sharp program to compute the sum of two given non-negative integers x and y as long as the sum has the same number of digits as x. 
    If the sum has more digits than x then return x without y. Go to the editor

    Sample Input:
    4, 5 00
    7, 4
    10, 10
    101,10
    10,104
    Expected Output:
    9
    7
    20 */

    public void CheckComputeSum(int x, int y)
    {

      int sum = x + y;

      Console.WriteLine(x.ToString().Length == sum.ToString().Length ? sum : x + " and " + sum + " don't have same number of digit.");

    }

    /*55 -  Write a C# Sharp program to compute the sum of three given integers.
     If the two values are same return the third value.

     Sample Input:
    4, 5, 7
    7, 4, 12
    10, 10, 12
    12, 12, 18
    Expected Output:
    16
    23
    12
    18

     */

    public void ComputeSum3Int(int x, int y, int z)
    {

      Console.WriteLine(x % 10 == y % 10 && x / 10 == y / 10 ? z : x + y + z);
    }

    /* 56. Write a C# Sharp program to compute the sum of the three integers.
     If one of the values is 13 then do not count it and its right towards the sum. Go to the editor

    Sample Input:
    4, 5, 7
    7, 4, 12
    10, 13, 12
    13, 12, 18
    Expected Output:
    16
    23
    10
    0 */

    public int CheckValueThenComputeSum(int[] intArr)
    {
      int sum = 0;
      foreach (var item in intArr)
      {
        if (item != 13)
        {
          sum += item;

        }
        else
        {
          break;
        }
      }
      return sum;
    }

    /*59. Write a C# Sharp program to check three given integers (small, medium and large) 
    and return true if the difference between small and medium and the difference between medium and large is same.

    Sample Input:
    4, 5, 6
    7, 12, 13
    -1, 0, 1
    Expected Output:
    True
    False
    True */

    public void CheckDifferenceIntegers(int x, int y, int z)
    {

      Console.WriteLine(x - y == y - z);
    }

    /* 
    Write a C# Sharp program to check a given array of integers of length 1 or more and return true if 10 appears as either first or last element in the given array. 

    Sample Input:
    { 10, 20, 40, 50 }
    { 5, 20, 40, 10 }
    { 10, 20, 40, 10 }
    { 12, 24, 35, 55 }
    Expected Output:
    True
    True
    True
    False
     */

    public bool ValueAppearsinArrays(int[] intArray, int value)
    {

      bool appears = false;

      foreach (var elmnt in intArray)
      {
        if (elmnt == value)
        {
          appears = true;
        }
      }

      return appears;
    }

    /* 
    Write a C# Sharp program to check a given array of integers of length 1 or more and return true if the first element and the last element are equal in the given array
     Sample Input:
    { 10, 20, 40, 50 }
    { 10, 20, 40, 10 }
    { 12, 24, 35, 55 }
    Expected Output:
    False
    True
    False

     */

    public bool ValueAppearsinArrays(int[] intArray)
    {

      if (intArray.First() == intArray.Last())
      {
        return true;
      }

      return false;
    }

    /* 
    90.Write a C# Sharp program to check two given arrays of integers of length 1 or more 
    and return true if they have the same first element or they have the same last element.

    Sample Input:
    { 10, 20, 40, 50 }, { 10, 20, 40, 50 }
    { 10, 20, 40, 50 }, { 10, 20, 40, 5 }
    { 10, 20, 40, 50 }, { 1, 20, 40, 5 }
    Expected Output:
    True
    True
    False
     */

    public bool ValueAppearsinArrays(int[] array1, int[] array2)
    {

      if (array1.First() == array2.First() || array1.First() == array2.Last())
      {
        return true;
      }

      return false;

    }


     /*
     92. Write a C# Sharp program to rotate the elements of a given array of integers (length 4 ) in left direction and return the new array. Go to the editor

Sample Input:
{ 10, 20, -30, -40 }
Expected Output:
Rotated array: 20 -30 -40 10
      
      */

        public static void RotateElmntsInArray(int[] intArray)
        {
           intArray = intArray.RotateToLeftElmnts().ToArray();

            foreach (var item in intArray)
	{
                Console.Write(item + " ");
	}
        
        }


  }
}
