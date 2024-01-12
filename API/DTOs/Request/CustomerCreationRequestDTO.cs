using API.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace API.DTOs.Request
{
    public class CustomerCreationRequestDTO
    {
        public Guid? Id { get; set; }
        [Required]
        public AuthDTO? Auth { get; set; }
        public string? StripeId { get; set; }
        public List<string>? AvaialableDiscounts { get; set; }
        public List<ServiceTimeSlots>? ServiceTimeSlots { get; set; }
        public long LoyaltyPoints { get; set; }
    }
}
