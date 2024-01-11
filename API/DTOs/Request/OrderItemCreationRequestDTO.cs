namespace API.DTOs.Request
{
    public class OrderItemCreationRequestDTO
    {
        public Guid ProductId { get; set; }
        public int Index { get; set; }
        public int Amount { get; set; }
    }
}
