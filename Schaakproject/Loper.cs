using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Loper : Schaakstuk
    {
        public Loper(string kleur, Vakje vakje)
        {
            this.kleur = kleur;
            this.vakje = vakje;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.LoperWit;
            }
            else
            {
                afbeelding = Properties.Resources.LoperZwart;
            }
        }
        public override bool kanStukSlaan(Vakje geselecteerdStuk)
        {
            bool mogelijkloop = false;
            bool kanSlaan = false;
            Vakje geselecteerdVak = geselecteerdStuk;
            Vakje vorigVakje = geselecteerdStuk;
            while (mogelijkloop == false)
            {
                if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "wit")
                {
                    mogelijkloop = true;
                    kanSlaan = true;
                }
                else if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "zwart")
                {
                    mogelijkloop = true;
                    kanSlaan = true;
                }
                else if (vorigVakje == null)
                {
                    mogelijkloop = true;
                    return false;
                }
                vorigVakje = vorigVakje.buurNoordoost;
            }

            geselecteerdVak = geselecteerdStuk;
            vorigVakje = geselecteerdStuk;
            while (mogelijkloop == false)
            {
                if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "wit")
                {
                    mogelijkloop = true;
                    kanSlaan = true;
                }
                else if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "zwart")
                {
                    mogelijkloop = true;
                    kanSlaan = true;
                }
                else if (vorigVakje == null)
                {
                    mogelijkloop = true;
                    return false;
                }
                vorigVakje = vorigVakje.buurNoordwest;
            }

            geselecteerdVak = geselecteerdStuk;
            vorigVakje = geselecteerdStuk;
            while (mogelijkloop == false)
            {
                if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "wit")
                {
                    mogelijkloop = true;
                    kanSlaan = true;
                }
                else if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "zwart")
                {
                    mogelijkloop = true;
                    kanSlaan = true;
                }
                else if (vorigVakje == null)
                {
                    mogelijkloop = true;
                    return false;
                }
                vorigVakje = vorigVakje.buurZuidoost;
            }

            geselecteerdVak = geselecteerdStuk;
            vorigVakje = geselecteerdStuk;
            while (mogelijkloop == false)
            {
                if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "wit")
                {
                    mogelijkloop = true;
                    kanSlaan = true;
                }
                else if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "zwart")
                {
                    mogelijkloop = true;
                    kanSlaan = true;
                }
                else if (vorigVakje == null)
                {
                    mogelijkloop = true;
                    return false;
                }
                vorigVakje = vorigVakje.buurZuidwest;
            }
            return kanSlaan;
        }

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Mens speler)
        {
            bool mogelijk = false;
            bool mogelijkloop = false;
            Vakje vorige = selected;
            while (mogelijkloop == false)
            {
                if (vorige.buurNoordoost == nieuwVakje)
                {
                    mogelijk = true;
                    mogelijkloop = true;
                }
                else if (vorige.buurNoordoost == null || vorige.buurNoordoost.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurNoordoost;
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurNoordwest == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;
                    }
                    else if (vorige.buurNoordwest == null || vorige.buurNoordwest.schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.buurNoordwest;
                }
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurZuidoost == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;

                    }
                    else if (vorige.buurZuidoost == null || vorige.buurZuidoost.schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.buurZuidoost;
                }
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurZuidwest == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;
                    }
                    else if (vorige.buurZuidwest == null || vorige.buurZuidwest.schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.buurZuidwest;

                }
            }
            if (mogelijk == true)
            {
                nieuwVakje.schaakstuk = this;
                selected.schaakstuk = null;
                this.vakje = nieuwVakje;
                speler.validezet = true;
            }
        }
    }
}

