using API.Model;

namespace API.Services.Interfaces
{
    public interface IDiscountService
    {
        public Discount CheckDiscount(Guid customerId, string code);
        public Discount GetDiscount(string discountId);
        public IEnumerable<Discount> GetDiscounts();
        public Discount CreateDiscount(Discount discount);
        public bool UpdateDiscount(string discountId, Discount discount);
        public bool DeleteDiscounts(IEnumerable<string> discountIds);
        public bool DeleteDiscount(string discountId);
    }
}
