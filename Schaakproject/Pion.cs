using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Pion : Schaakstuk
    {
        private bool _eersteZet { get; set; }       //is de pion al eens verzet
        private bool _magEnpassant { get; set; }    //mag de pion en-passant slaan
        

        public Pion(string kleur, Vakje vakje, Speler speler)
        {
            _magEnpassant = true;
            _speler = speler;
            this.vakje = vakje;
            this.kleur = kleur;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.PionWit;
            }
            else
            {
                afbeelding = Properties.Resources.PionZwart;
            }
        }

        public override void kanStukSlaan(Computer computer, Vakje geselecteerdStuk)
        {
            Vakje geselecteerdVak = geselecteerdStuk;
            if (geselecteerdVak.schaakstuk.kleur == "wit")
            {
                if (geselecteerdVak.buurNoordoost != null && geselecteerdVak.buurNoordoost.schaakstuk != null && geselecteerdVak.buurNoordoost.schaakstuk.kleur != "wit")
                {
                    computer.spelerkanslaan = true;
                }
                else if (geselecteerdVak.buurNoordoost != null && geselecteerdVak.buurNoordwest.schaakstuk != null && geselecteerdVak.buurNoordoost.schaakstuk.kleur != "wit")
                {
                    computer.computerkanslaan = true;
                }
                else
                {
                    computer.spelerkanslaan = false;
                    computer.computerkanslaan = false;
                }
            }
            else
            {
                if (geselecteerdVak.buurNoordwest != null && geselecteerdVak.buurNoordwest.schaakstuk != null && geselecteerdVak.buurNoordwest.schaakstuk.kleur != "zwart")
                {
                    computer.spelerkanslaan = true;
                }
                else if (geselecteerdVak.buurNoordwest != null && geselecteerdVak.buurNoordwest.schaakstuk != null && geselecteerdVak.buurNoordwest.schaakstuk.kleur != "zwart")
                {
                    computer.computerkanslaan = true;
                }
                else
                {
                    computer.spelerkanslaan = false;
                    computer.computerkanslaan = false;
                }
            }
        }

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Mens speler, Spel spel)
        {

            bool mogelijk = false;

            if (kleur == "wit")
            {
                // Witte pion een stapje naar voren
                if (selected.buurNoord == nieuwVakje && nieuwVakje.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // Slaan naar noordoost voor een witte pion
                else if (selected.buurNoordoost == nieuwVakje && nieuwVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Slaan naar noordwest voor een witte pion
                else if (selected.buurNoordwest == nieuwVakje && nieuwVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Twee stappen vooruit voor een witte pion
                else if (_eersteZet == false && selected.buurNoord.buurNoord == nieuwVakje && selected.buurNoord.buurNoord.schaakstuk == null && selected.buurNoord.schaakstuk == null)
                {
                    mogelijk = true;

                    // Zodat de tegenstander mag en-passant slaan
                    if (nieuwVakje.buurOost != null)
                    {
                        if (nieuwVakje.buurOost.schaakstuk is Pion)
                        {
                            // Als er oost een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.buurOost.schaakstuk as Pion)._speler.enPassantPion = this;
                        }
                    }
                    if (nieuwVakje.buurWest != null)
                    {
                        if (nieuwVakje.buurWest.schaakstuk is Pion)
                        {
                            // Als er west een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.buurWest.schaakstuk as Pion)._speler.enPassantPion = this;
                        }
                    }
                }
                else if (selected.buurOost != null)
                {
                    //en-passant slaan naar noordoost
                    if (selected.buurNoordoost == nieuwVakje && speler.enPassantPion == selected.buurOost.schaakstuk && speler.enPassantPion != null)
                    {
                        selected.buurOost.schaakstuk = null; //De andere pion verdwijnt
                        selected.buurOost.pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                        mogelijk = true;
                    }
                }
                if (selected.buurWest != null)
                {
                    //en-passant slaan naar noordwest
                    if (selected.buurNoordwest == nieuwVakje && speler.enPassantPion == selected.buurWest.schaakstuk && speler.enPassantPion != null)
                    {
                        selected.buurWest.schaakstuk = null; //De andere pion verdwijnt
                        selected.buurWest.pbox.update(); //update deze pbox zodat je de pion niet meer ziet
                        mogelijk = true;
                    }
                }

            }

            else if (kleur == "zwart")
            {
                // Zwarte pion een stapje naar voren
                if (selected.buurZuid == nieuwVakje && nieuwVakje.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // Slaan naar zuidoost voor een zwarte pion
                else if (selected.buurZuidoost == nieuwVakje && kleur == "zwart" && nieuwVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Slaan naar zuidwest voor een zwarte pion
                else if (selected.buurZuidwest == nieuwVakje && nieuwVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Twee stappen vooruit voor een zwarte pion
                else if (_eersteZet == false && selected.buurZuid.buurZuid == nieuwVakje && selected.buurZuid.buurZuid.schaakstuk == null && selected.buurZuid.schaakstuk == null)
                {
                    mogelijk = true;

                    // Zodat de tegenstander mag en-passant slaan
                    if (nieuwVakje.buurOost != null)
                    {
                        if (nieuwVakje.buurOost.schaakstuk is Pion)
                        {
                            // Als er oost een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.buurOost.schaakstuk as Pion)._speler.enPassantPion = this;

                        }
                    }
                    if (nieuwVakje.buurWest != null)
                    {
                        if (nieuwVakje.buurWest.schaakstuk is Pion)
                        {
                            // Als er west een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.buurWest.schaakstuk as Pion)._speler.enPassantPion = this;

                        }
                    }
                }
                else if (selected.buurOost != null)
                {
                    //en-passant slaan naar zuidoost
                    if (selected.buurZuidoost == nieuwVakje && speler.enPassantPion == selected.buurOost.schaakstuk && speler.enPassantPion != null)
                    {

                        selected.buurOost.schaakstuk = null; //De andere pion verdwijnt
                        selected.buurOost.pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                        mogelijk = true;

                    }
                }
                if (selected.buurWest != null)
                {
                    //en-passant slaan naar zuidwest
                    if (selected.buurZuidwest == nieuwVakje && speler.enPassantPion == selected.buurWest.schaakstuk && speler.enPassantPion != null)
                    {

                        selected.buurWest.schaakstuk = null; //De andere pion verdwijnt
                        selected.buurWest.pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                        mogelijk = true;

                    }
                }
            }

            if (mogelijk == true)
            {
                nieuwVakje.schaakstuk = this;
                selected.schaakstuk = null;
                this.vakje = nieuwVakje;
                bool checkSchaak = spel.schaakbord.CheckSchaak(speler.Koning);
                
                if (checkSchaak == true)
                {
                    selected.schaakstuk = this;
                    nieuwVakje.schaakstuk = null;
                    this.vakje = selected;
                }
                else
                {
                    _eersteZet = true;
                    speler.validezet = true;
                }

            }

            //De pion wil promoveren wanneer hij op de eerste of laatste rij komt te staan
            if (vakje.buurNoord == null || vakje.buurZuid == null)
            {
                nieuwVakje.pbox.update();
                selected.pbox.update();
                PromoveerForm promoveerform = new PromoveerForm(this, kleur);
                promoveerform.ShowDialog();
            }

        }

        public void Promoveert(string keuze)
        {
            if (keuze.Equals("paard"))
            {
                vakje.schaakstuk = new Paard(kleur, vakje, _speler);
            }
            else if (keuze.Equals("loper"))
            {
                vakje.schaakstuk = new Loper(kleur, vakje, _speler);
            }
            else if (keuze.Equals("toren"))
            {
                vakje.schaakstuk = new Toren(kleur, vakje, _speler);
            }
            else if (keuze.Equals("dame"))
            {
                vakje.schaakstuk = new Dame(kleur, vakje, _speler);
            }

        }
    }
}

