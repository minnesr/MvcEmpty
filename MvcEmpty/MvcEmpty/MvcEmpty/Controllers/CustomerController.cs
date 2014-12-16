using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEmpty.Models.Users;
using MvcEmpty.Models.EF;
using MvcEmpty.Repositories.Customers;

namespace MvcEmpty.Controllers
{
    public class CustomerController : Controller
    {

        private ICustomerRepo CustomerRepository;

        public CustomerController()
        {
            this.CustomerRepository = new CustomerRepo(new AppContext());
        }
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            using (AppContext context = new AppContext())
            {
                return View("All", CustomerRepository.GetAllCustomers());
            }
        }

        public ActionResult Add()
        {
            return View("AddCustomer");
        }

        public ActionResult All()
        {
            using (AppContext context = new AppContext())
            {
                return View(CustomerRepository.GetAllCustomers());
            }
        }

        //
        // GET: /Customer/Details/5

        public ActionResult View(int id)
        {

            var cust = CustomerRepository.GetCustomer(id);
            if (cust != null)
                return View(cust);
            else
                return View();


        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            string stop = "stop";

            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(Customer cust)
        {
            try
            {
                // TODO: Add insert logic here

                CustomerRepository.InsertCustomer(cust);
                CustomerRepository.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }

        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
