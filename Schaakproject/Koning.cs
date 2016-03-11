using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Koning : Schaakstuk
    {
        private bool _staatschaak { get; set; }

        private bool _eersteZet { get; set; }

        public Koning(string kleur, Vakje vakje)
        {
            this.kleur = kleur;
            this.vakje = vakje;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.KoningWit;
            }
            else
            {
                afbeelding = Properties.Resources.KoningZwart;
            }
        }

        public override void Verplaats(SpecialPB pictures, SpecialPB selected)
        {
            bool gevonden = false;
            if (selected.vakje.buurNoord == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurOost == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurZuid == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurWest == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurNoordoost == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurNoordwest == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurZuidoost == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurZuidwest == pictures.vakje)
            {
                gevonden = true;
            }

            if (gevonden == true)
            {
                pictures.vakje.schaakstuk = this;
                selected.vakje.schaakstuk = null;
                this.vakje = pictures.vakje;
            }
        }

        private void Rokeren()
        {
            throw new System.NotImplementedException();
        }
    }
}

