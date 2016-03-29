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
        public Color _bordercolor { get; set; }
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
            if (Mode == "Singleplayer")
            {
                Speler1 = txtSpeler1Naam.Text;
                Speler2 = txtSpeler2Naam.Text;
                Spel spel = new Spel(Mode, Speler1, Speler2, Variant, _bordercolor);
            }
            else if (Mode == "Multiplayer")
            {
                Speler1 = txtSpeler1Naam.Text;
                Speler2 = txtSpeler2Naam.Text;
                Spel spel = new Spel(Mode, Speler1, Speler2, Variant, _bordercolor);
            }
            else if (Mode == "Online")
            {
                Speler1 = _username;
                Speler2 = txtSpeler2Naam.Text;
                Spel spel = new Spel(Mode, _username, Speler2, Variant, _bordercolor);
            }

        }

        private void btModeMultiplayer_Click(object sender, EventArgs e)
        {
            // Maak mode buttons niet zichtbaar
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            btnSettings.Visible = false;
            lbTitel.Text = "Multiplayer";
            btnKlassiek.Visible = true;
            btnChess960.Visible = true;
            lblSpeler1Naam.Visible = true;
            lblSpeler2Naam.Visible = true;
            txtSpeler1Naam.Visible = true;
            txtSpeler2Naam.Visible = true;
            btnBegin.Visible = false;
            Mode = "Multiplayer";
        }

        private void btModeComputer_Click(object sender, EventArgs e)
        {
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            lbTitel.Text = "Single Player";
            btnKlassiek.Visible = true;
            btnChess960.Visible = true;
            lblSpeler1Naam.Visible = true;
            lblSpeler2Naam.Visible = false;
            txtSpeler1Naam.Visible = true;
            txtSpeler2Naam.Visible = false;
            btnBegin.Visible = false;
            Mode = "Singleplayer";

        }

        private void btModeRealMulti_Click(object sender, EventArgs e)
        {
            Mode = "Online";
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            lbTitel.Text = "Online";
            btnKlassiek.Visible = false;
            btnChess960.Visible = false;
            lblSpeler1Naam.Visible = false;
            lblSpeler2Naam.Visible = false;
            txtSpeler1Naam.Visible = false;
            btnBegin.Visible = false;
            LoginForm Login = new LoginForm();
            //Login.Visible = true;
            Login.ShowDialog();
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
                btnSettings.Visible = true;
                lbTitel.Text = "Selecteer een schaakmode";

                lblSpeler1Naam.Visible = false;
                lblSpeler2Naam.Visible = false;
                txtSpeler1Naam.Visible = false;
                txtSpeler2Naam.Visible = false;
                btnBegin.Visible = false;
                btnKlassiek.Visible = false;
                btnChess960.Visible = false;
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

        private void btnSettings_MouseEnter(object sender, EventArgs e)
        {
            btnSettings.BackgroundImage = Properties.Resources.button_settings_click;
        }

        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            btnSettings.BackgroundImage = Properties.Resources.button_settings;
        }

        private void btnborder_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                _bordercolor = colorDialog.Color;
            }
            else
            {
                _bordercolor = Color.RosyBrown;
            }

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            lbTitel.Text = "Settings";
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            btnSettings.Visible = false;
            lblSpeler1Naam.Visible = false;
            lblSpeler2Naam.Visible = false;
            txtSpeler1Naam.Visible = false;
            txtSpeler2Naam.Visible = false;
            btnBegin.Visible = false;
            btnKlassiek.Visible = false;
            btnChess960.Visible = false;
            btnborder.Visible = true;
        }

        private void btnborder_MouseEnter(object sender, EventArgs e)
        {
            btnborder.BackgroundImage = Properties.Resources.button_bordercolor_click;
        }

        private void btnborder_MouseLeave(object sender, EventArgs e)
        {
            btnborder.BackgroundImage = Properties.Resources.button_bordercolor;
        }
    }
}
