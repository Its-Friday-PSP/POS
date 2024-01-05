using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ProductOrderDTO
    {
        public Guid? ProductId { get; set; }
        [Required]
        public IEnumerable<ProductDTO>? Products { get; set; }
        [Required]
        public int? Amount { get; set; }
        [Required]
        public decimal? Price { get; set; }
    }
}