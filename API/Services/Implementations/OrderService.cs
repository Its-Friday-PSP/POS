using API.Controllers;
using API.DTOs;
using API.DTOs.Request;
using API.Enumerators;
using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using API.Shared;
using Stripe;
using Stripe.Climate;
using System.Runtime.InteropServices;
using Order = API.Model.Order;
using Product = API.Model.Product;


namespace API.Services.Implementations
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly ITaxRepository _taxRepository;
        private readonly ICustomerRepository _customerRepository;

        private HashSet<string> _discountIds = new HashSet<string>();

        public OrderService(
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IServiceRepository serviceRepository,
            ITaxRepository taxRepository,
            ICustomerRepository customerRepository
            )
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _serviceRepository = serviceRepository;
            _taxRepository = taxRepository;
            _customerRepository = customerRepository;
        }

        public Order AddOrderItem(Guid orderId, OrderItem orderItem)
        {
            return _orderRepository.AddOrderItem(orderId, orderItem);
        }

        public Order AddTip(Guid orderId, long tip)
        {
            return _orderRepository.AddTip(orderId, tip);
        }

        public async Task<OrderReceipt> CreateOrder(OrderCreationRequestDTO orderRequest)
        {
            _discountIds.Clear();
            OrderReceipt orderReceipt = await GetOrderReceipt(orderRequest);

            Order order = new Order();

            if (orderRequest.Services != null && orderRequest.OrderType == OrderTypeDTO.SERVICE)
            {
                var services = _serviceRepository.GetServices(orderRequest.Services);
                order  = new ServiceOrder(orderRequest.CustomerId, services);
            }
            else if(orderRequest.Products != null && orderRequest.OrderType == OrderTypeDTO.PRODUCT)
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

                if (orderItems == null)
                {
                    new ArgumentException("No Items");
                }

                order = new ProductOrder(orderId, orderRequest.CustomerId) { OrderItems = orderItems };
            }

            orderReceipt.OrderId = order.Id;
            order.Status = OrderStatus.PROCESSING;

            var customer = _customerRepository.GetCustomer(orderRequest.CustomerId);

            customer.CustomerDiscounts.RemoveAll(x => _discountIds.Contains(x.DiscountId));

            _orderRepository.CreateOrder(order);

            return orderReceipt;
        }

        private async Task<OrderReceipt> GetOrderReceipt(OrderCreationRequestDTO orderRequest)
        {
            var orderReceipt = new OrderReceipt();
            List<ReceiptItem> receipItems = new();
            long totalPrice = 0;


            if (orderRequest.Services != null)
            {
                var services = _serviceRepository.GetServices(orderRequest.Services);

                foreach (var service in services)
                {
                    long subTotal = 0;

                    var receiptItem = new ReceiptItem()
                    {
                        ItemName = service.Name,
                        ItemId = service.Id,
                        ItemType = OrderTypeDTO.SERVICE,
                        Quantity = 1,
                        UnitPrice = (decimal) service.Price.Value / (decimal) Constants.DECIMAL_MULTIPLIER 
                    };

                    subTotal += service.Price.Value;

                    var discountedSubTotal = GetDiscountedAmount(OrderTypeDTO.SERVICE, orderRequest.CustomerId, orderRequest.AppliedDiscount, subTotal);
                    var taxAmount = GetServiceTaxAmount(service);

                    receiptItem.DiscountedAmount = ((decimal)discountedSubTotal / (decimal)Constants.DECIMAL_MULTIPLIER);
                    receiptItem.TaxAmount = (decimal)taxAmount / (decimal)Constants.DECIMAL_MULTIPLIER;
                    receiptItem.PartialTotal = (decimal)(subTotal + taxAmount) / (decimal)Constants.DECIMAL_MULTIPLIER;

                    subTotal -= discountedSubTotal;

                    receipItems.Add(receiptItem);

                    totalPrice += subTotal;
                    totalPrice += taxAmount;
                }


            }

            if (orderRequest.Products != null)
            {
                foreach (var orderItem in orderRequest.Products)
                {
                    long subTotal = 0;

                    var product = _productRepository.GetProduct(orderItem.ProductId);

                    var receiptItem = new ReceiptItem()
                    {
                        ItemName = product.Name,
                        ItemId = product.Id,
                        ItemType = OrderTypeDTO.PRODUCT,
                        Quantity = orderItem.Amount,
                        UnitPrice = (decimal) product.Price.Value / (decimal)Constants.DECIMAL_MULTIPLIER
                    };

                    subTotal += product.Price.Value * orderItem.Amount;
                    var taxAmount = GetServiceTaxAmount(product) * orderItem.Amount;

                    var discountedSubTotal = GetDiscountedAmount(OrderTypeDTO.PRODUCT, orderRequest.CustomerId, orderRequest.AppliedDiscount, subTotal);

                    receiptItem.DiscountedAmount = ((decimal)discountedSubTotal / (decimal)Constants.DECIMAL_MULTIPLIER);
                    receiptItem.TaxAmount = (decimal)taxAmount / (decimal)Constants.DECIMAL_MULTIPLIER;
                    receiptItem.PartialTotal = (decimal)(subTotal + taxAmount) / (decimal)Constants.DECIMAL_MULTIPLIER;

                    subTotal -= discountedSubTotal;

                    receipItems.Add(receiptItem);

                    totalPrice += subTotal;
                    totalPrice += taxAmount;
                }

            }

            orderReceipt.ReceiptItems = receipItems;

            if (orderRequest.LoyaltyPoints.HasValue && totalPrice > orderRequest.LoyaltyPoints)
            {
                totalPrice -= orderRequest.LoyaltyPoints.Value;
            }

            totalPrice += (long)(orderRequest.Tip * Constants.DECIMAL_MULTIPLIER);
            
            orderReceipt.LoyaltyPoints = orderRequest.LoyaltyPoints != null ? orderRequest.LoyaltyPoints.Value : 0;
            orderReceipt.Tip = orderRequest.Tip != null ? orderRequest.Tip.Value : 0;

            orderReceipt.TotalPrice = (decimal)totalPrice / (decimal)Constants.DECIMAL_MULTIPLIER;

            return orderReceipt;
        }

        private long GetDiscountedAmount(OrderTypeDTO orderType, Guid customerId, string discountCode, long price)
        {
            var customerDiscounts = _customerRepository.GetCustomer(customerId).CustomerDiscounts;
            var discount = customerDiscounts.FirstOrDefault(x => x.DiscountId == discountCode).Discount;
            var tempPrice = price;

            if(discount == null || _discountIds.Contains(discountCode))
            {
                return 0;
            }

            _discountIds.Add(discountCode);

            if (discount.DiscountType == DiscountType.FIXED && discount.ApplicableOrderType == orderType)
            {
                if(tempPrice < discount.Price)
                {
                    return 0;
                }

                tempPrice -= discount.Price.Value;
            }
            else if(discount.DiscountType == DiscountType.PERCENTAGE && discount.ApplicableOrderType == orderType)
            {
                tempPrice = (long)(tempPrice * ((100.0 - discount.Percentage) / 100.0));
            }

            return price - tempPrice;
        }

        private long GetServiceTaxAmount(Service service)
        {
            long taxAmount = 0;
            foreach(var taxItem in service.Taxes)
            {
                var tax = _taxRepository.GetTax(taxItem.TaxId);

                if (tax.Type == TaxType.FLAT)
                {
                    taxAmount += tax.Price.Value;
                }
                else if (tax.Type == TaxType.PERCENTAGE)
                {
                    if (service.Price == null || tax.Percentage == null)
                        continue;
                    taxAmount += (long)(service.Price * (1.0 + (tax.Percentage / 100.0)))! - service.Price.Value;
                }
            }
            return taxAmount;
        }

        private long GetServiceTaxAmount(Product product)
        {
            long taxAmount = 0;
            foreach (var taxItem in product.Taxes)
            {
                var tax = _taxRepository.GetTax(taxItem.TaxId);

                if (tax.Type == TaxType.FLAT)
                {
                    taxAmount += tax.Price.Value;
                }
                else if (tax.Type == TaxType.PERCENTAGE)
                {
                    if (product.Price == null || tax.Percentage == null)
                        continue;

                    taxAmount += (long)(product.Price * (1.0 + (tax.Percentage / 100.0)))! - product.Price.Value;
                }

            }

            return taxAmount;
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

        public Order CompleteOrder(Guid orderId)
        {
            return _orderRepository.CompleteOrder(orderId);
        }

    }
}
