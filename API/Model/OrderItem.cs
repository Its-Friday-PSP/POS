using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class OrderItem
    {
        [Required]
        public string? ProductId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int Index { get; set; }
    }
}