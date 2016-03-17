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

        public abstract void Verplaats(SpecialPB pictures, SpecialPB selected, Mens speler);
        public abstract bool kanStukSlaan(SpecialPB geselecteerdStuk);
        public void Slaan(string kleur)
        {

        }
    }
}


