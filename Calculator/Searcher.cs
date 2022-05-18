using System;
using System.IO;
using System.Text;

public class Searcher
{
    public static void Find(string puth)
    {
        char wall = ' ';
        int start = 3 - 1;
        string[][] LineArray = Searcher.ArrayOfArray(puth, wall);
        for (int i = 0; i < LineArray[0].Length; i++)
        {
            Console.Write("{1}.{0} ", LineArray[0][i], i + 1);
        }
        int numofcol;
        do
        {
            numofcol = Input.Int("\nВведите номер колонки: ") - 1;
            if ((numofcol >= LineArray[0].Length) || (numofcol < 0))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\aДанной колонки не существует. Повторите попытку");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        while ((numofcol >= LineArray[0].Length) || (numofcol < 0));
        if (Input.IfDouble(LineArray[start][numofcol]))
        {
            Searcher.Double(LineArray, numofcol, start);
        }
        else
        {
            Searcher.String(LineArray, start);
        }
    }
    public static string[][] ArrayOfArray(string puth, char wall)
    {
        string[] ArrayOfFile = File.ReadAllLines(puth, Encoding.Default);
        string[][] LineArray = new string[ArrayOfFile.Length][];
        for (int i = 0; i < ArrayOfFile.Length; i++)
        {
            LineArray[i] = ArrayOfFile[i].Split(new char[] { wall });
        }
        return LineArray;
    }
    public static void String(string[][] LineArray, int start)
    {
        int str = 0;
        do
        {
            string Search = Input.String("Введите искомое значение: ");
            for (int i = start; i < LineArray.Length; i++)
            {
                int len = (LineArray[i][LineArray[0].Length - 1].ToLower()).IndexOf(Search.ToLower());
                if (len != -1)
                {
                    str = i;
                }
            }
            if (str != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < LineArray[0].Length; i++)
                {
                    Console.Write("{0} ", LineArray[str][i]);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\aНичего не найдено по запросу \"{0}\". Повторите попытку", Search);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        while (str == 0);
    }
    public static void Double(string[][] LineArray, int numofcol, int start)
    {
        int str = 0;
        double Element, Delta;
        double Search = Input.Double("Введите искомое значение: ");
        Delta = 9e307;
        for (int i = start; i < LineArray.Length; i++)
        {
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
                Console.WriteLine("\aВ числовом значении в таблице присутствует символ. Возможен некорректный ответ. Закройте окно, исправьте ошибку в таблице и повторите попытку.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        string Material = LineArray[str][LineArray[0].Length - 1];
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Ближайшее значение:{0:F3} \u00B1 {1} {4} - {3}", LineArray[str][numofcol], Delta, str, Material, LineArray[1][numofcol]);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}