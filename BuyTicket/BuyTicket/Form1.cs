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

namespace BuyTicket
{
    public partial class Form1 : Form
    {
        DatabaseConnection data;
        private RFID Reader;
        string tag;
        bool a;
        public Form1()
        {
            InitializeComponent();
            statusStrip1.SizingGrip = false;
            Reader = new RFID();
            Reader.Tag += new TagEventHandler(NewTag);
            Reader.open();
            Reader.waitForAttachment(3000);
            Reader.Antenna = true;
            Reader.LED = true;
        }

        private void NewTag(object sender, TagEventArgs e)
        {
            tag = e.Tag;
            a = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (a == true)
            {
                data = new DatabaseConnection();
                if (data.AddVisitor(tbFName.Text, tbLName.Text, tbMail.Text, DateTime.Parse(tbDOB.Text), Convert.ToInt32(tbPhone.Text), tbAddress.Text, tbCity.Text, tbCountry.Text, tbPostal.Text, Convert.ToInt32(tbAccount.Text), tag))
                    Status.Text = "Succesfully added person";
                else
                    Status.Text = "Error adding person";
                a = false;
            }
            else
            {
                MessageBox.Show("Scan RFID TAG first");
            }
        }
    }
}
