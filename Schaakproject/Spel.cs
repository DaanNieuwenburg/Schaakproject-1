using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Schaakproject
{
    public class Spel
    {
        public string SpelMode { get; private set; }            //Singleplayer of multiplayer
        private bool witaanzet { get; set; }                    //Wie is aan zet
        public Mens Speler1 { get; private set; }               //De speler (is er altijd)
        public Mens Speler2 { get; private set; }               //De tweede speler voor multiplayer
        public Computer computerSpeler { get; private set; }    //De computer voor singleplayer
        public Speler spelerAanZet { get; private set; }        //welke speler is aan zet
        public Vakje selected { get; set; }                     //Maakt de computer gebruik van
        public string Variant { get; private set; }             //Klassiek of Chess960
        public Schaakbord schaakbord { get; private set; }      //Het schaakbord wordt onthouden
        private Color _bordercolor { get; set; }                //De kleur voor de rand
        private Color _selectcolor { get; set; }                //De kleur voor het selecteren
        public SpeelBord speelbord { get; private set; }        //Het speelbord window

        public Spel(string Mode, string NaamSpeler1, string NaamSpeler2, string Variant, Color borderColor, Color selectColor)
        {
            _selectcolor = selectColor;
            _bordercolor = borderColor;
            SpelMode = Mode;
            this.Variant = Variant;

            Mens speler1 = new Mens(NaamSpeler1, "wit", this, _selectcolor);
            Speler1 = speler1;
            spelerAanZet = Speler1;

            if (SpelMode == "Singleplayer")
            {
                Computer computerSpeler = new Computer(NaamSpeler2, "zwart", _selectcolor);
                this.computerSpeler = computerSpeler;
            }

            else if (Mode == "Multiplayer")
            {
                Mens speler2 = new Mens(NaamSpeler2, "zwart", this, _selectcolor);
                Speler2 = speler2;
            }

            Start();
        }

        public void Start()
        {
            //Hij maakt een nieuw schaakbord waarin de logica zit
            Schaakbord schaakbord = new Schaakbord(Variant, this, Speler1, Speler2);
            this.schaakbord = schaakbord;

            //Hij maakt een nieuw speelbord (een window)
            SpeelBord speelbord = new SpeelBord(this, schaakbord, SpelMode, Speler1, Speler2, computerSpeler, Variant, _bordercolor);
            this.speelbord = speelbord;
            speelbord.Show();
        }

        public void Herstart(string spelMode, string speler1Naam, string speler2Naam)
        {
            if (spelMode == "Multiplayer")
            {
                Spel spel = new Spel(spelMode, speler1Naam, speler2Naam, Variant, _bordercolor, _selectcolor);
            }
            else
            {
                Spel spel = new Spel(spelMode, speler1Naam, "comp", Variant, _bordercolor, _selectcolor);
            }
        }

        public void veranderlbltext()
        {
            //Hier wordt de label met daarin welke speler aan zet is aangepast wanneer de speler wisselt;
            if (SpelMode == "Multiplayer")
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
        }

        public void VeranderSpeler()
        {
            //Iedere keer dat een legale zet gedaan is, wordt de speler gewisseld

            //Bekijk of het spel remise is doordat er te weinig stukken zijn
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
            
            //zodat je ziet wie er aan zet is
            veranderlbltext();

            bool schaak;
            bool mat;
            bool pat;
            
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

