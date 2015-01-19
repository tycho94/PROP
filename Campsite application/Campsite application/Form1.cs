﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;

namespace Campsite_application
{
    public partial class Form1 : Form
    {
        private RFID Reader;
        DatabaseConnection data = new DatabaseConnection();
        string tag;
        int spot;
        public Form1()
        {
            InitializeComponent();
            try
            {
                Reader = new RFID();
                //Reader.Attach += new AttachEventHandler(ReaderAttached);
                Reader.Tag += new TagEventHandler(Scan);
                Reader.open();
                Reader.waitForAttachment(3000);
                Reader.Antenna = true;
                Reader.LED = true;
            }
            catch (PhidgetException)
            {
                MessageBox.Show("RFID reader not found. \nExiting program.");
                Environment.Exit(1);
            }

            lbFreeSites.DataSource = data.ListSites();
        }


        private void reserveBtn_Click(object sender, EventArgs e)
        {
            spot = Convert.ToInt32(lbFreeSites.SelectedItem);
            if (data.Reserve(tag, spot))
            {
                statusStrip1.Text = "Succesfull reservation";
            }
            else
            {
                statusStrip1.Text = "Something went wrong";
            }

            if (data.GetSite(tag) != -1)
                lblSite.Text = "Site number: " + data.GetSite(tag).ToString();
            else
                lblSite.Visible = false;
            
        }

        

        private void Scan(object sender, TagEventArgs e)
        {
            tag = e.Tag;
            lblName.Text = "Name: " + data.GetName(e.Tag);
            lblMoney.Text = "Money: " + data.GetMoney(e.Tag).ToString();
            lblSite.Visible = true;
            if (data.GetSite(e.Tag) != -1)
                lblSite.Text = "Site number: " + data.GetSite(e.Tag).ToString();
            else
                lblSite.Visible = false;
        }

        private void lbFreeSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCost.Text = "Cost per night: " + Convert.ToString(data.GetPrice(Convert.ToInt32(lbFreeSites.SelectedItem)));
        }


    }
}
