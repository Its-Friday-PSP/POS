using API.Model;

namespace API.Repositories.Interfaces
{
    public interface IDiscountRepository
    {
        public Discount CreateDiscount(Discount discount);
        public IEnumerable<Discount> GetDiscounts();
        public Discount GetDiscount(string discountId);
        public bool UpdateDiscount(string discountId, Discount discount);
        public bool DeleteDiscounts(IEnumerable<string> discountIds);
        public bool DeleteDiscount(string discountId);
    }
}
