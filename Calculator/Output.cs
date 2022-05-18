using System;

public class Output
{
    public static void Matrix(string[,] ar)
    {
        {
            int len = 0;
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    if (len < ar[i, j].Length)
                    {
                        len = ar[i, j].Length;
                    }
                }
            }
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    Console.CursorLeft = j * (len + 1);
                    Console.Write(ar[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
    public static void Matrix(int[,] ar)
    {
        {
            int len = 0;
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    if (len < Convert.ToString(ar[i, j]).Length)
                    {
                        len = Convert.ToString(ar[i, j]).Length;
                    }
                }
            }
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    Console.CursorLeft = j * (len + 1);
                    Console.Write(ar[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
    public static void Matrix(double[,] ar)
    {
        {
            int len = 0;
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    if (len < Convert.ToString(ar[i, j]).Length)
                    {
                        len = Convert.ToString(ar[i, j]).Length;
                    }
                }
            }
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    Console.CursorLeft = j * (len + 1);
                    Console.Write(ar[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
    public static void Matrix(decimal[,] ar)
    {
        {
            int len = 0;
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    if (len < Convert.ToString(ar[i, j]).Length)
                    {
                        len = Convert.ToString(ar[i, j]).Length;
                    }
                }
            }
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    Console.CursorLeft = j * (len + 1);
                    Console.Write(ar[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
    public static void Matrix(char[,] ar)
    {
        {
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    Console.CursorLeft = j * 2;
                    Console.Write(ar[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
    public static void Matrix(float[,] ar)
    {
        {
            int len = 0;
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    if (len < Convert.ToString(ar[i, j]).Length)
                    {
                        len = Convert.ToString(ar[i, j]).Length;
                    }
                }
            }
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    Console.CursorLeft = j * (len + 1);
                    Console.Write(ar[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
    public static void Matrix(byte[,] ar)
    {
        {
            int len = 0;
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    if (len < Convert.ToString(ar[i, j]).Length)
                    {
                        len = Convert.ToString(ar[i, j]).Length;
                    }
                }
            }
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    Console.CursorLeft = j * (len + 1);
                    Console.Write(ar[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
    public static void ArrayOfArray(string[][] ar)
    {
        int len = 0;
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                if (len < ar[i][j].Length)
                {
                    len = ar[i][j].Length;
                }
            }
        }
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                Console.CursorLeft = j * len;
                Console.Write(ar[i][j]);
            }
            Console.WriteLine();
        }
    }
    public static void ArrayOfArray(int[][] ar)
    {
        int len = 0;
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                if (len < Convert.ToString(ar[i][j]).Length)
                {
                    len = Convert.ToString(ar[i][j]).Length;
                }
            }
        }
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                Console.CursorLeft = j * (len + 1);
                Console.Write(ar[i][j]);
            }
            Console.WriteLine();
        }
    }
    public static void ArrayOfArray(double[][] ar)
    {
        int len = 0;
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                if (len < Convert.ToString(ar[i][j]).Length)
                {
                    len = Convert.ToString(ar[i][j]).Length;

                }
            }
        }
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                Console.CursorLeft = j * (len + 1);
                Console.Write(ar[i][j]);
            }
            Console.WriteLine();
        }
    }
    public static void ArrayOfArray(decimal[][] ar)
    {
        int len = 0;
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                if (len < Convert.ToString(ar[i][j]).Length)
                {
                    len = Convert.ToString(ar[i][j]).Length;

                }
            }
        }
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                Console.CursorLeft = j * (len + 1);
                Console.Write(ar[i][j]);
            }
            Console.WriteLine();
        }
    }
    public static void ArrayOfArray(float[][] ar)
    {
        int len = 0;
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                if (len < Convert.ToString(ar[i][j]).Length)
                {
                    len = Convert.ToString(ar[i][j]).Length;
                }
            }
        }
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                Console.CursorLeft = j * (len + 1);
                Console.Write(ar[i][j]);
            }
            Console.WriteLine();
        }
    }
    public static void ArrayOfArray(byte[][] ar)
    {
        int len = 0;
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                if (len < Convert.ToString(ar[i][j]).Length)
                {
                    len = Convert.ToString(ar[i][j]).Length;
                }
            }
        }
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                Console.CursorLeft = j * (len + 1);
                Console.Write(ar[i][j]);
            }
            Console.WriteLine();
        }
    }
    public static void ArrayOfArray(char[][] ar)
    {
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                Console.CursorLeft = j * 2;
                Console.Write(ar[i][j]);
            }
            Console.WriteLine();
        }
    }
    public static void Array(int[] ar)
    {
        for (int i = 0; i < ar.Length; i++)
        {
            Console.CursorLeft = i * 6;
            Console.Write(ar[i]);
        }
        Console.WriteLine();
    }
    public static void Array(double[] ar)
    {
        for (int i = 0; i < ar.Length; i++)
        {
            Console.CursorLeft = i * 6;
            Console.Write(ar[i]);
        }
        Console.WriteLine();
    }
    public static void Array(decimal[] ar)
    {
        for (int i = 0; i < ar.Length; i++)
        {
            Console.CursorLeft = i * 6;
            Console.Write(ar[i]);
        }
        Console.WriteLine();
    }
    public static void Array(string[] ar)
    {
        for (int i = 0; i < ar.Length; i++)
        {
            Console.CursorLeft = i * 6;
            Console.Write(ar[i]);
        }
        Console.WriteLine();
    }
    public static void Array(byte[] ar)
    {
        for (int i = 0; i < ar.Length; i++)
        {
            Console.CursorLeft = i * 6;
            Console.Write(ar[i]);
        }
        Console.WriteLine();
    }
    public static void Array(char[] ar)
    {
        for (int i = 0; i < ar.Length; i++)
        {
            Console.CursorLeft = i * 6;
            Console.Write(ar[i]);
        }
        Console.WriteLine();
    }
    public static void Array(float[] ar)
    {
        for (int i = 0; i < ar.Length; i++)
        {
            Console.CursorLeft = i * 6;
            Console.Write(ar[i]);
        }
        Console.WriteLine();
    }
}
