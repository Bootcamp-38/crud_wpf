using crud_wpf.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_wpf.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("crud_wpf") { }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Login> Logins { get; set; }

    }
}
