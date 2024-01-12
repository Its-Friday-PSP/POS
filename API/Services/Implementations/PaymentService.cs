using API.DTOs;
using API.Enumerators;
using API.Model;
using API.Repositories.Implementations;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using API.Shared;

namespace API.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentsRepository _paymentRepository;
        private readonly IProductRepository _productRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly ITaxRepository _taxRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IOrderRepository _orderRepository;

        public PaymentService(
            IPaymentsRepository paymentRepository,
            IProductRepository productRepository,
            IDiscountRepository discountRepository,
            ITaxRepository taxRepository,
            IServiceRepository serviceRepository,
            IOrderRepository orderRepository
            )
        {
            _paymentRepository = paymentRepository;
            _serviceRepository = serviceRepository;
            _taxRepository = taxRepository;
            _productRepository = productRepository;
            _discountRepository = discountRepository;
            _orderRepository = orderRepository;
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
