﻿using System;
using System.Windows.Forms;

namespace Schaakproject
{
    public partial class SchaakMat : Form
    {
        private Spel _spel { get; set; }
        public SchaakMat(string naam, Spel spel)
        {
            InitializeComponent();            
            lbl_gewonnen.Text = "Schaakmat! " + naam + " heeft gewonnen!";
            lbl_gewonnen.Location = new System.Drawing.Point(lbl_gewonnen.Location.X - (lbl_gewonnen.Text.Length * 2), lbl_gewonnen.Location.Y);
            _spel = spel;
        }

        private void btn_ja_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            if (_spel.SpelMode == "Singleplayer")
            {
                _spel.Herstart(_spel.SpelMode, _spel.Speler1.Naam, _spel.ComputerSpeler.Naam);
            }
            else
            {
                _spel.Herstart(_spel.SpelMode, _spel.Speler1.Naam, _spel.Speler2.Naam);
            }
        }

        private void btn_nee_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.Yes;
            _spel.speelbord.Hide();
            NaamInvoer menu = new NaamInvoer(_spel.BorderColor, _spel.SelectColor, _spel.ColorVakje1, _spel.ColorVakje2);
            menu.ShowDialog();
        }
    }
}
