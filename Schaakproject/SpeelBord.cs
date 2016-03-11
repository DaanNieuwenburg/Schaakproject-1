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
        private string _speler1Naam { get; set; }
        private string _speler2Naam { get; set; }
        Mens mens = new Mens();
        Schaakbord schaakbord = new Schaakbord();

        public SpeelBord(string SpelMode, string Speler1, string Speler2)
        {
            _SpelMode = SpelMode;
            _speler1Naam = Speler1;
            _speler2Naam = Speler2;
            InitializeComponent();

            this.CenterToScreen();


            bool zwartwit = false;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    SpecialPB pictures = new SpecialPB();
                    if (zwartwit == false)
                    {
                        pictures.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
                    }
                    else
                    {
                        pictures.BackColor = Color.SaddleBrown;
                    }
                    pictures.Location = new Point(12 + 54 * y, 12 + 54 * x);
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
            InitializeComponent();
        }

        private void select(SpecialPB pictures)
        {
            if (pictures.vakje.schaakstuk != null)
            {
                mens.SelecteerStuk(pictures);
            }
        }

        private void SpeelBord_Load(object sender, EventArgs e)
        {
            if (_SpelMode.Equals("SinglePlayer"))
            {
                lblPlayer1.Text = _speler1Naam;
                lblPlayer2.Text = "COMP";
            }
            else if (_SpelMode.Equals("MultiPlayer"))
            {
                Console.WriteLine(_speler1Naam);
                lblPlayer1.Text = "P1: "+_speler1Naam;
                lblPlayer2.Text = "P2: "+_speler2Naam;
            }
        }

        private void SpeelBord_FormClosed(object sender, FormClosedEventArgs e)
        {
           Application.Exit();  // sluit applicatie af
        }

        private void btHerstart_Click(object sender, EventArgs e)
        {
            HerstartMelding Warning = new HerstartMelding();
            Warning.ShowDialog();
            if (Warning.Sure == true)
            {
                this.Hide();
                Spel.Herstart(_SpelMode, _speler1Naam, _speler2Naam);
            }
            }
        }
}
