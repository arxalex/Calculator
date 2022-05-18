using System;

namespace Calculator
{
    public class Output
    {
        public static void Matrix(string[,] ar)
        {
            {
                var len = 0;
                for (var i = 0; i < ar.GetLength(0); i++)
                for (var j = 0; j < ar.GetLength(1); j++)
                    if (len < ar[i, j].Length)
                        len = ar[i, j].Length;
                for (var i = 0; i < ar.GetLength(0); i++)
                {
                    for (var j = 0; j < ar.GetLength(1); j++)
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
                var len = 0;
                for (var i = 0; i < ar.GetLength(0); i++)
                for (var j = 0; j < ar.GetLength(1); j++)
                    if (len < Convert.ToString(ar[i, j]).Length)
                        len = Convert.ToString(ar[i, j]).Length;
                for (var i = 0; i < ar.GetLength(0); i++)
                {
                    for (var j = 0; j < ar.GetLength(1); j++)
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
                var len = 0;
                for (var i = 0; i < ar.GetLength(0); i++)
                for (var j = 0; j < ar.GetLength(1); j++)
                    if (len < Convert.ToString(ar[i, j]).Length)
                        len = Convert.ToString(ar[i, j]).Length;
                for (var i = 0; i < ar.GetLength(0); i++)
                {
                    for (var j = 0; j < ar.GetLength(1); j++)
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
                var len = 0;
                for (var i = 0; i < ar.GetLength(0); i++)
                for (var j = 0; j < ar.GetLength(1); j++)
                    if (len < Convert.ToString(ar[i, j]).Length)
                        len = Convert.ToString(ar[i, j]).Length;
                for (var i = 0; i < ar.GetLength(0); i++)
                {
                    for (var j = 0; j < ar.GetLength(1); j++)
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
                for (var i = 0; i < ar.GetLength(0); i++)
                {
                    for (var j = 0; j < ar.GetLength(1); j++)
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
                var len = 0;
                for (var i = 0; i < ar.GetLength(0); i++)
                for (var j = 0; j < ar.GetLength(1); j++)
                    if (len < Convert.ToString(ar[i, j]).Length)
                        len = Convert.ToString(ar[i, j]).Length;
                for (var i = 0; i < ar.GetLength(0); i++)
                {
                    for (var j = 0; j < ar.GetLength(1); j++)
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
                var len = 0;
                for (var i = 0; i < ar.GetLength(0); i++)
                for (var j = 0; j < ar.GetLength(1); j++)
                    if (len < Convert.ToString(ar[i, j]).Length)
                        len = Convert.ToString(ar[i, j]).Length;
                for (var i = 0; i < ar.GetLength(0); i++)
                {
                    for (var j = 0; j < ar.GetLength(1); j++)
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
            var len = 0;
            for (var i = 0; i < ar.Length; i++)
            for (var j = 0; j < ar[i].Length; j++)
                if (len < ar[i][j].Length)
                    len = ar[i][j].Length;
            for (var i = 0; i < ar.Length; i++)
            {
                for (var j = 0; j < ar[i].Length; j++)
                {
                    Console.CursorLeft = j * len;
                    Console.Write(ar[i][j]);
                }

                Console.WriteLine();
            }
        }

        public static void ArrayOfArray(int[][] ar)
        {
            var len = 0;
            for (var i = 0; i < ar.Length; i++)
            for (var j = 0; j < ar[i].Length; j++)
                if (len < Convert.ToString(ar[i][j]).Length)
                    len = Convert.ToString(ar[i][j]).Length;
            for (var i = 0; i < ar.Length; i++)
            {
                for (var j = 0; j < ar[i].Length; j++)
                {
                    Console.CursorLeft = j * (len + 1);
                    Console.Write(ar[i][j]);
                }

                Console.WriteLine();
            }
        }

        public static void ArrayOfArray(double[][] ar)
        {
            var len = 0;
            for (var i = 0; i < ar.Length; i++)
            for (var j = 0; j < ar[i].Length; j++)
                if (len < Convert.ToString(ar[i][j]).Length)
                    len = Convert.ToString(ar[i][j]).Length;
            for (var i = 0; i < ar.Length; i++)
            {
                for (var j = 0; j < ar[i].Length; j++)
                {
                    Console.CursorLeft = j * (len + 1);
                    Console.Write(ar[i][j]);
                }

                Console.WriteLine();
            }
        }

        public static void ArrayOfArray(decimal[][] ar)
        {
            var len = 0;
            for (var i = 0; i < ar.Length; i++)
            for (var j = 0; j < ar[i].Length; j++)
                if (len < Convert.ToString(ar[i][j]).Length)
                    len = Convert.ToString(ar[i][j]).Length;
            for (var i = 0; i < ar.Length; i++)
            {
                for (var j = 0; j < ar[i].Length; j++)
                {
                    Console.CursorLeft = j * (len + 1);
                    Console.Write(ar[i][j]);
                }

                Console.WriteLine();
            }
        }

        public static void ArrayOfArray(float[][] ar)
        {
            var len = 0;
            for (var i = 0; i < ar.Length; i++)
            for (var j = 0; j < ar[i].Length; j++)
                if (len < Convert.ToString(ar[i][j]).Length)
                    len = Convert.ToString(ar[i][j]).Length;
            for (var i = 0; i < ar.Length; i++)
            {
                for (var j = 0; j < ar[i].Length; j++)
                {
                    Console.CursorLeft = j * (len + 1);
                    Console.Write(ar[i][j]);
                }

                Console.WriteLine();
            }
        }

        public static void ArrayOfArray(byte[][] ar)
        {
            var len = 0;
            for (var i = 0; i < ar.Length; i++)
            for (var j = 0; j < ar[i].Length; j++)
                if (len < Convert.ToString(ar[i][j]).Length)
                    len = Convert.ToString(ar[i][j]).Length;
            for (var i = 0; i < ar.Length; i++)
            {
                for (var j = 0; j < ar[i].Length; j++)
                {
                    Console.CursorLeft = j * (len + 1);
                    Console.Write(ar[i][j]);
                }

                Console.WriteLine();
            }
        }

        public static void ArrayOfArray(char[][] ar)
        {
            for (var i = 0; i < ar.Length; i++)
            {
                for (var j = 0; j < ar[i].Length; j++)
                {
                    Console.CursorLeft = j * 2;
                    Console.Write(ar[i][j]);
                }

                Console.WriteLine();
            }
        }

        public static void Array(int[] ar)
        {
            for (var i = 0; i < ar.Length; i++)
            {
                Console.CursorLeft = i * 6;
                Console.Write(ar[i]);
            }

            Console.WriteLine();
        }

        public static void Array(double[] ar)
        {
            for (var i = 0; i < ar.Length; i++)
            {
                Console.CursorLeft = i * 6;
                Console.Write(ar[i]);
            }

            Console.WriteLine();
        }

        public static void Array(decimal[] ar)
        {
            for (var i = 0; i < ar.Length; i++)
            {
                Console.CursorLeft = i * 6;
                Console.Write(ar[i]);
            }

            Console.WriteLine();
        }

        public static void Array(string[] ar)
        {
            for (var i = 0; i < ar.Length; i++)
            {
                Console.CursorLeft = i * 6;
                Console.Write(ar[i]);
            }

            Console.WriteLine();
        }

        public static void Array(byte[] ar)
        {
            for (var i = 0; i < ar.Length; i++)
            {
                Console.CursorLeft = i * 6;
                Console.Write(ar[i]);
            }

            Console.WriteLine();
        }

        public static void Array(char[] ar)
        {
            for (var i = 0; i < ar.Length; i++)
            {
                Console.CursorLeft = i * 6;
                Console.Write(ar[i]);
            }

            Console.WriteLine();
        }

        public static void Array(float[] ar)
        {
            for (var i = 0; i < ar.Length; i++)
            {
                Console.CursorLeft = i * 6;
                Console.Write(ar[i]);
            }

            Console.WriteLine();
        }
    }
}