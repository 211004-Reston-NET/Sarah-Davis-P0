namespace Models
{
    public class Product
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _category;
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        
        
    }
}