﻿using System;
using System.Windows.Forms;

namespace Schaakproject
{
    public partial class RemiseMelding : Form
    {
        private Spel _spel { get; set; }

        public RemiseMelding(Spel spel)
        {
            _spel = spel;
            InitializeComponent();
        }

        private void btn_ja_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            _spel.Herstart(_spel.SpelMode, _spel.Speler1.Naam, _spel.Speler2.Naam);
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
