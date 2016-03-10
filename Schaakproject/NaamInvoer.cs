using LoginProject;
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
        public string Mode
        {
            get; set;
        }
        private string Speler1 { get; set; }
        private string Speler2 { get; set; }
        public NaamInvoer()
        {
            //lblNotImplented.Visible = true;
            InitializeComponent();
        }

        private void btnNaamSubmit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Speler speler1 = new Speler(txtSpeler1Naam.Text, "wit");
            Speler speler2 = new Speler(txtSpeler2Naam.Text, "zwart");
            Speler1 = txtSpeler1Naam.Text;
            Speler2 = txtSpeler2Naam.Text;
            Spel spel = new Spel(Mode, Speler1, Speler2);

        }

        private void btModeMultiplayer_Click(object sender, EventArgs e)
        {
            // Maak mode buttons niet zichtbaar
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            btModeRealMulti.Visible = false;
            lbTitel.Text = "Multiplayer";
            
            lblSpeler1Naam.Visible = true;
            lblSpeler2Naam.Visible = true;
            txtSpeler1Naam.Visible = true;
            txtSpeler2Naam.Visible = true;
            btnBegin.Visible = true;
            lblNotImplented.Visible = false;
            Mode = "MultiPlayer";
            
        }

        private void btModeComputer_Click(object sender, EventArgs e)
        {
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            btModeRealMulti.Visible = false;
            lbTitel.Text = "Computer";

            lblSpeler1Naam.Visible = true;
            lblSpeler2Naam.Visible = false;
            txtSpeler1Naam.Visible = true;
            txtSpeler2Naam.Visible = false;
            lblNotImplented.Visible = true;
            btnBegin.Visible = true;
            Mode = "SinglePlayer";
            lblDontPress.Visible = true;

        }

        private void btModeRealMulti_Click(object sender, EventArgs e)
        {
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            btModeRealMulti.Visible = false;
            lbTitel.Text = "ONLINE";

            lblSpeler1Naam.Visible = false;
            lblSpeler2Naam.Visible = false;
            txtSpeler1Naam.Visible = false;
            lblNotImplented.Visible = true;
            btnBegin.Visible = true;
            MainForm Login = new MainForm();
            //FormRegister Register = new FormRegister();
            Login.Show();
            lblDontPress.Visible = true;
        }

        private void btModeComputer_MouseEnter(object sender, EventArgs e)
        {
            this.btModeComputer.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button2KladClick);
        }

        private void btModeComputer_MouseLeave(object sender, EventArgs e)
        {
            this.btModeComputer.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button2Klad);

        }

        private void btModeMultiplayer_MouseLeave(object sender, EventArgs e)
        {
            this.btModeMultiplayer.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button1Klad);

        }

        private void btModeMultiplayer_MouseEnter(object sender, EventArgs e)
        {
            this.btModeMultiplayer.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button1KladClick);

        }

        private void btModeRealMulti_MouseEnter(object sender, EventArgs e)
        {
            this.btModeRealMulti.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button3KladClick);

        }

        private void btModeRealMulti_MouseLeave(object sender, EventArgs e)
        {
            this.btModeRealMulti.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button3Klad);

        }

        private void btnBegin_MouseEnter(object sender, EventArgs e)
        {
            this.btnBegin.BackgroundImage = (System.Drawing.Image)(Properties.Resources.buttonBeginClick);

        }

        private void btnBegin_MouseLeave(object sender, EventArgs e)
        {
            this.btnBegin.BackgroundImage = (System.Drawing.Image)(Properties.Resources.buttonBegin);

        }

        private void btModeComputer_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void pbTerug_Click(object sender, EventArgs e)
        {
            // Maak mode buttons niet zichtbaar
            btModeComputer.Visible = true;
            btModeMultiplayer.Visible = true;
            btModeRealMulti.Visible = true;
            lbTitel.Text = "Selecteer een schaakmodus";

            lblSpeler1Naam.Visible = false;
            lblSpeler2Naam.Visible = false;
            txtSpeler1Naam.Visible = false;
            txtSpeler2Naam.Visible = false;
            lblNotImplented.Visible = false;
            btnBegin.Visible = false;
            lblDontPress.Visible = false;
        }
    }
}
