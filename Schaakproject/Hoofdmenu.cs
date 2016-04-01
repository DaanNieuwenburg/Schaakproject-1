using System;
using System.Drawing;
using System.Windows.Forms;

namespace Schaakproject
{
    public partial class Hoofdmenu : Form
    {
        private Color _borderColor { get; set; }     //Je kunt de kleur voor de rand veranderen
        private Color _selectColor { get; set; }     //Je kunt de kleur voor een geselecteerd vakje veranderen
        private Color _vakje1Color { get; set; }     //Je kunt de kleur voor de zwarte vakjes veranderen
        private Color _vakje2Color { get; set; }     //Je kunt de kleur voor de witte vakjes veranderen
        public Hoofdmenu(Color border, Color select, Color vakje1color, Color vakje2color)
        {
            InitializeComponent();
            _borderColor = border;
            _selectColor = select;
            this._vakje1Color = vakje1color;
            this._vakje2Color = vakje2color;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            NaamInvoer naaminvoerdialog = new NaamInvoer(_borderColor, _selectColor, _vakje1Color, _vakje2Color);
            naaminvoerdialog.ShowDialog();
        }

        private void Hoofdmenu_Load(object sender, EventArgs e)
        {
            btnafsluiten.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent bordercolor (Color.Transparent is unsupported)
            BackgroundImageLayout = ImageLayout.Stretch;
            startButton.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void startButton_MouseLeave(object sender, EventArgs e)
        {
            this.startButton.BackgroundImage = (System.Drawing.Image)(Properties.Resources.start_klad_2_);
        }

        private void startButton_MouseEnter_1(object sender, EventArgs e)
        {
            this.startButton.BackgroundImage = (System.Drawing.Image)(Properties.Resources.start_click_klad_2_);
        }

        private void btnafsluiten_MouseEnter(object sender, EventArgs e)
        {
            this.btnafsluiten.BackgroundImage = (Image)(Properties.Resources.afsluiten_click);
        }

        private void btnafsluiten_MouseLeave(object sender, EventArgs e)
        {
            this.btnafsluiten.BackgroundImage = (Image)(Properties.Resources.afsluiten);
        }

        private void btnafsluiten_Click(object sender, EventArgs e)
        {
            btnafsluiten.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent bordercolor (Color.Transparent is unsupported)
            Console.WriteLine("AFSLUITEN");
            AfsluitMelding _afsluiten = new AfsluitMelding();
            _afsluiten.ShowDialog();
            if (_afsluiten.Sure == true)
            {
                Application.Exit();
            }
        }
    }
}
