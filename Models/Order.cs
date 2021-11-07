using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        
        public int OrderId { get; set; }
        public int LineItemId { get; set; }
        // public int LineItemOrderId { get; set; }
        private List<LineItem> _lineItem = new List<LineItem> ();
        public List<LineItem> LineItem
        {
            get { return _lineItem; }
            set { _lineItem = value; }
        }
        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }
        private string _storeLocation;
        public string StoreLocation
        {
            get { return _storeLocation; }
            set { _storeLocation = value; }
        }
        
        
        public int CustomerId { get; set; }
     
        
        public int StorefrontId { get; set; }
         public virtual Customer Customer { get; set; }
        
        public virtual List<LineItemOrder> LineItemOrders { get; set; }
        public virtual StoreFront Storefront { get; set; }

        
       
    }
}