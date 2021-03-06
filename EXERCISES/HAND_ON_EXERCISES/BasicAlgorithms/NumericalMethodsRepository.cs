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
      Console.WriteLine(Math.Abs(x - 100) <= 10 || Math.Abs(x - 200) <= 10);
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
      Console.WriteLine(30.IsContainedIn(val1, val2) || val1 + val2 == 30);
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
      Console.WriteLine((temps.First() < 0 && temps.Last() > 100) ||
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

      Console.WriteLine("{0} - count={1}", count <= 1 ? true : false, count);
    }

    public void CheckNearestTo(List<int> values, int point)
    {
      //int nearest=0;
      List<int> OrderList = values.OrderBy(v => v).ToList();
      int rest = 0;
      int max = 0;
      OrderList.ForEach(delegate (int value)
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
        Console.Write("values:[{0}, {1}] --> Values must be non-negative",
            val1,
            val2);
      }
      else
      {
        Console.WriteLine("values:[{0}, {1}] Last digits are equal? --> {2}",
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

    public void ComputeSumElmnts(int x, int y)
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

    public void ComputeSumElmnts(int x, int y, int z)
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

    public int ComputeSumElmnts(int[] intArr)
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

    public static void RotateElmntsInArray(List<int> intArray)
    {
      var Array = intArray.rotateToLeftElmnts();

      foreach (var item in Array)
      {
        Console.Write(item + " ");
      }

    }

    /*
   93. Write a C# Sharp program to reverse a given array of integers and length 5. Go to the editor

Sample Input:
{ 10, 20, -30, -40, 50 }
Expected Output:
Reverse array: 50 -40 -30 20 10
Click me to see the solution
      */

    public static void ReverseElementArray(List<int> intArray)
    {
      intArray.Reverse();

      foreach (var item in intArray)
      {
        Console.Write(item + " ");
      }
    }



    /*   95. Write a C# Sharp program to create a new array containing the middle elements from the two given arrays of integers, each length 5. Go to the editor

   Sample Input:
   { 10, 20, -30, -40, 30 }, { 10, 20, 30, 40, 30 }
   Expected Output:
   New array: -30 30

     */

    public static void newArrayFromDictionary(Dictionary<int, List<int>> dictionary)
    {
      var newArray = new List<int>();
      foreach (var item in dictionary)
      {
        newArray.Add(item.Value.ElementAt(Math.Abs(item.Value.Count / 2)));
      }

      foreach (var item in newArray)
      {
        Console.Write(item + " ");
      }
    }

    /*
     Write a C# Sharp program to check if a given array of integers and length 2, does not contain 15 or 20.

 Sample Input:
 { 12, 20 }
 { 14, 15 }
 { 11, 21 }
 Expected Output :
 False
 False
 True
    */

    public bool ArrayContainElmnt(List<int> list, int elmnt, int elmnt2)
    {

      if (!list.Contains(elmnt) || !list.Contains(elmnt2))
      {

        return false;
      }

      return true;

    }

    /* 
    101. Write a C# Sharp program to check a given array of integers, length 3 and create a new array. 
    If there is a 5 in the given array immediately followed by a 7 then set 7 to 1. Go to the editor

 Sample Input:
 { 1, 5, 7 }
 Expected Output :
 Original array:  1, 5, 7
 New array: 1 5 1
     */

    public List<int> CheckArray(List<int> str)
    {

      for (int i = 0; i < str.Count() - 1; i++)
      {

        if (str[i].Equals(5) && str[i + 1].Equals(7))
          str[i + 1] = 1;
      }

      return str;

    }

    /*
     102. Compute the sum of the two given arrays of integers,
    length 3 and find the array which has the largest sum. Go to the editor

 Sample Input:
 { 10, 20, -30 }, { 10, 20, 30 }
 Expected Output :
 Original array:  1, 5, 7
 Larger array: 10 20 30
     */

    public static List<int> ComputeSumElmnts(Dictionary<int, List<int>> dictionary)
    {

      var largestArray = new List<int>();
      var largestsum = 0;

      foreach (var item in dictionary)
      {
        if (item.Value.Sum() > largestsum)
        {
          largestsum = item.Value.Sum();
          largestArray = item.Value;
        }
      }

      return largestArray;

    }


    /*
     107. Write a C# Sharp program to find the largest value from first, last, 
    and middle elements of a given array of integers of odd length (atleast 1). Go to the editor

Sample Input:
{1}
{1,2,9}
{1,2,9,3,3}
{1,2,3,4,5,6,7}
{1,2,2,3,7,8,9,10,6,5,4}
Expected Output :
1
9
9
7
8    
   */
    public static int FindLargestValueFirstLastMiddle(List<int> list)
    {

      int max = list.First();

      if (list.Count > 1)
      {

        if (list.ElementAt(list.Count / 2) > max)
        {
          max = list.ElementAt(list.Count / 2);

        }

        if (list.Last() > max)
        {
          max = list.Last();

        }

      }

      return max;


    }
    /*
112. Write a C# Sharp program to compute the sum of the numbers in a given array except those numbers starting with 5 followed by atleast one 6. Return 0 if the given array has no integer. Go to the editor

Sample Input:
{ 5, 6, 1, 5, 6, 9, 10, 17, 5, 6 }
{ 5, 6, 1, 5, 6, 9, 10, 17 }
{ 1, 5, 6, 9, 10, 17, 5, 6 }
{ 1, 5, 9, 10, 17, 5, 6 }
{ 1, 5, 9, 10, 17, 5}
     
     */

    public static int ComputeSumElmnts(List<int> list)
    {
      int sum = 0;
      for (int i = 0; i < list.Count - 1; i++)
      {

        if (list[i] + list[i + 1] == 11)
        {
          list.RemoveRange(i, 2);
        }

      }
     sum += list.Sum();
      return sum;
    }



/*
 113. Write a C# Sharp program to check if a given array of integers contains 5 next to a 5 somewhere. Go to the editor

Sample Input:
{ 1, 5, 6, 9, 10, 17 }
{ 1, 5, 5, 9, 10, 17 }
{ 1, 5, 5, 9, 10, 17, 5, 5 }
Expected Output :
False
True
True
 */

    public void CheckArrayContainElmts( List<int> list) { 
        
            bool? flag = null;      
            for (int i = 0; i < list.Count-1; i++)
			{
            if (list[i]==5 && list[i+1]==5)
	{
            flag = true;
                    break;
	}
            flag = false;
			}   
        Console.WriteLine(flag);
        
        }

/*
 115. Write a C# Sharp program to check if the sum of all 5' in the array exactly 15 in a given array of integers. Go to the editor

Sample Input:
{ 1, 5, 6, 9, 10, 17 }
{ 1, 5, 5, 5, 10, 17 }
{ 1, 1, 5, 5, 5, 5}
Expected Output :
 
 */

    public void CheckSumValueInList(List<int> list) { 
        
        //int sum = 0;
        int count =0;
        int result = 0;
            foreach (var item in list)
	{
                if (item == 5)
	{
                    count++;
                    result = item * count;
	}
	}
            Console.WriteLine(result);

        
        }

/*
 119. Write a C# Sharp program to check if an array of integers contains a 3 next to a 3 or a 5 next to a 5 or both. Go to the editor

Sample Input:
{ 5, 5, 5, 5, 5 }
{ 1, 2, 3, 4 }
{ 3, 3, 5, 5, 5, 5}
{ 1, 5, 5, 7, 8, 10}
Expected Output :
True
False
True
True
 */

        public void CheckArrayContainElmts(List<int> list, int val, int val_1) { 
        
            bool? check_Values = false;
            for (int i = 0; i < list.Count-1; i++)
			{
                if ((list[i]==val && list[i+1]==val) || (list[i]==val_1 && list[i+1]==val_1) )
	{
                    check_Values = true;
	}
			}

            Console.WriteLine(check_Values);
        
        }


        /*
         124. Write a C# Sharp program to check a given array of integers and return true if every 5 that appears in the given array is next to another 5. Go to the editor

Sample Input:
{ 5, 6, 5, 3, 7 }
{ 3, 5, 5, 4, 1, 5, 7}
{ 3, 5, 5, 5, 4, 5}
{ 2, 4, 5, 5, 6, 5, 5}

Expected Output :
True
False
True
False
         */
       
        public void CheckValueAppearNextTo( List<int> list, int val) { 
        
            bool? flag = null;
            int listLength = list.Count;
            
            for (int i = 0; i < listLength; i++)
			{
             if (list[i]==val)
	          {     //checking from first lmnt to second last elmnt in the list.
                    if ((i > 0 && list[i-1]==val) || (i < listLength - 1 && list[i+1]==val ))
	                 {
                        flag = true;
	                 }
                   //checking last element in the list.
                    else if (i == listLength - 1)
	                 {
                        flag = false;
	                 }
                   //if value was not found in the list.
                    else
                    flag = false;
	          }   
			}
        Console.WriteLine(flag);
        }
  /*
  125. Write a C# Sharp program to check a given array of integers and return true if the specified number of same elements appears at the start and end of the given array. Go to the editor

Sample Input:
{ 3, 7, 5, 5, 3, 7 }, 2
{ 3, 7, 5, 5, 3, 7 }, 3
{ 3, 7, 5, 5, 3, 7, 5 }, 3
Expected Output :
True
False
True
  */

  public bool ComparingSubList(List<int> list, int val){
  
  var list1 = new List<int>();
  var list2 = new List<int>();
  var Length = list.Count;

  for (int i = 0; i < val; i++)
  {
      list1.Add(list[i]);
  }
  
  for (int i = Length - val ; i < Length; i++)
  {
      list2.Add(list[i]);
  }
  
   
  return list1.SequenceEqual(list2);

  }

/*
126. Write a C# Sharp program to check a given array of integers and return true if the array contains three increasing adjacent numbers.

Sample Input:
{ 1, 2, 3, 5, 3, 7 }
{ 3, 7, 5, 5, 3, 7 }
{ 3, 7, 5, 5, 6, 7, 5 }
Expected Output :
True
False
True
*/

public bool CheckingIncresingValuesInArray(List<int> list){

int listLength = list.Count;
bool isConsecutive = false;

for (int i = 0; i < listLength; i++)
{
    if (i <= listLength - 3)
    {
      if ((list[i+1] - list[i] == 1) && (list[i+2] - list[i+1]==1))
      {
         
       isConsecutive = true;  
      }       
    
    }   
}
 return isConsecutive;
}


/*
 127. shifting an element in left direction and return a new array. Go to the editor

Sample Input:
{ 10, 20, -30, -40, 50 }
Expected Output :
New array: 20 -30 -40 50 10
 */

public void ShiftingElmnInLeft( List<int> List) { 
        
 var listLenght = List.Count;
 var newList = new List<int>(listLenght);          
 
for (int i = 0; i < listLenght; i++)
			{
                newList.Add(Math.Abs(List.ElementAt((i+1) % listLenght)));
                Console.Write(newList[i] + " ");
			}

        }
/*
 128. Create a new array taking the elements before the element value 5 from a given array of integers. Go to the editor

Sample Input:
{ 1, 2, 3, 5, 7 }
Expected Output :
New array: 1 2 3
 
 */

public List<int> TakingElmntsBeforeValue(List<int> List, int value) {
        
           List<int> tempList = new List<int>();
    
            
            foreach (var item in List)
	{
                if (item != value)
	{
                    tempList.Add(item);
	}  
                else  break;
	}
            return tempList;
        
        }

/*
 129. Create a new array taking the elements after the element value 5 from a given array of integers. Go to the editor

Sample Input:
{ 1, 2, 3, 5, 7, 9, 11 }
Expected Output :
New array: 7 9 11
 */


public List<int> TakingElmntsAfterValue(List<int> List, int value) {
        
           List<int> tempList = new List<int>();
           var listLenght = List.Count();
            var pos = List.IndexOf(value);
            
            for (int i = pos; i < listLenght-1; i++)
			{
	
                    tempList.Add(List[i+1]);
	
			}
            return tempList;
        
        }

/*
 130. Create a new array from a given array of integers shifting all zeros to left direction. Go to the editor

Sample Input:
{ 1, 2, 0, 3, 5, 7, 0, 9, 11 }
Expected Output :
 */


public List<int> ShiftingAllZerotoLeft(List<int> List) {
            
            var pos = 0;
            for (int i = 0; i < List.Count; i++)
			{
                if (List[i]==0)
	{
                    List[i] = List[pos];
                    List[pos++] = 0; 
                    // same like List[pos] = 0;
                    // pos++;
	}
			}

           return List;
        }


/*
 132. Creating new array from a given array of integers shifting all even numbers before all odd numbers. Go to the editor

Sample Input:
{ 1, 2, 5, 3, 5, 4, 6, 9, 11 }
Expected Output :
New array: 2 4 6 3 5 1 5 9 11
 */

public List<int> ShiftingEveNumbersBeforeOdd(List<int> List) { 
        
           int pos = 0;

            for (int i = 0; i < List.Count; i++)
			{
                if (Math.Abs(List[i]%2)== 0)
	{               int temp= List[i];
                    List[i] = List[pos];
                    List[pos] = temp;
                    pos ++;  // an element has been inserted at started position.
	}
			}

            return List;

        }

/*
  133.Check if the value of each element is equal or greater than the value of previous element of a given array of integers. Go to the editor

Sample Input:
{ 5, 5, 1, 5, 5 }
{ 1, 2, 3, 4 }
{ 3, 3, 5, 5, 5, 5}
{ 1, 5, 5, 9, 8, 10}
Expected Output:
False
True
True
True
*/

public bool CheckValueEqualorGreaterPrevElmt(List<int> List) { 
        
           int pos = 0;
            bool check = true;
            for (int i = 1; i < List.Count; i++)
			{
                if (List[i] >= List[pos] && i < List.Count)
	{
                 pos++;
	}
                else
	{
            check= false;
	}
			}

            return check;

        }

/*
 135. Finding the larger average value between the first and the second half of a given array of integers and minimum length is at least 2. Assume that the second half begins at index (array length)/2. Go to the editor

Sample Input:
{ 1, 2, 3, 4, 6, 8 }
{ 15, 2, 3, 4, 15, 11 }
Expected Output:
6
10
 
 */

public int CalcLargestAvgBetweenFSHalf(List<int> List) { 
        
   var firtHalfAvg = Average(List, 0, List.Count/2);
   var ScndHalfAvg = Average(List, List.Count/2, List.Count);
   
   if (firtHalfAvg>ScndHalfAvg)
	{
            return firtHalfAvg;
	}         

   else
	{
            return ScndHalfAvg;
	}

  }

 public static int Average(List<int> list, int start, int end) { 
        
           int sum = 0;
           int count = 0;

  for (int i = start; i < end; i++)
			{
                sum+= list[i];
                count++;
			}               
  
            return sum/count;
                
  }

/*
 141. Create a new list from a given list of integers where each element is multiplied by 3. Go to the editor

Sample Input:
{ 1, 2, 3 , 4 }
Expected Output :
New array: 3 6 9 12
 */

 public List<int> NewArrayByNumber(List<int> List) {
        
        IEnumerable<int> newList = List.Select(e => e * 3);
            
            return newList.ToList<int>();

        }

/*
 150. Create a new list from a given list of integers removing those values end with 7. Go to the editor

Sample Input:
{ 10, 22, 35 , 47, 53, 67 }
Expected Output :
10 22 35 53
 */

public List<int> ArrayWithNoMultipleOfValue(List<int> list, int value) { 
        
        var newList = new List<int>();

            foreach (var item in list)
	{
            if (item % 10 != value)
	{
                    newList.Add(item);
	}
	}
            return newList;
        
        }

/*
Takes a number and a width also a number, as input and then displays a triangle of that width, using that number. Go to the editor
Test Data
Enter a number: 6
Enter the desired width: 6
Expected Output :

666666                                                      
66666                                                           
6666                                                                  
666                                                        
66                                                                  
6 
 */

public void PrintRect(int number, int width) { 
        
        var height = width;
            Console.WriteLine("Triangle:");
            for (int i = 0; i < height; i++)
			{
                for (int j = 0; j < width; j++)
			{
                Console.Write(number);
			}
                Console.WriteLine();
                width--;
			}
        
        
        }

/*
 display certain values of the function x = y2 + 2y + 1 (using integer numbers for y , ranging from -5 to +5)
 */

public void DisplayFunctionValue() { 
        
            
            for (int y = -5; y <= 5; y++)
			{
                int x = Math.Pow(y) + 2*y + 1;
                Console.WriteLine("{0} = ({1})2 + 2*({1}) + 1", x, y);
			}
        
        }

/*
 Display the n terms of odd natural number and their sum. Go to the editor
Test Data
Input number of terms : 10
Expected Output :
The odd numbers are :1 3 5 7 9 11 13 15 17 19
The Sum of odd Natural Number upto 10 terms : 100
 */

}

}