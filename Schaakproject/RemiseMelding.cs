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
    public partial class RemiseMelding : Form
    {
        public Spel spel { get; set; }

        public RemiseMelding(Spel spel)
        {
            this.spel = spel;
            InitializeComponent();
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
            NaamInvoer menu = new NaamInvoer(spel._bordercolor, spel._selectcolor, spel._colorvakje1, spel._colorvakje2);
            menu.ShowDialog();
        }
    }
}
