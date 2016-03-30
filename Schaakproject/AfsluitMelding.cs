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
    public partial class AfsluitMelding : Form
    {
        public bool Sure { get; private set; }

        public AfsluitMelding()
        {
            InitializeComponent();
        }


        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Sure = false;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Sure = true;
        }
    }
}
