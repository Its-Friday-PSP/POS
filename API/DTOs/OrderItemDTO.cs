using API.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class OrderItemDTO
    {
        [Required]
        public Guid? Id { get; set; }
        [Required]
        public Guid? OrderId { get; set; }
        [Required]
        public Guid? ItemId { get; set; } // produkto arba serviso ID
        [Required]
        public int? Amount { get; set; }
        public int? Price { get; set; }
        public IEnumerable<OrderTypeEnum>? OrderType { get; set; }
    }
}