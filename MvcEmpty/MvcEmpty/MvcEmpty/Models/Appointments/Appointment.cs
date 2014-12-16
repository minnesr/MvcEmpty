using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcEmpty.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MvcEmpty.Models.ViewModels;

namespace MvcEmpty.Models.Appointments
{
    [Table("Appointments")]
    public class Appointment
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public AppointmentType Type { get; set; }


        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

    }

    [Table("AppointmentTypes")]
    public class AppointmentType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID {get;set;}
        public string Name {get;set;}

    }
}