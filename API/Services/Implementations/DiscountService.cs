using API.DTOs.Request;
using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services.Implementations
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly ICustomerRepository _customerRepository;

        public DiscountService(IDiscountRepository discountRepository, ICustomerRepository customerRepository)
        {
            _discountRepository = discountRepository;
            _customerRepository = customerRepository;
        }

        public Discount CreateDiscount(Discount discount)
        {
            return _discountRepository.CreateDiscount(discount);
        }

        public Discount GetDiscount(string code)
        {
            return _discountRepository.GetDiscount(code);
        }

        public IEnumerable<Discount> GetDiscounts()
        {
            return _discountRepository.GetDiscounts();
        }

        public bool UpdateDiscount(string code, Discount discount)
        {
            return _discountRepository.UpdateDiscount(code, discount);
        }

        public Discount CheckDiscount(Guid customerId, string code)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            var customerDiscounts = customer.CustomerDiscounts;
            var discount = _discountRepository.GetDiscount(code);

            if (!IsDiscountApplicable(customerDiscounts, customerId, discount))
            {
                return null;
            }

            return discount;
        }

        private bool IsDiscountApplicable(List<CustomerDiscount> customerDiscounts, Guid customerId, Discount discount)
        {
            DateTime todayDate = DateTime.Now;

            if (discount.ValidFrom > todayDate || todayDate > discount.ValidTo)
            {
                return false;
            }

            bool isUnused = customerDiscounts.Any(x =>
                !x.IsUsed &&
                x.DiscountId == x.DiscountId &&
                x.CustomerId == customerId);

            return isUnused;
        }

        public bool DeleteDiscounts(IEnumerable<string> discountIds)
        {
            return _discountRepository.DeleteDiscounts(discountIds);
        }

        public bool DeleteDiscount(string code)
        {
            return _discountRepository.DeleteDiscount(code);
        }
    }
}
