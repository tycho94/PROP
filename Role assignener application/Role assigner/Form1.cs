﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Role_assigner
{
    public partial class Form1 : Form
    {
        List<String> list = new List<String>();
        DatabaseConnection data;

        public Form1()
        {
            InitializeComponent();
            statusStrip1.SizingGrip = false;
            data = new DatabaseConnection();
            list = data.LoadEmployees();
            for (int i = 0; i < list.Count(); i++)
            { empNameDropdown.Items.Add(list[i]); }
            roleDropdown.Items.Add("Bouncer");
            roleDropdown.Items.Add("Cashier");
            roleDropdown.Items.Add("Manager");
            roleDropdown.Items.Add("Owner");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                data = new DatabaseConnection();
                if (data.SetRoles((((String)empNameDropdown.SelectedItem).ToString()), (((String)roleDropdown.SelectedItem).ToString())))
                {
                    Status.Text = "Role set!";
                    lbRole.Text = "Current job: " + (((String)roleDropdown.SelectedItem).ToString());
                }
                else
                {
                    Status.Text = "Something went wrong!";
                }
            }
            catch
            { Status.Text = "Select a employee/role from the menu."; }

        }

        private void empNrDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            data = new DatabaseConnection();
            list = (data.LoadEmpInfo(((String)empNameDropdown.SelectedItem).ToString()));
            lbEmpNr.Text = "Employee #: " + list[0];
            string trim = "DOB: " + list[1];
            lbDob.Text = trim.Trim('0', ':');
            lbRole.Text = "Current job: " + list[2];
            
        }
    }
}
