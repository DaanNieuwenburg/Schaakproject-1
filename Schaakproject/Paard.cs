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
        public override bool kanStukSlaan(Vakje geselecteerdStuk)
        {
            return false;
        }
        public override void Verplaats(Vakje leegVakje, Vakje selected, Mens speler)
        {
            bool gevonden = false;
            if (selected.buurNoord != null)
            {
                if (selected.buurNoord.buurNoordoost == leegVakje)
                {
                    gevonden = true;
                }
                else if (selected.buurNoord.buurNoordwest == leegVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.buurOost != null)
            {
                if (selected.buurOost.buurNoordoost == leegVakje)
                {
                    gevonden = true;
                }
                else if (selected.buurOost.buurZuidoost == leegVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.buurZuid != null)
            {
                if (selected.buurZuid.buurZuidoost == leegVakje)
                {
                    gevonden = true;
                }
                else if (selected.buurZuid.buurZuidwest == leegVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.buurWest != null)
            {
                if (selected.buurWest.buurZuidwest == leegVakje)
                {
                    gevonden = true;
                }

                else if (selected.buurWest.buurNoordwest == leegVakje)
                {
                    gevonden = true;
                }
            }

            if (gevonden == true)
            {
                leegVakje.schaakstuk = this;
                selected.schaakstuk = null;
                this.vakje = leegVakje;
                speler.validezet = true;
            }
        }
    }
}

