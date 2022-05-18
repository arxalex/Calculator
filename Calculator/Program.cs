using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            do
            {
                double i = Input.Double("Input: ");
                Console.WriteLine("Нажмите Enter для продолжения");
                key = Console.ReadKey();
            }
            while (key.Key == ConsoleKey.Enter);
        }
    }
}