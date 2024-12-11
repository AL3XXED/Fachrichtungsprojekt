using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Vogel : Haustier
    {
        public Vogel(string name) : base(name) { }
    
            public override void sagHallo()
        {
            Console.WriteLine($"Allo ! Ich bin {Name} dein Papagei");
        }

        public void fliegen()
        {
            Console.WriteLine($"{Name} fliegt eine Runde um dich herum");
            Energie -= 15;
            Zufriedenheit += 5;
        }
        public void Singen()
        {
            Console.WriteLine($"{Name} singt ein schönes Lied.");
            Energie -= 10;
            Zufriedenheit += 15;
        }
    }
}
