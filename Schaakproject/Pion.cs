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

        public override void Verplaats(SpecialPB pictures, SpecialPB selected)
        {
            if (_eersteZet == false)
            {
                if (selected.vakje.buurNoord.buurNoord == pictures.vakje && selected.vakje.buurNoord.schaakstuk == null)
                {
                    pictures.vakje.schaakstuk = this;
                    selected.vakje.schaakstuk = null;
                    _eersteZet = true;
                }
                else if (selected.vakje.buurZuid.buurZuid == pictures.vakje && selected.vakje.buurZuid.schaakstuk == null)
                {
                    pictures.vakje.schaakstuk = this;
                    selected.vakje.schaakstuk = null;
                    _eersteZet = true;
                }
            }
            if (selected.vakje.buurNoord == pictures.vakje)
            {
                pictures.vakje.schaakstuk = this;
                selected.vakje.schaakstuk = null;
                _eersteZet = true;
            }
            else if (selected.vakje.buurZuid == pictures.vakje)
            {
                pictures.vakje.schaakstuk = this;
                selected.vakje.schaakstuk = null;
                this.vakje = pictures.vakje;
                _eersteZet = true;
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

