﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schaakproject
{
    public partial class SpeelBord : Form
    {
        private string _SpelMode { get; set; }              //Singleplayer of multiplayer
        private Schaakbord _schaakbord { get; set; }        //Een schaakbord
        private Mens _speler1 { get; set; }                 //Speler1
        private Mens _speler2 { get; set; }                 //Speler2
        private Computer _computerSpeler { get; set; }      //Computer
        private Spel _spel { get; set; }                    //Een spel
        private int clicks { get; set; }                    //voor het laten zien van de uitleg
        public string variant { get; set; }                //string voor spelvariant
        private bool _witaanzet { get; set; }
        public SpeelBord(Spel spel, Schaakbord schaakbord, string SpelMode, Mens Speler1, Mens Speler2, Computer computerSpeler, string Variant)
        {
            clicks = 0;
            _SpelMode = SpelMode;
            variant = Variant;
            InitializeComponent();

            _speler1 = Speler1;
            _speler2 = Speler2;
            if (_speler1.Naam == "")
            {
                _speler1.Naam = "Wit";
            }
            if (_speler2.Naam == "")
            {
                _speler2.Naam = "Zwart";
            }

            lblbeurt.Text = _speler1.Naam + " is aan zet";

            _computerSpeler = computerSpeler;
            _spel = spel;
            this.CenterToScreen();
            lblaantal1.Text = Convert.ToString(_speler1.resterendestukken); //hier moet de variabele komen voor het aantal van wit
            if(spel.SpelMode != "Singleplayer")
            {
                lblaantal2.Text = Convert.ToString(_speler2.resterendestukken); //hier moet de variabele komen voor het aantal van wit
            }
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    // Maak pictureboxes
                    SpecialPB pictureBox = new SpecialPB();
                    pictureBox.Location = new Point(12 + 54 * y, 50 + 54 * x);
                    pictureBox.Size = new Size(54, 54);
                    pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    pictureBox.TabIndex = 0;
                    pictureBox.TabStop = false;
                    this.Controls.Add(pictureBox);

                    // Koppel SpecialPB aan Vakje
                    pictureBox.vakje = schaakbord.schaakarray[x, y];
                    pictureBox.BackColor = pictureBox.vakje.kleur;
                    schaakbord.schaakarray[x, y].pbox = pictureBox;

                    pictureBox.update(); // Laat schaakstukken zien

                    pictureBox.Click += new EventHandler((o, a) => select(pictureBox));
                }

            }

            // Het spel is singleplayer of multiplayer
            if (_SpelMode.Equals("Singleplayer"))
            {
                lblPlayer1.Text = _speler1.Naam;
                lblPlayer2.Text = "COMP";
            }
            else if (_SpelMode.Equals("Multiplayer"))
            {
                Console.WriteLine("tlest " + _speler1.Naam);
                lblPlayer1.Text = "P1: " + _speler1.Naam;
                lblPlayer2.Text = "P2: " + _speler2.Naam;
            }
            else if (_SpelMode.Equals("Online"))
            {
                Console.WriteLine("tlest " + _speler1.Naam);
                lblPlayer1.Text = "P1: " + Speler1.Naam;
            }
        }

        private void select(SpecialPB pictureBox) //click event voor alle pictureboxes
        {
            if (_SpelMode == "Singleplayer")
            {
                if (_spel.spelerAanZet == _speler1)
                {
                    if (pictureBox.vakje.schaakstuk != null && pictureBox.vakje.schaakstuk.kleur == _speler1.Kleur)
                    {
                        _computerSpeler.slaanmogelijkheden.Clear();
                        _computerSpeler.slaanmogelijkhedenVanaf.Clear();
                        _speler1.SelecteerStuk(pictureBox.vakje, _spel);
                    }
                    else
                    {
                        _speler1.SelecteerVakje(pictureBox.vakje, _spel);
                        _computerSpeler.Zet(pictureBox.vakje, _spel, _speler1);
                    }
                }
                else
                {
                    //_computerSpeler.Zet(pictureBox.vakje, _spel, _speler1);
                }
            }

            else if (_SpelMode == "Multiplayer")
            {
                if (_spel.spelerAanZet == _speler1)
                {
                    //_spel.controleerOpSchaak();
                    //als de picturebox waarop gedrukt is wel een schaakstuk heeft en dit schaakstuk de kleur heeft van de speler
                    if (pictureBox.vakje.schaakstuk != null && pictureBox.vakje.schaakstuk.kleur == _speler1.Kleur)
                    {
                        _speler1.SelecteerStuk(pictureBox.vakje, _spel);
                    }
                    else
                    {
                        _speler1.SelecteerVakje(pictureBox.vakje, _spel);
                    }
                }
                else
                {
                    //_spel.controleerOpSchaak();
                    if (pictureBox.vakje.schaakstuk != null && pictureBox.vakje.schaakstuk.kleur == _speler2.Kleur)
                    {
                        _speler2.SelecteerStuk(pictureBox.vakje, _spel);
                    }
                    else
                    {
                        _speler2.SelecteerVakje(pictureBox.vakje, _spel);
                    }
                }
            }
            else if (_SpelMode == "Online")
            {

                if (_spel.spelerAanZet == _speler1)
                {
                    //als de picturebox waarop gedrukt is wel een schaakstuk heeft en dit schaakstuk de kleur heeft van de speler
                    if (pictureBox.vakje.schaakstuk != null && pictureBox.vakje.schaakstuk.kleur == _speler1.Kleur)
                    {
                        _speler1.SelecteerStuk(pictureBox.vakje, _spel);
                    }
                    else
                    {
                        _speler1.SelecteerVakje(pictureBox.vakje, _spel);
                    }
                }
                else
                {
                    if (pictureBox.vakje.schaakstuk != null && pictureBox.vakje.schaakstuk.kleur == _speler2.Kleur)
                    {
                        _speler2.SelecteerStuk(pictureBox.vakje, _spel);
                    }
                    else
                    {
                        _speler2.SelecteerVakje(pictureBox.vakje, _spel);
                    }
                }
            }
        }

        private void SpeelBord_Load(object sender, EventArgs e)
        {
            //hierdoor zijn de plaatjes ook zichtbaar zonder er eerst overheen te hoveren met je muis
            btnregels.BackgroundImage = Properties.Resources.button_regels_2;
            btnterug.BackgroundImage = Properties.Resources.button_terug_2;
            btHerstart.BackgroundImage = Properties.Resources.button_herstart_2;
            btnkoning.BackgroundImage = Properties.Resources.button_regels_koning;
            btndame.BackgroundImage = Properties.Resources.button_regels_dame;
            btnpion.BackgroundImage = Properties.Resources.button_regels_pion;
            btnloper.BackgroundImage = Properties.Resources.button_regels_loper;
            btntoren.BackgroundImage = Properties.Resources.button_regels_toren;
            btnpaard.BackgroundImage = Properties.Resources.button_regels_paard;
            btnregels.Visible = true;
            if (variant == "Chess960")
            {
                btnvariant.BackgroundImage = Properties.Resources.button_regels_chess960;
            }
            else
            {
                btnvariant.BackgroundImage = Properties.Resources.button_klassiekregels;
            }
        }

        private void SpeelBord_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();  // sluit applicatie af
        }

        private void btHerstart_Click(object sender, EventArgs e)
        {
            btHerstart.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent bordercolor (Color.Transparent is unsupported)
            Console.WriteLine("HERSTART");
            HerstartMelding Warning = new HerstartMelding();
            Warning.ShowDialog();
            if (_SpelMode == "Singleplayer")
            {
                if (Warning.Sure == true)
                {
                    this.Hide();
                    _spel.Herstart(_SpelMode, _speler1.Naam, "COMP");
                }
            }
            else
            {
                if (Warning.Sure == true)
                {
                    this.Hide();
                    _spel.Herstart(_SpelMode, _speler1.Naam, _speler2.Naam);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnvariant_Click(object sender, EventArgs e)
        {
            clicks++;
            lbluitleg.Visible = true;
            if (variant == "Chess960")
            {
                pbuitleg.Image = Properties.Resources.chess960_uitleg_2;
                pbuitleg.Visible = true;
                lbluitleg.Text = ("Chess960\nChess960 of Schaak960 is een variant\nvan het klassieke schaakspel. Hierbij\nworden in tegenstelling tot de klassieke\nvariant de schaakstukken van de eerste rij\nop een random positie geplaatst. Doordat\nhet aantal mogelijkheden 960 is zullen begin\ntactieken niet altijd gelden.");
            }
            else
            {
                lbluitleg.Text = ("Klassiek Schaken\nKlassiek schaken is het oeroude\nschaakspel, waarbij twee spelers\nmet behulp van dezelfde muis tegenelkaar\nkunnen schaken. De regels zijn\nbekend: Alle stukken bewegen op hun\neigen manier.Als één van jouw stukken\nop een vakje komt van een stuk van de\ntegenstander dan verdwijnt dat stuk van\nhet bord.Als je de koning van de\ntegenstander slaat heb je gewonnen.");
                pbuitleg.Image = Properties.Resources.schaken_uitleg_1;
                pbuitleg.Visible = false;
            }
            this.btndame.Visible = false;
            pbuitleg.BackgroundImage = Properties.Resources.zettenpaard;
            pbuitleg.Visible = true;
            this.btnkoning.Visible = false;
            this.btntoren.Visible = false;
            this.btnloper.Visible = false;
            this.btnpaard.Visible = false;
            this.btnpion.Visible = false;
            this.btnterug.Visible = true;
            this.btnregels.Visible = false;
            this.btnvariant.Visible = false;
        }

        private void btnregels_Click(object sender, EventArgs e)
        {
            clicks = 1;
            this.btndame.Visible = true;
            this.btnkoning.Visible = true;
            this.btntoren.Visible = true;
            this.btnloper.Visible = true;
            this.btnpaard.Visible = true;
            this.btnpion.Visible = true;
            this.btnvariant.Visible = true;
            this.btnregels.Visible = false;
        }

        private void btnpaard_Click(object sender, EventArgs e)
        {
            clicks++;
            lbluitleg.Visible = true;
            lbluitleg.Text = ("Paard\nHet paard maakt een beweging die een \ncombinatie is van 1 vlakje horizontaal of \nvertikaal, en 1 vlakje diagonaal.\nHet paard is het enige stuk dat kan \nspringen over andere stukken,\nd.w.z.het paard mag over andere \nstukken bewegen om van het ene \nnaar het andere vlakje te komen.\nDe stukken waar het paard tijdens \nzijn zet overheen springt worden \nniet beïnvloed.");
            this.btndame.Visible = false;
            pbuitleg.BackgroundImage = Properties.Resources.zettenpaard;
            pbuitleg.Visible = true;
            this.btnkoning.Visible = false;
            this.btntoren.Visible = false;
            this.btnloper.Visible = false;
            this.btnpaard.Visible = false;
            this.btnpion.Visible = false;
            this.btnterug.Visible = true;
            this.btnregels.Visible = false;
            this.btnvariant.Visible = false;
        }

        private void btnterug_Click(object sender, EventArgs e)
        {
            this.btnterug.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent bordercolor (Color.Transparent is unsupported)
            if (clicks == 0)
            {
                TerugMelding menu = new TerugMelding(this);
                menu.ShowDialog();
            }
            else if (clicks == 1)
            {
                clicks--;
                this.btndame.Visible = false;
                this.btnkoning.Visible = false;
                pbuitleg.Visible = false;
                this.btntoren.Visible = false;
                this.btnloper.Visible = false;
                this.btnpaard.Visible = false;
                this.btnpion.Visible = false;
                lbluitleg.Visible = false;
                this.btnregels.Visible = true;
                this.btnvariant.Visible = false;
                pbuitleg.Image = null;
            }
            else if (clicks == 2)
            {
                clicks--;
                this.btndame.Visible = true;
                pbuitleg.Visible = false;
                this.btnkoning.Visible = true;
                this.btntoren.Visible = true;
                this.btnloper.Visible = true;
                this.btnpaard.Visible = true;
                this.btnpion.Visible = true;
                lbluitleg.Visible = false;
                this.btnregels.Visible = false;
                this.btnvariant.Visible = true;
                pbuitleg.Image = null;
            }
        }

        private void btnkoning_Click(object sender, EventArgs e)
        {
            clicks++;
            lbluitleg.Text = ("Koning\nDe Koning mag vertikaal, horizontaal en \ndiagonaal bewegen op dezelfde manier \nals de Dame, maar slechts met 1 stapje tegelijk.\nDe Koning mag nooit een vlakje \nbetreden wat een (mogelijk) eindpunt zou \nkunnen zijn van een stuk van de tegenstander. In \nandere woorden, je kunt de Koning nooit op \neen vlakje zetten waar hij direct daarop geslagen zou \nkunnen worden door de tegenstander.");
            lbluitleg.Visible = true;
            pbuitleg.BackgroundImage = Properties.Resources.zettenkoning;
            pbuitleg.Visible = true;
            this.btndame.Visible = false;
            this.btnkoning.Visible = false;
            this.btntoren.Visible = false;
            this.btnloper.Visible = false;
            this.btnpaard.Visible = false;
            this.btnpion.Visible = false;
            this.btnterug.Visible = true;
            this.btnregels.Visible = false;
            this.btnvariant.Visible = false;
        }

        private void btndame_Click(object sender, EventArgs e)
        {
            pbuitleg.Visible = true;
            clicks++;
            lbluitleg.Text = ("Dame\nDe dame combineert de zetten\nvan de Toren en de Loper en is\ndaarmee het stuk met de grootste \nbewegingsvrijheid.De Dame mag \nhorizontaal, vertikaal en diagonaal \nbewegen in een rechte lijn en mag \nhierbij niet over andere stukken springen.");
            this.btnregels.Visible = false;
            lbluitleg.Visible = true;
            pbuitleg.BackgroundImage = Properties.Resources.zettendame;
            this.btndame.Visible = false;
            this.btnkoning.Visible = false;
            this.btntoren.Visible = false;
            this.btnloper.Visible = false;
            this.btnpaard.Visible = false;
            this.btnpion.Visible = false;
            this.btnterug.Visible = true;
            this.btnvariant.Visible = false;
        }

        private void btntoren_Click(object sender, EventArgs e)
        {
            clicks++;
            lbluitleg.Text = ("Toren\nDe toren beweegt vertikaal of horizontaal\nin een rechte lijn. De toren mag niet over\nandere stukken springen, alle vlakken\ntussen het begin en eindpunt van een\nzet dienen leeg te zijn.");
            lbluitleg.Visible = true;
            this.btndame.Visible = false;
            pbuitleg.BackgroundImage = Properties.Resources.zettentoren;
            this.btnkoning.Visible = false;
            this.btntoren.Visible = false;
            this.btnloper.Visible = false;
            this.btnpaard.Visible = false;
            this.btnpion.Visible = false;
            this.btnterug.Visible = true;
            this.btnregels.Visible = false;
            this.btnvariant.Visible = false;
            pbuitleg.Visible = true;
        }

        private void btnloper_Click(object sender, EventArgs e)
        {
            clicks++;
            lbluitleg.Text = ("Loper\nDe loper beweegt diagonaal over\nhet bord. Net als de toren mag de\nloper niet over andere stukken springen.");
            lbluitleg.Visible = true;
            pbuitleg.BackgroundImage = Properties.Resources.zettenloper;
            this.btndame.Visible = false;
            this.btnkoning.Visible = false;
            this.btntoren.Visible = false;
            this.btnloper.Visible = false;
            this.btnpaard.Visible = false;
            this.btnpion.Visible = false;
            this.btnterug.Visible = true;
            pbuitleg.Visible = true;
            this.btnvariant.Visible = false;
            this.btnregels.Visible = false;
        }

        private void btnpion_Click(object sender, EventArgs e)
        {
            clicks++;
            lbluitleg.Visible = true;
            lbluitleg.Text = ("Pion\nDe pion mag in princiepe alleen vooruit lopen.\nPer beurt mag de pion 1 vakje verplaatsen, \ntenzij de pion nog nooit is verplaatst dan mag \ndie 2 vakjes verplaatsen. Verder mag de pion alleen \nschuin slaan. Als de pion aan de andere kant van het\nbord is gekomen mag die promoveren tot\neen ander schaakstuk naar keuze.");
            this.btndame.Visible = false;
            pbuitleg.BackgroundImage = Properties.Resources.zettenpion;
            this.btnkoning.Visible = false;
            this.btntoren.Visible = false;
            this.btnloper.Visible = false;
            pbuitleg.Visible = true;
            this.btnpaard.Visible = false;
            this.btnpion.Visible = false;
            this.btnvariant.Visible = false;
            this.btnterug.Visible = true;
            this.btnregels.Visible = false;
        }

        private void btnvariant_MouseEnter(object sender, EventArgs e)
        {
            if (variant == "Chess960")
            {
                btnvariant.BackgroundImage = Properties.Resources.button_regels_chess960_click;
            }
            else
            {
                btnvariant.BackgroundImage = Properties.Resources.button_klassiekregels_click;
            }
        }

        private void btnvariant_MouseLeave(object sender, EventArgs e)
        {
            if (variant == "Chess960")
            {
                btnvariant.BackgroundImage = Properties.Resources.button_regels_chess960;
            }
            else
            {
                btnvariant.BackgroundImage = Properties.Resources.button_klassiekregels;
            }
        }

        private void btnpaard_MouseEnter(object sender, EventArgs e)
        {
            btnpaard.BackgroundImage = Properties.Resources.button_regels_paard_click;
        }

        private void btnpaard_MouseLeave(object sender, EventArgs e)
        {
            btnpaard.BackgroundImage = Properties.Resources.button_regels_paard;

        }

        private void btnkoning_MouseEnter(object sender, EventArgs e)
        {
            btnkoning.BackgroundImage = Properties.Resources.button_regels_koning_click;
        }

        private void btnkoning_MouseLeave(object sender, EventArgs e)
        {
            btnkoning.BackgroundImage = Properties.Resources.button_regels_koning;
        }

        private void btntoren_MouseEnter(object sender, EventArgs e)
        {
            btntoren.BackgroundImage = Properties.Resources.button_regels_toren_click;
        }

        private void btntoren_MouseLeave(object sender, EventArgs e)
        {
            btntoren.BackgroundImage = Properties.Resources.button_regels_toren;
        }

        private void btnloper_MouseEnter(object sender, EventArgs e)
        {
            btnloper.BackgroundImage = Properties.Resources.button_regels_loper_click1;
        }

        private void btnloper_MouseLeave(object sender, EventArgs e)
        {
            btnloper.BackgroundImage = Properties.Resources.button_regels_loper1;
        }

        private void btndame_MouseEnter(object sender, EventArgs e)
        {
            btndame.BackgroundImage = Properties.Resources.button_regels_dame_click;
        }

        private void btndame_MouseLeave(object sender, EventArgs e)
        {
            btndame.BackgroundImage = Properties.Resources.button_regels_dame;
        }

        private void btnpion_MouseEnter(object sender, EventArgs e)
        {
            btnpion.BackgroundImage = Properties.Resources.button_regels_pion_click;

        }

        private void btnpion_MouseLeave(object sender, EventArgs e)
        {
            btnpion.BackgroundImage = Properties.Resources.button_regels_pion;
        }

        private void btHerstart_MouseEnter(object sender, EventArgs e)
        {
            btHerstart.BackgroundImage = Properties.Resources.button_herstart_click_2;
        }
        private void btHerstart_MouseLeave(object sender, EventArgs e)
        {
            btHerstart.BackgroundImage = Properties.Resources.button_herstart_2;
        }

        private void btnterug_MouseEnter(object sender, EventArgs e)
        {
            btnterug.BackgroundImage = Properties.Resources.button_terug_click_2;
        }

        private void btnterug_MouseLeave(object sender, EventArgs e)
        {
            btnterug.BackgroundImage = Properties.Resources.button_terug_2;
        }

        private void btnregels_MouseLeave(object sender, EventArgs e)
        {
            btnregels.BackgroundImage = Properties.Resources.button_regels_2;
        }

        private void btnregels_MouseEnter(object sender, EventArgs e)
        {
            btnregels.BackgroundImage = Properties.Resources.button_regels_2_click;
        }
    }
}