using System;

namespace Schaakproject
{
    public class Pion : Schaakstuk
    {
        public bool eersteZet { get; private set; }        //is de pion al eens verzet

        public Pion(string kleur, Vakje vakje, Speler speler)
        {
            this.Speler = speler;
            this.Vakje = vakje;
            this.Kleur = kleur;
            if (kleur == "wit")
            {
                Afbeelding = Properties.Resources.PionWit;
            }
            else
            {
                Afbeelding = Properties.Resources.PionZwart;
            }
        }

        public override void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk)
        {
            if (geselecteerdStuk.schaakstuk.Kleur == "zwart")
            {
                Vakje geselecteerdVak = geselecteerdStuk;
                if (geselecteerdVak.Buren[5] != null && geselecteerdVak.Buren[5].schaakstuk != null && geselecteerdVak.Buren[5].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[5]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.Buren[6] != null && geselecteerdVak.Buren[6].schaakstuk != null && geselecteerdVak.Buren[6].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[6]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
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

            Schaakstuk tempPion = null;
            bool locatie = false;
            bool mogelijk = false;
            if (Kleur == "wit")
            {
                // Witte pion een stapje naar voren
                if (selected.Buren[0] == nieuwVakje && nieuwVakje.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // Slaan naar noordoost voor een witte pion
                else if (selected.Buren[4] == nieuwVakje && nieuwVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Slaan naar noordwest voor een witte pion
                else if (selected.Buren[7] == nieuwVakje && nieuwVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Twee stappen vooruit voor een witte pion
                else if (eersteZet == false && selected.Buren[0].Buren[0] == nieuwVakje && selected.Buren[0].Buren[0].schaakstuk == null && selected.Buren[0].schaakstuk == null)
                {
                    mogelijk = true;

                    // Zodat de tegenstander mag en-passant slaan
                    if (nieuwVakje.Buren[1] != null)
                    {
                        if (nieuwVakje.Buren[1].schaakstuk is Pion)
                        {
                            // Als er oost een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.Buren[1].schaakstuk as Pion).Speler.EnPassantPion = this;
                        }
                    }
                    if (nieuwVakje.Buren[3] != null)
                    {
                        if (nieuwVakje.Buren[3].schaakstuk is Pion)
                        {
                            // Als er west een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.Buren[3].schaakstuk as Pion).Speler.EnPassantPion = this;
                        }
                    }
                }
                else if (selected.Buren[1] != null)
                {
                    //en-passant slaan naar noordoost
                    if (selected.Buren[4] == nieuwVakje && base.Speler.EnPassantPion == selected.Buren[1].schaakstuk && base.Speler.EnPassantPion != null)
                    {
                        spel.updateAantalStukken(spel.SpelerAanZet);
                        tempPion = selected.Buren[1].schaakstuk;
                        locatie = false;
                        selected.Buren[1].schaakstuk.Slaan();
                        selected.Buren[1].schaakstuk = null; //De andere pion verdwijnt
                        selected.Buren[1].Pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                        mogelijk = true;
                    }
                }
                if (selected.Buren[3] != null)
                {
                    //en-passant slaan naar noordwest
                    if (selected.Buren[7] == nieuwVakje && base.Speler.EnPassantPion == selected.Buren[3].schaakstuk && base.Speler.EnPassantPion != null)
                    {
                        spel.updateAantalStukken(spel.SpelerAanZet);
                        tempPion = selected.Buren[3].schaakstuk;
                        locatie = true;
                        selected.Buren[3].schaakstuk.Slaan();
                        selected.Buren[3].schaakstuk = null; //De andere pion verdwijnt
                        selected.Buren[3].Pbox.update(); //update deze pbox zodat je de pion niet meer ziet
                        mogelijk = true;
                    }
                }

            }

            else if (Kleur == "zwart")
            {
                // Zwarte pion een stapje naar voren
                if (selected.Buren[2] == nieuwVakje && nieuwVakje.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // Slaan naar zuidoost voor een zwarte pion
                else if (selected.Buren[5] == nieuwVakje && Kleur == "zwart" && nieuwVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Slaan naar zuidwest voor een zwarte pion
                else if (selected.Buren[6] == nieuwVakje && nieuwVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Twee stappen vooruit voor een zwarte pion
                else if (eersteZet == false && selected.Buren[2].Buren[2] == nieuwVakje && selected.Buren[2].Buren[2].schaakstuk == null && selected.Buren[2].schaakstuk == null)
                {
                    mogelijk = true;

                    // Zodat de tegenstander mag en-passant slaan
                    if (nieuwVakje.Buren[1] != null)
                    {
                        if (nieuwVakje.Buren[1].schaakstuk is Pion)
                        {
                            // Als er oost een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.Buren[1].schaakstuk as Pion).Speler.EnPassantPion = this;

                        }
                    }
                    if (nieuwVakje.Buren[3] != null)
                    {
                        if (nieuwVakje.Buren[3].schaakstuk is Pion)
                        {
                            // Als er west een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.Buren[3].schaakstuk as Pion).Speler.EnPassantPion = this;

                        }
                    }
                }
                else if (selected.Buren[1] != null)
                {
                    //en-passant slaan naar zuidoost
                    if (selected.Buren[5] == nieuwVakje && base.Speler.EnPassantPion == selected.Buren[1].schaakstuk && base.Speler.EnPassantPion != null)
                    {
                        spel.updateAantalStukken(spel.SpelerAanZet);
                        locatie = false;
                        tempPion = selected.Buren[1].schaakstuk;
                        selected.Buren[1].schaakstuk.Slaan();
                        selected.Buren[1].schaakstuk = null; //De andere pion verdwijnt
                        selected.Buren[1].Pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                        mogelijk = true;
                    }
                }

                if (spel.SpelMode == "Multiplayer")
                {
                    if (selected.Buren[3] != null)
                    {
                        //en-passant slaan naar zuidwest
                        if (selected.Buren[6] == nieuwVakje && base.Speler.EnPassantPion == selected.Buren[3].schaakstuk && base.Speler.EnPassantPion != null)
                        {
                            spel.updateAantalStukken(spel.SpelerAanZet);
                            locatie = true;
                            tempPion = selected.Buren[3].schaakstuk;
                            selected.Buren[3].schaakstuk.Slaan();
                            selected.Buren[3].schaakstuk = null; //De andere pion verdwijnt
                            selected.Buren[3].Pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                            mogelijk = true;
                        }
                    }
                }
            }

            if (mogelijk == true)
            {
                //Als het schaakstuk het vakje kan bereiken, wordt het schaakstuk verplaatst.
                //Hierna wordt gekeken of de koning schaak staat.
                //Als de koning schaak staat, dan wordt het schaakstuk weer terug geplaatst waar die stond.
                //Staat de koning niet schaak, dan is de zet definitief en is de andere speler aan de beurt.

                Schaakstuk temp = nieuwVakje.schaakstuk;
                nieuwVakje.schaakstuk = this;
                selected.schaakstuk = null;
                this.Vakje = nieuwVakje;
                Console.WriteLine("Check schaak1");
                bool checkSchaak;
                checkSchaak = spel.schaakbord.CheckSchaak(spel.SpelerAanZet.koning.Vakje, spel.SpelerAanZet.koning.Kleur);

                Console.WriteLine("Schaak is " + checkSchaak);

                if (checkSchaak == true)
                {
                    selected.schaakstuk = this;
                    nieuwVakje.schaakstuk = temp;
                    this.Vakje = selected;
                    if (tempPion != null)
                    {
                        if (locatie == false)
                        {
                            selected.Buren[1].schaakstuk = tempPion;
                            selected.Buren[1].Pbox.update();
                        }
                        else
                        {
                            selected.Buren[3].schaakstuk = tempPion;
                            selected.Buren[3].Pbox.update();
                        }
                    }
                }
                else
                {
                    if (temp != null)
                    {
                        temp.Slaan();
                        spel.updateAantalStukken(spel.SpelerAanZet);
                    }
                    eersteZet = true;
                    Speler.ValideZet = true;
                }

            }

            //De pion wil promoveren wanneer hij op de eerste of laatste rij komt te staan
            if (Vakje.Buren[0] == null || Vakje.Buren[2] == null)
            {
                if (spel.SpelMode != "Singleplayer")
                {
                    Console.WriteLine("Hoort te promoveren");
                    nieuwVakje.Pbox.update();
                    selected.Pbox.update();
                    Vakje.schaakstuk = new Dame(Kleur, Vakje, base.Speler);
                    PromoveerForm promoveerform = new PromoveerForm(this, Kleur);
                    promoveerform.ShowDialog();
                }
                else
                {
                    if (spel.SpelerAanZet == spel.ComputerSpeler)
                    {
                        nieuwVakje.Pbox.update();
                        selected.Pbox.update();
                        Vakje.schaakstuk = new Dame(Kleur, Vakje, base.Speler);
                    }
                    else
                    {
                        nieuwVakje.Pbox.update();
                        selected.Pbox.update();
                        Vakje.schaakstuk = new Dame(Kleur, Vakje, base.Speler);
                        PromoveerForm promoveerform = new PromoveerForm(this, Kleur);
                        promoveerform.ShowDialog();
                    }
                }
            }

        }

        public void Promoveert(string keuze)
        {
            if (keuze.Equals("paard"))
            {
                Vakje.schaakstuk = new Paard(Kleur, Vakje, Speler);
            }
            else if (keuze.Equals("loper"))
            {
                Vakje.schaakstuk = new Loper(Kleur, Vakje, Speler);
            }
            else if (keuze.Equals("toren"))
            {
                Vakje.schaakstuk = new Toren(Kleur, Vakje, Speler);
            }
            else if (keuze.Equals("dame"))
            {
                Vakje.schaakstuk = new Dame(Kleur, Vakje, Speler);
            }

        }
    }
}

