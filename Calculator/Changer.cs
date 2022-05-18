using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Changer
{
    public static int[,] IntMatrix(int[,] M, int n)
    {
        bool b = true;
        n--;
        int[,] Mat = new int[M.GetLength(0) - 1, M.GetLength(1)];
        while (b)
        {
            try
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < M.GetLength(1); j++)
                    {
                        Mat[i, j] = M[i, j];
                    }
                }
                for (int i = n; i < (M.GetLength(0) - 1); i++)
                {
                    for (int j = 0; j < M.GetLength(1); j++)
                    {
                        Mat[i, j] = M[i + 1, j];
                    }
                }
                b = false;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("\aНедопустимое значение n.");
                b = false;
            }
        }
        return Mat;
    }
    public static double[] ArrElemDelete(double[] Arr, int elem)
    {
        double[] Arr1 = new double[Arr.Length - 1];
        //elem--;
        for (int i = 0; i < elem; i++)
        {
            Arr1[i] = Arr[i];           
        }
        for (int i = elem; i < Arr1.Length; i++)
        {
            Arr1[i] = Arr[i + 1];            
        }
        return Arr1;
    }
    public static string[] ArrElemDelete(string[] Arr, int elem)
    {
        string[] Arr1 = new string[Arr.Length - 1];
        //elem--;
        for (int i = 0; i < elem; i++)
        {
            Arr1[i] = Arr[i];
        }
        for (int i = elem; i < Arr1.Length; i++)
        {
            Arr1[i] = Arr[i + 1];
        }
        return Arr1;
    }
}
