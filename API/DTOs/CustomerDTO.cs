using API.Model;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CustomerDTO
    {
        public Guid? Id { get; set; }
        [Required]
        public AuthDTO? Auth { get; set; }
        public List<CustomerDiscount>? CustomerDiscounts { get; set; }
        public List<ServiceTimeSlots>? ServiceTimeSlots { get; set; }

    }
}
