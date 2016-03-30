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
            if (geselecteerdStuk.schaakstuk.kleur == "zwart")
            {
                // Kijkt of er noordwest geslagen kan worden
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
                        volgendVakje = volgendVakje.buurNoordwest;
                    }
                }

                // Kijkt of er noordoost geslagen kan worden
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
                        volgendVakje = volgendVakje.buurNoordoost;
                    }
                }

                // Kijkt of er Zuidwest geslagen kan worden
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
                        volgendVakje = volgendVakje.buurZuidwest;
                    }
                }

                // Kijkt of er Zuidoost geslagen kan worden
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
                        volgendVakje = volgendVakje.buurZuidoost;
                    }
                }

                // Kijkt of er Noord geslagen kan worden
                mogelijkloop = false;
                volgendVakje = geselecteerdStuk.buurNoord;
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
                        volgendVakje = volgendVakje.buurNoord;
                    }
                }

                // Kijkt of er West geslagen kan worden
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
                        volgendVakje = volgendVakje.buurWest;
                    }
                }

                // Kijkt of er Zuid geslagen kan worden
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
                        volgendVakje = volgendVakje.buurZuid;
                    }
                }


                // Kijkt of er Oost geslagen kan worden
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
                        volgendVakje = volgendVakje.buurOost;
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


            mogelijkloop = false;
            vorige = selected;
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

