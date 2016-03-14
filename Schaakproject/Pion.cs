using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Pion : Schaakstuk
    {
        private bool _eersteZet { get; set; }

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

        public override void Verplaats(SpecialPB pictures, SpecialPB selected, Mens speler)
        {
            if (kleur == "wit")
            {
                if (_eersteZet == false)
                {
                    // Twee stappen vooruit
                    if (selected.vakje.buurNoord.buurNoord == pictures.vakje && selected.vakje.buurNoord.buurNoord.schaakstuk == null && selected.vakje.buurNoord.schaakstuk == null)
                    {
                        pictures.vakje.schaakstuk = this;
                        selected.vakje.schaakstuk = null;
                        _eersteZet = true;
                        speler.validezet = true;
                    }
                }

                // Iets anders
                if (selected.vakje.buurNoordoost == pictures.vakje && kleur == "wit" && pictures.vakje.schaakstuk != null)
                {
                    pictures.vakje.schaakstuk = this;
                    selected.vakje.schaakstuk = null;
                    _eersteZet = true;
                    speler.validezet = true;
                }

                // Pion naar voren na eerste zet
                else if (selected.vakje.buurNoord == pictures.vakje && pictures.vakje.schaakstuk == null)
                {
                    pictures.vakje.schaakstuk = this;
                    selected.vakje.schaakstuk = null;
                    _eersteZet = true;
                    speler.validezet = true;
                }

                // Iets anders
                else if (selected.vakje.buurNoordwest == pictures.vakje && pictures.vakje.schaakstuk != null)
                {
                    pictures.vakje.schaakstuk = this;
                    selected.vakje.schaakstuk = null;
                    _eersteZet = true;
                    speler.validezet = true;
                }
            }

            else if (kleur == "zwart")
            {
                if (_eersteZet == false)
                {
                    // Twee stappen vooruit
                    if (selected.vakje.buurZuid.buurZuid == pictures.vakje && selected.vakje.buurZuid.buurZuid.schaakstuk == null && selected.vakje.buurZuid.schaakstuk == null)
                    {
                        pictures.vakje.schaakstuk = this;
                        selected.vakje.schaakstuk = null;
                        _eersteZet = true;
                        speler.validezet = true;
                    }
                }

                // Iets anders
                if (selected.vakje.buurZuidoost == pictures.vakje && kleur == "zwart" && pictures.vakje.schaakstuk != null)
                {
                    pictures.vakje.schaakstuk = this;
                    selected.vakje.schaakstuk = null;
                    _eersteZet = true;
                    speler.validezet = true;
                }

                // Pion naar voren na eerste zet
                else if (selected.vakje.buurZuid == pictures.vakje && pictures.vakje.schaakstuk == null)
                {
                    pictures.vakje.schaakstuk = this;
                    selected.vakje.schaakstuk = null;
                    this.vakje = pictures.vakje;
                    _eersteZet = true;
                    speler.validezet = true;
                }

                // Iets anders
                else if (selected.vakje.buurZuidwest == pictures.vakje && pictures.vakje.schaakstuk != null)
                {
                    pictures.vakje.schaakstuk = this;
                    selected.vakje.schaakstuk = null;
                    _eersteZet = true;
                    speler.validezet = true;
                }
            }

        }

        private void EnPassant()
        {
            throw new System.NotImplementedException();
        }

        private void Promoveert()
        {

        }
    }
}

