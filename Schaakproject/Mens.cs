using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Schaakproject
{
    public class Mens : Speler
    {
        private Vakje selected { get; set; }
        public bool validezet { get; set; }
        
        public Mens(string naam, string kleur, Spel _spel)
        {
            Naam = naam;
            Kleur = kleur;
            spel = _spel;
        }

        public void SelecteerStuk(Vakje clicked, Spel spel)
        {
            if (selected != null) //alleen als er al een stuk is geselecteerd
            {
                if (selected.schaakstuk is Toren && clicked.schaakstuk is Koning)
                {
                    //als het eerste stuk een toren is en het tweede een koning probeer dan te rokeren
                    (clicked.schaakstuk as Koning).Rokeren(selected, clicked, this);
                    DeselecteerStuk();

                }

                else if (selected.schaakstuk is Koning && clicked.schaakstuk is Toren)
                {
                    //als het eerste stuk een koning is en het tweede een toren probeer dan te rokeren
                    (selected.schaakstuk as Koning).Rokeren(clicked, selected, this);
                    DeselecteerStuk();
                }
            }
            
            if (validezet == false) //als hij niet gerokeerd heeft
                {
                if (clicked == selected) //als het stuk waarop geklikt is al geselecteerd was
                    {
                        DeselecteerStuk();
                    }
                    else
                    {
                    if (selected != null) //als er al een stuk geselecteerd staat
                        {
                            DeselecteerStuk();
                        }
                    this.selected = clicked; //het stuk waarop geklikt is wordt geselecteerd
                    clicked.pbox.BackColor = Color.HotPink; //de kleur van het vakje veranderd

                    }
                }
            else // als het rokeren gelukt is
            {
                spel.VeranderSpeler(); //De speler veranderd;

                // De pion voor en-passant wordt weer vergeten.               
                enPassantPion = null;
                
            }
            
            validezet = false;
        }
        
        private void DeselecteerStuk()
        {
            selected.pbox.update();     //de picturebox updatet zodat de kleur weer normaal wordt.
            selected = null;            //er staat niets meer geselecteerd
        }

        public void SelecteerVakje(Vakje nieuwVakje,  Spel spel)
        {
            if (selected != null) //alleen als er al iets is geselecteerd
            {
                Vakje clicked = nieuwVakje;   //voor de singleplayer
                selected.schaakstuk.Verplaats(nieuwVakje, selected, this, spel); //probeer het schaakstuk te verplaatsen
                
                selected.pbox.update();    //update het eerste vakje
                nieuwVakje.pbox.update();         //update het tweede vakje
                selected = null;            //niets is meer geselecteerd
                
                if (validezet == true)          //als het schaakstuk daar heen mag
                {
                    spel.selected = clicked;    //voor de singleplayer
                    spel.VeranderSpeler();      //de andere speler is aan zet

                    // De pion voor en-passant wordt weer vergeten.
                    enPassantPion = null;
                }
                validezet = false;
            }
        }

    }
}

