using API.DTOs.Request;
using API.Model;

namespace API.Services.Interfaces
{
    public interface IOrderService
    {
        public Order CreateOrder(OrderCreationRequestDTO order);
        public Order GetOrder(Guid orderId);
        public Order AddOrderItem(Guid orderId, OrderItem orderItem);
        public Order RemoveOrderItem(Guid orderId, int orderItemIndex);
        public Order DeleteOrder(Guid orderId);
        public Order AddTip(Guid orderId, Tip tip);
    }
}
