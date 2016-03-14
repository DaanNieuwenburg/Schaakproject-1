using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace Schaakproject
{
    public partial class Hoofdmenu : Form
    {
        public Hoofdmenu()
        {
            InitializeComponent();
            this.CenterToScreen();
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            NaamInvoer naaminvoerdialog = new NaamInvoer();
            naaminvoerdialog.ShowDialog();
        }

        private void Hoofdmenu_Load(object sender, EventArgs e)
        {
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
            AfsluitMelding _afsluiten = new AfsluitMelding();
            _afsluiten.ShowDialog();
            if (_afsluiten.Sure == true)
            {
                Application.Exit();
            }
        }
    }
}
