using API.Migrations;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class OrderDTO
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid? CustomerId { get; set; }
        [Required]
        public OrderTypeDTO? OrderType { get; set; }
        public OrderStatusDTO? Status { get; set; }
        public CurrencyDTO? Currency { get; set; }
        public int? TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public ProductOrderDTO? ProductOrder { get; set; }
        public ServiceOrderDTO? ServiceOrder { get; set; }
    }
}
