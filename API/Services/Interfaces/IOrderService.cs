using API.Model;

namespace API.Services.Interfaces
{
    public interface IOrderService
    {
        public Order CreateOrder(Order order);
        public Order GetOrder(Guid orderId);
        public IEnumerable<Order> GetOrders();
        public OrderItem AddOrderItem(OrderItem orderItem);
        public bool RemoveOrderItem(Guid orderId, int orderItemId);
        public bool DeleteOrder(Guid orderId);
        public Order AddTip(Guid orderId, Tip tip);
    }
}
