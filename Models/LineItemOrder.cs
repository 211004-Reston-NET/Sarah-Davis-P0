namespace Models
{
    public class LineItemOrder
    {
        public int LineItemOrderID { get; set; }
        public int LineItemId { get; set; }
        public int OrderId { get; set; }
        public LineItem LineItem { get; set; }
        public Order Order { get; set; }

    }
}