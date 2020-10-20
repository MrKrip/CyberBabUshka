﻿using CyberBabushka.Models;
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
        private int pageSize = 4;
        protected int CurrentPage
        {
            get
            {
                int page;
                page = int.TryParse(Request.QueryString["page"], out page) ? page : 1;
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((decimal)repository.Products.Count() / pageSize);
            }
        }

        protected IEnumerable<Product> GetProducts()
        {
            return repository.Products
                .OrderBy(g => g.ProductId)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize); ;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}