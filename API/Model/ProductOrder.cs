namespace API.Model
{
    public class ProductOrder : Order
    {
        public IEnumerable<OrderItem>? OrderItems { get; set; }
    }
}