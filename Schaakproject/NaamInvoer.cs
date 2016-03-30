using System;
using System.Drawing;
using System.Windows.Forms;

namespace Schaakproject
{
    public partial class NaamInvoer : Form
    {
        private string Mode { get; set; }           //Is het Singleplayer of Multiplayer
        private string Variant { get; set; }        //Is het klassiek schaak of chess960
        private bool buttonClick { get; set; }      // Door buttonClick en buttonClick2 werken de knoppen in het menu
        private bool buttonClick2 { get; set; }    
        private Color bordercolor { get; set; }     //Je kunt de kleur voor de rand veranderen
        private Color selectcolor { get; set; }     //Je kunt de kleur voor een geselecteerd vakje veranderen

        public NaamInvoer(Color border, Color select)
        {
            InitializeComponent();
            this.CenterToScreen();
            bordercolor = border;
            selectcolor = select;            
        }

        private void btnNaamSubmit_Click(object sender, EventArgs e)
        {
            //Als je op deze knop drukt, wordt het spel opgestart          
              
            DialogResult = DialogResult.Yes;
            Spel spel = new Spel(Mode, txtSpeler1Naam.Text, txtSpeler2Naam.Text, Variant, bordercolor, selectcolor);
        }

        private void btModeMultiplayer_Click(object sender, EventArgs e)
        {
            // Maak mode buttons onzichtbaar en naamvelden zichtbaar
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
            Mode = "Multiplayer"; // Hierdoor krijgt het speelbord te weten dat het multiplayer is.
        }

        private void btModeComputer_Click(object sender, EventArgs e)
        {
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            btnSettings.Visible = false;
            lbTitel.Text = "Single Player";
            btnKlassiek.Visible = true;
            btnChess960.Visible = true;
            lblSpeler1Naam.Visible = true;
            lblSpeler2Naam.Visible = false;
            txtSpeler1Naam.Visible = true;
            txtSpeler2Naam.Visible = false;
            btnBegin.Visible = false;
            Mode = "Singleplayer"; // Hierdoor krijgt het speelbord te weten dat het singleplayer is.
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
                this.Hide();
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
                btnborder.Visible = false;
                btnselect.Visible = false;
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
            buttonClick2 = false;
            buttonClick = true;
            btnBegin.Visible = true;
        }

        private void btnChess960_Click(object sender, EventArgs e)
        {
            Variant = "Chess960";
            this.btnKlassiek.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_klassiek);
            this.btnChess960.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_960_click);
            buttonClick = false;
            buttonClick2 = true;
            btnBegin.Visible = true;
        }

        private void btnKlassiek_MouseEnter(object sender, EventArgs e)
        {
            this.btnKlassiek.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_klassiek_click);
        }

        private void btnKlassiek_MouseLeave(object sender, EventArgs e)
        {
            if (buttonClick == true)
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
            if (buttonClick2 == true)
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

            // Kijk of gebruiker op OK drukt
            if (result == DialogResult.OK)
            {
                bordercolor = colorDialog.Color;
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
            btnselect.Visible = true;
        }

        private void btnborder_MouseEnter(object sender, EventArgs e)
        {
            btnborder.BackgroundImage = Properties.Resources.button_bordercolor_click;
        }

        private void btnborder_MouseLeave(object sender, EventArgs e)
        {
            btnborder.BackgroundImage = Properties.Resources.button_bordercolor;
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();

            // Kijk of gebruiker op OK drukt
            if (result == DialogResult.OK)
            {
                selectcolor = colorDialog.Color;
            }
        }

        private void btnselect_MouseEnter(object sender, EventArgs e)
        {
            btnselect.BackgroundImage = Properties.Resources.button_selectedcolor_click;
        }

        private void btnselect_MouseLeave(object sender, EventArgs e)
        {
            btnselect.BackgroundImage = Properties.Resources.button_selectedcolor;
        }
    }
}