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
        public SpeelBord(string SpelMode, string Speler1, string Speler2)
        {
            _SpelMode = SpelMode;
            _speler1Naam = Speler1;
            _speler2Naam = Speler2;
            InitializeComponent();

            this.CenterToScreen();
            Schaakbord schaakbord = new Schaakbord();
            PictureBox[,] pictures = new PictureBox[8, 8];
            bool zwartwit = false;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    pictures[x, y] = new PictureBox();
                    if (zwartwit == false)
                    {
                        pictures[x, y].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
                    }
                    else
                    {
                        pictures[x, y].BackColor = System.Drawing.Color.SaddleBrown;
                    }
                    pictures[x, y].Location = new System.Drawing.Point(90 + 54 * y, 50 + 54 * x);
                    pictures[x, y].Size = new System.Drawing.Size(54, 54);
                    pictures[x, y].TabIndex = 0;
                    pictures[x, y].TabStop = false;
                    pictures[x, y].SizeMode = PictureBoxSizeMode.CenterImage;
                    this.Controls.Add(pictures[x, y]);
                    schaakbord.schaakarray[x, y].pbox = pictures[x, y];
                    schaakbord.schaakarray[x, y].update();
                    zwartwit = !zwartwit;
                }
                zwartwit = !zwartwit;
            }
        }

        private void SpeelBord_Click(object sender, EventArgs e)
        {
            Console.WriteLine("TEST");
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
                lblPlayer1.Text = _speler1Naam;
                lblPlayer2.Text = _speler2Naam;
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