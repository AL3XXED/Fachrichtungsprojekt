using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Haustier_Tamagotchi
{
    internal class Bedingungen
    {
        public static Haustier meinTier = Menüführung.meinTier;

        public static int Absicherung(int wert, int min, int max)       //Absicherungs-Methode das Werte nicht unter 0 oder über Max gehen
        {
            return Math.Clamp(wert, min, max);                          //Math.Clamp um Werte im definierten bereich zu halten
        }                                       //Wert kleiner als 0 = 0, Wert größer als Max = Max 
                                                //Werte können den vordefinierten Bereich nicht Über,-Unterschreiten

        public static void Energiegrenze(int status)                    //Verwendung der Absicherung in Methode für Energie
        {
            meinTier.Energie = Absicherung(status, 0, meinTier.Energiemax); //min= 0 , Max = Vordefinierter Wert aus Haustier
        }

        public static void Gesundheitgrenze(int status)                 //Verwendung der Absicherung in Methode für Gesundheit
        {
            meinTier.Gesundheit = Absicherung(status, 0, meinTier.Gesundheitmax);   //min= 0 , Max = Vordefinierter Wert aus Haustier
            if (meinTier.Gesundheit == 0)
            {
                Sterben();                                              //Ist die Gesundheit bei 0 wird die Sterben-Methode aufgerufen
            }
        }

        public static void Hungergrenze(int status)                     //Verwendung der Absicherung in Methode für Hunger mit verweiß auf 
        {
            meinTier.Hunger = Absicherung(status, 0, meinTier.Hungermax);   //min= 0 , Max = Vordefinierter Wert aus Haustier   
        }

        public static void Zufriedenheitgrenze(int status)              //Methode mit Absicherung und verweiß auf Level-Up-Methode
        {
            meinTier.Zufriedenheit = Absicherung(status, 25, meinTier.Zufriedenheitmax);  //min= 25 (startwert) , Max = Vordefinierter Wert aus Haustier
        }

        public static void VerbrauchEnergie(int menge)                  //Methode verweißt auf Energiegrenze-Methode in der die Absicherung drin ist
        {
            Energiegrenze(meinTier.Energie - menge);
        }

        public static void ErhoeheZufriedenheit(int menge)              //Methode verweißt auf Zufriedenheitsgrenze-Methode in der die Absicherung drin ist
        {
            Zufriedenheitgrenze(meinTier.Zufriedenheit + menge);        //Zufriedenheit wird als EP-Wert genutzt 
            if (meinTier.Zufriedenheit == meinTier.Zufriedenheitmax)
            {
                LevelAufstieg();                                        //Verweiß auf LevelAufstiegt-Methode
            }
        }

        public static void ErhoeheHunger(int menge)                     //Methode verweißt auf Hungergrenze-Methode in der die Absicherung drin ist
        {
            Hungergrenze(meinTier.Hunger + menge);
        }

        public static void ErhoeheEnergie(int menge)                    //Methode verweißt auf Energiegrenze-Methode in der die Absicherung drin ist
        {
            Energiegrenze(meinTier.Energie + menge);
        }

        public static void ErhoeheGesundheit(int menge)                 //Methode verweißt auf Gesundheitgrenze-Methode in der die Absicherung drin ist
        {
            Gesundheitgrenze(meinTier.Gesundheit + menge);
        }

        public static void VerringereHunger(int menge)                  //Methode verweißt auf Hungergrenze-Methode in der die Absicherung drin ist
        {
            Hungergrenze(meinTier.Hunger - menge);
        }

        public static void LevelAufstieg()                              //Level-Up Methode die Zufriedenheit als Bedingungswert nutzt
        {
            if (meinTier.Level < meinTier.Levelmax)                     //Aussteigen bis in Haustier definirter Maximalwert -> 25
            {
                meinTier.Level++;                                       //Bei jedem Levelaufstiegt werden drei Werte erhöht
                meinTier.Gesundheitmax += 10;
                meinTier.Hungermax += 5;
                meinTier.Energiemax += 10;
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("\t\t\t\t\t __                _    _____     \r\n\t\t\t\t\t|  |   ___ _ _ ___| |  |  |  |___ \r\n\t\t\t\t\t|  |__| -_| | | -_| |  |  |  | . |\r\n\t\t\t\t\t|_____|___|\\_/|___|_|  |_____|  _|\r\n\t\t\t\t\t                             |_|  \r\n");
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"Gratulation! {meinTier.tierName} ist aufgestiegen!");
                Console.WriteLine();
                Spielmechanik.ZentrierteAusgabe($"{meinTier.tierName} ist jetzt auf Level {meinTier.Level}.");
            }
        }

        public static void Sterben()                                    //Sterben-Methode die Aufgerufen wird wenn Gesundheit bei 0 ist
        {
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("\r\n\t\t\t\t   _____                         ____                 \r\n\t\t\t\t  / ____|                       / __ \\                \r\n\t\t\t\t | |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ \r\n\t\t\t\t | | |_ |/ _` | '_ ` _ \\ / _ \\ | |  | \\ \\ / / _ \\ '__|\r\n \t\t\t\t | |__| | (_| | | | | | |  __/ | |__| |\\ V /  __/ |   \r\n\t\t\t\t  \\_____|\\__,_|_| |_| |_|\\___|  \\____/  \\_/ \\___|_|   ");
            Console.WriteLine();
            Spielmechanik.ZentrierteAusgabe($"{meinTier.tierName} ist verhungert und gestorben!");
            Thread.Sleep(3000);
            return;
        }

        public static void AktualisiereStatus()                         //Nach jeder Aktion wird diese Methode aufgerufen um Level-Up
        {                                                               //oder Sterben überprüft
            PruefeHunger();
            PruefeZufriedenheit();
            Gesundheitgrenze(meinTier.Gesundheit);
            Energiegrenze(meinTier.Energie);
        }

        public static void PruefeHunger()                               //Methode um bei gewissem Hunger Gesundheit abzuziehen
        {
            if (meinTier.Hunger >= meinTier.Hungermax - 25)
            {
                meinTier.Gesundheit -= 10;                              //Da Maximaler Hunger beim Levelup erhöht wird                                 
                                                                        //habe ich mich so auf die Wertgrenze bezogen
                if (meinTier.Hunger >= meinTier.Hungermax - 10)
                {
                    meinTier.Gesundheit -= 25;
                    if (meinTier.Hunger == meinTier.Hungermax)          //Warnmeldung wenn Maximaler Hunger erreicht ist
                    {                                                   //Wird nach jeder Aktion gezeigt wenn Hunger bei Max ist
                        Console.Clear();
                        Console.SetCursorPosition(0, 8);
                        Console.WriteLine("\t\t\t\t\t               _     _                     \r\n\t\t\t\t\t     /\\       | |   | |                    \r\n\t\t\t\t\t    /  \\   ___| |__ | |_ _   _ _ __   __ _ \r\n\t\t\t\t\t   / /\\ \\ / __| '_ \\| __| | | | '_ \\ / _` |\r\n\t\t\t\t\t  / ____ \\ (__| | | | |_| |_| | | | | (_| |\r\n\t\t\t\t\t /_/    \\_\\___|_| |_|\\__|\\__,_|_| |_|\\__, |\r\n\t\t\t\t\t                                      __/ |\r\n\t\t\t\t\t                                     |___/ ");
                        Console.SetCursorPosition(0, 18);
                        Spielmechanik.ZentrierteAusgabe($"{meinTier.tierName} ist ausgehungert !");
                        Spielmechanik.ZentrierteAusgabe($"Gib {meinTier.tierName} etwas zu Essen bevor es Stierbt !");
                        Console.ReadKey();
                    }
                }
            }
        }

        public static void PruefeZufriedenheit()                        //Methode zum Überprüfen auf ein Levelup welche in 
        {                                                               //Methode Aktualisiere aufgerufen wird
            if (meinTier.Zufriedenheit >= meinTier.Zufriedenheitmax)
            {
                LevelAufstieg();                                        //Levelup Überprüfung ebenfalls in Zufriedenheitsgrenze
            }                                                           //Schlimm wenn es doppelt geprüft wird ?
        }

        public static bool HatGenugEnergie(int benoetigteEnergie)       //Bollean der in den Methoden der Kindklasse vor Aktionen abgefragt wird
        {                                                               //Entscheidet welche Ausgabe angezeigt wird
            return meinTier.Energie >= benoetigteEnergie;
        }
    }
}
