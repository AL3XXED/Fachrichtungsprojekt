namespace Haustier_Tamagotchi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Spielmechanik neuesSpiel = new Spielmechanik();
            Haustier neuesTier = new Haustier("name");


            neuesSpiel.Begruessung(); 
            neuesSpiel.menueTier();
            neuesSpiel.tierName();
            neuesSpiel.hauptmenu();
            neuesTier.sagHallo();
            neuesTier.Spielen();

        }
    }
}
