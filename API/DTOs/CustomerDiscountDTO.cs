using API.Model;

namespace API.DTOs
{
    public class CustomerDiscountDTO
    {
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public string? DiscountId { get; set; }
        public Discount? Discount { get; set; }

        public bool? IsUsed { get; set; }
    }
}
