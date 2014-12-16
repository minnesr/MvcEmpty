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
    public class AppContext : DbContext, IAppContext
    {
        public AppContext()
            : base("DefaultConnection") 
        {
            Database.SetInitializer<AppContext>(new AppInitializer());

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }



    }

    public class MockAppContext : IAppContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
    }



}