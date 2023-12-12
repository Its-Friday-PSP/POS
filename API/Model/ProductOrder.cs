namespace API.Model
{
    public class ProductOrder
    {
        public IEnumerable<OrderItem>? OrderItems { get; set; }
    }
}