using API.Enums;

namespace API.Model
{
    public class OrderItem 
    {
        public Guid? Id { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ItemId { get; set; } // produkto arba serviso ID
        public int? Amount { get; set; }
        public int? Price { get; set; }
        public IEnumerable<OrderTypeEnum>? OrderType { get; set; }
        public OrderItem(Guid id) 
        {
            Id = id;
        }
    }
}
