using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Begruessung()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Willkommen bei Haustier-Tamagotchi!");
            Console.WriteLine("====================================");
            Console.Write("Bitte gib deinen Namen ein: ");
            string playerName = Console.ReadLine().ToUpper();

            Console.Clear();
            Console.WriteLine($"Hallo {playerName}! Lass uns dein virtuelles Haustier erstellen.");
        }

        public void ErstelleHaustier()
        {
            int haustierTyp;
            string tierName;
            bool weiter = false;

            do
            {
                Console.WriteLine("Wähle dein Haustier aus:");
                haustierTyp = NavigationsMenu(haustiertypAuswahl);

                Console.WriteLine($"Du hast {haustiertypAuswahl[haustierTyp]} gewählt. Wie soll dein Haustier heißen?");
                tierName = Console.ReadLine().Trim();

                Console.WriteLine($"Du möchtest also ein(e/en) {haustiertypAuswahl[haustierTyp]} namens {tierName}. Ist das korrekt? ");
                string[] bestatigungmenuAuswahl = { "Ja", "Nein, ich möchte etwas ändern" };
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
            Console.WriteLine($"Großartig! Dein neues Haustier ist ein(e) {haustiertypAuswahl[haustierTyp]} namens {tierName}.");
            Console.WriteLine("Drücke eine Taste, um fortzufahren...");
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
            Console.WriteLine("\nWähle eine Aktion:");

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == auswahlIndex)
                {
                    Console.WriteLine($"> {menuItems[i]} <");
                }
                else
                {
                    Console.WriteLine(menuItems[i]);
                }
                
            }
        }
        public void Hauptmenu()
        {
            string[] hauptmenuAnzeige = { "Aktivitäten", "Essen", "Ruhe", "Status", "Beenden" };
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
            string[] aktivitatsmenuAnzeige = { "Spazieren", "Streicheln", "Spielen", "Trainieren", "Hygiene", "zurück" };
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
            string[] essenmenuAnzeige = { "Leckerli", "Snack", "Mahlzeit", "zurück" };
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
    }
}
