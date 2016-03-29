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
        public bool geslagen { get; private set; }

        public abstract void Verplaats(Vakje nieuwVakje, Vakje selected, Mens speler, Spel spel);
        public abstract void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk);
        public void Slaan()
        {
            speler.aantalstukken[5]--;
            if (this is Pion && speler != null)
            {
                speler.aantalstukken[0]--;
                geslagen = true;
            }
            else if (this is Toren && speler != null)
            {
                speler.aantalstukken[1]--;
            }
            else if (this is Paard && speler != null)
            {
                speler.aantalstukken[2]--;
            }
            else if (this is Loper && speler != null)
            {
                speler.aantalstukken[3]--;
            }
            else if (this is Dame && speler != null)
            {
                speler.aantalstukken[4]--;
            }
        }
    }
}


