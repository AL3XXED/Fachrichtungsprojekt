﻿using System;
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
            Spielmechanik.ZentrierteAusgabe($"Allo ! Ich bin {tierName} dein gefiederter Freund.");
            Console.ReadKey();
        }
        public override string[] Aktivitaten()
        {
            return ["  Spazieren  ", "  Streicheln ", "   Spielen   ", "  Trainieren ", "   Hygiene   ", "zurück"];
        }
        public override void Spielen()
        {
            if (Bedingungen.HatGenugEnergie(5))
            {
                Console.Clear();
                ZeigeTier();
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{tierName} spielt.");
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
                Spielmechanik.ZentrierteAusgabe($"{spielerName} geht raus und {tierName} fliegt um ihn herum.");
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
                Spielmechanik.ZentrierteAusgabe($"{spielerName} hat Ringe aufgehängt und {tierName} fliegt im slalom durch die Ringe.");
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
            Spielmechanik.ZentrierteAusgabe($"{tierName} wird gepflegt.");
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
            Spielmechanik.ZentrierteAusgabe($"{tierName} frisst in Ruhe und Freut sich.");
            Spielmechanik.Ladebalken(150, 100);
            Bedingungen.VerringereHunger(menge);
            Bedingungen.AktualisiereStatus();
        }
        public override void ZeigeTier()
        {
            Spielmechanik.MyIMG("vogel2.png");
        }
    }
}
