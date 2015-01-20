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

namespace Shop_application
{
    public partial class Shop : Form
    {


        // double cost = 0;
        //int productLeft = 0;
        double totalCost = 0;
        private Items shop;
        double totalPrice = 0;
        object O;
        public string tag = "";
        int shopID = 10;
        bool isReturn = false;
        double balance;

        RFID Reader;

        List<Item> bought = new List<Item>();
        Item product;

        DatabaseConnection data;


        public Shop()
        {
            InitializeComponent();

            Reader = new RFID();
            Reader.Tag += new TagEventHandler(rfid_Tag);
            Reader.open();
            Reader.waitForAttachment(3000);
            Reader.Antenna = true;
            Reader.LED = true;

            shop = new Items("shop");

            CreateDummyData();
        }

        public void CreateDummyData()
        {
            //shop.AddSnack("Hamburger", 2.70, 200);
            //shop.AddSnack("Nugget", 1.50, 100);
            //shop.AddSnack("Corn Dog",1 ,200,"corndog");
            //shop.AddSnack("Hot Dog", 2.5,200,"hotdog");
            //shop.AddSnack("Pizza", 6, 80,"pizza");
            //shop.AddSnack("Fries",1.5 ,200,"RI2226_1i4615french_fries");
            //shop.AddSnack("Durum", 3,200,"Kebab original");
            //shop.AddSnack("Taco", 3,200,"large_TwoTacos");
            //shop.AddSnack("Lumpia",2.5 ,200,"loempia");
            //shop.AddSnack("Nachos", 1.5,200,"NachosBeef");
            //shop.AddSnack("Kip Stukken", 2.5, 200, "20120112-popeyes-refried-chicken-6");
            //shop.AddSnack("Kibbeling", 3, 200, "kibbeling-2");
            //shop.AddSnack("Cola", 1, 200, "Coca-Cola-33cl-CAN");
            //shop.AddSnack("Fanta", 1, 200, "Fanta");
            //shop.AddSnack("Sprite", 1, 200, "Sprite_Lata350_regular");
            //shop.AddSnack("Cola-Zero", 1.2, 200, "cola_zero_01");
            //shop.AddSnack("Pepsi", 1, 200, "3023648-slide-1-pepsi-can");
            //shop.AddSnack("MTN Dew", 1, 200, "mountaindeweu_500_1");
            //shop.AddSnack("Bavaria", 1.95, 200, "Bavaria vles-2");
            //shop.AddSnack("Monster", 1.5, 200, "Monster-Energy-Drink-24-oz-Can");
            //shop.AddSnack("Spa", 0.8, 200, "spa reine 50cl-500x500");
            //shop.AddSnack("Jaeger", 15, 70, "Jagermeister_Bottle");
            //shop.AddSnack("Jack Daniels", 20, 50, "Jack D");
            //shop.AddSnack("Vodka", 17, 60, "Vodka");
            data = new DatabaseConnection();
            foreach (Item i in data.LoadItemInfo())
            {
                shop.AddSnack(i.Name, i.Price, i.TotalLeft, i.ID, i.Image);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime myDate = DateTime.Now;
            string dateNow = myDate.ToString("yyyy-MM-dd");
            DateTime Time = DateTime.Now;
            string time = Time.ToString("H:mm:ss");
            double banyak = Convert.ToDouble(numericUpDown1.Value);
            double harga;
            int loadedBalance = 0;
            if (boughtList.Items.Count > 0)
            {
                data = new DatabaseConnection();
                loadedBalance = Convert.ToInt32(data.loadBalance(tag));
                data = new DatabaseConnection();
                if (data.Insert(product.ID, shopID, tag, time, dateNow, banyak))
                {
                    data = new DatabaseConnection();
                    if (data.Stocks(product.TotalLeft, "-", Convert.ToInt32(banyak), product.ID) && data.Balance(loadedBalance, Convert.ToInt32(product.Price), tag))
                    {
                        harga = loadedBalance - totalCost;
                        MessageBox.Show("Kebeli");
                        data = new DatabaseConnection();
                        BalanceLabel.Text = "Current Balance: " + data.loadBalance(tag).ToString();

                    }
                }
            }
            else
            {
                MessageBox.Show("Order First.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LabelLoad("Hamburger");
        }

        private void nuggetPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Nugget");
        }

        private void CorndogPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Corn Dog");
        }

        private void HotdogPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Hotdog");
        }

