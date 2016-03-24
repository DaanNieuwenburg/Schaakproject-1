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
    public partial class TerugMelding : Form
    {
        public SpeelBord _speelbord { get; set; }
        public TerugMelding(SpeelBord speelbord)
        {
            _speelbord = speelbord;
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Hide();
            _speelbord.Hide();
            NaamInvoer naaminvoerdialog = new NaamInvoer();
            naaminvoerdialog.ShowDialog();
            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
