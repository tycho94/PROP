using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_App
{
    public partial class Form1 : Form
    {
        double totalCost = 0;
        private Items rent;
        double totalPrice = 0;
        
        object O;

        List<Item> bought = new List<Item>();
        Item product;
         
        public Form1()
        {
            InitializeComponent();
            rent = new Items("rent");
            CreateDummyData();
    
        }

        private void CreateDummyData() 
        {
            rent.AddItem("ipad", 40, 10, 100,"ipad", 21);
            rent.AddItem("go-pro", 30, 10, 80, "gopro", 12);
 
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

            O = Properties.Resources.ResourceManager.GetObject(product.Image); 
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

            O = Properties.Resources.ResourceManager.GetObject(product.Image);
            pictureBoxBIG.Image = (Image)O;
        }
    }
}
