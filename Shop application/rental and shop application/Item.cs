using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_application
{
    class Item
    {
        //fields
        private string name;
        private double price;
        private int totalLeft=0;
        
        private string id;
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

        public string ID 
        {
            get { return id; }
            set { id = value; }
        }

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        //constructor
        public Item(string name, double price, int totalLeft, string id, string image) 
        {
            this.name = name;
            this.price = price;
            this.totalLeft = totalLeft;
            this.id = id;
            this.image = image;
        }

        public string AsString() 
        {
            string s = this.name + ", price: " + price + ", left in stock: " + totalLeft;
            return s;
        }

        public void updateStock(int banyak, string op)
        {

            if (op == "tambah")
            {
                totalLeft = totalLeft + banyak;
            }

            else if (op == "kurang")
            {
                totalLeft = totalLeft - banyak;
            }
        }

    }
}
