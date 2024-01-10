using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class OrderItemDTO
    {
        public Guid ProductId { get; set; }
        public int Index { get; set; }
        public int Amount { get; set; }
    }
}