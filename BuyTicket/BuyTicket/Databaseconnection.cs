using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace BuyTicket
{
    class DatabaseConnection
    {
        private string connectionInfo = "SERVER=athena01.fhict.local;" +
                                        "DATABASE=dbi289514;" + // your database name
                                        "UID=dbi289514;" + // your user id
                                        "PASSWORD=HdPvIjPpDJ;";  // your password

        private string addvisitor = "INSERT INTO VISITOR (LAST_NAME, FIRST_NAME, EMAIL, DATE_OF_BIRTH, PHONE, STREET_ADDRESS, CITY, COUNTRY, POSTAL_CODE, ACCOUNT_NR, RFID) VALUES (@LNAME, @FNAME, @MAIL, @DOB, @PHONE, @STREET, @CITY, @COUNTRY, @POSTAL, @ACCOUNT, @RFID)";

        MySqlConnection con;
        MySqlCommand cmd;
        public DatabaseConnection()
        {
            con = new MySqlConnection(connectionInfo);
            con.Open();
        }

        public Boolean AddVisitor(string fname, string lname, string mail, DateTime dob, int phone, string street, string city, string country, string postal, int account, string tag)
        {
            //try
            //{
                cmd = new MySqlCommand(addvisitor, con);
                cmd.Parameters.AddWithValue("@LNAME", lname);
                cmd.Parameters.AddWithValue("@FNAME", fname);
                cmd.Parameters.AddWithValue("@MAIL", mail);
                cmd.Parameters.AddWithValue("@DOB", dob);
                cmd.Parameters.AddWithValue("@PHONE", phone);
                cmd.Parameters.AddWithValue("@STREET", street);
                cmd.Parameters.AddWithValue("@CITY", city);
                cmd.Parameters.AddWithValue("@COUNTRY", country);
                cmd.Parameters.AddWithValue("@POSTAL", postal);
                cmd.Parameters.AddWithValue("@ACCOUNT", account);
                cmd.Parameters.AddWithValue("@RFID", tag);
                cmd.ExecuteNonQuery();
                return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }


    }
}
