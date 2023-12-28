using API.Model;
using API.Repositories.Interfaces;

namespace API.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        public Order AddOrderItem(Guid orderId, OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Order CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order DeleteOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Order RemoveOrderItem(Guid orderId, int orderItemIndex)
        {
            throw new NotImplementedException();
        }
    }
}
