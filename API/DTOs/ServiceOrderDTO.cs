using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ServiceOrderDTO
    {
        public Guid? ServiceId { get; set; }
        [Required]
        public List<ServiceDTO>? Services { get; set; }
        [Required]
        public int? Amount { get; set; }
        [Required]
        public decimal? Price { get; set; }

    }
}