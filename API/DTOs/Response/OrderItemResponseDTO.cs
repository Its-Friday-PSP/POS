using API.Model;

namespace API.DTOs.Response
{
    public class OrderItemResponseDTO
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public int Index { get; set; }
    }
}
