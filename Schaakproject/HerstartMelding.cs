using System;
using System.Windows.Forms;

namespace Schaakproject
{
    public partial class HerstartMelding : Form
    {
        public bool Sure { get; private set; }
        public HerstartMelding()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Sure = true;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Sure = false;
        }
    }
}
