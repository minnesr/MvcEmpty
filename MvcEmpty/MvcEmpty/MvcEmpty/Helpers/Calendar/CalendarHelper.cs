using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcEmpty.Models.ViewModels;
using MvcEmpty.Repositories.Appointments;

namespace MvcEmpty.Helpers.Calendar
{
    public static class CalendarHelper
    {

        public static List<CalendarDay> GetMonthlyAppointments(int daysInMonth, int year, int month, AppointmentsRepo appRepo)
        {
            var returnList = new List<CalendarDay>();

            for (int day = 1; day <= daysInMonth; day++)
            {
                var thisDay = new CalendarDay();
                thisDay.Date = new DateTime(year, month, day);

                foreach (var app in appRepo.AllAppointments().Where(a => a.Date.Date == thisDay.Date.Date))
                {
                    var thisApp = new CalendarApp();
                    thisApp.CustomerName = app.Customer.FirstName + " " + app.Customer.LastName;
                    thisApp.StartDate = app.Date;
                    thisApp.AppointmentID = app.ID;
                    thisDay.Appointments.Add(thisApp);
                }

                returnList.Add(thisDay);

            }

            return returnList;
        }

    }
}