using System;

namespace Schaakproject
{
    public class Koning : Schaakstuk
    {
        private bool _eersteZet { get; set; }       //Is de koning al verzet
        private bool _wilRokeren { get; set; }      //Als je op ja drukt als er gevraagd wordt of je wilt rokeren
        private bool _magRokeren { get; set; }      //wanneer het mogelijk is om te rokeren verschijnt een melding of je wilt rokeren

        public Koning(string kleur, Vakje vakje, Speler speler)
        {

            this.Kleur = kleur;
            this.Vakje = vakje;
            this.Speler = speler;
            if (kleur == "wit")
            {
                Afbeelding = Properties.Resources.KoningWit;
            }
            else
            {
                Afbeelding = Properties.Resources.KoningZwart;
            }
        }

        public override void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk)
        {
            // Deze methode kijkt vanuit de computer of er een koning geslagen kan worden.
            if (geselecteerdStuk.schaakstuk.Kleur == "zwart")
            {
                Vakje geselecteerdVak = geselecteerdStuk;

                // noord
                if (geselecteerdVak.Buren[7] != null && geselecteerdVak.Buren[7].schaakstuk != null && geselecteerdVak.Buren[7].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[7]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.Buren[0] != null && geselecteerdVak.Buren[0].schaakstuk != null && geselecteerdVak.Buren[0].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[0]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.Buren[4] != null && geselecteerdVak.Buren[4].schaakstuk != null && geselecteerdVak.Buren[4].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[4]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }

                // west
                else if (geselecteerdVak.Buren[3].Buren[0] != null && geselecteerdVak.Buren[3].Buren[0].schaakstuk != null && geselecteerdVak.Buren[3].Buren[0].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[3].Buren[0]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.Buren[3] != null && geselecteerdVak.Buren[3].schaakstuk != null && geselecteerdVak.Buren[3].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[3]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.Buren[3].Buren[2] != null && geselecteerdVak.Buren[3].Buren[2].schaakstuk != null && geselecteerdVak.Buren[3].Buren[2].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[3].Buren[2]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }

                // zuid
                else if (geselecteerdVak.Buren[6] != null && geselecteerdVak.Buren[6].schaakstuk != null && geselecteerdVak.Buren[6].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[6]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.Buren[2] != null && geselecteerdVak.Buren[2].schaakstuk != null && geselecteerdVak.Buren[2].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[2]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.Buren[5] != null && geselecteerdVak.Buren[5].schaakstuk != null && geselecteerdVak.Buren[5].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[5]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }

                // oost
                else if (geselecteerdVak.Buren[1].Buren[0] != null && geselecteerdVak.Buren[1].Buren[0].schaakstuk != null && geselecteerdVak.Buren[1].Buren[0].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[1].Buren[0]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.Buren[1] != null && geselecteerdVak.Buren[1].schaakstuk != null && geselecteerdVak.Buren[1].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[1]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.Buren[1].Buren[2] != null && geselecteerdVak.Buren[1].Buren[2].schaakstuk != null && geselecteerdVak.Buren[1].Buren[2].schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.Buren[1].Buren[2]);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else
                {
                }
            }
        }

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Spel spel)
        {
            //Kijk of het schaakstuk het geselecteerde vakje kan vinden,
            //door alle vakjes waar heen bewogen mag worden te vergelijken met het geselecteerde vakje

            bool gevonden = false;
            if (selected.Buren[0] == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.Buren[1] == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.Buren[2] == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.Buren[3] == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.Buren[4] == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.Buren[7] == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.Buren[5] == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.Buren[6] == nieuwVakje)
            {
                gevonden = true;
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
            Schaakstuk tempToren = vakjeToren.schaakstuk;
            Vakje _Randoost;
            Vakje vorige = vakjeKoning;
            bool checkschaak = false;

            // Rokeren voor klassieke schaakvariant
            if (spel.Variant == "Klassiek")
            {
                _wilRokeren = false;
                bool magrokeren = true;
                if (vakjeToren.Buren[1] == null) // Als het gaat om de rechter toren.
                {
                    //check of rokeren mogelijk is door te kijken of alle vakjes leeg zijn, en de koning en toren nog geen zet gedaan hebben.
                    if (_eersteZet == false && (vakjeToren.schaakstuk as Toren)._eersteZet == false && vakjeToren.Buren[3].schaakstuk == null && vakjeToren.Buren[3].Buren[3].schaakstuk == null)
                    {
                        while (vorige != null)
                        {
                            //voor elk vakje van de koning tot en met de toren moet gekeken worden dat dit vakje niet geraakt kan worden.
                            checkschaak = spel.schaakbord.CheckSchaak(vorige, speler.koning.Kleur);
                            if (checkschaak == true)
                            {
                                magrokeren = false;
                            }
                            vorige = vorige.Buren[1];
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
                        this.Vakje = vakjeKoning.Buren[1].Buren[1];
                        vakjeKoning.Buren[1].Buren[1].schaakstuk = this;

                        tempToren.Vakje = vakjeKoning.Buren[1];
                        vakjeKoning.Buren[1].schaakstuk = tempToren;

                        vakjeKoning.schaakstuk = null;
                        vakjeToren.schaakstuk = null;

                        this.Vakje.Pbox.update();
                        this.Vakje.Buren[3].Buren[3].Pbox.update();
                        this.Vakje.Buren[3].Pbox.update();
                        this.Vakje.Buren[1].Pbox.update();

                        speler.ValideZet = true;
                        _eersteZet = true;

                        if (spel.SpelMode == "Singleplayer")
                        {
                            spel.ComputerSpeler.Zet(tempToren.Vakje);  // laat de computer op de mens reageren
                            spel.VeranderSpeler();
                        }
                    }

                }

                else if (vakjeToren.Buren[3] == null) //Als het gaat om de linker toren.
                {
                    //check of rokeren mogelijk is door te kijken of alle vakjes leeg zijn, en de koning en toren nog geen zet gedaan hebben.
                    if (_eersteZet == false && (vakjeToren.schaakstuk as Toren)._eersteZet == false && vakjeToren.Buren[1].schaakstuk == null && vakjeToren.Buren[1].Buren[1].schaakstuk == null && vakjeToren.Buren[1].Buren[1].Buren[1].schaakstuk == null)
                    {
                        while (vorige != null)
                        {
                            //voor elk vakje van de koning tot en met de toren moet gekeken worden dat dit vakje niet geraakt kan worden.
                            checkschaak = spel.schaakbord.CheckSchaak(vorige, speler.koning.Kleur);
                            if (checkschaak == true)
                            {
                                magrokeren = false;
                            }
                            vorige = vorige.Buren[3];
                        }

                        if (magrokeren == true)
                        {
                            // popup voor rokeren
                            Rokerenmelding _Rokerenmelding = new Rokerenmelding(this);
                            _Rokerenmelding.ShowDialog();
                            spel.VeranderSpeler();
                        }

                    }
                    if (_wilRokeren == true)
                    {
                        this.Vakje = vakjeKoning.Buren[3].Buren[3];
                        vakjeKoning.Buren[3].Buren[3].schaakstuk = this;

                        tempToren.Vakje = vakjeKoning.Buren[3];
                        vakjeKoning.Buren[3].schaakstuk = tempToren;

                        vakjeToren.Buren[1].schaakstuk = null;
                        vakjeKoning.schaakstuk = null;
                        vakjeToren.schaakstuk = null;

                        this.Vakje.Pbox.update();
                        this.Vakje.Buren[3].Buren[3].Pbox.update();
                        this.Vakje.Buren[3].Pbox.update();
                        this.Vakje.Buren[1].Pbox.update();
                        this.Vakje.Buren[1].Buren[1].Pbox.update();

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
                    Vakje _vorigWest = vakjeKoning.Buren[3];
                    Vakje _vorigVakje = vakjeKoning.Buren[3];

                    while (_vorigWest != null)                      //bepaald locatie van de koning a.d.v. het aantal buren links
                    {
                        west++;
                        if (_vorigWest.schaakstuk is Toren)
                        {
                            aantalplaatsenwest = west;
                        }
                        if (_vorigWest.Buren[3] != null)
                        {
                            _vorigWest = _vorigWest.Buren[3];
                        }
                        else
                        {
                            break;
                        }

                    }
                    Vakje _randWest = _vorigWest;
                    Vakje _vorigOost = _randWest;
                    _Randoost = _randWest.Buren[1].Buren[1].Buren[1].Buren[1].Buren[1].Buren[1].Buren[1];
                    Vakje koningnieuw_W = _randWest.Buren[1].Buren[1];
                    Vakje torennieuw_W = _randWest.Buren[1].Buren[1].Buren[1];
                    Vakje koningnieuw_O = _Randoost.Buren[3];
                    Vakje torennieuw_O = _Randoost.Buren[3].Buren[3];
                    // voor west

                    vakjesleeg = true;

                    if (vakjeKoning.Buren[3].schaakstuk is Toren)
                    {
                        if (vakjeKoning.Buren[3] == vakjeToren)
                        {
                            aantalplaatsenwest = 1;
                            rokeerwest = true;

                            while (i <= aantalplaatsenwest)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[3];
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
                    else if (vakjeKoning.Buren[3].Buren[3].schaakstuk is Toren)
                    {
                        if (vakjeKoning.Buren[3].Buren[3] == vakjeToren)
                        {
                            aantalplaatsenwest = 2;
                            rokeerwest = true;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[3];
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
                    else if (vakjeKoning.Buren[3].Buren[3].Buren[3].schaakstuk is Toren)
                    {
                        if (vakjeKoning.Buren[3].Buren[3].Buren[3] == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 3;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[3];
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
                    else if (vakjeKoning.Buren[3].Buren[3].Buren[3].Buren[3].schaakstuk is Toren)
                    {
                        if (vakjeKoning.Buren[3].Buren[3].Buren[3].Buren[3] == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 4;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[3];
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
                    else if (vakjeKoning.Buren[3].Buren[3].Buren[3].Buren[3].Buren[3].schaakstuk is Toren)
                    {
                        if (vakjeKoning.Buren[3].Buren[3].Buren[3].Buren[3].Buren[3] == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 5;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[3];
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
                    else if (vakjeKoning.Buren[3].Buren[3].Buren[3].Buren[3].Buren[3].Buren[3].schaakstuk is Toren)
                    {
                        if (vakjeKoning.Buren[3].Buren[3].Buren[3].Buren[3].Buren[3].Buren[3] == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 6;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[3];
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
                    else if (vakjeKoning.Buren[3].Buren[3].Buren[3].Buren[3].Buren[3].Buren[3].Buren[3].schaakstuk is Toren)
                    {
                        if (vakjeKoning.Buren[3].Buren[3].Buren[3].Buren[3].Buren[3].Buren[3].Buren[3] == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 7;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[3];
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
                        _vorigVakje = vakjeKoning.Buren[1];
                        // voor oost
                        vakjesleeg = true;
                        if (vakjeKoning.Buren[1] == vakjeToren)
                        {
                            rokeerwest = false;
                            _magRokeren = true;
                            while (i <= aantalplaatsenoost)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[1];
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
                        else if (vakjeKoning.Buren[1].Buren[1] == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 2;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[1];
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
                        else if (vakjeKoning.Buren[1].Buren[1].Buren[1] == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 3;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[1];
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
                        else if (vakjeKoning.Buren[1].Buren[1].Buren[1].Buren[1] == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 4;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[1];
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
                        else if (vakjeKoning.Buren[1].Buren[1].Buren[1].Buren[1].Buren[1] == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 5;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[1];
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
                        else if (vakjeKoning.Buren[1].Buren[1].Buren[1].Buren[1].Buren[1].Buren[1] == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 6;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[1];
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
                        else if (vakjeKoning.Buren[1].Buren[1].Buren[1].Buren[1].Buren[1].Buren[1].Buren[1] == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 7;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.Buren[1];
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
                                Vakje _torenOud = vakjeToren;
                                Vakje _koningOud = vakjeKoning;
                                Schaakstuk Tempkoning = vakjeKoning.schaakstuk;
                                _Randoost.Buren[3].Buren[3].schaakstuk = tempToren;
                                _Randoost.Buren[3].schaakstuk = Tempkoning;
                                _Randoost.Buren[3].Pbox.update();
                                _Randoost.Buren[3].Pbox.update();
                                _koningOud.schaakstuk = null;
                                _torenOud.schaakstuk = null;
                                vakjeToren.schaakstuk = null;
                                this.Vakje.Pbox.update();
                                vakjeToren.Pbox.update();
                                _torenOud.Pbox.update();
                                _Randoost.Buren[3].schaakstuk = Tempkoning;
                                _Randoost.Buren[3].Pbox.update();
                                _Randoost.Buren[3].Buren[3].schaakstuk = tempToren;
                                _Randoost.Buren[3].Buren[3].Pbox.update();
                                _eersteZet = true;
                            }
                            else // ROKEREN NAAR WEST KANT
                            {
                                Vakje _torenOud = vakjeToren;
                                Vakje _koningOud = vakjeKoning;
                                Schaakstuk Tempkoning = vakjeKoning.schaakstuk;
                                _randWest.Buren[1].Buren[1].Buren[1].schaakstuk = tempToren;
                                _randWest.Buren[1].Buren[1].schaakstuk = Tempkoning;
                                _randWest.Buren[1].Pbox.update();
                                _randWest.Buren[1].Buren[1].schaakstuk = null;
                                _randWest.Buren[1].Buren[1].Pbox.update();
                                _koningOud.schaakstuk = null;
                                _torenOud.schaakstuk = null;
                                vakjeToren.schaakstuk = null;
                                this.Vakje.Pbox.update();
                                vakjeToren.Pbox.update();
                                _torenOud.Pbox.update();
                                _randWest.Buren[1].Buren[1].schaakstuk = Tempkoning;
                                _randWest.Buren[1].Buren[1].Pbox.update();
                                _randWest.Buren[1].Buren[1].Buren[1].schaakstuk = tempToren;
                                _randWest.Buren[1].Buren[1].Buren[1].Pbox.update();
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

