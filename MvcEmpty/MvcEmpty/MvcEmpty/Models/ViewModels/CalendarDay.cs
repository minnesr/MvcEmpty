using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEmpty.Models.ViewModels
{
    public class CalendarDay
    {
        
        public DateTime Date { set; get; }
        public List<CalendarApp> Appointments { get; set; }

        public CalendarDay()
        {
            this.Appointments = new List<CalendarApp>();
        }
    }

    public class CalendarApp
    {
        public int AppointmentID { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
    }
}