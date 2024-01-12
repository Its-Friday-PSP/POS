using API.Enumerators;
using API.Model;

namespace API.DTOs.Response
{
    public class DiscountCreationResponseDTO
    {
        public string Id { get; set; }
        public DiscountType DiscountType { get; set; }
        public OrderTypeDTO ApplicableOrderType { get; set; }
        public string? Description { get; set; }
        public long? Percentage { get; set; }
        public decimal? Price { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsStackable { get; set; }
        public List<CustomerDiscount> CustomerDiscounts { get; set; }
    }
}
