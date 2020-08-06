using System;
using System.Collections.Generic;
using System.Text;

namespace blockbuster
{
    class VHS : Movie
    {
        //properties
        public int CurrentTime { get; set; }

        //constructors
        public VHS() { }
        public VHS(string Title, Genre Category, int RunTime, List<string> Scenes, int CurrentTime) : base(Title, Category, RunTime, Scenes)
        {
            this.CurrentTime = CurrentTime;
        }

        public override void Play()
        {
            foreach (string scene in Scenes)
            {
                Console.WriteLine($"Scene {CurrentTime+1}: {scene[CurrentTime]}");
                CurrentTime++;
            }
        }

        public void Rewind()
        {
            CurrentTime = 0;
        }

        public override void PlayWholeMovie()
        {
            throw new NotImplementedException();
        }
    }
}
