using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Schaakproject
{
    public class Spel
    {
        public string _SpelMode { get; set; }  //Singleplayer of multiplayer
        public Mens _Speler1 { get; set; }     //De speler (is er altijd)
        public Mens _Speler2 { get; set; }     //De tweede speler voor multiplayer
        public Computer _computerSpeler { get; set; }  //De computer voor singleplayer
        public Speler spelerAanZet { get; private set; } //welke speler is aan zet
        public Vakje selected { get;  set; } //Maakt de computer gebruik van
        public string _Variant { get; set; }    //Klassiek of Chess960
        public Schaakbord schaakbord { get; set; }

        public Spel(string Mode, string NaamSpeler1, string NaamSpeler2, string Variant)
        {
            _SpelMode = Mode;
            _Variant = Variant;
            if (_SpelMode == "Singleplayer")
            {
                Mens speler1 = new Mens(NaamSpeler1, "wit", this);
                Computer computerSpeler = new Computer(NaamSpeler2, "zwart");
                _Speler1 = speler1;
                _Speler2 = null;
                _computerSpeler = computerSpeler;
            }
            else if (Mode == "Multiplayer")
            {
                Mens speler1 = new Mens(NaamSpeler1, "wit", this);
                Mens speler2 = new Mens(NaamSpeler2, "zwart", this);
                _Speler1 = speler1;
                _Speler2 = speler2;
                _computerSpeler = null;
            }
            else if (Mode == "Online")
            {
                Mens speler1 = new Mens(NaamSpeler1, "wit", this);
                Console.WriteLine("Test Spel Naamspeler1: " + NaamSpeler1);
                Mens speler2 = new Mens(NaamSpeler2, "zwart", this);
                _Speler1 = speler1;
                _Speler2 = speler2;
                _computerSpeler = null;
            }
            spelerAanZet = _Speler1;
            Start();
        }

        public void Start()
        {
            Console.WriteLine("start");
                Schaakbord schaakbord = new Schaakbord(_Variant, this, _Speler1, _Speler2);
            this.schaakbord = schaakbord;
            SpeelBord speelbord = new SpeelBord(this, schaakbord, _SpelMode, _Speler1, _Speler2, _computerSpeler, _Variant);
            speelbord.Show();
        }

        public void Herstart(string spelMode, string speler1Naam, string speler2Naam)
        {
            if (spelMode == "Multiplayer" || _SpelMode == "Online")
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
            bool schaak;
            bool mat;
            Console.WriteLine("VeranderSpeler");
            if (spelerAanZet == _Speler1)
            {
                spelerAanZet = _Speler2;
                schaak = schaakbord.CheckSchaak(_Speler2.Koning);
                if (schaak == true)
                {
                    _Speler2.Koning.vakje.pbox.BackColor = System.Drawing.Color.Blue;
                    mat = schaakbord.CheckMat(_Speler2.Koning);
                    if (mat == true)
                    {
                        _Speler2.Koning.vakje.pbox.BackColor = System.Drawing.Color.Green;
                    }
                }
            }
            else
            {
                spelerAanZet = _Speler1;
                schaak = schaakbord.CheckSchaak(_Speler1.Koning);
                if (schaak == true)
                {
                    _Speler1.Koning.vakje.pbox.BackColor = System.Drawing.Color.Blue;
                    mat = schaakbord.CheckMat(_Speler1.Koning);
                    if (mat == true)
                    {
                        _Speler1.Koning.vakje.pbox.BackColor = System.Drawing.Color.Green;
                    }
                }
            }
            
        }
        public void controleerOpSchaak()
        {
            Console.WriteLine("Controleer op schaak");
            // kijk waar de koning staat
            bool koningGevonden = false;
            bool koningNietGevonden = true;
            Vakje vorigvakjeHO = selected;  // Horizontaal oost
            Vakje vorigvakjeVZ = selected; // Verticaal noord

            // Loop tot het meest linker vakje gevonden is
            while (vorigvakjeHO != null)
            {
                vorigvakjeHO = vorigvakjeHO.buurOost;
        }

            // Loop tot het meest onderste vakje gevonden is
            while (vorigvakjeVZ != null)
            {
                vorigvakjeVZ = vorigvakjeHO.buurZuid;
            }


            // Loop tot de koning gevonden is
            while (koningGevonden == false)
            {
                // loop naar boven
                // loop naar oost
                while (koningNietGevonden == true)
                {
                    if (vorigvakjeHO.schaakstuk is Koning && vorigvakjeHO.schaakstuk.kleur != selected.schaakstuk.kleur)
                    {
                        vorigvakjeHO.pbox.BackColor = System.Drawing.Color.Pink;
                        koningNietGevonden = false;
                    }
                    else
                    {
                        vorigvakjeHO.pbox.BackColor = System.Drawing.Color.Pink;
                        vorigvakjeHO = vorigvakjeHO.buurWest;
                    }
                }
                // loop naar west
                while (koningNietGevonden == true)
                {
                    if (vorigvakjeVZ.schaakstuk is Koning && vorigvakjeVZ.schaakstuk.kleur != selected.schaakstuk.kleur)
                    {
                        vorigvakjeHO.pbox.BackColor = System.Drawing.Color.Pink;
                        koningNietGevonden = false;
                    }
                    else
                    {
                        vorigvakjeHO.pbox.BackColor = System.Drawing.Color.Pink;
                        vorigvakjeVZ = vorigvakjeVZ.buurNoord;
                    }
                }
            }
        }
    }
}

