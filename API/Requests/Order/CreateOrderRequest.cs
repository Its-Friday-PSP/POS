using API.DTOs;
using System.ComponentModel.DataAnnotations;

namespace API.Requests.Order
{
    public class CreateOrderRequest
    {
        [Required]
        public OrderDTO? Order { get; set; }
    }
}
