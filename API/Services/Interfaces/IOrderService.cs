using API.DTOs.Request;
using API.Model;

namespace API.Services.Interfaces
{
    public interface IOrderService
    {
        public Order CreateOrder(OrderCreationRequestDTO order);
        public IEnumerable<Order> GetAllOrders();
        public Order CompleteOrder(Guid orderId);
        public Order GetOrder(Guid orderId);
        public Order AddOrderItem(Guid orderId, OrderItem orderItem);
        public bool RemoveOrderItem(Guid orderId, int orderItemIndex);
        public bool DeleteOrder(Guid orderId);
        public Order AddTip(Guid orderId, Tip tip);
    }
}
