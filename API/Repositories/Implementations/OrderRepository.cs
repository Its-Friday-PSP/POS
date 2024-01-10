using API.Model;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public Order AddTip(Guid orderId, Tip tip)
        {
            throw new NotImplementedException();
        }

        public Order CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }

        public bool DeleteOrder(Guid orderId)
        {
            var order = GetOrder(orderId);
            _context.Orders.Remove(order);
              
            return true;
        }

        public Order GetOrder(Guid orderId)
        {
            return _context.Orders.Find(orderId);
        }

        public Order AddOrderItem(Guid orderId, OrderItem orderItem)
        {
            var order = GetOrder(orderId);

            var product = _context.Products.Find(orderItem.ProductId);

            if(product.AmountInStock >= orderItem.Amount)
            {
                product.AmountInStock -= orderItem.Amount;

                orderItem.OrderId = orderId;
                _context.OrderItems.Add(orderItem);

                _context.SaveChanges();
            }

            return order;
        }

        public bool RemoveOrderItem(Guid orderId, int orderItemIndex)
        {
            var productOrder = _context.ProductOrders
                .Include(po => po.OrderItems)
                .SingleOrDefault(po => po.Id == orderId);

            var orderItem = productOrder?.OrderItems
                .SingleOrDefault(oi => oi.Index == orderItemIndex);

            var product = _context.Products.Find(orderItem.ProductId);

            product.AmountInStock += orderItem.Amount;

            _context.OrderItems.Remove(orderItem);

            _context.SaveChanges();

            return true;
        }

    }
}
