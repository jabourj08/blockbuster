using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace blockbuster
{
    abstract class Movie
    {
        //Properties
        public string Title { get; set; }
        public Genre Category { get; set; }
        public int RunTime { get; set; }
        public List<string> Scenes { get; set; }

        //enum
        //public enum Genre { Drama, Comedy, Horror, Romance, Action};

        //constructors
        public Movie() { }
        public Movie(string Title, Genre Category, int RunTime, List<string> Scenes)
        {
            this.Title = Title;
            this.Category = Category;
            this.RunTime = RunTime;
            this.Scenes = Scenes;
        }

        //disply movie info
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Title:\t\t{Title}");
            Console.WriteLine($"Category:\t{Category}");
            Console.WriteLine($"Runtime:\t{RunTime} minutes");
        }

        //display all scenes
        public virtual void PrintScenes()
        {
            foreach (string scene in Scenes)
            {
                int count = 1;
                Console.WriteLine($"Scene {count}: ");
                count++;
            }
        }

        public abstract void Play();
        public abstract void PlayWholeMovie();
    }
}
