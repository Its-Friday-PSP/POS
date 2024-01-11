﻿
using API.DTOs;
using API.Enumerators;

namespace API.Model
{
    public abstract class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public OrderTypeDTO OrderType { get; set; }
        public DateTime Date { get; set; }
        public Price Price { get; set; }
        public Tip? Tip { get; set; }
        public List<Payment>? Payments { get; set; }
        public List<CustomerDiscount>? OrderDiscounts { get; set; }
        public Order(Guid customerId) : this()
        {
            CustomerId = customerId;
        }
        public Order()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
        }

        public Order(Guid orderId, Guid customerId)
        {
            Id = orderId;
            CustomerId = customerId;
            Date = DateTime.Now;
        }

    }
}
