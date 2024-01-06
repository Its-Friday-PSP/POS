using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Implementations
{
    public class PaymentsRepository : IPaymentsRepository
    {
        public IActionResult CreatePayment()
        {
            throw new NotImplementedException();
        }

        public IActionResult DeletePayment(Guid paymentId)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetPayment(Guid paymentId)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetPayments()
        {
            throw new NotImplementedException();
        }

        public IActionResult UpdatePayment(Guid paymentId)
        {
            throw new NotImplementedException();
        }
    }
}
