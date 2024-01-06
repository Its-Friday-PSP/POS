using API.Model;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Implementations
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly Context _context;

        public PaymentsRepository(Context context)
        {
            _context = context;
        }

        public Payment CreatePayment(Payment payment)
        {
            payment.Id = new Guid();
            payment.LastUpdated = new DateTime();

            _context.Payments.Add(payment);
            _context.SaveChanges();

            return payment;
        }

        public bool DeletePayment(Payment payment)
        {
            _context.Payments.Remove(payment);
            _context.SaveChanges();

            return true;
        }

        public bool DeletePayment(Guid paymentId)
        {
            Payment payment = GetPayment(paymentId);
            _context.Payments.Remove(payment);
            _context.SaveChanges();

            return true;
        }

        public Payment GetPayment(Guid paymentId)
        {
            return _context.Payments.FirstOrDefault(x => x.Id == paymentId)!;
        }

        public List<Payment> GetPayments()
        {
            return _context.Payments.ToList();
        }

        public bool UpdatePayment(Guid paymentId, Payment newPayment)
        {
            Payment oldPayment = _context.Payments.FirstOrDefault(x => x.Id == paymentId)!;

            oldPayment = newPayment;
            oldPayment.LastUpdated = new DateTime();

            _context.SaveChanges();

            return true;
        }
    }
}
