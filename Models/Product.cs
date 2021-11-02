namespace Models
{
    public class Product
    {
        private int _Id;
        public int ProductId
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private decimal? _price;
        public decimal? Price
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

        public object LineItemId { get; internal set; }
    }
}