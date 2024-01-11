namespace API.Model
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Index { get; set; }
        public int Amount { get; set; }
        public ProductOrder ProductOrder { get; set; }
    }
}
