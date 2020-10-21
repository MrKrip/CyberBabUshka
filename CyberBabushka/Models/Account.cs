using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberBabushka.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}