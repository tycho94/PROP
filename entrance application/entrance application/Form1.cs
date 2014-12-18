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
        Admin rj;
        EnterClient current;
        Timer checkup = new Timer();



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
                current = new EnterClient("2800b39b49");
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
                rj = new Admin();
                if (rj.CheckPass(tbPass.Text) == true)
                {
                    current.ChangeStatus(1);
                }
                else
                    MessageBox.Show("Wrong password!");

            }

            catch
            {
                MessageBox.Show("Wait for RFID scan");
            }

            resetui();
        }


        private void Entering(object sender, TagEventArgs e)
        {

            if (current.Entering(e.Tag) == 1)
            {
                //db function
                tbStatus.BackColor = Color.LightGreen;
                tbStatus.Text = "Allowed";
                tbName.Text = current.Username;
            }
            if (current.Entering(e.Tag) == 2)
            {
                //db function
                tbStatus.BackColor = Color.Red;
                tbStatus.Text = "Entered";
                tbName.Text = current.Username;
                btnEnter.Enabled = false;
            }
            if (current.Entering(e.Tag) == 3)
            {
                tbStatus.BackColor = Color.Red;
                //db function
                tbStatus.Text = "Banned!";
                tbName.Text = current.Username;
                btnEnter.Enabled = false;
                btnBan.Enabled = false;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {

                current.ChangeStatus(2);
                System.Threading.Thread.Sleep(2000);
                resetui();
            }
            catch
            {
                MessageBox.Show("Wait for RFID scan");
            }
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            try
            {

                current.ChangeStatus(3);
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
            btnBan.Enabled = true;
            btnEnter.Enabled = true;
        }

    }
}
