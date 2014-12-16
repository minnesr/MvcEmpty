using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcEmpty.Models.Appointments;

namespace MvcEmpty.Models.ViewModels
{
    public class CustomerAppointment
    {

        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentNotes { get; set; }
        public string CustomerName { get; set; }

        public CustomerAppointment(Appointment app)
        {

            AppointmentID = app.ID;
            AppointmentDate = app.Date;
            AppointmentNotes = app.Notes;
            CustomerName = app.Customer.FirstName + " " + app.Customer.LastName;
        }
    }
}