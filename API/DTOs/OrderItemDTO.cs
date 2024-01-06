using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class OrderItemDTO
    {
        [Required]
        public Guid? Id { get; set; }
        [Required]
        public Guid? ItemId { get; set; }
        [Required]
        public int? Amount { get; set; }
        public int? Price { get; set; }
    }
}