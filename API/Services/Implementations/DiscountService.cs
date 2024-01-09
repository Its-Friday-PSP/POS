using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services.Implementations
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public Discount CreateDiscount(Discount discount)
        {
            return _discountRepository.CreateDiscount(discount);
        }

        public Discount GetDiscount(string discountId)
        {
            return _discountRepository.GetDiscount(discountId);
        }

        public IEnumerable<Discount> GetDiscounts()
        {
            return _discountRepository.GetDiscounts();
        }

        public bool UpdateDiscount(string discountId, Discount discount)
        {
            return _discountRepository.UpdateDiscount(discountId, discount);
        }

        public Discount CheckDiscount(string discountId)
        {
            var discount = _discountRepository.GetDiscount(discountId);

            if(discount == null)
            {
                return null;
            }

            if(!IsDiscountApplicable(discount))
            {
                return null;
            }

            return discount;
        }

        private bool IsDiscountApplicable(Discount discount)
        {
            DateTime todayDate = DateTime.Now;

            if (discount.ValidFrom > todayDate || todayDate > discount.ValidTo)
            {
                return false;
            }

            return true;
        }

        public bool DeleteDiscounts(IEnumerable<string> discountIds)
        {
            return _discountRepository.DeleteDiscounts(discountIds);
        }

        public bool DeleteDiscount(string discountId)
        {
            return _discountRepository.DeleteDiscount(discountId);
        }
    }
}
