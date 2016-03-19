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
        public void connect()
        {
            String connCredentials = "Server = 127.0.0.1;Database=chessregisterdb;User Id=root;Password=daanpronk1;Connection Timeout = 5";
            MySqlConnection connection = new MySqlConnection(connCredentials);

            MySqlCommand query = connection.CreateCommand();
            query.CommandText = "SELECT * FROM logintable";
            connection.Open();
            MySqlDataReader reader = query.ExecuteReader();
            
            string[] Passwords = new string[5];
            string[] UserId = new string[5];
           

            while (reader.Read())
            {
                
                Username[0] = (string)reader["Username"];
                Password[0] = (string)reader["Password"];
                UserId[0] = (string)reader["UserId rij"];
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
        }
    }
}
