using System;

namespace Calculator
{
    internal static class Changer
    {
        public static int[,] IntMatrix(int[,] M, int n)
        {
            var b = true;
            n--;
            var Mat = new int[M.GetLength(0) - 1, M.GetLength(1)];
            while (b)
                try
                {
                    for (var i = 0; i < n; i++)
                    for (var j = 0; j < M.GetLength(1); j++)
                        Mat[i, j] = M[i, j];
                    for (var i = n; i < M.GetLength(0) - 1; i++)
                    for (var j = 0; j < M.GetLength(1); j++)
                        Mat[i, j] = M[i + 1, j];
                    b = false;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("\aНедопустимое значение n.");
                    b = false;
                }

            return Mat;
        }

        public static double[] ArrElemDelete(double[] Arr, int elem)
        {
            var Arr1 = new double[Arr.Length - 1];
            //elem--;
            for (var i = 0; i < elem; i++) Arr1[i] = Arr[i];
            for (var i = elem; i < Arr1.Length; i++) Arr1[i] = Arr[i + 1];
            return Arr1;
        }

        public static string[] ArrElemDelete(string[] Arr, int elem)
        {
            var Arr1 = new string[Arr.Length - 1];
            //elem--;
            for (var i = 0; i < elem; i++) Arr1[i] = Arr[i];
            for (var i = elem; i < Arr1.Length; i++) Arr1[i] = Arr[i + 1];
            return Arr1;
        }
    }
}