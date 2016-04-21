using System;

namespace Schaakproject
{
    public class Dame : Schaakstuk
    {
        public Dame(string kleur, Vakje vakje, Speler speler)
        {
            this.Vakje = vakje;
            this.Kleur = kleur;
            this.Speler = speler;
            if (kleur == "wit")
            {
                Afbeelding = Properties.Resources.DameWit;
            }
            else
            {
                Afbeelding = Properties.Resources.DameZwart;
            }
        }
        public override void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk)
        {
            // Deze methode kijkt vanuit de computer of er een dame geslagen kan worden.
            if (geselecteerdStuk.schaakstuk.Kleur == "zwart")
            {
                // Kijkt of er noordwest geslagen kan worden
                bool mogelijkloop = false;
                Vakje volgendVakje = geselecteerdStuk.Buren[7];
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
                        volgendVakje = volgendVakje.Buren[7];
                    }
                }

                // Kijkt of er noordoost geslagen kan worden
                mogelijkloop = false;
                volgendVakje = geselecteerdStuk.Buren[4];
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
                        volgendVakje = volgendVakje.Buren[4];
                    }
                }

                // Kijkt of er Zuidwest geslagen kan worden
                mogelijkloop = false;
                volgendVakje = geselecteerdStuk.Buren[6];
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
                        volgendVakje = volgendVakje.Buren[6];
                    }
                }

                // Kijkt of er Zuidoost geslagen kan worden
                mogelijkloop = false;
                volgendVakje = geselecteerdStuk.Buren[5];
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
                        volgendVakje = volgendVakje.Buren[5];
                    }
                }

                // Kijkt of er Noord geslagen kan worden
                mogelijkloop = false;
                volgendVakje = geselecteerdStuk.Buren[0];
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
                        volgendVakje = volgendVakje.Buren[0];
                    }
                }

                // Kijkt of er West geslagen kan worden
                mogelijkloop = false;
                volgendVakje = geselecteerdStuk.Buren[3];
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
                        volgendVakje = volgendVakje.Buren[3];
                    }
                }

                // Kijkt of er Zuid geslagen kan worden
                mogelijkloop = false;
                volgendVakje = geselecteerdStuk.Buren[2];
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
                        volgendVakje = volgendVakje.Buren[2];
                    }
                }


                // Kijkt of er Oost geslagen kan worden
                mogelijkloop = false;
                volgendVakje = geselecteerdStuk.Buren[1];
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
                        volgendVakje = volgendVakje.Buren[1];
                    }
                }
            }
        }

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Spel spel)
        {

            bool mogelijk = false;
            bool mogelijkloop = false;
            Vakje vorige = selected;

            //Kijk of het schaakstuk het geselecteerde vakje kan vinden,
            //door alle vakjes waar heen bewogen mag worden te vergelijken met het geselecteerde vakje
            while (mogelijkloop == false)
            {
                if (vorige.Buren[0] == nieuwVakje)
                {
                    mogelijk = true;
                    mogelijkloop = true;
                }
                else if (vorige.Buren[0] == null || vorige.Buren[0].schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.Buren[0];
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.Buren[1] == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;
                    }
                    else if (vorige.Buren[1] == null || vorige.Buren[1].schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.Buren[1];
                }
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.Buren[2] == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;
                    }
                    else if (vorige.Buren[2] == null || vorige.Buren[2].schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.Buren[2];
                }
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.Buren[3] == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;
                    }
                    else if (vorige.Buren[3] == null || vorige.Buren[3].schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.Buren[3];
                }
            }


            mogelijkloop = false;
            vorige = selected;
            while (mogelijkloop == false)
            {
                if (vorige.Buren[4] == nieuwVakje)
                {
                    mogelijk = true;
                    mogelijkloop = true;
                }
                else if (vorige.Buren[4] == null || vorige.Buren[4].schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.Buren[4];
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.Buren[7] == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;
                    }
                    else if (vorige.Buren[7] == null || vorige.Buren[7].schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.Buren[7];
                }
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.Buren[5] == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;

                    }
                    else if (vorige.Buren[5] == null || vorige.Buren[5].schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.Buren[5];
                }
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.Buren[6] == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;
                    }
                    else if (vorige.Buren[6] == null || vorige.Buren[6].schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.Buren[6];

                }
            }
            //Als het schaakstuk het vakje kan bereiken, wordt het schaakstuk verplaatst.
            //Hierna wordt gekeken of de koning schaak staat.
            //Als de koning schaak staat, dan wordt het schaakstuk weer terug geplaatst waar die stond.
            //Staat de koning niet schaak, dan is de zet definitief en is de andere speler aan de beurt.

            if (mogelijk == true)
            {
                Schaakstuk temp = nieuwVakje.schaakstuk;
                nieuwVakje.schaakstuk = this;
                selected.schaakstuk = null;
                this.Vakje = nieuwVakje;
                bool checkSchaak = spel.schaakbord.CheckSchaak(spel.SpelerAanZet.koning.Vakje, spel.SpelerAanZet.koning.Kleur);
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
                    spel.SpelerAanZet.ValideZet = true;
                }
            }
        }
    }
}

