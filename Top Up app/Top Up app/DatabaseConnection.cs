using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace Top_Up_app
{
    class Databaseconnection
    {
        private string connectionInfo = "SERVER=athena01.fhict.local;" +
                                      "DATABASE=dbi289514;" + // your database name
                                      "UID=dbi289514;" + // your user id
                                      "PASSWORD=HdPvIjPpDJ;";  // your password

        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataReader rdr = null;
        string list;

        public Databaseconnection()
        {
            con = new MySqlConnection(connectionInfo);
            con.Open();
        }

    }
}
