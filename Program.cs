﻿namespace Haustier_Tamagotchi
{
    internal class Program
    {
    
        static void Main(string[] args)
        {
            Spielmechanik neuesSpiel = new Spielmechanik();
            Haustier neuesTier = new Haustier("name");
            Hund neuerhund = new Hund("name");

            neuesSpiel.Begruessung();
            neuesSpiel.ErstelleHaustier();
            neuesTier.sagHallo();
            neuesSpiel.Hauptmenu();

            //MyIIMG("<Bildname.png>");
        }
    }
}
