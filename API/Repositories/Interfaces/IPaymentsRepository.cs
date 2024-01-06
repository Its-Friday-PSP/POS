using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Interfaces
{
    public interface IPaymentsRepository
    {
        Payment CreatePayment(Payment payment);
        IEnumerable<Payment> GetPayments();
        Payment GetPayment(Guid paymentId);
        public void UpdatePayment(Guid paymentId, Payment payment);
        public void DeletePayment(Guid paymentId);
    }
}
