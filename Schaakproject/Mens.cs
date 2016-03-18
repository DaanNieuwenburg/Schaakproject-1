using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Schaakproject
{
    public class Mens : Speler
    {
        private SpecialPB selected { get; set; }
        public bool validezet { get; set; }
        public Koning koning { get; set; }
        public Mens(string naam, string kleur)
        {
            Naam = naam;
            Kleur = kleur;
        }

        public void SelecteerStuk(SpecialPB pictures, Spel spel)
        {
            if (selected != null) //alleen als er al een stuk is geselecteerd
            {
                if (selected.vakje.schaakstuk is Toren && pictures.vakje.schaakstuk is Koning)
                {
                    //als het eerste stuk een toren is en het tweede een koning probeer dan te rokeren
                    (pictures.vakje.schaakstuk as Koning).Rokeren(selected, pictures, this);
                    DeselecteerStuk();

                }

                else if (selected.vakje.schaakstuk is Koning && pictures.vakje.schaakstuk is Toren)
                {
                    //als het eerste stuk een koning is en het tweede een toren probeer dan te rokeren
                    (selected.vakje.schaakstuk as Koning).Rokeren(pictures, selected, this);
                    DeselecteerStuk();
                }
            }

            if (validezet == false) //als hij niet gerokeerd heeft
                {
                if (pictures == selected) //als het stuk waarop geklikt is al geselecteerd was
                    {
                        DeselecteerStuk();
                    }
                    else
                    {
                    if (selected != null) //als er al een stuk geselecteerd staat
                        {
                            DeselecteerStuk();
                        }
                    this.selected = pictures; //het stuk waarop geklikt is wordt geselecteerd
                    pictures.BackColor = Color.HotPink; //de kleur van het vakje veranderd

                    }
                }
            else // als het rokeren gelukt is
            {
                spel.VeranderSpeler(); //De speler veranderd;
            }
            validezet = false;
        }

        private void DeselecteerStuk()
        {
            selected.update();          //de picturebox updatet zodat de kleur weer normaal wordt.
            selected = null;            //er staat niets meer geselecteerd
        }

        public void SelecteerVakje(SpecialPB pictures, SpeelBord speelbord, Spel spel)
        {
            if (selected != null) //alleen als er al iets is geselecteerd
            {
                SpecialPB clicked = pictures;   //voor de singleplayer
                selected.vakje.schaakstuk.Verplaats(pictures, selected, this); //probeer het schaakstuk te verplaatsen

                selected.update();    //update het eerste vakje
                pictures.update();    //update het tweede vakje
                selected = null;            //niets is meer geselecteerd
                
                if (validezet == true)          //als het schaakstuk daar heen mag
                {
                    spel.selected = clicked;    //voor de singleplayer
                    spel.VeranderSpeler();      //de andere speler is aan zet
                }
                validezet = false;
            }
        }

    }
}

