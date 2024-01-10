﻿using API.DTOs;
using API.DTOs.Request;
using API.Enumerators;
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

            if(orderRequest.OrderType == OrderTypeDTO.SERVICE)
            {
                var services = _serviceRepository.GetServices(orderRequest.Services);
                order = new ServiceOrder(orderRequest.CustomerId, services);

                order.OrderType = OrderType.SERVICE;

                order.Price = CalculateTotalPrice(services, orderRequest.DiscountCodes);
            }
            else
            {
                Guid orderId = Guid.NewGuid();
                
                var orderItems = orderRequest.Products?.Select(orderItemDto =>
                    new OrderItem(orderItemDto.ProductId, orderId, orderItemDto.Amount, orderItemDto.Index)
                );
                order = new ProductOrder(orderItems, orderId, orderRequest.CustomerId);
                
                order.OrderType = OrderType.PRODUCT;

                order.Price = CalculateTotalPrice(orderItems, orderRequest.DiscountCodes);
            }

            //var discounts = _discountRepository.GetDiscounts(orderRequest.DiscountCodes);

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

        private Price CalculateTotalPrice(IEnumerable<OrderItem> orderItems, IEnumerable<string> appliedDiscounts)
        {
            var productIds = orderItems.Select(x => x.ProductId);
            var products = _productRepository.GetProducts(productIds);

            long totalPrice = 0;

            foreach(var product in products)
            {
                long normalizedProductPrice = NormalizeCurrency(product.Price);
                long discountedProductPrice = ApplyDiscountTotalPrice(product.ApplicableDiscounts, appliedDiscounts, normalizedProductPrice);
                
                totalPrice += discountedProductPrice;
            }

            return new Price() { Amount = totalPrice, Currency = Currency.EUR };
        }

        private Price CalculateTotalPrice(IEnumerable<Service> orderServices, IEnumerable<string> appliedDiscountCodes)
        {
            long totalPrice = 0;

            foreach(var orderService in orderServices)
            {
                long normalizedOrderPrice = NormalizeCurrency(orderService.Price);
                long discountedServicePrice = ApplyDiscountTotalPrice(orderService.Discounts, appliedDiscountCodes, normalizedOrderPrice);

                totalPrice += discountedServicePrice;
            }

            return new Price() { Amount = totalPrice, Currency = Currency.EUR };
        }

        private long NormalizeCurrency(Price price) => price.Currency switch
        {
            Currency.GBP => 86 * price.Amount,
            Currency.PLN => 434 * price.Amount,
            _ => price.Amount,
        };

        private long ApplyDiscountTotalPrice(IEnumerable<Discount> productDiscounts, IEnumerable<string> appliedDiscountCodes, long productPrice)
        {
            if(productDiscounts == null)
            {
                return 0;
            }

            var appicableDiscounts = productDiscounts.Where(x => appliedDiscountCodes.Contains(x.Id));

            long resultPrice = productPrice;

            foreach(var discount in appicableDiscounts)
            {
                if(discount.DiscountType == DiscountType.FIXED)
                {
                    if(resultPrice - discount.Price!.Amount < 0)
                    {
                        return 0;
                    }

                    resultPrice -= discount.Price.Amount;
                }
                else if(discount.DiscountType == DiscountType.PERCENTAGE)
                {
                    resultPrice *= (long)(resultPrice * ((100 - discount.Percentage) / 100))!;
                }

            }

            return resultPrice;
        }

    }
}
