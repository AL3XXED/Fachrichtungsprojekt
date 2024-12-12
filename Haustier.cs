using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Haustier
    {
        public string tierName { get; set; }
        public int Gesundheit { get; set; }
        public int Hunger { get; set; }
        public int Energie { get; set; }
        public int Zufriedenheit { get; set; }

        public Haustier(string name)
        {
            this.tierName = name;
            this.Gesundheit = 100;
            this.Hunger = 10;
            this.Energie = 80;
            this.Zufriedenheit = 50;
        }
        public virtual void sagHallo()
        {
            Console.WriteLine($"Hallo, ich bin {tierName}!\nDein neuer Besterfreund <3");
        }

        public virtual void Spielen()
        {
            Console.WriteLine($"{tierName} spielt.");
            Spielmechanik.Ladebalken(100, 100);
            Energie -= 10;
            Zufriedenheit += 15;
        }
        public virtual void Spazieren()
        {
            Console.WriteLine($"{tierName} geht spazieren.");
            Spielmechanik.Ladebalken(175, 175);
            Energie -= 10;
            Zufriedenheit += 15;
            Hunger += 10;
        }
        public virtual void Streicheln()
        {
            Console.WriteLine($"{tierName} wird gestreichelt.");
            Spielmechanik.Ladebalken(175, 175);
            Zufriedenheit += 10;
            Energie -= 5;
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
