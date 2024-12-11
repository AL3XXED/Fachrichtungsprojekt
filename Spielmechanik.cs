using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Spielmechanik
    {
        private string playerName;
        public void Begruessung()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Willkommen bei Haustier-Tamagotchi!");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.Write("Bitte gib deinen Namen ein: ");
            string playerName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"Hallo {playerName}! Lass uns dein virtuelles Haustier erstellen.");
        }

        public void menueTier()
        {
            string[] menue1 = { "Hund", "Katze", "Maus", "Vogel" };
            int tierIndex = 0;
            bool weiter = true;
            while (weiter)
            {
                Console.Clear();
                Console.WriteLine("Wähle dein Haustier aus:");

                for (int i = 0; i < menue1.Length; i++)
                {
                    if (i == tierIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"> {menue1[i]} <");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {menue1[i]}   ");
                    }
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        tierIndex = (tierIndex - 1 + menue1.Length) % menue1.Length;
                        break;

                    case ConsoleKey.DownArrow:
                        tierIndex = (tierIndex + 1) % menue1.Length;
                        break;

                    case ConsoleKey.Enter:
                        if (tierIndex == menue1.Length - 1)
                            return;

                        Console.WriteLine($"\nSie haben {menue1[tierIndex]} ausgewählt.");
                        Console.ReadKey(true);
                        weiter = false;
                        break;
                }
                Console.Clear();
            }
        }
        public void tierName()
        {
            bool wiederholen = true;
            while (wiederholen)
            {
                Console.WriteLine("Bitte gib deinem neuem Haustier einen Namen:");
                string name = Console.ReadLine();
                Console.WriteLine($"Ist der Name: {name} richtig ? (Ja/Nein)");
                string eingabe = Console.ReadLine().ToLower().Trim();
                if (eingabe == "j" || eingabe == "ja")
                {
                    Console.WriteLine($"{name} ist ein sehr schöner Name.");
                    wiederholen = false;
                }
                else if (eingabe == "n" || eingabe == "nein")
                {
                    Console.WriteLine("Okay dann lass es uns nocheinmal versuchen.");
                    wiederholen = true ;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Eingabe ungültig!");
                }
            }

        }
        public void hauptmenu()
        {
            string[] menuauswahl = { "Aktivitäten", "Füttern", "Ausruhen", "Status", "Exit" };
            int auswahlIndex = 0;

            ConsoleKey key;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuauswahl.Length; i++)
                {
                    if (i == auswahlIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"> {menuauswahl[i]} <");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {menuauswahl[i]}");
                    }
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        auswahlIndex = (auswahlIndex == 0) ? menuauswahl.Length - 1 : auswahlIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        auswahlIndex = (auswahlIndex == menuauswahl.Length - 1) ? 0 : auswahlIndex + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine($"Du hast {menuauswahl[auswahlIndex]} ausgewählt");
                        if (menuauswahl[auswahlIndex] == "Exit")
                        {
                            return;
                        }
                        Console.ReadKey();
                        break;
                }
            } while (key != ConsoleKey.Escape);
        }


    }
}
