using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LoginProject
{
    public partial class FormRegister : Form
    {
        public string user { get; set; }
        public string pass { get; set; }
        private bool confirmed { get; set; }
        public StreamWriter userfile { get; set; }
        public StreamWriter passfile { get; set; }


        public FormRegister()
        {
            confirmed = false;
            InitializeComponent();
            //userfile = new StreamWriter(@"C:\Users\daan1\Source\Repos\Schaakproject\Login\username.txt", true);
            // file nog veranderen naar de projectfolder. Werkt nu nog niet.
           //passfile = new StreamWriter(@"C:\Users\daan1\Source\Repos\Schaakproject\Login\password.txt", true);
            // file nog veranderen naar de projectfolder. Werkt nu nog niet.
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            lblerror.Text = null;
            if (txtpass.Text == txtconfirm.Text && txtvoornaam.Text != null && txtachternaam.Text != null && txtconfirm.Text != null && txtpass.Text != null && txtuser.Text != null)
            {
                user = txtuser.Text;
                pass = txtpass.Text;
               // userfile.WriteLine(user);
                //userfile.Close();
               // passfile.WriteLine(pass);
                //passfile.Close();
                // Main.username = txtuser.Text;
                //Main.password = txtpass.Text;
                DialogResult = DialogResult.Yes;
                //button1.DialogResult = DialogResult.No;
            }
            else if (txtvoornaam.Text == null || txtachternaam.Text == null || txtconfirm.Text == null || txtpass.Text == null || txtuser.Text == null)
            {
                lblerror.ForeColor = Color.Red;
                lblerror.Text = "⚠ 1 of meer verplichte velden zijn leeg ⚠";
            }
            else if (txtpass.Text != txtconfirm.Text)
            {
                lblerror.ForeColor = Color.Red;
                lblerror.Text = "⚠ Password en Confirm zijn niet het zelfde ⚠";
            }

        }

        private void txtconfirm_TextChanged(object sender, EventArgs e)
        {
            txtconfirm.PasswordChar = '*';              // hierdoor is het ingevoerde wachtwoord onzichtbaar
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            txtpass.PasswordChar = '*';                 // hierdoor is het ingevoerde wachtwoord onzichtbaar
        }
    }
}

