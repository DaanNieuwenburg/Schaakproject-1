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
    public partial class PromoveerForm : Form
    {
        Pion pion { get; set; }
        public PromoveerForm(Pion _pion)
        {
            InitializeComponent();
            pion = _pion;
        }

        private void pbPaard_Click(object sender, EventArgs e)
        {
            pion.Promoveert("paard");
            DialogResult = DialogResult.Yes;
        }

        private void pbLoper_Click(object sender, EventArgs e)
        {
            pion.Promoveert("loper");
            DialogResult = DialogResult.Yes;
        }

        private void pbDame_Click(object sender, EventArgs e)
        { 
            pion.Promoveert("dame");
            DialogResult = DialogResult.Yes;
        }

        private void pbToren_Click(object sender, EventArgs e)
        {
            pion.Promoveert("toren");
            DialogResult = DialogResult.Yes;
        }
    }
}
