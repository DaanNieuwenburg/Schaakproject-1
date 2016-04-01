using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Schaakproject
{
    public class Mens : Speler
    {
        public Vakje Selected { get; set; }
        public int ResterendeStukken { get; set; }
        private Color _selectColor { get; set; }

        public Mens(string naam, string kleur, Spel _spel, Color select)
        {
            _selectColor = select;
            Naam = naam;
            Kleur = kleur;
            spel = _spel;
            ResterendeStukken = 16;
        }

        public void SelecteerStuk(Vakje clicked, Spel spel)
        {
            if (Selected != null) //alleen als er al een stuk is geselecteerd
            {
                if (Selected.schaakstuk is Toren && clicked.schaakstuk is Koning)
                {
                    //als het eerste stuk een toren is en het tweede een koning probeer dan te rokeren
                    (clicked.schaakstuk as Koning).Rokeren(Selected, clicked, this, spel);
                    DeselecteerStuk();
                }

                else if (Selected.schaakstuk is Koning && clicked.schaakstuk is Toren)
                {
                    //als het eerste stuk een koning is en het tweede een toren probeer dan te rokeren
                    (Selected.schaakstuk as Koning).Rokeren(clicked, Selected, this, spel);
                    DeselecteerStuk();
                }
            }

            if (ValideZet == false) //als hij niet gerokeerd heeft
            {
                if (clicked == Selected) //als het stuk waarop geklikt is al geselecteerd was
                {
                    DeselecteerStuk();
                }
                else
                {
                    if (Selected != null) //als er al een stuk geselecteerd staat
                    {
                        DeselecteerStuk();
                    }
                    this.Selected = clicked; //het stuk waarop geklikt is wordt geselecteerd
                    clicked.Pbox.BackColor = _selectColor; //de kleur van het vakje veranderd

                }
            }
            else // als het rokeren gelukt is
            {
                spel.VeranderSpeler(); //De speler veranderd;

                // De pion voor en-passant wordt weer vergeten.               
                EnPassantPion = null;

            }

            ValideZet = false;
        }

        private void DeselecteerStuk()
        {
            Selected.Pbox.update();     //de picturebox updatet zodat de kleur weer normaal wordt.
            Selected = null;            //er staat niets meer geselecteerd
        }

        public void SelecteerVakje(Vakje nieuwVakje, Spel spel)
        {
            if (spel.SpelerAanZet == spel.Speler1)
            {
                Console.WriteLine("HUIDIGE SPELER IS SPELER 1");
            }
            else if (spel.SpelerAanZet == spel.ComputerSpeler)
            {
                Console.WriteLine("HUIDIGE SPELER IS COMP SPELER");
            }

            if (Selected != null) //alleen als er al iets is geselecteerd
            {
                Vakje clicked = nieuwVakje;   //voor de singleplayer
                Selected.schaakstuk.Verplaats(nieuwVakje, Selected, spel); //probeer het schaakstuk te verplaatsen

                Selected.Pbox.update();    //update het eerste vakje
                nieuwVakje.Pbox.update();         //update het tweede vakje
                Selected = null;            //niets is meer geselecteerd

                if (ValideZet == true)          //als het schaakstuk daar heen mag
                {
                    spel.Selected = clicked;    //voor de singleplayer
                    spel.VeranderSpeler();      //de andere speler is aan zet
                    if (spel.SpelMode == "Singleplayer")
                    {
                        Console.WriteLine("SPELERRONDE");
                        spel.ComputerSpeler.Zet(clicked, spel);  // laat de computer op de mens reageren
                        spel.VeranderSpeler();
                    }

                    // De pion voor en-passant wordt weer vergeten.
                    EnPassantPion = null;
                }
                ValideZet = false;
            }
        }

    }
}

