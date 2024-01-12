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
        public long Price { get; set; }
        public DateTime LastUpdated { get; set; }
        public long LoyaltyPoints { get; set; }

        public Payment() { }

        public Payment(Guid id, Guid orderId, PaymentType paymentType, PaymentState paymentState, long price, DateTime lastUpdated)
        {
            Id = id;
            OrderId = orderId;
            PaymentType = paymentType;
            PaymentState = paymentState;
            Price = price;
            LastUpdated = lastUpdated;
        }
    }
}
