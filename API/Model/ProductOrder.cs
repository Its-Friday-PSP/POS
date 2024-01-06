namespace API.Model
{
    public class ProductOrder : Order
    {
        public IEnumerable<OrderItem>? OrderItems { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }

        public ProductOrder(Guid id) : base(id)
        {
        }
    }
}