using API.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Payment
    {
        [Required]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentState PaymentState { get; set; }
        public DateTime Date { get; set; }

    }
}
