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
        public Spel _spel { get; set; }

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
            NaamInvoer menu = new NaamInvoer();
            menu.ShowDialog();
        }
    }
}
