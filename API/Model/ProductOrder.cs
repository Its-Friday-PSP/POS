namespace API.Model
{
    public class ProductOrder : Order
    {
        public IEnumerable<OrderItem>? OrderItems { get; set; }
        public ProductOrder(Guid id) : base(id)
        {
        }
    }
}