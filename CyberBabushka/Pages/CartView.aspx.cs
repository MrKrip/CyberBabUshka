﻿using System;
using System.Collections.Generic;
using System.Linq;
using CyberBabushka.Models.Repository;
using System.Web.Routing;
using CyberBabushka.Models;
using CyberBabushka.Pages.Helpers;


namespace CyberBabushka.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Repository repository = new Repository();
                int productId;
                if (int.TryParse(Request.Form["remove"], out productId))
                {
                    Product productToRemove = repository.Products
                        .Where(g => g.ProductId == productId).FirstOrDefault();
                    if (productToRemove != null)
                    {
                        SessionHelper.GetCart(Session).RemoveLine(productToRemove);
                    }
                }
            }
        }

        public IEnumerable<CartLine> GetCartLines()
        {
            return SessionHelper.GetCart(Session).Lines;
        }

        public decimal CartTotal
        {
            get
            {
                return SessionHelper.GetCart(Session).ComputeTotalValue();
            }
        }

        public string ReturnUrl
        {
            get
            {
                return SessionHelper.Get<string>(Session, SessionKey.RETURN_URL);
            }
        }
        public string CheckoutUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "checkout",
                    null).VirtualPath;
            }
        }
    }
}