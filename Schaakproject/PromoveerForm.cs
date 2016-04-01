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
        private Pion _pion { get; set; }  //onthoudt de pion die wil promoveren

        public PromoveerForm(Pion pion, string _kleur)
        {
            InitializeComponent();
            this.ControlBox = false;
            _pion = pion;
            if (_kleur.Equals("zwart"))         
            {
                //verander de plaatjes zodat deze bij de kleur van de pion passen
                pbDame.Image = global::Schaakproject.Properties.Resources.DameZwart;
                pbLoper.Image = global::Schaakproject.Properties.Resources.LoperZwart;
                pbToren.Image = global::Schaakproject.Properties.Resources.TorenZwart;
                pbPaard.Image = global::Schaakproject.Properties.Resources.PaardZwart;
            }
        }

        private void pbPaard_Click(object sender, EventArgs e)
        {
            _pion.Promoveert("paard");
            DialogResult = DialogResult.Yes;
        }

        private void pbLoper_Click(object sender, EventArgs e)
        {
            _pion.Promoveert("loper");
            DialogResult = DialogResult.Yes;
        }

        private void pbDame_Click(object sender, EventArgs e)
        { 
            _pion.Promoveert("dame");
            DialogResult = DialogResult.Yes;
        }

        private void pbToren_Click(object sender, EventArgs e)
        {
            _pion.Promoveert("toren");
            DialogResult = DialogResult.Yes;
        }
    }
}
