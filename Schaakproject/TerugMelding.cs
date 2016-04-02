using System;
using System.Windows.Forms;

namespace Schaakproject
{
    public partial class TerugMelding : Form
    {
        public SpeelBord _speelbord { get; set; }
        public Spel spel { get; set; }
        public TerugMelding(SpeelBord speelbord, Spel spel)
        {
            this.spel = spel;
            _speelbord = speelbord;
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Hide();
            _speelbord.Hide();
            NaamInvoer naaminvoerdialog = new NaamInvoer(spel.BorderColor, spel.SelectColor, spel.ColorVakje1, spel.ColorVakje2);
            naaminvoerdialog.ShowDialog();
            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
