using System;
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
            this.speler = speler;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.DameWit;
            }
            else
            {
                afbeelding = Properties.Resources.DameZwart;
            }
        }
        public override void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk)
        {
            loopStukSlaan("Noord", algoritme, geselecteerdStuk);
            loopStukSlaan("West", algoritme, geselecteerdStuk);
            loopStukSlaan("Zuid", algoritme, geselecteerdStuk);
            loopStukSlaan("Oost", algoritme, geselecteerdStuk);
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
            else if(richting == "buurOost")
            {
                volgendVakje = geselecteerdStuk.buurOost;
            }
            else if (richting == "Noordwest")
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
                    else if(richting == "Oost")
                    {
                        volgendVakje = volgendVakje.buurOost;
                    }
                    else if (richting == "Noordwest")
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

            bool mogelijk = false;
            bool mogelijkloop = false;
            Vakje vorige = selected;

            while (mogelijkloop == false)
            {
                if (vorige.buurNoord == nieuwVakje)
                {
                    if (vorige.buurNoord.schaakstuk != null && vorige.buurNoord.schaakstuk.kleur == "Wit")
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
                        if (vorige.buurOost.schaakstuk != null && vorige.buurOost.schaakstuk.kleur == "Wit")
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
                        if (vorige.buurZuid.schaakstuk != null && vorige.buurZuid.schaakstuk.kleur == "Wit")
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
                        if (vorige.buurWest.schaakstuk != null && vorige.buurWest.schaakstuk.kleur == "Wit")
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


            mogelijkloop = false;
            vorige = selected;
            while (mogelijkloop == false)
            {
                if (vorige.buurNoordoost == nieuwVakje)
                {
                    if (vorige.buurNoordoost.schaakstuk != null && vorige.buurNoordoost.schaakstuk.kleur == "Wit")
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
                        if (vorige.buurNoordwest.schaakstuk != null && vorige.buurNoordwest.schaakstuk.kleur == "Wit")
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
                        if (vorige.buurZuidoost.schaakstuk != null && vorige.buurZuidoost.schaakstuk.kleur == "Wit")
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
                        if (vorige.buurZuidwest.schaakstuk != null && vorige.buurZuidwest.schaakstuk.kleur == "Wit")
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
                bool checkSchaak = spel.schaakbord.CheckSchaak(spel.spelerAanZet.Koning.vakje, spel.spelerAanZet.Koning.kleur);
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
                    spel.spelerAanZet.validezet = true;
                }
            }
        }
    }
}

