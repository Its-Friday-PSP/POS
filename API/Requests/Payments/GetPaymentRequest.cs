using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Payments
{
    public class GetPaymentRequest
    {
        [FromRoute(Name = "paymentId")]
        public Guid PaymentId { get; set; }
    }
}
