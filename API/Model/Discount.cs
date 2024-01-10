using API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace API.Model
{
    public class Discount
    {
        public string Id { get; set; }
        public OrderTypeDTO DiscountType { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public Price Price { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsStackable { get; set; }
        public List<CustomerDiscount> CustomerDiscounts { get; set; }
    }
}
