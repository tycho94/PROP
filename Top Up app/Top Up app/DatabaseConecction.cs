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
    class DatabaseConecction
    {
        private string connectionInfo = "SERVER=athena01.fhict.local;" +
                                      "DATABASE=dbi289514;" + // your database name
                                      "UID=dbi289514;" + // your user id
                                      "PASSWORD=HdPvIjPpDJ;";  // your password


        private string getBalance = "SELECT BALANCE FROM VISITOR WHERE  Visitor_Id = @IDO";

        private string updateBalance="UPDATE VISITOR SET BALANCE = @BALANCE+@CREDITS WHERE Visitor_Id = @IDO";


        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataReader rdr = null;
        string list;

          public DatabaseConecction()
        {
            con = new MySqlConnection(connectionInfo);
            con.Open();
        }


          public string loadBalance(int id) 
          {
              cmd = new MySqlCommand(getBalance, con);
              cmd.Parameters.AddWithValue("@IDO", id);

              rdr = cmd.ExecuteReader();

              while (rdr.Read())
              {
                  var blc = rdr["BALANCE"];

                  list = Convert.ToString(blc);

              }

              rdr.Close();
              return list;
 
          }

          public Boolean adding(int balance, int credits, int id)
          {
              try
              {
                  cmd = new MySqlCommand(updateBalance, con);

                  cmd.Parameters.AddWithValue("@BALANCE", balance);
                  cmd.Parameters.AddWithValue("@CREDITS", credits);
                  cmd.Parameters.AddWithValue("@IDO", id);
                  cmd.ExecuteNonQuery();

                  return true;
              }
              catch
              { return false; }

              
          }


          public void Disconnect()
          {
              con.Close();
          }
    }
}
