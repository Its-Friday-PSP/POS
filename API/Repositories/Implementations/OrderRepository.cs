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

        public Order AddOrderItem(Guid orderId, OrderItem orderItem)
        {
            throw new NotImplementedException();
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
