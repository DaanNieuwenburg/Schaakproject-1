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
using LoginProject;

namespace Schaakproject
{
    public partial class MainForm : Form
    {
        private bool login = false;
        public string username { get; set; }
        public string password { get; set; }

        public MainForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            label4.Text = username;
            label5.Text = password;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            StreamReader userfile = new StreamReader(@"C:\Users\daan1\Source\Repos\Schaakproject\Login\username.txt");
            username = userfile.ReadLine();
            userfile.Close();
            StreamReader passfile = new StreamReader(@"C:\Users\daan1\Source\Repos\Schaakproject\Login\password.txt");
            password = passfile.ReadLine();
            passfile.Close();
            if (txtUsername.Text == username && txtPassword.Text == password)
            {
                login = true;
                label3.Text = login.ToString();
            }
            else
            {
                login = false;
                label3.Text = login.ToString();
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            FormRegister Registerdialog = new FormRegister();
            Registerdialog.ShowDialog();


            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
