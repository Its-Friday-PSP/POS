using API.DTOs;

namespace API.Model
{
    public class ReceiptItem
    {
        public string ItemName { get; set; }
        public OrderTypeDTO ItemType { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountedAmount { get; set; }
        public decimal PartialTotal { get; set; }
    }
}
