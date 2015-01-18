using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Top_Up_app
{
    public partial class Form1 : Form
    {
        public int balance = 0;
        public int RFID =0;
        public int numberAdded = 0;

        DatabaseConecction data = new DatabaseConecction();

        List<String> list = new List<String>();

        public Form1()
        {
            InitializeComponent();
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

            balance = Convert.ToInt32(data.loadBalance(137782));
            label1.Text = "Current Credit:" + balance.ToString();
        }


         
        private void button1_Click(object sender, EventArgs e)
        {

            RFID = 137782;
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


    }
}
