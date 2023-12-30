using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class OrderItemDTO
    {
        [Required]
        public Guid? ProductId { get; set; }
        [Required]
        public int? Amount { get; set; }
        [Required]
        public int? Index { get; set; }
    }
}