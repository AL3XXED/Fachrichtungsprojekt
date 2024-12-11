using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Katze : Haustier
    {
        public Katze(string tierName) : base(tierName) { }

        public override void sagHallo()
        {
            Console.WriteLine($"Miauu! Ich bin {tierName} die Katze");
        }

        public void kratzen()
        {
            Console.WriteLine($"{tierName} spielt am Kratzbaum");
            Energie -= 15;
            Zufriedenheit += 5;
        }
        public void Schnurren()
        {
            Console.WriteLine($"{tierName} schnurrt zufrieden.");
            Zufriedenheit += 5;
        }
    }
}
