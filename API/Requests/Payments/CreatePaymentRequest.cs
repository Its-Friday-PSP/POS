using API.DTOs;

namespace API.Requests.Payments
{
    public class CreatePaymentRequest
    {
        public PaymentDTO Payment { get; set; }
    }
}
