using System;
using System.Linq;
using ExercisesLearning.ExtensionMethods;
using System.Collections.Generic;


namespace ExercisesLearning.BasicAlgorithms
{
  public class StringsMethodsRepository
  {
    /*
         5. Write a C# Sharp program to create a new string where 'if' is added to the front of a given string.
          If the string already begins with 'if', return the string unchanged. Go to the editor
        */


    public static void CheckAddStringToFront(string str)
    {
      Console.WriteLine(str.Substring(0, 3) == "if " ? str : str.Insert(0, "if "));
    }

    /*6. Write a C# Sharp program to remove the character in a given position of a given string. 
        The given position will be in the range 0.. string length -1 inclusive. Go to the editor

        Sample Input:
    "Python", 1
    "Python", o
    "Python", 4
    Expected Output:
    Pthon
    ython
    Pythn
    */

    public static void RemoveCharGivenPos(string str, int pos)
    {
      //Converting string to array:
      // var array = str.ToArray();
      // for (int i = 0; i <= array.Length-1; i++)
      // {
      //   Console.Write(i!=pos ? array[i] : "");
      // }
      // Console.WriteLine();

      //Using Delete Method of String Class.

      //Console.WriteLine(str.Remove(pos,1));

      //Using MyExtension Method.        

      Console.WriteLine(str.RemoveCharIn(pos));
    }

    /*
     Write a C# Sharp program to exchange the first and last characters in a given string and return the new string. 

    Sample Input:
    "Dariem"
    "a"
    "xy"
    */
    public static void ExchangeChar(string str)
    {

      var firstChar = str.FirstOrDefault();
      var lastChar = str.LastOrDefault();
      Console.WriteLine(str.Substring(1, str.Length - 1));
      Console.WriteLine(str.Length > 1 ? lastChar + str.Substring(1, str.Count() - 2) + firstChar : str);
    }

    // 8. Write a C# Sharp program to create a new string which is 4 copies of the 2 front characters 
    // of a given string. If the given string length is less than 2 return the original string.
    /*
    Sample Input:
  "C Sharp"
  "JS"
  "a"
  Expected Output:
  C C C C 
  JSJSJSJS

  a*/
    public void CreateCopiesFrontChar(string str, int numCopies)
    {

      var newString = string.Empty;
      if (str.Length >= 2)
      {
        for (int i = 0; i <= numCopies - 1; i++)
        {

          newString = newString + str.Substring(0, 2);

        }
      }
      else
      {
        newString = str;
      }
      Console.Write(newString);
    }

    /*
9. Write a C# Sharp program to create a new string with the last char added at the front and back of a given string of length 1 or more.
   "Red"
"Green"
"1"
    */


    public void AddCharFrontBack(string str)
    {

      var newString = string.Empty;
      var lastChar = str.Last();
      newString = lastChar + str + lastChar;
      Console.WriteLine(str.Length >= 1 ? newString : str); ;
    }

    /*
17. Write a C# Sharp program to check if a string 'yt' appears at index 1 in a given string. 
    If it appears return a string without 'yt' otherwise return the original string.

    Sample Input:
"Python"
"ytade"
"jsues"
Expected Output:
Phon
ytade
jsues
    */

    public void CheckStringIn(string strToCheck, string str)
    {

      Console.WriteLine("{0}", str.First());
      Console.WriteLine(strToCheck.StringIsContainedin(str) && str.First() != strToCheck.First() ? str.Remove(str.IndexOf(strToCheck.First()), strToCheck.Length) : str);

    }
    /*
22. Write a C# Sharp program to check if a given string contains between 2 and 4 'z' character. 

    Sample Input:
    "frizz"
    "zane"
    "Zazz"
    "false"
    Expected Output:
    True
    False
    True
    False
    */
    public void CheckCountChar(string str, char character)
    {
      int counter = 0;

      for (int i = 0; i < str.Length; i++)
      {
        if (str[i] == character)
        {
          counter += 1;
        }
      }
      Console.WriteLine(counter >= 2);
    }

