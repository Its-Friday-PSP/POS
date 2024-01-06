namespace API.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Date { get; set; }

        public Order(Guid id)
        {
            Id = id;
        }
    }
}
