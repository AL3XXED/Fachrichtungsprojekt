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
        public override void Spielen()
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
        public override void Spazieren()
        {
            if (Bedingungen.HatGenugEnergie(15))
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} sitzt auf deiner Schulter wärend du spazieren gehst.");
                Spielmechanik.Ladebalken(175, 175);
                Bedingungen.VerbrauchEnergie(15);
                Bedingungen.ErhoeheZufriedenheit(3);
                Bedingungen.ErhoeheHunger(10);
                Bedingungen.AktualisiereStatus();
            }
            else
            {
                Spielmechanik.ZentrierteAusgabe($"{tierName} hat nicht mehr genug Energie ({Energie})!");
                Console.ReadKey();
            }
        }
        public override void Streicheln()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} wird gestreichelt.");
            Spielmechanik.Ladebalken(175, 175);
            Bedingungen.ErhoeheZufriedenheit(5);
            Bedingungen.ErhoeheEnergie(5);
            Bedingungen.AktualisiereStatus();
        }

        public override void Trainieren()
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
                Console.ReadKey();
            }
        }

        public override void Hygiene()
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} wird gepflegt.");
            Bedingungen.ErhoeheZufriedenheit(5);
            if (Gesundheit < Gesundheitmax && Gesundheit >= 75)
            {
                Bedingungen.ErhoeheGesundheit(10);
            }
            Bedingungen.AktualisiereStatus();
        }

        public override void Ruhen()
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

        public override void Futtern(int menge)
        {
            Spielmechanik.ZentrierteAusgabe($"{tierName} frisst.");
            Spielmechanik.Ladebalken(150, 100);
            Bedingungen.VerringereHunger(menge);
            Bedingungen.AktualisiereStatus();
        }
    }
}
