using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Schaakproject
{
    public class Toren : Schaakstuk
    {
        public bool _eersteZet { get; private set; } // Is de toren al eens verzet

        public Toren(string kleur, Vakje vakje, Speler speler)
        {

            this.kleur = kleur;
            this.vakje = vakje;
            this.speler = speler;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.TorenWit;
            }
            else
            {
                afbeelding = Properties.Resources.TorenZwart;
            }
        }

        public override void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk)
        {
            if (geselecteerdStuk.schaakstuk.kleur == "Zwart")
            {
                loopStukSlaan("Noord", algoritme, geselecteerdStuk);
                loopStukSlaan("West", algoritme, geselecteerdStuk);
                loopStukSlaan("Zuid", algoritme, geselecteerdStuk);
                loopStukSlaan("Oost", algoritme, geselecteerdStuk);
            }
        }

        public void loopStukSlaan(string richting, Algoritme algoritme, Vakje geselecteerdStuk)
        {
            Vakje volgendVakje;
            if (richting == "Noord")
            {
                volgendVakje = geselecteerdStuk.buurNoord;
            }
            else if (richting == "West")
            {
                volgendVakje = geselecteerdStuk.buurWest;
            }
            else if (richting == "Zuid")
            {
                volgendVakje = geselecteerdStuk.buurZuid;
            }
            else
            {
                volgendVakje = geselecteerdStuk.buurOost;
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

                    if (richting == "Noord")
                    {
                        volgendVakje = volgendVakje.buurNoord;
                    }
                    else if (richting == "West")
                    {
                        volgendVakje = volgendVakje.buurWest;
                    }
                    else if (richting == "Zuid")
                    {
                        volgendVakje = volgendVakje.buurZuid;
                    }
                    else
                    {
                        volgendVakje = volgendVakje.buurOost;
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
                if (vorige.buurNoord == nieuwVakje)
                {
                    if (vorige.buurNoord.schaakstuk != null && vorige.buurNoord.schaakstuk.kleur != speler.Kleur)
                    {
                        spel.updateAantalStukken(spel.spelerAanZet);
                    }
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
                        if (vorige.buurOost.schaakstuk != null && vorige.buurOost.schaakstuk.kleur != speler.Kleur)
                        {
                            spel.updateAantalStukken(spel.spelerAanZet);
                        }
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
                        if (vorige.buurZuid.schaakstuk != null && vorige.buurZuid.schaakstuk.kleur != speler.Kleur)
                        {
                            spel.updateAantalStukken(spel.spelerAanZet);
                        }
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
                        if (vorige.buurWest.schaakstuk != null && vorige.buurWest.schaakstuk.kleur != speler.Kleur)
                        {
                            spel.updateAantalStukken(spel.spelerAanZet);
                        }
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
                    _eersteZet = true;
                }
            }
        }
    }
}

