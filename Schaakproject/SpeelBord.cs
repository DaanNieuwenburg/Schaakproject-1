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
        private string _SpelMode { get; set; }
        private Schaakbord _schaakbord { get; set; }
        private Mens _speler1 { get; set; }
        private Mens _speler2 { get; set; }
        private Computer _computerSpeler { get; set; }
        private Spel _spel { get; set; }
        private int clicks { get; set; }
        public SpeelBord(Spel spel, Schaakbord schaakbord, string SpelMode, Mens Speler1, Mens Speler2, Computer computerSpeler)
        {
            _SpelMode = SpelMode;

            InitializeComponent();
            _speler1 = Speler1;
            _speler2 = Speler2;
            _computerSpeler = computerSpeler;
            _spel = spel;
            this.CenterToScreen();
            lblaantal1.Text = "xx"; //hier moet de variabele komen voor het aantal van wit
            lblaantal2.Text = "xx"; //hier moet de variabele komen voor het aantal van zwart
            bool zwartwit = false;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    // Maak vakjes pictures
                    SpecialPB pictures = new SpecialPB();
                    if (zwartwit == false)
                    {
                        pictures.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
                    }
                    else
                    {
                        pictures.BackColor = Color.SaddleBrown;
                    }
                    pictures.Location = new Point(12 + 54 * y, 50 + 54 * x);
                    pictures.Size = new Size(54, 54);
                    pictures.SizeMode = PictureBoxSizeMode.CenterImage;
                    pictures.TabIndex = 0;
                    pictures.TabStop = false;

                    this.Controls.Add(pictures);
                    pictures.vakje = schaakbord.schaakarray[x, y];
                    schaakbord.schaakarray[x, y].pbox = pictures;
                    schaakbord.schaakarray[x, y].update();

                    pictures.Click += new EventHandler((o, a) => select(pictures));

                    zwartwit = !zwartwit;
                }
                zwartwit = !zwartwit;
            }
            if (_SpelMode.Equals("Singleplayer"))
            {
                lblPlayer1.Text = _speler1.Naam;
                lblPlayer2.Text = "COMP";
            }
            else if (_SpelMode.Equals("Multiplayer"))
            {
                Console.WriteLine("test1 " + _speler1.Naam);
                lblPlayer1.Text = "P1: " + _speler1.Naam;
                lblPlayer2.Text = "P2: " + _speler2.Naam;
            }
            InitializeComponent();

        }

        private void select(SpecialPB pictures)
        {
            if (_SpelMode == "Singleplayer")
            {
                if (_spel.speler1aanzet == true)
                {
                    if (pictures.vakje.schaakstuk != null && pictures.vakje.schaakstuk.kleur == _speler1.Kleur)
                    {
                        _speler1.SelecteerStuk(pictures, _spel);
                    }
                    else
                    {
                        _speler1.SelecteerVakje(pictures, this, _spel);
                        if (_spel.selected.vakje == null)
                        {
                            Console.WriteLine("ARGHHHH");
                        }
                        else
                        {
                            Console.WriteLine("Dit werkt");
                        }
                        //_computerSpeler.Zet(pictures, _spel, _speler1);
                    }
                }
                else
                {
                    //_computerSpeler.Zet(pictures, _spel, _speler1);
                }
            }
            else if (_SpelMode == "Multiplayer")
            {
            if (_spel.speler1aanzet == true)
            {
                
                if (pictures.vakje.schaakstuk != null && pictures.vakje.schaakstuk.kleur == _speler1.Kleur)
                {
                    _speler1.SelecteerStuk(pictures, _spel);
                }
                else
                {
                        _speler1.SelecteerVakje(pictures, this, _spel);
                }
            }
            else 
            {
                if (pictures.vakje.schaakstuk != null && pictures.vakje.schaakstuk.kleur == _speler2.Kleur)
                {
                    _speler2.SelecteerStuk(pictures, _spel);
                }
                else
                {
                        _speler2.SelecteerVakje(pictures, this, _spel);
                    }
                }
            }

        }

        private void SpeelBord_Load(object sender, EventArgs e)
        {
        }

        private void SpeelBord_FormClosed(object sender, FormClosedEventArgs e)
        {
           Application.Exit();  // sluit applicatie af
        }

        private void btHerstart_Click(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnregels_Click(object sender, EventArgs e)
        {
            this.btndame.Visible = true;
            this.btnkoning.Visible = true;
            this.btntoren.Visible = true;
            this.btnloper.Visible = true;
            this.btnpaard.Visible = true;
            this.btnpion.Visible = true;
        }

        private void btnpaard_Click(object sender, EventArgs e)
        {
            clicks++;
            lbluitleg.Visible = true;
            lbluitleg.Text = ("Paard\n Het paard maakt een beweging die een \ncombinatie is van 1 vlakje horizontaal of \nvertikaal, en 1 vlakje diagonaal.\nHet paard is het enige stuk dat kan \nspringen over andere stukken,\nd.w.z.het paard mag over andere \nstukken bewegen om van het ene \nnaar het andere vlakje te komen.\n De stukken waar het paard tijdens \nzijn zet overheen springt worden \nniet beïnvloed.");
            this.btndame.Visible = false;
            pbuitleg.Visible = true;
            this.btnkoning.Visible = false;
            this.btntoren.Visible = false;
            this.btnloper.Visible = false;
            this.btnpaard.Visible = false;
            this.btnpion.Visible = false;
            this.btnterug.Visible = true;
            this.btnregels.Visible = false;
        }

        private void btnterug_Click(object sender, EventArgs e)
        {
            if(clicks == 0)
            {
                this.btndame.Visible = false;
                this.btnkoning.Visible = false;
                pbuitleg.Visible = false;
                this.btntoren.Visible = false;
                this.btnloper.Visible = false;
                this.btnpaard.Visible = false;
                this.btnpion.Visible = false;
                lbluitleg.Visible = false;
                this.btnregels.Visible = true;
            }
            else if (clicks == 1)
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
            }
        }

        private void btnkoning_Click(object sender, EventArgs e)
        {
            clicks++;
            lbluitleg.Text = ("Koning\nDe Koning mag vertikaal, horizontaal en \ndiagonaal bewegen op dezelfde manier \nals de Dame, maar slechts met 1 stapje tegelijk.\n De Koning mag nooit een vlakje \nbetreden wat een (mogelijk) \neindpunt zou kunnen \nzijn van een stuk van de tegenstander. In \nandere woorden, je kunt de Koning nooit op een vlakje zetten waar \nhij direct daarop geslagen zou \nkunnen worden door de tegenstander.");
            lbluitleg.Visible = true;
            pbuitleg.Visible = true;
            this.btndame.Visible = false;
            this.btnkoning.Visible = false;
            this.btntoren.Visible = false;
            this.btnloper.Visible = false;
            this.btnpaard.Visible = false;
            this.btnpion.Visible = false;
            this.btnterug.Visible = true;
            this.btnregels.Visible = false;
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
        }

        private void btntoren_Click(object sender, EventArgs e)
        {
            clicks++;
            lbluitleg.Text = ("Toren\nDe toren beweegt vertikaal of horizontaal\nin een rechte lijn. De toren mag niet over\nandere stukken springen, alle vlakken\ntussen het begin en eindpunt van een\nzet dienen leeg te zijn.");
            lbluitleg.Visible = true;
            this.btndame.Visible = false;
            this.btnkoning.Visible = false;
            this.btntoren.Visible = false;
            this.btnloper.Visible = false;
            this.btnpaard.Visible = false;
            this.btnpion.Visible = false;
            this.btnterug.Visible = true;
            this.btnregels.Visible = false;
            pbuitleg.Visible = true;
        }

        private void btnloper_Click(object sender, EventArgs e)
        {
            clicks++;
            lbluitleg.Text = ("Loper\nDe loper beweegt diagonaal over\nhet bord. Net als de toren mag de\nloper niet over andere stukken springen.");
            lbluitleg.Visible = true;
            this.btndame.Visible = false;
            this.btnkoning.Visible = false;
            this.btntoren.Visible = false;
            this.btnloper.Visible = false;
            this.btnpaard.Visible = false;
            this.btnpion.Visible = false;
            this.btnterug.Visible = true;
            pbuitleg.Visible = true;
            this.btnregels.Visible = false;
        }

        private void btnpion_Click(object sender, EventArgs e)
        {
            clicks++;
            lbluitleg.Visible = true;
            lbluitleg.Text = ("Pion\nDe pion mag in princiepe alleen vooruit lopen.\nPer beurt mag de pion 1 vakje verplaatsen, tenzij\nde pion nog nooit is verplaatst dan mag die 2 vakjes\nverplaatsen. Verder mag de pion alleen schuin slaan.\nAls de pion aan de andere kant van het\nbord is gekomen mag die promoveren tot\neen ander schaakstuk naar keuze.");
            this.btndame.Visible = false;
            this.btnkoning.Visible = false;
            this.btntoren.Visible = false;
            this.btnloper.Visible = false;
            pbuitleg.Visible = true;
            this.btnpaard.Visible = false;
            this.btnpion.Visible = false;
            this.btnterug.Visible = true;
            this.btnregels.Visible = false;
        }
    }
}
