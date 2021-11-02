using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entities
{
    public partial class LineItem
    {
        public LineItem()
        {
            LineItemOrders = new HashSet<LineItemOrder>();
        }

        public int ProductId { get; set; }
        public int LineItemQuantity { get; set; }
        public int LineItemId { get; set; }
        public int StorefrontId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Storefront Storefront { get; set; }
        public virtual ICollection<LineItemOrder> LineItemOrders { get; set; }
    }
}
