using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CyberBabushka.Models.Repository
{
    public class EFDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public System.Data.Entity.DbSet<CyberBabushka.Models.OrderLine> OrderLines { get; set; }
    }
}