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
            
            try
            {
                Reader = new RFID();
                //Reader.Attach += new AttachEventHandler(ReaderAttached);
                Reader.Tag += new TagEventHandler(Leaving);
                Reader.open();
                Reader.waitForAttachment(3000);
                Reader.Antenna = true; 
                Reader.LED = true;
            }
            catch (PhidgetException)
            {
                MessageBox.Show("RFID reader not found. \nExiting program.");
                //Environment.Exit(1);
            }
        }

        public void Leaving(object sender, TagEventArgs e)
        {
            moneylbl.Text = "Money left on card: ";
        }
    }
}
