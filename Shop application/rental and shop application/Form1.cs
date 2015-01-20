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
        double totalCost = 0;
        private Items shop;
        double totalPrice = 0;
        string tag = null;
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

        private void btn_Buy(object sender, EventArgs e)
        {
            string dateNow = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("H:mm:ss");
            int count = Convert.ToInt32(numericUpDown1.Value);
            double loadedBalance;
            if (boughtList.Items.Count > 0)
            {

                if (tag == null)
                {
                    MessageBox.Show("Scan RFID first.");
                }
                else
                {
                    data = new DatabaseConnection();
                    loadedBalance = data.loadBalance(tag);
                    data = new DatabaseConnection();
                    if (loadedBalance < product.Price*count)
                    {
                        MessageBox.Show("Need more money");
                    }
                    else
                    {
                        if (data.Insert(product.ID, 10, tag, time, dateNow, count))
                        {
                            data = new DatabaseConnection();
                            if (data.UpdateStock(product.TotalLeft, count, product.ID) && data.SetBalance(loadedBalance, product.Price, count, tag))
                            {
                                MessageBox.Show("Bought.");
                                data = new DatabaseConnection();
                                BalanceLabel.Text = "Current Balance: " + String.Format("{0:0.00}", data.loadBalance(tag));
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Order First.");
            }
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(numericUpDown1.Value);
            if (numericUpDown1.Value > 0)
            {
                try
                {
                    totalCost = product.Price * count;

                    bought.Add(product);
                    product.updateStock(Convert.ToInt32(count), "minus");

                    labelProduct.Text = "Product: " + product.TotalLeft.ToString();
                    boughtList.Items.Add(product.AsString() + ", order: " + count + ", price: " + String.Format("{0:0.00}", totalCost));
                    totalPrice = totalPrice + totalCost;
                    labelTotal.Text = "Total cost: " + String.Format("{0:0.00}", totalPrice);

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
            boughtList.Items.Clear();
            bought.Clear();

            int count = Convert.ToInt32(numericUpDown1.Value);

            product.updateStock(Convert.ToInt32(count), "add");
            totalCost = 0;
            totalPrice = 0;
            labelTotal.Text = "Total cost: ";
            labelProduct.Text = "Product: ";

        }

        private void btn_Search(object sender, EventArgs e)
        {
            product = shop.GetItems(tbSearch.Text);

            if (tbSearch.Text != "")
            {
                if (product != null)
                {
                    LabelLoad(tbSearch.Text);
                }
                else
                {
                    MessageBox.Show("We don't serve this.");
                }
            }
            else
            {
                MessageBox.Show("Fill in a name.");
            }

        }
        // RFID
        void rfid_Tag(object sender, TagEventArgs e)
        {
            tag = e.Tag;
            data = new DatabaseConnection();
            BalanceLabel.Text = "Current Balance: " + String.Format("{0:0.00}", data.loadBalance(tag));
        }

        public void LabelLoad(string item)
        {
            product = shop.GetItems(item);
            labelCost.Text = "Cost: " + String.Format("{0:0.00}", product.Price);
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            object O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
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
            pictureBoxBIG.ImageLocation = "C:/Users/Tycho/Documents/School/Fontys/ProP/PROP/Shop application/rental and shop application/Resources/Kebab Original.png";
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
    }
}
