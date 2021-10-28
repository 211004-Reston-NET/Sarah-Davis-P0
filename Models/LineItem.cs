namespace Models
{
    public class LineItem
    {
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
        
    }
}