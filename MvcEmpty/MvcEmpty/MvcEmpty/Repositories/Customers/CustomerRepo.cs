using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcEmpty.Models.Users;
using MvcEmpty.Models.EF;
using System.Data.Entity;

namespace MvcEmpty.Repositories.Customers
{
    public class CustomerRepo : ICustomerRepo, IDisposable
    {
        private AppContext context;

        public CustomerRepo()
        {
            this.context = new AppContext();
        }

        public CustomerRepo(AppContext context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return this.context.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return this.context.Customers.Find(id);
        }

        public void InsertCustomer(Customer cust)
        {
            context.Customers.Add(cust);
        }

        public void DeleteCustomer(int id)
        {
            Customer cust = context.Customers.Find(id);
            context.Customers.Remove(cust);

        }

        public void UpdateCustomer(Customer cust)
        {
            context.Entry(cust).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}