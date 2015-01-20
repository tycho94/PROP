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
        double price;
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
                rent.AddItem(i.Name, i.Price, i.Deposit, i.Image, i.TotalLeft, i.iD);
            }
 
        }

        private void RentList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isReturn = Return.isReturn;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void orderBtn_Click(object sender, EventArgs e)
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {

            int selected;
            double selectedPrice;

            double quantity = Convert.ToDouble(numericUpDown1.Value);

            if (this.RentList.SelectedIndex >= 0)
            {
                selected = this.RentList.SelectedIndex;
                selectedPrice = Convert.ToDouble(borrowed[selected].Price);

                borrowed.RemoveAt(selected);
                RentList.Items.RemoveAt(selected);

                totalPrice = totalPrice - selectedPrice*quantity;

                product.updateStock(Convert.ToInt32(quantity), "plus");

                labelTotal.Text = "Total cost: " + totalPrice;
                labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            }

        }

        private void pictureBoxIpad_Click(object sender, EventArgs e)
        {

            LabelLoad("ipad");
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
                    MessageBox.Show("we are deeply sorry, we don't have it");
                }
            }
        }

        private void pictureBoxGoPro_Click(object sender, EventArgs e)
        {
            LabelLoad("go-pro");

          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime myDate = DateTime.Now;
            string dateNow = myDate.ToString("yyyy-MM-dd");
            DateTime returnDate = DateTime.Now.AddDays(1);
            string dateReturn = returnDate.ToString("yyyy-MM-dd");

             quantity = Convert.ToDouble(numericUpDown1.Value);

             if (RFID == "")
             {
                 if (balance > 0)
                 {

                     int loadedBalance = Convert.ToInt32(data.loadBalance(RFID));

                     if (data.insert(product.iD, shopID, RFID, dateNow, dateReturn, Convert.ToInt32(product.Deposit)))
                     {
                         if (data.Stocks(product.TotalLeft + Convert.ToInt32(quantity), "-", Convert.ToInt32(quantity), product.iD) && data.Balance(loadedBalance, "-", Convert.ToInt32(totalPrice), RFID))
                         {
                             balance = loadedBalance - totalPrice;
                             //data.loadBalance(Convert.ToInt32(RFID));
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
            //if (!isReturn)
            //{
                RFID = e.Tag;
                reader.LED = true;       // light on
                balance = Convert.ToInt32(data.loadBalance(RFID));
                BalanceLabel.Text = "Current Balance:" + balance.ToString();
//}
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
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            isReturn = true;
            //Return form2 = new Return();

            //this.Hide();
            //form2.ShowDialog();
            //form2.Activate();
            //this.Close();
            //System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            //t.Start();
            //this.Close();

            this.Hide();
            Return form2 = new Return();
            form2.ShowDialog();
        }

        //public static void ThreadProc()
        //{
        //    Return f;
        //    Application.Run(new Return());
        //}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TentPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Tent");
        }
    }
}
