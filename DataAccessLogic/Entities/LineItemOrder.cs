using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entities
{
    public partial class LineItemOrder
    {
        public int LineItemOrderId { get; set; }
        public int? LineItemId { get; set; }
        public int? OrderId { get; set; }

        public virtual LineItem LineItem { get; set; }
        public virtual OrderPage Order { get; set; }
    }
}
