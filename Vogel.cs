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
        public  void Singen()
        {
            Console.WriteLine($"{tierName} singt ein schönes Lied.");
            Console.ReadKey();
            Energie -= 10;
            Zufriedenheit += 15;
        }
        public override void Trainieren()
        {
            Console.WriteLine($"{tierName} trainiert.");
            Spielmechanik.Ladebalken(175, 175);
            Energie -= 15;
            Zufriedenheit += 10;
            Hunger += 10;
        }

        public override void Hygiene()
        {
            Console.WriteLine($"{tierName} wird gepflegt.");

            Gesundheit += 10;
            Zufriedenheit += 5;
        }

        public override void Ruhen()
        {
            Console.WriteLine($"{tierName} ruht sich aus.");
            Spielmechanik.Ladebalken(500, 1500);
            Energie = Math.Min(120, Energie + 30);
            Gesundheit += 5;
            Zufriedenheit += 5;
        }

        public override void Futtern(int menge)
        {
            Console.WriteLine($"{tierName} frisst.");
            Spielmechanik.Ladebalken(150, 100);
        }
    }
}
