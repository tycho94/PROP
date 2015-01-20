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

        //private string updateStock = "UPDATE ITEM SET ITEM_STOCK = @STOCK - @QUANTITY WHERE ITEMID = @IID";

        private string updateBalance = "UPDATE VISITOR SET BALANCE = @BALANCE - @PRICE WHERE RFID = @IDO";

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


        public string loadBalance(string id)
        {
            string blnc = "";

            cmd = new MySqlCommand(getBalance, con);
            cmd.Parameters.AddWithValue("@IDO", id);

            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                var blc = rdr["BALANCE"];
                blnc = blc.ToString();
            }

            rdr.Close();
            con.Close();
            return blnc;



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

        public Boolean Balance(int balance,  int price, string Vid)
        {
            try
            {
                cmd = new MySqlCommand(updateBalance, con);
                cmd.Parameters.AddWithValue("@BALANCE", balance);
                //cmd.Parameters.AddWithValue("@OPERATION", operation);
                cmd.Parameters.AddWithValue("@PRICE", price);
                cmd.Parameters.AddWithValue("@IDO", Vid);

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

        public Boolean Stocks(int stock, string operation, int quantity, string Iid)
        {
            string updateStock = "UPDATE ITEM SET ITEM_STOCK = "+stock+"  WHERE ITEMID = '"+Iid +"'";
            try
            {
                cmd = new MySqlCommand(updateStock, con);
                //cmd.Parameters.AddWithValue("@STOCK", stock);
                //cmd.Parameters.AddWithValue("@OPERATION", operation);
                //cmd.Parameters.AddWithValue("@QUANTITY", quantity);
                //cmd.Parameters.AddWithValue("@IID", Iid);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Insert(string ID, int SID, string RFID, string TIME, string DATE, double QUANTITY) 
        {
            string insert= "INSERT INTO `dbi289514`.`itemsold` (`Item_ID`, `ShopID`, `RFID`, `EmpNr`, `time`, `Date`, `Quantity`) VALUES ('"+ID+"', '"+SID+"', '"+RFID+"', '112983', '"+TIME+"', '"+DATE+"', '"+QUANTITY+"')";
            try
            {
                cmd = new MySqlCommand(insert, con);
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
    }
}
