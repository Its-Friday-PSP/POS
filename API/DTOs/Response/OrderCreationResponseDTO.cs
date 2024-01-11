using API.Model;

namespace API.DTOs.Response
{
    public class OrderCreationResponseDTO
    {
        public Guid Id { get; set; }
        public OrderTypeDTO OrderType { get; set; }
        public PriceDTO Price { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<Discount> AppliedDiscounts { get; set; }
    }
}
