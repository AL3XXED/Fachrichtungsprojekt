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
            Spielmechanik.ZentrierteAusgabe($"Wuff! Ich bin {tierName} dein neuer Freund .");
        }
        public override string[] Aktivitaten()
        {
            return ["  Gassi  ", "  Streicheln ", "   Ball werfen   ", "  Trainieren ", "   Hygiene   ", "zurück"];
        }

        public override void Spielen()
        {
            if (Bedingungen.HatGenugEnergie(5))
            {
                Console.Clear();
                ZeigeTier();
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{spielerName} wirft ein Ball und {tierName} holt ihn voller Freude .");
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
                Console.ReadKey();
            }
        }
        public override void Spazieren()
        {
            if (Bedingungen.HatGenugEnergie(15))
            {
                Console.Clear();
                ZeigeTier();
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{spielerName} geht mit {tierName} eine Runde Gassi.");
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
            Spielmechanik.ZentrierteAusgabe($"{spielerName} streichelt {tierName} Liebevoll.");
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
                Spielmechanik.ZentrierteAusgabe($"{spielerName} trainiert mit {tierName} im Park.");
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
            Spielmechanik.ZentrierteAusgabe($"{spielerName} wäscht {tierName} und pflegt ihn.");
            Console.WriteLine();
            Spielmechanik.ZentrierteAusgabe($"{tierName} freut sich sehr das {spielerName} ihn umsorgt <3");
            Bedingungen.ErhoeheZufriedenheit(5);
            Bedingungen.ErhoeheGesundheit(10);
            Bedingungen.AktualisiereStatus();
        }

        public override void Ruhen()
        {
            Console.Clear();
            ZeigeTier();
            Console.WriteLine();
            Spielmechanik.ZentrierteAusgabe($"{tierName} schläft eine Runde in seinem Körbchen.");
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
            Spielmechanik.MyIMG("hund2.png");
        }
    }
}
