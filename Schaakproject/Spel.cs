﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Schaakproject
{
    public class Spel
    {
        private string _SpelMode { get; set; }  //Singleplayer of multiplayer
        private Mens _Speler1 { get; set; }     //De speler (is er altijd)
        private Mens _Speler2 { get; set; }     //De tweede speler voor multiplayer
        private Computer _computerSpeler { get; set; }  //De computer coor singleplayer
        public bool speler1aanzet { get; private set; } //is speler 1 aan zet?
        public SpecialPB selected { get;  set; } //Maakt de computer gebruik van
        public string _Variant { get; private set; }    //Klassiek of Chess960

        public Spel(string Mode, string NaamSpeler1, string NaamSpeler2, string Variant)
        {
            _SpelMode = Mode;
            _Variant = Variant;
            if (_SpelMode == "Singleplayer")
            {
                Mens speler1 = new Mens(NaamSpeler1, "wit");
                Computer computerSpeler = new Computer(NaamSpeler2, "zwart");
                _Speler1 = speler1;
                _Speler2 = null;
                _computerSpeler = computerSpeler;
            }
            else if (Mode == "Multiplayer")
            {
                Mens speler1 = new Mens(NaamSpeler1, "wit");
                Mens speler2 = new Mens(NaamSpeler2, "zwart");
                _Speler1 = speler1;
                _Speler2 = speler2;
                _computerSpeler = null;
            }
            speler1aanzet = true;
            Start();
        }

        public void Start()
        {
            Schaakbord schaakbord = new Schaakbord(_Variant);
            SpeelBord speelbord = new SpeelBord(this, schaakbord, _SpelMode, _Speler1, _Speler2, _computerSpeler, _Variant);
            speelbord.Show();
        }

        public void Herstart(string spelMode, string speler1Naam, string speler2Naam)
        {
            if (spelMode == "Multiplayer")
            {
                Spel spel = new Spel(spelMode, speler1Naam, speler2Naam, _Variant);
            }
            else
            {
                Spel spel = new Spel(spelMode, speler1Naam, "comp", _Variant);
            }
        }

        public void VeranderSpeler()
        {
            speler1aanzet = !speler1aanzet;

        }

    }
}

