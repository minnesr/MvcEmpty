using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEmpty.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult Index(int customerID)
        {
            return View("NewOrder", customerID);
        }

        public ActionResult New(int customerID)
        {
            return View("NewOrder", customerID);
        }


    }
}
