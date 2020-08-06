using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace blockbuster
{
    class VHS : Movie
    {
        //properties
        public int CurrentTime { get; set; }

        //constructors
        public VHS() { }
        public VHS(string Title, Genre Category, int RunTime, List<string> Scenes) : base(Title, Category, RunTime, Scenes)
        {
        }

        //play scene by scene
        public override void Play()
        {
            string input = "";
            if (CurrentTime == 0)
            {
                int count = 1;
                int splitTime = RunTime / Scenes.Count;

                Console.WriteLine();
                foreach (string scene in Scenes)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"Watching scene {count}: {scene} | Time: {CurrentTime} minutes");
                    CurrentTime = CurrentTime + splitTime;

                    if (count < Scenes.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Would you like to watch the next scene? y/n");
                        Console.ResetColor();
                        input = CheckDecision(Console.ReadLine());
                        if (input == "n")
                        {
                            break;
                        }
                    }
                    else if (count == Scenes.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"...{Title} has ended. Total time: {CurrentTime}");
                    }
                    count++;
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Rewind Movie? y/n");
                Console.ResetColor();
                input = CheckDecision(Console.ReadLine());
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Sorry, the last jerk that rented this movie didn't rewind.");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Rewind now? y/n");
                Console.ResetColor();
                input = CheckDecision(Console.ReadLine());
            }

            if (input == "y")
            {
                Rewind();
            }
        }
        //play all scenes of movie in order
        public override void PlayWholeMovie()
        {
            string input = "";
            if (CurrentTime == 0)
            {
                int count = 1;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Watching {Title}...");
                Console.WriteLine();

                int splitTime = RunTime / Scenes.Count;

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                foreach (string scene in Scenes)
                {
                    Console.WriteLine($"Scene {count}: {scene} | Time: {CurrentTime} minutes");
                    CurrentTime = CurrentTime + splitTime;
                    count++;
                }
                CurrentTime = RunTime;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"...{Title} has ended. Total time: {CurrentTime}");

                Console.WriteLine("Rewind Movie? y/n");
                Console.ResetColor();
                input = CheckDecision(Console.ReadLine());
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Sorry, the last jerk that rented this movie didn't rewind.");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Rewind now? y/n");
                Console.ResetColor();
                input = CheckDecision(Console.ReadLine());
            }

            if (input == "y")
            {
                Rewind();
            }
        }
        //rewind movie
        public void Rewind()
        {
            int colorChange = RunTime / 3;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Rewinding...");
            for (int i = RunTime; i >= 0; i--)
            {
                if (i >= colorChange * 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Current Time: {i}");
                    Thread.Sleep(100);
                }
                else if (i >= colorChange)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Current Time: {i}");
                    Thread.Sleep(100);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Current Time: {i}");
                    Thread.Sleep(100);
                }
            }
            CurrentTime = 0;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("...Thank you for your patience. Rewind complete.");
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
        //Addz Cool Zoundz!!! Because why not??
        public static void BeepBoops()
        {
            Console.Beep(1000, 100); Console.Beep(1000, 100); Console.Beep(1000, 100);
            Console.Beep(2000, 100); Console.Beep(2000, 100); Console.Beep(2000, 100);
        }
    }
}
