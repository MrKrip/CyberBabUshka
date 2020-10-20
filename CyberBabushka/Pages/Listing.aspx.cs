using CyberBabushka.Models;
using CyberBabushka.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using CyberBabushka.Pages.Helpers;
using System.Web.Routing;

namespace CyberBabushka.Pages
{
    public partial class Listing : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int selectedProductId;
                if (int.TryParse(Request.Form["add"], out selectedProductId))
                {
                    Product selectedProduct = repository.Products
                        .Where(g => g.ProductId == selectedProductId).FirstOrDefault();

                    if (selectedProduct != null)
                    {
                        SessionHelper.GetCart(Session).AddItem(selectedProduct, 1);
                        SessionHelper.Set(Session, SessionKey.RETURN_URL,
                            Request.RawUrl);

                        Response.Redirect(RouteTable.Routes
                            .GetVirtualPath(null, "cart", null).VirtualPath);
                    }
                }
            }
        }

        private Repository repository = new Repository();
        private int pageSize = 4;
        protected int CurrentPage
        {
            get
            {
                int page;
                page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                int prodCount = FilterProducts().Count();
                return (int)Math.Ceiling((decimal)repository.Products.Count() / pageSize);
            }
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ??
                Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }
        

        public IEnumerable<Product> GetProducts()
        {
            return FilterProducts()
                .OrderBy(g => g.ProductId)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize); ;
        }

        private IEnumerable<Product> FilterProducts()
        {
            IEnumerable<Product> products = repository.Products;
            string currentCategory = (string)RouteData.Values["category"] ??
                Request.QueryString["category"];
            return currentCategory == null ? products :
                products.Where(p => p.Category == currentCategory);
        }
        
    }
}