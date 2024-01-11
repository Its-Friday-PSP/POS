using API.Model;

namespace API.DTOs.Request
{
    public class ServiceCreationRequestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public PriceDTO Price { get; set; }
        public int DurationInMinutes { get; set; }
        public List<ServiceServiceTimeSlotsCreationRequestDTO> ServiceTimeSlots { get; set; }
        public string? StripeId { get; set; }

    }
}
