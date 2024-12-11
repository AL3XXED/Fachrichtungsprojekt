using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Haustier
    {
        public string Name { get; set; }
        public int Gesundheit { get; set; }
        public int Hunger { get; set; }
        public int Energie { get; set; }
        public int Zufriedenheit { get; set; }

        public Haustier(string name)
        {
            this.Name = name;
            this.Gesundheit = 100;
            this.Hunger = 10;
            this.Energie = 80;
            this.Zufriedenheit = 50;
        }
        public virtual void sagHallo()
        {
            Console.WriteLine($"Hallo, ich bin {Name}!");
        }

        public virtual void Spielen()
        {
            Console.WriteLine($"{Name} spielt.");
            Energie -= 10;
            Zufriedenheit += 15;
        }
    }
}
