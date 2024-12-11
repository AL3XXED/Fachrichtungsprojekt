using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Hund : Haustier
    {
        public Hund(string name) : base(name) { }

        public override void sagHallo() 
        {
            Console.WriteLine($"Wuff! Ich bin {Name} dein neuer Freund");
        }

        public void Apportieren()
        {
            Console.WriteLine($"{Name} holt den geworfenen Ball");
            Energie -= 15;
            Zufriedenheit += 5;
        }
        public void Bellen()
        {
            Console.WriteLine($"{Name} bellt laut: Wuff! Wuff!");
            Energie -= 5;
        }
    }
}
