using System.Collections.Generic;

namespace Models
{  
    public class LineItem
    {

        public int ProductId { get; set; }
        private int _lineitemid;
        private Product _product = new Product();
      

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }
        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public int LineItemId
        {
            get { return _lineitemid; }  
            set { _lineitemid = value; }
        }
        public int StorefrontId
        {
            get ;  set;
        }
       public virtual StoreFront Storefront { get; set; }

        public override string ToString()
        {
            return $"LineItemId: {Product.ProductId} \nPrice: {Product.Price} \nName: {Product.Name} \nDescription: {Product.Description} \nCategory: {Product.Category} \nQuantity: {Quantity}";
        }
        public virtual List<LineItemOrder> LineItemOrders { get; set; }

    }
}