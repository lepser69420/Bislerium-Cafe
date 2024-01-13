using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCoffee.Components.Data
{
    // Item Class - used to store coffee and addons data
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public float ItemPrice { get; set; }

        public Item()
        {

        }

        public Item(int id, string name, float price)
        {
            this.Id = id;
            this.ItemName = name;
            this.ItemPrice = price;
        }
    }
}
