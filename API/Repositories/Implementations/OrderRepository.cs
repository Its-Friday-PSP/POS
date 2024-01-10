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
            //var customer = _context.Customers.Find(order.CustomerId);

            //if(order.OrderDiscounts == null || order.OrderDiscounts.Count == 0 || customer == null)
            //{
            //    return;
            //}

            //foreach(var orderDiscount in order.OrderDiscounts)
            //{
            //    if(!orderDiscount.IsUsed)
            //    {
            //        continue;
            //    }

            //    var usedDiscount = customer.CustomerDiscounts?.FirstOrDefault(
            //        x => x.CustomerId == orderDiscount.CustomerId &&
            //        x.DiscountId == orderDiscount.DiscountId
            //        );
            //    customer.CustomerDiscounts?.Remove(usedDiscount!);
            //}

            //_context.SaveChanges();

        }
    }
}
