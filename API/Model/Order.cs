using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Order
    {
        [Required]
        public string? Id { get; set; }
        [Required]
        public OrderType? OrderType { get; set; }
        public ProductOrder? ProductOrder { get; set; }
        public ServiceOrder? ServiceOrder { get; set; }

    }
}
