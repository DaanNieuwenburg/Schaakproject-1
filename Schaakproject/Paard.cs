namespace Schaakproject
{
    public class Paard : Schaakstuk
    {
        public Paard(string kleur, Vakje vakje, Speler speler)
        {
            this.Vakje = vakje;
            this.Kleur = kleur;
            this.Speler = speler;
            if (kleur == "wit")
            {
                Afbeelding = Properties.Resources.PaardWit;
            }
            else
            {
                Afbeelding = Properties.Resources.PaardZwart;
            }
        }
        public override void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk)
        {
            // Deze methode kijkt vanuit de computer of er een paard geslagen kan worden.
            Vakje geselecteerdVak = geselecteerdStuk;
            if (geselecteerdStuk.schaakstuk.Kleur == "zwart" && geselecteerdStuk.schaakstuk != null)
            {
                if (geselecteerdVak.Buren[0] != null && geselecteerdVak.Buren[0].Buren[4] != null && geselecteerdVak.Buren[0].Buren[7] != null)
                {
                    if (geselecteerdVak.Buren[0].Buren[4].schaakstuk != null && geselecteerdVak.Buren[0].Buren[4].schaakstuk != null && geselecteerdVak.Buren[0].Buren[4].schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.Buren[0].Buren[4].Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[0].Buren[4]);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (geselecteerdVak.Buren[0].Buren[7] != null && geselecteerdVak.Buren[0].Buren[7].schaakstuk != null && geselecteerdVak.Buren[0].Buren[7].schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.Buren[0].Buren[7].Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[0].Buren[7]);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                }

                if (geselecteerdVak.Buren[2] != null && geselecteerdStuk.schaakstuk != null)
                {
                    if (geselecteerdVak.Buren[2].Buren[6] != null && geselecteerdVak.Buren[2].Buren[6].schaakstuk != null && geselecteerdVak.Buren[2].Buren[6].schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.Buren[2].Buren[6].Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[2].Buren[6]);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (geselecteerdVak.Buren[2].Buren[5] != null && geselecteerdVak.Buren[2].Buren[5].schaakstuk != null && geselecteerdVak.Buren[2].Buren[5].schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.Buren[2].Buren[5].Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[2].Buren[5]);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                }

                if (geselecteerdVak.Buren[3] != null && geselecteerdStuk.schaakstuk != null)
                {
                    if (geselecteerdVak.Buren[3].Buren[7] != null && geselecteerdVak.Buren[3].Buren[7].schaakstuk != null && geselecteerdVak.Buren[3].Buren[7].schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.Buren[3].Buren[7].Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[3].Buren[7]);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (geselecteerdVak.Buren[3].Buren[6] != null && geselecteerdVak.Buren[3].Buren[6].schaakstuk != null && geselecteerdVak.Buren[3].Buren[6].schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.Buren[3].Buren[6].Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[3].Buren[6]);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                }
                if (geselecteerdVak.Buren[1] != null)
                {
                    if (geselecteerdVak.Buren[1].Buren[7] != null && geselecteerdVak.Buren[1].Buren[7].schaakstuk != null && geselecteerdVak.Buren[1].Buren[7].schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.Buren[1].Buren[7].Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[1].Buren[7]);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (geselecteerdVak.Buren[1].Buren[6] != null && geselecteerdVak.Buren[1].Buren[6].schaakstuk != null && geselecteerdVak.Buren[1].Buren[6].schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.Buren[1].Buren[6].Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[1].Buren[6]);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                }
                else
                {
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
            //Kijk of het schaakstuk het geselecteerde vakje kan vinden,
            //door alle vakjes waar heen bewogen mag worden te vergelijken met het geselecteerde vakje

            bool gevonden = false;
            if (selected.Buren[0] != null)
            {
                if (selected.Buren[0].Buren[4] == nieuwVakje)
                {
                    gevonden = true;
                }
                else if (selected.Buren[0].Buren[7] == nieuwVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.Buren[1] != null)
            {
                if (selected.Buren[1].Buren[4] == nieuwVakje)
                {
                    gevonden = true;
                }
                else if (selected.Buren[1].Buren[5] == nieuwVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.Buren[2] != null)
            {
                if (selected.Buren[2].Buren[5] == nieuwVakje)
                {
                    gevonden = true;
                }
                else if (selected.Buren[2].Buren[6] == nieuwVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.Buren[3] != null)
            {
                if (selected.Buren[3].Buren[6] == nieuwVakje)
                {
                    gevonden = true;
                }

                else if (selected.Buren[3].Buren[7] == nieuwVakje)
                {
                    gevonden = true;
                }
            }

            if (gevonden == true)
            {
                //Als het schaakstuk het vakje kan bereiken, wordt het schaakstuk verplaatst.
                //Hierna wordt gekeken of de koning schaak staat.
                //Als de koning schaak staat, dan wordt het schaakstuk weer terug geplaatst waar die stond.
                //Staat de koning niet schaak, dan is de zet definitief en is de andere speler aan de beurt.

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

