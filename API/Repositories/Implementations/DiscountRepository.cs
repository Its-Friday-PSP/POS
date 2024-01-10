using API.Model;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly Context _context;
        public DiscountRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Discount> GetDiscounts()
        {
            return _context.Discounts;
        }

        public Discount GetDiscount(string discountId)
        {
            return _context.Discounts.Find(discountId);
        }

        public bool UpdateDiscount(string discountId, Discount discount)
        {
            var existingDiscount = _context.Discounts.Find(discountId);

            if (existingDiscount == null)
            {
                return false;
            }

            existingDiscount = discount;
            _context.SaveChanges();

            return true;
        }

        public Discount CreateDiscount(Discount discount)
        {
            _context.Discounts.Add(discount);
            _context.SaveChanges();

            return discount;
        }

        public bool DeleteDiscount(string discountId)
        {
            var discount = _context.Discounts.Find(discountId);

            if(discount == null)
            {
                return false;
            }

            _context.Discounts.Remove(discount);
            _context.SaveChanges(true);

            return true;
        }

        public bool DeleteDiscounts(IEnumerable<string> discountIds)
        {
            var discounts = _context.Discounts.Where(discount =>  discountIds.Contains(discount.Id));
            
            if(discounts == null || discounts.Count() == 0)
            {
                return false;
            }

            _context.Discounts.RemoveRange(discounts);
            _context.SaveChanges();

            return true;
        }

    }
}
