using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Maus : Haustier
    {
        public Maus(string tierName) : base(tierName) { }
    
            public override void sagHallo()
        {
            Spielmechanik.ZentrierteAusgabe($"Pipps! Ich bin {tierName} deine kleine Süße Maus");
        }
        public override string[] Aktivitaten()
        {
            return ["  Spazieren  ", "  Streicheln ", "   Spielen   ", "  Trainieren ", "   Hygiene   ", "zurück"];
        }
        public void klettern()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} klettert an dir hoch.");
            Energie -= 15;
            Zufriedenheit += 5;
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
            Hunger = 0;
            Zufriedenheit += menge / 2;
        }
    }
}
