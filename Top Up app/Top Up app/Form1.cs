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


namespace Top_Up_app
{
    public partial class Form1 : Form
    {
        public int balance = 0;
        public string RFID = "";
        public int numberAdded = 0;
        RFID reader;


        DatabaseConecction data = new DatabaseConecction();

        List<String> list = new List<String>();

        public Form1()
        {
            InitializeComponent();

            reader = new RFID();
            reader.Attach += new AttachEventHandler(rfid_Attach);
            reader.Detach += new DetachEventHandler(rfid_Detach);
            reader.RFIDTag += new TagEventHandler(rfid_Tag);
            reader.RFIDTagLost += new TagEventHandler(rfid_TagLost);
            reader.Antenna = true;
            reader.open();

            ChargeDropDownList.Items.Add("5");
            ChargeDropDownList.Items.Add("10");
            ChargeDropDownList.Items.Add("15");
            ChargeDropDownList.Items.Add("20");
            ChargeDropDownList.Items.Add("25");
            ChargeDropDownList.Items.Add("30");
            ChargeDropDownList.Items.Add("35");
            ChargeDropDownList.Items.Add("40");
            ChargeDropDownList.Items.Add("45");
            ChargeDropDownList.Items.Add("50");

            balance = Convert.ToInt32(data.loadBalance(RFID));
            label1.Text = "Current Credit:" + balance.ToString();
        }


         
        private void button1_Click(object sender, EventArgs e)
        {

            if(data.adding(balance,numberAdded,RFID))
            {
            balance = balance + numberAdded;

            MessageBox.Show("your balance is now :"+ Convert.ToString(balance));
            }
            label1.Text = "Current Credit:" + balance.ToString();
        }

        private void ChargeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            numberAdded = Convert.ToInt32(ChargeDropDownList.SelectedItem.ToString());
        }

        // RFID
        void rfid_Tag(object sender, TagEventArgs e)
        {
            RFID = e.Tag;
            reader.LED = true;       // light on
        }

        void rfid_TagLost(object sender, TagEventArgs e)
        {
            RFID = "";
            reader.LED = false;      // light off
        }

        void rfid_Detach(object sender, DetachEventArgs e)
        {
            //lblAttached.Text = "Not Attached";
        }

        void rfid_Attach(object sender, AttachEventArgs e)
        {
            Phidgets.RFID phid = (Phidgets.RFID)sender;
            //lblAttached.Text = "Attached: " + phid.Name;

        }


    }
}
