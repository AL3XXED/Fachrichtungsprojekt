using System.Drawing;
using TrueColorConsole;

namespace Haustier_Tamagotchi
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Spielmechanik neuesSpiel = new Spielmechanik();
            Haustier neuesTier = new Haustier("name");
            Hund neuerhund = new Hund("name");
            Menüführung menu = new Menüführung();
            Bedingungen bedingungen = new Bedingungen();



            neuesSpiel.Begruessung();
            menu.ErstelleHaustier();
            neuesTier.sagHallo();
            menu.Hauptmenu();

        }
    }
}
