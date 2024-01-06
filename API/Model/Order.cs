using API.DTOs;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public OrderTypeDTO? OrderType { get; set; }
        public OrderStatusDTO? Status { get; set; }
        public CurrencyDTO? Currency { get; set; }
        public DateTime Date { get; set; }
        public ProductOrderDTO? ProductOrder { get; set; }
        public ServiceOrderDTO? ServiceOrder { get; set; }

        public Order(Guid id)
        {
            Id = id;
        }
    }
}
