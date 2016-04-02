using System;
using System.Drawing;
using System.Windows.Forms;

namespace Schaakproject
{
    public partial class NaamInvoer : Form
    {
        private string _mode { get; set; }           //Is het Singleplayer of Multiplayer
        private string _variant { get; set; }        //Is het klassiek schaak of chess960
        private bool _buttonClick { get; set; }      // Door buttonClick en buttonClick2 werken de knoppen in het menu
        private bool _buttonClick2 { get; set; }
        private Color _borderColor { get; set; }     //Je kunt de kleur voor de rand veranderen
        private Color _selectColor { get; set; }     //Je kunt de kleur voor een geselecteerd vakje veranderen
        private Color _vakje1Color { get; set; }     //Je kunt de kleur voor de zwarte vakjes veranderen
        private Color _vakje2Color { get; set; }     //Je kunt de kleur voor de witte vakjes veranderen

        public NaamInvoer(Color border, Color select, Color vakje1color, Color vakje2color)
        {
            InitializeComponent();
            this.CenterToScreen();
            _borderColor = border;
            _selectColor = select;
            this._vakje1Color = vakje1color;
            this._vakje2Color = vakje2color;

        }

        private void btnNaamSubmit_Click(object sender, EventArgs e)
        {
            //Als je op deze knop drukt, wordt het spel opgestart          

            DialogResult = DialogResult.Yes;
            Spel spel = new Spel(_mode, txtSpeler1Naam.Text, txtSpeler2Naam.Text, _variant, _borderColor, _selectColor, _vakje1Color, _vakje2Color);
        }

        private void btModeMultiplayer_Click(object sender, EventArgs e)
        {
            // Maak mode buttons onzichtbaar en naamvelden zichtbaar
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            btnSettings.Visible = false;
            lblTitel.Text = "Multiplayer";
            btnKlassiek.Visible = true;
            btnChess960.Visible = true;
            lblSpeler1Naam.Visible = true;
            lblSpeler2Naam.Visible = true;
            txtSpeler1Naam.Visible = true;
            txtSpeler2Naam.Visible = true;
            btnBegin.Visible = false;
            _mode = "Multiplayer"; // Hierdoor krijgt het speelbord te weten dat het multiplayer is.
        }

        private void btModeComputer_Click(object sender, EventArgs e)
        {
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            btnSettings.Visible = false;
            lblTitel.Text = "Single Player";
            btnKlassiek.Visible = false;
            btnChess960.Visible = false;
            lblSpeler1Naam.Visible = true;
            lblSpeler2Naam.Visible = false;
            txtSpeler1Naam.Visible = true;
            txtSpeler2Naam.Visible = false;
            btnBegin.Visible = true;
            _variant = "Klassiek";
            _mode = "Singleplayer"; // Hierdoor krijgt het speelbord te weten dat het singleplayer is.
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

        private void btTerug_Click(object sender, EventArgs e)
        {

        }

        private void btTerug_MouseEnter(object sender, EventArgs e)
        {
            this.btnTerug.BackgroundImage = (System.Drawing.Image)(Properties.Resources.backIcon_click);
        }

        private void btTerug_MouseLeave(object sender, EventArgs e)
        {
            this.btnTerug.BackgroundImage = (System.Drawing.Image)(Properties.Resources.backIcon);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _variant = "Klassiek";
            this.btnKlassiek.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_klassiek_click);
            this.btnChess960.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_960);
            _buttonClick2 = false;
            _buttonClick = true;
            btnBegin.Visible = true;
        }

        private void btnChess960_Click(object sender, EventArgs e)
        {
            _variant = "Chess960";
            this.btnKlassiek.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_klassiek);
            this.btnChess960.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_960_click);
            _buttonClick = false;
            _buttonClick2 = true;
            btnBegin.Visible = true;
        }

        private void btnKlassiek_MouseEnter(object sender, EventArgs e)
        {
            this.btnKlassiek.BackgroundImage = (System.Drawing.Image)(Properties.Resources.button_klassiek_click);
        }

        private void btnKlassiek_MouseLeave(object sender, EventArgs e)
        {
            if (_buttonClick == true)
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
            if (_buttonClick2 == true)
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
                _borderColor = colorDialog.Color;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            lblTitel.Text = "Settings";
            btModeComputer.Visible = false;
            btModeMultiplayer.Visible = false;
            btnSettings.Visible = false;
            lblSpeler1Naam.Visible = false;
            lblSpeler2Naam.Visible = false;
            txtSpeler1Naam.Visible = false;
            txtSpeler2Naam.Visible = false;
            btnBegin.Visible = false;
            btnvakje1.Visible = true;
            btnvakje2.Visible = true;
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
                _selectColor = colorDialog.Color;
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

        private void btnvakje1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();

            // Kijk of gebruiker op OK drukt
            if (result == DialogResult.OK)
            {
                _vakje1Color = colorDialog.Color;
            }
        }


        private void btnvakje2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();

            // Kijk of gebruiker op OK drukt
            if (result == DialogResult.OK)
            {
                _vakje2Color = colorDialog.Color;
            }
        }

        private void btnvakje1_MouseEnter(object sender, EventArgs e)
        {
            btnvakje1.BackgroundImage = Properties.Resources.button_vakje1color_click;
        }

        private void btnvakje1_MouseLeave(object sender, EventArgs e)
        {
            btnvakje1.BackgroundImage = Properties.Resources.button_vakje1color;
        }

        private void btnvakje2_MouseEnter(object sender, EventArgs e)
        {
            btnvakje2.BackgroundImage = Properties.Resources.button_vakje2color_click;
        }

        private void btnvakje2_MouseLeave(object sender, EventArgs e)
        {
            btnvakje2.BackgroundImage = Properties.Resources.button_vakje2color;
        }

        private void btnTerug_Click(object sender, EventArgs e)
        {
            if (lblTitel.Text == "Selecteer een schaakmode")
            {
                this.Hide();
                Hoofdmenu hoofdmenu = new Hoofdmenu(_borderColor, _selectColor, _vakje1Color, _vakje2Color);
                hoofdmenu.Show();
            }
            else
            {
                // Maak mode buttons niet zichtbaar
                btModeComputer.Visible = true;
                btModeMultiplayer.Visible = true;
                btnSettings.Visible = true;
                lblTitel.Text = "Selecteer een schaakmode";
                btnborder.Visible = false;
                btnvakje1.Visible = false;
                btnvakje2.Visible = false;
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
    }
}