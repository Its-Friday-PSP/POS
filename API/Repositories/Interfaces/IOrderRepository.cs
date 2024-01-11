using API.Model;

namespace API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Order CreateOrder(Order order);
        public Order GetOrder(Guid orderId);
        public IEnumerable<Order> GetAllOrders();
        public Order AddOrderItem(Guid orderId, OrderItem orderItem);
        public bool RemoveOrderItem(Guid orderId, int orderItemIndex);
        public bool DeleteOrder(Guid orderId);
        public Order AddTip(Guid orderId, Tip tip);
    }
}
