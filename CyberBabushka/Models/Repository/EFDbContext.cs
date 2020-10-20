using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberBabushka.Models.Repository
{
    public class EFDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}