        private void pizzaPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Pizza");
        }

        private void FriesPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("French Fries");
        }

        private void DurumPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Durum");
        }

        private void TacoPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Taco");
        }

        private void LoempiaPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Lumpia");
        }

        private void NachosPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Nachos");
        }

        private void ChickenPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Kip Stukken");
        }

        private void KibbelingPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Kibbeling");
        }


        private void ColaPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Coca Cola");
        }

        private void FantaPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Fanta");
        }

        private void SpritePctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Sprite");
        }

        private void ColaZeroPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Cola-Zero");
        }

        private void PepsiPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Pepsi");
        }

        private void MtnDewPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Mountain Dew");
        }

        private void BavariaPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Bavaria");
        }

        private void MonsterPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Monster");
        }

        private void SpaBlauwPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Spa Water");
        }

        private void JaegerMeisterPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Jaeger");
        }

        private void JackDPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Jack Daniels");
        }

        private void AbsoluteVodkaPctBox_Click(object sender, EventArgs e)
        {
            LabelLoad("Vodka");
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            int banyak = Convert.ToInt32(numericUpDown1.Value);
            if (numericUpDown1.Value > 0)
            {
                try
                {
                    totalCost = product.Price * banyak;

                    bought.Add(product);
                    product.updateStock(Convert.ToInt32(banyak), "kurang");

                    //foreach (Item x in bought)
                    //{
                    //    string nama;
                    //    int jumlah;
                    //    int totalHarga;


                    labelProduct.Text = "Product: " + product.TotalLeft.ToString();
                    boughtList.Items.Add(product.AsString() + ", order: " + banyak + ", total: " + totalCost);
                    totalPrice = totalPrice + totalCost;
                    //}



                    labelTotal.Text = "Total cost: " + totalPrice;
                    //boughtList.Items.Add(product.AsString()+", order: "+banyak+", total: "+totalCost);
                    //    boughtList.Items.Add("Product: " + pName + ", Harga:");
                }
                catch
                {
                    MessageBox.Show("Select an item");
                }
            }
            else
            {
                MessageBox.Show("Portion must not be 0");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            int selected;
            double selectedPrice;

            double banyak = Convert.ToDouble(numericUpDown1.Value);

            if (this.boughtList.SelectedIndex >= 0)
            {
                selected = this.boughtList.SelectedIndex;
                selectedPrice = Convert.ToDouble(bought[selected].Price);

                bought.RemoveAt(selected);
                boughtList.Items.RemoveAt(selected);

                totalPrice = totalPrice - selectedPrice * banyak;

                product.updateStock(Convert.ToInt32(banyak), "tambah");

                labelTotal.Text = "Total cost: " + totalPrice;
                labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            }



        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            product = shop.GetItems(textBox1.Text);

            if (textBox1 != null)
            {
                if (product != null)
                {
                    labelCost.Text = "Cost: " + product.Price.ToString();
                    labelProduct.Text = "Product: " + product.TotalLeft.ToString();

                    O = Properties.Resources.ResourceManager.GetObject(product.Image);
                    pictureBoxBIG.Image = (Image)O;
                    //Image = (Image)O; //Set the Imag
                }
                else
                {
                    MessageBox.Show("inputu.");
                }
            }

            else
            {
                MessageBox.Show("we are deeply sorry, we don't have that menu.");
            }

        }
        // RFID
        void rfid_Tag(object sender, TagEventArgs e)
        {
            if (!isReturn)
            {
                tag = e.Tag;
                data = new DatabaseConnection();
                balance = Convert.ToInt32(data.loadBalance(tag));
                BalanceLabel.Text = "Current Balance: " + balance;
            }
        }

        public void LabelLoad(string item)
        {
            product = shop.GetItems(item);
            labelCost.Text = "Cost: " + String.Format("{0:0.00}", product.Price);
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }
    }
}
