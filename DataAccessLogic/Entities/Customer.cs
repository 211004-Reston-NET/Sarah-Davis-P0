using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            OrderPages = new HashSet<OrderPage>();
        }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int CustomerId { get; set; }

        public string CustomerPassword { get; set; }
        

        public virtual ICollection<OrderPage> OrderPages { get; set; }
    }
}
