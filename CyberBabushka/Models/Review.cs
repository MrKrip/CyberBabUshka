using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberBabushka.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public Product Product { get; set; }
        public Account Account { get; set; }
        public string Info { get; set; }
    }
}