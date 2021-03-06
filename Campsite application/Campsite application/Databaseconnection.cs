﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace Campsite_application
{
    class DatabaseConnection
    {
        private string connectionInfo = "SERVER=athena01.fhict.local;" +
                                        "DATABASE=dbi289514;" + // your database name
                                        "UID=dbi289514;" + // your user id
                                        "PASSWORD=HdPvIjPpDJ;";  // your password

        private string name = "SELECT First_name, LAST_NAME FROM VISITOR WHERE RFID = @RFID";

        private string balance = "SELECT BALANCE FROM VISITOR WHERE RFID = @RFID";

        private string site = "SELECT CAMPSPOT FROM VISITOR WHERE RFID = @RFID";

        private string sites = "SELECT SPOTID FROM CAMPSPOT WHERE RESERVEE IS NULL";

        private string price = "SELECT PRICE FROM CAMPSPOT WHERE SPOTID = @SPOTID";

        private string reserve1 = "UPDATE CAMPSPOT SET RESERVEE = @RFID WHERE SPOTID = @SPOTID";
        private string reserve2 = "UPDATE VISITOR SET CAMPSPOT = @SPOTID WHERE RFID = @RFID";

        private string checkspot = "SELECT RESERVEE FROM CAMPSPOT WHERE SPOTID = @SPOTID";

        private string setspot = "UPDATE VISITOR SET CAMPSPOT = @SPOTID WHERE RFID =@RFID";

        private string getspot = "SELECT SPOTID FROM CAMPSPOT WHERE RESERVEE = @RFID";

        private string maxspots = "SELECT COUNT(CAMPSPOT) FROM VISITOR WHERE CAMPSPOT = @SPOTID";


        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader rdr;
        List<Int32> list;
        public DatabaseConnection()
        {
            con = new MySqlConnection(connectionInfo);
            con.Open();
        }

        public Boolean Reserve(string tag, int spotID)
        {
            string b = "";
            try
            {
                cmd = new MySqlCommand(checkspot, con);
                cmd.Parameters.AddWithValue("@SPOTID", spotID);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    b = rdr.GetString(0);
                }
                rdr.Close();
                con.Close();
                return false;
            }
            catch
            {
                try
                {

                    rdr.Close();

                    if (b == "")
                    {

                        cmd = new MySqlCommand(reserve1, con);
                        cmd.Parameters.AddWithValue("@RFID", tag);
                        cmd.Parameters.AddWithValue("@SPOTID", spotID);
                        cmd.ExecuteNonQuery();

                        cmd = new MySqlCommand(reserve2, con);
                        cmd.Parameters.AddWithValue("@RFID", tag);
                        cmd.Parameters.AddWithValue("@SPOTID", spotID);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        return true;
                    }
                    con.Close();
                    return false;
                }
                catch
                {
                    con.Close();
                    return false;
                }
            }
        }

        public Boolean SetSite(string ftag, string stag)
        {
            try
            {
                int a = -1;
                cmd = new MySqlCommand(getspot, con);
                cmd.Parameters.AddWithValue("@RFID", ftag);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    a = rdr.GetInt32(0);
                }
                rdr.Close();
                int b = 0;
                cmd = new MySqlCommand(maxspots, con);
                cmd.Parameters.AddWithValue("@SPOTID", a);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    b = rdr.GetInt32(0);
                }
                rdr.Close();

                if (a != -1 && b > 0)
                {
                    cmd = new MySqlCommand(setspot, con);
                    cmd.Parameters.AddWithValue("@SPOTID", a);
                    cmd.Parameters.AddWithValue("@RFID", stag);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch
            {
                con.Close();
                return false;
            }
        }


        public List<Int32> ListSites()
        {
            list = new List<Int32>();
            cmd = new MySqlCommand(this.sites, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(rdr.GetInt32(0));
            }
            rdr.Close();
            con.Close();
            return list;
        }

        public Int32 GetPrice(int spot)
        {
            int nr = -1;
            cmd = new MySqlCommand(price, con);
            cmd.Parameters.AddWithValue("@SPOTID", spot);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                nr = rdr.GetInt32(0);
            }
            rdr.Close();
            con.Close();
            return nr;
        }

        public String GetName(string tag)
        {
            string name = "";
            cmd = new MySqlCommand(this.name, con);
            cmd.Parameters.AddWithValue("@RFID", tag);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                name = rdr.GetString(0) + " " + rdr.GetString(1);
            }
            rdr.Close();
            con.Close();
            return name;
        }

        public Int32 GetMoney(string tag)
        {
            int nr = 0;
            cmd = new MySqlCommand(balance, con);
            cmd.Parameters.AddWithValue("@RFID", tag);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                nr = rdr.GetInt32(0);
            }
            rdr.Close();
            con.Close();
            return nr;
        }

        public Int32 GetSite(string tag)
        {
            try
            {
                int nr = -1;
                cmd = new MySqlCommand(site, con);
                cmd.Parameters.AddWithValue("@RFID", tag);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    nr = rdr.GetInt32(0);
                }
                rdr.Close();
                con.Close();
                return nr;
            }
            catch
            {
                rdr.Close();
                con.Close();
                return -1;
            }

        }
    }
}
