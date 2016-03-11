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

        public override void Verplaats(SpecialPB pictures, SpecialPB selected, Mens speler)
        {
            bool gevonden = false;
            if (selected.vakje.buurNoord != null && selected.vakje.buurNoord.buurNoord != null)
            {
                if (selected.vakje.buurNoord.buurNoord.buurOost == pictures.vakje)
                {
                    gevonden = true;
                }
                else if (selected.vakje.buurNoord.buurNoord.buurWest == pictures.vakje)
                {
                    gevonden = true;
                }
            }
            if (selected.vakje.buurOost != null && selected.vakje.buurOost.buurOost != null)
            {
                if (selected.vakje.buurOost.buurOost.buurNoord == pictures.vakje)
                {
                    gevonden = true;
                }
                else if (selected.vakje.buurOost.buurOost.buurZuid == pictures.vakje)
                {
                    gevonden = true;
                }
            }
            if (selected.vakje.buurZuid != null && selected.vakje.buurZuid.buurZuid != null)
            {
                if (selected.vakje.buurZuid.buurZuid.buurOost == pictures.vakje)
                {
                    gevonden = true;
                }
                else if (selected.vakje.buurZuid.buurZuid.buurWest == pictures.vakje)
                {
                    gevonden = true;
                }
            }
            if (selected.vakje.buurWest != null && selected.vakje.buurWest.buurWest != null)
            {
                if (selected.vakje.buurWest.buurWest.buurZuid == pictures.vakje)
                {
                    gevonden = true;
                }

                else if (selected.vakje.buurWest.buurWest.buurNoord == pictures.vakje)
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

