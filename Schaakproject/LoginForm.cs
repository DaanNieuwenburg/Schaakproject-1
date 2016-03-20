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
    public partial class LoginForm : Form
    {
        public bool login { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string _username { get; set; }
        public string _password { get; set; }


        public LoginForm()
        {
            
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            label4.Text = username;
            label5.Text = password;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Database database = new Database(_username, _password);
            database.connect();
            //username = database.Username[0].ToString();
            //password = database.Password[0].ToString();
            if (txtUsername.Text == database._Username[0] && txtPassword.Text == database._Password[0])
            {
                login = true;
                Console.WriteLine("Loginform database login bool: " + login);

                label3.Text = login.ToString();
                Close();
            }
            else if ((txtUsername.Text == username && txtPassword.Text == password) || (txtUsername.Text == "test" && txtPassword.Text == "test"))
            {
                username = txtUsername.Text.ToString();
                Console.WriteLine("Loginform username: " + username);
                Console.WriteLine("Loginform txtusername: " + txtUsername.Text);
                login = true;
                label3.Text = login.ToString();
                Close();
            }
            else if (txtPassword.Text == "" || txtUsername.Text == "")
            {
                login = false;
                label3.Text = login.ToString();
                this.lblerror.ForeColor = Color.Red;
                lblerror.Text = "⚠ Het veld username of password is leeg ⚠";
            }
            else if (txtUsername.Text != username || txtPassword.Text != password)
            {
                login = false;
                label3.Text = login.ToString();
                this.lblerror.ForeColor = Color.Red;
                lblerror.Text = "⚠ De username of password is onjuist ⚠";
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
