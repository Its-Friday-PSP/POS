using API.DTOs;

namespace API.Responses.Payments
{
    public class GetPaymentResponse
    {
        public PaymentDTO Payment { get; set; }

        public GetPaymentResponse(PaymentDTO payment)
        {
            Payment = payment;
        }

    }
}
