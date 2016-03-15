using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Pion : Schaakstuk
    {
        private bool _eersteZet { get; set; }
        private bool _magEnpassant { get; set; }
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

        public override void Verplaats(SpecialPB pictures, SpecialPB selected, Mens speler)
        {
           bool mogelijk = false;

            if (kleur == "wit")
            {
                // Witte pion een stapje naar voren
                if (selected.vakje.buurNoord == pictures.vakje && pictures.vakje.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // Slaan naar noordoost voor een witte pion
                else if (selected.vakje.buurNoordoost == pictures.vakje && pictures.vakje.schaakstuk != null)
                {
                    mogelijk = true;
                    
                }

                // Slaan naar noordwest voor een witte pion
                else if (selected.vakje.buurNoordwest == pictures.vakje && pictures.vakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Twee stappen vooruit voor een witte pion
                else if (_eersteZet == false && selected.vakje.buurNoord.buurNoord == pictures.vakje && selected.vakje.buurNoord.buurNoord.schaakstuk == null && selected.vakje.buurNoord.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // En-passant voor een witte pion
                else if (_eersteZet == false)
                {
                    EnPassant(pictures, selected, speler);
                    _magEnpassant = false;
                }
            }
            
            else if (kleur == "zwart")
            {
                // Zwarte pion een stapje naar voren
                if (selected.vakje.buurZuid == pictures.vakje && pictures.vakje.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // Slaan naar zuidoost voor een zwarte pion
                else if (selected.vakje.buurZuidoost == pictures.vakje && kleur == "zwart" && pictures.vakje.schaakstuk != null)
                {
                    mogelijk = true;
                    
                }

                // Slaan naar zuidwest voor een zwarte pion
                else if (selected.vakje.buurZuidwest == pictures.vakje && pictures.vakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Twee stappen vooruit voor een zwarte pion
                else if (_eersteZet == false && selected.vakje.buurZuid.buurZuid == pictures.vakje && selected.vakje.buurZuid.buurZuid.schaakstuk == null && selected.vakje.buurZuid.schaakstuk == null)
                {
                    mogelijk = true;
                }
                // En-passant voor een zwarte pion
                else if (_eersteZet == false)
                {
                    EnPassant(pictures, selected, speler);
                    _magEnpassant = false;
                }
            }

            if (mogelijk == true)
            {
                pictures.vakje.schaakstuk = this;
                selected.vakje.schaakstuk = null;
                this.vakje = pictures.vakje;
                _eersteZet = true;
                speler.validezet = true;
            }

                
            if (vakje.buurNoord == null || vakje.buurZuid == null)
            {
                PromoveerForm promoveerform = new PromoveerForm(this, kleur);
                promoveerform.ShowDialog();
            }
           
        }

        private void EnPassant(SpecialPB pictures, SpecialPB selected, Mens speler)
        {
            if (kleur.Equals("wit"))
            {

                if (selected.vakje.buurNoord != null && selected.vakje.buurNoord.buurNoord != null)
                {
                    if (selected.vakje.buurNoord.buurNoord.buurOost == pictures.vakje && pictures.vakje.schaakstuk is Pion)
                    {
                        pictures.vakje.schaakstuk = this;
                        selected.vakje.schaakstuk = null;
                        _eersteZet = true;
                        speler.validezet = true;
                        this.vakje = pictures.vakje;
                    }
                    else if (selected.vakje.buurNoord.buurNoord.buurWest == pictures.vakje && pictures.vakje.schaakstuk is Pion)
                    {
                        pictures.vakje.schaakstuk = this;
                        selected.vakje.schaakstuk = null;
                        _eersteZet = true;
                        speler.validezet = true;
                        this.vakje = pictures.vakje;
                    }
                }
            }
            else
            {
                if (selected.vakje.buurZuid != null && selected.vakje.buurZuid.buurZuid != null)
                {
                    if (selected.vakje.buurZuid.buurZuid.buurOost == pictures.vakje && pictures.vakje.schaakstuk is Pion)
                    {
                        pictures.vakje.schaakstuk = this;
                        selected.vakje.schaakstuk = null;
                        _eersteZet = true;
                        speler.validezet = true;
                        this.vakje = pictures.vakje;
                    }
                    else if (selected.vakje.buurZuid.buurZuid.buurWest == pictures.vakje && pictures.vakje.schaakstuk is Pion)
                    {
                        pictures.vakje.schaakstuk = this;
                        selected.vakje.schaakstuk = null;
                        _eersteZet = true;
                        speler.validezet = true;
                        this.vakje = pictures.vakje;
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

