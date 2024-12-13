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
          Spielmechanik.ZentrierteAusgabe($"Allo ! Ich bin {tierName} dein Papagei");
            Console.ReadKey();
        }
        public override string[] Aktivitaten()
        {
            return ["  Spazieren  ", "  Streicheln ", "   Spielen   ", "  Trainieren ", "   Hygiene   ", "zurück"];
        }
        public override void Spazieren()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} fliegt eine Runde um dich herum");
            Console.ReadKey();
            Energie -= 15;
            Zufriedenheit += 5;
        }
        public  void Singen()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} singt ein schönes Lied.");
            Console.ReadKey();
            Energie -= 10;
            Zufriedenheit += 15;
        }
        public override void Trainieren()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} trainiert.");
            Spielmechanik.Ladebalken(175, 175);
            Energie -= 15;
            Zufriedenheit += 10;
            Hunger += 10;
        }

        public override void Hygiene()
        {   
            Spielmechanik.ZentrierteAusgabe($"{tierName} wird gepflegt.");

            Gesundheit += 10;
            Zufriedenheit += 5;
        }

        public override void Ruhen()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} ruht sich aus.");
            Spielmechanik.Ladebalken(500, 1500);
            Energie = Math.Min(120, Energie + 30);
            Gesundheit += 5;
            Zufriedenheit += 5;
        }

        public override void Futtern(int menge)
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} frisst.");
            Spielmechanik.Ladebalken(150, 100);
        }
    }
}
