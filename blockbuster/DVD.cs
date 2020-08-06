using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace blockbuster
{
    class DVD : Movie
    {
        //constructors
        public DVD() { }
        public DVD(string Title, Genre Category, int RunTime, List<string> Scenes) : base (Title, Category, RunTime, Scenes)
        {

        }
        public override void Play()
        {
            bool cont = true;

            while (cont)
            {
                int count = 1;
                Console.WriteLine();
                Console.WriteLine($"Which Scene of \"{Title}\" would you like to watch?");
                Console.WriteLine();
                foreach (string scene in Scenes)
                {
                    Console.WriteLine($"Scene {count}: {scene}");
                    count++;
                }
                Console.WriteLine();
                Console.Write($"Enter 1 - {Scenes.Count}: ");
                int selection = CheckNumber(Console.ReadLine(), true, Scenes.Count);
                Console.WriteLine();
                Console.WriteLine($"Watching scene {selection}: {Scenes[selection - 1]}...");

                Console.WriteLine();
                Console.WriteLine("Would you like to watch another scene? y/n");
                string input = CheckDecision(Console.ReadLine());

                if (input == "n")
                {
                    cont = false;
                }
            }
        }

        //play all scenes
        public override void PlayWholeMovie()
        {
            int count = 1;
            Console.Clear();
            Console.WriteLine($"Watching {Title}...");
            Console.WriteLine();
            foreach (string scene in Scenes)
            {
                Console.WriteLine($"Scene {count}: {scene}");
                count++;
            }
            Console.WriteLine();
            Console.WriteLine($"...{Title} has ended.");
        }
        //Check for y/n
        public string CheckDecision(string input)
        {
            bool invalid = true;
            while (invalid)
            {
                if (input.ToLower() == "y")
                {
                    input = "y";
                    invalid = false;
                }
                else if (input.ToLower() == "n")
                {
                    input = "n";
                    invalid = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Why u no listen??? I said enter y/n");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    BeepBoops();
                    Console.Write("Please try again: ");
                    Console.ResetColor();
                    input = Console.ReadLine();
                }
            }
            return input;
        }
        //Check for number
        public int CheckNumber(string input, bool rangeCheck, int num)
        {
            int validNumber = 0;
            bool invalid = true;
            while (invalid)
            {
                try
                {
                    validNumber = int.Parse(input);

                    if (rangeCheck)
                    {
                        if (validNumber > 0 && validNumber <= num)
                        {
                            invalid = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Why u no listen??? I said enter a number from 1-" + num + ".");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            BeepBoops();
                            Console.Write("Please try again: ");
                            Console.ResetColor();
                            input = Console.ReadLine();
                        }
                    }
                    else
                    {
                        invalid = false;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Why u no listen??? Enter a number");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    BeepBoops();
                    Console.Write("Please try again: ");
                    Console.ResetColor();
                    input = Console.ReadLine();
                }
            }
            return validNumber;
        }
        //Addz Cool Zoundz!!! Because why not??
        public static void BeepBoops()
        {
            Console.Beep(1000, 100); Console.Beep(1000, 100); Console.Beep(1000, 100);
            Console.Beep(2000, 100); Console.Beep(2000, 100); Console.Beep(2000, 100);
        }
    }
}
