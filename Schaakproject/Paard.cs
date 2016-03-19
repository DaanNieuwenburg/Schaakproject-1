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
        public override void kanStukSlaan(Computer computer, Vakje geselecteerdStuk)
        {
            Vakje geselecteerdVak = geselecteerdStuk;
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

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Mens speler)
        {
            bool gevonden = false;
            if (selected.buurNoord != null)
            {
                if (selected.buurNoord.buurNoordoost == nieuwVakje)
                {
                    gevonden = true;
                }
                else if (selected.buurNoord.buurNoordwest == nieuwVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.buurOost != null)
            {
                if (selected.buurOost.buurNoordoost == nieuwVakje)
                {
                    gevonden = true;
                }
                else if (selected.buurOost.buurZuidoost == nieuwVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.buurZuid != null)
            {
                if (selected.buurZuid.buurZuidoost == nieuwVakje)
                {
                    gevonden = true;
                }
                else if (selected.buurZuid.buurZuidwest == nieuwVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.buurWest != null)
            {
                if (selected.buurWest.buurZuidwest == nieuwVakje)
                {
                    gevonden = true;
                }

                else if (selected.buurWest.buurNoordwest == nieuwVakje)
                {
                    gevonden = true;
                }
            }

            if (gevonden == true)
            {
                nieuwVakje.schaakstuk = this;
                selected.schaakstuk = null;
                this.vakje = nieuwVakje;
                speler.validezet = true;
            }
        }
    }
}

