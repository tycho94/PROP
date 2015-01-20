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
        DatabaseConnection data;
        string tag;
        int spot;
        string ftag;
        string stag;
        bool a = false;
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
            data = new DatabaseConnection();
            lbFreeSites.DataSource = data.ListSites();
        }


        private void reserveBtn_Click(object sender, EventArgs e)
        {
            data = new DatabaseConnection();
            spot = Convert.ToInt32(lbFreeSites.SelectedItem);
            if (data.Reserve(tag, spot))
            {
                lblStatus.Text = "Succesfull reservation";
                lblSite.Text = "Site number: " + spot.ToString();
                data = new DatabaseConnection();
                lbFreeSites.DataSource = data.ListSites();
            }
            else
            {
                lblStatus.Text = "Something went wrong";
            }
        }



        private void Scan(object sender, TagEventArgs e)
        {
            tag = e.Tag;
            data = new DatabaseConnection();
            lblName.Text = "Name: " + data.GetName(e.Tag);
            data = new DatabaseConnection();
            lblMoney.Text = "Money: " + data.GetMoney(e.Tag).ToString();
            lblSite.Visible = true;
            data = new DatabaseConnection();
            if (data.GetSite(e.Tag) != -1)
            {
                data = new DatabaseConnection();
                lblSite.Text = "Site number: " + data.GetSite(e.Tag).ToString();
                data = new DatabaseConnection();
                lblFirst.Text = "Name: " + data.GetName(e.Tag).ToString();
                panelcampspot.Visible = true;
            }
            else
            {
                lblSite.Visible = false;
                if (a == true)
                {
                    data = new DatabaseConnection();
                    lblSecond.Text = "Name: " + data.GetName(e.Tag).ToString();
                }
                else
                    panelcampspot.Visible = false;
            }

        }

        private void lbFreeSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            data = new DatabaseConnection();
            lblCost.Text = "Cost per night: " + Convert.ToString(data.GetPrice(Convert.ToInt32(lbFreeSites.SelectedItem)));
            campsitenr(Convert.ToInt32(lbFreeSites.SelectedItem));
        }



        private void campsitenr(int nr)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = false;
            lbl9.Visible = false;
            lbl10.Visible = false;
            lbl1.Visible = false;
            if (nr == 1)
                lbl1.Visible = true;
            if (nr == 2)
                lbl2.Visible = true;
            if (nr == 3)
                lbl3.Visible = true;
            if (nr == 4)
                lbl4.Visible = true;
            if (nr == 5)
                lbl5.Visible = true;
            if (nr == 6)
                lbl6.Visible = true;
            if (nr == 7)
                lbl7.Visible = true;
            if (nr == 8)
                lbl8.Visible = true;
            if (nr == 9)
                lbl9.Visible = true;
            if (nr == 10)
                lbl10.Visible = true;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            a = true;
            ftag = tag;
            btnContinue.Visible = false;
            btnAddDelete.Visible = true;
        }

        private void btnAddDelete_Click(object sender, EventArgs e)
        {
            a = false;
            stag = tag;
            btnContinue.Visible = true;
            btnAddDelete.Visible = false;
            data = new DatabaseConnection();
            if (data.SetSite(ftag, stag))
                lblStatus.Text = "Succesfully added to campspot";
            else
                lblStatus.Text = "Something went wrong";
            lblFirst.Text = "Name: ";
            lblSecond.Text = "Name: ";
        }
    }
}
