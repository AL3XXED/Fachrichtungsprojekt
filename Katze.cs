using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Katze : Haustier
    {
        public Katze(string name) : base(name) { }

        public override void sagHallo()
        {
            Console.WriteLine($"Miauu! Ich bin {Name} die Katze");
        }

        public void kratzen()
        {
            Console.WriteLine($"{Name} spielt am Kratzbaum");
            Energie -= 15;
            Zufriedenheit += 5;
        }
        public void Schnurren()
        {
            Console.WriteLine($"{Name} schnurrt zufrieden.");
            Zufriedenheit += 5;
        }
    }
}
