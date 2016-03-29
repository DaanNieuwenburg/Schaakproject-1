﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Koning : Schaakstuk
    {
        private Vakje _vorigvakje { get; set; }
        private Vakje _vorigwest { get; set; }
        private bool _staatschaak { get; set; }     //Staat de koning schaak
        private bool _eersteZet { get; set; }       //Is de koning al verzet
        private int _positiewest { get; set; }
        private bool _wilRokeren { get; set; }      //Als je op ja drukt als er gevraagd wordt of je wilt rokeren
        private bool _magRokeren { get; set; }

        public Koning(string kleur, Vakje vakje, Speler speler)
        {

            this.kleur = kleur;
            this.vakje = vakje;
            this.speler = speler;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.KoningWit;
            }
            else
            {
                afbeelding = Properties.Resources.KoningZwart;
            }
        }
        public override void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk)
        {
            if (geselecteerdStuk.schaakstuk.kleur == "zwart")
            {
                Vakje geselecteerdVak = geselecteerdStuk;

                // noord
                if (geselecteerdVak.buurNoordwest != null && geselecteerdVak.buurNoordwest.schaakstuk != null && geselecteerdVak.buurNoordwest.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurNoordwest);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.buurNoord != null && geselecteerdVak.buurNoord.schaakstuk != null && geselecteerdVak.buurNoord.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurNoord);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.buurNoordoost != null && geselecteerdVak.buurNoordoost.schaakstuk != null && geselecteerdVak.buurNoordoost.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurNoordoost);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }

                // west
                else if (geselecteerdVak.buurWest.buurNoord != null && geselecteerdVak.buurWest.buurNoord.schaakstuk != null && geselecteerdVak.buurWest.buurNoord.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurWest.buurNoord);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.buurWest != null && geselecteerdVak.buurWest.schaakstuk != null && geselecteerdVak.buurWest.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurWest);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.buurWest.buurZuid != null && geselecteerdVak.buurWest.buurZuid.schaakstuk != null && geselecteerdVak.buurWest.buurZuid.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurWest.buurZuid);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }

                // zuid
                else if (geselecteerdVak.buurZuidwest != null && geselecteerdVak.buurZuidwest.schaakstuk != null && geselecteerdVak.buurZuidwest.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurZuidwest);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.buurZuid != null && geselecteerdVak.buurZuid.schaakstuk != null && geselecteerdVak.buurZuid.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurZuid);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.buurZuidoost != null && geselecteerdVak.buurZuidoost.schaakstuk != null && geselecteerdVak.buurZuidoost.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurZuidoost);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }

                // oost
                else if (geselecteerdVak.buurOost.buurNoord != null && geselecteerdVak.buurOost.buurNoord.schaakstuk != null && geselecteerdVak.buurOost.buurNoord.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurOost.buurNoord);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.buurOost != null && geselecteerdVak.buurOost.schaakstuk != null && geselecteerdVak.buurOost.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurOost);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.buurOost.buurZuid != null && geselecteerdVak.buurOost.buurZuid.schaakstuk != null && geselecteerdVak.buurOost.buurZuid.schaakstuk.kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.buurOost.buurZuid);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else
                {
                }
            }
        }

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Mens speler, Spel spel)
        {

            bool gevonden = false;
            if (selected.buurNoord == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.buurOost == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.buurZuid == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.buurWest == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.buurNoordoost == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.buurNoordwest == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.buurZuidoost == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.buurZuidwest == nieuwVakje)
            {
                gevonden = true;
            }

            if (gevonden == true)
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
                    if (nieuwVakje.schaakstuk != null)
                    {
                        nieuwVakje.schaakstuk.Slaan();
                    }

                    speler.validezet = true;
                }
            }
        }

        public void Rokeren(Vakje vakjeToren, Vakje vakjeKoning, Mens speler, Spel spel)
        {
            _vorigvakje = spel.selected;
            Schaakstuk tempToren = vakjeToren.schaakstuk;
            Vakje vorige = vakjeKoning;
            bool checkschaak = false;

            // Rokeren voor klassieke schaakvariant
            if (spel.Variant == "Klassiek")
            {
                _wilRokeren = false;
                bool magrokeren = true;
                if (vakjeToren.buurOost == null)
                {
                    //check of rokeren mogelijk is
                    if (_eersteZet == false && (vakjeToren.schaakstuk as Toren)._eersteZet == false && vakjeToren.buurWest.schaakstuk == null && vakjeToren.buurWest.buurWest.schaakstuk == null)
                    {
                        while (vorige != null)
                        {
                            checkschaak = spel.schaakbord.CheckSchaak(vorige, speler.Koning.kleur);
                            if (checkschaak == true)
                            {
                                magrokeren = false;
                            }
                            vorige = vorige.buurOost;
                        }

                        if (magrokeren == true)
                        {
                            // popup voor rokeren
                            Rokerenmelding _Rokerenmelding = new Rokerenmelding(this);
                            _Rokerenmelding.ShowDialog();
                        }
                    }

                    if (_wilRokeren == true)
                    {
                        this.vakje = vakjeKoning.buurOost.buurOost;
                        vakjeKoning.buurOost.buurOost.schaakstuk = this;

                        tempToren.vakje = vakjeKoning.buurOost;
                        vakjeKoning.buurOost.schaakstuk = tempToren;

                        vakjeKoning.schaakstuk = null;
                        vakjeToren.schaakstuk = null;

                        this.vakje.pbox.update();
                        this.vakje.buurWest.buurWest.pbox.update();
                        this.vakje.buurWest.pbox.update();
                        this.vakje.buurOost.pbox.update();

                        speler.validezet = true;
                        _eersteZet = true;
                    }

                }

                else if (vakjeToren.buurWest == null)
                {
                    if (_eersteZet == false && (vakjeToren.schaakstuk as Toren)._eersteZet == false && vakjeToren.buurOost.schaakstuk == null && vakjeToren.buurOost.buurOost.schaakstuk == null && vakjeToren.buurOost.buurOost.buurOost.schaakstuk == null)
                    {
                        while (vorige != null)
                        {
                            checkschaak = spel.schaakbord.CheckSchaak(vorige, speler.Koning.kleur);
                            if (checkschaak == true)
                            {
                                magrokeren = false;
                            }
                            vorige = vorige.buurWest;
                        }

                        if (magrokeren == true)
                        {
                            // popup voor rokeren
                            Rokerenmelding _Rokerenmelding = new Rokerenmelding(this);
                            _Rokerenmelding.ShowDialog();
                        }

                    }
                    if (_wilRokeren == true)
                    {
                        this.vakje = vakjeKoning.buurWest.buurWest;
                        vakjeKoning.buurWest.buurWest.schaakstuk = this;

                        tempToren.vakje = vakjeKoning.buurWest;
                        vakjeKoning.buurWest.schaakstuk = tempToren;

                        vakjeToren.buurOost.schaakstuk = null;
                        vakjeKoning.schaakstuk = null;
                        vakjeToren.schaakstuk = null;

                        this.vakje.pbox.update();
                        this.vakje.buurWest.buurWest.pbox.update();
                        this.vakje.buurWest.pbox.update();
                        this.vakje.buurOost.pbox.update();
                        this.vakje.buurOost.buurOost.pbox.update();

                        speler.validezet = true;
                        _eersteZet = true;
                    }
                }
            }
            // Rokeren voor 960 schaakvariant
            else if (spel.Variant == "Chess960")
            {
                int i = 0;
                int west = 0;
                while (_vorigwest != null)                      //bepaald locatie van de koning a.d.v. het aantal buren links
                {
                    _vorigwest = _vorigwest.buurWest;
                    west++;
                }
                Console.WriteLine("west: " + west);
                // voor west
                int aantalplaatsenwest = 0;                     // aantal plaatsen tussen koning en linker toren
                int aantalplaatsenoost = 0;                     // aantal plaatsen tussen koning en rechter toren
                if (vakjeKoning.buurWest == vakjeToren)
                {
                    aantalplaatsenwest = 1;
                    if (_vorigvakje.schaakstuk == null)
                    {
                        _vorigvakje = _vorigvakje.buurWest;
                        _magRokeren = true;
                    }
                }
                else if (vakjeKoning.buurWest.buurWest == vakjeToren)
                {
                    aantalplaatsenwest = 2;
                    while (i < aantalplaatsenwest)
                    {
                        if (_vorigvakje.schaakstuk == null)
                        {
                            _vorigvakje = _vorigvakje.buurWest;
                            i++;

                        }
                    }
                    _magRokeren = true;
                }
                else if (vakjeKoning.buurWest.buurWest.buurWest == vakjeToren)
                {
                    aantalplaatsenwest = 3;
                    while (i < aantalplaatsenwest)
                    {
                        if (_vorigvakje.schaakstuk == null)
                        {
                            _vorigvakje = _vorigvakje.buurWest;
                            i++;

                        }
                    }
                    _magRokeren = true;
                }
                else if (vakjeKoning.buurWest.buurWest.buurWest.buurWest == vakjeToren)
                {
                    aantalplaatsenwest = 4;
                    while (i < aantalplaatsenwest)
                    {
                        if (_vorigvakje.schaakstuk == null)
                        {
                            _vorigvakje = _vorigvakje.buurWest;
                            i++;
                        }
                    }
                    _magRokeren = true;
                }
                else if (vakjeKoning.buurWest.buurWest.buurWest.buurWest.buurWest == vakjeToren)
                {
                    aantalplaatsenwest = 5;
                    while (i < aantalplaatsenwest)
                    {
                        if (_vorigvakje.schaakstuk == null)
                        {
                            _vorigvakje = _vorigvakje.buurWest;
                            i++;
                        }
                    }
                    _magRokeren = true;
                }
                else if (vakjeKoning.buurWest.buurWest.buurWest.buurWest.buurWest.buurWest == vakjeToren)
                {
                    aantalplaatsenwest = 6;
                    while (i < aantalplaatsenwest)
                    {
                        if (_vorigvakje.schaakstuk == null)
                        {
                            _vorigvakje = _vorigvakje.buurWest;
                            i++;
                        }
                    }
                    _magRokeren = true;
                }
                else if (vakjeKoning.buurWest.buurWest.buurWest.buurWest.buurWest.buurWest.buurWest == vakjeToren)
                {
                    aantalplaatsenwest = 7;
                    while (i < aantalplaatsenwest)
                    {
                        if (_vorigvakje.schaakstuk == null)
                        {
                            _vorigvakje = _vorigvakje.buurWest;
                            i++;
                        }
                    }
                    _magRokeren = true;
                }

                // voor oost

                if (vakjeKoning.buurOost == vakjeToren)
                {
                    aantalplaatsenoost = 1;
                    if (_vorigvakje.schaakstuk == null)
                    {
                        _vorigvakje = _vorigvakje.buurOost;
                        i++;
                        _magRokeren = true;
                    }
                }
                else if (vakjeKoning.buurOost.buurOost == vakjeToren)
                {
                    aantalplaatsenoost = 2;
                    while (i < aantalplaatsenoost)
                    {
                        if (_vorigvakje.schaakstuk == null)
                        {
                            _vorigvakje = _vorigvakje.buurOost;
                            i++;

                        }
                    }
                    _magRokeren = true;
                }
                else if (vakjeKoning.buurOost.buurOost.buurOost == vakjeToren)
                {
                    aantalplaatsenoost = 3;
                    while (i < aantalplaatsenoost)
                    {
                        if (_vorigvakje.schaakstuk == null)
                        {
                            _vorigvakje = _vorigvakje.buurOost;
                            i++;

                        }
                    }
                    _magRokeren = true;
                }
                else if (vakjeKoning.buurOost.buurOost.buurOost.buurOost == vakjeToren)
                {
                    aantalplaatsenoost = 4;
                    while (i < aantalplaatsenoost)
                    {
                        if (_vorigvakje.schaakstuk == null)
                        {
                            _vorigvakje = _vorigvakje.buurOost;
                            i++;
                        }
                    }
                    _magRokeren = true;
                }
                else if (vakjeKoning.buurOost.buurOost.buurOost.buurOost.buurOost == vakjeToren)
                {
                    aantalplaatsenoost = 5;
                    while (i < aantalplaatsenoost)
                    {
                        if (_vorigvakje.schaakstuk == null)
                        {
                            _vorigvakje = _vorigvakje.buurOost;
                            i++;
                        }
                    }
                    _magRokeren = true;
                }
                else if (vakjeKoning.buurOost.buurOost.buurOost.buurOost.buurOost.buurOost == vakjeToren)
                {
                    aantalplaatsenoost = 6;
                    while (i < aantalplaatsenoost)
                    {
                        if (_vorigvakje.schaakstuk == null)
                        {
                            _vorigvakje = _vorigvakje.buurOost;
                            i++;
                        }
                    }
                    _magRokeren = true;
                }
                else if (vakjeKoning.buurOost.buurOost.buurOost.buurOost.buurOost.buurOost.buurOost == vakjeToren)
                {
                    aantalplaatsenoost = 7;
                    while (i < aantalplaatsenoost)
                    {
                        if (_vorigvakje.schaakstuk == null)
                        {
                            _vorigvakje = _vorigvakje.buurOost;
                            i++;
                        }
                    }
                    _magRokeren = true;
                }



                if (_wilRokeren == true && _magRokeren == true)
                {
                    int j = 0;


                    this.vakje.pbox.update();
                    this.vakje.buurWest.buurWest.pbox.update();
                    this.vakje.buurWest.pbox.update();
                    this.vakje.buurOost.pbox.update();

                    speler.validezet = true;
                    _eersteZet = true;
                }
                else
                {
                    this.vakje = vakjeKoning;
                    vakjeKoning.schaakstuk = this;
                    vakjeKoning.buurWest.buurWest.schaakstuk = null;
                    vakjeKoning.buurWest.schaakstuk = null;
                    vakjeToren.buurOost.schaakstuk = null;
                }
            }
        }


        public void Wilrokeren()
        {
            _wilRokeren = true;
        }
    }
}

