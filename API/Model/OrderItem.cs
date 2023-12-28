using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class OrderItem
    {
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }

        public Guid? OrderId { get; set; }
        public ProductOrder? Order { get; set; }

        public int? Amount { get; set; }
        public int? Index { get; set; }
    }
}