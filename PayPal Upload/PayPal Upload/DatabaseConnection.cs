using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace PayPal_Upload
{
    class Databaseconnection
    {
        private string connectionInfo = "SERVER=athena01.fhict.local;" +
                                      "DATABASE=dbi289514;" + // your database name
                                      "UID=dbi289514;" + // your user id
                                      "PASSWORD=HdPvIjPpDJ;";  // your password
        private string account = "INSERT INTO PAYPAL_ACCOUNT (BANK_NUMBER, NR_OF_DEPOSITS, START_TIME, END_TIME) VALUES (@BANK, @DEPO, @START, @END)";

        private string transaction = "INSERT INTO PAYPAL_TRANSACTION (TRANSACTION_ID, BANK_NUMBER, AMOUNT) VALUES (@TRAN, @BANK, @AMOUNT)";

        MySqlConnection con = null;
        MySqlCommand cmd = null;

        public Databaseconnection()
        {
            con = new MySqlConnection(connectionInfo);
            con.Open();
        }

        public void Upload(List<string> list)
        {
            cmd = new MySqlCommand(account, con);
            cmd.Parameters.AddWithValue("@BANK", list[0]);
            cmd.Parameters.AddWithValue("@DEPO", list[3]);
            cmd.Parameters.AddWithValue("@START", list[1]);
            cmd.Parameters.AddWithValue("@END", list[2]);
            cmd.ExecuteNonQuery();


            for (int i = 4; i < (list.Count()); i = i + 2)
            {
                cmd = new MySqlCommand(transaction, con);
                cmd.Parameters.AddWithValue("@BANK", list[0]);
                cmd.Parameters.AddWithValue("@TRAN", list[i]);
                cmd.Parameters.AddWithValue("@AMOUNT", list[i + 1]);
                cmd.ExecuteNonQuery();
            }

            con.Close();
        }

    }
}
