using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEmpty.Models.EF;
using MvcEmpty.Models.Products;

namespace MvcEmpty.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(int id)
        {

            using (AppContext context = new AppContext())
            {
                var prod = context.Products.FirstOrDefault(p => p.ID == id);
                if (prod!=null)
                    return View("ViewProd",prod);
            }

            return View("ViewProd");
        }
        [HttpPost]
        public ActionResult View(Product prod)
        {
            var basket =  new List<int>();
            if (Session["basket"] != null)
            {                
                basket = (List<int>)Session["basket"];
                basket.Add(prod.ID);
            }

            basket.Add(prod.ID);
            Session["basket"] =basket;

            return View();
        }

    }
}
