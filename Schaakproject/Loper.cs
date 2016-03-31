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
            this.Kleur = kleur;
            this.Vakje = vakje;
            this.Speler = speler;
            if (kleur == "wit")
            {
                Afbeelding = Properties.Resources.LoperWit;
            }
            else
            {
                Afbeelding = Properties.Resources.LoperZwart;
            }
        }
        public override void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk)
        {
            if (geselecteerdStuk.schaakstuk.Kleur == "zwart")
            {
                // Kijkt of er noordwest geslagen kan worden
                bool mogelijkloop = false;
                Vakje volgendVakje = geselecteerdStuk.BuurNoordWest;
                while (mogelijkloop == false)
                {
                    if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                    }
                    else
                    {
                        if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "wit")
                        {
                            mogelijkloop = true;
                            algoritme.slaanmogelijkheden.Add(volgendVakje);
                            algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                        }
                        else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "zwart")
                        {
                            mogelijkloop = true;
                        }
                        volgendVakje = volgendVakje.BuurNoordWest;
                    }
                }

                // Kijkt of er noordoost geslagen kan worden
                mogelijkloop = false;
                volgendVakje = geselecteerdStuk.BuurNoordoost;
                while (mogelijkloop == false)
                {
                    if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                    }
                    else
                    {
                        if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "wit")
                        {
                            mogelijkloop = true;
                            algoritme.slaanmogelijkheden.Add(volgendVakje);
                            algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                        }
                        else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "zwart")
                        {
                            mogelijkloop = true;
                        }
                        volgendVakje = volgendVakje.BuurNoordoost;
                    }
                }

                // Kijkt of er Zuidwest geslagen kan worden
                mogelijkloop = false;
                volgendVakje = geselecteerdStuk.BuurZuidWest;
                while (mogelijkloop == false)
                {
                    if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                    }
                    else
                    {
                        if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "wit")
                        {
                            mogelijkloop = true;
                            algoritme.slaanmogelijkheden.Add(volgendVakje);
                            algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                        }
                        else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "zwart")
                        {
                            mogelijkloop = true;
                        }
                        volgendVakje = volgendVakje.BuurZuidWest;
                    }
                }

                // Kijkt of er Zuidoost geslagen kan worden
                mogelijkloop = false;
                volgendVakje = geselecteerdStuk.BuurZuidOost;
                while (mogelijkloop == false)
                {
                    if (volgendVakje == null)
                    {
                        mogelijkloop = true;
                    }
                    else
                    {
                        if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "wit")
                        {
                            mogelijkloop = true;
                            algoritme.slaanmogelijkheden.Add(volgendVakje);
                            algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                        }
                        else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "zwart")
                        {
                            mogelijkloop = true;
                        }
                        volgendVakje = volgendVakje.BuurZuidOost;
                    }
                }
            }
        }

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Spel spel)
        {
            if (spel.SpelerAanZet == spel.Speler1)
            {
                Speler = spel.Speler1;
            }
            else if (spel.SpelerAanZet == spel.Speler2)
            {
                Speler = spel.Speler2;
            }
            else if (spel.SpelMode == "Singleplayer")
            {
                Speler = spel.ComputerSpeler;
            }

            bool mogelijk = false;
            bool mogelijkloop = false;
            Vakje vorige = selected;
            while (mogelijkloop == false)
            {
                if (vorige.BuurNoordoost == nieuwVakje)
                {                    
                    mogelijk = true;
                    mogelijkloop = true;
                }
                else if (vorige.BuurNoordoost == null || vorige.BuurNoordoost.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.BuurNoordoost;
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.BuurNoordWest == nieuwVakje)
                    {                        
                        mogelijk = true;
                        mogelijkloop = true;
                    }
                    else if (vorige.BuurNoordWest == null || vorige.BuurNoordWest.schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.BuurNoordWest;
                }
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.BuurZuidOost == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;

                    }
                    else if (vorige.BuurZuidOost == null || vorige.BuurZuidOost.schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.BuurZuidOost;
                }
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.BuurZuidWest == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;
                    }
                    else if (vorige.BuurZuidWest == null || vorige.BuurZuidWest.schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.BuurZuidWest;

                }
            }
            if (mogelijk == true)
            {
                Schaakstuk temp = nieuwVakje.schaakstuk;
                nieuwVakje.schaakstuk = this;
                selected.schaakstuk = null;
                this.Vakje = nieuwVakje;
                bool checkSchaak = spel.schaakbord.CheckSchaak(Speler.koning.Vakje, Speler.koning.Kleur);
                if (checkSchaak == true)
                {
                    selected.schaakstuk = this;
                    nieuwVakje.schaakstuk = temp;
                    this.Vakje = selected;
                }
                else
                {
                    if (temp != null)
                    {
                        spel.updateAantalStukken(spel.SpelerAanZet);
                        temp.Slaan();
                    }
                    Speler.ValideZet = true;
                }
            }
        }
    }
}

