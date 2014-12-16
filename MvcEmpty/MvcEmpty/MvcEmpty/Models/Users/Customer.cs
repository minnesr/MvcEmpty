using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MvcEmpty.Models.Orders;
using MvcEmpty.Models.EF;

namespace MvcEmpty.Models.Users
{

    [Table("Customers")]
    public class Customer : BaseUser
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public List<Order> Orders {
            get {
                using (AppContext context = new AppContext())
                {
                    return context.Orders.Where(o => o.Customer.ID == this.ID).ToList();
                }
            }
        }

    }
}