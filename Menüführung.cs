using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Menüführung
    {
        private Haustier meinTier;
        private string[] haustiertypAuswahl = { "Hund", "Katze", "Maus", "Vogel" };
        private int auswahlIndex = 0;
        private string tierName;

        public void ErstelleHaustier()
        {
            int haustierTyp;
            ;
            bool weiter = false;

            do
            {
                Spielmechanik.text = ("Wähle dein Haustier aus:\n");
                haustierTyp = NavigationsMenu(haustiertypAuswahl);
                Console.Clear();
                Spielmechanik.ZentrierteAusgabe($"Du hast {haustiertypAuswahl[haustierTyp]} gewählt.");
                Spielmechanik.ZentrierteAusgabe("Wie soll dein Haustier heißen?:");
                Console.SetCursorPosition(57, 4);
                tierName = Console.ReadLine().Trim();

                Spielmechanik.ZentrierteAusgabe($"Du möchtest also ein(e/en) {haustiertypAuswahl[haustierTyp]} namens {tierName}. Ist das korrekt? ");
                string[] bestatigungmenuAuswahl = { "             Ja              ", "Nein, ich möchte etwas ändern" };
                Spielmechanik.text = ("Bestätige deine Auswahl:\n");
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
            Spielmechanik.ZentrierteAusgabe($"Großartig! Dein neues Haustier ist ein(e) {haustiertypAuswahl[haustierTyp]} namens {tierName}.\n\n\n");
            meinTier.sagHallo();
            Console.SetCursorPosition(57, 25);
            Spielmechanik.ZentrierteAusgabe("Drücke eine beliebige Taste um fortzufahren ...");
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
            Spielmechanik.ZentrierteAusgabe(Spielmechanik.text);
            for (int i = 0; i < menuItems.Length; i++)
            {
                ;
                if (i == auswahlIndex)
                {
                    Spielmechanik.ZentrierteAusgabe($"> {menuItems[i]} <");
                }
                else
                {
                    Spielmechanik.ZentrierteAusgabe($" {menuItems[i]} ");
                }

            }
        }
        public void Hauptmenu()
        {
            Spielmechanik.ZentrierteAusgabe("~ Hauptmenü ~\n");
            string[] hauptmenuAnzeige = { "Aktivitäten", "   Essen   ", "    Ruhe   ", "   Status  ", "  Beenden  " };
            while (true)
            {
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
            string[] aktivitatsmenuAnzeige = meinTier.Aktivitaten();
            Spielmechanik.ZentrierteAusgabe("~ Aktivitätsmenü ~");
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
            string[] essenmenuAnzeige = { " Leckerli ", "  Snack   ", " Mahlzeit ", "zurück" };
            Spielmechanik.ZentrierteAusgabe("~ Essensmenü ~");
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
            string[] statusmenuAnzeige = { "Status", "Tipps", "zurück" };
            Spielmechanik.ZentrierteAusgabe(" ~Statusmenü ~");
            int auswahl = NavigationsMenu(statusmenuAnzeige);
            switch (auswahl)
            {
                case 0:
                    Console.Clear();
                    Spielmechanik.ZentrierteAusgabe($"{meinTier.tierName}'s Status:\n");
                    Spielmechanik.ZentrierteAusgabe($"Gesundheit: {meinTier.Gesundheit}");
                    Spielmechanik.ZentrierteAusgabe($"Hunger: {meinTier.Hunger}");
                    Spielmechanik.ZentrierteAusgabe($"Energie: {meinTier.Energie}");
                    Spielmechanik.ZentrierteAusgabe($"Zufriedenheit: {meinTier.Zufriedenheit}");
                    Console.ReadKey();
                    return;

                case 1:
                    Console.Clear();
                    Spielmechanik.ZentrierteAusgabe("<Tipps einfügen>");                      //String-Array mit Tipps erstellen!
                    Console.ReadKey();
                    return;
                case 2:
                    return;
            }

        }
    }
}
