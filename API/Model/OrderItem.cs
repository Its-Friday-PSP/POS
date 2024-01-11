namespace API.Model
{
    public class OrderItem
    {
        public List<ProductOrderItem> ProductOrderItems { get; set; }
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public int Index { get; set; }

    }
}
