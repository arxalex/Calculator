using System;

namespace Calculator
{
    public static class Program
    {
        private static void Main()
        {
            ConsoleKeyInfo key;
            do
            {
                Input.Double("Input: ");
                Console.WriteLine("Нажмите Enter для продолжения");
                key = Console.ReadKey();
            } while (key.Key == ConsoleKey.Enter);
        }
    }
}