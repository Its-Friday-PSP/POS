using API.Enums;

namespace API.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public OrderStatusEnum Status { get; set; }
        public OrderTypeEnum Type { get; set; }

        public Order(Guid id)
        {
            Id = id;
        }


        public Order() { }
    }
}
