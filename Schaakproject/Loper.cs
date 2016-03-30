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
            this.speler = speler;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.LoperWit;
            }
            else
            {
                afbeelding = Properties.Resources.LoperZwart;
            }
        }
        public override void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk)
        {
            loopStukSlaan("Noordwest", algoritme, geselecteerdStuk);
            loopStukSlaan("Noordoost", algoritme, geselecteerdStuk);
            loopStukSlaan("Zuidwest", algoritme, geselecteerdStuk);
            loopStukSlaan("Zuidoost", algoritme, geselecteerdStuk);
        }

        public void loopStukSlaan(string richting, Algoritme algoritme, Vakje geselecteerdStuk)
        {
            Vakje volgendVakje;
            if (richting == "Noordwest")
            {
                volgendVakje = geselecteerdStuk.buurNoordwest;
            }
            else if (richting == "Noordoost")
            {
                volgendVakje = geselecteerdStuk.buurNoordoost;
            }
            else if (richting == "Zuidwest")
            {
                volgendVakje = geselecteerdStuk.buurZuidwest;
            }
            else
            {
                volgendVakje = geselecteerdStuk.buurZuidoost;
            }

            bool mogelijkloop = false;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "wit")
                    {
                        mogelijkloop = true;
                        algoritme.slaanmogelijkheden.Add(volgendVakje);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.kleur == "zwart")
                    {
                        mogelijkloop = true;
                    }

                    if (richting == "Noordwest")
                    {
                        volgendVakje = volgendVakje.buurNoordwest;
                    }
                    else if (richting == "Noordoost")
                    {
                        volgendVakje = volgendVakje.buurNoordoost;
                    }
                    else if (richting == "Zuidwest")
                    {
                        volgendVakje = volgendVakje.buurZuidwest;
                    }
                    else
                    {
                        volgendVakje = volgendVakje.buurZuidoost;
                    }
                }
            }
        }

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Spel spel)
        {
            if (spel.spelerAanZet == spel.Speler1)
            {
                speler = spel.Speler1;
            }
            else if (spel.spelerAanZet == spel.Speler2)
            {
                speler = spel.Speler2;
            }
            else if (spel.SpelMode == "Singleplayer")
            {
                speler = spel.computerSpeler;
            }

            bool mogelijk = false;
            bool mogelijkloop = false;
            Vakje vorige = selected;
            while (mogelijkloop == false)
            {
                if (vorige.buurNoordoost == nieuwVakje)
                {
                    if (vorige.buurNoordoost.schaakstuk != null && vorige.buurNoordoost.schaakstuk.kleur != speler.Kleur)
                    {
                        spel.updateAantalStukken(spel.spelerAanZet);
                    }
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
                        if (vorige.buurNoordwest.schaakstuk != null && vorige.buurNoordwest.schaakstuk.kleur != speler.Kleur)
                        {
                            spel.updateAantalStukken(spel.spelerAanZet);
                        }
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
                        if (vorige.buurZuidoost.schaakstuk != null && vorige.buurZuidoost.schaakstuk.kleur != speler.Kleur)
                        {
                            spel.updateAantalStukken(spel.spelerAanZet);
                        }
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
                        if (vorige.buurZuidwest.schaakstuk != null && vorige.buurZuidwest.schaakstuk.kleur != speler.Kleur)
                        {
                            spel.updateAantalStukken(spel.spelerAanZet);
                        }
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
                bool checkSchaak = spel.schaakbord.CheckSchaak(speler.Koning.vakje, speler.Koning.kleur);
                if (checkSchaak == true)
                {
                    selected.schaakstuk = this;
                    nieuwVakje.schaakstuk = temp;
                    this.vakje = selected;
                }
                else
                {
                    if (temp != null)
                    {
                        temp.Slaan();
                    }
                    speler.validezet = true;
                }
            }
        }
    }
}

