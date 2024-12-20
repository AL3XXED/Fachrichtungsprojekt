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
        public static string spielerName { get; set; }
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
        public virtual void Spielen()                       //Virual-Methode spielen welche in Kindklassen individuel überschrieben wird
        {
            if (Bedingungen.HatGenugEnergie(5))
            {
                Console.Clear();
                ZeigeTier();
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{tierName} spielt.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Spielmechanik.ZentrierteAusgabe("Energie -5 , Hunger +2 , Zufriedenheit +3");
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
        public virtual void Spazieren()                         //Virual-Methode Spazieren welche ebenfalls individuel in Kindklassen überschrieben wird
        {
            if (Bedingungen.HatGenugEnergie(15))                //Abfrage durch Methode aus Klasse Bedingungen
            {
                Console.Clear();
                ZeigeTier();
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{tierName} geht spazieren.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Spielmechanik.ZentrierteAusgabe("Energie -15 ~ Hunger +10 ~ Zufriedenheit +3");
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
            }
        }
        public virtual void Streicheln()
        {
            Console.Clear();
            ZeigeTier();
            Console.WriteLine();
            Spielmechanik.ZentrierteAusgabe($"{tierName} wird gestreichelt.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Spielmechanik.ZentrierteAusgabe("Energie +5 ~ Zufriedenheit +5");
            Console.ResetColor();
            Spielmechanik.Ladebalken(175, 175);
            Bedingungen.ErhoeheZufriedenheit(5);
            Bedingungen.ErhoeheEnergie(5);
            Bedingungen.AktualisiereStatus();
        }

        public virtual void Trainieren()
        {
            if (Bedingungen.HatGenugEnergie(15))
            {
                Console.Clear();
                ZeigeTier();
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{tierName} trainiert.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Spielmechanik.ZentrierteAusgabe("Energie -15 ~ Hunger +10 ~ Zufriedenheit +5");
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
                Console.WriteLine(); ;
                Spielmechanik.ZentrierteAusgabe($"{tierName} hat nicht mehr genug Energie ({Energie})!");
            }
        }

        public virtual void Hygiene()
        {
            Console.Clear();
            ZeigeTier();
            Console.WriteLine();
            Spielmechanik.ZentrierteAusgabe($"{tierName} wird gepflegt.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Spielmechanik.ZentrierteAusgabe("Gesundheit +10 ~ Zufriedenheit + 5");
            Console.ResetColor();
            Bedingungen.ErhoeheZufriedenheit(5);
            Bedingungen.ErhoeheGesundheit(10);
            Bedingungen.AktualisiereStatus();
        }

        public virtual void Ruhen()
        {
            Console.Clear();
            ZeigeTier();
            Console.WriteLine();
            Spielmechanik.ZentrierteAusgabe($"{tierName} ruht sich aus.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Spielmechanik.ZentrierteAusgabe("Gesundheit +10 ~ Zufriedenheit + 5");
            Console.ResetColor();
            Spielmechanik.Ladebalken(500, 1500);
            Bedingungen.ErhoeheEnergie(30);
            Bedingungen.ErhoeheHunger(20);
            Bedingungen.ErhoeheGesundheit(5);
            Bedingungen.ErhoeheZufriedenheit(5);
            Bedingungen.AktualisiereStatus();
        }

        public virtual void Futtern(int menge)                  //int menge in Menüführung.Essenmenu deklariert
        {
            Console.Clear();
            ZeigeTier();
            Console.WriteLine();
            Spielmechanik.ZentrierteAusgabe($"{tierName} frisst in Ruhe und Freut sich.");
            Spielmechanik.Ladebalken(150, 100);
            Bedingungen.VerringereHunger(menge);
            Bedingungen.AktualisiereStatus();
        }

        public virtual void ZeigeTier()
        {
            Spielmechanik.MyIMG("bild");
        }
    }
}