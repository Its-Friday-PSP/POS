using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ServiceOrderDTO
    {
        [Required]
        public List<ServiceDTO> services{ get; set; }
    }
}