    /*
25. Write a C# Sharp program to create a new string which is n (non-negative integer) copies of a given string. 

Sample Input:
"JS", 2
"JS", 3
"JS", 1
Expected Output:
JSJS
JSJSJS
JS
    */
    public void CreateStringWithCopies(string str, int copies)
    {
      int counter = 0;
      String newString = string.Empty;
      while (counter < copies)
      {
        newString += " " + str;
        counter++;
      }

      Console.WriteLine(newString);
    }

    /*
27. Write a C# Sharp program to count the string "aa" in a given string and assume "aaa" contains two "aa".

Sample Input:
"bbaaccaag"
"jjkiaaasew"
"JSaaakoiaa"
Expected Output:
2
2
3
 */
 ///<summary>
///Counts the number that a substring passed as parameter occurs in a given string.
///str: It's a given string.
///subStr: Is the substring to count its occurrence in string.
///</summary>
    public int CountSubstringOcurrence(string str, string subStr)
    {
      int count = 0;
      for (int i = 0; i < str.Length - 1; i++)
      {
        if (str.Substring(i, 2) == subStr)
        {
          count++;
        }
      }

      return count;
    }

    /*
    31. Write a C# Sharp program to count a substring of length 2 appears in a given string and also as the last 2 characters of the string. 
    Do not count the end substring. Go to the editor

    Sample Input:
    "abcdsab"
    "abcdabab"
    "abcabdabab"
    "abcabd"
    Expected Output:
    1
    2
    3
    0
    */
 ///<summary>
/// This function counts the number that a  specific substring occurs in a given string.
///str: It's a given string.
///</summary>

    public void CountSubstringOcurrence(string str)
    {
      string subString = str.Substring(str.Length - 2, 2);

      //Do not count the end substring means 1 less occurrence.
      Console.WriteLine(CountSubstringOcurrence(str, subString) - 1);
    }



    /*
29. Write a C# Sharp program to create a new string made of every other character starting with the first from a given string. 

Sample Input:
"Python"
"PHP"
"JS"
Expected Output:
Pto
PP
J
    */

    public void CreateNewStringOddPos(string str)
    {

      string newStr = string.Empty;

      for (int i = 0; i <= str.Length - 1; i++)
      {
        if (Math.Abs(i % 2) == 0)
        {
          newStr += str[i];
        }
      }

      Console.WriteLine(newStr);
    }

    /*
30. Write a C# Sharp program to create a string like "aababcabcd" from a given string "abcd". Go to the editor

Sample Input:
"abcd"
"abc"
"a"
Expected Output:
aababcabcd
aababc
a
    */
    public void CreateStringGivenFormat(string str)
    {
      string newString = string.Empty;

      for (int i = 0; i <= str.Length - 1; i++)
      {
        newString = newString + str.Substring(0, i + 1);
      }
      Console.WriteLine(newString);
    }
/*46. Write a C# Sharp program to check whether a given string starts with "F" or ends with "B"
 If the string starts with "F" return "Fizz" and return "Buzz" if it ends with "B" 
 If the string starts with "F" and ends with "B" return "FizzBuzz". 
 In other cases return the original string.
Sample Input:
"FizzBuzz"
"Fizz"
"Buzz"
"Founder"
Expected Output:
Fizz
Fizz
Buzz
Fizz */

public string CheckStringStartorEndWith(string str){
if (str.StartsWith("F") && str.EndsWith("B"))
{
   return "FizzBuzz";
}
else
{
     switch (str)
     {
         case string s when s.StartsWith("F"):
         return "Fizz";
         case string s when s.EndsWith('B'):
         return "Buzz";
         default: return "Same input array: " + str;
     }
}
}

/* 
61. Write a C# Sharp program to insert a given string into middle of the another given string of length 4. Go to the editor

Sample Input:
"[[]]","Hello"
"(())", "Hi"
Expected Output:
[[Hello]]
((Hi)) */
public void InsertStringInto(string str1, string str2){

 int posInsertTo = str1.Length /2 ;

 Console.WriteLine(str1.Insert(posInsertTo, str2));

}

/* 63. Write a C# Sharp program to create a new string using first two characters of a given string. 
If the string length is less than 2 then return the original string.. Go to the editor

Sample Input:
"Hello"
"Hi"
"H"
" "
Expected Output:
He
Hi
H */

public void CreateStrGivenLenght(string str, int strLenght){
  
  Console.WriteLine(str.Length>2 ? str.Substring(0,strLenght): str);

}
/* 65. Write a C# Sharp program to create a new string without the first and last character of a given string of length atleast two. 


Sample Input:
"Hello"
"Hi"
"Python"
Expected Output:
ell

ytho */

public void CreateStrGivenLenght(string str){
  Console.WriteLine(str.Length>=2 ? str.Substring(1,str.Length-2): "False");
  }

