using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLChatCSharp
{
    class SQLConnect
    {
        public MySqlConnection connect()
        {
            string server;
            string database;
            string uid;
            string password;
            MySqlConnection connection;

            server = "127.0.0.1";
            database = "webchat";
            uid = "test";
            password = "steve";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception)
            {
                return connection;
                throw;
            }
        }
    }
}
