using System;
using System.Windows.Forms;

namespace Schaakproject
{
    public partial class Rokerenmelding : Form
    {
        private Koning _koning { get; set; }

        public Rokerenmelding(Koning koning)
        {
            _koning = koning;
            InitializeComponent();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            _koning.Wilrokeren();
            DialogResult = DialogResult.Yes;

        }
    }
}