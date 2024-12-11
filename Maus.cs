using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Maus : Haustier
    {
        public Maus(string name) : base(name) { }
    
            public override void sagHallo()
        {
            Console.WriteLine($"Pipps! Ich bin {Name} deine kleine Süße Maus");
        }

        public void klettern()
        {
            Console.WriteLine($"{Name} klettert an dir hoch.");
            Energie -= 15;
            Zufriedenheit += 5;
        }
    }
}
