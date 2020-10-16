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

        public Item()
        {

        }
        public Item(string name)
        {
            this.Name = name;
        }
    }
}
