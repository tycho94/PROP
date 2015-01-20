using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace entrance_application
{
    class DatabaseConnection
    {
        private string connectionInfo = "SERVER=athena01.fhict.local;" +
                                        "DATABASE=dbi289514;" + // your database name
                                        "UID=dbi289514;" + // your user id
                                        "PASSWORD=HdPvIjPpDJ;";  // your password

        private string status = "SELECT STATUS FROM VISITOR WHERE RFID = @RFID";

        private string name = "SELECT LAST_NAME FROM VISITOR WHERE RFID = @RFID";

        private string pass = "SELECT PASSWORD FROM access_pass WHERE Security_lvl = 2 OR Security_lvl = 3";

        private string changestatus = "UPDATE VISITOR SET STATUS = @STATUS WHERE RFID = @RFID";


        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader rdr;
        public DatabaseConnection()
        {
            con = new MySqlConnection(connectionInfo);
            con.Open();
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
            con.Close();
            return nbr;
        }

        public Boolean GetPass(string tag, string pass)
        {
            bool n = false;
            cmd = new MySqlCommand(this.pass, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (pass == rdr.GetString(0))
                    n = true;
            }
            rdr.Close();
            con.Close();
            return n;
        }

        public string GetName(string tag)
        {
            string name = "";
            cmd = new MySqlCommand(this.name, con);
            cmd.Parameters.AddWithValue("@RFID", tag);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                name = rdr.GetString(0);
            }
            rdr.Close();
            con.Close();
            return name;
        }

        public void ChangeStatus(string tag, int status)
        {
            cmd = new MySqlCommand(changestatus, con);
            cmd.Parameters.AddWithValue("@STATUS", status);
            cmd.Parameters.AddWithValue("@RFID", tag);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
