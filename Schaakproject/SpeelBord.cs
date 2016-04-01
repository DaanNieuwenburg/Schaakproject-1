using System;
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
        private Spel _spel { get; set; }                    //Een spel
        private int _clicks { get; set; }                    //voor het laten zien van de uitleg
        private string _variant { get; set; }                //string voor spelvariant
        private int _optie { get; set; }                   //int die bijhoud welk menu van regels je zit

        public SpeelBord(Spel spel, Schaakbord schaakbord, string Variant, Color borderColor)
        {
            _spel = spel;
            _clicks = 0;
            this._variant = Variant;
            InitializeComponent();
            if (_spel.Speler1.Naam == "")
            {
                _spel.Speler1.Naam = "Wit";
            }
            if (_spel.Speler2 != null && _spel.Speler2.Naam == "")
            {
                _spel.Speler2.Naam = "Zwart";
            }

            lblbeurt.Text = _spel.Speler1.Naam + " is aan zet";
            this.CenterToScreen();
            lblaantal2.Text = Convert.ToString(_spel.Speler1.ResterendeStukken); //hier moet de variabele komen voor het aantal van wit
            if (spel.SpelMode != "Singleplayer")
            {
                lblaantal1.Text = Convert.ToString(_spel.Speler2.ResterendeStukken); //hier moet de variabele komen voor het aantal van wit
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
                    pictureBox.vakje = schaakbord.SchaakArray[x, y];
                    pictureBox.BackColor = pictureBox.vakje.Kleur;
                    schaakbord.SchaakArray[x, y].Pbox = pictureBox;

                    pictureBox.update(); // Laat schaakstukken zien

                    pictureBox.Click += new EventHandler((o, a) => select(pictureBox));
                }
            }
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1.BackgroundImage = Properties.Resources.border_transparent;
            pictureBox1.BackColor = borderColor;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(1, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(460, 460);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.Controls.Add(pictureBox1);

            // Het spel is singleplayer of multiplayer
            if (_spel.SpelMode.Equals("Singleplayer"))
            {
                lblPlayer1.Text = _spel.Speler1.Naam;
                lblPlayer2.Text = "COMP";
            }
            else if (_spel.SpelMode.Equals("Multiplayer"))
            {
                Console.WriteLine("tlest " + _spel.Speler1.Naam);
                lblPlayer1.Text = "P1: " + _spel.Speler1.Naam;
                lblPlayer2.Text = "P2: " + _spel.Speler2.Naam;
            }
            else if (_spel.SpelMode.Equals("Online"))
            {
                Console.WriteLine("tlest " + _spel.Speler1.Naam);
                lblPlayer1.Text = "P1: " + _spel.Speler1.Naam;
            }
        }

        private void select(SpecialPB pictureBox) //click event voor alle pictureboxes
        {
            if (_spel.SpelMode == "Singleplayer")
            {
                if (_spel.SpelerAanZet == _spel.Speler1)
                {
                    if (pictureBox.vakje.schaakstuk != null && pictureBox.vakje.schaakstuk.Kleur == _spel.Speler1.Kleur)
                    {
                        Console.WriteLine("Speler selecteert stuk");
                        _spel.Speler1.SelecteerStuk(pictureBox.vakje, _spel);
                    }
                    else
                    {
                        _spel.Speler1.SelecteerVakje(pictureBox.vakje, _spel);                
                    }
                }
            }

            else if (_spel.SpelMode == "Multiplayer")
            {
                if (_spel.SpelerAanZet == _spel.Speler1)
                {
                    //_spel.controleerOpSchaak();
                    //als de picturebox waarop gedrukt is wel een schaakstuk heeft en dit schaakstuk de kleur heeft van de speler
                    if (pictureBox.vakje.schaakstuk != null && pictureBox.vakje.schaakstuk.Kleur == _spel.Speler1.Kleur)
                    {
                        _spel.Speler1.SelecteerStuk(pictureBox.vakje, _spel);
                    }
                    else
                    {
                        _spel.Speler1.SelecteerVakje(pictureBox.vakje, _spel);
                    }
                }
                else
                {
                    //_spel.controleerOpSchaak();
                    if (pictureBox.vakje.schaakstuk != null && pictureBox.vakje.schaakstuk.Kleur == _spel.Speler2.Kleur)
                    {
                        _spel.Speler2.SelecteerStuk(pictureBox.vakje, _spel);
                    }
                    else
                    {
                        _spel.Speler2.SelecteerVakje(pictureBox.vakje, _spel);
                    }
                }
            }
            else if (_spel.SpelMode == "Online")
            {

                if (_spel.SpelerAanZet == _spel.Speler1)
                {
                    //als de picturebox waarop gedrukt is wel een schaakstuk heeft en dit schaakstuk de kleur heeft van de speler
                    if (pictureBox.vakje.schaakstuk != null && pictureBox.vakje.schaakstuk.Kleur == _spel.Speler1.Kleur)
                    {
                        _spel.Speler1.SelecteerStuk(pictureBox.vakje, _spel);
                    }
                    else
                    {
                        _spel.Speler1.SelecteerVakje(pictureBox.vakje, _spel);
                    }
                }
                else
                {
                    if (pictureBox.vakje.schaakstuk != null && pictureBox.vakje.schaakstuk.Kleur == _spel.Speler2.Kleur)
                    {
                        _spel.Speler2.SelecteerStuk(pictureBox.vakje, _spel);
                    }
                    else
                    {
                        _spel.Speler2.SelecteerVakje(pictureBox.vakje, _spel);
                    }
                }
            }
        }

        private void SpeelBord_Load(object sender, EventArgs e)
        {
            btHerstart.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent bordercolor (Color.Transparent is unsupported)
           
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
            if (_spel.SpelMode == "Singleplayer")
            {
                if (Warning.Sure == true)
                {
                    this.Hide();
                    _spel.Herstart(_spel.SpelMode, _spel.Speler1.Naam, "COMP");
                }
            }
            else
            {
                if (Warning.Sure == true)
                {
                    this.Hide();
                    _spel.Herstart(_spel.SpelMode, _spel.Speler1.Naam, _spel.Speler2.Naam);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnvariant_Click(object sender, EventArgs e)
        {
            if (_clicks == 2 && _optie == 1)
            {
                _clicks++;
                lbluitleg.Visible = true;
                if (_variant == "Chess960")
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
            else if (_clicks == 2 && _optie == 3)
            {
                _clicks++;
                pbuitleg.Image = Properties.Resources.uitleg_promoveren;
                lbluitleg.Text = ("Promoveren\nWanneer een pion het einde van\nhet bord bereikt heeft, mag hij\npromoveren. Dit houd in dat de\npion vervangen mag worden door\neen paard, dame, loper of toren.\nhet is niet mogelijk om naar een\nkoning of pion te promoveren.");
                this.btndame.Visible = false;
                lbluitleg.Visible = true;
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
            else if (_clicks == 1)
            {
                _optie = 1;
                _clicks++;
                if (_variant == "Chess960")
                {
                    btnvariant.BackgroundImage = Properties.Resources.button_regels_chess960;
                }
                else
                {
                    btnvariant.BackgroundImage = Properties.Resources.button_klassiekregels;
                }
                this.btndame.Visible = false;
                btnpaard.BackgroundImage = Properties.Resources.button_regels_schaak;
                btntoren.BackgroundImage = Properties.Resources.button_regels_mat;
                btnloper.BackgroundImage = Properties.Resources.button_regels_remise;
                this.btnkoning.Visible = false;
                this.btntoren.Visible = true;
                this.btnloper.Visible = true;
                this.btnpaard.Visible = true;
                this.btnpion.Visible = false;
                this.btnvariant.Visible = true;
                this.btnregels.Visible = false;

            }
        }

        private void btnregels_Click(object sender, EventArgs e)
        {
            btnvariant.BackgroundImage = Properties.Resources.button_spel_1;
            btnpaard.BackgroundImage = Properties.Resources.button_regels_stukken;
            btntoren.BackgroundImage = Properties.Resources.button_regels_zetten;
            _optie = 0;
            _clicks = 1;
            this.btndame.Visible = false;
            this.btnkoning.Visible = false;
            this.btntoren.Visible = true;
            this.btnloper.Visible = false;
            this.btnpaard.Visible = true;
            this.btnpion.Visible = false;
            this.btnvariant.Visible = true;
            this.btnregels.Visible = false;

        }

        private void btnpaard_Click(object sender, EventArgs e)
        {
            if (_clicks == 1)
            {
                _optie = 2;
                _clicks++;
                this.btnkoning.Visible = true;
                this.btndame.Visible = true;
                this.btntoren.Visible = true;
                this.btnloper.Visible = true;
                this.btnpaard.Visible = true;
                this.btnpion.Visible = true;
                this.btnterug.Visible = true;
                this.btnregels.Visible = false;
                this.btnvariant.Visible = false;
            }
            else if (_clicks == 2 && _optie == 1)
            {
                //schaak uitleg
                _clicks++;
                lbluitleg.Visible = true;
                lbluitleg.Text = ("Schaak\nSchaak is een opstelling waarbij\nde koning geslagen kan worden, maar\nde schaak nog kan worden opgeheven.\ndit kan op 3 manieren:\n - het verplaatsen van de koning\n - het schaakzettende stuk slaan\n - een stuk tussen de koning en\nhet schaakzettende stuk plaatsen.");
                this.btndame.Visible = false;
                pbuitleg.BackgroundImage = Properties.Resources.uitleg_schaak;
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
            else if (_clicks == 2 && _optie == 2)
            {
                //paard uitleg
                _clicks++;
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
            else if (_clicks == 2 && _optie == 3)
            {

                //Rokeren uitleg
                _clicks++;
                lbluitleg.Visible = true;
                lbluitleg.Text = ("Rokeren\nEr zijn 2 rokades mogelijk in een spel.\nEen lange en een korte rokade. Bij\nrokeren mag zowel de koning als de\nbetreffende toren niet verplaatst zijn.\nOok mogen de vlakken tussen te koning\nen de toren niet geslagen kunnen worden\ntijdens de rokade. De koning en toren\nveranderen van plaats.Hierna is een\nandere rokade niet meer mogelijk voor\ndie speler.");
                this.btndame.Visible = false;
                pbuitleg.BackgroundImage = Properties.Resources.uitleg_rokeren;
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
        }


        private void btnterug_Click(object sender, EventArgs e)
        {
            this.btnterug.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent bordercolor (Color.Transparent is unsupported)
            if (_clicks == 0)
            {
                TerugMelding menu = new TerugMelding(this, _spel);
                menu.ShowDialog();
            }
            else if (_clicks == 1)
            {
                
                _clicks--;
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
            else if (_clicks == 2)
            {
                _optie = 0;
                btnvariant.BackgroundImage = Properties.Resources.button_spel_1;
                btntoren.BackgroundImage = Properties.Resources.button_regels_zetten;
                btnpaard.BackgroundImage = Properties.Resources.button_regels_stukken;
                _clicks--;
                this.btndame.Visible = false;
                this.btnkoning.Visible = false;
                pbuitleg.Visible = false;
                this.btntoren.Visible = true;
                this.btnloper.Visible = false;
                this.btnpaard.Visible = true;
                this.btnpion.Visible = false;
                lbluitleg.Visible = false;
                this.btnregels.Visible = false;
                this.btnvariant.Visible = true;
                pbuitleg.Image = null;
            }
            else if (_clicks == 3)
            {
                if (_optie == 1)
                {
                    _clicks--;
                    this.btndame.Visible = false;
                    pbuitleg.Visible = false;
                    this.btnkoning.Visible = false;
                    this.btntoren.Visible = true;
                    this.btnloper.Visible = true;
                    this.btnpaard.Visible = true;
                    this.btnpion.Visible = false;
                    lbluitleg.Visible = false;
                    this.btnregels.Visible = false;
                    this.btnvariant.Visible = true;
                    pbuitleg.Image = null;
                }
                else if (_optie == 2)
                {
                    _clicks--;
                    this.btndame.Visible = true;
                    pbuitleg.Visible = false;
                    this.btnkoning.Visible = true;
                    this.btntoren.Visible = true;
                    this.btnloper.Visible = true;
                    this.btnpaard.Visible = true;
                    this.btnpion.Visible = true;
                    lbluitleg.Visible = false;
                    this.btnregels.Visible = false;
                    this.btnvariant.Visible = false;
                    pbuitleg.Image = null;
                }
                else if (_optie == 3)
                {
                    _clicks--;
                    this.btndame.Visible = false;
                    pbuitleg.Visible = false;
                    this.btnkoning.Visible = false;
                    this.btntoren.Visible = true;
                    this.btnloper.Visible = false;
                    this.btnpaard.Visible = true;
                    this.btnpion.Visible = false;
                    lbluitleg.Visible = false;
                    this.btnregels.Visible = false;
                    this.btnvariant.Visible = true;
                    pbuitleg.Image = null;
                }
            }
            
        }

        private void btnkoning_Click(object sender, EventArgs e)
        {
            //Koning uitleg
            _clicks++;
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
            // Dame uitleg
            pbuitleg.Visible = true;
            _clicks++;
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
            if (_clicks == 1)
            {
                // Menu zetten 
                _optie = 3;
                _clicks++;
                btnpaard.BackgroundImage = Properties.Resources.button_regels_rokeren;
                btntoren.BackgroundImage = Properties.Resources.button_regels_enpassant;
                btnvariant.BackgroundImage = Properties.Resources.button_regels_promoveren;
                this.btnkoning.Visible = false;
                this.btndame.Visible = false;
                this.btntoren.Visible = true;
                this.btnloper.Visible = false;
                this.btnpaard.Visible = true;
                this.btnpion.Visible = false;
                this.btnterug.Visible = true;
                this.btnregels.Visible = false;
                this.btnvariant.Visible = true;
            }
            else if (_clicks == 2 && _optie == 1)
            {
                //schaakmat uitleg
                _clicks++;
                lbluitleg.Visible = true;
                lbluitleg.Text = ("Schaakmat\nBij schaakmat staat de koning schaak\nhet enige verschil is dat de koning ook\nnergens meer heen kan verplaatsen \nzonder schaak te blijven staan. Dit\nis schaakmat. Bij schaakmat is het \nspel afgelopen en heeft de speler die mat\nstaat verloren.");
                this.btndame.Visible = false;
                pbuitleg.BackgroundImage = Properties.Resources.uitlegmat;
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
            else if (_clicks == 2 && _optie == 2)
            {
                // Toren uitleg
                _clicks++;
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
            else if (_clicks == 2 && _optie == 3)
            {
                //En-passant uitleg
                _clicks++;
                lbluitleg.Visible = true;
                lbluitleg.Text = ("En - Passant\nAls een pion 2 vlakken naar voren\nwordt gezet, kan deze en-passant\ngeslagen worden. Dit kan doordat\nde tegenstander dan het vlakje aanvalt\nwaar de pion op zou staan, als die maar\n1 vakje naar voren was gegaan.Dit \nmoet wel in de eerst volgende zet gebeuren.\nGebeurt dit niet, dan is de pion veilig.");
                this.btndame.Visible = false;
                pbuitleg.BackgroundImage = Properties.Resources.uitleg_enpassant;
                pbuitleg.Visible = true;
                this.btnkoning.Visible = false;
                this.btntoren.Visible = false;
                this.btnloper.Visible = false;
                this.btnpaard.Visible = false;
                this.btnpion.Visible = false;
                this.btnterug.Visible = true;
                this.btnregels.Visible = false;
                this.btnvariant.Visible = false;
            }}

        private void btnloper_Click(object sender, EventArgs e)
        {
            if(_optie == 1)
            {
                // Remise uitleg
                _clicks++;
                lbluitleg.Text = ("Remise\nDit schaakspel kent 2 vormen van remise:\n- Schaak pat: Bij pat staan de stukken zo opgesteld\ndat de koning niet schaak staat, maar ook niet\nkan bewegen zonder schaak te komen staan.\nVerder zijn er geen stukken die je kan verplaatsen.\n- Te weinig stukken: Bij deze vorm van remise\nhebben beide spelers nog te weinig stukken om\nde ander schaakmat te zetten. Hierbij eindigt\nhet ook met gelijkspel.");
                lbluitleg.Visible = true;
                pbuitleg.BackgroundImage = Properties.Resources.uitleg_remise;
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
            else
            {
                // Loper uitleg
                _clicks++;
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
            
        }

        private void btnpion_Click(object sender, EventArgs e)
        {
            // Pion uitleg
            _clicks++;
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
        
        // ↓↓↓ Vanaf hier komen de MouseEnter en MouseLeave events voor de knoppen in het regel menu ↓↓↓

        private void btnvariant_MouseEnter(object sender, EventArgs e)
        {
            if (_optie == 0)
            {
                btnvariant.BackgroundImage = Properties.Resources.button_spel_1_click;
            }
            else if (_optie == 1)
            {
                if (_variant == "Chess960")
                {
                    btnvariant.BackgroundImage = Properties.Resources.button_regels_chess960_click;
                }
                else
                {
                    btnvariant.BackgroundImage = Properties.Resources.button_klassiekregels_click;
                }
            }
            else if (_optie == 3)
            {
                btnvariant.BackgroundImage = Properties.Resources.button_regels_promoveren_click;
            }
        }

        private void btnvariant_MouseLeave(object sender, EventArgs e)
        {
            if (_optie == 0)
            {
                btnvariant.BackgroundImage = Properties.Resources.button_spel_1;
            }
            else if (_optie == 1)
            {
                if (_variant == "Chess960")
                {
                    btnvariant.BackgroundImage = Properties.Resources.button_regels_chess960;
                }
                else
                {
                    btnvariant.BackgroundImage = Properties.Resources.button_klassiekregels;
                }
            }
            else if (_optie == 3)
            {
                btnvariant.BackgroundImage = Properties.Resources.button_regels_promoveren;
            }
        }

        private void btnpaard_MouseEnter(object sender, EventArgs e)
        {
            if (_optie == 0)
            {
                btnpaard.BackgroundImage = Properties.Resources.button_regels_stukken_click;
            }
            else if (_optie == 1)
            {
                btnpaard.BackgroundImage = Properties.Resources.button_regels_schaak_click;
            }
            else if (_optie == 3)
            {
                btnpaard.BackgroundImage = Properties.Resources.button_regels_rokeren_click;
            }
            else
            {
                btnpaard.BackgroundImage = Properties.Resources.button_regels_paard_click;
            }

        }

        private void btnpaard_MouseLeave(object sender, EventArgs e)
        {
            if (_optie == 0)
            {
                btnpaard.BackgroundImage = Properties.Resources.button_regels_stukken;
            }
            else if (_optie == 1)
            {
                btnpaard.BackgroundImage = Properties.Resources.button_regels_schaak;
            }
            else if (_optie == 3)
            {
                btnpaard.BackgroundImage = Properties.Resources.button_regels_rokeren;
            }
            else
            {
                btnpaard.BackgroundImage = Properties.Resources.button_regels_paard;
            }

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
            if (_optie == 0)
            {
                btntoren.BackgroundImage = Properties.Resources.button_regels_zetten_click;
            }
            else if (_optie == 1)
            {
                btntoren.BackgroundImage = Properties.Resources.button_regels_mat_click;
            }
            else if (_optie == 2)
            {
                btntoren.BackgroundImage = Properties.Resources.button_regels_toren_click;
            }
            else if (_optie == 3)
            {
                btntoren.BackgroundImage = Properties.Resources.button_regels_enpassant_click;
            }
        }

        private void btntoren_MouseLeave(object sender, EventArgs e)
        {
            if (_optie == 0)
            {
                btntoren.BackgroundImage = Properties.Resources.button_regels_zetten;
            }
            else if (_optie == 1)
            {
                btntoren.BackgroundImage = Properties.Resources.button_regels_mat;
            }
            else if (_optie == 2)
            {
                btntoren.BackgroundImage = Properties.Resources.button_regels_toren;
            }
            else if (_optie == 3)
            {
                btntoren.BackgroundImage = Properties.Resources.button_regels_enpassant;
            }
        }

        private void btnloper_MouseEnter(object sender, EventArgs e)
        {
            if (_optie == 1)
            {
                btnloper.BackgroundImage = Properties.Resources.button_regels_remise_click;
            }
            else
            {
                btnloper.BackgroundImage = Properties.Resources.button_regels_loper_click1;

            }
        }

        private void btnloper_MouseLeave(object sender, EventArgs e)
        {
            if (_optie == 1)
            {
                btnloper.BackgroundImage = Properties.Resources.button_regels_remise;
            }
            else
            {
                btnloper.BackgroundImage = Properties.Resources.button_regels_loper1;

            }
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