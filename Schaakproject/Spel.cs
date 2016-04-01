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
        private bool _witAanzet { get; set; }                   //Wie is aan zet
        public Mens Speler1 { get; private set; }               //De speler (is er altijd)
        public Mens Speler2 { get; private set; }               //De tweede speler voor multiplayer
        public Computer ComputerSpeler { get; private set; }    //De computer voor singleplayer
        public Speler SpelerAanZet { get; private set; }        //welke speler is aan zet
        public Vakje Selected { get; set; }                     //Maakt de computer gebruik van
        public string Variant { get; private set; }             //Klassiek of Chess960
        public Schaakbord schaakbord { get; private set; }      //Het schaakbord wordt onthouden

        public Color BorderColor { get; private set; }         //De kleur voor de rand
        public Color SelectColor { get; private set; }         //De kleur voor het selecteren
        public Color ColorVakje1 { get; private set; }         //De kleur van het eerste vakje
        public Color ColorVakje2 { get; private set; }         //De kleur van het tweede vakje

        public SpeelBord speelbord { get; private set; }        //Het speelbord window

        public Spel(string Mode, string NaamSpeler1, string NaamSpeler2, string Variant, Color borderColor, Color selectColor, Color vakje1, Color vakje2)
        {
            ColorVakje1 = vakje1;
            ColorVakje2 = vakje2;
            SelectColor = selectColor;
            BorderColor = borderColor;
            SpelMode = Mode;
            this.Variant = Variant;

            Mens speler1 = new Mens(NaamSpeler1, "wit", this, SelectColor);
            Speler1 = speler1;
            SpelerAanZet = Speler1;

            if (SpelMode == "Singleplayer")
            {
                Computer computerSpeler = new Computer(NaamSpeler2, "zwart", SelectColor, this);
                this.ComputerSpeler = computerSpeler;
            }

            else if (Mode == "Multiplayer")
            {
                Mens speler2 = new Mens(NaamSpeler2, "zwart", this, SelectColor);
                Speler2 = speler2;
            }

            Start(BorderColor);
        }

        public void Start(Color BorderColor)
        {
            //Hij maakt een nieuw schaakbord waarin de logica zit
            Schaakbord schaakbord = new Schaakbord(Variant, this, Speler1, Speler2, ColorVakje1, ColorVakje2);
            this.schaakbord = schaakbord;

            //Hij maakt een nieuw speelbord (een window)
            SpeelBord speelbord = new SpeelBord(this, schaakbord, Variant, BorderColor);
            this.speelbord = speelbord;
            speelbord.Show();
        }

        public void Herstart(string spelMode, string speler1Naam, string speler2Naam)
        {
            if (spelMode == "Multiplayer")
            {
                Spel spel = new Spel(spelMode, speler1Naam, speler2Naam, Variant, BorderColor, SelectColor, ColorVakje1, ColorVakje2);
            }
            else
            {
                Spel spel = new Spel(spelMode, speler1Naam, "comp", Variant, BorderColor, SelectColor, ColorVakje1, ColorVakje2);
            }
        }

        public void veranderlbltext()
        {
            //Hier wordt de label met daarin welke speler aan zet is aangepast wanneer de speler wisselt;
            if (SpelMode == "Multiplayer")
            {
                if (_witAanzet == false)
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
            Console.WriteLine("VeranderSPELER");
            //Iedere keer dat een legale zet gedaan is, wordt de speler gewisseld

            //Bekijk of het spel remise is doordat er te weinig stukken zijn
            if (SpelMode == "Multiplayer")
            {
                if (Speler1.AantalStukken[5] < 3 && Speler2.AantalStukken[5] < 3)
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
                Console.WriteLine("Check remise SP");
                if (Speler1.AantalStukken[5] < 3 && ComputerSpeler.AantalStukken[5] < 3)
                {
                    bool checkweingstukken = schaakbord.CheckWeinigStukken(Speler1, ComputerSpeler);
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

            if (SpelerAanZet == Speler1)
            {
                Console.WriteLine("Speleraanzet == speler1");
                _witAanzet = true;
                if (SpelMode == "Singleplayer")
                {
                    SpelerAanZet = ComputerSpeler;
                    schaak = schaakbord.CheckSchaak(ComputerSpeler.koning.Vakje, ComputerSpeler.koning.Kleur);
                }
                else
                {
                    SpelerAanZet = Speler2;
                    schaak = schaakbord.CheckSchaak(Speler2.koning.Vakje, Speler2.koning.Kleur);
                }
                if (schaak == true)
                {
                    if (SpelMode == "Singleplayer")
                    {
                        mat = schaakbord.CheckMat(ComputerSpeler.koning);
                        if (mat == true)
                        {
                            Console.WriteLine("HUIDIGE SPELER  = " + ComputerSpeler.Kleur);
                            Console.WriteLine("MAT IS TRUE");
                            ComputerSpeler.koning.Vakje.Pbox.Image = Properties.Resources.ZwartMat1;
                            SchaakMat _SchaakMat = new SchaakMat(Speler1.Naam, this);
                            _SchaakMat.ShowDialog();
                            speelbord.Hide();
                        }
                        else
                        {
                            // computer reageert op schaak
                            ComputerSpeler.algoritme.zojuistSchaak = true;
                            Console.WriteLine("REAGEER OP SCHAAK " + SpelerAanZet.Kleur);
                            Selected.Pbox.BackColor = Color.Blue;
                            ComputerSpeler.algoritme.StaatSchaak = true;
                            ComputerSpeler.algoritme.reageerOpSchaak(Selected);
                        }
                    }
                    else
                    {

                        mat = schaakbord.CheckMat(Speler2.koning);
                        if (mat == true)
                        {
                            Speler2.koning.Vakje.Pbox.Image = Properties.Resources.ZwartMat1;
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

                        pat = schaakbord.CheckPat(Speler2.koning);
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
                _witAanzet = false;
                SpelerAanZet = Speler1;
                schaak = schaakbord.CheckSchaak(Speler1.koning.Vakje, Speler1.koning.Kleur);
                if (schaak == true)
                {
                    mat = schaakbord.CheckMat(Speler1.koning);
                    if (mat == true)
                    {
                        if(SpelMode == "Singleplayer")
                        {
                            Speler1.koning.Vakje.Pbox.Image = Properties.Resources.WitMat1;
                            SchaakMat _SchaakMat = new SchaakMat("De computer ", this);
                            _SchaakMat.ShowDialog();
                            speelbord.Hide();
                        }
                        else
                        {
                            Speler1.koning.Vakje.Pbox.Image = Properties.Resources.WitMat1;
                            SchaakMat _SchaakMat = new SchaakMat(Speler2.Naam, this);
                            _SchaakMat.ShowDialog();
                            speelbord.Hide();
                        }
                    }
                }
                else
                {
                    pat = schaakbord.CheckPat(Speler1.koning);
                    if (pat == true)
                    {
                        RemiseMelding _remise = new RemiseMelding(this);
                        _remise.ShowDialog();
                        speelbord.Hide();
                    }
                }
            }
        }

        public void updateAantalStukken(Speler speler)
        {
            if (speler.Kleur == "wit")
            {
                Speler1.ResterendeStukken = Speler1.ResterendeStukken - 1;
                speelbord.lblaantal1.Text = Convert.ToString(Speler1.ResterendeStukken);
            }
            else
            {
                if (SpelMode != "Singleplayer")
                {
                    Speler2.ResterendeStukken = Speler2.ResterendeStukken - 1;
                    speelbord.lblaantal2.Text = Convert.ToString(Speler2.ResterendeStukken);
                }
            }
        }
    }
}

