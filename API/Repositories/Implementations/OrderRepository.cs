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

        public Order CreateOrder(Order order)
        {
            HandleDiscounts(order);

            order.Id = Guid.NewGuid();

            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
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

        public Order AddTip(Guid orderId, Tip tip)
        {
            var order = _context.Orders.Find(orderId);

            if (order == null)
            {
                return null;
            }

            order.Tip = tip;
            _context.SaveChanges();

            return order;
        }

        private void HandleDiscounts(Order order)
        {
            var customer = _context.Customers.Find(order.CustomerId);

            foreach (var usedDiscount in order.Discounts)
            {
                var savedDiscount = customer.Discounts.FirstOrDefault(x => x.Id == usedDiscount.Id);
                if (savedDiscount != null)
                {
                    customer.Discounts.Remove(savedDiscount);
                }
            }
        }
    }
}
