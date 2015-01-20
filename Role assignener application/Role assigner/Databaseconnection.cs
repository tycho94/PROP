using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace Role_assigner
{
    class DatabaseConnection
    {
        private string connectionInfo = "SERVER=athena01.fhict.local;" +
                                        "DATABASE=dbi289514;" + // your database name
                                        "UID=dbi289514;" + // your user id
                                        "PASSWORD=HdPvIjPpDJ;";  // your password

        private string updateEmployee = "UPDATE EMPLOYEE SET JOB = @ROLE WHERE LAST_NAME =@NAME";

        private string infoEmployee = "SELECT EMPNR, DATE_OF_BIRTH, JOB FROM EMPLOYEE WHERE LAST_NAME =@NAME";

        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataReader rdr = null;
        List<String> list;
        public DatabaseConnection()
        {
            con = new MySqlConnection(connectionInfo);
            con.Open();
        }

        public List<String> LoadEmployees()
        {
            list = new List<String>();
            cmd = new MySqlCommand("SELECT LAST_NAME FROM EMPLOYEE", con);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(rdr.GetString(0));
            }
            rdr.Close();
            con.Close();
            return list;
        }

        public Boolean SetRoles(string name, string role)
        {
            try
            {
                cmd = new MySqlCommand(updateEmployee, con);
                cmd.Parameters.AddWithValue("@NAME", name);
                cmd.Parameters.AddWithValue("@ROLE", role);
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

        public List<String> LoadEmpInfo(string name)
        {
            list = new List<String>();
            cmd = new MySqlCommand(infoEmployee, con);
            cmd.Parameters.AddWithValue("@NAME", name);
            rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                var nr = rdr["EMPNR"];
                var dob = rdr["DATE_OF_BIRTH"];
                var job = rdr["JOB"];
                list.Add(nr.ToString());
                list.Add(dob.ToString());
                list.Add(job.ToString());
            }

            rdr.Close();
            con.Close();
            return list;
        }

    }
}
