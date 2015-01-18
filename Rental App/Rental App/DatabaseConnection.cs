using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace Rental_App
{
    class DatabaseConnection
    {
        private string connectionInfo = "SERVER=athena01.fhict.local;" +
                                     "DATABASE=dbi289514;" + // your database name
                                     "UID=dbi289514;" + // your user id
                                     "PASSWORD=HdPvIjPpDJ;";  // your password

        private string getItem = "SELECT * FROM RENTAL";

        private string updateStock = "UPDATE RENTAL SET RENTAL_STOCK = @STOCK @OPERATION @QUANTITY WHERE RENTAL_ID = @IDR";

        private string updateBalance = "UPDATE VISITOR SET BALANCE = @BALANCE @OPERATION @CREDITS WHERE Visitor_Id = @IDO";

        private string insertRented = "INSERT INTO RENTEDITEM(RENTAL_ID, SHOP_ID, RFID, DATE_RENTED, RETURN_DATE, DEPOSIT";

        private string getBalance = "SELECT BALANCE FROM VISITOR WHERE  Visitor_Id = @IDO";

        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataReader rdr = null;
        List<Item> list;

          public DatabaseConnection()
        {
            con = new MySqlConnection(connectionInfo);
            con.Open();
        }

          public List<Item> loadBalance(int id)
          {
              cmd = new MySqlCommand(getBalance, con);
              cmd.Parameters.AddWithValue("@IDO", id);

              rdr = cmd.ExecuteReader();

              while (rdr.Read())
              {
                  var blc = rdr["BALANCE"];

                  list.Add(blc.ToString());

              }

              rdr.Close();
              return list;

          }

          public List<Item> LoadItemInfo() 
          {
              list = new List<Item>();
              cmd = new MySqlCommand(getItem, con);
              rdr = cmd.ExecuteReader();

              while (rdr.Read())
              {
                  var nama = rdr["RENTAL_NAME"];
                  var rcst = rdr["RENTAL_PRICE"];
                  var rdpst = rdr["RENTAL_DEPOSIT"];
                  var  stock = rdr["RENTAL_STOCK"];
                  var id = rdr["RENTAL_ITEM_ID"];
                  list.Add(new Item(Convert.ToString(nama), Convert.ToDouble(rcst), Convert.ToDouble(rdpst), Convert.ToInt32(stock), Convert.ToInt32(id)));
              }

              rdr.Close();
              return list;

          }

          public Boolean Stocks(int stock, string operation, int quantity, int RId) 
          {
              try
              {
                  cmd = new MySqlCommand(updateStock, con);
                  cmd.Parameters.Add("@STOCK", stock);
                  cmd.Parameters.Add("@OPERATION", operation);
                  cmd.Parameters.Add("@QUANTITY", quantity);
                  cmd.Parameters.Add("@IDR", RId);
                  cmd.ExecuteNonQuery();

                  return true;
              }
              catch
              {
                  return false;
              }
          }

          public Boolean Balance(int balance, string operation, int credits, int Vid) 
          {
              try
              {
                  cmd = new MySqlCommand(updateBalance, con);
                  cmd.Parameters.Add("@BALANCE", balance);
                  cmd.Parameters.Add("@OPERATION", operation);
                  cmd.Parameters.Add("@CREDITS", credits);
                  cmd.Parameters.Add("@IDO", Vid);

                  cmd.ExecuteNonQuery();
                  return true;
              }
              catch 
              {
                  return false;
              }
          }
    }

}
