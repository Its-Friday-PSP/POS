using API.DTOs;
using API.DTOs.Request;
using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services.Implementations
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IServiceRepository _serviceRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IServiceRepository serviceRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _serviceRepository = serviceRepository;
        }

        public Order AddOrderItem(Guid orderId, OrderItem orderItem)
        {
            return _orderRepository.AddOrderItem(orderId, orderItem);
        }

        public Order AddTip(Guid orderId, Tip tip)
        {
            return _orderRepository.AddTip(orderId, tip);
        }

        public Order CreateOrder(OrderCreationRequestDTO orderRequest)
        {
            Order order;
            if(orderRequest.OrderType == OrderTypeDTO.SERVICE)
            {
                var services = _serviceRepository.GetServices(orderRequest.Services);
                order = new ServiceOrder(orderRequest.CustomerId, services);
            }
            else
            {
                Guid orderId = Guid.NewGuid();
                var orderItems = orderRequest.Products?.Select(orderItemDto =>
                    new OrderItem(orderItemDto.ProductId, orderId, orderItemDto.Amount, orderItemDto.Index)
                );

                order = new ProductOrder(orderItems, orderId, orderRequest.CustomerId);
            }

            order.Status = OrderStatus.PROCESSING;
            
            _orderRepository.CreateOrder(order);

            return order;
        }

        public bool DeleteOrder(Guid orderId)
        {
            return _orderRepository.DeleteOrder(orderId);
        }

        public Order GetOrder(Guid orderId)
        {
            return _orderRepository.GetOrder(orderId);
        }

        public bool RemoveOrderItem(Guid orderId, int orderItemIndex)
        {
            return _orderRepository.RemoveOrderItem(orderId, orderItemIndex);
        }
        
    }
}
