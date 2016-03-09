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
    public partial class NaamInvoer : Form
    {
        public NaamInvoer()
        {
            InitializeComponent();
        }

        private void btnNaamSubmit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Speler speler1 = new Speler(txtSpeler1Naam.Text, "wit");
            Speler speler2 = new Speler(txtSpeler2Naam.Text, "zwart");
        }

        private void NaamInvoer_Load(object sender, EventArgs e)
        {

        }

        private void btModeMultiplayer_Click(object sender, EventArgs e)
        {
            lblSpeler1Naam.Visible = true;
            lblSpeler2Naam.Visible = true;
            txtSpeler1Naam.Visible = true;
            txtSpeler2Naam.Visible = true;
            btnBegin.Visible = true;
            lblNotImplented.Visible = false;
        }

        private void btModeComputer_Click(object sender, EventArgs e)
        {
            lblSpeler1Naam.Visible = true;
            lblSpeler2Naam.Visible = false;
            txtSpeler1Naam.Visible = true;
            txtSpeler2Naam.Visible = false;
            lblNotImplented.Visible = true;
            btnBegin.Visible = true;
        }

        private void btModeRealMulti_Click(object sender, EventArgs e)
        {
            lblSpeler1Naam.Visible = false;
            lblSpeler2Naam.Visible = false;
            txtSpeler1Naam.Visible = false;
            lblNotImplented.Visible = true;
            btnBegin.Visible = true;
        }
    }
}
