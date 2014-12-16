using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEmpty.Repositories.Appointments;
using MvcEmpty.Models.ViewModels;
using MvcEmpty.Models.Appointments;
using MvcEmpty.Models.Helpers;
using MvcEmpty.Repositories.Customers;
using MvcEmpty.Helpers.Calendar;

namespace MvcEmpty.Controllers
{
    public class AppointmentsController : Controller
    {
        //
        // GET: /Appointment/
        AppointmentsRepo appRepo = new AppointmentsRepo();

        public ActionResult Index()
        {
            return View("All", appRepo.AllAppointments());
        }

        public ActionResult All()
        {
            return View(appRepo.AllAppointments());
        }

        public ActionResult View(int id)
        {
            var app = appRepo.GetAppointment(id);

            if (app!=null)
                return View(new CustomerAppointment(app));

            return View("Index");
        }

        public ActionResult New(int id)
        {
            var app = new NewAppointment();            
            SelectList appTypes = new SelectList(DropdownHelper.AppointmentTypes(),"ID", "Name");
            ViewBag.AppointmentTypes = appTypes;
            
            app.CustomerID =id;

            return View(app);
        }


        [HttpPost]
        public ActionResult New(NewAppointment NewApp)
        {
            //var appType = appRepo.GetAppointmentType(ddlAppType);
            //app.Type = appType;
            //

            var custRepo = new CustomerRepo(appRepo.context);

            var app = new Appointment();
            app.Type = appRepo.GetAppointmentType(NewApp.AppointmentTypeID);
            app.Customer = custRepo.GetCustomer(NewApp.CustomerID);
            app.Notes = NewApp.AppointmentNotes;
            var date = new DateTime(NewApp.AppointmentDate.Year, NewApp.AppointmentDate.Month, NewApp.AppointmentDate.Day, NewApp.AppointmentStartTime.Hour, NewApp.AppointmentStartTime.Minute, NewApp.AppointmentStartTime.Second);
            app.Date = date;
            appRepo.InsertAppointment(app);
            appRepo.Save();
            return View("View", new CustomerAppointment(app));
        }

        //public ActionResult Calendar()
        //{

        //    ViewBag.daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        //    var calendarDays = CalendarHelper.GetMonthlyAppointments(ViewBag.daysInMonth, DateTime.Now.Year, DateTime.Now.Month, appRepo);

        //    ViewBag.Month = DateTime.Now.Month;
        //    ViewBag.Year = DateTime.Now.Year;
        //    return View(calendarDays);

        //}

        public ActionResult Calendar(DateTime? dateToShow)
        {
            if (dateToShow == null)
                dateToShow = DateTime.Now;

            ViewBag.daysInMonth = DateTime.DaysInMonth(dateToShow.Value.Year, dateToShow.Value.Month);
            var calendarDays = CalendarHelper.GetMonthlyAppointments(ViewBag.daysInMonth, dateToShow.Value.Year, dateToShow.Value.Month, appRepo);

            ViewBag.NextMonth = dateToShow.Value.AddMonths(1);
            ViewBag.LastMonth = dateToShow.Value.AddMonths(-1);
            return View(calendarDays);

        }

        //public ActionResult Next(DateTime? nextMonth)
        //{
        //    ViewBag.daysInMonth = DateTime.DaysInMonth(nextMonth.Value.Year, nextMonth.Value.Month);
        //    var calendarDays = CalendarHelper.GetMonthlyAppointments(ViewBag.daysInMonth, nextMonth.Value.Year, nextMonth.Value.Month, appRepo);

        //    ViewBag.NextMonth = nextMonth.Value.AddMonths(1);


        //    return View("Calendar", calendarDays);
        //}

    }
}
