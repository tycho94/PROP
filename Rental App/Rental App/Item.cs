using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_App
{
    class Item
    {
        //fields
        private string name;
        private double price;
        private int totalLeft = 0;
        private double deposit;
        private int ID = 0;
        private string image;

        //properties
        public string Name
        { get { return name; } }

        public double Price
        { get { return price; } }

        public int TotalLeft
        {
            get { return totalLeft; }
            set { totalLeft = value; }
        }

        public double Deposit 
        {
            get { return deposit; }
        }

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        public int iD
        {
            get{return ID;}
            set{ID=value;}
        }

        //constructor
        public Item(string name, double price, double deposit , string img,int totalLeft ,int id)
        {
            this.name = name;
            this.price = price;
            this.deposit = deposit;
            this.totalLeft = totalLeft;
            
            this.image = img;
            this.ID = id;
           
        }

        public string AsString()
        {
            string s = this.name + ", price: " + price + ", Deposit: "+deposit+", left in stock: " + totalLeft; 
            return s;
        }

        public void updateStock(int banyak, string op)
        {

            if (op == "plus")
            {
                totalLeft = totalLeft + banyak;
            }

            else if (op == "minus")
            {
                totalLeft = totalLeft - banyak;
            }
        }

    }
}
