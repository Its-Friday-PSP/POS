using API.Model;
using Microsoft.Identity.Client;

namespace API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Order CreateOrder(Order order);
        public Order CompleteOrder(Guid orderId);
        public Order GetOrder(Guid orderId);
        public Order AddOrderItem(Guid orderId, ProductOrderItem orderItem);
        public bool RemoveOrderItem(Guid orderId, int orderItemIndex);
        public bool DeleteOrder(Guid orderId);
        public Order AddTip(Guid orderId, Tip tip);
    }
}
