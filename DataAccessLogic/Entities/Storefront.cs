using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entities
{
    public partial class Storefront
    {
        public Storefront()
        {
            LineItems = new HashSet<LineItem>();
            OrderPages = new HashSet<OrderPage>();
        }

        public string StorefrontName { get; set; }
        public string StorefrontAddress { get; set; }
        public int StorefrontId { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
        public virtual ICollection<OrderPage> OrderPages { get; set; }
    }
}
