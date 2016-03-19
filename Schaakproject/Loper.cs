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
        public override void kanStukSlaan(Computer computer, Vakje geselecteerdStuk)
        {
            bool mogelijkloop = false;
            Vakje geselecteerdVak = geselecteerdStuk;
            Vakje vorigVakje = geselecteerdStuk;
            while (mogelijkloop == false)
            {
                if (vorigVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "zwart")
                    {
                        vorigVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(vorigVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                    }
                    else if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "wit")
                    {
                        vorigVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(vorigVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                    }
                    else if (vorigVakje == null)
                    {
                        mogelijkloop = true;
                        vorigVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    }
                    vorigVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    vorigVakje = vorigVakje.buurNoord;
                }
            }

            geselecteerdVak = geselecteerdStuk;
            vorigVakje = geselecteerdStuk;
            while (mogelijkloop == false)
            {
                if (vorigVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "zwart")
                    {
                        vorigVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(vorigVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                    }
                    else if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "wit")
                    {
                        vorigVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(vorigVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                    }
                    else if (vorigVakje == null)
                    {
                        mogelijkloop = true;
                        vorigVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    }
                    vorigVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    vorigVakje = vorigVakje.buurOost;
                }
            }

            geselecteerdVak = geselecteerdStuk;
            vorigVakje = geselecteerdStuk;
            while (mogelijkloop == false)
            {
                if (vorigVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "zwart")
                    {
                        vorigVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(vorigVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                    }
                    else if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "wit")
                    {
                        vorigVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(vorigVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                    }
                    else if (vorigVakje == null)
                    {
                        mogelijkloop = true;
                        vorigVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    }
                    vorigVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    vorigVakje = vorigVakje.buurZuid;
                }
            }

            geselecteerdVak = geselecteerdStuk;
            vorigVakje = geselecteerdStuk;
            while (mogelijkloop == false)
            {
                if (vorigVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "zwart")
                    {
                        vorigVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(vorigVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                    }
                    else if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "wit")
                    {
                        vorigVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(vorigVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                    }
                    else if (vorigVakje == null)
                    {
                        mogelijkloop = true;
                        vorigVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    }
                    vorigVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    vorigVakje = vorigVakje.buurWest;
                }
            }
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

