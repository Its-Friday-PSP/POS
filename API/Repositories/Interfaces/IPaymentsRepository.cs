using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Interfaces
{
    public interface IPaymentsRepository
    {
        Payment CreatePayment(Payment payment);
        List<Payment> GetPayments();
        Payment GetPayment(Guid paymentId);
        bool UpdatePayment(Guid paymentId, Payment payment);
        bool DeletePayment(Guid paymentId);
    }
}
