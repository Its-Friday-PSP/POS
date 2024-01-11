namespace API.Model
{
    public class ProductOrderItem
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid OrderItemId { get; set; }
        public OrderItem? OrderItem { get; set; }

        public ProductOrderItem(Guid productId, Guid orderId)
        {
            ProductId = productId;
            OrderItemId = orderId;
        }

        public ProductOrderItem() { }
    }
}
