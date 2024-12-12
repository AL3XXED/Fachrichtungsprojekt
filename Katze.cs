using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Katze : Haustier
    {
        public Katze(string tierName) : base(tierName) { }

        public override void sagHallo()
        {
            Console.WriteLine($"Miauu! Ich bin {tierName} die Katze");
        }

        public override void Spielen()
        {
            Console.WriteLine($"{tierName} spielt am Kratzbaum");
            Energie -= 15;
            Zufriedenheit += 5;
        }
        public override void Streicheln()
        {
            Console.WriteLine($"{tierName} schnurrt zufrieden.");
            Zufriedenheit += 5;
        }
        public virtual void Trainieren()
        {
            Console.WriteLine($"{tierName} trainiert.");
            Spielmechanik.Ladebalken(175, 175);
            Energie -= 15;
            Zufriedenheit += 10;
            Hunger += 10;
        }

        public virtual void Hygiene()
        {
            Console.WriteLine($"{tierName} wird gepflegt.");

            Gesundheit += 10;
            Zufriedenheit += 5;
        }

        public virtual void Ruhen()
        {
            Console.WriteLine($"{tierName} ruht sich aus.");
            Spielmechanik.Ladebalken(500, 1500);
            Energie = Math.Min(120, Energie + 30);
            Gesundheit += 5;
            Zufriedenheit += 5;
        }

        public virtual void Futtern(int menge)
        {
            Console.WriteLine($"{tierName} frisst.");
            Spielmechanik.Ladebalken(150, 100);
            Hunger = 0;
            Zufriedenheit += menge / 2;
        }
    }
}
