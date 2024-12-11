using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Vogel : Haustier
    {
        public Vogel(string tierName) : base(tierName) { }
    
            public override void sagHallo()
        {
            Console.WriteLine($"Allo ! Ich bin {tierName} dein Papagei");
            Console.ReadKey();
        }

        public override void Spazieren()
        {
            Console.WriteLine($"{tierName} fliegt eine Runde um dich herum");
            Console.ReadKey();
            Energie -= 15;
            Zufriedenheit += 5;
        }
        public void Singen()
        {
            Console.WriteLine($"{tierName} singt ein schönes Lied.");
            Console.ReadKey();
            Energie -= 10;
            Zufriedenheit += 15;
        }
    }
}
