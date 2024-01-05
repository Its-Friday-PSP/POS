using API.Enums;
using API.Migrations;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class OrderDTO
    {
        public Guid? Id { get; set; }
        [Required]
        public OrderTypeEnum? OrderType { get; set; }
        public string? Currency { get; set; }
        public ProductOrderDTO? ProductOrder { get; set; }
        public ServiceOrderDTO? ServiceOrder { get; set; }
    }
}
