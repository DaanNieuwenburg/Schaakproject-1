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
    }
}
