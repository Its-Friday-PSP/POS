using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentsRepository _paymentRepository;

        public PaymentService(IPaymentsRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Payment CreatePayment(Payment payment)
        {
            return _paymentRepository.CreatePayment(payment);
        }

        public bool DeletePayment(Guid paymentId)
        {
            return _paymentRepository.DeletePayment(paymentId);
        }

        public Payment GetPayment(Guid paymentId)
        {
            return _paymentRepository.GetPayment(paymentId);
        }

        public List<Payment> GetPayments()
        {
            return _paymentRepository.GetPayments();
        }

        public bool UpdatePayment(Guid paymentId, Payment payment)
        {
            return _paymentRepository.UpdatePayment(paymentId, payment);
        }
    }
}
