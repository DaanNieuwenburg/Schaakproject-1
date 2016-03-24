using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Schaakproject
{
    public abstract class Schaakstuk
    {
        public string kleur { get; set; }
        public Image afbeelding { get; set; }
        public Vakje vakje { get; set; }
        public Speler speler { get; set; }

        public abstract void Verplaats(Vakje nieuwVakje, Vakje selected, Mens speler, Spel spel);
        public abstract void kanStukSlaan(Computer computer, Vakje geselecteerdStuk);
        public void Slaan(string kleur)
        {

        }
    }
}


