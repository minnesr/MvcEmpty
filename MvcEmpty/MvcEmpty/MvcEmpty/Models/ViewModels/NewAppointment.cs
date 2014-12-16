using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcEmpty.Models.ViewModels
{
    public class NewAppointment
    {
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentStartTime { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public string AppointmentNotes { get; set; }
        public int AppointmentTypeID { get; set; }
        public int CustomerID { get; set; }
    }
}