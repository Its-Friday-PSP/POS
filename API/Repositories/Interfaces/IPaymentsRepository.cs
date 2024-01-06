using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Interfaces
{
    public interface IPaymentsRepository
    {
        public IActionResult CreatePayment();
        public IActionResult GetPayments();
        public IActionResult GetPayment(Guid paymentId);
        public IActionResult UpdatePayment(Guid paymentId);
        public IActionResult DeletePayment(Guid paymentId);
    }
}
