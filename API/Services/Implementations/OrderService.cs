using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services.Implementations
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order AddOrderItem(string orderId, OrderItem orderItem)
        {
            return _orderRepository.AddOrderItem(orderId, orderItem);
        }

        public Order CreateOrder(Order order)
        {
            return _orderRepository.CreateOrder(order);
        }

        public Order DeleteOrder(string orderId)
        {
            return _orderRepository.DeleteOrder(orderId);
        }

        public Order GetOrder(string orderId)
        {
            return _orderRepository.GetOrder(orderId);
        }

        public Order RemoveOrderItem(string orderId, int orderItemIndex)
        {
            return _orderRepository.RemoveOrderItem(orderId, orderItemIndex);
        }
    }
}
