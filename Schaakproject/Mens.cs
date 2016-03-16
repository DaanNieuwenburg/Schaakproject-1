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

        public void SelecteerStuk(SpecialPB pictures, Spel spel)
        {
            if (selected != null)
            {
                if (selected.vakje.schaakstuk is Toren && pictures.vakje.schaakstuk is Koning)
                {

                    (pictures.vakje.schaakstuk as Koning).Rokeren(selected, pictures, this);
                    DeselecteerStuk();

                }

                else if (selected.vakje.schaakstuk is Koning && pictures.vakje.schaakstuk is Toren)
                {

                    (selected.vakje.schaakstuk as Koning).Rokeren(pictures, selected, this);
                    DeselecteerStuk();
                }
            }
            if (validezet == false)
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
            else
            {
                spel.VeranderSpeler();
            }
            validezet = false;
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
                    //spel.selected = clicked;
                    spel.VeranderSpeler();
                }
                validezet = false;
            }
        }

    }
}

