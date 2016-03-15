using System;
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
        public bool speler1aanzet { get; set; }
        public SpecialPB selected { get; set; }

        public Spel(string Mode, string Speler1, string Speler2)
        {
            _SpelMode = Mode;

            if (Mode == "Singleplayer")
            {
                Mens speler1 = new Mens(Speler1, "wit");
                Computer computerSpeler = new Computer(Speler2, "zwart");
                _Speler1 = speler1;
                _Speler2 = null;
                _computerSpeler = computerSpeler;
            }
            else if (Mode == "Multiplayer")
            {
                Mens speler1 = new Mens(Speler1, "wit");
                Mens speler2 = new Mens(Speler2, "zwart");
                _Speler1 = speler1;
                _Speler2 = speler2;
                _computerSpeler = null;
            }
            speler1aanzet = true;
            Start();
        }

        public void Start()
        {
            Schaakbord schaakbord = new Schaakbord();
            SpeelBord speelbord = new SpeelBord(this, schaakbord, _SpelMode, _Speler1, _Speler2, _computerSpeler);
            speelbord.Show();
        }

        public static void Herstart(string spelMode, string speler1Naam, string speler2Naam)
        {
            if (spelMode == "Multiplayer")
            {
                Spel spel = new Spel(spelMode, speler1Naam, speler2Naam);
            }
            else
            {
                Spel spel = new Spel(spelMode, speler1Naam, "comp");
            }

        }

        public void VeranderSpeler()
        {
            speler1aanzet = !speler1aanzet;

        }

    }
}

