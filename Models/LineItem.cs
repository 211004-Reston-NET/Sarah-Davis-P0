namespace Models
{
    public class LineItem
    {
        private int _lineitemid;
        private Product _product;
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
        public override string ToString()
        {
            return $"LineItemId: {Product.ProductId} \nPrice: {Product.Price} \nName: {Product.Name} \nDescription: {Product.Description} \nCategory: {Product.Category} \nQuantity: {Quantity}";
        }

    }
}