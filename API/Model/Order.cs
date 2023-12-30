namespace API.Model
{
    public class Order
    {
        public Guid Id { get; set; }

        public Order(Guid id)
        {
            Id = id;
        }

        public Order() { }
    }
}