  /* 67. Write a C# Sharp program to concat two given string of length atleast 1, after removing their first character.

Sample Input:
"Hello", "Hi"
"JS", "Python"
Expected Output:
elloi
Sython */

  public void ConcatStringWithOutFirstCharacter(List<string> ListStrings){
  string newStr = string.Empty;
  foreach (var item in ListStrings)
  {
      newStr += item.Substring(1, item.Length-1);
  }
   Console.WriteLine(newStr);
}

/* 71. Write a C# Sharp program to create a new string using the two middle characters of a given string of even length (
  at least 2).

Sample Input:
"Hell"
"JS"
Expected Output:
el
JS */

public void CreateStrWithMiddleChar(string str, int length){

Console.WriteLine(str.Substring(Math.Abs(str.Length/2)-1,length));
}

/* 72. Write a C# Sharp program to check if a given string ends with "on". Go to the editor

Sample Input:
"Hello"
"Python"
"on"
"o"
Expected Output:
False
True
True
False */

public void CheckStringEndWith(string str, string strToCheck){
Console.WriteLine(str.EndsWith(strToCheck));
}

/* 77. Write a C# Sharp program to create a new string taking the first character from a given string and 
the last character from another given string. If the length of any given string is 0, use '#' as its missing character. 
Sample Input:
"Hello", "Hi"
"Python", "PHP"
"JS", "JS"
"Csharp", ""
Expected Output:
Hi
PP
JS
C#
*/

public void CreateStrFirstLastChar(List<string> strings){

  string newStr = string.Empty;
  var FirstChar = strings.First().FirstOrDefault().ToString();
  var LastChar = strings.Last().LastOrDefault().ToString() ;

  if (strings.First() == "")
  {
      FirstChar = "#";
  }

    if (strings.Last() == "")
    {
        LastChar = "#";
    }
  
  newStr = FirstChar + LastChar; 

  Console.WriteLine(newStr);
}

/* 
78. Write a C# Sharp program to concat two given strings (lowercase). 
If there are any double character in new string then omit one character. 

Sample Input:
"abc", "cat"
"python", "php"
"php", "php"
Expected Output:
abcat
pythonphp
phphp
 */

public void ConcatGivenStringOmitDoubleChar( string str1, string str2){

//Another way to accomplish the same result.
/* var newStr = str1 + str2;
for (int i = 0; i < newStr.Length -1 ; i++)
{
 if(newStr[i] == newStr[i+1]){
  newStr = newStr.RemoveCharIn(i);
 }
} */

//Console.WriteLine(newStr);
Console.WriteLine(
  !str1.EndsWith(str2.Substring(0,1)) ? str1 + str2 : str1 + str2.Substring(1) 
  );
}

/* 79. Write a C# Sharp program to create a new string from a given string after swapping last two characters.

Sample Input:
"Hello"
"Python"
"PHP"
"JS"
"C"
Expected Output:
Helol
Pythno
PPH
SJ
C */
public void SwappingTwoLastChar(string str){

if (str.Length>1)
{
    Console.WriteLine(str.Substring(0,str.Length-2) + str.Last() + str[str.Length-2]);
}

else
{
    Console.Write(str);
}

}


/*
80. Write a C# Sharp program to check if a given string begins with 'abc' or 'xyz'. 
If the string begins with 'abc' or 'xyz' return 'abc' or 'xyz' otherwise return the empty string. 

Sample Input:
"abc"
"abcdef"
"C"
"xyz"
"xyzsder"
Expected Output:
abc
abc

xyz
xyz
*/

public static void CheckingStringBeginsWith(string str, string substr1, string substr2)
{    


if (str.Length >= substr1.Length || str.Length >= substr2.Length)
{
    
if (substr1.StringIsContainedin(str.Substring(0,substr1.Count())))
{
    Console.WriteLine(substr1);
}
else if (substr2.StringIsContainedin(str.Substring(0,substr2.Count())))
{
    Console.WriteLine(substr2);
}
}
 Console.WriteLine( string.Empty);
}

/* 
81. Write a C# Sharp program to check whether the first two characters and last two characters of a given string are same.

Sample Input:
"abab"
"abcdef"
"xyzsderxy"
Expected Output:
True
False
True
 */

public static void AreFirstAndLastSubStringSame (string str, int subStrLength){
Console.WriteLine(str.StartsWith(str.Substring(0,subStrLength)) && str.EndsWith(str.Substring(0,subStrLength)) );
}


/* 
Write a C# Sharp program to concat two given strings.If the given strings have different length remove the characters from the longer string.

Sample Input:
"abc", "abcd"
"Python", "Python"
"JS", "Python"
Expected Output:
abcbcd
PythonPython
JSon
 */
 public static void ConcatGivenStringsWithDifferentsLength(string str1, string str2){
 
   if(!str1.Length.IsGreaterThan(str2.Length)){
     var newstring = str2.Remove(0, Math.Abs(str1.Length - str2.Length));
     Console.WriteLine(string.Concat(str1, newstring));
   }

   else if(str1.Length.IsGreaterThan(str2.Length)){
   var newstring = str1.Remove(0, Math.Abs(str2.Length - str1.Length));
    Console.WriteLine(string.Concat(newstring,str2));
   }

   else
   Console.WriteLine(string.Concat(str1, str2));
  
 }


