using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ServiceOrderDTO
    {
        [Required]
        public List<Guid>? ServiceId{ get; set; }
    }
}