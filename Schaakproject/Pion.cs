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

        public Pion(string kleur, Vakje vakje)
        {
            _magEnpassant = true;
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

        public override bool kanStukSlaan(Vakje geselecteerdStuk )
        {
            Vakje geselecteerdVak = geselecteerdStuk;
            if(geselecteerdVak.schaakstuk.kleur == "wit")
            {
                if (geselecteerdVak.buurNoordoost.schaakstuk != null && geselecteerdVak.buurNoordoost.schaakstuk.kleur != "wit")
                {
                    return true;
                }
                else if(geselecteerdVak.buurNoordwest.schaakstuk != null && geselecteerdVak.buurNoordoost.schaakstuk.kleur != "wit")
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

        public override void Verplaats(Vakje leegVakje, Vakje selected, Mens speler)
        {
           bool mogelijk = false;

            if (kleur == "wit")
            {
                // Witte pion een stapje naar voren
                if (selected.buurNoord == leegVakje && leegVakje.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // Slaan naar noordoost voor een witte pion
                else if (selected.buurNoordoost == leegVakje && leegVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Slaan naar noordwest voor een witte pion
                else if (selected.buurNoordwest == leegVakje && leegVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Twee stappen vooruit voor een witte pion
                else if (_eersteZet == false && selected.buurNoord.buurNoord == leegVakje && selected.buurNoord.buurNoord.schaakstuk == null && selected.buurNoord.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // En-passant voor een witte pion
                else if (_eersteZet == false)
                {
                    EnPassant(leegVakje, selected, speler);
                    _magEnpassant = false;
                }
            }
            
            else if (kleur == "zwart")
            {
                // Zwarte pion een stapje naar voren
                if (selected.buurZuid == leegVakje && leegVakje.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // Slaan naar zuidoost voor een zwarte pion
                else if (selected.buurZuidoost == leegVakje && kleur == "zwart" && leegVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Slaan naar zuidwest voor een zwarte pion
                else if (selected.buurZuidwest == leegVakje && leegVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Twee stappen vooruit voor een zwarte pion
                else if (_eersteZet == false && selected.buurZuid.buurZuid == leegVakje && selected.buurZuid.buurZuid.schaakstuk == null && selected.buurZuid.schaakstuk == null)
                {
                    mogelijk = true;
                }
                // En-passant voor een zwarte pion
                else if (_eersteZet == false)
                {
                    EnPassant(leegVakje, selected, speler);
                    _magEnpassant = false;
                }
            }

            if (mogelijk == true)
            {
                leegVakje.schaakstuk = this;
                selected.schaakstuk = null;
                this.vakje = leegVakje;
                _eersteZet = true;
                speler.validezet = true;
                
            }

                
            if (vakje.buurNoord == null || vakje.buurZuid == null)
            {
                leegVakje.pbox.update();
                selected.pbox.update();
                PromoveerForm promoveerform = new PromoveerForm(this, kleur);
                promoveerform.ShowDialog();
            }
           
        }

        private void EnPassant(Vakje leegVakje, Vakje selected, Mens speler)
        {
            if (kleur.Equals("wit"))
            {

                if (selected.buurNoord != null && selected.buurNoord.buurNoord != null)
                {
                    if (selected.buurNoord.buurNoord.buurOost == leegVakje && leegVakje.schaakstuk is Pion)
                    {
                        leegVakje.schaakstuk = this;
                        selected.schaakstuk = null;
                        _eersteZet = true;
                        speler.validezet = true;
                        this.vakje = leegVakje;
                    }
                    else if (selected.buurNoord.buurNoord.buurWest == leegVakje && leegVakje.schaakstuk is Pion)
                    {
                        leegVakje.schaakstuk = this;
                        selected.schaakstuk = null;
                        _eersteZet = true;
                        speler.validezet = true;
                        this.vakje = leegVakje;
                    }
                }
            }
            else
            {
                if (selected.buurZuid != null && selected.buurZuid.buurZuid != null)
                {
                    if (selected.buurZuid.buurZuid.buurOost == leegVakje && leegVakje.schaakstuk is Pion)
                    {
                        leegVakje.schaakstuk = this;
                        selected.schaakstuk = null;
                        _eersteZet = true;
                        speler.validezet = true;
                        this.vakje = leegVakje;
                    }
                    else if (selected.buurZuid.buurZuid.buurWest == leegVakje && leegVakje.schaakstuk is Pion)
                    {
                        leegVakje.schaakstuk = this;
                        selected.schaakstuk = null;
                        _eersteZet = true;
                        speler.validezet = true;
                        this.vakje = leegVakje;
                    }
                }
            }

        }

        public void Promoveert(string keuze)
        {
            if(keuze.Equals("paard"))
            {
                vakje.schaakstuk = new Paard(kleur, vakje);
            }
            else if(keuze.Equals("loper"))
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

