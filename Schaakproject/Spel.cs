﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Schaakproject
{
    public class Spel
    {
        private string _SpelMode { get; set; }
        private Mens _Speler1 { get; set; }
        private Mens _Speler2 { get; set; }
        private Computer _computerSpeler { get; set; }
        public bool speler1aanzet { get; private set; }
        public SpecialPB selected { get; set; }
        public string _Variant { get; private set; }

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

