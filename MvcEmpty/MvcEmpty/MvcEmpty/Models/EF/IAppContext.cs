using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcEmpty.Models.Users;
using MvcEmpty.Models.Orders;
using MvcEmpty.Models.Products;
using MvcEmpty.Models.Appointments;

namespace MvcEmpty.Models.EF
{
   public interface IAppContext
    {
         DbSet<Customer> Customers { get; set; }
         DbSet<Order> Orders { get; set; }
         DbSet<OrderRow> OrderRows { get; set; }
         DbSet<Product> Products { get; set; }
         DbSet<Appointment> Appointments { get; set; }
         DbSet<AppointmentType> AppointmentTypes { get; set; }


    }
}