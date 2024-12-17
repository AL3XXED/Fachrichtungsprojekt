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
        public virtual void Spielen()
        {
            if (Bedingungen.HatGenugEnergie(5))
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} spielt.");
                Spielmechanik.Ladebalken(100, 100);
                Bedingungen.VerbrauchEnergie(5);
                Bedingungen.ErhoeheZufriedenheit(3);
                Bedingungen.ErhoeheHunger(2);
                Bedingungen.AktualisiereStatus();
            }
            else
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} hat nicht mehr genug Energie ({Energie})!");
            }
        }
        public virtual void Spazieren()
        {
            if (Bedingungen.HatGenugEnergie(15))
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} geht spazieren.");
                Spielmechanik.Ladebalken(175, 175);
                Bedingungen.VerbrauchEnergie(15);
                Bedingungen.ErhoeheZufriedenheit(3);
                Bedingungen.ErhoeheHunger(10);
                Bedingungen.AktualisiereStatus();
            }
            else
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} hat nicht mehr genug Energie ({Energie})!");
            }
        }
        public virtual void Streicheln()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} wird gestreichelt.");
            Spielmechanik.Ladebalken(175, 175);
            Bedingungen.ErhoeheZufriedenheit(5);
            Bedingungen.ErhoeheEnergie(5);
            Bedingungen.AktualisiereStatus();
        }

        public virtual void Trainieren()
        {
            if (Bedingungen.HatGenugEnergie(15))
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} trainiert.");
                Spielmechanik.Ladebalken(175, 175);
                Bedingungen.VerbrauchEnergie(15);
                Bedingungen.ErhoeheZufriedenheit(2);
                Bedingungen.ErhoeheHunger(10);
                Bedingungen.AktualisiereStatus();
            }
            else
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} hat nicht mehr genug Energie ({Energie})!");
            }
        }

        public virtual void Hygiene()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} wird gepflegt.");
            Bedingungen.ErhoeheZufriedenheit(5);
            if (Gesundheit < Gesundheitmax && Gesundheit >= 75)
            {
                Bedingungen.ErhoeheGesundheit(10);
            }
            Bedingungen.AktualisiereStatus();
        }

        public virtual void Ruhen()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} ruht sich aus.");
            Spielmechanik.Ladebalken(500, 1500);
            Bedingungen.ErhoeheEnergie(30);
            Bedingungen.ErhoeheHunger(20);
            if (Gesundheit <= Energiemax)
            {
                Bedingungen.ErhoeheGesundheit(5);
            }
            Bedingungen.ErhoeheZufriedenheit(5);
            Bedingungen.AktualisiereStatus();
        }

        public virtual void Futtern(int menge)
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} frisst.");
            Spielmechanik.Ladebalken(150, 100);
            Bedingungen.VerringereHunger(menge);
            Bedingungen.AktualisiereStatus();
        }

        public bool IstAmLeben()
        {
            return !Bedingungen.GameOver;
        }
    }
}