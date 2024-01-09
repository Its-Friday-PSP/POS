using API.Model;
using Microsoft.Identity.Client;

namespace API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Order CreateOrder(Order order);
        public Order GetOrder(Guid orderId);
        public Order AddOrderItem(Guid orderId, OrderItem orderItem);
        public Order RemoveOrderItem(Guid orderId, int orderItemIndex);
        public Order DeleteOrder(Guid orderId);
        public Order AddTip(Guid orderId, Tip tip);
    }
}
