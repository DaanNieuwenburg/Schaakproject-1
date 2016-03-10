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
        public StreamWriter userfile { get; set; }
        public StreamWriter passfile { get; set; }


        public FormRegister()
        {
            InitializeComponent();
            userfile = new StreamWriter(@"C:\Users\daan1\Documents\Visual Studio 2015\Projects\LoginProject\Login\username.txt", true);
            // file nog veranderen naar de projectfolder. Werkt nu nog niet.
            passfile = new StreamWriter(@"C:\Users\daan1\Documents\Visual Studio 2015\Projects\LoginProject\Login\password.txt", true);
            // file nog veranderen naar de projectfolder. Werkt nu nog niet.
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            user = txtuser.Text;
            pass = txtpass.Text;
            userfile.WriteLine(user);
            userfile.Close();
            passfile.WriteLine(pass);
            passfile.Close();
            // Main.username = txtuser.Text;
            //Main.password = txtpass.Text;
            DialogResult = DialogResult.Yes;
            //button1.DialogResult = DialogResult.No;
        }
    }
}

