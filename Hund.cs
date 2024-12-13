using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Hund : Haustier
    {
        public Hund(string tierName) : base(tierName) { }

        public override void sagHallo()
        {
            Spielmechanik.ZentrierteAusgabe($"Wuff! Ich bin {tierName} dein neuer Freund");
        }
        public override string[] Aktivitaten()
        {
            return ["  Gassi gehen  ", "  Streicheln ", "   Spielen   ", "  Trainieren ", "   Hygiene   ", "zurück"];
        }
        public override void Spazieren()
        {
            Spielmechanik.ZentrierteAusgabe($"Du gehst mit {tierName} eine Runde im Wald Spazieren");
            Energie -= 20;
            Hunger += 20;

        }
        public void Apportieren()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} holt den geworfenen Ball");
            Energie -= 15;
            Zufriedenheit += 5;
        }
        public void Bellen()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} bellt laut: Wuff! Wuff!");
            Energie -= 5;
        }
        public override void Spielen()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} spielt am Kratzbaum");
            Energie -= 15;
            Zufriedenheit += 5;
        }
        public override void Streicheln()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} schnurrt zufrieden.");
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
