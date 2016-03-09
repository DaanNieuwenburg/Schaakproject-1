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
            Spel spel = new Spel();
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

        private void btModeComputer_MouseEnter(object sender, EventArgs e)
        {
            this.btModeComputer.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_2_klad_click);
        }

        private void btModeComputer_MouseLeave(object sender, EventArgs e)
        {
            this.btModeComputer.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_2_klad);

        }

        private void btModeMultiplayer_MouseLeave(object sender, EventArgs e)
        {
            this.btModeMultiplayer.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_1_klad);

        }

        private void btModeMultiplayer_MouseEnter(object sender, EventArgs e)
        {
            this.btModeMultiplayer.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_1_klad_click);

        }

        private void btModeRealMulti_MouseEnter(object sender, EventArgs e)
        {
            this.btModeRealMulti.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_3_klad_click);

        }

        private void btModeRealMulti_MouseLeave(object sender, EventArgs e)
        {
            this.btModeRealMulti.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_3_klad);

        }
    }
}
