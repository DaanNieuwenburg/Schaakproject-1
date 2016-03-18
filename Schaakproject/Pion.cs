using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Pion : Schaakstuk
    {
        private bool _eersteZet { get; set; }       //is de pion al eens verzet
        public Speler _speler { get; private set; }

        public Pion(string kleur, Vakje vakje)
        {
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

        public override bool kanStukSlaan(Vakje geselecteerdStuk)
        {
            Vakje geselecteerdVak = geselecteerdStuk;
            if (geselecteerdVak.schaakstuk.kleur == "wit")
            {
                if (geselecteerdVak.buurNoordoost.schaakstuk != null && geselecteerdVak.buurNoordoost.schaakstuk.kleur != "wit")
                {
                    return true;
                }
                else if (geselecteerdVak.buurNoordwest.schaakstuk != null && geselecteerdVak.buurNoordoost.schaakstuk.kleur != "wit")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (geselecteerdVak.buurNoordoost.schaakstuk != null && geselecteerdVak.buurNoordoost.schaakstuk.kleur != "zwart")
                {
                    return true;
                }
                else if (geselecteerdVak.buurNoordwest.schaakstuk != null && geselecteerdVak.buurNoordoost.schaakstuk.kleur != "zwart")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Mens speler)
        {
            if (_speler == null)
            {
                _speler = speler;
            }

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
                            // Als er oost een pion staat dan onthoudt de tegenstander dat hij deze pion met die pion mag slaan
                            (nieuwVakje.buurOost.schaakstuk as Pion)._speler.tegenstanderPion = this;
                            (nieuwVakje.buurOost.schaakstuk as Pion)._speler.mijnPassantPion = nieuwVakje.buurOost.schaakstuk as Pion;
                        }
                    }
                    if (nieuwVakje.buurWest != null)
                    {
                        if (nieuwVakje.buurWest.schaakstuk is Pion)
                        {
                            // Als er west een pion staat dan onthoudt de tegenstander dat hij deze pion met die pion mag slaan
                            (nieuwVakje.buurWest.schaakstuk as Pion)._speler.tegenstanderPion = this;
                            (nieuwVakje.buurWest.schaakstuk as Pion)._speler.mijnPassantPion2 = nieuwVakje.buurWest.schaakstuk as Pion;
                        }
                    }
                }
                else if (selected.buurOost != null)
                {
                    //en-passant slaan naar noordoost
                    if (selected.buurOost.schaakstuk is Pion && selected.buurNoordoost == nieuwVakje && selected.buurNoordoost.schaakstuk == null)
                    {
                        if (speler.mijnPassantPion2 == this && speler.tegenstanderPion == selected.buurOost.schaakstuk)
                        {
                            selected.buurOost.schaakstuk = null; //De andere pion verdwijnt
                            selected.buurOost.pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                            mogelijk = true;

                        }
                    }
                }
                if (selected.buurWest != null)
                {
                    //en-passant slaan naar noordwest
                    if (selected.buurWest.schaakstuk is Pion && selected.buurNoordwest == nieuwVakje && selected.buurNoordwest.schaakstuk == null)
                    {
                        if (speler.mijnPassantPion == this && speler.tegenstanderPion == selected.buurWest.schaakstuk)
                        {
                            selected.buurWest.schaakstuk = null; //De andere pion verdwijnt
                            selected.buurWest.pbox.update(); //update deze pbox zodat je de pion niet meer ziet
                            mogelijk = true;
                        }
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
                            // Als er oost een pion staat dan onthoudt de tegenstander dat hij deze pion met die pion mag slaan
                            (nieuwVakje.buurOost.schaakstuk as Pion)._speler.tegenstanderPion = this;
                            (nieuwVakje.buurOost.schaakstuk as Pion)._speler.mijnPassantPion = nieuwVakje.buurOost.schaakstuk as Pion;
                        }
                    }
                    if (nieuwVakje.buurWest != null)
                    {
                        if (nieuwVakje.buurWest.schaakstuk is Pion)
                        {
                            // Als er west een pion staat dan onthoudt de tegenstander dat hij deze pion met die pion mag slaan
                            (nieuwVakje.buurWest.schaakstuk as Pion)._speler.tegenstanderPion = this;
                            (nieuwVakje.buurWest.schaakstuk as Pion)._speler.mijnPassantPion2 = nieuwVakje.buurWest.schaakstuk as Pion;
                        }
                    }
                }
                else if (selected.buurOost != null)
                {
                    //en-passant slaan naar zuidoost
                    if (selected.buurOost.schaakstuk is Pion && selected.buurZuidoost == nieuwVakje && selected.buurZuidoost.schaakstuk == null)
                    {
                        if (speler.mijnPassantPion2 == this && speler.tegenstanderPion == selected.buurOost.schaakstuk)
                        {
                            selected.buurOost.schaakstuk = null; //De andere pion verdwijnt
                            selected.buurOost.pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                            mogelijk = true;
                        }
                    }
                }
                if (selected.buurWest != null)
                {
                    //en-passant slaan naar zuidwest
                    if (selected.buurWest.schaakstuk is Pion && selected.buurZuidwest == nieuwVakje && selected.buurZuidwest.schaakstuk == null)
                    {
                        if (speler.mijnPassantPion == this && speler.tegenstanderPion == selected.buurWest.schaakstuk)
                        {
                            selected.buurWest.schaakstuk = null; //De andere pion verdwijnt
                            selected.buurWest.pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                            mogelijk = true;
                        }
                    }
                }
            }

            if (mogelijk == true)
            {
                nieuwVakje.schaakstuk = this;
                selected.schaakstuk = null;
                this.vakje = nieuwVakje;
                _eersteZet = true;
                speler.validezet = true;

            }

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
                vakje.schaakstuk = new Paard(kleur, vakje);
            }
            else if (keuze.Equals("loper"))
            {
                vakje.schaakstuk = new Loper(kleur, vakje);
            }
            else if (keuze.Equals("toren"))
            {
                vakje.schaakstuk = new Toren(kleur, vakje);
            }
            else if (keuze.Equals("dame"))
            {
                vakje.schaakstuk = new Dame(kleur, vakje);
            }

        }
    }
}

