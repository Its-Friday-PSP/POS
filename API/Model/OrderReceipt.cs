using API.DTOs;

namespace API.Model
{
    public class OrderReceipt
    {
        public Guid OrderId { get; set; }
        public IEnumerable<ReceiptItem> ReceiptItems { get; set; }
        public decimal Tip { get; set; }
        public decimal TotalPrice { get; set; }
        public long LoyaltyPoints { get; set; }

    }
}
