using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            Vakje geselecteerdVak = geselecteerdStuk;
            if (geselecteerdStuk.schaakstuk.Kleur == "zwart" && geselecteerdStuk.schaakstuk != null)
            {
                if (geselecteerdVak.BuurNoord != null && geselecteerdVak.BuurNoord.BuurNoordoost != null && geselecteerdVak.BuurNoord.BuurNoordWest != null)
                {
                    if (geselecteerdVak.BuurNoord.BuurNoordoost.schaakstuk != null && geselecteerdVak.BuurNoord.BuurNoordoost.schaakstuk != null  && geselecteerdVak.BuurNoord.BuurNoordoost.schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.BuurNoord.BuurNoordoost.Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurNoord.BuurNoordoost);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (geselecteerdVak.BuurNoord.BuurNoordWest != null && geselecteerdVak.BuurNoord.BuurNoordWest.schaakstuk != null && geselecteerdVak.BuurNoord.BuurNoordWest.schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.BuurNoord.BuurNoordWest.Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurNoord.BuurNoordWest);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                }

                if (geselecteerdVak.BuurZuid != null && geselecteerdStuk.schaakstuk != null)
                {
                    if (geselecteerdVak.BuurZuid.BuurZuidWest != null && geselecteerdVak.BuurZuid.BuurZuidWest.schaakstuk != null && geselecteerdVak.BuurZuid.BuurZuidWest.schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.BuurZuid.BuurZuidWest.Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurZuid.BuurZuidWest);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (geselecteerdVak.BuurZuid.BuurZuidOost != null && geselecteerdVak.BuurZuid.BuurZuidOost.schaakstuk != null && geselecteerdVak.BuurZuid.BuurZuidOost.schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.BuurZuid.BuurZuidOost.Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurZuid.BuurZuidOost);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                }

                if (geselecteerdVak.BuurWest != null && geselecteerdStuk.schaakstuk != null)
                {
                    if (geselecteerdVak.BuurWest.BuurNoordWest != null && geselecteerdVak.BuurWest.BuurNoordWest.schaakstuk != null && geselecteerdVak.BuurWest.BuurNoordWest.schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.BuurWest.BuurNoordWest.Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurWest.BuurNoordWest);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (geselecteerdVak.BuurWest.BuurZuidWest != null && geselecteerdVak.BuurWest.BuurZuidWest.schaakstuk != null && geselecteerdVak.BuurWest.BuurZuidWest.schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.BuurWest.BuurZuidWest.Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurWest.BuurZuidWest);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                }
                if (geselecteerdVak.BuurOost != null)
                {
                    if (geselecteerdVak.BuurOost.BuurNoordWest != null && geselecteerdVak.BuurOost.BuurNoordWest.schaakstuk != null && geselecteerdVak.BuurOost.BuurNoordWest.schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.BuurOost.BuurNoordWest.Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurOost.BuurNoordWest);
                        algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (geselecteerdVak.BuurOost.BuurZuidWest != null && geselecteerdVak.BuurOost.BuurZuidWest.schaakstuk != null && geselecteerdVak.BuurOost.BuurZuidWest.schaakstuk.Kleur == "wit")
                    {
                        geselecteerdVak.BuurOost.BuurZuidWest.Pbox.BackColor = System.Drawing.Color.Red;
                        algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurOost.BuurZuidWest);
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

            bool gevonden = false;
            if (selected.BuurNoord != null)
            {
                if (selected.BuurNoord.BuurNoordoost == nieuwVakje)
                {                    
                    gevonden = true;
                }
                else if (selected.BuurNoord.BuurNoordWest == nieuwVakje)
                {                    
                    gevonden = true;
                }
            }
            if (selected.BuurOost != null)
            {
                if (selected.BuurOost.BuurNoordoost == nieuwVakje)
                {
                    gevonden = true;
                }
                else if (selected.BuurOost.BuurZuidOost == nieuwVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.BuurZuid != null)
            {
                if (selected.BuurZuid.BuurZuidOost == nieuwVakje)
                {
                    gevonden = true;
                }
                else if (selected.BuurZuid.BuurZuidWest == nieuwVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.BuurWest != null)
            {
                if (selected.BuurWest.BuurZuidWest == nieuwVakje)
                {
                    gevonden = true;
                }

                else if (selected.BuurWest.BuurNoordWest == nieuwVakje)
                {
                    gevonden = true;
                }
            }

            if (gevonden == true)
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

