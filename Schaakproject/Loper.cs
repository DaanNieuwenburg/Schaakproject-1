using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Loper : Schaakstuk
    {
        public Loper(string kleur, Vakje vakje, Speler speler)
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
            Vakje volgendVakje = geselecteerdStuk.buurNoordwest;
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
                        Console.WriteLine("FOUND");
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
                        Console.WriteLine("FOUND");
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
                        Console.WriteLine("FOUND");
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
                        Console.WriteLine("FOUND");
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
        }

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Mens speler, Spel spel)
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
                bool checkSchaak = spel.schaakbord.CheckSchaak(speler.Koning);
                if (checkSchaak == true)
                {
                    selected.schaakstuk = this;
                    nieuwVakje.schaakstuk = null;
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

