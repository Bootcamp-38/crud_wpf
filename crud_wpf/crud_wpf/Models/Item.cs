using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_wpf.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Supplier Supplier { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }

        public Item()
        {

        }
        public Item(string name, Supplier supplier, int stok, int price)
        {
            this.Name = name;
            this.Supplier = supplier;
            this.Stock = stok;
            this.Price = price;
            
        }
    }
}
