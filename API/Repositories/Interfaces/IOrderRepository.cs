using API.Model;

namespace API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Order CreateOrder(Order order);
        public Order GetOrder(Guid orderId);
        public OrderItem AddOrderItem(OrderItem orderItem);
        public bool RemoveOrderItem(Guid orderId, int orderItemId);
        public bool DeleteOrder(Guid orderId);
        public Order AddTip(Guid orderId, Tip tip);
    }
}
