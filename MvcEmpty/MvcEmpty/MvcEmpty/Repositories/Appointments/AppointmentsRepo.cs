using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcEmpty.Models.EF;
using MvcEmpty.Models.Appointments;

namespace MvcEmpty.Repositories.Appointments
{
    public class AppointmentsRepo
    {

        public AppContext context;

        public AppointmentsRepo()
        {
            context = new AppContext();
        }

        public List<Appointment> AllAppointments()
        {
            return context.Appointments.ToList();
        }

        public Appointment GetAppointment(int id)
        {
            return context.Appointments.FirstOrDefault(a=>a.ID==id);
        }

        public AppointmentType GetAppointmentType(int id)
        {
            return context.AppointmentTypes.FirstOrDefault(a => a.ID == id);
        }

        public Appointment SetCustomer(int CustomerID)
        {
           var customer= context.Customers.Find(CustomerID);
           var app = new Appointment();
           app.Customer = customer;
           return app;
        }

        public void InsertAppointment(Appointment app)
        {
            context.Appointments.Add(app);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}