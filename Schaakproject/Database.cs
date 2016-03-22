using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Schaakproject
{

    public class Database
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
        String connCredentials = "Server = 127.0.0.1;Database=chessregisterdb;User Id=root;Password=daanpronk1;Connection Timeout = 5";
        public MySqlConnection connection;
        //public bool valid { get; set; }
        public Database(string username, string password)
        {
            Console.WriteLine("invoeruser: " + invoeruser);
            Console.WriteLine("invoerpass: " + invoerpass);
            username = invoeruser;
            password = invoerpass;
            //Login();
        }
        public void Register(string R_user, string R_pass, string R_voornaam, string R_achternaam)
        {
            //using (MySqlConnection connection = new MySqlConnection(connCredentials))
            {
                MySqlCommand query = connection.CreateCommand();
                int Count = 0;
                query.CommandText = "Select MAX(UserId) WHERE UserId != null";
                query.ExecuteNonQuery();
                connection.Open();
                Count = (int)query.ExecuteScalar();
                int newCount = Count + 1;
                query.CommandText = "INSERT INTO Register (UserId, Username, Password, Voornaam, Achternaam) VALUES (@UserId, @Username, @Password, @Voornaam, @Achternaam)";
                query.Parameters.AddWithValue("@UserId", newCount);
                query.Parameters.AddWithValue("@Username", R_user);
                query.Parameters.AddWithValue("@Password", R_pass);
                query.Parameters.AddWithValue("@Voornaam", R_voornaam);
                query.Parameters.AddWithValue("@Achternaam", R_achternaam);
                query.ExecuteNonQuery();
            }
        }
        public void Login()
        {
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
        
    }
}
