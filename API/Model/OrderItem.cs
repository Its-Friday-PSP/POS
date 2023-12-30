using Microsoft.AspNetCore.Components.Forms;

namespace API.Model
{
    public class OrderItem
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public Guid OrderId { get; set; }
        public ProductOrder? Order { get; set; }

        public int Amount { get; set; }
        public int Index { get; set; }

        public OrderItem(Guid productId, Guid orderId, int amount, int index)
        {
            ProductId = productId;
            OrderId = orderId;
            Amount = amount;
            Index = index;
        }
    }
}