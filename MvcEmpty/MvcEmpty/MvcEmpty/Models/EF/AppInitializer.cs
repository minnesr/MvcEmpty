using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcEmpty.Models.Products;
using MvcEmpty.Models.Appointments;

namespace MvcEmpty.Models.EF
{
    public class AppInitializer : DropCreateDatabaseIfModelChanges<AppContext>
    {

        protected override void Seed(AppContext context)
        {
            IList<Product> products = new List<Product>();

            products.Add(new Product() { Name = "product 1", Description = "script for product 1", Price = 10.00 });
            products.Add(new Product() { Name = "product 2", Description = "script for product 2", Price = 20.00 });
            products.Add(new Product() { Name = "product 3", Description = "script for product 3", Price = 30.00 });
            
            foreach (Product prod in products)
                context.Products.Add(prod);

            IList<AppointmentType> appTypes = new List<AppointmentType>();

            appTypes.Add(new AppointmentType { Name = "Initial" });
            appTypes.Add(new AppointmentType { Name = "Measuring" });
            appTypes.Add(new AppointmentType { Name = "Fitting" });
            appTypes.Add(new AppointmentType { Name = "Other" });

            foreach (var app in appTypes)
                context.AppointmentTypes.Add(app);

            //All standards will
            base.Seed(context);
        }
    }
}