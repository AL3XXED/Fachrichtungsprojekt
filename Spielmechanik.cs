using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Haustier_Tamagotchi
{
    internal class Spielmechanik
    {
        private Haustier meinTier;
        private string[] haustiertypAuswahl = { "Hund", "Katze", "Maus", "Vogel" };
        private int auswahlIndex = 0;
        private string tierName;
        public static string text = " ";
        public static string uberschrift = (" \t\t  _______ _               _______                                _       _     _ \r\n\t\t |__   __(_)             |__   __|                              | |     | |   (_)\r\n\t\t    | |   _  ___ _ __ ______| | __ _ _ __ ___   __ _  __ _  ___ | |_ ___| |__  _ \r\n\t\t    | |  | |/ _ \\ '__|______| |/ _` | '_ ` _ \\ / _` |/ _` |/ _ \\| __/ __| '_ \\| |\r\n\t\t    | |  | |  __/ |         | | (_| | | | | | | (_| | (_| | (_) | || (__| | | | |\r\n\t\t    |_|  |_|\\___|_|         |_|\\__,_|_| |_| |_|\\__,_|\\__, |\\___/ \\__\\___|_| |_|_|\r\n                         \t\t                              __/ |                      \r\n                                  \t\t                     |___/                       \r\n========================================================================================================================");

        internal Haustier MeinTier { get => meinTier; set => meinTier = value; }
        public string TierName { get => tierName; set => tierName = value; }

        public void Begruessung()
        {
           Console.WriteLine(Spielmechanik.uberschrift);
            text = "Bitte gib deinen Namen ein:\n";
            Zentriert();
            Console.WriteLine(text);
            Zentriert();
            string spielerName = Console.ReadLine().ToUpper();
            text = $"Hallo {spielerName}! Lass uns dein virtuelles Haustier erstellen.";
            Zentriert();
            Console.Write(text);
            Console.Clear();
        }

        public void ErstelleHaustier()
        {
            int haustierTyp;
            ;
            bool weiter = false;

            do
            {
                Zentriert();
                Spielmechanik.text = "Wähle dein Haustier aus:\n";
                Zentriert();
                haustierTyp = NavigationsMenu(haustiertypAuswahl);
                Console.Clear();
                Zentriert();
                text = $"Du hast {haustiertypAuswahl[haustierTyp]} gewählt.";
                Console.WriteLine(text);
                Zentriert();
                text = "Wie soll dein Haustier heißen?:";
                Console.WriteLine(text);
                tierName = Console.ReadLine().Trim();

                text = $"Du möchtest also ein(e/en) {haustiertypAuswahl[haustierTyp]} namens {tierName}. Ist das korrekt? ";
                Zentriert();    
                Console.WriteLine(text);
                string[] bestatigungmenuAuswahl = { "             Ja              ", "Nein, ich möchte etwas ändern" };
                Spielmechanik.text = "Bestätige deine Auswahl:\n";
                int bestatigungsAuswahl = NavigationsMenu(bestatigungmenuAuswahl);

                weiter = (bestatigungsAuswahl == 0);
            } while (!weiter);

            switch (haustierTyp)
            {
                case 0:
                    meinTier = new Hund(tierName);
                    break;

                case 1:
                    meinTier = new Katze(tierName);
                    break;

                case 2:
                    meinTier = new Maus(tierName);
                    break;

                case 3:
                    meinTier = new Vogel(tierName);
                    break;
            }
            Console.Clear();
            Zentriert();
            text = $"Großartig! Dein neues Haustier ist ein(e) {haustiertypAuswahl[haustierTyp]} namens {tierName}.\n";
            Console.WriteLine(text);
            Zentriert();
            meinTier.sagHallo();
            text = "Drücke eine beliebige Taste um fortzufahren ...";
            Console.WriteLine(text);
            Console.ReadKey();
        }
        private int NavigationsMenu(string[] menuItems)         //Fügt die benutzung der Pfeiltasten in der Menüausgabe ein
        {
            auswahlIndex = 0;
            while (true)
            {
                DisplayMenu(menuItems);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        auswahlIndex = (auswahlIndex - 1 + menuItems.Length) % menuItems.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        auswahlIndex = (auswahlIndex + 1) % menuItems.Length;
                        break;
                    case ConsoleKey.Enter:
                        return auswahlIndex;
                }
            }
        }

        private void DisplayMenu(string[] menuItems)   //Setzt das aktuell gewälte in > < zur optischen Übersicht
        {
            Console.Clear();
            Console.WriteLine(Spielmechanik.uberschrift);
            Zentriert();
            Console.WriteLine(Spielmechanik.text);
            for (int i = 0; i < menuItems.Length; i++)
            {
                Zentriert();
                if (i == auswahlIndex)
                {
                    Console.WriteLine($"> {menuItems[i]} <");
                }
                else
                {
                    Console.WriteLine($"  {menuItems[i]} ");
                }

            }
        }
        public void Hauptmenu()
        {
            Console.WriteLine(Spielmechanik.uberschrift);
            Zentriert();
            Spielmechanik.text = "~ Hauptmenü ~\n";
            string[] hauptmenuAnzeige = { "Aktivitäten", "Essen", "Ruhe", "Status", "Beenden" };
            while (true)
            {
                Zentriert();
                int auswahl = NavigationsMenu(hauptmenuAnzeige);
                switch (auswahl)
                {
                    case 0:                             // Aktivitäten
                        AktivitatenMenu();
                        break;
                    case 1:                             // Essen
                        EssenMenu();
                        break;
                    case 2:                             // Ruhe
                        meinTier.Ruhen();
                        break;
                    case 3:                            // Status
                        Statusmenu();
                        break;
                    case 4:                            // Beenden
                        return;
                }
            }
        }

        private void AktivitatenMenu()
        {
            Console.WriteLine(Spielmechanik.uberschrift);
            Zentriert();
            string[] aktivitatsmenuAnzeige = { "Spazieren", "Streicheln", "Spielen", "Trainieren", "Hygiene", "zurück" };
            Spielmechanik.text = "~ Aktivitätsmenü ~";
            int auswahl = NavigationsMenu(aktivitatsmenuAnzeige);
            switch (auswahl)
            {
                case 0:                         // Spazieren
                    meinTier.Spazieren();
                    break;
                case 1:                         // Streicheln
                    meinTier.Streicheln();
                    break;
                case 2:                         // Spielen
                    meinTier.Spielen();
                    break;
                case 3:                         // Trainieren
                    meinTier.Trainieren();
                    break;
                case 4:                         // Hygiene
                    meinTier.Hygiene();
                    break;
                case 5:                         // Zurück
                    return;
            }

        }
        private void EssenMenu()
        {
            Console.WriteLine(Spielmechanik.uberschrift);
            Zentriert();
            string[] essenmenuAnzeige = { "Leckerli", "Snack", "Mahlzeit", "zurück" };
            Spielmechanik.text = "~ Essensmenü ~";
            int auswahl = NavigationsMenu(essenmenuAnzeige);
            switch (auswahl)
            {
                case 0:                     //Leckerli
                    meinTier.Futtern(10);
                    break;

                case 1:                     //Snack
                    meinTier.Futtern(25);
                    break;

                case 2:                     //Mahlzeit
                    meinTier.Futtern(50);
                    break;
                case 3:
                    return;
            }
        }
        private void Statusmenu()
        {
            Console.WriteLine(Spielmechanik.uberschrift);
            Zentriert();
            string[] statusmenuAnzeige = { "Status", "Tipps", "zurück" };
            Spielmechanik.text = " ~Statusmenü ~";
            int auswahl = NavigationsMenu(statusmenuAnzeige);
            switch (auswahl)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine($"{meinTier.tierName}'s Status:");
                    Console.WriteLine($"Gesundheit: {meinTier.Gesundheit}\nHunger: {meinTier.Hunger}\nEnergie: {meinTier.Energie}\nZufriedenheit: {meinTier.Zufriedenheit}");
                    Console.ReadKey();
                    return;

                case 1:
                    Console.Clear();
                    Console.WriteLine("<Tipps einfügen>");                      //String-Array mit Tipps erstellen!
                    Console.ReadKey();
                    return;
                case 2:
                    return;
            }

        }
        public static void Ladebalken(int schritte, int dauer)
        {
            int breite = Console.WindowWidth - 70;
            int positionUnten = Console.WindowHeight - 2;

            Console.CursorVisible = false;
            Console.SetCursorPosition(32, positionUnten);
            for (int i = 0; i <= schritte; i++)
            {
                Console.SetCursorPosition(32, positionUnten);
                float prozent = (float)i / schritte;
                int fortschritt = (int)(breite * prozent);

                Console.Write("[");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write(new string(' ', fortschritt));
                Console.ResetColor();
                Console.Write(new string(' ', breite - fortschritt));
                Console.Write("]");
                Console.Write($" {(int)(prozent * 100)}%");

                Thread.Sleep(50);
            }
            Console.CursorVisible = true;
            Console.Clear();
        }
        public static void Zentriert()
        {
            int fensterbreite = Console.WindowWidth;
            int startpunkt = (fensterbreite - text.Length) / 2;
            Console.SetCursorPosition(startpunkt, Console.CursorTop);
        }
    }
}
