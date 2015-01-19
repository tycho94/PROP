using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace Admin_application
{
    class DatabaseConnection
    {
        private string connectionInfo = "SERVER=athena01.fhict.local;" +
                                        "DATABASE=dbi289514;" + // your database name
                                        "UID=dbi289514;" + // your user id
                                        "PASSWORD=HdPvIjPpDJ;";  // your password

        private string nrofvisitors = "SELECT COUNT(*) FROM VISITOR WHERE ACTIVE = 1";

        private string names = "SELECT LAST_NAME FROM VISITOR WHERE ACTIVE = 1";

        private string tickets = "SELECT COUNT(*) FROM VISITOR";

        private string changestatus = "UPDATE VISITOR SET ACTIVE = @STATUS WHERE RFID = @RFID";
        private string itemssold = "Select  SUM(quantity) from itemsold";

        private string stock = "";


        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader rdr;
        List<string> list;

        public DatabaseConnection()
        {
            con = new MySqlConnection(connectionInfo);
            con.Open();
        }

        public List<string> GetNames()
        {
            list = new List<string>();
            cmd = new MySqlCommand(this.names, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(rdr.GetString(0));
            }
            rdr.Close();
            return list;
        }

        public Int32 GetVisitors()
        {
            int nr = 0;
            cmd = new MySqlCommand(this.nrofvisitors, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                nr = rdr.GetInt32(0);
            }
            rdr.Close();
            return nr;
        }

        public Int32 GetTickets()
        {
            int nr = 0;
            cmd = new MySqlCommand(this.tickets, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                nr = rdr.GetInt32(0);
            }
            rdr.Close();
            return nr;
        }

        public Int32 TotalSold()
        {
            int nr = 0;
            cmd = new MySqlCommand(itemssold, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                nr = rdr.GetInt32(0);
            }
            rdr.Close();
            return nr;
        }

        public List<string> GetStock()
        {
            list = new List<string>();
            cmd = new MySqlCommand(this.names, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(rdr.GetString(0));
            }
            rdr.Close();
            return list;
        }
        
        public void Disconnect()
        {
            con.Close();
        }
    }
}
