using API.Enums;
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
        public IEnumerable<OrderStatusEnum>? Status { get; set; }
        public IEnumerable<CurrencyEnum>? Currency { get; set; }
        public List<OrderItemDTO>? OrderItem { get; set; }
        public int? TotalPrice { get; set; }
    }
}
