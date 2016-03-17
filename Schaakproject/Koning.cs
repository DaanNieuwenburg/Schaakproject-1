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

                    this.vakje.update();
                    this.vakje.buurWest.buurWest.update();
                    this.vakje.buurWest.update();
                    this.vakje.buurOost.update();

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

                    this.vakje.update();
                    this.vakje.buurWest.buurWest.update();
                    this.vakje.buurOost.buurOost.update();
                    this.vakje.buurOost.update();
                    speler.validezet = true;
                    _eersteZet = true;
                }
            }
        }

        public void Wilrokeren()
        {
            _wilRokeren = true;            
        }
    }
}

