using API.Model;
using API.Repositories.Interfaces;

namespace API.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public OrderItem AddOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();

            return orderItem;
        }

        public Order AddTip(Guid orderId, Tip tip)
        {
            var order = _context.Orders.Find(orderId);

            if(order == null)
            {
                return null;
            }

            order.Tip = tip;
            _context.SaveChanges();

            return order;
        }

        public Order CreateOrder(Order order)
        {
            order.Id = new Guid();

            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }

        public bool DeleteOrder(Guid orderId)
        {
            var order = _context.Orders.Find(orderId);

            if(order == null)
            {
                return false;
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return true;
        }

        public Order GetOrder(Guid orderId)
        {
            return _context.Orders.Find(orderId);
        }

        public bool RemoveOrderItem(Guid orderId, int orderItemIndex)
        {
            var orderItem = _context.OrderItems
                .FirstOrDefault(item => item.Index == orderItemIndex && item.OrderId == orderId);

            if(orderItem == null)
            {
                return false;
            }

            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();

            return true;
        }
    }
}
