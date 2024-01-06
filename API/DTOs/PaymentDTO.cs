using API.Enumerators;
using API.Model;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class PaymentDTO
    {
        [Required]
        public Guid Id { get; set; }
        public Guid? OrderId { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        public PaymentState? PaymentState { get; set; }
        public Price? Price { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
