using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Menüführung
    {
        public static Haustier meinTier;
        private string[] haustiertypAuswahl = { "Hund", "Katze", "Maus", "Vogel" };
        private int auswahlIndex = 0;
        public static string tierName;

        public void ErstelleHaustier()
        {
            int haustierTyp;
            ;
            bool weiter = false;

            do
            {
                Spielmechanik.text = ("Wähle dein Haustier aus:\n");        //Auswahl des Haustiers durch die Navigationsmethode welche die Pfeiltasten
                haustierTyp = NavigationsMenu(haustiertypAuswahl);          //und Enter als Eingabe nutzt
                Console.Clear();
                Console.SetCursorPosition(0, 5);
                Spielmechanik.ZentrierteAusgabe($"Du hast {haustiertypAuswahl[haustierTyp]} gewählt.");
                Console.SetCursorPosition(0, 7);
                Spielmechanik.ZentrierteAusgabe("Wie soll dein Haustier heißen?:");
                Console.SetCursorPosition(57, 13);
                Spielmechanik.ZentrierteAusgabe("---------------");
                Console.SetCursorPosition(57, 12);                           //Cursor-position wird auf die mitte der Konsole gesetzt 
                Console.CursorVisible = true;                               //für die Eingabe Tiername
                tierName = Console.ReadLine().Trim();
                Console.CursorVisible = false;                              //Corsor wird unsichtbar gemacht

                //Abfrage ob Haustier und Namens wahl richtig sind, falls Nein kann man es nochmal versuchen
                Spielmechanik.ZentrierteAusgabe($"Du möchtest also ein(e/en) {haustiertypAuswahl[haustierTyp]} namens {tierName}. Ist das korrekt? ");
                string[] bestatigungmenuAuswahl = { "             Ja              ", "Nein, ich möchte etwas ändern" };
                Spielmechanik.text = ("Bestätige deine Auswahl:\n");
                int bestatigungsAuswahl = NavigationsMenu(bestatigungmenuAuswahl);

                weiter = (bestatigungsAuswahl == 0);
            } while (!weiter);

            switch (haustierTyp)            //Hier wird das gewählte Tier erstellt, welches sich auf die Kindklassen von Haustier bezieht
            {                               //um anschließend die passenden Auswahl & Ausgabe texte anzeigt
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
            meinTier.ZeigeTier();                       //Zeigt ein Pixelbild vom gewählten Haustier => Hund, Katze, Maus oder Vogel
            Console.SetCursorPosition(0, 24);
            meinTier.sagHallo();                        //Methodenaufruf der mit Override in Kindklasse passend zum Tier ausgegeben wird
            Console.SetCursorPosition(57, 27);
            Spielmechanik.ZentrierteAusgabe("Drücke eine beliebige Taste um fortzufahren ...");
            Console.ReadKey();
        }
        private int NavigationsMenu(string[] menuItems)         //Fügt die benutzung der Pfeiltasten in der Menüausgabe ein
        {
            auswahlIndex = 0;                                   //Diese Methode wird ein allen Menüs benutzt und ist Grundlegend für das Spiel
            while (true)
            {
                DisplayMenu(menuItems);                         //Zeigt die Menü-Auswahl an,durch die Displaymenu-Methode
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:                    //Bewegt die Auswahl nach oben,wenn es Anfang ist springt es auf das unterste
                        auswahlIndex = (auswahlIndex - 1 + menuItems.Length) % menuItems.Length;
                        break;
                    case ConsoleKey.DownArrow:                  //Bewegt die Auswahl nach unten, wenn es das unterste ist springt es nach oben
                        auswahlIndex = (auswahlIndex + 1) % menuItems.Length;
                        break;
                    case ConsoleKey.Enter:                      //Eingabe mit Enter und gibt den Auswahlindex zurück
                        return auswahlIndex;
                }
            }
        }

        private void DisplayMenu(string[] menuItems)   //Setzt die aktuell Auswahl in > < zur optischen Übersicht
        {
            Console.CursorVisible = false;
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
                    Spielmechanik.ZentrierteAusgabe($" {menuItems[i]} "); //Zeigt die Auswahloptionen an
                }

            }
        }
        public void Hauptmenu()                         //Hauptmenü von dem man in die unterschiedlichen Menü-Methoden kommt
        {
            Spielmechanik.ZentrierteAusgabe("~ Hauptmenü ~\n");
            string[] hauptmenuAnzeige = { "Aktivitäten", "   Essen   ", "    Ruhe   ", "   Status  ", "  Beenden  " };
            while (true)
            {
                int auswahl = NavigationsMenu(hauptmenuAnzeige);
                switch (auswahl)
                {
                    case 0:                             // Aktivitäten Menü
                        AktivitatenMenu();
                        break;
                    case 1:                             // Essens Menü
                        EssenMenu();
                        break;
                    case 2:                             // Ruhe Methode
                        meinTier.Ruhen();
                        break;
                    case 3:                            // Status Methode
                        Statusanzeige();
                        break;
                    case 4:                            // Beenden
                        return;
                }
            }
        }

        private void AktivitatenMenu()              //Aktivitäten Anzeige wird in Kindklassen überschrieben je nach gewähltem Tier
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
        private void EssenMenu()                    //Essenmenü um je nach Wahl den Wert Hunger wieder zu verringern & Zufriedenheit erhöht
        {
            string[] essenmenuAnzeige = { " Leckerli ", "  Snack   ", " Mahlzeit ", "zurück" };
            Spielmechanik.ZentrierteAusgabe("~ Essensmenü ~");
            int auswahl = NavigationsMenu(essenmenuAnzeige);
            switch (auswahl)
            {
                case 0:                     //Leckerli
                    if (meinTier.Hunger < meinTier.Hungermax)
                    { meinTier.Futtern(5); meinTier.Zufriedenheit++; }
                    else
                    { Spielmechanik.ZentrierteAusgabe($"{meinTier.tierName} hat kein Hunger."); }
                    break;
                case 1:                     //Snack
                    if (meinTier.Hunger < meinTier.Hungermax)
                    { meinTier.Futtern(20); meinTier.Zufriedenheit++; }
                    else
                    { Spielmechanik.ZentrierteAusgabe($"{meinTier.tierName} hat kein Hunger."); }
                    break;
                case 2:                     //Mahlzeit
                    if (meinTier.Hunger < meinTier.Hungermax)
                    { meinTier.Futtern(35); meinTier.Zufriedenheit++; }
                    else
                    { Spielmechanik.ZentrierteAusgabe($"{meinTier.tierName} hat kein Hunger."); }
                    break;
                case 3:
                    return;
            }
        }
        private void Statusanzeige()
        {

            Console.Clear();
            meinTier.ZeigeTier();
            Spielmechanik.ZentrierteAusgabe($"{meinTier.tierName}'s Status:\n");
            Spielmechanik.ZentrierteAusgabe($"Level: {meinTier.Level}");

            if(meinTier.Gesundheit > meinTier.Gesundheitmax - 25)               //Bedingungen eingefügt um Anzeige der Statuswerte einzufärben
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Spielmechanik.ZentrierteAusgabe($"Gesundheit: {meinTier.Gesundheit} / {meinTier.Gesundheitmax}");
                Console.ResetColor();
            }
            else if(meinTier.Gesundheit < meinTier.Gesundheitmax - 25 && meinTier.Gesundheit > meinTier.Gesundheitmax - 75)
            { 
                Console.ForegroundColor = ConsoleColor.Yellow;
                Spielmechanik.ZentrierteAusgabe($"Gesundheit: {meinTier.Gesundheit} / {meinTier.Gesundheitmax}");
                Console.ResetColor();
            }
            else if (meinTier.Gesundheit < meinTier.Gesundheitmax - 75)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Spielmechanik.ZentrierteAusgabe($"Gesundheit: {meinTier.Gesundheit} / {meinTier.Gesundheitmax}");
                Console.ResetColor();
            }
            //----------------------------------------------------------------------------------------------------

            if (meinTier.Hunger < meinTier.Hungermax - 60)                   //Bedingungen eingefügt um Anzeige der Statuswerte einzufärben
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Spielmechanik.ZentrierteAusgabe($"Hunger: {meinTier.Hunger} / {meinTier.Hungermax}");
                Console.ResetColor();
            }
            else if (meinTier.Hunger > meinTier.Hungermax - 60 && meinTier.Hunger < meinTier.Hungermax - 20)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Spielmechanik.ZentrierteAusgabe($"Hunger: {meinTier.Hunger} / {meinTier.Hungermax}");
                Console.ResetColor();
            }
            else if (meinTier.Hunger > meinTier.Hungermax - 20)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Spielmechanik.ZentrierteAusgabe($"Hunger: {meinTier.Hunger} / {meinTier.Hungermax}"); 
                Console.ResetColor();
            }
            //----------------------------------------------------------------------------------------------------

            if (meinTier.Energie > meinTier.Energiemax - 20)                //Bedingungen eingefügt um Anzeige der Statuswerte einzufärben
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Spielmechanik.ZentrierteAusgabe($"Energie: {meinTier.Energie} / {meinTier.Energiemax}");
                Console.ResetColor();
            }
            else if (meinTier.Energie < meinTier.Energiemax - 20  && meinTier.Energie > meinTier.Energiemax - 60)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Spielmechanik.ZentrierteAusgabe($"Energie: {meinTier.Energie} / {meinTier.Energiemax}");
                Console.ResetColor();
            }
            else if (meinTier.Energie < meinTier.Energiemax - 60)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Spielmechanik.ZentrierteAusgabe($"Energie: {meinTier.Energie} / {meinTier.Energiemax}");
                Console.ResetColor();
            }
            //---------------------------------------------------------------------------------------------------

            if (meinTier.Zufriedenheit > meinTier.Zufriedenheitmax - 25)            //Bedingungen eingefügt um Anzeige der Statuswerte einzufärben
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Spielmechanik.ZentrierteAusgabe($"Zufriedenheit: {meinTier.Zufriedenheit} / {meinTier.Zufriedenheitmax}");
                Console.ResetColor();
            }
            else 
            { 
                Spielmechanik.ZentrierteAusgabe($"Zufriedenheit: {meinTier.Zufriedenheit} / {meinTier.Zufriedenheitmax}"); 
            }
            Console.ReadKey();
            return;
        }
    }
}
