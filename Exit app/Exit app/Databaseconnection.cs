using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace Role_assigner
{
    class DatabaseConnection
    {
        private string connectionInfo = "SERVER=athena01.fhict.local;" +
                                        "DATABASE=dbi289514;" + // your database name
                                        "UID=dbi289514;" + // your user id
                                        "PASSWORD=HdPvIjPpDJ;";  // your password

        private string getbalance = "SELECT BALANCE FROM VISITOR WHERE RFIDNR =@RFID";
        public Int32 GetBalance(string tag)
        {
            int nbr;
            cmd = new MySqlCommand(getbalance, con);
            cmd.Parameters.AddWithValue("@RFID", tag);
            nbr = Convert.ToInt32(cmd.ExecuteScalar());
            return 0;
        }

        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataReader rdr = null;
        List<String> list;
        public DatabaseConnection()
        {
            con = new MySqlConnection(connectionInfo);
            con.Open();
        }

        public String Version()
        {
            string stm = "SELECT VERSION()";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            string version = "Connected to database. Version: " + Convert.ToString(cmd.ExecuteScalar());
            return version;
        }


        public void Disconnect()
        {
            con.Close();
        }
    }
}
