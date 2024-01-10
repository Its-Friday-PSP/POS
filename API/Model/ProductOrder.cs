namespace API.Model
{
    public class ProductOrder : Order
    {
        public List<OrderItem>? OrderItems { get; set; }
        public ProductOrder(Guid customerId) : base(customerId)
        {

        }

        public ProductOrder(IEnumerable<OrderItem> orderItems) : base()
        {
            OrderItems = orderItems.ToList();
        }

        public ProductOrder(IEnumerable<OrderItem> orderItems, Guid customerId) : base(customerId)
        {
            OrderItems = orderItems.ToList();
        }

        public ProductOrder(IEnumerable<OrderItem> orderItems, Guid orderId, Guid customerId) : base(customerId)
        {
            OrderItems = orderItems.ToList();
        }

    }
}