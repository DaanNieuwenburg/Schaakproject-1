using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Schaakproject
{
    public class Dame : Schaakstuk
    {
        public Dame(string kleur, Vakje vakje)
        {
            this.vakje = vakje;
            this.kleur = kleur;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.DameWit;
            }
            else
            {
                afbeelding = Properties.Resources.DameZwart;
            }
        }
        public override void kanStukSlaan(Computer computer, Vakje geselecteerdStuk)
        {
            bool mogelijkloop = false;
            Vakje geselecteerdVak = geselecteerdStuk;
            Vakje volgendVakje = geselecteerdStuk.buurNoordwest;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    //volgendVakje = volgendVakje.buurNoord;
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "zwart")
                    {
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "wit")
                {
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
            }
                    volgendVakje = volgendVakje.buurNoordwest;
                }
            }

            mogelijkloop = false;
            geselecteerdVak = geselecteerdStuk;
            volgendVakje = geselecteerdStuk.buurNoordoost;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    //volgendVakje = volgendVakje.buurNoord;
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "zwart")
                    {
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "wit")
                {
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
            }
                    volgendVakje = volgendVakje.buurNoordoost;
                }
            }

            mogelijkloop = false;
            geselecteerdVak = geselecteerdStuk;
            volgendVakje = geselecteerdStuk.buurNoord;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    //volgendVakje = volgendVakje.buurNoord;
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "zwart")
                {
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "wit")
                {
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje == null)
                {
                    mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.buurNoord;
                }
            }

            mogelijkloop = false;
            geselecteerdVak = geselecteerdStuk;
            volgendVakje = geselecteerdStuk.buurWest;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    //volgendVakje = volgendVakje.buurNoord;
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "zwart")
                {
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "wit")
                {
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje == null)
                {
                    mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.buurWest;
                }
            }

            mogelijkloop = false;
            geselecteerdVak = geselecteerdStuk;
            volgendVakje = geselecteerdStuk.buurZuid;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    //volgendVakje = volgendVakje.buurNoord;
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "zwart")
                    {
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "wit")
                {
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                    volgendVakje = volgendVakje.buurZuid;
            }
            }

            mogelijkloop = false;
            geselecteerdVak = geselecteerdStuk;
            volgendVakje = geselecteerdStuk.buurZuidoost;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    //volgendVakje = volgendVakje.buurNoord;
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "zwart")
                {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "wit")
                {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje == null)
                {
                    mogelijkloop = true;
                        volgendVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    }
                    volgendVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    volgendVakje = volgendVakje.buurZuidoost;  
                }
            }

            mogelijkloop = false;
            geselecteerdVak = geselecteerdStuk;
            volgendVakje = geselecteerdStuk.buurZuidwest; ;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    //volgendVakje = volgendVakje.buurNoord;
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "zwart")
                {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "wit")
                {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje == null)
                {
                    mogelijkloop = true;
                        volgendVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    }
                    volgendVakje.pbox.BackColor = System.Drawing.Color.DeepPink;
                    volgendVakje = volgendVakje.buurZuidwest;
                }
            }

            geselecteerdVak = geselecteerdStuk;
            volgendVakje = geselecteerdStuk;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    //volgendVakje = volgendVakje.buurNoord;
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "zwart")
                    {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
                }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "wit")
                {
                        volgendVakje.pbox.BackColor = System.Drawing.Color.Black;
                    mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkhedenSpeler.Add(volgendVakje.pbox);
                        computer.slaanmogelijkhedenSpelerVanaf.Add(geselecteerdStuk.pbox);
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
        }
        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Mens speler)
        {
            bool mogelijk = false;
            bool mogelijkloop = false;
            Vakje vorige = selected;

            while (mogelijkloop == false)
            {
                if (vorige.buurNoord == nieuwVakje)
                {
                    mogelijk = true;
                    mogelijkloop = true;
                }
                else if (vorige.buurNoord == null || vorige.buurNoord.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurNoord;
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurOost == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;
                    }
                    else if (vorige.buurOost == null || vorige.buurOost.schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.buurOost;
                }
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurZuid == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;

                    }
                    else if (vorige.buurZuid == null || vorige.buurZuid.schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.buurZuid;
                }
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurWest == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;
                    }
                    else if (vorige.buurWest == null || vorige.buurWest.schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.buurWest;
                }
            }
            

            mogelijkloop = false;
            vorige = selected;
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

