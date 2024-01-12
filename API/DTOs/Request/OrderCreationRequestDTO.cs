using API.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Request
{
    public class OrderCreationRequestDTO
    {
        [Required]
        public Guid CustomerId { get; set; }
        public OrderTypeDTO OrderType { get; set; }
        public IEnumerable<OrderItemCreationRequestDTO>? Products { get; set; }
        public IEnumerable<Guid>? Services { get; set; }
        public decimal? Tip { get; set; }
        public long? LoyaltyPoints { get; set; } 
        public string? AppliedDiscount { get; set; }
    }
}
