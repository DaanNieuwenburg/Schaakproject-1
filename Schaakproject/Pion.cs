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
                if (geselecteerdVak.BuurZuidOost != null && geselecteerdVak.BuurZuidOost.schaakstuk != null && geselecteerdVak.BuurZuidOost.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurZuidOost);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.BuurZuidWest != null && geselecteerdVak.BuurZuidWest.schaakstuk != null && geselecteerdVak.BuurZuidWest.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurZuidWest);
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
                if (selected.BuurNoord == nieuwVakje && nieuwVakje.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // Slaan naar noordoost voor een witte pion
                else if (selected.BuurNoordoost == nieuwVakje && nieuwVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Slaan naar noordwest voor een witte pion
                else if (selected.BuurNoordWest == nieuwVakje && nieuwVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Twee stappen vooruit voor een witte pion
                else if (eersteZet == false && selected.BuurNoord.BuurNoord == nieuwVakje && selected.BuurNoord.BuurNoord.schaakstuk == null && selected.BuurNoord.schaakstuk == null)
                {
                    mogelijk = true;

                    // Zodat de tegenstander mag en-passant slaan
                    if (nieuwVakje.BuurOost != null)
                    {
                        if (nieuwVakje.BuurOost.schaakstuk is Pion)
                        {
                            // Als er oost een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.BuurOost.schaakstuk as Pion).Speler.EnPassantPion = this;
                        }
                    }
                    if (nieuwVakje.BuurWest != null)
                    {
                        if (nieuwVakje.BuurWest.schaakstuk is Pion)
                        {
                            // Als er west een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.BuurWest.schaakstuk as Pion).Speler.EnPassantPion = this;
                        }
                    }
                }
                else if (selected.BuurOost != null)
                {
                    //en-passant slaan naar noordoost
                    if (selected.BuurNoordoost == nieuwVakje && base.Speler.EnPassantPion == selected.BuurOost.schaakstuk && base.Speler.EnPassantPion != null)
                    {
                        spel.updateAantalStukken(spel.SpelerAanZet);
                        tempPion = selected.BuurOost.schaakstuk;
                        locatie = false;
                        selected.BuurOost.schaakstuk.Slaan();
                        selected.BuurOost.schaakstuk = null; //De andere pion verdwijnt
                        selected.BuurOost.Pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                        mogelijk = true;
                    }
                }
                if (selected.BuurWest != null)
                {
                    //en-passant slaan naar noordwest
                    if (selected.BuurNoordWest == nieuwVakje && base.Speler.EnPassantPion == selected.BuurWest.schaakstuk && base.Speler.EnPassantPion != null)
                    {
                        spel.updateAantalStukken(spel.SpelerAanZet);
                        tempPion = selected.BuurWest.schaakstuk;
                        locatie = true;
                        selected.BuurWest.schaakstuk.Slaan();
                        selected.BuurWest.schaakstuk = null; //De andere pion verdwijnt
                        selected.BuurWest.Pbox.update(); //update deze pbox zodat je de pion niet meer ziet
                        mogelijk = true;
                    }
                }

            }

            else if (Kleur == "zwart")
            {
                // Zwarte pion een stapje naar voren
                if (selected.BuurZuid == nieuwVakje && nieuwVakje.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // Slaan naar zuidoost voor een zwarte pion
                else if (selected.BuurZuidOost == nieuwVakje && Kleur == "zwart" && nieuwVakje.schaakstuk != null)
                {                    
                    mogelijk = true;
                }

                // Slaan naar zuidwest voor een zwarte pion
                else if (selected.BuurZuidWest == nieuwVakje && nieuwVakje.schaakstuk != null)
                {
                    mogelijk = true;
                }

                // Twee stappen vooruit voor een zwarte pion
                else if (eersteZet == false && selected.BuurZuid.BuurZuid == nieuwVakje && selected.BuurZuid.BuurZuid.schaakstuk == null && selected.BuurZuid.schaakstuk == null)
                {
                    mogelijk = true;

                    // Zodat de tegenstander mag en-passant slaan
                    if (nieuwVakje.BuurOost != null)
                    {
                        if (nieuwVakje.BuurOost.schaakstuk is Pion)
                        {
                            // Als er oost een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.BuurOost.schaakstuk as Pion).Speler.EnPassantPion = this;

                        }
                    }
                    if (nieuwVakje.BuurWest != null)
                    {
                        if (nieuwVakje.BuurWest.schaakstuk is Pion)
                        {
                            // Als er west een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.BuurWest.schaakstuk as Pion).Speler.EnPassantPion = this;

                        }
                    }
                }
                else if (selected.BuurOost != null)
                {
                    //en-passant slaan naar zuidoost
                    if (selected.BuurZuidOost == nieuwVakje && base.Speler.EnPassantPion == selected.BuurOost.schaakstuk && base.Speler.EnPassantPion != null)
                    {
                        spel.updateAantalStukken(spel.SpelerAanZet);
                        locatie = false;
                        tempPion = selected.BuurOost.schaakstuk;
                        selected.BuurOost.schaakstuk.Slaan();
                        selected.BuurOost.schaakstuk = null; //De andere pion verdwijnt
                        selected.BuurOost.Pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                        mogelijk = true;
                    }
                }
                
                if (spel.SpelMode == "Multiplayer")
                {
                    if (selected.BuurWest != null)
                    {
                        //en-passant slaan naar zuidwest
                        if (selected.BuurZuidWest == nieuwVakje && base.Speler.EnPassantPion == selected.BuurWest.schaakstuk && base.Speler.EnPassantPion != null)
                        {
                            spel.updateAantalStukken(spel.SpelerAanZet);
                            locatie = true;
                            tempPion = selected.BuurWest.schaakstuk;
                            selected.BuurWest.schaakstuk.Slaan();
                            selected.BuurWest.schaakstuk = null; //De andere pion verdwijnt
                            selected.BuurWest.Pbox.update(); // update deze pbox zodat je de pion niet meer ziet
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
                            selected.BuurOost.schaakstuk = tempPion;
                            selected.BuurOost.Pbox.update();
                        }
                        else
                        {
                            selected.BuurWest.schaakstuk = tempPion;
                            selected.BuurWest.Pbox.update();
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
            if (Vakje.BuurNoord == null || Vakje.BuurZuid == null)
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

