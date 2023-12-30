namespace API.Model
{
    public class ProductOrder : Order
    {
        public IEnumerable<OrderItem>? OrderItems { get; set; }

        public ProductOrder() { }

        public ProductOrder(Guid id, IEnumerable<OrderItem> orderItems) : base(id)
        {
            OrderItems = orderItems;
        }
    }
}