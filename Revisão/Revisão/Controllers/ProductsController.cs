using Revisão.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Revisão.Controllers
{
    public class ProductsController : Controller
    {
        private EFContext context = new EFContext();
        //	GET:	Produtos
        public ActionResult Index()
        {
            var productList = context
                .Products
                .Include(c => c.Category)
                .Include(f => f.Supplier)
                .OrderBy(n => n.Name);
            return View(productList);
        }
    }
}