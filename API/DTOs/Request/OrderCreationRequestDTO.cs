using API.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Request
{
    public class OrderCreationRequestDTO
    {
        [Required]
        public Guid CustomerId { get; set; }
        public OrderTypeDTO OrderType { get; set; }
        public IEnumerable<string>? DiscountCodes { get; set; }
        public IEnumerable<OrderItemCreationRequestDTO>? Products { get; set; }
        public Currency CurrentCurrency { get; set; }
        public OriginCountry CurrentCountry { get; set; }
        public IEnumerable<Guid>? Services { get; set; }
    }
}
