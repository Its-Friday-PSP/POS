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
        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders;
        }

        public Order? GetOrder(Guid orderId)
        {
            var order = _context.Orders.Find(orderId);

            if(order == null)
            {
                return null;
            }
            if(order.OrderType == Enumerators.OrderType.PRODUCT)
            {
                return _context.Orders.Include(order => ((ProductOrder)order).OrderItems).First(order => order.Id == orderId);
            }
            else
            {
                return _context.Orders.Include(order => ((ServiceOrder)order).Services).First(order => order.Id == orderId);
            }
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
