namespace EventTracking.Producer.Model
{

    public class Order
    {
        public int OrderId { get; set; }
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }        
    }

}
