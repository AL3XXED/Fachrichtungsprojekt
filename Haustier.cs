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
        public int Level { get; set; }
        public int Gesundheit { get; set; }
        public int Hunger { get; set; }
        public int Energie { get; set; }
        public int Zufriedenheit { get; set; }

        public int Levelmax { get; set; }
        public int Gesundheitmax {  get; set; }
        public int Hungermax { get; set; }
        public int Energiemax { get; set; }
        public int Zufriedenheitmax { get; set; }

        public Haustier(string name)
        {
            this.tierName = name;
            this.Level = 0;
            this.Gesundheit = 100;
            this.Hunger = 10;
            this.Energie = 80;
            this.Zufriedenheit = 25;

            this.Levelmax = 25;                 //Tod oder Maxlevel
            this.Gesundheitmax = 100;           //Lvl+ = +10
            this.Hungermax = 75;                //Lvl+ = +5
            this.Energiemax = 80;               //Lvl+ = +10
            this.Zufriedenheitmax = 100;        //Lvl+ = Standart 25 -> Fungiert als EP
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
            if (Energie < Energiemax && Energie >= 5)
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} spielt.");
                Spielmechanik.Ladebalken(100, 100);
                Energie -= 5;
                Zufriedenheit += 3;
            }
            else
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} hat nicht mehr genug Energie ({Energie}) !");
            }
        }
        public virtual void Spazieren()
        {
            if (Energie < Energiemax && Energie >= 15)
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} geht spazieren.");
                Spielmechanik.Ladebalken(175, 175);
                Energie -= 15;
                Zufriedenheit += 3;
                Hunger += 10;
            }
            else
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} hat nicht mehr genug Energie ({Energie}) !");
            }
        }
        public virtual void Streicheln()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} wird gestreichelt.");
            Spielmechanik.Ladebalken(175, 175);
            Zufriedenheit += 5;
            Energie += 5;
        }

        public virtual void Trainieren()
        {
            if (Energie < Energiemax && Energie >= 15)
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} trainiert.");
                Spielmechanik.Ladebalken(175, 175);
                Energie -= 15;
                Zufriedenheit += 2;
                Hunger += 10;
            }
            else
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} hat nicht mehr genug Energie ({Energie}) !");
            }
        }

        public virtual void Hygiene()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} wird gepflegt.");
            Zufriedenheit += 5;
            if (Gesundheit < Gesundheitmax && Gesundheit >= 75)
            {
                Gesundheit += 10;
            }
        }

        public virtual void Ruhen()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} ruht sich aus.");
            Spielmechanik.Ladebalken(500, 1500);
            if (Energie <= Energiemax) { Energie += 30; Hunger += 20; }
            else if (Gesundheit <= Energiemax) { Gesundheit += 5; }
            Zufriedenheit += 5;
        }

        public virtual void Futtern(int menge)
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} frisst.");
            Spielmechanik.Ladebalken(150, 100);
        }




    }
}
