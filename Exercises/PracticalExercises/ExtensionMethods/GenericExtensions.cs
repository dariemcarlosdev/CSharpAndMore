using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace ExercisesLearning.ExtensionMethods
{

  public static class GenericExtensions
  {
    //Add methods to existing type(Class) with your own methods, without creating new derived type, recompiling or modifying the original type.
    //Extension methods should be created inside a static class. They themselves should be static and should contain at least one parameter,
    // the first preceded by the this keyword.
    //Type of First parameter (T obj) specifies the type with wich this ext. method will be available and give it a name.
    // it means, the type(Class) we are extending.
    public static bool IsContainedIn<T>(this T obj, params T[] args)
    {
      return args.Contains(obj);
    }

    public static bool IsGreaterThan(this int obj, int value){
     return obj > value ? true : false;
    }

    public static bool StringIsContainedin(this String obj, string str)
    {
      return str.Contains(obj);
    }

    public static string RemoveCharIn(this String str, int pos)
    {
      var newStr = string.Empty;

      for (int i = 0; i <= str.Length - 1; i++)
      {
        if (i != pos)
        {
          newStr = newStr + str[i];
        }
      }

      return newStr;
    }

    public static int GetLastIndex(this string str)
    {
      int index = 0;
      if (str.Length > 0)
      {
        index = str.Length - 1;
      }
      return index;
    }

    public static List<T> rotateToLeftElmnts<T>(this List<T> array ) { 
        
             int lenght =  array.Count();            
         
            for (int i = 0; i < lenght-1;i++)
			{
                var temp = array[i+1];                
                array[i+1]= array[i];
                array[i] = temp;               

			}

            return array;
        
        }
  }
}