using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    public class Haustier
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
        public virtual string[] Aktivitaten()
        {
            return ["  Spazieren  ", "  Streicheln ", "   Spielen   ", "  Trainieren ", "   Hygiene   ", "zurück"];
        }
        public virtual void sagHallo()
        {
            Spielmechanik.ZentrierteAusgabe($"Hallo, ich bin {tierName}!\nDein neuer Besterfreund <3");
        }

        public virtual void Spezial()
        {

        }

        public virtual void Spielen()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} spielt.");
            Spielmechanik.Ladebalken(100, 100);
            Energie -= 10;
            Zufriedenheit += 15;
        }
        public virtual void Spazieren()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} geht spazieren.");
            Spielmechanik.Ladebalken(175, 175);
            Energie -= 10;
            Zufriedenheit += 15;
            Hunger += 10;
        }
        public virtual void Streicheln()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} wird gestreichelt.");
            Spielmechanik.Ladebalken(175, 175);
            Zufriedenheit += 10;
            Energie -= 5;
        }

        public virtual void Trainieren()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} trainiert.");
            Spielmechanik.Ladebalken(175, 175);
            Energie -= 15;
            Zufriedenheit += 10;
            Hunger += 10;
        }

        public virtual void Hygiene()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} wird gepflegt.");

            Gesundheit += 10;
            Zufriedenheit += 5;
        }

        public virtual void Ruhen()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} ruht sich aus.");
            Spielmechanik.Ladebalken(500, 1500);
            Energie += 30;
            Gesundheit += 5;
            Zufriedenheit += 5;
        }

        public virtual void Futtern(int menge)
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} frisst.");
            Spielmechanik.Ladebalken(150, 100);
            Hunger = 0;
            Zufriedenheit += menge / 2;
        }




    }
}
