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
            if (geselecteerdStuk.schaakstuk.Kleur == "zwart")
            {
                Vakje geselecteerdVak = geselecteerdStuk;

                // noord
                if (geselecteerdVak.BuurNoordWest != null && geselecteerdVak.BuurNoordWest.schaakstuk != null && geselecteerdVak.BuurNoordWest.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurNoordWest);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.BuurNoord != null && geselecteerdVak.BuurNoord.schaakstuk != null && geselecteerdVak.BuurNoord.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurNoord);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.BuurNoordoost != null && geselecteerdVak.BuurNoordoost.schaakstuk != null && geselecteerdVak.BuurNoordoost.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurNoordoost);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }

                // west
                else if (geselecteerdVak.BuurWest.BuurNoord != null && geselecteerdVak.BuurWest.BuurNoord.schaakstuk != null && geselecteerdVak.BuurWest.BuurNoord.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurWest.BuurNoord);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.BuurWest != null && geselecteerdVak.BuurWest.schaakstuk != null && geselecteerdVak.BuurWest.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurWest);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.BuurWest.BuurZuid != null && geselecteerdVak.BuurWest.BuurZuid.schaakstuk != null && geselecteerdVak.BuurWest.BuurZuid.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurWest.BuurZuid);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }

                // zuid
                else if (geselecteerdVak.BuurZuidWest != null && geselecteerdVak.BuurZuidWest.schaakstuk != null && geselecteerdVak.BuurZuidWest.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurZuidWest);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.BuurZuid != null && geselecteerdVak.BuurZuid.schaakstuk != null && geselecteerdVak.BuurZuid.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurZuid);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.BuurZuidOost != null && geselecteerdVak.BuurZuidOost.schaakstuk != null && geselecteerdVak.BuurZuidOost.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurZuidOost);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }

                // oost
                else if (geselecteerdVak.BuurOost.BuurNoord != null && geselecteerdVak.BuurOost.BuurNoord.schaakstuk != null && geselecteerdVak.BuurOost.BuurNoord.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurOost.BuurNoord);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.BuurOost != null && geselecteerdVak.BuurOost.schaakstuk != null && geselecteerdVak.BuurOost.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurOost);
                    algoritme.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                }
                else if (geselecteerdVak.BuurOost.BuurZuid != null && geselecteerdVak.BuurOost.BuurZuid.schaakstuk != null && geselecteerdVak.BuurOost.BuurZuid.schaakstuk.Kleur == "wit")
                {
                    algoritme.slaanmogelijkheden.Add(geselecteerdVak.BuurOost.BuurZuid);
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
            if (selected.BuurNoord == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.BuurOost == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.BuurZuid == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.BuurWest == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.BuurNoordoost == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.BuurNoordWest == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.BuurZuidOost == nieuwVakje)
            {
                gevonden = true;
            }
            else if (selected.BuurZuidWest == nieuwVakje)
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
            Console.WriteLine("MAG ROKEREN = " + _eersteZet);

            // Rokeren voor klassieke schaakvariant
            if (spel.Variant == "Klassiek")
            {
                _wilRokeren = false;
                bool magrokeren = true;
                if (vakjeToren.BuurOost == null) // Als het gaat om de rechter toren.
                {
                    //check of rokeren mogelijk is door te kijken of alle vakjes leeg zijn, en de koning en toren nog geen zet gedaan hebben.
                    if (_eersteZet == false && (vakjeToren.schaakstuk as Toren)._eersteZet == false && vakjeToren.BuurWest.schaakstuk == null && vakjeToren.BuurWest.BuurWest.schaakstuk == null)
                    {
                        while (vorige != null)
                        {
                            //voor elk vakje van de koning tot en met de toren moet gekeken worden dat dit vakje niet geraakt kan worden.
                            checkschaak = spel.schaakbord.CheckSchaak(vorige, speler.koning.Kleur);
                            if (checkschaak == true)
                            {
                                magrokeren = false;
                            }
                            vorige = vorige.BuurOost;
                        }

                        if (magrokeren == true)
                        {
                            Console.WriteLine("Rokeert");

                            // popup voor rokeren
                            Rokerenmelding _Rokerenmelding = new Rokerenmelding(this);
                            _Rokerenmelding.ShowDialog();
                        }
                    }

                    if (_wilRokeren == true)
                    {
                        this.Vakje = vakjeKoning.BuurOost.BuurOost;
                        vakjeKoning.BuurOost.BuurOost.schaakstuk = this;

                        tempToren.Vakje = vakjeKoning.BuurOost;
                        vakjeKoning.BuurOost.schaakstuk = tempToren;

                        vakjeKoning.schaakstuk = null;
                        vakjeToren.schaakstuk = null;

                        this.Vakje.Pbox.update();
                        this.Vakje.BuurWest.BuurWest.Pbox.update();
                        this.Vakje.BuurWest.Pbox.update();
                        this.Vakje.BuurOost.Pbox.update();

                        speler.ValideZet = true;
                        _eersteZet = true;

                        if (spel.SpelMode == "Singleplayer")
                        {
                            spel.ComputerSpeler.Zet(tempToren.Vakje);  // laat de computer op de mens reageren
                            spel.VeranderSpeler();
                        }
                    }

                }

                else if (vakjeToren.BuurWest == null) //Als het gaat om de linker toren.
                {
                    //check of rokeren mogelijk is door te kijken of alle vakjes leeg zijn, en de koning en toren nog geen zet gedaan hebben.
                    if (_eersteZet == false && (vakjeToren.schaakstuk as Toren)._eersteZet == false && vakjeToren.BuurOost.schaakstuk == null && vakjeToren.BuurOost.BuurOost.schaakstuk == null && vakjeToren.BuurOost.BuurOost.BuurOost.schaakstuk == null)
                    {
                        while (vorige != null)
                        {
                            //voor elk vakje van de koning tot en met de toren moet gekeken worden dat dit vakje niet geraakt kan worden.
                            checkschaak = spel.schaakbord.CheckSchaak(vorige, speler.koning.Kleur);
                            if (checkschaak == true)
                            {
                                magrokeren = false;
                            }
                            vorige = vorige.BuurWest;
                        }

                        if (magrokeren == true)
                        {
                            Console.WriteLine("Rokeert");
    
                            // popup voor rokeren
                            Rokerenmelding _Rokerenmelding = new Rokerenmelding(this);
                            _Rokerenmelding.ShowDialog();
                            spel.VeranderSpeler();
                        }

                    }
                    if (_wilRokeren == true)
                    {
                        this.Vakje = vakjeKoning.BuurWest.BuurWest;
                        vakjeKoning.BuurWest.BuurWest.schaakstuk = this;

                        tempToren.Vakje = vakjeKoning.BuurWest;
                        vakjeKoning.BuurWest.schaakstuk = tempToren;

                        vakjeToren.BuurOost.schaakstuk = null;
                        vakjeKoning.schaakstuk = null;
                        vakjeToren.schaakstuk = null;

                        this.Vakje.Pbox.update();
                        this.Vakje.BuurWest.BuurWest.Pbox.update();
                        this.Vakje.BuurWest.Pbox.update();
                        this.Vakje.BuurOost.Pbox.update();
                        this.Vakje.BuurOost.BuurOost.Pbox.update();

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
                    Vakje _vorigWest = vakjeKoning.BuurWest;
                    Vakje _vorigVakje = vakjeKoning.BuurWest;

                    while (_vorigWest != null)                      //bepaald locatie van de koning a.d.v. het aantal buren links
                    {
                        west++;
                        if (_vorigWest.schaakstuk is Toren)
                        {
                            aantalplaatsenwest = west;
                        }
                        if (_vorigWest.BuurWest != null)
                        {
                            _vorigWest = _vorigWest.BuurWest;
                        }
                        else
                        {
                            break;
                        }

                    }
                    Vakje _randWest = _vorigWest;
                    Vakje _vorigOost = _randWest;
                    _Randoost = _randWest.BuurOost.BuurOost.BuurOost.BuurOost.BuurOost.BuurOost.BuurOost;
                    Vakje koningnieuw_W = _randWest.BuurOost.BuurOost;
                    Vakje torennieuw_W = _randWest.BuurOost.BuurOost.BuurOost;
                    Vakje koningnieuw_O = _Randoost.BuurWest;
                    Vakje torennieuw_O = _Randoost.BuurWest.BuurWest;
                    Console.WriteLine("west: " + west);
                    Console.WriteLine("aantal " + aantalplaatsenwest);
                    // voor west

                    vakjesleeg = true;

                    if (vakjeKoning.BuurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.BuurWest == vakjeToren)
                        {
                            aantalplaatsenwest = 1;
                            rokeerwest = true;

                            while (i <= aantalplaatsenwest)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurWest;
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
                    else if (vakjeKoning.BuurWest.BuurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.BuurWest.BuurWest == vakjeToren)
                        {
                            aantalplaatsenwest = 2;
                            rokeerwest = true;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurWest;
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
                    else if (vakjeKoning.BuurWest.BuurWest.BuurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.BuurWest.BuurWest.BuurWest == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 3;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurWest;
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
                    else if (vakjeKoning.BuurWest.BuurWest.BuurWest.BuurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.BuurWest.BuurWest.BuurWest.BuurWest == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 4;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurWest;
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
                    else if (vakjeKoning.BuurWest.BuurWest.BuurWest.BuurWest.BuurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.BuurWest.BuurWest.BuurWest.BuurWest.BuurWest == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 5;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurWest;
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
                    else if (vakjeKoning.BuurWest.BuurWest.BuurWest.BuurWest.BuurWest.BuurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.BuurWest.BuurWest.BuurWest.BuurWest.BuurWest.BuurWest == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 6;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurWest;
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
                    else if (vakjeKoning.BuurWest.BuurWest.BuurWest.BuurWest.BuurWest.BuurWest.BuurWest.schaakstuk is Toren)
                    {
                        if (vakjeKoning.BuurWest.BuurWest.BuurWest.BuurWest.BuurWest.BuurWest.BuurWest == vakjeToren)
                        {
                            rokeerwest = true;
                            aantalplaatsenwest = 7;
                            while (i < aantalplaatsenwest - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurWest;
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
                        _vorigVakje = vakjeKoning.BuurOost;
                        // voor oost
                        vakjesleeg = true;
                        if (vakjeKoning.BuurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            _magRokeren = true;
                            while (i <= aantalplaatsenoost)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurOost;
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
                        else if (vakjeKoning.BuurOost.BuurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 2;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurOost;
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
                        else if (vakjeKoning.BuurOost.BuurOost.BuurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 3;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurOost;
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
                        else if (vakjeKoning.BuurOost.BuurOost.BuurOost.BuurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 4;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurOost;
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
                        else if (vakjeKoning.BuurOost.BuurOost.BuurOost.BuurOost.BuurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 5;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurOost;
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
                        else if (vakjeKoning.BuurOost.BuurOost.BuurOost.BuurOost.BuurOost.BuurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 6;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurOost;
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
                        else if (vakjeKoning.BuurOost.BuurOost.BuurOost.BuurOost.BuurOost.BuurOost.BuurOost == vakjeToren)
                        {
                            rokeerwest = false;
                            aantalplaatsenoost = 7;
                            while (i < aantalplaatsenoost - 1)
                            {
                                if (_vorigVakje.schaakstuk == null || _vorigVakje.schaakstuk is Toren)
                                {
                                    _vorigVakje = _vorigVakje.BuurOost;
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
                                _Randoost.BuurWest.BuurWest.schaakstuk = tempToren;
                                _Randoost.BuurWest.schaakstuk = Tempkoning;
                                _Randoost.BuurWest.Pbox.update();
                                _Randoost.BuurWest.Pbox.update();
                                _koningOud.schaakstuk = null;
                                _torenOud.schaakstuk = null;
                                vakjeToren.schaakstuk = null;
                                this.Vakje.Pbox.update();
                                vakjeToren.Pbox.update();
                                _torenOud.Pbox.update();
                                _Randoost.BuurWest.schaakstuk = Tempkoning;
                                _Randoost.BuurWest.Pbox.update();
                                _Randoost.BuurWest.BuurWest.schaakstuk = tempToren;
                                _Randoost.BuurWest.BuurWest.Pbox.update();
                                _eersteZet = true;
                            }
                            else // ROKEREN NAAR WEST KANT
                            {
                                Vakje _torenOud = vakjeToren;
                                Vakje _koningOud = vakjeKoning;
                                Schaakstuk Tempkoning = vakjeKoning.schaakstuk;
                                _randWest.BuurOost.BuurOost.BuurOost.schaakstuk = tempToren;
                                _randWest.BuurOost.BuurOost.schaakstuk = Tempkoning;
                                _randWest.BuurOost.Pbox.update();
                                _randWest.BuurOost.BuurOost.schaakstuk = null;
                                _randWest.BuurOost.BuurOost.Pbox.update();
                                _koningOud.schaakstuk = null;
                                _torenOud.schaakstuk = null;
                                vakjeToren.schaakstuk = null;
                                this.Vakje.Pbox.update();
                                vakjeToren.Pbox.update();
                                _torenOud.Pbox.update();
                                _randWest.BuurOost.BuurOost.schaakstuk = Tempkoning;
                                _randWest.BuurOost.BuurOost.Pbox.update();
                                _randWest.BuurOost.BuurOost.BuurOost.schaakstuk = tempToren;
                                _randWest.BuurOost.BuurOost.BuurOost.Pbox.update();
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

