namespace API.Model
{
    public class ProductOrder : Order
    {
        public IEnumerable<OrderItem>? OrderItems { get; set; }
        
        public ProductOrder(Guid orderId) : base(orderId)
        {

        }
        
        public ProductOrder() : base()
        {

        }

    }
}