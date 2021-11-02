using System.Collections.Generic;

namespace Models
{
    public class Order
    {
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
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }
    }
}