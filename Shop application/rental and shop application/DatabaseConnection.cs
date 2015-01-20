using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace Shop_application
{
    class DatabaseConnection
    {
        private string connectionInfo = "SERVER=athena01.fhict.local;" +
                                    "DATABASE=dbi289514;" + // your database name
                                    "UID=dbi289514;" + // your user id
                                    "PASSWORD=HdPvIjPpDJ;";  // your password


        private string getItem = "SELECT * FROM ITEM";

        private string updateStock = "UPDATE ITEM SET ITEM_STOCK = @QUANTITY WHERE ITEMID = @IID";

        private string updateBalance = "UPDATE VISITOR SET BALANCE = @BALANCE WHERE RFID = @IDO";

        private string getBalance = "SELECT BALANCE FROM VISITOR WHERE  RFID = @IDO";


        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataReader rdr = null;
        List<Item> list;

        public DatabaseConnection()
        {
            con = new MySqlConnection(connectionInfo);
            con.Open();
        }


        public double loadBalance(string id)
        {
            if (id != null)
            {
                double balance = 0;
                cmd = new MySqlCommand(getBalance, con);
                cmd.Parameters.AddWithValue("@IDO", id);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    balance = rdr.GetDouble(0);
                }
                rdr.Close();
                con.Close();
                return balance;
            }
            else
                return -1;
        }

        public List<Item> LoadItemInfo()
        {
            list = new List<Item>();
            cmd = new MySqlCommand(getItem, con);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                var nama = rdr["ITEM_NAME"];
                var rcst = rdr["ITEM_PRICE"];

                var stock = rdr["ITEM_STOCK"];
                var id = rdr["ITEMID"];
                var img = rdr["IMAGE"];
                list.Add(new Item(Convert.ToString(nama), Convert.ToDouble(rcst), Convert.ToInt32(stock), Convert.ToString(id), Convert.ToString(img)));
            }

            rdr.Close();
            con.Close();
            return list;
        }

        public Boolean UpdateStock(int stock, double bought, string itemid)
        {
            // try
            // {
            cmd = new MySqlCommand(updateStock, con);
            cmd.Parameters.AddWithValue("@IID", itemid);
            cmd.Parameters.AddWithValue("@QUANTITY", (stock - bought));
            cmd.ExecuteNonQuery();
            return true;
            //  }
            //  catch
            //  {
            //      return false;
            //  }
        }

        public Boolean SetBalance(double balance, double price, int count, string id)
        {
            try
            {
                cmd = new MySqlCommand(updateBalance, con);
                cmd.Parameters.AddWithValue("@BALANCE", (balance - (price*count)));
                cmd.Parameters.AddWithValue("@IDO", id);

                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                con.Close();
                return false;
            }

        }

        public Boolean Insert(string ID, int SID, string RFID, string TIME, string DATE, double QUANTITY)
        {
           
            string insert = "INSERT INTO `dbi289514`.`itemsold` (`Item_ID`, `ShopID`, `RFID`, `EmpNr`, `time`, `Date`, `Quantity`) VALUES ('" + ID + "', '" + SID + "', '" + RFID + "', '112983', '" + TIME + "', '" + DATE + "', '" + QUANTITY + "')";
            
                cmd = new MySqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
        }


    }
}
