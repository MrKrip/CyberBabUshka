using CyberBabushka.Models;
using CyberBabushka.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyberBabushka.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected IEnumerable<Product> GetProducts()
        {
            return repository.Products;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}