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

        public override string[] Aktivitaten()
        {
            return ["  Welt erkunden  ", "  Streicheln ", "   Hindernispacour   ", "  Tricks lernen ", "   Hygiene   ", "zurück"];
        }
        public override void sagHallo()
        {
            Spielmechanik.ZentrierteAusgabe($"Pipps! Ich bin {tierName} deine kleine Süße Maus.");
        }
        public override void Spielen()
        {
            if (Bedingungen.HatGenugEnergie(5))
            {
                Console.Clear();
                ZeigeTier();
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{spielerName} hat ein Hindernisparcour für {tierName} gebaut.");
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{tierName} freut sich und rennt durch den Parkour <3"); ;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Spielmechanik.ZentrierteAusgabe(" Energie -5   ~   Hunger +2   ~   Zufriedenheit +3");
                Console.ResetColor();
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
                Spielmechanik.ZentrierteAusgabe($"{tierName} sitzt auf deiner Schulter wärend du spazieren gehst.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Spielmechanik.ZentrierteAusgabe("Energie -15   ~   Hunger +10   ~   Zufriedenheit +3");
                Console.ResetColor();
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
            Spielmechanik.ZentrierteAusgabe($"{tierName} wird von {spielerName} gestreichelt.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Spielmechanik.ZentrierteAusgabe("Energie +5   ~   Zufriedenheit +5");
            Console.ResetColor();
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
                Spielmechanik.ZentrierteAusgabe($"{spielerName} nutzt ein Klicker um {tierName} Kommandos bei zu bringen.");
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{tierName} freut sich und lernt fleißig <3");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Spielmechanik.ZentrierteAusgabe("Energie -15   ~   Hunger +10   ~   Zufriedenheit +5");
                Console.ResetColor();
                Spielmechanik.Ladebalken(175, 175);
                Bedingungen.VerbrauchEnergie(15);
                Bedingungen.ErhoeheZufriedenheit(5);
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
            Spielmechanik.ZentrierteAusgabe($"{spielerName} wäscht{tierName} vorsichtig und trocknet ihn ab.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Spielmechanik.ZentrierteAusgabe("Gesundheit +10   ~   Zufriedenheit +5");
            Console.ResetColor();
            Bedingungen.ErhoeheZufriedenheit(5);
            Bedingungen.ErhoeheGesundheit(10);
            Bedingungen.AktualisiereStatus();
        }

        public override void Ruhen()
        {
            Console.Clear();
            ZeigeTier();
            Console.WriteLine();
            Spielmechanik.ZentrierteAusgabe($"{tierName} ruht sich in seinem Käfig aus.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Spielmechanik.ZentrierteAusgabe("Gesundheit +10   ~   Zufriedenheit +5");
            Console.ResetColor();
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
            Spielmechanik.MyIMG("maus2.png");
        }
    }
}
