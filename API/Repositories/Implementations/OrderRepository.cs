﻿using API.DTOs;
using API.Enumerators;
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

        public Order AddTip(Guid orderId, long tip)
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
            if(order.OrderType == OrderTypeDTO.PRODUCT)
            {
                return _context.Orders
                    .Include(order => ((ProductOrder)order).OrderItems)
                    .First(order => order.Id == orderId);
        }
            else
            {
                return _context.Orders
                    .Include(order => ((ServiceOrder)order).Services)
                    .First(order => order.Id == orderId);
            }
        }

        public Order AddOrderItem(Guid orderId, OrderItem orderItem)
        {
            var order = GetOrder(orderId);
            var product = _context.Products.Find(orderItem.ProductId);

            if(product.AmountInStock >= orderItem.Amount)
            {
                product.AmountInStock -= orderItem.Amount;

                _context.OrderItems.Add(orderItem);
                _context.SaveChanges();
            }

            return order;
        }

        public bool RemoveOrderItem(Guid orderId, int orderItemIndex)
        {
            var productOrder = _context.ProductOrders
                .Include(po => po.OrderItems)
                .FirstOrDefault(po => po.Id == orderId);

            var orderItem = productOrder?.OrderItems
                .FirstOrDefault(oi => oi.Index == orderItemIndex);

            var product = _context.Products.Find(orderItem.ProductId);

            product.AmountInStock += orderItem.Amount;

            _context.OrderItems.Remove(orderItem);

            _context.SaveChanges();

            return true;
        }

        public Order CompleteOrder(Guid orderId)
        {
            var completedOrder = GetOrder(orderId);

            if(completedOrder.OrderType == OrderTypeDTO.SERVICE)
            {
                var serviceOrder = completedOrder as ServiceOrder;

                if(serviceOrder == null)
                {
                    return null;
                }

            }
            else
            {
                var productOrder = completedOrder as ProductOrder;

                if(productOrder.OrderItems == null)
                {
                    return null;
                }

                foreach(var orderItem in productOrder.OrderItems)
                {
                    var product = _context.Products.FirstOrDefault(x => x.Id == orderItem.ProductId);
                    
                    if(product == null)
                    {
                        continue;
                    }
                    product.AmountInStock -= orderItem.Amount;
                }

            }

            completedOrder.Status = OrderStatus.COMPLETED;
            _context.SaveChanges();

            return completedOrder;
        }

        public Order UpdateOrderStatus(Order order, OrderStatus orderStatus)
        {
            order.Status = orderStatus;
            _context.Update(order);
            _context.SaveChanges();
            return order;
        }
    }
}
