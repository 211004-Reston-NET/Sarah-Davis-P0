using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entities
{
    public partial class OrderPage
    {
        public OrderPage()
        {
            LineItemOrders = new HashSet<LineItemOrder>();
        }

        public int OrderId { get; set; }
        public string OrderStorelocation { get; set; }
        public decimal? OrderTotalprice { get; set; }
        public int? StorefrontId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Storefront Storefront { get; set; }
        public virtual ICollection<LineItemOrder> LineItemOrders { get; set; }
    }
}
