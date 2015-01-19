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
        //ExitClient current = new ExitClient("2800b39b49");
        DatabaseConnection data = new DatabaseConnection();

        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            moneylbl.Visible = false;

            try
            {
                Reader = new RFID();
                //Reader.Attach += new AttachEventHandler(ReaderAttached);
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
            if (data.GetStatus(e.Tag) == 1)
            {
                moneylbl.Text = "Money left on card: " + data.GetBalance(e.Tag).ToString();

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
                    data.leaving(e.Tag);
                }
            }
            else if (data.GetStatus(e.Tag) == 0)
            {
                label1.Visible = false;
                label2.Visible = false;
                moneylbl.Visible = false;
                label3.Text = "Something went wrong, please contact support.";
            }
        }
    }
}
