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

        public static bool GameOver { get; private set; }

        public static int Absicherung(int wert, int min, int max)
        {
            return Math.Clamp(wert, min, max);
        }

        public static void Energiegrenze(int status)
        {
            meinTier.Energie = Absicherung(status, 0, meinTier.Energiemax);
        }

        public static void Gesundheitgrenze(int status)
        {
            meinTier.Gesundheit = Absicherung(status, 0, meinTier.Gesundheitmax);
        }

        public static void Hungergrenze(int status)
        {
            int neuerHunger = Absicherung(status, 0, meinTier.Hungermax);
            if (neuerHunger == 0 && meinTier.Hunger > 0)
            {
                Sterben();
            }
            meinTier.Hunger = neuerHunger;
        }

        public static void Zufriedenheitgrenze(int status)
        {
            int neueZufriedenheit = Absicherung(status, 0, meinTier.Zufriedenheitmax);
            if (neueZufriedenheit >= meinTier.Zufriedenheitmax && meinTier.Zufriedenheit < meinTier.Zufriedenheitmax)
            {
                LevelAufstieg();
            }
            meinTier.Zufriedenheit = neueZufriedenheit;
        }

        public static void VerbrauchEnergie(int menge)
        {
            Energiegrenze(meinTier.Energie - menge);
        }

        public static void ErhoeheZufriedenheit(int menge)
        {
            Zufriedenheitgrenze(meinTier.Zufriedenheit + menge);
        }

        public static void ErhoeheHunger(int menge)
        {
            Hungergrenze(meinTier.Hunger + menge);
        }

        public static void ErhoeheEnergie(int menge)
        {
            Energiegrenze(meinTier.Energie + menge);
        }

        public static void ErhoeheGesundheit(int menge)
        {
            Gesundheitgrenze(meinTier.Gesundheit + menge);
        }

        public static void VerringereHunger(int menge)
        {
            Hungergrenze(meinTier.Hunger - menge);
        }

        public static void LevelAufstieg()
        {
            if (meinTier.Level < meinTier.Levelmax)
            {
                meinTier.Level++;
                meinTier.Gesundheitmax += 10;
                meinTier.Hungermax += 5;
                meinTier.Energiemax += 10;

                Spielmechanik.ZentrierteAusgabe($"Gratulation! {meinTier.tierName} ist aufgestiegen!");
                Spielmechanik.ZentrierteAusgabe($"{meinTier.tierName} ist jetzt auf Level {meinTier.Level}.");
            }
        }

        public static void Sterben()
        {
            GameOver = true;
            Spielmechanik.ZentrierteAusgabe($"{meinTier.tierName} ist verhungert und gestorben!");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }

        public static void AktualisiereStatus()
        {
            PruefeHunger();
            PruefeZufriedenheit();
            Gesundheitgrenze(meinTier.Gesundheit);
            Energiegrenze(meinTier.Energie);
        }

        public static void PruefeHunger()
        {
            if (meinTier.Hunger <= 0 || meinTier.Gesundheit == 0)
            {
                Sterben();
            }
            else if (meinTier.Hunger >= meinTier.Hungermax - 15)
            {
                 meinTier.Gesundheit -= 15;
            }
        }

        public static void PruefeZufriedenheit()
        {
            if (meinTier.Zufriedenheit >= meinTier.Zufriedenheitmax)
            {
                LevelAufstieg();
            }
        }

        public static bool HatGenugEnergie(int benoetigteEnergie)
        {
            return meinTier.Energie >= benoetigteEnergie;
        }
    }
}
