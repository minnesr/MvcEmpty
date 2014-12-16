using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEmpty.Models.Users;
using MvcEmpty.Models.EF;
using MvcEmpty.Models.Orders;

namespace MvcEmpty.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            using (var context = new AppContext())
            {
                Customer cust = new Customer { FirstName = "Ross", LastName = "Minnes", CreatedDate=DateTime.Now };
                context.Customers.Add(cust);
                Order ord = new Order { Customer = cust, CreatedDate=DateTime.Now };
                context.Orders.Add(ord);
                context.SaveChanges();                
           }

            return View();
        }

    }
}
