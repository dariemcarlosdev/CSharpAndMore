using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodFillAlgorithm
{
    class Program
    {
        static void Main(string[] args) {

            /*this is a jagged array (an array of arrays), while int[,] is a two dimension array (Matrix). 
            The first bracket specifies the size of an array, and the second bracket specifies the dimensions of the array which is going to be stored.
             */

            // A jagged array is initialized with two square brackets [][]
            int[][] image_array = new int[10][];
            image_array[0] = new int[] { 8, 4, 5, 3, 2, 2, 2, 6, 9, 5 };       
            image_array[1] = new int[] { 3, 1, 3, 7, 4, 8, 9, 0, 1, 6 };
            image_array[2] = new int[] { 0, 7, 1, 7, 5, 2, 2, 8, 6, 9 };
            image_array[3] = new int[] { 9, 1, 0, 5, 8, 8, 0, 5, 5, 9 };
            image_array[4] = new int[] { 3, 4, 9, 5, 4, 8, 0, 2, 7, 5 };
            image_array[5] = new int[] { 5, 1, 1, 8, 1, 6, 5, 9, 7, 8 };
            image_array[6] = new int[] { 9, 7, 9, 4, 5, 3, 4, 1, 8, 2 };
            image_array[7] = new int[] { 5, 1, 6, 3, 5, 4, 8, 9, 0, 8 };
            image_array[8] = new int[] { 8, 8, 6, 1, 0, 8, 0, 6, 9, 9 };
            image_array[9] = new int[] { 4, 1, 8, 7, 3, 6, 9, 6, 6, 1 };

            int[][] image_array2 = new int[2][];
            image_array2[0] = new int[] { 0, 0, 0 };
            image_array2[1] = new int[] { 0, 0, 0 };

            //FloodFillAlgorithm.PrintJaggedArray(image_array);
            //Console.ReadLine();
            //var floodfill = new FloodFillAlgorithm();
            var dfs = new DFSAlgorithm();
            //FloodFillAlgorithm.PrintJaggedArray(floodfill.FloodFillBoundary(image_array, 1, 1, 2));
             var jaggledArray = dfs.FloodFillWithStack(image_array,8,0,9);
            FloodFillAlgorithm.PrintJaggedArray(jaggledArray);
        }
    }

    public class FloodFillAlgorithm

    {
        
        public  int[][] FloodFillBoundary(int[][] image, int sr, int sc, int newColor)
        {
                  
            var color = image[sr][sc];
            if (color != newColor)
            {
                dfRecursion(image, sr, sc, color, newColor);
            }
           
            return image;
            
          
        }

        private void dfRecursion( int[][] image, int r, int c, int color, int newColor)
        {
            if (image[r][c] == color)
            {
                image[r][c] = newColor;
                if (r >= 1) { dfRecursion(image, r - 1, c, color, newColor); }
                if (c >= 1) { dfRecursion(image, r, c-1, color, newColor); }
                if (r + 1 < image.Length){ dfRecursion(image,r + 1, c, color,newColor); };
                if (c + 1 < image[0].Length) { dfRecursion(image, r, c + 1, color, newColor); };
            }
        }

        public static void PrintJaggedArray(int[][] ja) 
        {


            for (int i = 0; i < ja.Length; i++)
            {
                Console.Write("Element({0}): ", i);

                for (int j = 0; j < ja[i].Length; j++)
                {
                    Console.Write("{0}{1}", ja[i][j], j == (ja[i].Length - 1) ? "" : " ");

                }

                Console.WriteLine();
            }

        }
    }

    public class DFSAlgorithm
    {

        public int[][] FloodFillWithStack(int[][] image, int sr, int sc, int newColor)
        { 
            if (image[sr][sc] == newColor)
                return image;
            
            var originarColor = image[sr][sc];

            var Stack = new Stack<(int x, int y)>(); //store position in Stack
            Stack.Push((sr, sc));

            while (Stack.Count > 0)
            {
                var (x, y) = Stack.Pop();
                    if (x < 0 || x > image.Length - 1 || 
                        y < 0 || y > image[0].Length -1 ) 
                
                    continue; // it skips its giving statement and continues with the next iteration of the loop.
                

                if (image[x][y] != originarColor || image[x][y] == newColor)
                
                    continue;
                

                image[x][y] = newColor;

                Stack.Push((x - 1 , y)); // top
                Stack.Push((x + 1, y)); // bottom
                Stack.Push((x, y + 1 )); //right
                Stack.Push((x, y - 1)); //left

            }           

            return image;
        }

    }
}
