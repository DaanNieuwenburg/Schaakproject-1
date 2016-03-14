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
    public partial class PromoveerForm : Form
    {
        Pion pion { get; set; }
        string kleur { get; set; }
        public PromoveerForm(Pion _pion, string _kleur)
        {
            InitializeComponent();
            this.ControlBox = false;
            pion = _pion;
            kleur = _kleur;
            if (kleur.Equals("zwart"))
            {
                pbDame.Image = global::Schaakproject.Properties.Resources.DameZwart;
                pbLoper.Image = global::Schaakproject.Properties.Resources.LoperZwart;
                pbToren.Image = global::Schaakproject.Properties.Resources.TorenZwart;
                pbPaard.Image = global::Schaakproject.Properties.Resources.PaardZwart;
            }
        }

        private void pbPaard_Click(object sender, EventArgs e)
        {
            pion.Promoveert("paard");
            DialogResult = DialogResult.Yes;
        }

        private void pbLoper_Click(object sender, EventArgs e)
        {
            pion.Promoveert("loper");
            DialogResult = DialogResult.Yes;
        }

        private void pbDame_Click(object sender, EventArgs e)
        { 
            pion.Promoveert("dame");
            DialogResult = DialogResult.Yes;
        }

        private void pbToren_Click(object sender, EventArgs e)
        {
            pion.Promoveert("toren");
            DialogResult = DialogResult.Yes;
        }
    }
}
