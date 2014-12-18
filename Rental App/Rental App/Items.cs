using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_App
{
    class Items
    {
        private string name;
        private List<Item> itemList;

        //public List<Item> Itemlist { get { return itemList; } }

        public Items(string nm)
        {
            this.name = nm;
            itemList = new List<Item>();
        }


        public Item GetItems(string nm)
        {
            int i = 0;
            while (i < itemList.Count)
            {
                if (itemList[i].Name == nm)
                    return itemList[i];
                else i++;

            }
            return null;
        }

        public bool AddItem(string nm, double pr, double dp, int Left, string img, int id)
        {
            if (GetItems(nm) == null)
            {
                this.itemList.Add(new Item(nm, pr, dp, Left, img, id));
                return true;

            }
            else return false;
        }

        
    }
}
