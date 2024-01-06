using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Payments
{
    public class DeletePaymentRequest
    {
        [FromRoute(Name = "paymentId")]
        public Guid PaymentId { get; set; }
    }
}
