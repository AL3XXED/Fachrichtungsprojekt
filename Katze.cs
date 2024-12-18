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

        public override string[] Aktivitaten()
        {
            return ["  Erkundungstour  ", "  Streicheln ", "   Laserpointer   ", "  Kratzbaum ", "   Hygiene   ", "zurück"];
        }
        public override void sagHallo()
        {
            Spielmechanik.ZentrierteAusgabe($"Miauu! Ich bin {tierName} die Katze.");
        }
        public override void Spielen()
        {
            if (Bedingungen.HatGenugEnergie(5))
            {
                Console.Clear();
                ZeigeTier();
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{spielerName} benutzt ein Laserpointer und spielt mit {tierName}.");
                Spielmechanik.Ladebalken(100, 100);
                Bedingungen.VerbrauchEnergie(5);
                Bedingungen.ErhoeheZufriedenheit(3);
                Bedingungen.ErhoeheHunger(2);
                Bedingungen.AktualisiereStatus();
            }
            else
            {
                Console.Clear();
                ZeigeTier();
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{tierName} hat nicht mehr genug Energie ({Energie})!");
            }
        }
        public override void Spazieren()
        {
            if (Bedingungen.HatGenugEnergie(15))
            {
                Console.Clear();
                ZeigeTier();
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{spielerName} geht raus in den Garten und {tierName} kommt mit auf Erkundungstour.");
                Spielmechanik.Ladebalken(175, 175);
                Bedingungen.VerbrauchEnergie(15);
                Bedingungen.ErhoeheZufriedenheit(3);
                Bedingungen.ErhoeheHunger(10);
                Bedingungen.AktualisiereStatus();
            }
            else
            {
                Console.Clear();
                ZeigeTier();
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{tierName} hat nicht mehr genug Energie ({Energie})!");
                Console.ReadKey();
            }
        }
        public override void Streicheln()
        {
            Console.Clear();
            ZeigeTier();
            Console.WriteLine();
            Spielmechanik.ZentrierteAusgabe($"{tierName} lässt sich von {spielerName} streicheln und verwöhnen.");
            Console.WriteLine();
            Spielmechanik.ZentrierteAusgabe($"{tierName} schnurrt dabei.");
            Spielmechanik.Ladebalken(175, 175);
            Bedingungen.ErhoeheZufriedenheit(5);
            Bedingungen.ErhoeheEnergie(5);
            Bedingungen.AktualisiereStatus();
        }

        public override void Trainieren()
        {
            if (Bedingungen.HatGenugEnergie(15))
            {
                Console.Clear();
                ZeigeTier();
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{tierName} rennt den Kratzbaum Hoch und Runter.");
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{tierName} hat seine 5 Minuten.");
                Spielmechanik.Ladebalken(175, 175);
                Bedingungen.VerbrauchEnergie(15);
                Bedingungen.ErhoeheZufriedenheit(2);
                Bedingungen.ErhoeheHunger(10);
                Bedingungen.AktualisiereStatus();
            }
            else
            {
                Console.Clear();
                ZeigeTier();
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{tierName} hat nicht mehr genug Energie ({Energie})!");
                Console.ReadKey();
            }
        }

        public override void Hygiene()
        {
            Console.Clear();
            ZeigeTier();
            Console.WriteLine();
            Spielmechanik.ZentrierteAusgabe($"{spielerName} kämmt {tierName} das Fell.");
            Bedingungen.ErhoeheZufriedenheit(5);
            Bedingungen.ErhoeheGesundheit(10);
            Bedingungen.AktualisiereStatus();
        }

        public override void Ruhen()
        {
            Console.Clear();
            ZeigeTier();
            Console.WriteLine();
            Spielmechanik.ZentrierteAusgabe($"{tierName} schläft auf {spielerName}`s Schoß ein.");
            Spielmechanik.Ladebalken(500, 1500);
            Bedingungen.ErhoeheEnergie(30);
            Bedingungen.ErhoeheHunger(20);
            Bedingungen.ErhoeheGesundheit(5);
            Bedingungen.ErhoeheZufriedenheit(5);
            Bedingungen.AktualisiereStatus();
        }

        public override void Futtern(int menge)
        {
            Console.Clear();
            ZeigeTier();
            Console.WriteLine();
            Spielmechanik.ZentrierteAusgabe($"{tierName} frisst in Ruhe was ihm {spielerName} gegeben hat und Freut sich.");
            Spielmechanik.Ladebalken(150, 100);
            Bedingungen.VerringereHunger(menge);
            Bedingungen.AktualisiereStatus();
        }
        public override void ZeigeTier()
        {
            Spielmechanik.MyIMG("katze2.png");
        }
    }
}
