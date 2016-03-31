using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Koning : Schaakstuk
    {
        private Vakje _vorigvakje { get; set; }
        private Vakje _vorigwest { get; set; }
        private Vakje _vorigoost { get; set; }
        private Vakje _Randwest { get; set; }
        private Vakje _Randoost { get; set; }
        private bool _staatschaak { get; set; }     //Staat de koning schaak
        private bool _eersteZet { get; set; }       //Is de koning al verzet
        private int _positiewest { get; set; }
        private bool _wilRokeren { get; set; }      //Als je op ja drukt als er gevraagd wordt of je wilt rokeren
        private bool _magRokeren { get; set; }
        private Vakje _koningoud { get; set; }
        public Vakje _torenoud { get; set; }
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

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Spel spel)
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
                bool checkSchaak = spel.SchaakBord.CheckSchaak(spel.SpelerAanZet.koning.vakje, spel.SpelerAanZet.koning.kleur);
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
                        spel.updateAantalStukken(spel.SpelerAanZet);
                        temp.Slaan();
                    }
                    _eersteZet = true;
                    spel.SpelerAanZet.ValideZet = true;
                }
            }
        }

        public void Rokeren(Vakje vakjeToren, Vakje vakjeKoning, Mens speler, Spel spel)
        {
            Vakje toren1 = vakjeToren;
            Vakje koning1 = vakjeKoning;
            bool rokeerwest = true;
            _vorigvakje = spel.Selected;
            Schaakstuk tempToren = vakjeToren.schaakstuk;
            Vakje _Randoost;
            Vakje vorige = vakjeKoning;
            bool checkschaak = false;
            Console.WriteLine("MAG ROKEREN = " + _eersteZet);
            
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
                            checkschaak = spel.SchaakBord.CheckSchaak(vorige, speler.koning.kleur);
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

                        speler.ValideZet = true;
                        _eersteZet = true;
                    }

                }

                else if (vakjeToren.buurWest == null)
                {
                    if (_eersteZet == false && (vakjeToren.schaakstuk as Toren)._eersteZet == false && vakjeToren.buurOost.schaakstuk == null && vakjeToren.buurOost.buurOost.schaakstuk == null && vakjeToren.buurOost.buurOost.buurOost.schaakstuk == null)
                    {
                        while (vorige != null)
                        {
                            checkschaak = spel.SchaakBord.CheckSchaak(vorige, speler.koning.kleur);
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

                        speler.ValideZet = true;
                        _eersteZet = true;
                    }
                }
            }
            // Rokeren voor 960 schaakvariant
            else if (spel.Variant == "Chess960")
            {
                if (_eersteZet == false && (vakjeToren.schaakstuk as Toren)._eersteZet == false)
                {

                    rokeerwest = false;
                    bool vakjesleeg = false;
                    int aantalplaatsenwest = 0;                     // aantal plaatsen tussen koning en linker toren
                    int aantalplaatsenoost = 0;                     // aantal plaatsen tussen koning en rechter toren
                    int i = 0;
                    int west = 0;
                    _vorigwest = vakjeKoning.buurWest;
                    _vorigvakje = vakjeKoning.buurWest;

                    while (_vorigwest != null)                      //bepaald locatie van de koning a.d.v. het aantal buren links
                    {
                        west++;
                        if (_vorigwest.schaakstuk is Toren)
                        {
                            aantalplaatsenwest = west;
                        }
                        if (_vorigwest.buurWest != null)
                        {
                            _vorigwest = _vorigwest.buurWest;
                        }
                        else
                        {
                            break;
                        }

                    }
                    _Randwest = _vorigwest;
                    _vorigoost = _Randwest;
                    _Randoost = _Randwest.buurOost.buurOost.buurOost.buurOost.buurOost.buurOost.buurOost;
                    Vakje koningnieuw_W = _Randwest.buurOost.buurOost;
                    Vakje torennieuw_W = _Randwest.buurOost.buurOost.buurOost;
                    Vakje koningnieuw_O = _Randoost.buurWest;
                    Vakje torennieuw_O = _Randoost.buurWest.buurWest;
                    Console.WriteLine("west: " + west);
                    Console.WriteLine("aantal " + aantalplaatsenwest);
                    // voor west

                    vakjesleeg = true;

                    if (vakjeKoning.buurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.buurWest == vakjeToren)
                        {
                            aantalplaatsenwest = 1;
                            rokeerwest = true;
                            
                            while (i <= aantalplaatsenwest)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurWest;
                                    if (koningnieuw_W.schaakstuk == null || koningnieuw_W == vakjeKoning || koningnieuw_W == vakjeToren)
                                    {
                                        if (torennieuw_W.schaakstuk == null || torennieuw_W == vakjeKoning || torennieuw_W == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }
                                }
                                else
                                {
                                    vakjesleeg = false;
                                }

                                i++;
                            }
                            _magRokeren = true;
                        }
                    }
                    else if (vakjeKoning.buurWest.buurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.buurWest.buurWest == vakjeToren)
                        {
                            aantalplaatsenwest = 2;
                            rokeerwest = true;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurWest;
                                    if (koningnieuw_W.schaakstuk == null || koningnieuw_W == vakjeKoning || koningnieuw_W == vakjeToren)
                                    {
                                        if (torennieuw_W.schaakstuk == null || torennieuw_W == vakjeKoning || torennieuw_W == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }
                                }
                                else
                                {
                                    vakjesleeg = false;
                                }
                                i++;
                            }
                            _magRokeren = true;
                        }
                    }
                    else if (vakjeKoning.buurWest.buurWest.buurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.buurWest.buurWest.buurWest == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 3;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurWest;
                                    if (koningnieuw_W.schaakstuk == null || koningnieuw_W == vakjeKoning || koningnieuw_W == vakjeToren)
                                    {
                                        if (torennieuw_W.schaakstuk == null || torennieuw_W == vakjeKoning || torennieuw_W == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }
                                }
                                else
                                {
                                    vakjesleeg = false;
                                }
                                i++;
                            }
                            _magRokeren = true;
                        }

                    }
                    else if (vakjeKoning.buurWest.buurWest.buurWest.buurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.buurWest.buurWest.buurWest.buurWest == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 4;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurWest;
                                    if (koningnieuw_W.schaakstuk == null || koningnieuw_W == vakjeKoning || koningnieuw_W == vakjeToren)
                                    {
                                        if (torennieuw_W.schaakstuk == null || torennieuw_W == vakjeKoning || torennieuw_W == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }
                                }
                                else
                                {
                                    vakjesleeg = false;
                                }
                                i++;
                            }
                            _magRokeren = true;
                        }

                    }
                    else if (vakjeKoning.buurWest.buurWest.buurWest.buurWest.buurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.buurWest.buurWest.buurWest.buurWest.buurWest == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 5;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurWest;
                                    if (koningnieuw_W.schaakstuk == null || koningnieuw_W == vakjeKoning || koningnieuw_W == vakjeToren)
                                    {
                                        if (torennieuw_W.schaakstuk == null || torennieuw_W == vakjeKoning || torennieuw_W == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }
                                }
                                else
                                {
                                    vakjesleeg = false;
                                }
                                i++;
                            }
                            _magRokeren = true;
                        }

                    }
                    else if (vakjeKoning.buurWest.buurWest.buurWest.buurWest.buurWest.buurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.buurWest.buurWest.buurWest.buurWest.buurWest.buurWest == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 6;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurWest;
                                    if (koningnieuw_W.schaakstuk == null || koningnieuw_W == vakjeKoning || koningnieuw_W == vakjeToren)
                                    {
                                        if (torennieuw_W.schaakstuk == null || torennieuw_W == vakjeKoning || torennieuw_W == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }
                                }
                                else
                                {
                                    vakjesleeg = false;
                                }
                                i++;
                            }
                            _magRokeren = true;
                        }

                    }
                    else if (vakjeKoning.buurWest.buurWest.buurWest.buurWest.buurWest.buurWest.buurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.buurWest.buurWest.buurWest.buurWest.buurWest.buurWest.buurWest == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 7;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurWest;
                                    if (koningnieuw_W.schaakstuk == null || koningnieuw_W == vakjeKoning || koningnieuw_W == vakjeToren)
                                    {
                                        if (torennieuw_W.schaakstuk == null || torennieuw_W == vakjeKoning || torennieuw_W == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }
                                }
                                else
                                {
                                    vakjesleeg = false;
                                }
                                i++;
                            }
                            _magRokeren = true;
                        }

                    }

                    if (rokeerwest == false)
                    {
                        _vorigvakje = vakjeKoning.buurOost;
                        // voor oost
                        vakjesleeg = true;
                        if (vakjeKoning.buurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            _magRokeren = true;
                            while (i <= aantalplaatsenoost)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurOost;
                                    if (koningnieuw_O.schaakstuk == null || koningnieuw_O.schaakstuk is Koning || koningnieuw_O == vakjeToren)
                                    {
                                        if (torennieuw_O.schaakstuk == null || torennieuw_O.schaakstuk is Koning || torennieuw_O == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }
                                    
                                }
                                else
                                {
                                    vakjesleeg = false;
                                }
                                i++;
                            }
                            _magRokeren = true;
                        }
                        else if (vakjeKoning.buurOost.buurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 2;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurOost;
                                    if (koningnieuw_O.schaakstuk == null || koningnieuw_O.schaakstuk is Koning || koningnieuw_O == vakjeToren)
                                    {
                                        if (torennieuw_O.schaakstuk == null || torennieuw_O.schaakstuk is Koning || torennieuw_O == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }

                                }
                                else
                                {
                                    vakjesleeg = false;
                                }
                                i++;
                            }
                            _magRokeren = true;
                        }
                        else if (vakjeKoning.buurOost.buurOost.buurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 3;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurOost;
                                    if (koningnieuw_O.schaakstuk == null || koningnieuw_O.schaakstuk is Koning || koningnieuw_O == vakjeToren)
                                    {
                                        if (torennieuw_O.schaakstuk == null || torennieuw_O.schaakstuk is Koning || torennieuw_O == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }

                                }
                                else
                                {
                                    vakjesleeg = false;
                                }
                                i++;
                            }

                            _magRokeren = true;
                        }
                        else if (vakjeKoning.buurOost.buurOost.buurOost.buurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 4;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurOost;
                                    if (koningnieuw_O.schaakstuk == null || koningnieuw_O.schaakstuk is Koning || koningnieuw_O == vakjeToren)
                                    {
                                        if (torennieuw_O.schaakstuk == null || torennieuw_O.schaakstuk is Koning || torennieuw_O == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }

                                }
                                else
                                {
                                    vakjesleeg = false;
                                }
                                i++;
                            }
                            _magRokeren = true;
                        }
                        else if (vakjeKoning.buurOost.buurOost.buurOost.buurOost.buurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 5;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurOost;
                                    if (koningnieuw_O.schaakstuk == null || koningnieuw_O.schaakstuk is Koning || koningnieuw_O == vakjeToren)
                                    {
                                        if (torennieuw_O.schaakstuk == null || torennieuw_O.schaakstuk is Koning || torennieuw_O == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }

                                }
                                else
                                {
                                    vakjesleeg = false;
                                }
                                i++;
                            }
                            _magRokeren = true;
                        }
                        else if (vakjeKoning.buurOost.buurOost.buurOost.buurOost.buurOost.buurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 6;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurOost;
                                    if (koningnieuw_O.schaakstuk == null || koningnieuw_O.schaakstuk is Koning || koningnieuw_O == vakjeToren)
                                    {
                                        if (torennieuw_O.schaakstuk == null || torennieuw_O.schaakstuk is Koning || torennieuw_O == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }

                                }
                                else
                                {
                                    vakjesleeg = false;
                                }
                                i++;
                            }
                            _magRokeren = true;
                        }
                        else if (vakjeKoning.buurOost.buurOost.buurOost.buurOost.buurOost.buurOost.buurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 7;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigvakje.schaakstuk == null || _vorigvakje.schaakstuk is Toren)
                                {
                                    _vorigvakje = _vorigvakje.buurOost;
                                    if (koningnieuw_O.schaakstuk == null || koningnieuw_O.schaakstuk is Koning || koningnieuw_O == vakjeToren)
                                    {
                                        if (torennieuw_O.schaakstuk == null || torennieuw_O.schaakstuk is Koning || torennieuw_O == vakjeToren)
                                        {
                                            vakjesleeg = true;
                                        }
                                        else
                                        {
                                            vakjesleeg = false;
                                        }
                                    }
                                    else
                                    {
                                        vakjesleeg = false;
                                    }

                                }
                                else
                                {
                                    vakjesleeg = false;
                                }
                                i++;
                            }
                            _magRokeren = true;
                        }
                }
                

                if (_magRokeren == true)
                {
                    if (vakjesleeg == true)
                    {
                        // popup voor rokeren
                        Rokerenmelding _Rokerenmelding = new Rokerenmelding(this);
                        _Rokerenmelding.ShowDialog();
                    }
                }

                if (_wilRokeren == true && _magRokeren == true)
                {
                    if (vakjesleeg == true)
                    {
                        // ROKEREN NAAR OOST KANT
                        if (rokeerwest == false)
                        {
                            _torenoud = vakjeToren;
                            _koningoud = vakjeKoning;
                            Schaakstuk Tempkoning = vakjeKoning.schaakstuk;
                            _Randoost.buurWest.buurWest.schaakstuk = tempToren;
                            _Randoost.buurWest.schaakstuk = Tempkoning;
                            _Randoost.buurWest.pbox.update();
                            _Randoost.buurWest.pbox.update();
                            _koningoud.schaakstuk = null;
                            _torenoud.schaakstuk = null;
                            vakjeToren.schaakstuk = null;
                            this.vakje.pbox.update();
                            vakjeToren.pbox.update();
                            _torenoud.pbox.update();
                            _Randoost.buurWest.schaakstuk = Tempkoning;
                            _Randoost.buurWest.pbox.update();
                            //_Randwest.buurOost.buurOost.pbox.BackColor = System.Drawing.Color.Red;
                            _Randoost.buurWest.buurWest.schaakstuk = tempToren;
                            //_Randwest.buurOost.buurOost.buurOost.pbox.BackColor = System.Drawing.Color.Blue;
                            _Randoost.buurWest.buurWest.pbox.update();
                            _eersteZet = true;
                        }
                        else // ROKEREN NAAR WEST KANT
                        {
                            _torenoud = vakjeToren;
                            _koningoud = vakjeKoning;
                            Schaakstuk Tempkoning = vakjeKoning.schaakstuk;
                            _Randwest.buurOost.buurOost.buurOost.schaakstuk = tempToren;
                            _Randwest.buurOost.buurOost.schaakstuk = Tempkoning;
                            _Randwest.buurOost.pbox.update();
                            _Randwest.buurOost.buurOost.schaakstuk = null;
                            _Randwest.buurOost.buurOost.pbox.update();
                            _koningoud.schaakstuk = null;
                            _torenoud.schaakstuk = null;
                            vakjeToren.schaakstuk = null;
                            this.vakje.pbox.update();
                            vakjeToren.pbox.update();
                            _torenoud.pbox.update();
                            _Randwest.buurOost.buurOost.schaakstuk = Tempkoning;
                            _Randwest.buurOost.buurOost.pbox.update();
                            //_Randwest.buurOost.buurOost.pbox.BackColor = System.Drawing.Color.Red;
                            _Randwest.buurOost.buurOost.buurOost.schaakstuk = tempToren;
                            //_Randwest.buurOost.buurOost.buurOost.pbox.BackColor = System.Drawing.Color.Blue;
                            _Randwest.buurOost.buurOost.buurOost.pbox.update();
                            _eersteZet = true;
                        }
                    }

                    speler.ValideZet = true;
                    _eersteZet = true;
                }
            }
        }
    }


    public void Wilrokeren()
    {
        _wilRokeren = true;
    }
}
}

