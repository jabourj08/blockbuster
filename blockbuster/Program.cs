using System;
using System.Collections.Generic;

namespace blockbuster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("***** Welcome to BlorkBorstor! *****");
            Console.ResetColor();
            Console.WriteLine();

            Blockbuster myStore = new Blockbuster();

            myStore.MainMenu();

        }
    }
}
