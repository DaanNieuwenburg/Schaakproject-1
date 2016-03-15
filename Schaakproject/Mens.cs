using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Schaakproject
{
    public class Mens : Speler
    {
        public SpecialPB selected { get; set; }
        public bool validezet { get; set; }
        public Mens(string naam, string kleur)
        {
            Naam = naam;
            Kleur = kleur;
        }

        public void SelecteerStuk(SpecialPB pictures)
        {
            if (pictures.vakje.schaakstuk.kleur == this.Kleur)
            {
                if (pictures == selected)
                {
                    DeselecteerStuk();
                }
                else
                {
                    if (selected != null)
                    {
                        DeselecteerStuk();
                    }

                    this.selected = pictures;
                    pictures.BackColor = Color.HotPink;
                }
            }
        }

        private void DeselecteerStuk()
        {
            selected.vakje.update();
            selected = null;
        }

        public void SelecteerVakje(SpecialPB pictures, SpeelBord speelbord, Spel spel)
        {
            if (selected != null)
            {
                SpecialPB clicked = pictures;
                pictures.BackColor = Color.AliceBlue;
                selected.vakje.schaakstuk.Verplaats(pictures, selected, this);
                selected.vakje.update();
                pictures.vakje.update();
                selected = null;
                if (validezet == true)
                {
                    spel.vorigVakje = clicked;
                    spel.VeranderSpeler();
                }
                validezet = false;
            }

        }

    }
}

