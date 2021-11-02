using System.Collections.Generic;

namespace Models
{
    public class StoreFront
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private List<Product> _listOfProduct;
        public List<Product> ListOfProducts
        {
            get { return _listOfProduct; }
            set { _listOfProduct = value; }
        }
        private List<Order> _listOfOrders;
        public List<Order> ListOfOrders
        {
            get { return _listOfOrders; }
            set { _listOfOrders = value; }
        }
        public int StoreFrontId { get; set; }
    }
}