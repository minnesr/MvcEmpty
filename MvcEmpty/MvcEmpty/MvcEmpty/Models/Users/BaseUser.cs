using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEmpty.Models.Users
{
    public abstract class BaseUser
    {
        
        public string FirstName {get; set;}
        public string LastName { get; set; }

    }
}