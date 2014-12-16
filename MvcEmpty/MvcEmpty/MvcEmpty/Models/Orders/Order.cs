using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcEmpty.Models.Users;
using MvcEmpty.Models.Products;
using MvcEmpty.Models.EF;

namespace MvcEmpty.Models.Orders
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public double TotalCost
        {
            get
            {
                using (AppContext context = new AppContext())
                {
                    return context.OrderRows.Where(o => o.Order.ID == ID).Sum(o => o.TotalPrice);
                }
            }
        }

        public DateTime CreatedDate { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public List<OrderRow> Rows
        {
            get
            {
                using (AppContext context = new AppContext())
                {
                    return context.OrderRows.Where(o => o.Order.ID == ID).ToList();
                }
            }

        }

    }

    [Table("OrderRows")]
    public class OrderRow
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice
        {
            get
            {
                using (AppContext context = new AppContext())
                {
                    var prod = context.Products.FirstOrDefault(p => p.ID == ID);
                    if (prod != null)
                    {
                        return prod.Price * Quantity;
                    }
                    else
                        return 0.0;
                }
            }
        }

    }

}
