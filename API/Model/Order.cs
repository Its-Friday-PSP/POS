using API.DTOs;
using API.Enums;

namespace API.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public OrderStatusEnum Status { get; set; }
        public OrderTypeEnum Currency { get; set; }
        public ICollection<OrderItemDTO> OrderItem { get; set; }
        public int? TotalPrice { get; set; }

        public Order(Guid id)
        {
            Id = id;
        }
    }
}
