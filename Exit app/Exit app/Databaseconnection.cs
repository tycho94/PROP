using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace Exit_app
{
    class DatabaseConnection
    {
        private string connectionInfo = "SERVER=athena01.fhict.local;" +
                                        "DATABASE=dbi289514;" + // your database name
                                        "UID=dbi289514;" + // your user id
                                        "PASSWORD=HdPvIjPpDJ;";  // your password

        private string getbalance = "SELECT BALANCE FROM VISITOR WHERE RFID = @RFID";

        private string getrented = "SELECT RENTAL_ID FROM RENTEDITEM  where RFID = @RFID";

        private string leave = "UPDATE VISITOR SET STATUS = 0 WHERE RFID = @RFID";

        private string status = "SELECT STATUS FROM VISITOR WHERE RFID = @RFID";

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader rdr;
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

        public Int32 GetBalance(string tag)
        {
            int nbr = 0;
            cmd = new MySqlCommand(getbalance, con);
            cmd.Parameters.AddWithValue("@RFID", tag);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                nbr = rdr.GetInt32(0);
            }
            rdr.Close();
            return nbr;
        }

        public Int32 GetStatus(string tag)
        {
            int nbr = 0;
            cmd = new MySqlCommand(status, con);
            cmd.Parameters.AddWithValue("@RFID", tag);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                nbr = rdr.GetInt32(0);
            }
            rdr.Close();
            return nbr;
        }

        public Boolean GetRented(string tag)
        {
            int rented = -1;
            try
            {
                cmd = new MySqlCommand(getrented, con);
                cmd.Parameters.AddWithValue("@RFID", tag);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    rented = rdr.GetInt32(0);
                }
                rdr.Close();
            }
            catch
            {
                rented = -1;
            }

            if (rented < 0)
                return false;
            else
                return true;
        }

        public void leaving(string tag)
        {
            cmd = new MySqlCommand(leave, con);
            cmd.Parameters.AddWithValue("@RFID", tag);
            cmd.ExecuteNonQuery();
        }
        public void Disconnect()
        {
            con.Close();
        }
    }
}
