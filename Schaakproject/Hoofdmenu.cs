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
    public partial class Hoofdmenu : Form
    {
        public Hoofdmenu()
        {
            InitializeComponent();
        }

        private void herstartButton_MouseClick(object sender, MouseEventArgs e)
        {
            HerstartMelding Warning = new HerstartMelding();
            Warning.ShowDialog();
            if (Warning.Sure == true)
            {
                Spel.Herstart();
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            NaamInvoer naaminvoerdialog = new NaamInvoer();
            naaminvoerdialog.ShowDialog();
            lblTmpSpeler1.Text = naaminvoerdialog.txtSpeler1Naam.Text;
            lblTmpSpeler2.Text = naaminvoerdialog.txtSpeler2Naam.Text;
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
