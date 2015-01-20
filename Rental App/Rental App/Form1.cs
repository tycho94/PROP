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
        double balance = 0;
        int shopID = 0;
        double quantity;

        static bool isReturn = false;

        public static string RFID = "";
        RFID reader;


        object O;

        DatabaseConnection data = new DatabaseConnection();
        List<Item> borrowed = new List<Item>();
        Item product;

        public Form1()
        {
            InitializeComponent();

            reader = new RFID();
            reader.Tag += new TagEventHandler(rfid_Tag);
            reader.open();
            reader.waitForAttachment(3000);
            reader.Antenna = true;
            reader.LED = true;

            rent = new Items("rent");
            CreateDummyData();
            //balance = Convert.ToInt32(data.loadBalance(RFID));
            shopID = 11;


        }

        private void CreateDummyData()
        {
            //rent.AddItem("ipad", , 10, 100,"ipad", 21);
            //rent.AddItem("go-pro", 30, 10, 80, "gopro", 12);

            foreach (Item i in data.LoadItemInfo())
            {
                rent.AddItem(i.Name, i.Price, i.Deposit, i.Image, i.TotalLeft, i.iD);
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            isReturn = Return.isReturn;
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            try
            {
                quantity = Convert.ToDouble(numericUpDown1.Value);
                if (numericUpDown1.Value > 0)
                {
                    totalCost = (product.Deposit + product.Price) * quantity;

                    borrowed.Add(product);
                    product.updateStock(Convert.ToInt32(quantity), "minus");


                    labelProduct.Text = "Product: " + product.TotalLeft.ToString();
                    RentList.Items.Add(product.AsString() + ", order: " + quantity + ", total: " + totalCost);
                    totalPrice = totalPrice + totalCost;

                    labelTotal.Text = "Total cost: " + totalPrice;
                }

                else
                {
                    MessageBox.Show("Quantity must be over 0");
                }
            }
            catch
            {
                MessageBox.Show("Select an item");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            RentList.Items.Clear();
            totalPrice = 0;
            totalCost = 0;
            labelTotal.Text = "Total cost: ";
            labelProduct.Text = "Product: ";
        }



        private void button2_Click(object sender, EventArgs e)
        {
            product = rent.GetItems(textBox1.Text);
            if (textBox1 != null)
            {
                if (product != null)
                {
                    labelCost.Text = "Cost: " + product.Price.ToString();
                    labelDeposit.Text = "Deposit: " + product.Deposit.ToString();
                    labelProduct.Text = "Product: " + product.TotalLeft.ToString();
                    labelID.Text = "ID Number: " + product.iD.ToString();

                    O = Properties.Resources.ResourceManager.GetObject(product.Image); //Return an object from the image chan1.png in the project
                    pictureBoxBIG.Image = (Image)O;
                }
                else
                {
                    MessageBox.Show("unavailable");
                }
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            DateTime myDate = DateTime.Now;
            string dateNow = myDate.ToString("yyyy-MM-dd");
            DateTime returnDate = DateTime.Now.AddDays(1);
            string dateReturn = returnDate.ToString("yyyy-MM-dd");

            quantity = Convert.ToDouble(numericUpDown1.Value);

            if (RFID != "")
            {
                if (balance > product.Price * quantity)
                {

                    int loadedBalance = Convert.ToInt32(data.loadBalance(RFID));

                    if (data.insert(product.iD, shopID, RFID, dateNow, dateReturn, Convert.ToInt32(product.Deposit)))
                    {
                        if (data.Stocks(product.TotalLeft + Convert.ToInt32(quantity), Convert.ToInt32(quantity), product.iD))
                        {
                            data.Balance(loadedBalance, Convert.ToInt32(totalPrice), RFID);
                            balance = data.loadBalance(RFID);
                            BalanceLabel.Text = "Current Balance:" + balance.ToString();
                            MessageBox.Show("rented");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("you don't have enough credits");
                }
            }
            else
            {
                MessageBox.Show("please present your RFID first");

            }
        }

        // RFID
        void rfid_Tag(object sender, TagEventArgs e)
        {
            RFID = e.Tag;
            balance = data.loadBalance(RFID);
            BalanceLabel.Text = "Current Balance:" + balance.ToString();


        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            isReturn = true;
            Return form2 = new Return();
            form2.ShowDialog();
        }

        public void LabelLoad(string item)
        {
            product = rent.GetItems(item);
            labelCost.Text = "Cost: " + String.Format("{0:0.00}", product.Price);
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();
            labelDeposit.Text = "Deposit: " + product.Deposit.ToString();
            labelID.Text = "ID Number: " + product.iD.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void pictureBoxIpad_Click(object sender, EventArgs e)
        {
            LabelLoad("ipad");
        }
        private void pictureBoxGoPro_Click(object sender, EventArgs e)
        {
            LabelLoad("go-pro");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox30_Click(object sender, EventArgs e)
        {
            LabelLoad("Sleeping bags");
        }

        private void PowerBrickPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Power Brick");
        }

        private void IPhoneChargerPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("IPhoneCharger");
        }

        private void AndroidChargerPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Android Charger");
        }

        private void LaptopPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Laptop");
        }

        private void FlashlightpctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Flash Light");
        }

        private void TentPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Tent");
        }
    }
}
