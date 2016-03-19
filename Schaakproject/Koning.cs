﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Koning : Schaakstuk
    {
        private bool _staatschaak { get; set; }     //Staat de koning schaak
        private bool _eersteZet { get; set; }       //Is de koning al verzet
        private bool _wilRokeren { get; set; }      //Als je op ja drukt als er gevraagd wordt of je wilt rokeren

        public Koning(string kleur, Vakje vakje)
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
        public override void kanStukSlaan(Computer computer, SpecialPB geselecteerdStuk)
        {
            Vakje geselecteerdVak = geselecteerdStuk.vakje;
            if (geselecteerdVak.schaakstuk.kleur == "wit")
            {
                if (geselecteerdVak.buurNoord.schaakstuk != null && geselecteerdVak.buurNoord.schaakstuk.kleur != "wit")
                {
                    computer.spelerkanslaan = true;
                }
                else if (geselecteerdVak.buurOost.schaakstuk != null && geselecteerdVak.buurOost.schaakstuk.kleur != "wit")
                {
                    computer.spelerkanslaan = true;
                }
                else if (geselecteerdVak.buurZuid.schaakstuk != null && geselecteerdVak.buurZuid.schaakstuk.kleur != "wit")
                {
                    computer.spelerkanslaan = true;
                }
                else if (geselecteerdVak.buurWest.schaakstuk != null && geselecteerdVak.buurWest.schaakstuk.kleur != "wit")
                {
                    computer.spelerkanslaan = true;
                }
                else if (geselecteerdVak.buurNoordoost.schaakstuk != null && geselecteerdVak.buurNoordoost.schaakstuk.kleur != "wit")
                {
                    computer.spelerkanslaan = true;
                }
                else if (geselecteerdVak.buurNoordwest.schaakstuk != null && geselecteerdVak.buurNoordwest.schaakstuk.kleur != "wit")
                {
                    computer.spelerkanslaan = true;
                }
                else if (geselecteerdVak.buurZuidoost.schaakstuk != null && geselecteerdVak.buurZuidoost.schaakstuk.kleur != "wit")
                {
                    computer.spelerkanslaan = true;
                }
                else if (geselecteerdVak.buurZuidwest.schaakstuk != null && geselecteerdVak.buurZuidwest.schaakstuk.kleur != "wit")
                {
                    computer.spelerkanslaan = true;
                }
            }
            else
            {
                if (geselecteerdVak.buurNoord.schaakstuk != null && geselecteerdVak.buurNoord.schaakstuk.kleur != "zwart")
                {
                    computer.computerkanslaan = true;
                }
                else if (geselecteerdVak.buurOost.schaakstuk != null && geselecteerdVak.buurOost.schaakstuk.kleur != "zwart")
                {
                    computer.computerkanslaan = true;
                }
                else if (geselecteerdVak.buurZuid.schaakstuk != null && geselecteerdVak.buurZuid.schaakstuk.kleur != "zwart")
                {
                    computer.computerkanslaan = true;
                }
                else if (geselecteerdVak.buurWest.schaakstuk != null && geselecteerdVak.buurWest.schaakstuk.kleur != "zwart")
                {
                    computer.computerkanslaan = true;
                }
                else if (geselecteerdVak.buurNoordoost.schaakstuk != null && geselecteerdVak.buurNoordoost.schaakstuk.kleur != "zwart")
                {
                    computer.computerkanslaan = true;
                }
                else if (geselecteerdVak.buurNoordwest.schaakstuk != null && geselecteerdVak.buurNoordwest.schaakstuk.kleur != "zwart")
                {
                    computer.computerkanslaan = true;
                }
                else if (geselecteerdVak.buurZuidoost.schaakstuk != null && geselecteerdVak.buurZuidoost.schaakstuk.kleur != "zwart")
                {
                    computer.computerkanslaan = true;
                }
                else if (geselecteerdVak.buurZuidwest.schaakstuk != null && geselecteerdVak.buurZuidwest.schaakstuk.kleur != "zwart")
                {
                    computer.computerkanslaan = true;
                }
            }
        }

        public override void Verplaats(SpecialPB pictures, SpecialPB selected, Mens speler)
        {
            bool gevonden = false;
            if (selected.vakje.buurNoord == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurOost == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurZuid == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurWest == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurNoordoost == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurNoordwest == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurZuidoost == pictures.vakje)
            {
                gevonden = true;
            }
            else if (selected.vakje.buurZuidwest == pictures.vakje)
            {
                gevonden = true;
            }

            if (gevonden == true)
            {
                pictures.vakje.schaakstuk = this;
                selected.vakje.schaakstuk = null;
                this.vakje = pictures.vakje;
                speler.validezet = true;
            }
        }

        public void Rokeren(SpecialPB picturesToren, SpecialPB selectedKoning, Mens speler)
        {
            
            _wilRokeren = false;
            if (picturesToren.vakje.buurOost == null)
            {

                if (_eersteZet == false && (picturesToren.vakje.schaakstuk as Toren)._eersteZet == false && picturesToren.vakje.buurWest.schaakstuk == null && picturesToren.vakje.buurWest.buurWest.schaakstuk == null)
                {
                    // popup voor rokeren
                    Rokerenmelding _Rokerenmelding = new Rokerenmelding(this);
                    _Rokerenmelding.ShowDialog();

                }
                
                if (_wilRokeren == true)
                {
                    picturesToren.vakje.schaakstuk.vakje = picturesToren.vakje.buurWest.buurWest;
                    picturesToren.vakje.buurWest.buurWest.schaakstuk = picturesToren.vakje.schaakstuk;
                    picturesToren.vakje.schaakstuk = null;

                    this.vakje = selectedKoning.vakje.buurOost.buurOost;
                    selectedKoning.vakje.buurOost.buurOost.schaakstuk = this;
                    selectedKoning.vakje.schaakstuk = null;

                    this.vakje.pbox.update();
                    this.vakje.buurWest.buurWest.pbox.update();
                    this.vakje.buurWest.pbox.update();
                    this.vakje.buurOost.pbox.update();

                    speler.validezet = true;
                    _eersteZet = true;
                }
            }

            else if (picturesToren.vakje.buurWest == null)
            {
                if (_eersteZet == false && (picturesToren.vakje.schaakstuk as Toren)._eersteZet == false && picturesToren.vakje.buurOost.schaakstuk == null && picturesToren.vakje.buurOost.buurOost.schaakstuk == null && picturesToren.vakje.buurOost.buurOost.buurOost.schaakstuk == null)
                {
                    Rokerenmelding _Rokerenmelding = new Rokerenmelding(this);
                    _Rokerenmelding.ShowDialog();
                }
                if (_wilRokeren == true)
                {
                    picturesToren.vakje.schaakstuk.vakje = picturesToren.vakje.buurOost.buurOost.buurOost;
                    picturesToren.vakje.buurOost.buurOost.buurOost.schaakstuk = picturesToren.vakje.schaakstuk;
                    picturesToren.vakje.schaakstuk = null;

                    this.vakje = selectedKoning.vakje.buurWest.buurWest;
                    selectedKoning.vakje.buurWest.buurWest.schaakstuk = this;
                    selectedKoning.vakje.schaakstuk = null;

                    this.vakje.pbox.update();
                    this.vakje.buurWest.buurWest.pbox.update();
                    this.vakje.buurOost.buurOost.pbox.update();
                    this.vakje.buurOost.pbox.update();
                    speler.validezet = true;
                    _eersteZet = true;
                }
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
                    Console.WriteLine("schaakfalse: "+ schaak);
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

