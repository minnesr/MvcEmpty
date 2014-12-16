using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcEmpty.Models.Users;

namespace MvcEmpty.Repositories.Customers
{
    interface ICustomerRepo : IDisposable
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        void InsertCustomer(Customer cust);
        void DeleteCustomer(int id);
        void UpdateCustomer(Customer cust);
        void Save();

    }
}