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
    public partial class Rokerenmelding : Form
    {
        public Koning koning { get; set; }
        public Rokerenmelding(Koning _koning)
        {
            koning = _koning;
            InitializeComponent();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            koning.Wilrokeren();
            DialogResult = DialogResult.Yes;

        }
    }
}