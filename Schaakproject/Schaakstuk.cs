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

        public abstract void Verplaats(Vakje nieuwVakje, Vakje selected, Spel spel);
        public abstract void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk);
        public void Slaan()
        {
            if (speler != null)
            {
                speler.AantalStukken[5]--;
                if (this is Pion )
                {
                    speler.AantalStukken[0]--;
                    geslagen = true;
                }
                else if (this is Toren )
                {
                    speler.AantalStukken[1]--;
                }
                else if (this is Paard )
                {
                    speler.AantalStukken[2]--;
                }
                else if (this is Loper )
                {
                    speler.AantalStukken[3]--;
                }
                else if (this is Dame )
                {
                    speler.AantalStukken[4]--;
                }
            }
        }
    }
}


