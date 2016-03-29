using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Schaakproject
{
    public class Spel
    {
        public string SpelMode { get; set; }  //Singleplayer of multiplayer
        public bool witaanzet { get; set; }     //Wie is aan zet
        public Mens Speler1 { get; set; }     //De speler (is er altijd)
        public Mens Speler2 { get; set; }     //De tweede speler voor multiplayer
        public Computer computerSpeler { get; set; }  //De computer voor singleplayer
        public Speler spelerAanZet { get; private set; } //welke speler is aan zet
        public Vakje selected { get; set; } //Maakt de computer gebruik van
        public string Variant { get; set; }    //Klassiek of Chess960
        public Schaakbord schaakbord { get; set; }
        private Color _bordercolor { get; set; }
        public SpeelBord speelbord { get; set; }

        public Spel(string Mode, string NaamSpeler1, string NaamSpeler2, string Variant, Color bordercolor)
        {
            _bordercolor = bordercolor;
            SpelMode = Mode;
            this.Variant = Variant;
            if (SpelMode == "Singleplayer")
            {
                Mens speler1 = new Mens(NaamSpeler1, "wit", this);
                Computer computerSpeler = new Computer(NaamSpeler2, "zwart");
                Speler1 = speler1;
                Speler2 = null;
                this.computerSpeler = computerSpeler;
            }
            else if (Mode == "Multiplayer")
            {
                Mens speler1 = new Mens(NaamSpeler1, "wit", this);
                Mens speler2 = new Mens(NaamSpeler2, "zwart", this);
                Speler1 = speler1;
                Speler2 = speler2;
                computerSpeler = null;
            }
            else if (Mode == "Online")
            {
                Mens speler1 = new Mens(NaamSpeler1, "wit", this);
                Console.WriteLine("Test Spel Naamspeler1: " + NaamSpeler1);
                Mens speler2 = new Mens(NaamSpeler2, "zwart", this);
                Speler1 = speler1;
                Speler2 = speler2;
                computerSpeler = null;
            }
            spelerAanZet = Speler1;
            Start();
        }

        public void Start()
        {
            Console.WriteLine("start");
            Schaakbord schaakbord = new Schaakbord(Variant, this, Speler1, Speler2);
            this.schaakbord = schaakbord;
            SpeelBord speelbord = new SpeelBord(this, schaakbord, SpelMode, Speler1, Speler2, computerSpeler, Variant, _bordercolor);
            this.speelbord = speelbord;
            speelbord.Show();
        }

        public void Herstart(string spelMode, string speler1Naam, string speler2Naam)
        {
            if (spelMode == "Multiplayer" || SpelMode == "Online")
            {
                Spel spel = new Spel(spelMode, speler1Naam, speler2Naam, Variant, _bordercolor);
            }
            else
            {
                Spel spel = new Spel(spelMode, speler1Naam, "comp", Variant, _bordercolor);
            }
        }
        public void veranderlbltext()
        {
            if (SpelMode == "Multiplayer")
            {
                if (Speler1.Naam != "" && Speler2.Naam != "")
                {
                    if (witaanzet == false)
                    {
                        speelbord.lblbeurt.Text = Speler2.Naam + " is aan zet";
                    }
                    else
                    {
                        speelbord.lblbeurt.Text = Speler1.Naam + " is aan zet";
                    }
                }
                else
                {
                    if (witaanzet == false)
                    {
                        speelbord.lblbeurt.Text = "Zwart is aan zet";
                    }
                    else
                    {
                        speelbord.lblbeurt.Text = "Wit is aan zet";
                    }
                }
            }
        }
        public void VeranderSpeler()
        {
            if (SpelMode == "Multiplayer")
            {
                if (Speler1.aantalstukken[5] < 3 && Speler2.aantalstukken[5] < 3)
                {
                    bool checkweingstukken = schaakbord.CheckWeinigStukken(Speler1, Speler2);
                    if (checkweingstukken == true)
                    {
                        RemiseMelding _remise = new RemiseMelding(this);
                        _remise.ShowDialog();
                        speelbord.Hide();
                    }
                }
            }
            else
            {
                if (Speler1.aantalstukken[5] < 3 && computerSpeler.aantalstukken[5] < 3)
                {
                    bool checkweingstukken = schaakbord.CheckWeinigStukken(Speler1, computerSpeler);
                    if (checkweingstukken == true)
                    {
                        RemiseMelding _remise = new RemiseMelding(this);
                        _remise.ShowDialog();
                        speelbord.Hide();
                    }
                }
            }
            veranderlbltext();
            bool schaak;
            bool mat;
            bool pat;
            //Console.WriteLine("VeranderSpeler");
            if (spelerAanZet == Speler1)
            {
                witaanzet = true;
                if (SpelMode == "Singleplayer")
                {
                    spelerAanZet = computerSpeler;
                    schaak = schaakbord.CheckSchaak(computerSpeler.Koning.vakje, computerSpeler.Koning.kleur);
                }
                else
                {
                    spelerAanZet = Speler2;
                    schaak = schaakbord.CheckSchaak(Speler2.Koning.vakje, Speler2.Koning.kleur);
                }
                if (schaak == true)
                {
                    if (SpelMode == "Singleplayer")
                    {
                        //mat = schaakbord.CheckMat(computerSpeler.Koning);
                        //if (mat == true)
                        //{
                          //  Speler2.Koning.vakje.pbox.BackColor = System.Drawing.Color.Green;
                        //}
                    }
                    else
                    {

                        mat = schaakbord.CheckMat(Speler2.Koning);
                        if (mat == true)
                        {
                            Speler2.Koning.vakje.pbox.Image = Properties.Resources.ZwartMat1;
                            SchaakMat _SchaakMat = new SchaakMat(Speler1.Naam, this);
                            _SchaakMat.ShowDialog();
                            speelbord.Hide();
                        }
                    }
                }
                else
                {
                    if (SpelMode == "Singleplayer")
                    {
                        //pat = schaakbord.CheckPat(computerSpeler.Koning);
                        //if (pat == true)
                        //{
                        //    Speler2.Koning.vakje.pbox.BackColor = System.Drawing.Color.Purple;
                       // }
                    }
                    else
                    {

                        pat = schaakbord.CheckPat(Speler2.Koning);
                        if (pat == true)
                        {
                            RemiseMelding _remise = new RemiseMelding(this);
                            _remise.ShowDialog();
                            speelbord.Hide();
                        }
                    }
                }
            }
            else
            {
                witaanzet = false;
                spelerAanZet = Speler1;
                schaak = schaakbord.CheckSchaak(Speler1.Koning.vakje, Speler1.Koning.kleur);
                if (schaak == true)
                {

                    mat = schaakbord.CheckMat(Speler1.Koning);
                    if (mat == true)
                    {

                        Speler1.Koning.vakje.pbox.Image = Properties.Resources.WitMat1;
                        SchaakMat _SchaakMat = new SchaakMat(Speler2.Naam, this);
                        _SchaakMat.ShowDialog();
                        speelbord.Hide();
                    }
                }
                else
                {
                    pat = schaakbord.CheckPat(Speler1.Koning);
                    if (pat == true)
                    {
                        RemiseMelding _remise = new RemiseMelding(this);
                        _remise.ShowDialog();
                        speelbord.Hide();
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

        public void updateAantalStukken(Mens speler)
        {
            if (SpelMode != "Singleplayer")
            {
                speler.resterendestukken = speler.resterendestukken - 1;
                if (speler.Kleur == "wit")
                {
                    speelbord.lblaantal2.Text = Convert.ToString(Speler1.resterendestukken); //onlogisch, speler1 = label 2
                }
                else
                {
                    speelbord.lblaantal1.Text = Convert.ToString(Speler2.resterendestukken); //onlogisch, speler2 = label 1
                }
            }
        }
    }
}

