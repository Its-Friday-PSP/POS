using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Payments
{
    public class UpdatePaymentRequest
    {
        [FromBody]
        public PaymentDTO Payment { get; set; }
    }
}
