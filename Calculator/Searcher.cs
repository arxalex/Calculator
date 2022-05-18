using System;
using System.IO;
using System.Text;

namespace Calculator
{
    public class Searcher
    {
        public static void Find(string puth)
        {
            var wall = ' ';
            var start = 3 - 1;
            var LineArray = ArrayOfArray(puth, wall);
            for (var i = 0; i < LineArray[0].Length; i++) Console.Write("{1}.{0} ", LineArray[0][i], i + 1);
            int numofcol;
            do
            {
                numofcol = Input.Int("\nВведите номер колонки: ") - 1;
                if (numofcol >= LineArray[0].Length || numofcol < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\aДанной колонки не существует. Повторите попытку");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (numofcol >= LineArray[0].Length || numofcol < 0);

            if (Input.IfDouble(LineArray[start][numofcol]))
                Double(LineArray, numofcol, start);
            else
                String(LineArray, start);
        }

        public static string[][] ArrayOfArray(string puth, char wall)
        {
            var ArrayOfFile = File.ReadAllLines(puth, Encoding.Default);
            var LineArray = new string[ArrayOfFile.Length][];
            for (var i = 0; i < ArrayOfFile.Length; i++) LineArray[i] = ArrayOfFile[i].Split(wall);
            return LineArray;
        }

        public static void String(string[][] LineArray, int start)
        {
            var str = 0;
            do
            {
                var Search = Input.String("Введите искомое значение: ");
                for (var i = start; i < LineArray.Length; i++)
                {
                    var len = LineArray[i][LineArray[0].Length - 1].ToLower().IndexOf(Search.ToLower());
                    if (len != -1) str = i;
                }

                if (str != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (var i = 0; i < LineArray[0].Length; i++) Console.Write("{0} ", LineArray[str][i]);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aНичего не найдено по запросу \"{0}\". Повторите попытку", Search);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (str == 0);
        }

        public static void Double(string[][] LineArray, int numofcol, int start)
        {
            var str = 0;
            double Element, Delta;
            var Search = Input.Double("Введите искомое значение: ");
            Delta = 9e307;
            for (var i = start; i < LineArray.Length; i++)
                try
                {
                    Element = Convert.ToDouble(LineArray[i][numofcol]);
                    if (Math.Abs(Element - Search) < Delta)
                    {
                        Delta = Math.Abs(Element - Search);
                        str = i;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        "\aВ числовом значении в таблице присутствует символ. Возможен некорректный ответ. Закройте окно, исправьте ошибку в таблице и повторите попытку.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

            var Material = LineArray[str][LineArray[0].Length - 1];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ближайшее значение:{0:F3} \u00B1 {1} {4} - {3}", LineArray[str][numofcol], Delta, str,
                Material, LineArray[1][numofcol]);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}