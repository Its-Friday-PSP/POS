using API.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentState PaymentState { get; set; }
        public Price Price { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
