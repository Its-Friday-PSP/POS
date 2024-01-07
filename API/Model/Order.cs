namespace API.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid EmployeeId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Date { get; set; }
        public Tip? Tip { get; set; }
        public List<Payment> Payments { get; set; }

        public Order(Guid id)
        {
            Id = id;
        }
    }
}
