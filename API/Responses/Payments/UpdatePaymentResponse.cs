using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Responses.Payments
{
    public class UpdatePaymentResponse
    {
        public PaymentDTO Payment { get; set; }

        public UpdatePaymentResponse(PaymentDTO payment)
        {
            Payment = payment;
        }
    }
}
