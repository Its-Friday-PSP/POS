using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ServiceDTO
    {
        public Guid? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public Boolean? Availability { get; set; }

    }
}
