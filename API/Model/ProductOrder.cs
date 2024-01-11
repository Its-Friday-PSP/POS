namespace API.Model
{
    public class ProductOrder : Order
    {
        public List<OrderItem>? OrderItems { get; set; }
        public ProductOrder(Guid customerId) : base(customerId)
        {
            OrderType = Enumerators.OrderType.PRODUCT;
        }

        public ProductOrder(Guid orderId, Guid customerId) : base(orderId, customerId)
        {
            OrderType = Enumerators.OrderType.PRODUCT;
        }

    }
}