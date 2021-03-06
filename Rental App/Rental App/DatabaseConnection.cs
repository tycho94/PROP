﻿using System;
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

        private string updateBalance = "UPDATE VISITOR SET BALANCE = @BALANCE WHERE RFID = @IDO";

        private string updateStock = "UPDATE RENTAL SET RENTAL_STOCK = @STOCK WHERE RENTAL_ITEM_ID = @IDR";


        //private string getShop = "SELECT SHOP_ID FROM RENTAL_SHOP";

        //private string updateStock = "UPDATE RENTAL SET RENTAL_STOCK = @STOCK - @QUANTITY WHERE RENTAL_ITEM_ID = @IDR";

        //private string updateBalance = "UPDATE VISITOR SET BALANCE = @BALANCE - @PRICE WHERE RFID = @IDO";

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

        public int loadBalance(string id)
        {
            int balance = -1;

            cmd = new MySqlCommand(getBalance, con);
            cmd.Parameters.AddWithValue("@IDO", id);

            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                balance = rdr.GetInt32(0);
            }

            rdr.Close();
            return balance;

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
                var img = rdr["IMAGE"];
                var stock = rdr["RENTAL_STOCK"];
                var id = rdr["RENTAL_ITEM_ID"];

                list.Add(new Item(Convert.ToString(nama), Convert.ToDouble(rcst), Convert.ToDouble(rdpst), Convert.ToString(img), Convert.ToInt32(stock), Convert.ToInt32(id)));
            }

            rdr.Close();
            return list;

        }


        public List<Item> LoadUserItem(string RFID)
        {
            string getUserItem = "SELECT * FROM Rental Where Rental_item_id IN (Select RENTAL_ID FROM renteditem WHERE RFID = '" + RFID + "')";

            List<Item> result = new List<Item>();
            cmd = new MySqlCommand(getUserItem, con);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                var nama = rdr["RENTAL_NAME"];
                var rcst = rdr["RENTAL_PRICE"];
                var rdpst = rdr["RENTAL_DEPOSIT"];
                var img = rdr["IMAGE"];
                var stock = rdr["RENTAL_STOCK"];
                var id = rdr["RENTAL_ITEM_ID"];
                result.Add(new Item(Convert.ToString(nama), Convert.ToDouble(rcst), Convert.ToDouble(rdpst), Convert.ToString(img), Convert.ToInt32(stock), Convert.ToInt32(id)));
            }

            rdr.Close();
            return result;

        }
        //public List<Item> LoadShop() 
        //{
        //    list = new List<Item>();
        //    cmd = new MySqlCommand(getShop, con);
        //    rdr = cmd.ExecuteReader();

        //    while (rdr.Read()) 
        //    {
        //        var ShopID = rdr["SHOP_ID"];

        //        list.Add(new Item(ShopID.ToString()));
        //    }
        //}

        public Boolean insert(int RID,double Quantity, int SID, string RFID, string DateRent, string DateReturn, int deposit)
        {

            string insertRented = "INSERT INTO `dbi289514`.`renteditem` (`Rental_ID`,`Quantity`, `ShopID`, `RFID`, `Date_Rented`, `Return_Date`, `Deposit`)   VALUES ('" + RID + "', '" + Quantity + "' ,'" + SID + "', '" + RFID + "', '" + DateRent + "', '" + DateReturn + "', '" + deposit + "')";

            try
            {
                cmd = new MySqlCommand(insertRented, con);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean returned(int stock, int quantity, int RID) 
        {
            cmd = new MySqlCommand(updateStock, con);
            cmd.Parameters.AddWithValue("@STOCK", stock + quantity);
            cmd.Parameters.AddWithValue("@IDR", RID);
            cmd.ExecuteNonQuery();
            return true;

 
        }

        public Boolean Stocks(int stock, int quantity, int RId)
        {
                cmd = new MySqlCommand(updateStock, con);
                cmd.Parameters.AddWithValue("@STOCK", stock - quantity);
                cmd.Parameters.AddWithValue("@IDR", RId);
                cmd.ExecuteNonQuery();
                return true;

        }

        public Boolean Balance(double balance, double price, string id)
        {
            cmd = new MySqlCommand(updateBalance, con);
            cmd.Parameters.AddWithValue("@BALANCE", balance - price);
            cmd.Parameters.AddWithValue("@IDO", id);
            cmd.ExecuteNonQuery();
            return true;

        }

        public Boolean retDeposit(double balance, double deposit, string id) 
        {
            cmd = new MySqlCommand(updateBalance,con);
            cmd.Parameters.AddWithValue("@BALANCE", balance + deposit);
            cmd.Parameters.AddWithValue("@IDO", id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool deleteRent(int RID, string rfid)
        {
            string deleteRents = "DELETE FROM `dbi289514`.`renteditem` WHERE `renteditem`.`Rental_ID` = " + RID + " AND `renteditem`.`RFID` = \'" + rfid + "\'";
            try
            {

                cmd = new MySqlCommand(deleteRents, con);
                //cmd.Parameters.AddWithValue("@RID", RID);
                //cmd.Parameters.AddWithValue("@RFID", rfid);

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
