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


namespace Rental_App
{
    public partial class Form1 : Form
    {
        double totalCost = 0;
        private Items rent;
        double totalPrice = 0;
        int balance = 0;
        int shopID = 0;

        bool isReturn = false;

        public string RFID = "";
        RFID reader;


        object O;

        DatabaseConnection data = new DatabaseConnection();
        List<Item> bought = new List<Item>();
        Item product;
         
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

            rent = new Items("rent");
            CreateDummyData();
            //balance = Convert.ToInt32(data.loadBalance(RFID));
            shopID = 10;
            
    
        }

        private void CreateDummyData() 
        {
            //rent.AddItem("ipad", , 10, 100,"ipad", 21);
            //rent.AddItem("go-pro", 30, 10, 80, "gopro", 12);

            foreach (Item i in data.LoadItemInfo())
            {
                rent.AddItem(i.Name, i.Price, i.Deposit, i.TotalLeft, i.iD);
            }
 
        }

        private void RentList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            double banyak = Convert.ToDouble(numericUpDown1.Value);
            totalCost =  (product.Deposit + product.Price) * banyak;

            bought.Add(product);
            product.updateStock(Convert.ToInt32(banyak), "kurang");

     
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();
            RentList.Items.Add(product.AsString() + ", order: " + banyak + ", total: " + totalCost);
            totalPrice = totalPrice + totalCost;

            RentList.Items.Clear();
            labelTotal.Text = "Total cost: " + totalPrice;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

            int selected;
            double selectedPrice;

            double banyak = Convert.ToDouble(numericUpDown1.Value);

            if (this.RentList.SelectedIndex >= 0)
            {
                selected = this.RentList.SelectedIndex;
                selectedPrice = Convert.ToDouble(bought[selected].Price);

                bought.RemoveAt(selected);
                RentList.Items.RemoveAt(selected);

                totalPrice = totalPrice - selectedPrice;

                product.updateStock(Convert.ToInt32(banyak), "tambah");

                labelTotal.Text = "Total cost: " + totalPrice;
                labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            }

        }

        private void pictureBoxIpad_Click(object sender, EventArgs e)
        {
            product = rent.GetItems("ipad");

            labelCost.Text = "Cost: " + product.Price.ToString();
            labelDeposit.Text = "Deposit: " + product.Deposit.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();
            labelID.Text = "ID Number: " + product.iD.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Name); 
            pictureBoxBIG.Image = (Image)O;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            product = rent.GetItems(textBox1.Text);

            labelCost.Text = "Cost: " + product.Price.ToString();
            labelDeposit.Text = "Deposit: " + product.Deposit.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();
            labelID.Text = "ID Number: " + product.iD.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image); //Return an object from the image chan1.png in the project
            pictureBoxBIG.Image = (Image)O;
        }

        private void pictureBoxGoPro_Click(object sender, EventArgs e)
        {
            product = rent.GetItems("go-pro");

            labelCost.Text = "Cost: " + product.Price.ToString();
            labelDeposit.Text = "Deposit: " + product.Deposit.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();
            labelID.Text = "ID Number: " + product.iD.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Name);
            pictureBoxBIG.Image = (Image)O;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime myDate = DateTime.Now;
            string dateNow = myDate.ToString("yyyy-MM-dd");
            DateTime returnDate = DateTime.Now.AddDays(1);
            string dateReturn = returnDate.ToString("yyyy-MM-dd");

            double banyak = Convert.ToDouble(numericUpDown1.Value);
            double harga;
            int loadedBalance = Convert.ToInt32(data.loadBalance(RFID));
            if (data.insert(product.iD, shopID, RFID, dateNow, dateReturn, Convert.ToInt32(product.Deposit)))
            {
                if (data.Stocks(product.TotalLeft + Convert.ToInt32(banyak), "-", Convert.ToInt32(banyak), product.iD) && data.Balance(loadedBalance, "-", Convert.ToInt32(totalPrice), RFID))
                {
                    harga = loadedBalance - totalPrice;
                    //data.loadBalance(Convert.ToInt32(RFID));
                    MessageBox.Show(harga.ToString());
                }
            }
            
        }

        // RFID
        void rfid_Tag(object sender, TagEventArgs e)
        {
            if (!isReturn)
            {
                RFID = e.Tag;
                reader.LED = true;       // light on
                balance = Convert.ToInt32(data.loadBalance(RFID));
                MessageBox.Show("Current Credit:" + balance.ToString());
            }
        }

        void rfid_TagLost(object sender, TagEventArgs e)
        {
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

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            isReturn = true;
            Return form2 = new Return();
            this.Hide();
            form2.Show();
            this.Close();
            
        }
    }
}
