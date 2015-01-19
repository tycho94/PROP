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

namespace entrance_application
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
                Reader.Tag += new TagEventHandler(Entering);
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
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {

                if (data.GetPass(tag, tbPass.Text))
                {
                    data.ChangeStatus(tag, 0);

                    resetui();
                }
                else
                    MessageBox.Show("Wrong pass");


            }
            catch
            {
                MessageBox.Show("Wait for RFID scan");
            }
        }


        private void Entering(object sender, TagEventArgs e)
        {
            try
            {
                tag = e.Tag;
                if (data.GetStatus(e.Tag) == 0)
                {
                    //db function
                    tbStatus.BackColor = Color.LightGreen;
                    tbStatus.Text = "Allowed";
                    tbName.Text = data.GetName(e.Tag);
                    btnEnter.Enabled = true;
                }
                if (data.GetStatus(e.Tag) == 1)
                {
                    //db function
                    tbStatus.BackColor = Color.Red;
                    tbStatus.Text = "Entered";
                    tbName.Text = data.GetName(e.Tag);
                    btnEnter.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Scanning failed");
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                data.ChangeStatus(tag, 1);
                System.Threading.Thread.Sleep(1000);
                resetui();
            }
            catch
            {
                MessageBox.Show("Wait for RFID scan");
            }
        }

        private void resetui()
        {
            tbName.Text = "";
            tbStatus.Text = "";
            tbStatus.BackColor = Color.Empty;
            btnEnter.Enabled = true;

        }

    }
}
