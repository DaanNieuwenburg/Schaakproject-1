﻿using System;
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

        public abstract void Verplaats(Vakje leegVakje, Vakje selected, Mens speler);
        public abstract bool kanStukSlaan(Vakje geselecteerdStuk);
        public void Slaan(string kleur)
        {

        }
    }
}


