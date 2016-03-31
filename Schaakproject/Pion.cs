﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Pion : Schaakstuk
    {
        public bool eersteZet { get; private set; }        //is de pion al eens verzet
        private bool _magEnpassant { get; set; }            //mag de pion en-passant slaan

        public Pion(string kleur, Vakje vakje, Speler speler)
        {
            _magEnpassant = true;
            this.speler = speler;
            this.vakje = vakje;
            this.kleur = kleur;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.PionWit;
            }
            else
            {
                afbeelding = Properties.Resources.PionZwart;
            }
        }

        public override void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk)
        {
            if (geselecteerdStuk.schaakstuk.kleur == "zwart")
            {
                Vakje geselecteerdVak = geselecteerdStuk;
                if (geselecteerdVak.buurZuidoost != null && geselecteerdVak.buurZuidoost.schaakstuk != null && geselecteerdVak.buurZuidoost.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurZuidoost);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.buurZuidwest != null && geselecteerdVak.buurZuidwest.schaakstuk != null && geselecteerdVak.buurZuidwest.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurZuidwest);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else
                {
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

            Schaakstuk tempPion = null;
            bool locatie = false;
            bool mogelijk = false;
            Console.WriteLine("Verplaats");
            if (kleur == "wit")
            {
                // Witte pion een stapje naar voren
                if (selected.buurNoord == nieuwVakje && nieuwVakje.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // Slaan naar noordoost voor een witte pion
                else if (selected.buurNoordoost == nieuwVakje && nieuwVakje.schaakstuk != null)
                {
                    spel.updateAantalStukken(spel.spelerAanZet);
                    mogelijk = true;
                }

                // Slaan naar noordwest voor een witte pion
                else if (selected.buurNoordwest == nieuwVakje && nieuwVakje.schaakstuk != null)
                {
                    spel.updateAantalStukken(spel.spelerAanZet);
                    mogelijk = true;
                }

                // Twee stappen vooruit voor een witte pion
                else if (eersteZet == false && selected.buurNoord.buurNoord == nieuwVakje && selected.buurNoord.buurNoord.schaakstuk == null && selected.buurNoord.schaakstuk == null)
                {
                    mogelijk = true;

                    // Zodat de tegenstander mag en-passant slaan
                    if (nieuwVakje.buurOost != null)
                    {
                        if (nieuwVakje.buurOost.schaakstuk is Pion)
                        {
                            // Als er oost een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.buurOost.schaakstuk as Pion).speler.enPassantPion = this;
                        }
                    }
                    if (nieuwVakje.buurWest != null)
                    {
                        if (nieuwVakje.buurWest.schaakstuk is Pion)
                        {
                            // Als er west een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.buurWest.schaakstuk as Pion).speler.enPassantPion = this;
                        }
                    }
                }
                else if (selected.buurOost != null)
                {
                    //en-passant slaan naar noordoost
                    if (selected.buurNoordoost == nieuwVakje && base.speler.enPassantPion == selected.buurOost.schaakstuk && base.speler.enPassantPion != null)
                    {
                        spel.updateAantalStukken(spel.spelerAanZet);
                        tempPion = selected.buurOost.schaakstuk;
                        locatie = false;
                        selected.buurOost.schaakstuk.Slaan();
                        selected.buurOost.schaakstuk = null; //De andere pion verdwijnt
                        selected.buurOost.pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                        mogelijk = true;
                    }
                }
                if (selected.buurWest != null)
                {
                    //en-passant slaan naar noordwest
                    if (selected.buurNoordwest == nieuwVakje && base.speler.enPassantPion == selected.buurWest.schaakstuk && base.speler.enPassantPion != null)
                    {
                        spel.updateAantalStukken(spel.spelerAanZet);
                        tempPion = selected.buurWest.schaakstuk;
                        locatie = true;
                        selected.buurWest.schaakstuk.Slaan();
                        selected.buurWest.schaakstuk = null; //De andere pion verdwijnt
                        selected.buurWest.pbox.update(); //update deze pbox zodat je de pion niet meer ziet
                        mogelijk = true;
                    }
                }

            }

            else if (kleur == "zwart")
            {
                // Zwarte pion een stapje naar voren
                if (selected.buurZuid == nieuwVakje && nieuwVakje.schaakstuk == null)
                {
                    mogelijk = true;
                }

                // Slaan naar zuidoost voor een zwarte pion
                else if (selected.buurZuidoost == nieuwVakje && kleur == "zwart" && nieuwVakje.schaakstuk != null)
                {
                    spel.updateAantalStukken(spel.spelerAanZet);
                    mogelijk = true;
                }

                // Slaan naar zuidwest voor een zwarte pion
                else if (selected.buurZuidwest == nieuwVakje && nieuwVakje.schaakstuk != null)
                {
                    spel.updateAantalStukken(spel.spelerAanZet);
                    mogelijk = true;
                }

                // Twee stappen vooruit voor een zwarte pion
                else if (eersteZet == false && selected.buurZuid.buurZuid == nieuwVakje && selected.buurZuid.buurZuid.schaakstuk == null && selected.buurZuid.schaakstuk == null)
                {
                    mogelijk = true;

                    // Zodat de tegenstander mag en-passant slaan
                    if (nieuwVakje.buurOost != null)
                    {
                        if (nieuwVakje.buurOost.schaakstuk is Pion)
                        {
                            // Als er oost een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.buurOost.schaakstuk as Pion).speler.enPassantPion = this;

                        }
                    }
                    if (nieuwVakje.buurWest != null)
                    {
                        if (nieuwVakje.buurWest.schaakstuk is Pion)
                        {
                            // Als er west een pion staat dan onthoudt de tegenstander dat hij deze pion en-passant mag slaan
                            (nieuwVakje.buurWest.schaakstuk as Pion).speler.enPassantPion = this;

                        }
                    }
                }
                else if (selected.buurOost != null)
                {
                    //en-passant slaan naar zuidoost
                    if (selected.buurZuidoost == nieuwVakje && base.speler.enPassantPion == selected.buurOost.schaakstuk && base.speler.enPassantPion != null)
                    {
                        spel.updateAantalStukken(spel.spelerAanZet);
                        locatie = false;
                        tempPion = selected.buurOost.schaakstuk;
                        selected.buurOost.schaakstuk.Slaan();
                        selected.buurOost.schaakstuk = null; //De andere pion verdwijnt
                        selected.buurOost.pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                        mogelijk = true;
                    }
                }

                // dit laat de SP crashen dus uit SP gehaald
                if (spel.SpelMode == "Multiplayer")
                {
                    if (selected.buurWest != null)
                    {
                        //en-passant slaan naar zuidwest
                        if (selected.buurZuidwest == nieuwVakje && base.speler.enPassantPion == selected.buurWest.schaakstuk && base.speler.enPassantPion != null)
                        {
                            spel.updateAantalStukken(spel.spelerAanZet);
                            locatie = true;
                            tempPion = selected.buurWest.schaakstuk;
                            selected.buurWest.schaakstuk.Slaan();
                            selected.buurWest.schaakstuk = null; //De andere pion verdwijnt
                            selected.buurWest.pbox.update(); // update deze pbox zodat je de pion niet meer ziet
                            mogelijk = true;
                        }
                    }
                }
            }

            if (mogelijk == true)
            {
                Schaakstuk temp = nieuwVakje.schaakstuk;
                nieuwVakje.schaakstuk = this;
                selected.schaakstuk = null;
                this.vakje = nieuwVakje;
                Console.WriteLine("Check schaak1");
                bool checkSchaak;
                if (spel.SpelMode == "Singleplayer")
                {
                    checkSchaak = spel.schaakbord.CheckSchaak(spel.computerSpeler.Koning.vakje, spel.computerSpeler.Koning.kleur);
                }
                else
                {
                    checkSchaak = spel.schaakbord.CheckSchaak(speler.Koning.vakje, speler.Koning.kleur);
                }

                if (checkSchaak == true)
                {
                    selected.schaakstuk = this;
                    nieuwVakje.schaakstuk = temp;
                    this.vakje = selected;
                    if (tempPion != null)
                    {
                        if (locatie == false)
                        {
                            selected.buurOost.schaakstuk = tempPion;
                            selected.buurOost.pbox.update();
                        }
                        else
                        {
                            selected.buurWest.schaakstuk = tempPion;
                            selected.buurWest.pbox.update();
                        }
                    }
                }
                else
                {
                    if (temp != null)
                    {
                        temp.Slaan();
                    }
                    eersteZet = true;
                    speler.validezet = true;
                }

            }

            //De pion wil promoveren wanneer hij op de eerste of laatste rij komt te staan
            if (vakje.buurNoord == null || vakje.buurZuid == null)
            {
                if (spel.SpelMode != "Singleplayer")
                {
                    nieuwVakje.pbox.update();
                    selected.pbox.update();
                    vakje.schaakstuk = new Dame(kleur, vakje, base.speler);
                    PromoveerForm promoveerform = new PromoveerForm(this, kleur);
                    promoveerform.ShowDialog();
                }
                else
                {
                    nieuwVakje.pbox.update();
                    selected.pbox.update();
                    vakje.schaakstuk = new Dame(kleur, vakje, base.speler);
                }
            }

        }

        public void Promoveert(string keuze)
        {
            if (keuze.Equals("paard"))
            {
                vakje.schaakstuk = new Paard(kleur, vakje, speler);
            }
            else if (keuze.Equals("loper"))
            {
                vakje.schaakstuk = new Loper(kleur, vakje, speler);
            }
            else if (keuze.Equals("toren"))
            {
                vakje.schaakstuk = new Toren(kleur, vakje, speler);
            }
            else if (keuze.Equals("dame"))
            {
                vakje.schaakstuk = new Dame(kleur, vakje, speler);
            }

        }
    }
}

