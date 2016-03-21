using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Schaakproject
{

    class Database : LoginForm
    {
        public string[] Username { get; set; }
        public string[] Password { get; set; }
        public string[] UserId { get; set; }
        public string invoeruser { get; set; }
        public string invoerpass { get; set; }
        public String[] _Username { get; set; }
        public String[] _Password { get; set; }
        public List<string> Userlist { get; set; }
        public List<string> Passlist { get; set; }

        //public bool valid { get; set; }

        public void connect()
        {

            String connCredentials = "Server = 127.0.0.1;Database=chessregisterdb;User Id=root;Password=daanpronk1;Connection Timeout = 5";
            MySqlConnection connection = new MySqlConnection(connCredentials);

            MySqlCommand query = connection.CreateCommand();
            query.CommandText = "SELECT * FROM logintable";
            connection.Open();
            MySqlDataReader reader = query.ExecuteReader();
            _Username = new String[5];
            _Password = new String[5];
            Userlist = new List<string>();
            Passlist = new List<string>();
            string[] UserId = new string[5];


            while (reader.Read())
            {
                Userlist.Add((String)reader["Username"]);
                Passlist.Add((String)reader["Password"]);
            }
        }
        public Database(string username, string password)
        {
            Console.WriteLine("invoeruser: " + invoeruser);
            Console.WriteLine("invoerpass: " + invoerpass);
            username = invoeruser;
            password = invoerpass;
            connect();
        }
    }
}