 /* 
 83. Write a C# Sharp program to create a new string using 3 copies of the first 2 characters of a given string.
Sample Input:
"abc"
"Python"
"J"
Expected Output:
ababab
PyPyPy
JJJ 
  */

  public static void NewStringFromCopyOfFirstChar(string givenStr, int characters, int numberOfCopy){
  string newStr = string.Empty;

  for (int i = 0; i < numberOfCopy; i++)
  {
      newStr += string.Concat(givenStr.Substring(0, characters));
  }
   
   Console.WriteLine(newStr);

  }

/* 
84. Write a C# Sharp program to create a new string from a given string. 
If the two characters of the given string from its beginning and end are same return  the given string without the first two characters otherwise return the original string.

Sample Input:
"abcab"
"Python"
Expected Output:
cab
Python
 */

public static void CreateStringFromGivenOne (string str){

string newStr = str;

if(str.Substring(0,2) == str.Substring(str.Length-2)){

newStr = str.Remove(0,2);

}

Console.WriteLine(newStr);

}

/* 
85. Write a C# Sharp program to create a new string from a given string without the first two characters. 
Keep the first character if it is "p" and keep the second character if it is "y". 

Sample Input:
"abcab"
"python"
"press"
"jython"
Expected Output:
cab
python
pess
ython
 */

public static void StringWithOutFirstTwoCharacters(string str){
/* Sample Input:
"abcab"
"python"
"press"
"jython"
Expected Output:
cab
python
pess
ython */
if (str.Length >= 2)
{ 
   
    if(string.Compare(str.Substring(1,1),"y") !=0){
      str = str.Remove(1,1);
    }
    if(string.Compare(str.Substring(0,1),"p") !=0){
      str = str.Remove(0,1);
    }   
}
else if (string.Compare(str.Substring(0,1),"p") !=0)
{
    str = str.Remove(0,1);
}

Console.WriteLine(str);
//Console.WriteLine(string.Compare(str.Substring(0,1),"p"));
//Console.WriteLine(string.Compare(str.Substring(1,1),"y"));
}


/* 
86. Write a C# Sharp program to create a new string from a given string without the first and last character
 if the first or last characters are 'a' otherwise return the original given string. Go to the editor

Sample Input:
"abcab"
"python"
"abcda"
"jython"
Expected Output:
bcab
python
bcd
jython
 */

public static string CreateStringWithoutCharacters(string str){

if (str.First() =='a')
{
   str = str.Remove(0,1);
}

if(str.Last() =='a') {

  str = str.Remove(str.Length-1,1);
}

return str;

}











  }
}
