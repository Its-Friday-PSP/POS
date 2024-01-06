using API.DTOs;

namespace API.Responses.Payments
{
    public class CreatePaymentResponse
    {
        public PaymentDTO Payment { get; set; }

        public CreatePaymentResponse(PaymentDTO payment)
        {
            Payment = payment;
        }

    }
}
