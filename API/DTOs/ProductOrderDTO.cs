using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ProductOrderDTO
    {
        [Required]
        public IEnumerable<OrderItemDTO>? OrderItems { get; set; }
    }
}