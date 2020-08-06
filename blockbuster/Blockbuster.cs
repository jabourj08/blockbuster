using System;
using System.Collections.Generic;
using System.Text;

namespace blockbuster
{
    public class Blockbuster
    {
        private List<Movie> movies = new List<Movie>()
            {
                new VHS("The Bigger Bad-er Wolf - VHS", Genre.Action, 60, (new List<string>() { "One Little Piggy", "Two Little Piggy", "Three Little Piggy", "Four Little Piggy", "Six Little Piggy??" })),
                new VHS("The Wizard of Oz - VHS", Genre.Drama, 112, (new List<string>() { "TORNADO!!!", "The Lollipop Guild", "Dorthy Meets Friends", "The Gang Meets the Wicked Witch of the West", "The Gang Meets THE WIZARD" })),
                new VHS("Willy Wonka and the Chocolate Factory - VHS", Genre.Drama, 90, (new List<string>() { "Charlie and the Fam", "The Golden Ticket!", "Meet Willy Wonka", "The Snozzberries Taste Like Snozzberries", "Oompa Loompa-Palooza" })),
                new DVD("Grocery Shopping: The Movie - DVD", Genre.Horror, 6000, (new List<string>() { "Arrive at Grocery Store", "The Bananas", "The Chicken", "The Tortillas", "The Checkout Line" })),
                new DVD("Shaun of the Dead - DVD", Genre.Comedy, 100, (new List<string>() { "Take Car", "Go to Mum's", "Kill Phil", "Grab Liz", "Go to the Winchester", "Have a Nice Cold Pint", "Wait for All of This to Blow Over" })),
                new DVD("Movie: The Movie - DVD", Genre.Romance, 30, (new List<string>() { "scene 1", "Scene 2", "sCene 3", "scEne 4", "sceNe 5", "scenE 6", "sceNe 7", "scEne 8", "sCene 9", "Scene 10" })),
            };

        private List<Movie> rentedMovies = new List<Movie>(){};

        public void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Currently, there are {movies.Count} movies available for rent.");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1) Show all available movies");
            Console.WriteLine("2) Watch a movie");
            Console.WriteLine("3) Rent a movie");
            Console.WriteLine("4) Return a movie");
            Console.WriteLine("5) Leave this horrible store");
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.Write("Enter 1 - 5: ");
            Console.ResetColor();
            int selection = CheckNumber(Console.ReadLine(), true, 5);

            if (selection == 1)
            {
                if (movies.Count > 0)
                {
                    PrintMovies(movies);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Sorry, there are no movies available for rent at this time.");
                }
                ReturnToMain();
            }
            else if (selection == 2)
            {
                WatchMovies();
            }
            else if (selection == 3)
            {
                CheckOut();
            }
            else if (selection == 4)
            {
                ReturnMovie();
            }
            else if (selection == 5)
            {
                ExitProgram();
            }
        }

        //Print All movie titles
        private void PrintMovies(List<Movie> movielist)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine();
            int counter = 1;
            foreach (Movie m in movielist)
            {
                Console.WriteLine($"{counter}) {m.Title}");
                counter++;
            }
            Console.ResetColor();
        }
        //Watch movies
        public void WatchMovies()
        {
            Console.Clear();
            if (rentedMovies.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("How would you like to watch a movie?");
                Console.WriteLine();
                Console.WriteLine("1) Watch an entire movie");
                Console.WriteLine("2) Watch a movie by scene");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.Write("Enter 1 - 2: ");
                Console.ResetColor();
                int selection1 = CheckNumber(Console.ReadLine(), true, 3);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Please select a movie from the list:");

                PrintMovies(rentedMovies);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"Enter 1 - {rentedMovies.Count}: ");
                Console.ResetColor();
                int selection2 = CheckNumber(Console.ReadLine(), true, rentedMovies.Count);

                if (selection1 == 1)
                {
                    rentedMovies[selection2 - 1].PlayWholeMovie();
                }
                else if (selection1 == 2)
                {
                    rentedMovies[selection2 - 1].Play();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Sorry, you have not rented a movie yet.");
                Console.WriteLine("Please return to the main menu to rent.");
            }
            
            ReturnToMain();
        }
        //check out a movie from the list. (remove said movie)
        public void CheckOut()
        {
            Console.Clear();
            if (movies.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Which movie would you like to check out?");
                PrintMovies(movies);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"Enter 1 - {movies.Count}: ");
                Console.ResetColor();
                int choice = CheckNumber(Console.ReadLine(), true, movies.Count);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have checked out the following movie: ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                movies[choice-1].PrintInfo();
                rentedMovies.Add(movies[choice-1]);
                movies.RemoveAt(choice-1);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Sorry, there are no movies available for rent at this time.");
            }

            ReturnToMain();
        }
        //check out a movie from the list. (remove said movie)
        public void ReturnMovie()
        {
            Console.Clear();
            if (rentedMovies.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Which movie would you like to return?");
                PrintMovies(rentedMovies);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"Enter 1 - {rentedMovies.Count}: ");
                Console.ResetColor();
                int choice = CheckNumber(Console.ReadLine(), true, rentedMovies.Count);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have returned the following movie: ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                rentedMovies[choice - 1].PrintInfo();
                movies.Add(rentedMovies[choice - 1]);
                rentedMovies.RemoveAt(choice - 1);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Silly Goose, you don't have any movies to return!");
            }

            ReturnToMain();
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
            Console.ResetColor();
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
