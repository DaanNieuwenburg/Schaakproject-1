using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Schaakproject
{
    public abstract class Schaakstuk
    {
        public string Kleur { get; set; }
        public Image Afbeelding { get; set; }
        public Vakje Vakje { get; set; }
        public Speler Speler { get; set; }
        public bool Geslagen { get; private set; }
        public abstract void Verplaats(Vakje nieuwVakje, Vakje selected, Spel spel);
        public abstract void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk);
        public void Slaan()
        {
            if (Speler != null)
            {
                Speler.AantalStukken[5]--;
                if (this is Pion )
                {
                    Speler.AantalStukken[0]--;
                    Geslagen = true;
                }
                else if (this is Toren )
                {
                    Speler.AantalStukken[1]--;
                }
                else if (this is Paard )
                {
                    Speler.AantalStukken[2]--;
                }
                else if (this is Loper )
                {
                    Speler.AantalStukken[3]--;
                }
                else if (this is Dame )
                {
                    Speler.AantalStukken[4]--;
                }
            }
        }
    }
}


