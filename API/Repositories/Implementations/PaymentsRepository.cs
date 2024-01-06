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

            _context.Payments.Add(payment);
            _context.SaveChanges();

            return payment;
        }

        public void DeletePayment(Payment payment)
        {
            _context.Payments.Remove(payment);
            _context.SaveChanges();
        }

        public void DeletePayment(Guid paymentId)
        {
            Payment payment = GetPayment(paymentId);
            _context.Payments.Remove(payment);
            _context.SaveChanges();
        }

        public Payment GetPayment(Guid paymentId)
        {
            return _context.Payments.FirstOrDefault(x => x.Id == paymentId)!;
        }

        public IEnumerable<Payment> GetPayments()
        {
            return _context.Payments;
        }

        public void UpdatePayment(Guid paymentId, Payment newPayment)
        {
            Payment oldPayment = _context.Payments.FirstOrDefault(x => x.Id == paymentId)!;

            if(oldPayment == null)
            {
                return;
            }

            oldPayment = newPayment;

            _context.SaveChanges();
        }
    }
}
