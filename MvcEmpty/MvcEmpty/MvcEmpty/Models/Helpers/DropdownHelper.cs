using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcEmpty.Models.Appointments;
using MvcEmpty.Models.EF;

namespace MvcEmpty.Models.Helpers
{
    public static class DropdownHelper
    {

        public static IEnumerable<AppointmentType> AppointmentTypes()
        {
            var context = new AppContext();
            return context.AppointmentTypes;
        }

    }
}