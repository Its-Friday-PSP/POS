using API.Model;
using API.Repositories.Interfaces;

namespace API.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        public Order AddOrderItem(string orderId, OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Order CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order DeleteOrder(string orderId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(string orderId)
        {
            throw new NotImplementedException();
        }

        public Order RemoveOrderItem(string orderId, int orderItemIndex)
        {
            throw new NotImplementedException();
        }
    }
}
