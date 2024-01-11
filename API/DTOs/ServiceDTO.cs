using API.DTOs.Response;
using API.Model;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ServiceDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public PriceDTO? Price { get; set; }
        public int? DurationInMinutes { get; set; }
        [Required]
        public List<ServiceTimeSlotsDTO>? ServiceTimeSlots { get; set; }
    }
}
