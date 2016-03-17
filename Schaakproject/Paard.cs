using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Paard : Schaakstuk
    {
        public Paard(string kleur, Vakje vakje)
        {
            this.vakje = vakje;
            this.kleur = kleur;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.PaardWit;
            }
            else
            {
                afbeelding = Properties.Resources.PaardZwart;
            }
        }
        public override bool kanStukSlaan(SpecialPB geselecteerdStuk)
        {
            return false;
        }
        public override void Verplaats(SpecialPB pictures, SpecialPB selected, Mens speler)
        {
            bool gevonden = false;
            if (selected.vakje.buurNoord != null)
            {
                if (selected.vakje.buurNoord.buurNoordoost == pictures.vakje)
                {
                    gevonden = true;
                }
                else if (selected.vakje.buurNoord.buurNoordwest == pictures.vakje)
                {
                    gevonden = true;
                }
            }
            if (selected.vakje.buurOost != null)
            {
                if (selected.vakje.buurOost.buurNoordoost == pictures.vakje)
                {
                    gevonden = true;
                }
                else if (selected.vakje.buurOost.buurZuidoost == pictures.vakje)
                {
                    gevonden = true;
                }
            }
            if (selected.vakje.buurZuid != null)
            {
                if (selected.vakje.buurZuid.buurZuidoost == pictures.vakje)
                {
                    gevonden = true;
                }
                else if (selected.vakje.buurZuid.buurZuidwest == pictures.vakje)
                {
                    gevonden = true;
                }
            }
            if (selected.vakje.buurWest != null)
            {
                if (selected.vakje.buurWest.buurZuidwest == pictures.vakje)
                {
                    gevonden = true;
                }

                else if (selected.vakje.buurWest.buurNoordwest == pictures.vakje)
                {
                    gevonden = true;
                }
            }

            if (gevonden == true)
            {
                pictures.vakje.schaakstuk = this;
                selected.vakje.schaakstuk = null;
                this.vakje = pictures.vakje;
                speler.validezet = true;
            }
        }
    }
}

