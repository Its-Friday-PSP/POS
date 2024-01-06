using API.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class PaymentDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public PaymentState PaymentState { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
