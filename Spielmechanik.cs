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
        private string tierName;
        public static string text = " ";
        public static string uberschrift = (" \t\t  _______ _               _______                                _       _     _ \r\n\t\t |__   __(_)             |__   __|                              | |     | |   (_)\r\n\t\t    | |   _  ___ _ __ ______| | __ _ _ __ ___   __ _  __ _  ___ | |_ ___| |__  _ \r\n\t\t    | |  | |/ _ \\ '__|______| |/ _` | '_ ` _ \\ / _` |/ _` |/ _ \\| __/ __| '_ \\| |\r\n\t\t    | |  | |  __/ |         | | (_| | | | | | | (_| | (_| | (_) | || (__| | | | |\r\n\t\t    |_|  |_|\\___|_|         |_|\\__,_|_| |_| |_|\\__,_|\\__, |\\___/ \\__\\___|_| |_|_|\r\n                         \t\t                              __/ |                      \r\n                                  \t\t                     |___/                       \r\n========================================================================================================================");

        internal Haustier MeinTier { get => meinTier; set => meinTier = value; }
        public string TierName { get => tierName; set => tierName = value; }

        public void Begruessung()
        {
            Console.WriteLine(Spielmechanik.uberschrift);
            ZentrierteAusgabe("Bitte gib dein Namen ein:");
            Console.SetCursorPosition(58, 11);
            string spielerName = Console.ReadLine().ToUpper();
            ZentrierteAusgabe($"Hallo {spielerName}! Lass uns dein virtuelles Haustier erstellen.");
            Console.Clear();
        }


        public static void Ladebalken(int schritte, int dauer)
        {
            int breite = Console.WindowWidth - 70;
            int positionUnten = Console.WindowHeight - 2;

            Console.CursorVisible = false;
            Console.SetCursorPosition(44, positionUnten);
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
        public static void ZentrierteAusgabe(string text)
        {
            int fensterbreite = Console.WindowWidth;
            int startpunkt = (fensterbreite - text.Length) / 2;
            startpunkt = Math.Max(startpunkt, 0);                            // Stellt sicher, dass der Startpunkt nicht negativ ist
            startpunkt = Math.Min(startpunkt, fensterbreite - text.Length);  // Stellt sicher, dass der Startpunkt innerhalb der Fensterbreite liegt
            Console.SetCursorPosition(startpunkt, Console.CursorTop);
            Console.WriteLine(text);
        }
    }
}
