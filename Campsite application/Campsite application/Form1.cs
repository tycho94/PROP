using System;
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

        private void searchBtn_Click(object sender, EventArgs e)
        {

        }

        private void showBtn_Click(object sender, EventArgs e)
        {

        }

        private void reserveBtn_Click(object sender, EventArgs e)
        {

        }

        private void Scan(object sender, TagEventArgs e)
        {
            lblName.Text = "Name: " + data.GetName(e.Tag);
            lblMoney.Text = "Money: " + data.GetMoney(e.Tag).ToString();
            lblSite.Visible = true;
            if (data.GetSite(e.Tag) != -1)
                lblSite.Text = "Site number: " + data.GetSite(e.Tag).ToString();
            else
                lblSite.Visible = false;
        }

    }
}
