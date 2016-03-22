﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Schaakproject
{
    public class Dame : Schaakstuk
    {
        public Dame(string kleur, Vakje vakje, Speler speler)
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
            Vakje volgendVakje = geselecteerdStuk.buurNoord;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur != geselecteerdStuk.schaakstuk.kleur)
                    {
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkheden.Add(volgendVakje);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.buurNoord;
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerdStuk.buurOost;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur != geselecteerdStuk.schaakstuk.kleur)
                    {
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkheden.Add(volgendVakje);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.buurOost;
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerdStuk.buurZuid;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur != geselecteerdStuk.schaakstuk.kleur)
                    {
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkheden.Add(volgendVakje);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.buurZuid;
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerdStuk.buurWest;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur != geselecteerdStuk.schaakstuk.kleur)
                    {
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkheden.Add(volgendVakje);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.buurWest;
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerdStuk.buurNoordoost;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur != geselecteerdStuk.schaakstuk.kleur)
                    {
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkheden.Add(volgendVakje);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.buurNoordoost;
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerdStuk.buurNoordwest;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur != geselecteerdStuk.schaakstuk.kleur)
                    {
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkheden.Add(volgendVakje);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.buurNoordwest;
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerdStuk.buurZuidoost;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur != geselecteerdStuk.schaakstuk.kleur)
                    {
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkheden.Add(volgendVakje);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.buurZuidoost;
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerdStuk.buurZuidwest;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur != geselecteerdStuk.schaakstuk.kleur)
                    {
                        mogelijkloop = true;
                        computer.spelerkanslaan = true;
                        computer.slaanmogelijkheden.Add(volgendVakje);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.buurZuidwest;
                }
            }
        }

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Mens speler, Spel spel)
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
                Schaakstuk temp = nieuwVakje.schaakstuk;
                nieuwVakje.schaakstuk = this;                
                selected.schaakstuk = null;
                this.vakje = nieuwVakje;
                bool checkSchaak = spel.schaakbord.CheckSchaak(speler.Koning);
                if (checkSchaak == true)
                {
                    selected.schaakstuk = this;
                    nieuwVakje.schaakstuk = temp;
                    this.vakje = selected;
                }
                else
                {
                    speler.validezet = true;
                }
            }
        }
    }
}

