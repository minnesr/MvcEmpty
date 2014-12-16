using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MvcEmpty.Models.Users;
using MvcEmpty.Repositories.Customers;
using MvcEmpty.Models.EF;

namespace MvcEmpty.Tests.Customers
{
    [TestFixture]
    class CustomerTests
    {
        AppContext context;
        //declarations ..
        [SetUp]
        public void Init()
        {
            context = new AppContext();
            //All initializations
        }

        [Test]
        public void IsNameEqual()
        {
            Assert.AreEqual("TestName", "TestName");
        }

        [Test]
        public void Does_Customer_Insert_Work()
        {

            Customer cust = new Customer { FirstName = "Ross", LastName = "Minnes", CreatedDate = DateTime.Now, ID = 1 };

            CustomerRepo repo = new CustomerRepo(context);

            repo.InsertCustomer(cust);

            var foundCustomer = repo.GetCustomer(cust.ID);

            Assert.IsTrue(foundCustomer != null);
            Assert.IsTrue(foundCustomer.FirstName == "Ross");
            Assert.IsTrue(foundCustomer.LastName == "Minnes");

        }

        [Test]
        public void Does_Customer_Delete_Work()
        {

            Customer cust = new Customer { FirstName = "Ross", LastName = "Minnes", CreatedDate = DateTime.Now, ID = 1 };

            CustomerRepo repo = new CustomerRepo(context);

            repo.InsertCustomer(cust);

            Assert.IsTrue(repo.GetCustomer(cust.ID) != null);

            repo.DeleteCustomer(cust.ID);

            Assert.IsTrue(repo.GetCustomer(cust.ID) == null);

        }

        [Test]
        public void Does_Customer_Update_Work()
        {

            Customer cust = new Customer { FirstName = "Ross", LastName = "Minnes", CreatedDate = DateTime.Now, ID = 1 };

            CustomerRepo repo = new CustomerRepo(context);
            repo.InsertCustomer(cust);            

            var custToEdit = repo.GetCustomer(cust.ID);

            var newFirstName = "Ross2";
            var newLastName = "Minnes2";

            custToEdit.FirstName = newFirstName;
            custToEdit.LastName = newLastName;

            repo.UpdateCustomer(custToEdit);



        }

    }
}
