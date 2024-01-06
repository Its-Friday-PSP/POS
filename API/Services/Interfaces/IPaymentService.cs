using API.Model;

namespace API.Services.Interfaces
{
    public interface IPaymentService
    {
        public Payment CreatePayment(Payment payment);
        public Payment GetPayment(Guid paymentId);
        public bool UpdatePayment(Guid paymentId, Payment payment);
        public bool DeletePayment(Guid paymentId);
        public List<Payment> GetPayments();

    }
}
