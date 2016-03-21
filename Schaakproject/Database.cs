using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Schaakproject
{

    public class Database : LoginForm
    {
        public string[] Username { get; set; }
        public string[] Password { get; set; }
        public string[] UserId { get; set; }
        public string invoeruser { get; set; }
        public string invoerpass { get; set; }
        public String[] _Username { get; set; }
        public String[] _Password { get; set; }

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
            string[] UserId = new string[5];


            while (reader.Read())
            {

                _Username[0] = (String)reader["Username"];
                invoeruser = _Username[0].ToString();
                Console.WriteLine("database test: "+ _Username[0]);
                _Password[0] = (String)reader["Password"];
                invoerpass = _Password[0].ToString();
                Console.WriteLine("database test: "+ _Password[0]);
                //UserId[0] = (string)reader["UserId rij"];
                /*Usernames[1] = (String)reader["username rij"];
                Passwords[1] = (String)reader["password rij"];
                UserId[1] = (String)reader["UserId rij"];
                Usernames[2] = (String)reader["username rij"];
                Passwords[2] = (String)reader["password rij"];
                UserId[2] = (String)reader["UserId rij"];
                Usernames[3] = (String)reader["username rij"];
                Passwords[3] = (String)reader["password rij"];
                UserId[3] = (String)reader["UserId rij"];
                Usernames[4] = (String)reader["username rij"];
                Passwords[4] = (String)reader["password rij"];
                UserId[4] = (String)reader["UserId rij"];*/
            }
            // werkt niet. Terug aanpassen in LoginForm if else
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
