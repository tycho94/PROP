﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace rental_and_shop_application
{
    class DatabaseConnection
    {
        private string connectionInfo = "SERVER=athena01.fhict.local;" +
                                    "DATABASE=dbi289514;" + // your database name
                                    "UID=dbi289514;" + // your user id
                                    "PASSWORD=HdPvIjPpDJ;";  // your password


        private string getItem = "SELECT * FROM ITEM";

        private string updateStock = "UPDATE ITEM SET ITEM_STOCK = @STOCK - @QUANTITY WHERE ITEMID = '@IID'";

        private string updateBalance = "UPDATE VISITOR SET BALANCE = @BALANCE - @PRICE WHERE Visitor_Id = @IDO";

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


        public string loadBalance(int id)
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
                list.Add(new Item(Convert.ToString(nama), Convert.ToDouble(rcst), Convert.ToInt32(stock), Convert.ToString(id)));
            }

            rdr.Close();
            return list;
        }

        public Boolean Balance(int balance, string operation, int price, int Vid)
        {
            try
            {
                cmd = new MySqlCommand(updateBalance, con);
                cmd.Parameters.AddWithValue("@BALANCE", balance);
                cmd.Parameters.AddWithValue("@OPERATION", operation);
                cmd.Parameters.AddWithValue("@PRICE", price);
                cmd.Parameters.AddWithValue("@IDO", Vid);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Stocks(int stock, string operation, int quantity, string Iid)
        {
            try
            {
                cmd = new MySqlCommand(updateStock, con);
                cmd.Parameters.AddWithValue("@STOCK", stock);
                cmd.Parameters.AddWithValue("@OPERATION", operation);
                cmd.Parameters.AddWithValue("@QUANTITY", quantity);
                cmd.Parameters.AddWithValue("@IID", Iid);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Disconnect()
        {
            con.Close();
        }
    }
}