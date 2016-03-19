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
        public override void kanStukSlaan(Computer computer, SpecialPB geselecteerdStuk)
        {
            Vakje geselecteerdVak = geselecteerdStuk.vakje;
            if (geselecteerdVak.schaakstuk.kleur == "wit")
            {
                if (geselecteerdVak.buurNoord.buurNoordoost != null && geselecteerdVak.buurNoord.buurNoordoost.schaakstuk.kleur != "wit")
                {
                    computer.spelerkanslaan = true;
                }

                else if (geselecteerdVak.buurNoord.buurNoordwest != null && geselecteerdVak.buurNoord.buurNoordwest.schaakstuk.kleur != "wit")
                {
                    computer.spelerkanslaan = true;
                }

                else if (geselecteerdVak.buurZuid.buurZuidoost != null && geselecteerdVak.buurZuid.buurZuidoost.schaakstuk.kleur != "wit")
                {
                    computer.spelerkanslaan = true;
                }

                else if (geselecteerdVak.buurZuid.buurZuidwest != null && geselecteerdVak.buurZuid.buurZuidwest.schaakstuk.kleur != "wit")
                {
                    computer.spelerkanslaan = true;
                }
                else
                {
                    computer.spelerkanslaan = true;
                }
            }
            else
            {
                if (geselecteerdVak.buurNoord.buurNoordoost != null && geselecteerdVak.buurNoord.buurNoordoost.schaakstuk.kleur != "zwart")
                {
                    computer.computerkanslaan = true;
                }

                else if (geselecteerdVak.buurNoord.buurNoordwest != null && geselecteerdVak.buurNoord.buurNoordwest.schaakstuk.kleur != "zwart")
                {
                    computer.computerkanslaan = true;
                }

                else if (geselecteerdVak.buurZuid.buurZuidoost != null && geselecteerdVak.buurZuid.buurZuidoost.schaakstuk.kleur != "zwart")
                {
                    computer.computerkanslaan = true;
                }

                else if (geselecteerdVak.buurZuid.buurZuidwest != null && geselecteerdVak.buurZuid.buurZuidwest.schaakstuk.kleur != "zwart")
                {
                    computer.computerkanslaan = true;
                }
                else
                {
                    computer.computerkanslaan = true;
                }
            }
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

