﻿using API.Controllers;
using API.DTOs;
using API.DTOs.Request;
using API.Enumerators;
using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using API.Shared;


namespace API.Services.Implementations
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IDiscountRepository _discountRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IServiceRepository serviceRepository,
            IDiscountRepository discountRepository
            )
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _serviceRepository = serviceRepository;
            _discountRepository = discountRepository;
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


            if (orderRequest.OrderType == OrderTypeDTO.SERVICE)
            {
                var services = _serviceRepository.GetServices(orderRequest.Services);
                order = new ServiceOrder(orderRequest.CustomerId, services);

                order.Price = CalculateTotalPrice(services, orderRequest.DiscountCodes);
            }
            else
            {

                Guid orderId = Guid.NewGuid();
                
                List<OrderItem> orderItems = orderRequest.Products?.Select(orderItemDto =>
                    new OrderItem()
                    {
                        OrderId = orderId,
                        ProductId = orderItemDto.ProductId,
                        Amount = orderItemDto.Amount,
                        Index = orderItemDto.Index
                    }
                ).ToList()!;

                if(orderItems == null)
                {
                    new ArgumentException("No Items");
                }

                order = new ProductOrder(orderId, orderRequest.CustomerId) { OrderItems = orderItems };
                order.Price = CalculateTotalPrice(orderItems, orderRequest.DiscountCodes);
            }

            if (order.Price.Amount == 0)
            {
                return null;
            }

            order.Status = OrderStatus.PROCESSING;
            _orderRepository.CreateOrder(order);

            return order;
        }

        public bool DeleteOrder(Guid orderId)
        {
            return _orderRepository.DeleteOrder(orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }
        public Order GetOrder(Guid orderId)
        {
            return _orderRepository.GetOrder(orderId);
        }

        public bool RemoveOrderItem(Guid orderId, int orderItemIndex)
        {
            return _orderRepository.RemoveOrderItem(orderId, orderItemIndex);
        }

        private Price CalculateTotalPrice(IEnumerable<OrderItem> orderItems, IEnumerable<string> appliedDiscounts)
        {
            var productIds = orderItems.Select(x => x.ProductId);
            var products = _productRepository.GetProducts(productIds).ToList();

            long totalPrice = 0;

            foreach(var product in products)
            {
                long normalizedProductPrice = NormalizeCurrency(product.Price);

                var amount = orderItems.FirstOrDefault(x => x.ProductId == product.Id).Amount;
                normalizedProductPrice *= amount;

                long discountedProductPrice = ApplyDiscountTotalPrice(appliedDiscounts, OrderTypeDTO.PRODUCT, normalizedProductPrice);
                
                totalPrice += discountedProductPrice;
            }

            return new Price() { Amount = totalPrice, Currency = Currency.EUR };
        }

        private Price CalculateTotalPrice(IEnumerable<Service> orderServices, IEnumerable<string> appliedDiscounts)
        {
            long totalPrice = 0;

            foreach(var orderService in orderServices)
            {
                long normalizedOrderPrice = NormalizeCurrency(orderService.Price);
                long discountedServicePrice = ApplyDiscountTotalPrice(appliedDiscounts, OrderTypeDTO.SERVICE, normalizedOrderPrice);

                totalPrice += discountedServicePrice;
            }

            return new Price() { Amount = totalPrice, Currency = Currency.EUR };
        }

        private long NormalizeCurrency(Price price) => price.Currency switch
        {
            Currency.GBP => (long) 0.86 * Constants.DECIMAL_MULTIPLIER * price.Amount,
            Currency.PLN => (long) 4.34 * Constants.DECIMAL_MULTIPLIER * price.Amount,
            _ => price.Amount,
        };

        private long ApplyDiscountTotalPrice(IEnumerable<string> discountCodes, OrderTypeDTO orderType, long productPrice)
        {
            var discounts = _discountRepository.GetDiscounts(discountCodes);
            long resultPrice = productPrice;

            foreach(var discount in discounts)
            {
                if(discount.DiscountType == DiscountType.FIXED && discount.ApplicableOrderType == orderType)
                {
                    if(resultPrice - discount.Price!.Amount < 0)
                    {
                        return 0;
                    }

                    resultPrice -= discount.Price.Amount;
                }
                else if(discount.DiscountType == DiscountType.PERCENTAGE && discount.ApplicableOrderType == orderType)
                {
                    double percentage = (100.0 - (double) discount.Percentage!) / (double) Constants.DECIMAL_MULTIPLIER;
                    resultPrice = (long)(resultPrice * percentage);
                }

            }

            return resultPrice;
        }

        public Order CompleteOrder(Guid orderId)
        {
            return _orderRepository.CompleteOrder(orderId);
        }
    }
}
