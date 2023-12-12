using API.Model;

namespace API.Services.Interfaces
{
    public interface IOrderService
    {
        public Order CreateOrder(Order order);
        public Order GetOrder(string orderId);
        public Order AddOrderItem(string orderId, OrderItem orderItem);
        public Order RemoveOrderItem(string orderId, int orderItemIndex);
        public Order DeleteOrder(string orderId);
    }
}
