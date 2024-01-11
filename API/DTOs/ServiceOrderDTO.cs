using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ServiceOrderDTO
    {
        public List<ServiceDTO> Services { get; set; }
    }
}