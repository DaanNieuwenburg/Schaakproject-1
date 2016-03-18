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
        public string Mode { get; set; }
        public string Variant { get; set; }
        private string Speler1 { get; set; }
        private string Speler2 { get; set; }
        private bool click { get; set; }
        private string _username { get; set; }
        private bool click2 { get; set; }
        public NaamInvoer()
        {
            //lblNotImplented.Visible = true;
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnNaamSubmit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            if (Mode == "Multiplayer")
            {
                Speler1 = txtSpeler1Naam.Text;
                Speler2 = txtSpeler2Naam.Text;
                Spel spel = new Spel(Mode, Speler1, Speler2, Variant);
            }
            else if (Mode == "Online")
            {
                Speler1 = _username;
                Speler2 = txtSpeler2Naam.Text;
                Spel spel = new Spel(Mode, _username, Speler2, Variant);
            }
            
            
            hLabel.Visible = true;
        }

        private void btModeMultiplayer_Click(object sender, EventArgs e)
        {
            // Maak mode buttons niet zichtbaar
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            btModeRealMulti.Visible = false;
            lbTitel.Text = "Multiplayer";
            btnKlassiek.Visible = true;
            btnChess960.Visible = true;
            lblSpeler1Naam.Visible = true;
            lblSpeler2Naam.Visible = true;
            txtSpeler1Naam.Visible = true;
            txtSpeler2Naam.Visible = true;
            btnBegin.Visible = false;
            Mode = "Multiplayer";
            hLabel.Visible = false;
        }

        private void btModeComputer_Click(object sender, EventArgs e)
        {
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            btModeRealMulti.Visible = false;
            lbTitel.Text = "Single Player";
            btnKlassiek.Visible = true;
            btnChess960.Visible = true;
            lblSpeler1Naam.Visible = true;
            lblSpeler2Naam.Visible = false;
            txtSpeler1Naam.Visible = true;
            txtSpeler2Naam.Visible = false;
            btnBegin.Visible = false;
            Mode = "Singleplayer";
            hLabel.Visible = false;

        }

        private void btModeRealMulti_Click(object sender, EventArgs e)
        {
            Mode = "Online";
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            btModeRealMulti.Visible = false;
            lbTitel.Text = "Online";
            btnKlassiek.Visible = false;
            btnChess960.Visible = false;
            lblSpeler1Naam.Visible = false;
            lblSpeler2Naam.Visible = false;
            txtSpeler1Naam.Visible = false;
            btnBegin.Visible = false;
            LoginForm Login = new LoginForm();
            Login.ShowDialog();
            hLabel.Visible = false;
            if (Login.login == true)
            {
                _username = Login.username;
                Console.WriteLine("Test Naaminvoer: " + _username);
                btnKlassiek.Visible = true;
                btnChess960.Visible = true;    
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (lbTitel.Text == "Selecteer een schaakmode")
            {
                this.Visible = false;
                Hoofdmenu hoofdmenu = new Hoofdmenu();
                hoofdmenu.Show();
            }
            else
            {
                // Maak mode buttons niet zichtbaar
                btModeComputer.Visible = true;
                btModeMultiplayer.Visible = true;
                btModeRealMulti.Visible = true;
                lbTitel.Text = "Selecteer een schaakmode";

                lblSpeler1Naam.Visible = false;
                lblSpeler2Naam.Visible = false;
                txtSpeler1Naam.Visible = false;
                txtSpeler2Naam.Visible = false;
                btnBegin.Visible = false;
                btnKlassiek.Visible = false;
                btnChess960.Visible = false;
                hLabel.Visible = true;
            }
        }

        private void btTerug_MouseEnter(object sender, EventArgs e)
        {
            this.btTerug.BackgroundImage = (System.Drawing.Image)(Properties.Resources.backIcon_click);
        }

        private void btTerug_MouseLeave(object sender, EventArgs e)
        {
            this.btTerug.BackgroundImage = (System.Drawing.Image)(Properties.Resources.backIcon);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Variant = "Klassiek";
            this.btnKlassiek.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_klassiek_click);
            this.btnChess960.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_960);
            click2 = false;
            click = true;
            btnBegin.Visible = true;
        }

        private void btnChess960_Click(object sender, EventArgs e)
        {
            Variant = "Chess960";
            this.btnKlassiek.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_klassiek);
            this.btnChess960.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_960_click);
            click = false;
            click2 = true;
            btnBegin.Visible = true;
        }

        private void btnKlassiek_MouseEnter(object sender, EventArgs e)
        {
            this.btnKlassiek.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_klassiek_click);
        }

        private void btnKlassiek_MouseLeave(object sender, EventArgs e)
        {
            if (click == true)
            {
                this.btnKlassiek.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_klassiek_click);
            }
            else
            {
                this.btnKlassiek.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_klassiek);
            }
        }

        private void btnChess960_MouseLeave(object sender, EventArgs e)
        {
            if (click2 == true)
            {
                this.btnChess960.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_960_click);
            }
            else
            {
                this.btnChess960.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_960);
            }
            
        }

        private void btnChess960_MouseEnter(object sender, EventArgs e)
        {
            this.btnChess960.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_960_click);
        }
    }
}
