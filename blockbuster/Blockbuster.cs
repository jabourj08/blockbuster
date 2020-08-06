using System;
using System.Collections.Generic;
using System.Text;

namespace blockbuster
{
    public class Blockbuster
    {
        private List<Movie> movies = new List<Movie>()
            {
                new VHS("title", Genre.Action, 92, (new List<string>() { "scene1", "scene2", "scene3", "scene4", "scene5" }), 0),
                new VHS("title", Genre.Comedy, 92, (new List<string>() { "scene1", "scene2", "scene3", "scene4", "scene5" }), 0),
                new VHS("title", Genre.Drama, 92, (new List<string>() { "scene1", "scene2", "scene3", "scene4", "scene5" }), 0),
                new DVD("title", Genre.Horror, 92, (new List<string>() { "scene1", "scene2", "scene3", "scene4", "scene5" })),
                new DVD("title", Genre.Romance, 92, (new List<string>() { "scene1", "scene2", "scene3", "scene4", "scene5" })),
                new DVD("Check it Out", Genre.Action, 92, (new List<string>() { "scene1", "scene2", "scene3", "scene4", "scene5" })),
            };        

        public void MainMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1) Show all movies");
            Console.WriteLine("2) Watch a movie");
            Console.WriteLine("3) Leave this horrible store");
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.Write("Enter 1 - 3: ");
            int selection = CheckNumber(Console.ReadLine(), true, 3);

            if (selection == 1)
            {
                PrintMovies();
            }
            else if (selection == 2)
            {
                WatchMovies();
            }
            else if (selection == 3)
            {
                ExitProgram();
            }
        }

        //Print All movie titles
        public void PrintMovies()
        {
            //Console.Clear();
            int counter = 1;
            foreach (Movie m in movies)
            {
                Console.WriteLine($"{counter}) {m.Title}");
                counter++;
            }
            //ReturnToMain();
        }
        //Watch movies
        public void WatchMovies()
        {
            Console.Clear();
            Console.WriteLine("How would you like to watch a movie?");
            Console.WriteLine();
            Console.WriteLine("1) Watch an entire movie");
            Console.WriteLine("2) Watch a movie by scene");
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.Write("Enter 1 - 2: ");
            int selection1 = CheckNumber(Console.ReadLine(), true, 3);

            Console.WriteLine();
            Console.WriteLine("Please select a movie from the list:");
            Console.WriteLine();

            PrintMovies();

            Console.WriteLine();
            Console.Write($"Enter 1 - {movies.Count}: ");
            int selection2 = CheckNumber(Console.ReadLine(), true, movies.Count);

            if (selection1 == 1)
            {
                movies[selection2-1].PlayWholeMovie();
            }
            else if (selection1 == 2)
            {
                movies[selection2-1].Play();
            }
            ReturnToMain();
        }
        //check out a movie from the list. (remove said movie)
        public void CheckOut()
        {
            Console.WriteLine("Which movie would you like to check out?");
            Console.WriteLine();
            PrintMovies();
            Console.WriteLine();
            Console.Write($"Enter 1 - {movies.Count}: ");
            int choice = CheckNumber(Console.ReadLine(), true, movies.Count);

            Console.WriteLine();
            Console.WriteLine("You have checked out the following movie: ");
            Console.WriteLine();
            movies[choice - 1].PrintInfo();
            movies.RemoveAt(choice-1);
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
        //Return to main menu
        public void ReturnToMain()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.Write("Press any key to return to the Main Menu...");
            Console.ResetColor();
            Console.ReadKey();
            Console.WriteLine();
            Console.Clear();
            MainMenu();
        }
        //Determine if user wants to Exit Program
        public void ExitProgram()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Are you sure you want to leave this horrid store? y/n");
            string input = CheckDecision(Console.ReadLine());

            if (input == "y")
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("***** Thank you for choosing BlorkBorstor! Have a great day! *****");
                Console.Write(" Press any key to exit...");
                Console.ReadKey();
            }
            else
            {
                ReturnToMain();
            }
        }
        //Addz Cool Zoundz!!! Because why not??
        public static void BeepBoops()
        {
            Console.Beep(1000, 100); Console.Beep(1000, 100); Console.Beep(1000, 100);
            Console.Beep(2000, 100); Console.Beep(2000, 100); Console.Beep(2000, 100);
        }
    }
}
