using System;

namespace ExercisesLearning{
  /*
  To test result in Program.cs:

      var matrix = new int[,] { { 1, 0, 2, 0 }, { 1, 1, 1, 0 }, { 1, 0, 0, 57 } };
      var matrix2 = new int[,] { { 0, 0, 0, 0 }, { 1, 0, 1, 0 }, { 1, 89, 0, 57 } };
      var matrix3 = new int[,] { { 23, 0, 0, 43 }, { 0, 43, 1, 0 }, { 1, 89, 0, 57 } };
     
      var MatrixCalc = new MatrixCalc(matrix3);
     

      MatrixCalc.SumElmntMatrix();
  
  */
  public class MatrixCalc
{
  private readonly int[,] _array;

  public MatrixCalc(int[,] array)
  {
    _array = array;
  }
  public void SumElmntMatrix()
  {

    var lastIndexRowDim = _array.GetUpperBound(0);


    for (int row = 0; row < _array.GetLength(0); row++)
    {
      for (int col = 0; col < _array.GetLength(1); col++)
      {
        if (_array[row, col] == 0 && row < lastIndexRowDim)
        {

          _array[row + 1, col] = 0;

        }

      }
    }

    PrintMatrix();
  }

  public void PrintMatrix()
  {
    var sum = 0;
    for (int row = 0; row < _array.GetLength(0); row++)
    {
      for (int col = 0; col < _array.GetLength(1); col++)
      {
        Console.Write(_array[row, col] + " ");
        if (_array[row, col] != 0)
        {
          sum += _array[row, col];
        }
      }
      Console.WriteLine("\n");

    }
    Console.WriteLine("Sum Elmnts:" + sum + "\n");
  }
}


}