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
    }
}
