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

namespace rental_and_shop_application
{
    public partial class Shop : Form
    {
        

       // double cost = 0;
        //int productLeft = 0;
        double totalCost = 0;
        private Items shop;
        double totalPrice = 0;
        int Left = 0;
        object O;
        public string RFID = "";
        int shopID = 10;
        bool isReturn = false;
        double balance;
        
        RFID reader;

        List<Item> bought = new List<Item>();
        Item product;

        DatabaseConnection data = new DatabaseConnection();


        public Shop()
        {
            InitializeComponent();

            reader = new RFID();
            reader.Attach += new AttachEventHandler(rfid_Attach);
            reader.Detach += new DetachEventHandler(rfid_Detach);
            reader.RFIDTag += new TagEventHandler(rfid_Tag);
            reader.RFIDTagLost += new TagEventHandler(rfid_TagLost);
            reader.Antenna = true;
            reader.open();
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

            foreach (Item i in data.LoadItemInfo())
            {
                shop.AddSnack(i.Name, i.Price, i.TotalLeft, i.ID,i.Image);
            }

 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Shop_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         //  this.cost= 3.5;
           //labelCost.Text = "Cost: "+this.cost.ToString();
           //this.productLeft= 200;
           product = shop.GetItems("Hamburger");

           labelCost.Text = "Cost: " + product.Price.ToString();
           labelProduct.Text ="Product: "+product.TotalLeft.ToString();
           //MessageBox.Show(i.AsString());
           O = Properties.Resources.ResourceManager.GetObject(product.Image);
           pictureBoxBIG.Image = (Image)O;

           
           
 
           
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            if (boughtList.Items.Count>0)
            {
                 loadedBalance = Convert.ToInt32(data.loadBalance(RFID));
                if (data.Insert(product.ID, shopID, RFID, time, dateNow, banyak))
                {
                    if (data.Stocks(product.TotalLeft, "-", Convert.ToInt32(banyak), product.ID) && data.Balance(loadedBalance, Convert.ToInt32(product.Price), RFID))
                    {
                        harga = loadedBalance - totalCost;
                        MessageBox.Show("Kebeli");

                        BalanceLabel.Text = "Current Balance: " + data.loadBalance(RFID).ToString();

                    }
                }
            }
            else 
            {
                MessageBox.Show("Order First.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void nuggetPctBox_Click(object sender, EventArgs e)
        {
            //this.cost = 1.5;
            //labelCost.Text = "Cost: " + this.cost.ToString() ;
            //this.productLeft = 200;
            product = shop.GetItems("Nugget");

            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void CorndogPctBox_Click(object sender, EventArgs e)
        {
            //this.cost = 1;
            //labelCost.Text = "Cost: " + this.cost.ToString() ;
            //this.productLeft = 200;
            product = shop.GetItems("Corn Dog");

            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void HotdogPctBox_Click(object sender, EventArgs e)
        {
            //this.cost = 2.5;
            //labelCost.Text = "Cost: " + this.cost.ToString() ;
            //this.productLeft = 200;
            product = shop.GetItems("Hotdog");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void pizzaPctBox_Click(object sender, EventArgs e)
        {
            //this.cost = 6;
            //labelCost.Text = "Cost: " + this.cost.ToString() ;
            //this.productLeft = 200;
            product = shop.GetItems("Pizza");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void FriesPctBox_Click(object sender, EventArgs e)
        {
            //this.cost = 1.5;
            //labelCost.Text = "Cost: " + this.cost.ToString()  ;
            //this.productLeft = 200;
            product = shop.GetItems("French Fries");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void DurumPctBox_Click(object sender, EventArgs e)
        {
            //this.cost = 3;
            //labelCost.Text = "Cost: " + this.cost.ToString() ;
            //this.productLeft = 200;
            product = shop.GetItems("Durum");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void TacoPctBox_Click(object sender, EventArgs e)
        {
            //this.cost = 3;
            //labelCost.Text = "Cost: " + this.cost.ToString() ;
            //this.productLeft = 200;
            product = shop.GetItems("Taco");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void LoempiaPctBox_Click(object sender, EventArgs e)
        {
            //this.cost = 2.5;
            //labelCost.Text = "Cost: " + this.cost.ToString() ;
            //this.productLeft = 200;
            product = shop.GetItems("Lumpia");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void NachosPctBox_Click(object sender, EventArgs e)
        {
            //this.cost = 1.5;
            //labelCost.Text = "Cost: " + this.cost.ToString() ;
            //this.productLeft = 200;
            product = shop.GetItems("Nachos");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
            
        }

        private void ChickenPctBox_Click(object sender, EventArgs e)
        {
            //this.cost = 2.5;
            //labelCost.Text = "Cost: " + this.cost.ToString() ;
            //this.productLeft = 200;
            product = shop.GetItems("Kip Stukken");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
            
        }

        private void KibbelingPctBox_Click(object sender, EventArgs e)
        {
            //this.cost = 3;
            //labelCost.Text = "Cost: " + this.cost.ToString() ;
            //this.productLeft = 200;
            product = shop.GetItems("Kibbeling");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
            
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            double banyak = Convert.ToDouble(numericUpDown1.Value);
            if (numericUpDown1.Value > 0)
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

                totalPrice = totalPrice - selectedPrice*banyak;
               
                product.updateStock(Convert.ToInt32(banyak), "tambah");

                labelTotal.Text = "Total cost: " + totalPrice;
                labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            }

            

        }

        private void ColaPctBox_Click(object sender, EventArgs e)
        {
            product = shop.GetItems("Coca Cola");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void FantaPctBox_Click(object sender, EventArgs e)
        {
            product = shop.GetItems("Fanta");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void SpritePctBox_Click(object sender, EventArgs e)
        {
            product = shop.GetItems("Sprite");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void ColaZeroPctBox_Click(object sender, EventArgs e)
        {
            product = shop.GetItems("Cola-Zero");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void PepsiPctBox_Click(object sender, EventArgs e)
        {
            product = shop.GetItems("Pepsi");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void MtnDewPctBox_Click(object sender, EventArgs e)
        {
            product = shop.GetItems("Mountain Dew");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void BavariaPctBox_Click(object sender, EventArgs e)
        {
            product = shop.GetItems("Bavaria");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void MonsterPctBox_Click(object sender, EventArgs e)
        {
            product = shop.GetItems("Monster");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image); 
            pictureBoxBIG.Image = (Image)O;
        }

        private void SpaBlauwPctBox_Click(object sender, EventArgs e)
        {
            product = shop.GetItems("Spa Water");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void JaegerMeisterPctBox_Click(object sender, EventArgs e)
        {
            product = shop.GetItems("Jaeger");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void JackDPctBox_Click(object sender, EventArgs e)
        {
            product = shop.GetItems("Jack Daniels");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void AbsoluteVodkaPctBox_Click(object sender, EventArgs e)
        {
            product = shop.GetItems("Vodka");
            labelCost.Text = "Cost: " + product.Price.ToString();
            labelProduct.Text = "Product: " + product.TotalLeft.ToString();

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            product = shop.GetItems(textBox1.Text);

            if (textBox1 != null )
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
                RFID = e.Tag;
                reader.LED = true;       // light on
                balance = Convert.ToInt32(data.loadBalance(RFID));
                BalanceLabel.Text = "Current Balance: " + balance;
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
    }
}
