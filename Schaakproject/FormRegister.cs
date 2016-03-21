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
using Schaakproject;

namespace LoginProject
{
    public partial class FormRegister : Form
    {
        public string user { get; set; }
        public string pass { get; set; }
        public string voornaam { get; set; }
        public string achternaam { get; set; }
        private bool confirmed { get; set; }
        public StreamWriter userfile { get; set; }
        public StreamWriter passfile { get; set; }
        public Database _database { get; set; }
        public FormRegister(Database database)
        {
            
            _database = database;
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
            if (txtpass.Text == txtconfirm.Text && txtvoornaam.Text != "" && txtachternaam.Text != "" && txtconfirm.Text != "" && txtpass.Text != "" && txtuser.Text != "")
            {
                user = txtuser.Text;
                pass = txtpass.Text;
                voornaam = txtvoornaam.Text;
                achternaam = txtachternaam.Text;
                Console.WriteLine(user + pass + voornaam + achternaam);
                _database.Register(user, pass, voornaam, achternaam);
                DialogResult = DialogResult.Yes;
            }
            else if ((txtvoornaam.Text == "" || txtachternaam.Text == "" || txtconfirm.Text == "" || txtpass.Text == "" || txtuser.Text == "")&& (txtpass.Text != txtconfirm.Text))
            {
                lblerror.ForeColor = Color.Red;
                lblerror.Text = "⚠ 1 of meer verplichte velden zijn leeg \nen het de wachtwoorden zijn ongelijk⚠";
            }
            else if (txtvoornaam.Text == "" || txtachternaam.Text == "" || txtconfirm.Text == "" || txtpass.Text == "" || txtuser.Text == "")
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

