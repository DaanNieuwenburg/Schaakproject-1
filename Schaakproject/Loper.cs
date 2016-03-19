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
        public override void kanStukSlaan(Computer computer, SpecialPB geselecteerdStuk)
        {
            bool mogelijkloop = false;
            Vakje geselecteerdVak = geselecteerdStuk.vakje;
            Vakje volgendVakje = geselecteerdVak.buurNoord;

            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "zwart")
                    {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "wit")
                    {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                        volgendVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    }
                    volgendVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    volgendVakje = volgendVakje.buurNoord;
                }
            }


            mogelijkloop = false;
            geselecteerdVak = geselecteerdStuk.vakje;
            volgendVakje = geselecteerdStuk.vakje.buurOost;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "zwart")
                    {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "wit")
                    {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                        volgendVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    }
                    volgendVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    volgendVakje = volgendVakje.buurOost;
                }
            }

            mogelijkloop = false;
            geselecteerdVak = geselecteerdStuk.vakje;
            volgendVakje = geselecteerdStuk.vakje.buurZuid;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "zwart")
                    {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "wit")
                    {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                        volgendVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    }
                    volgendVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    volgendVakje = volgendVakje.buurZuid;
                }
            }

            mogelijkloop = false;
            geselecteerdVak = geselecteerdStuk.vakje;
            volgendVakje = geselecteerdStuk.vakje.buurWest;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "zwart")
                    {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "wit")
                    {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                        volgendVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    }
                    volgendVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    volgendVakje = volgendVakje.buurWest;
                }
            }
        }

        public override void Verplaats(SpecialPB pictures, SpecialPB selected, Mens speler)
        {
            bool mogelijk = false;
            bool mogelijkloop = false;
            Vakje vorige = selected.vakje;
            while (mogelijkloop == false)
            {
                if (vorige.buurNoordoost == pictures.vakje)
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
            vorige = selected.vakje;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurNoordwest == pictures.vakje)
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
            vorige = selected.vakje;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurZuidoost == pictures.vakje)
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
            vorige = selected.vakje;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurZuidwest == pictures.vakje)
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
                pictures.vakje.schaakstuk = this;
                selected.vakje.schaakstuk = null;
                this.vakje = pictures.vakje;
                speler.validezet = true;
            }
        }
    }
}

