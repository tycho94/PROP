using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_application
{
    class Items
    {
        private string name;
        private List<Item> itemList;

        public Items(string nm) 
        {
            this.name = nm;
            itemList = new List<Item>();
        }


        public Item GetItems(string nm) 
        {
            for (int i = 0; i < itemList.Count(); i++)
            {
                if(itemList[i].Name == nm)
                {
                    return itemList[i];
                }
            }
            return null;

        }

        public bool AddSnack(string nm, double pr, int Left, string ID, string img) 
        {
            if (GetItems(nm) == null)
            {
                this.itemList.Add(new Item(nm, pr, Left, ID, img));
                return true;

            }
            else return false;
        }
    }
}
