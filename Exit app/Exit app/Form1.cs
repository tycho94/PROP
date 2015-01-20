using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets.Events;
using Phidgets;

namespace Exit_app
{
    public partial class Form1 : Form
    {
        private RFID Reader;
        DatabaseConnection data;

        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            moneylbl.Visible = false;

            try
            {
                Reader = new RFID();
                Reader.open();
                Reader.waitForAttachment(3000);
                Reader.Antenna = true;
                Reader.LED = true;
                Reader.Tag += new TagEventHandler(Leaving);

            }
            catch (PhidgetException)
            {
                MessageBox.Show("RFID reader not found. \nExiting program.");
                Environment.Exit(1);
            }
        }


        public void Leaving(object sender, TagEventArgs e)
        {
            data = new DatabaseConnection();
            if (data.GetStatus(e.Tag) == 1)
            {
                data = new DatabaseConnection();
                moneylbl.Text = "Money left on card: " + data.GetBalance(e.Tag).ToString();
                data = new DatabaseConnection();
                if (data.GetRented(e.Tag) == true)
                {
                    label1.Visible = false;
                    label2.Visible = false;
                    moneylbl.Visible = false;
                    label3.Text = "Return your items before you can leave.";
                }
                else
                {
                    label1.Visible = true;
                    label2.Visible = true;
                    moneylbl.Visible = true;
                    label3.Text = "";
                    data = new DatabaseConnection();
                    data.leaving(e.Tag);
                }
            }
            else
            {
                data = new DatabaseConnection();
                if (data.GetStatus(e.Tag) == 0)
                {
                    label1.Visible = false;
                    label2.Visible = false;
                    moneylbl.Visible = false;
                    label3.Text = "Something went wrong, please contact support.";
                }
            }
        }
    }
}
