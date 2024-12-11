using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Maus : Haustier
    {
        public Maus(string tierName) : base(tierName) { }
    
            public override void sagHallo()
        {
            Console.WriteLine($"Pipps! Ich bin {tierName} deine kleine Süße Maus");
        }

        public void klettern()
        {
            Console.WriteLine($"{tierName} klettert an dir hoch.");
            Energie -= 15;
            Zufriedenheit += 5;
        }
    }
}
