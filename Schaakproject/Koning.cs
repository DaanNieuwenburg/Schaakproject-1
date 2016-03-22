using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Koning : Schaakstuk
    {
        private Vakje _vorigvakje { get; set; }
        private bool _staatschaak { get; set; }     //Staat de koning schaak
        private bool _eersteZet { get; set; }       //Is de koning al verzet
        private int _positiewest { get; set; }
        private bool _wilRokeren { get; set; }      //Als je op ja drukt als er gevraagd wordt of je wilt rokeren

        public Koning(string kleur, Vakje vakje, Speler speler)
        {
            this.kleur = kleur;
            this.vakje = vakje;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.KoningWit;
            }
            else
            {
                afbeelding = Properties.Resources.KoningZwart;
            }
        }
        public override void kanStukSlaan(Computer computer, Vakje geselecteerdStuk)
        {

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
                bool checkSchaak = spel.schaakbord.CheckSchaak(speler.Koning);
                if (checkSchaak == true)
                {
                    selected.schaakstuk = this;
                    nieuwVakje.schaakstuk = temp;
                    this.vakje = selected;
                }
                else
                {
                    speler.validezet = true;
                }
            }
        }

        public void Rokeren(Vakje vakjeToren, Vakje vakjeKoning, Mens speler, Spel spel)
        {
            Schaakstuk tempToren = vakjeToren.schaakstuk;
            if (spel._Variant == "Klassiek")
            {
                
                bool veldenLeeg = false;
                _wilRokeren = false;
                if (vakjeToren.buurOost == null)
                {
                    //check of rokeren mogelijk is
                    if (_eersteZet == false && (vakjeToren.schaakstuk as Toren)._eersteZet == false && vakjeToren.buurWest.schaakstuk == null && vakjeToren.buurWest.buurWest.schaakstuk == null)
                    {
                        veldenLeeg = true;
                        bool checkschaak = spel.schaakbord.CheckSchaak(speler.Koning);
                        if (checkschaak == false)
                        {
                            this.vakje = vakjeKoning.buurOost;
                            vakjeKoning.buurOost.schaakstuk = this;
                            vakjeKoning.schaakstuk = null;

                            checkschaak = spel.schaakbord.CheckSchaak(speler.Koning);
                            if (checkschaak == false)
                            {
                                this.vakje = vakjeKoning.buurOost.buurOost;
                                vakjeKoning.buurOost.buurOost.schaakstuk = this;
                                vakjeKoning.buurOost.schaakstuk = null;

                                checkschaak = spel.schaakbord.CheckSchaak(speler.Koning);
                                if (checkschaak == false)
                                {
                                    this.vakje = vakjeKoning.buurOost.buurOost.buurOost;
                                    vakjeKoning.buurOost.buurOost.buurOost.schaakstuk = this;
                                    vakjeKoning.buurOost.buurOost.schaakstuk = null;

                                    checkschaak = spel.schaakbord.CheckSchaak(speler.Koning);
                                    if (checkschaak == false)
                                    {
                                        // popup voor rokeren
                                        Rokerenmelding _Rokerenmelding = new Rokerenmelding(this);
                                        _Rokerenmelding.ShowDialog();

                                    }
                                }
                            }
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
                    else
                    {
                        if (veldenLeeg == true)
                        {
                            this.vakje = vakjeKoning;
                            tempToren.vakje = vakjeToren;
                            vakjeKoning.schaakstuk = this;
                            vakjeToren.schaakstuk = tempToren;
                            vakjeKoning.buurOost.buurOost.schaakstuk = null;
                            vakjeKoning.buurOost.schaakstuk = null;
                        }
                    }
                }

                else if (vakjeToren.buurWest == null)
                {
                    if (_eersteZet == false && (vakjeToren.schaakstuk as Toren)._eersteZet == false && vakjeToren.buurOost.schaakstuk == null && vakjeToren.buurOost.buurOost.schaakstuk == null && vakjeToren.buurOost.buurOost.buurOost.schaakstuk == null)
                    {
                        bool checkschaak = spel.schaakbord.CheckSchaak(speler.Koning);
                        if (checkschaak == false)
                        {
                            this.vakje = vakjeKoning.buurWest;
                            vakjeKoning.buurWest.schaakstuk = this;
                            vakjeKoning.schaakstuk = null;

                            checkschaak = spel.schaakbord.CheckSchaak(speler.Koning);
                            if (checkschaak == false)
                            {
                                this.vakje = vakjeKoning.buurWest.buurWest;
                                vakjeKoning.buurWest.buurWest.schaakstuk = this;
                                vakjeKoning.buurWest.schaakstuk = null;

                                checkschaak = spel.schaakbord.CheckSchaak(speler.Koning);
                                if (checkschaak == false)
                                {
                                    this.vakje = vakjeKoning.buurWest.buurWest.buurWest;
                                    vakjeKoning.buurWest.buurWest.buurWest.schaakstuk = this;
                                    vakjeKoning.buurWest.buurWest.schaakstuk = null;

                                    checkschaak = spel.schaakbord.CheckSchaak(speler.Koning);
                                    if (checkschaak == false)
                                    {
                                        this.vakje = vakjeKoning.buurWest.buurWest.buurWest.buurWest;
                                        vakjeKoning.buurWest.buurWest.buurWest.buurWest.schaakstuk = this;
                                        vakjeKoning.buurWest.buurWest.buurWest.schaakstuk = null;

                                        checkschaak = spel.schaakbord.CheckSchaak(speler.Koning);
                                        if (checkschaak == false)
                                        {
                                            // popup voor rokeren
                                            Rokerenmelding _Rokerenmelding = new Rokerenmelding(this);
                                            _Rokerenmelding.ShowDialog();
                                        }
                                    }
                                }
                            }
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
                    else
                    {
                        if (veldenLeeg == true)
                        {
                            this.vakje = vakjeKoning;
                            tempToren.vakje = vakjeToren;
                            vakjeKoning.schaakstuk = this;
                            vakjeToren.schaakstuk = tempToren;
                            vakjeKoning.buurWest.buurWest.schaakstuk = null;
                            vakjeKoning.buurWest.schaakstuk = null;
                            vakjeToren.buurOost.schaakstuk = null;
                        }
                    }
                }
            }
            else if (spel._Variant == "Chess960")
            {
                _vorigvakje = spel.selected;
                bool buurwest = false;
                bool torenwestgevonden = false;
                bool veldenLeeg = false;
                int westteller = 0;
                while (buurwest == false)
                {
                    if (buurwest == false && _vorigvakje != null)
                    {
                        _vorigvakje = _vorigvakje.buurWest;
                        westteller++;
                        Console.WriteLine(westteller);

                    }
                    else if (_vorigvakje == vakjeToren)
                    {
                        buurwest = true;
                        _positiewest = westteller;
                        torenwestgevonden = true;
                    }
                    else
                    {
                        buurwest = true;
                        _positiewest = westteller;
                    }

                    _wilRokeren = false;
                    if (vakjeToren.buurOost == null)
                    {
                        //check of rokeren mogelijk is
                        if (_eersteZet == false && (vakjeToren.schaakstuk as Toren)._eersteZet == false && veldenLeeg == true)
                        {
                            bool checkschaak = spel.schaakbord.CheckSchaak(speler.Koning);
                            if (checkschaak == false)
                            {
                                this.vakje = vakjeKoning.buurOost;
                                vakjeKoning.buurOost.schaakstuk = this;
                                vakjeKoning.schaakstuk = null;

                                checkschaak = spel.schaakbord.CheckSchaak(speler.Koning);
                                if (checkschaak == false)
                                {
                                    this.vakje = vakjeKoning.buurOost.buurOost;
                                    vakjeKoning.buurOost.buurOost.schaakstuk = this;
                                    vakjeKoning.buurOost.schaakstuk = null;

                                    checkschaak = spel.schaakbord.CheckSchaak(speler.Koning);
                                    if (checkschaak == false)
                                    {
                                        this.vakje = vakjeKoning.buurOost.buurOost.buurOost;
                                        vakjeKoning.buurOost.buurOost.buurOost.schaakstuk = this;
                                        vakjeKoning.buurOost.buurOost.schaakstuk = null;

                                        checkschaak = spel.schaakbord.CheckSchaak(speler.Koning);
                                        if (checkschaak == false)
                                        {
                                            // popup voor rokeren
                                            Rokerenmelding _Rokerenmelding = new Rokerenmelding(this);
                                            _Rokerenmelding.ShowDialog();

                                        }
                                    }
                                }
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
                        else
                        {
                            this.vakje = vakjeKoning;
                            tempToren.vakje = vakjeToren;
                            vakjeKoning.schaakstuk = this;
                            vakjeToren.schaakstuk = tempToren;
                            vakjeKoning.buurOost.buurOost.schaakstuk = null;
                            vakjeKoning.buurOost.schaakstuk = null;
                        }
                    }

                    else if (torenwestgevonden == true)
                    {
                        for (int i = 0; i < westteller;)
                        {
                            if (_vorigvakje.schaakstuk == null)
                            {
                                _vorigvakje = _vorigvakje.buurOost;
                                i++;
                            }
                            else if (_vorigvakje.schaakstuk == null && westteller == i)
                            {
                                veldenLeeg = true;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (_eersteZet == false && (vakjeToren.schaakstuk as Toren)._eersteZet == false && veldenLeeg == true)
                        {

                            // popup voor rokeren
                            Rokerenmelding _Rokerenmelding = new Rokerenmelding(this);
                            _Rokerenmelding.ShowDialog();

                        }
                    }
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

                speler.validezet = true;
                _eersteZet = true;
            }
            else
            {
                this.vakje = vakjeKoning;
                tempToren.vakje = vakjeToren;
                vakjeKoning.schaakstuk = this;
                vakjeToren.schaakstuk = tempToren;
                vakjeKoning.buurWest.buurWest.schaakstuk = null;
                vakjeKoning.buurWest.schaakstuk = null;
                vakjeToren.buurOost.schaakstuk = null;
            }
        }


        public void Wilrokeren()
        {
            _wilRokeren = true;
        }
        public void Checkschaak(SpecialPB pictures, SpecialPB selected, Mens speler)
        {
            bool schaak = false;
            bool mogelijkloop = false;
            Vakje vorige = vakje;
            while (mogelijkloop == false)
            {

                if (vorige.buurNoord.schaakstuk is Toren || vorige.buurNoord.schaakstuk is Dame)
                {
                    schaak = true;
                    Console.WriteLine("schaaktrue: " + schaak);
                    mogelijkloop = true;
                }
                else if (vorige.buurNoord == null || vorige.buurNoord.schaakstuk != null)
                {
                    mogelijkloop = true;
                    Console.WriteLine("schaakfalse: " + schaak);
                }
                vorige = vorige.buurNoord;
            }
            mogelijkloop = false;
            vorige = vakje;
            if (schaak == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurOost.schaakstuk is Toren || vorige.buurOost.schaakstuk is Dame)
                    {
                        schaak = true;
                        Console.WriteLine("schaaktrue: " + schaak);
                        mogelijkloop = true;
                    }
                    else if (vorige.buurOost == null || vorige.buurOost.schaakstuk != null)
                    {
                        mogelijkloop = true;
                        Console.WriteLine("schaakfalse: " + schaak);
                    }
                    vorige = vorige.buurOost;
                }
            }
            mogelijkloop = false;
            vorige = vakje;
            if (schaak == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurZuid.schaakstuk is Toren || vorige.buurZuid.schaakstuk is Dame)
                    {
                        schaak = true;
                        Console.WriteLine("schaaktrue: " + schaak);
                        mogelijkloop = true;
                    }
                    else if (vorige.buurZuid == null || vorige.buurZuid.schaakstuk != null)
                    {
                        mogelijkloop = true;
                        Console.WriteLine("schaakfalse: " + schaak);
                    }
                    vorige = vorige.buurZuid;
                }
            }
            mogelijkloop = false;
            vorige = vakje;
            if (schaak == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurWest.schaakstuk is Toren || vorige.buurWest.schaakstuk is Dame)
                    {
                        schaak = true;
                        Console.WriteLine("schaaktrue: " + schaak);
                        mogelijkloop = true;
                    }
                    else if (vorige.buurWest == null || vorige.buurWest.schaakstuk != null)
                    {
                        mogelijkloop = true;
                        Console.WriteLine("schaakfalse: " + schaak);
                    }
                    vorige = vorige.buurWest;
                }
            }
        }
    }
}

