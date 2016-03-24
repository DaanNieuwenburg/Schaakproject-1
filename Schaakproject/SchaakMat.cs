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
    public partial class SchaakMat : Form
    {
        private Spel spel { get; set; }
        public SchaakMat(string naam, Spel spel)
        {
            InitializeComponent();            
            lbl_gewonnen.Text = "Schaakmat! " + naam + " heeft gewonnen!";
            lbl_gewonnen.Location = new System.Drawing.Point(lbl_gewonnen.Location.X - (lbl_gewonnen.Text.Length * 2), lbl_gewonnen.Location.Y);
            this.spel = spel;
        }

        private void btn_ja_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            spel.Herstart(spel.SpelMode, spel.Speler1.Naam, spel.Speler2.Naam);
        }

        private void btn_nee_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.Yes;
            spel.speelbord.Hide();
            NaamInvoer menu = new NaamInvoer();
            menu.ShowDialog();
        }
    }
}
